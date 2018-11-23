using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        #region 变量
        private const int PORT = 51388;
        private TcpClient tcpClient = null;
        IPAddress ipAddress;

        private delegate void ShowMessage(string str);
        //private ShowMessage ShowMessageCallback;

        private delegate void ResetMessage();
        //private ResetMessage ResetMessageCallback;
        #endregion
        public Form1()
        {
            InitializeComponent();
            tcpClient = new TcpClient();
            //ShowMessageCallback = new ShowMessage(showMessage);
            //ResetMessageCallback = new ResetMessage(resetMessage);
            ipAddress = IPAddress.Loopback;
            txtServerIP.Text = ipAddress.ToString();
            txtServerPort.Text = PORT.ToString();
            System.Timers.Timer timer = new System.Timers.Timer()
            {
                Enabled = true,
                Interval = 1000 //执行间隔时间,单位为毫秒; 这里实际间隔为10分钟  
            };
            timer.Start();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(showMessage);
        }
        private void showMessage(object source, ElapsedEventArgs e)
        {
            NetworkStream reciveStream = tcpClient.GetStream();
            byte[] buffer = new byte[8192];
            int msgSize;
            while (true)
            {
                try
                {
                    lock (reciveStream)
                    {
                        msgSize = reciveStream.Read(buffer, 0, 8192);
                    }
                    if (msgSize == 0)
                        return;
                    string msg = Encoding.Default.GetString(buffer);
                    msg = msg.Replace("\0", "").Trim();
                    txtShow.AppendText("服务器：\r\n    " + msg + "\r\n\r\n");
                }
                catch { }
            }
        }

        //private void resetMessage()
        //{

        //}

        private void 敏感词过滤ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SFilter s = new SFilter();
            s.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            txtShow.Clear();
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIn.Text))
            {
                MessageBox.Show("发送内容不能为空哟");
                return;
            }
            if (!tcpClient.IsOnline())
            {
                MessageBox.Show("网络不通");
                return;
            }
            string preStr = txtIn.Text.ToString().Trim();
            foreach (string item in StrFilter.strs)
            {
                string filterstr = "";
                for (int i = 0; i < item.Length; i++)
                {
                    filterstr += "*";
                }
                preStr = preStr.Replace(item, filterstr);
            }
            txtShow.Text += "客户端:\r\n    " + preStr + "\r\n\r\n";
            NetworkStream dataStream = tcpClient.GetStream();
            byte[] buffer = Encoding.Default.GetBytes(preStr.Trim());
            dataStream.Write(buffer, 0, buffer.Length);
            txtIn.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                tcpClient.Connect(ipAddress, PORT);
                if (tcpClient.IsOnline())
                {
                    MessageBox.Show("连接成功");
                }
            }
            catch
            {
                MessageBox.Show("哎呀！网络好像不通畅。");
            }
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            if (!tcpClient.IsOnline())
            {
                try
                {
                    tcpClient = new TcpClient();
                    tcpClient.Connect(IPAddress.Parse(txtServerIP.Text), int.Parse(txtServerPort.Text.ToString()));
                    if (tcpClient.IsOnline())
                    {
                        MessageBox.Show("连接成功");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("网络不通。" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("刷新成功");
            }
        }
    }
    public static class TcpClientEx
    {
        public static bool IsOnline(this TcpClient c)
        {
            return !((c.Client.Poll(1000, SelectMode.SelectRead) && (c.Client.Available == 0)) || !c.Client.Connected);
        }
    }
}