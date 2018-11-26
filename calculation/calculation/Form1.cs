using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculation
{
    public partial class Form1 : Form
    {
        static Stack<string> totalExp = new Stack<string>();
        public Form1()
        {
            InitializeComponent();
            foreach (Control item in panel1.Controls)
            {
                item.Click +=  new EventHandler(GetInput);
            }
        }

        private void GetInput(object sender, EventArgs e)
        {
            Button a = (Button)sender;
            totalExp.Push(a.Text.Trim());
            GetExp();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly=true;
            textBox2.ReadOnly = true;
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            totalExp.Pop();
            GetExp();
        }
        string GetExp()
        {
            string FinalExp = "";
            int count = totalExp.Count;
            string[] b = totalExp.ToArray();
            for (int i=count-1;i>-1;i--)
            {
                FinalExp += b[i];
            }
            textBox1.Text = FinalExp;
            try
            {
                textBox2.Text = new DataTable().Compute(FinalExp, "").ToString();
            }
            catch
            {

            }
            return FinalExp;
        }
        private void Button11_Click(object sender, EventArgs e)
        {
            totalExp.Clear();
            GetExp();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = new DataTable().Compute(GetExp(), "").ToString();
            }
            catch
            {
                MessageBox.Show("输入语法有误请检查后重试");
            }
        }
    }
}
