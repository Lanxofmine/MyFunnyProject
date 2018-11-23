namespace Sort
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.另存为ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.算法ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.冒泡排序普通算法ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.快速算法控件换时间ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.希尔排序ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.直接插入排序ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.算法ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(381, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.另存为ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 另存为ToolStripMenuItem
            // 
            this.另存为ToolStripMenuItem.Name = "另存为ToolStripMenuItem";
            this.另存为ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.另存为ToolStripMenuItem.Text = "另存为";
            // 
            // 算法ToolStripMenuItem
            // 
            this.算法ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.冒泡排序普通算法ToolStripMenuItem,
            this.快速算法控件换时间ToolStripMenuItem,
            this.希尔排序ToolStripMenuItem,
            this.直接插入排序ToolStripMenuItem});
            this.算法ToolStripMenuItem.Name = "算法ToolStripMenuItem";
            this.算法ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.算法ToolStripMenuItem.Text = "算法";
            // 
            // 冒泡排序普通算法ToolStripMenuItem
            // 
            this.冒泡排序普通算法ToolStripMenuItem.Checked = true;
            this.冒泡排序普通算法ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.冒泡排序普通算法ToolStripMenuItem.Name = "冒泡排序普通算法ToolStripMenuItem";
            this.冒泡排序普通算法ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.冒泡排序普通算法ToolStripMenuItem.Text = "冒泡排序（普通算法）";
            // 
            // 快速算法控件换时间ToolStripMenuItem
            // 
            this.快速算法控件换时间ToolStripMenuItem.Name = "快速算法控件换时间ToolStripMenuItem";
            this.快速算法控件换时间ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.快速算法控件换时间ToolStripMenuItem.Text = "快速算法（控件换时间）";
            // 
            // 希尔排序ToolStripMenuItem
            // 
            this.希尔排序ToolStripMenuItem.Name = "希尔排序ToolStripMenuItem";
            this.希尔排序ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.希尔排序ToolStripMenuItem.Text = "希尔排序";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 28);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(134, 316);
            this.listBox1.TabIndex = 1;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(239, 28);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(134, 316);
            this.listBox2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(155, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 3;
            this.button1.Text = "排序";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // 直接插入排序ToolStripMenuItem
            // 
            this.直接插入排序ToolStripMenuItem.Name = "直接插入排序ToolStripMenuItem";
            this.直接插入排序ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.直接插入排序ToolStripMenuItem.Text = "直接插入排序";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 355);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "排序算法";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 另存为ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 算法ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 冒泡排序普通算法ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 快速算法控件换时间ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 希尔排序ToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem 直接插入排序ToolStripMenuItem;
    }
}

