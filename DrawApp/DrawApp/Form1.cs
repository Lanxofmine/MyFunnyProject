using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawApp
{
    public partial class Form1 : Form
    {
        static List<Point> points=new List<Point>();
        static bool single=false;
        static bool singleZ = false;
        static Graphics gca;
        static Graphics g;
        static Color color;
        public Form1()
        {

            InitializeComponent();
            
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripComboBox1.SelectedIndex = 0;
            color= Color.FromKnownColor(KnownColor.Black);
            gca = panel1.CreateGraphics();
            g = panel1.CreateGraphics();
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
            points.Add(e.Location);
            Pen pen = new Pen(color);
            switch (toolStripComboBox1.SelectedItem.ToString().Trim())
            {
                case "直线":
                    if (single)
                    {
                        points.Clear();
                        singleZ = true;
                        single = false;
                    }
                    else
                        single = true;
                    
                    break;
                case "折线":
                    single = true;
                    break;
                case "圆":
                    if (single)
                    {
                        points.Clear();
                        singleZ = true;
                        single = false;
                    }
                    else
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

        private void 撤销ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 选色ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            points.Clear();
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
    }
}
