using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DrawApp
{
    public partial class Form1 : Form
    {
        static List<Point> points=new List<Point>();
        static bool single=false;
        static bool singleZ = false;
        static Graphics gca;
        static Color color;
        public Form1()
        {
            InitializeComponent();
            toolStripComboBox1.SelectedIndexChanged += new EventHandler(SelectItem);
        }
        private void SelectItem(object sender,EventArgs e)
        {
            singleZ = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripComboBox1.SelectedIndex = 0;
            color= Color.FromKnownColor(KnownColor.Black);
            gca = panel1.CreateGraphics();
        }

        private void 选色ToolStripMenuItem_Click_1(object sender,EventArgs e)
        {
            ColorDialog ColorForm = new ColorDialog();
            if (ColorForm.ShowDialog() == DialogResult.OK)
            {
                color = ColorForm.Color;
            }
        }
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!singleZ)
            {
                points.Clear();
                singleZ = true;
            }
            points.Add(e.Location);
            Pen pen = new Pen(color);
            switch (toolStripComboBox1.SelectedItem.ToString().Trim())
            {
                case "直线":
                case "圆":
                    if (single)
                    {
                        singleZ = true;
                        single = false;
                    }
                    else
                    {
                        if (points.Count > 1)
                        {
                            points.Clear();
                            points.Add(e.Location);
                        }
                        single = true;
                    }
                    break;
                case "折线":
                    single = true;
                    break;
                default:
                    single = true;
                    break;
            }
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Pen pen = new Pen(color);
            switch (toolStripComboBox1.SelectedItem.ToString().Trim())
            {
                case "圆":
                    if (single)
                    {
                        gca.Clear(panel1.BackColor);
                        float dis = (float)Math.Sqrt((e.Location.X-points[points.Count-1].X)* (e.Location.X - points[points.Count - 1].X)
                            + (e.Location.Y - points[points.Count - 1].Y)* (e.Location.Y - points[points.Count - 1].Y));
                        gca.DrawEllipse(pen,points[points.Count-1].X-dis, points[points.Count - 1].Y - dis,2*dis,2*dis);
                    }
                    break;
                case "多边形":
                    if (single)
                    {
                        gca.Clear(panel1.BackColor);
                        points.Add(e.Location);
                        if (points.Count > 1)
                            gca.DrawPolygon(pen, points.ToArray());
                        gca.FillPolygon(new SolidBrush(color), points.ToArray());
                        points.RemoveAt(points.Count - 1);
                    }
                    break;
                default:
                    if (single)
                    {
                        gca.Clear(panel1.BackColor);
                        if (points.Count > 1)
                            gca.DrawLines(pen, points.ToArray());
                        if(points.Count>0)
                        gca.DrawLine(pen, points[points.Count - 1], e.Location);
                    }
                    break;
            }
        }

        private void Panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            singleZ = false;
            single = false;
        }

        private void 重绘ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gca.Clear(panel1.BackColor);
        }

        private void 撤销ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (points.Count > 0)
                points.RemoveAt(points.Count - 1);
            else if(singleZ)
            {
                DialogResult a= MessageBox.Show("已完成的绘图无法撤销,是否清空重绘？", "tips",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (a == DialogResult.OK)
                {
                    gca.Clear(panel1.BackColor);
                    singleZ = false;
                }
            }
            Pen pen = new Pen(color);
            switch (toolStripComboBox1.SelectedItem.ToString().Trim())
            {
                case "折线":
                    gca.Clear(panel1.BackColor);
                    if (points.Count > 1)
                        gca.DrawLines(pen, points.ToArray());
                    break;
                case "多边形":
                    gca.Clear(panel1.BackColor);
                    if (points.Count > 1)
                        gca.DrawPolygon(pen, points.ToArray());
                    break;
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs points)
        {
            string file = null;
            string Type = null;
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                FilterIndex=2,
                Title = "请选择文件",
                Filter = "文本文件|*.txt"
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                file = fileDialog.FileName;
                string[] data = File.ReadAllLines(file, Encoding.UTF8);
                Form1.points.Clear();
                Type = data[0];
                List<string> Dat = data.ToList<string>();
                Dat.RemoveAt(0);
                foreach (string item in Dat)
                {
                    string[] point = item.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    try
                    {
                        Form1.points.Add(new Point(int.Parse(point[0]), int.Parse(point[1])));
                    }
                    catch { }
                }
                Pen pen = new Pen(color);
                gca.Clear(panel1.BackColor);
                switch (Type)
                {
                    case "圆":
                        float dis = (float)Math.Sqrt((Form1.points[0].X - Form1.points[Form1.points.Count - 1].X) * (Form1.points[0].X - Form1.points[Form1.points.Count - 1].X)
                            + (Form1.points[0].Y - Form1.points[Form1.points.Count - 1].Y) * (Form1.points[0].Y - Form1.points[Form1.points.Count - 1].Y));
                        gca.DrawEllipse(pen, Form1.points[0].X - dis, Form1.points[0].Y - dis, 2 * dis, 2 * dis);
                        break;
                    case "多边形":
                        gca.DrawPolygon(pen, Form1.points.ToArray());
                        gca.FillPolygon(new SolidBrush(color), Form1.points.ToArray());
                        break;
                    default:
                        gca.DrawLines(pen, Form1.points.ToArray());
                        break;
                }
            }
        }

        private void SaveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Title="另存为",
                Filter = "文本文件|*.txt"
            };
            if (points.Count == 0)
            {
                MessageBox.Show("无数据可保存");
                return;
            }
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string msg = toolStripComboBox1.SelectedItem.ToString()+"\r\n";
                foreach (Point item in points)
                {
                    msg += item.X.ToString() + "," + item.Y.ToString() + "\r\n";
                }
                using (StreamWriter sw=new StreamWriter(saveFileDialog.FileName))
                {
                    sw.WriteLineAsync(msg);
                }
            }
        }
    }
}
