using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        
        public Form1()
        {
            InitializeComponent();
        }
        #region
        private Point downPoint;
        private bool catchFinished = false;
        private bool catchStart = false;
        private Bitmap originBitmap;
        private Rectangle catchRectangle;
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
         Bitmap catchBmap = new Bitmap(
            Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);
         Graphics g = Graphics.FromImage(catchBmap);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(
                Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height));
            this.FormBorderStyle = FormBorderStyle.None;
            this.Cursor = Cursors.Cross;
            this.BackgroundImage = catchBmap;
            originBitmap = new Bitmap(this.BackgroundImage);
            this.WindowState = FormWindowState.Maximized;
            g.Dispose();
        }

        private void Mouse_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!catchStart&&catchRectangle.IsEmpty)
                {
                    catchStart = true;
                    downPoint = new Point(e.X, e.Y);
                }
            }
        }

        private void Form_DoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && catchFinished)
            {
                Bitmap bitmap = new Bitmap(catchRectangle.Width, catchRectangle.Height);
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawImage(originBitmap, new Rectangle(downPoint.X, downPoint.Y, catchRectangle.Width, catchRectangle.Height));
                bitmap=(Bitmap)originBitmap.Clone(new Rectangle(downPoint.X, downPoint.Y, catchRectangle.Width, catchRectangle.Height),originBitmap.PixelFormat);
                Clipboard.SetImage(bitmap);
                catchFinished = false;
                this.BackgroundImage = originBitmap;
                bitmap.Dispose();
                g.Dispose();
                this.Close();
            }
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (catchStart)
            {
                Bitmap bitmap = (Bitmap)originBitmap.Clone();
                Point newPoint = new Point(downPoint.X, downPoint.Y);
                Graphics graphics = Graphics.FromImage(bitmap);
                Pen pen = new Pen(Color.White, 2);
                int width = Math.Abs(e.X - newPoint.X);
                int height = Math.Abs(e.Y - newPoint.Y);
                newPoint.X = e.X< newPoint.X?e.X:newPoint.X;
                newPoint.Y = e.Y < newPoint.Y ? e.Y : newPoint.Y;
                catchRectangle = new Rectangle(newPoint, new Size(width, height));
                graphics.DrawRectangle(pen, catchRectangle);
                pen.Dispose();
                graphics.Dispose();
                Graphics graphics1 = this.CreateGraphics();
                graphics1.DrawImage(bitmap, new Point(0, 0));
                graphics1.Dispose();
                bitmap.Dispose();
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            if (catchStart) {
                catchStart = false;
                catchFinished = true;
            }
        }
    }
}
