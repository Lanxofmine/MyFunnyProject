using System;
using System.Drawing;
using System.Windows.Forms;

namespace HIA
{
    public partial class Form2 : Form
    {
        Point point;
        public Form2()
        {
            InitializeComponent();
            foreach (Control item in this.Controls)
            {
                if(item is Button)
                {
                    item.Click += new EventHandler(Lick);
                }
            }
        }
        private void Lick(object sendr,EventArgs e)
        {
            MessageBox.Show("我就知道你会点是的！");
        }
        
        private void Button2_MouseEnter(object sender, EventArgs e)
        {
            if (button2.Text.Equals("不是"))
            {
                point = new Point();
                point = button2.Location;
                if (point.Y > 40)
                    button2.Location = new Point(point.X, point.Y - 40);
                else
                {
                        button2.Location = new Point(point.X, point.Y + 80);
                        button2.Text = "是";
                        button1.Text = "不是";
                        button2.MouseEnter -= new EventHandler(Button2_MouseEnter);
                        button2.MouseEnter += new EventHandler(Button2Enter);
                }
            }

        }

        private void Button1_MouseEnter(object sender, EventArgs e)
        {
            if (button1.Text.Equals("不是"))
            {
                point = new Point();
                point = new Point(button1.Location.X, button1.Location.Y);
                if (button1.Location.Y > 40)
                    button1.Location = new Point(point.X, point.Y - 40);
                else
                {
                    button1.Location = new Point(point.X, point.Y + 80);
                    button1.Text = "是";
                    button2.Text = "不是";
                    button1.MouseEnter -= new EventHandler(Button1_MouseEnter);
                    button1.MouseEnter += new EventHandler(Button1Enter);
                }
            }
        }
        public void Button1Enter(object sender, EventArgs e)
        {
            if (button1.Text.Equals("不是"))
            {
                button1.Text = "是";
                button2.Text = "不是";
                button1.MouseEnter += new EventHandler(Button1_MouseEnter);
            }
        }
        public void Button2Enter(object sender, EventArgs e)
        {
            if (button2.Text.Equals("不是"))
            {
                button2.Text = "是";
                button1.Text = "不是";
                button2.MouseEnter += new EventHandler(Button2_MouseEnter);
            }
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("关了窗体也不能否认你是煞笔的事实！");
        }

    }
}
