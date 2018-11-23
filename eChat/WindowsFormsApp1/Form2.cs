using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class SFilter : Form
    {
        public SFilter()
        {
            InitializeComponent();
            foreach (Control item in Controls)
            {
                if(!item.Text.Equals("修改"))
                    item.MouseDown += new MouseEventHandler(Panel_out);
            }
            MouseDown += new MouseEventHandler(Panel_out);
        }

        private void SFilter_Load(object sender, EventArgs e)
        {
            foreach (string item in StrFilter.strs)
            {
                lstBoxShowFilter.Items.Add(item);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInFilter.Text.ToString().Trim()))
            {
                MessageBox.Show("尚未输入任何字符");
                return;
            }else if (StrFilter.strs.Contains(txtInFilter.Text.ToString().Trim()))
            {
                MessageBox.Show("敏感词已存在");
                return;
            }
            StrFilter.strs.Add(txtInFilter.Text.ToString().Trim());
            lstBoxShowFilter.Items.Add(txtInFilter.Text.ToString().Trim());
            txtInFilter.Clear();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (lstBoxShowFilter.SelectedItems.Count == 0)
            {
                MessageBox.Show("请先选中需要修改的字符");
                return;
            }
            panelUpdate.Visible = true;
            txtOldvalue.Text = lstBoxShowFilter.SelectedItems[0].ToString().Trim();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewvalue.Text))
            {
                MessageBox.Show("请输入修改后的字符。");
                return;
            }
            else if (txtNewvalue.Text.Equals(txtOldvalue.Text))
            {
                MessageBox.Show("修改后字符未发生任何改变，请检查。");
                return;
            }else if (StrFilter.strs.Contains(txtNewvalue.Text.ToString().Trim()))
            {
                MessageBox.Show("修改后的字符已存在，请检查。");
                return;
            }
            int index = StrFilter.strs.IndexOf(txtOldvalue.Text.ToString().Trim());
            StrFilter.strs.Remove(txtOldvalue.Text.ToString().Trim());
            StrFilter.strs.Insert(index, txtNewvalue.Text.ToString().Trim());
            int lstindex = lstBoxShowFilter.Items.IndexOf(txtOldvalue.Text.ToString().Trim());
            lstBoxShowFilter.Items.Remove(txtOldvalue.Text.ToString().Trim());
            lstBoxShowFilter.Items.Insert(lstindex,txtNewvalue.Text.ToString().Trim());
            if (lstBoxShowFilter.SelectedItems.Count>0)
            {
                txtOldvalue.Text =lstBoxShowFilter.SelectedItems[0].ToString().Trim();
                txtNewvalue.Clear();
            }
            else
            {
                MessageBox.Show("所选内容已全部更改");
                lstBoxShowFilter.SelectedItems.Clear();
                panelUpdate.Visible = false;
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (lstBoxShowFilter.SelectedItems.Count == 0)
            {
                MessageBox.Show("请先选中需要修改的字符");
                return;
            }
            try
            {
                int count = lstBoxShowFilter.SelectedItems.Count;
                for (int i=0;i< count; i++)
                {
                    StrFilter.strs.Remove(lstBoxShowFilter.SelectedItems[0].ToString().Trim());
                    lstBoxShowFilter.Items.Remove(lstBoxShowFilter.SelectedItems[0]);
                }
            }catch{}
        }

        private void BtnOver_Click(object sender, EventArgs e)
        {
            int index = lstBoxShowFilter.SelectedItems.IndexOf(txtOldvalue.Text.ToString().Trim());
            if (index==lstBoxShowFilter.SelectedItems.Count-1)
            {
                MessageBox.Show("所选内容已全部更改");
                lstBoxShowFilter.SelectedItems.Clear();
                panelUpdate.Visible = false;
            }
            else
            {
                txtOldvalue.Text = lstBoxShowFilter.SelectedItems[index+1].ToString().Trim();
            }
        }

        private void Panel_out(object sender,MouseEventArgs e)
        {
            if (!new Rectangle(lstBoxShowFilter.Location,lstBoxShowFilter.Size).Contains(e.Location))
            {
                panelUpdate.Visible=false;
            }
        }
    }
}
