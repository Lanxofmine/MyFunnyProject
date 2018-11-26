using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void FitNum()
        {
             void FitS(DataGridView a)
            {
                a.ColumnCount = (int)numericUpDown1.Value;
                a.RowCount = (int)numericUpDown1.Value;
                foreach (DataGridViewTextBoxColumn item in a.Columns)
                {
                    item.Width = (a.Width - 1) / a.ColumnCount - 1;
                }
                foreach (DataGridViewRow item in a.Rows)
                {
                    item.Height = (a.Height - 1) / a.RowCount - 1;
                }
            }
            FitS(dataGridView1);
            FitS(dataGridView2);
            FitS(dataGridView3);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            FitNum();
            comboBox1.SelectedIndex = 0;
            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
            dataGridView3.ClearSelection();
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            FitNum();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            FitNum();
            foreach (DataGridViewRow item in dataGridView2.Rows)
            {
                foreach (DataGridViewCell itm in item.Cells)
                {
                    itm.Value = new Random(Guid.NewGuid().GetHashCode()).Next(0, 100);
                }
            }
        }
        private void Add()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows[i].Cells.Count; j++)
                {
                    dataGridView3.Rows[i].Cells[j].Value = int.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString().Trim()) + int.Parse(dataGridView2.Rows[i].Cells[j].Value.ToString().Trim());
                }
            }
        }
        private void Sub()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows[i].Cells.Count; j++)
                {
                    dataGridView3.Rows[i].Cells[j].Value = int.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString().Trim()) - int.Parse(dataGridView2.Rows[i].Cells[j].Value.ToString().Trim());
                }
            }
        }
        private void Mul()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                for (int j = 0; j < dataGridView1.Rows[i].Cells.Count; j++)
                {
                    int a = 0;
                    for (int k = 0; k < dataGridView1.Rows[i].Cells.Count; k++)
                      a+= int.Parse(dataGridView1.Rows[i].Cells[k].Value.ToString().Trim()) * int.Parse(dataGridView2.Rows[k].Cells[j].Value.ToString().Trim());
                    dataGridView3.Rows[i].Cells[j].Value = a;
                }
        }
        private void Tra()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows[i].Cells.Count; j++)
                {
                    dataGridView3.Rows[j].Cells[i].Value = dataGridView1.Rows[i].Cells[j].Value;
                }
            }
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString().Trim())
            {
                case "+":
                    Add();
                    break;
                case "-":
                    Sub();
                    break;
                case "*":
                    Mul();
                    break;
                case "转置":
                    dataGridView2.Rows.Clear();
                    Tra();
                    break;
                default:
                    break;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            FitNum();
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                foreach (DataGridViewCell itm in item.Cells)
                {
                    itm.Value = new Random(Guid.NewGuid().GetHashCode()).Next(0, 100);
                }
            }
        }
    }
}
