using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sort
{
    public partial class Form1 : Form
    {
        List<int> totalNumList;
        int[] totalNum;
        public Form1()
        {
            InitializeComponent();
            foreach (ToolStripMenuItem item in 算法ToolStripMenuItem.DropDownItems)
            {
                item.Click += new EventHandler(SelectMethod);
            }
        }
        public void SelectMethod(object sender,EventArgs e)
        {
            ToolStripItem a = (ToolStripItem)sender;
            foreach (ToolStripMenuItem item in 算法ToolStripMenuItem.DropDownItems)
            {
                if (item.Equals(a))
                {
                    item.Checked = true;
                }
                else
                {
                    item.Checked = false;
                }
            }
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string filepath = @"D:\Users\Administrator\Desktop\a\1.dat";
            string[] data = System.IO.File.ReadAllLines(filepath, Encoding.Default);
            totalNumList = new List<int>();
            foreach (string item in data)
            {
                string[] dataArray = item.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string items in dataArray)
                {
                    totalNumList.Add(int.Parse(items.Trim()));
                    listBox1.Items.Add(items.Trim());
                }
            }
            totalNum = totalNumList.ToArray();
        }

        //快速排序
        public void QuickSort( int[] unSortArray, int left, int right)
        {
            listBox2.Items.Clear();
            DateTime start = DateTime.Now;
            QSort(ref unSortArray, left, right);
            for (int i = 0; i < unSortArray.Length; i++)
            {
                listBox2.Items.Add(unSortArray[i]);
            }
            DateTime end = DateTime.Now;
            TimeSpan tp = end - start;
            MessageBox.Show("共耗时：" + tp.TotalSeconds.ToString() + "秒");
        }

        public void QSort(ref int[]unSortArray, int left, int right)
        {
            if (left < right)
            {
                int i = left;
                int j = right - 1;
                int middle = unSortArray[(left + right) / 2];
                while (true)
                {
                    while (i < right && unSortArray[i] < middle) { i++; };
                    while (j > 0 && unSortArray[j] > middle) { j--; };
                    if (i == j) break;
                    unSortArray[i] = unSortArray[i] + unSortArray[j];
                    unSortArray[j] = unSortArray[i] - unSortArray[j];
                    unSortArray[i] = unSortArray[i] - unSortArray[j];
                    if (unSortArray[i] == unSortArray[j]) j--;
                }
                QSort(ref unSortArray, left, i);
                QSort(ref unSortArray, i + 1, right);
            }
        }
        
        //冒泡排序
        public void Bubblesort(int[] unSortArray)
        {
            listBox2.Items.Clear();
            DateTime start = DateTime.Now;
            for (int i = 0; i < unSortArray.Length - 1; i++)
            {
                for (int j = 0; j < unSortArray.Length - 1 - i; j++)
                {
                    if (unSortArray[j] > unSortArray[j + 1])
                    {
                        int temp = unSortArray[j];
                        unSortArray[j] = unSortArray[j + 1];
                        unSortArray[j + 1] = temp;
                    }
                }
            }
            for (int i = 0; i < unSortArray.Length; i++)
            {
                listBox2.Items.Add(unSortArray[i]);
            }
            DateTime end = DateTime.Now;
            TimeSpan tp = end - start;
            MessageBox.Show("共耗时：" + tp.TotalSeconds.ToString() + "秒");
        }

        //直接插入排序
        public void Insertionsort(int[] unSortArray)
        {
            listBox2.Items.Clear();
            DateTime start = DateTime.Now;
            for (int i = 1; i < unSortArray.Length; i++)
            {
                if (unSortArray[i] < unSortArray[i - 1])
                {
                    int j = i - 1;
                    int x = unSortArray[i];
                    while (j > -1 && x < unSortArray[j])
                    {
                        unSortArray[j + 1] = unSortArray[j];
                        j--;
                    }
                    unSortArray[j + 1] = x;
                }
            }
            for (int i = 0; i < unSortArray.Length; i++)
            {
                listBox2.Items.Add(unSortArray[i]);
            }
            DateTime end = DateTime.Now;
            TimeSpan tp = end - start;
            MessageBox.Show("共耗时："+tp.TotalSeconds.ToString()+"秒");
        }

        //希尔排序
        public void Shellsort(int[] unSortArray)
        {
            MessageBox.Show("暂未实现");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string method = "";
            foreach (ToolStripMenuItem item in 算法ToolStripMenuItem.DropDownItems)
            {
                if (item.Checked)
                {
                    method = item.Text.Trim();
                }
            }
            if (method.Contains("冒泡"))
                Bubblesort(totalNum);
            else if (method.Contains("插入"))
                Insertionsort(totalNum);
            else if (method.Contains("快速"))
                QuickSort( totalNum, 0, totalNum.Length);
            else if (method.Contains("希尔"))
                Shellsort(totalNum);
            else
                MessageBox.Show("无此排序方法");
        }
    }
}
