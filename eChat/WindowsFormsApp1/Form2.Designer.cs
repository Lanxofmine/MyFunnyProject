using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class SFilter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtInFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lstBoxShowFilter = new System.Windows.Forms.ListBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.txtOldvalue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelUpdate = new System.Windows.Forms.Panel();
            this.btnOver = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.txtNewvalue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelUpdate.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtInFilter
            // 
            this.txtInFilter.Location = new System.Drawing.Point(84, 29);
            this.txtInFilter.Name = "txtInFilter";
            this.txtInFilter.Size = new System.Drawing.Size(148, 21);
            this.txtInFilter.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "输入敏感词：";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(238, 29);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // lstBoxShowFilter
            // 
            this.lstBoxShowFilter.FormattingEnabled = true;
            this.lstBoxShowFilter.ItemHeight = 12;
            this.lstBoxShowFilter.Location = new System.Drawing.Point(12, 69);
            this.lstBoxShowFilter.Name = "lstBoxShowFilter";
            this.lstBoxShowFilter.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstBoxShowFilter.Size = new System.Drawing.Size(301, 136);
            this.lstBoxShowFilter.TabIndex = 3;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(147, 217);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(238, 217);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "移除";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // txtOldvalue
            // 
            this.txtOldvalue.Location = new System.Drawing.Point(35, 5);
            this.txtOldvalue.Name = "txtOldvalue";
            this.txtOldvalue.ReadOnly = true;
            this.txtOldvalue.Size = new System.Drawing.Size(101, 21);
            this.txtOldvalue.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "From:";
            // 
            // panelUpdate
            // 
            this.panelUpdate.Controls.Add(this.btnOver);
            this.panelUpdate.Controls.Add(this.btnYes);
            this.panelUpdate.Controls.Add(this.txtNewvalue);
            this.panelUpdate.Controls.Add(this.label3);
            this.panelUpdate.Controls.Add(this.txtOldvalue);
            this.panelUpdate.Controls.Add(this.label2);
            this.panelUpdate.Location = new System.Drawing.Point(8, 246);
            this.panelUpdate.Name = "panelUpdate";
            this.panelUpdate.Size = new System.Drawing.Size(308, 69);
            this.panelUpdate.TabIndex = 8;
            this.panelUpdate.Visible = false;
            // 
            // btnOver
            // 
            this.btnOver.Location = new System.Drawing.Point(142, 35);
            this.btnOver.Name = "btnOver";
            this.btnOver.Size = new System.Drawing.Size(75, 23);
            this.btnOver.TabIndex = 10;
            this.btnOver.Text = "跳过此项";
            this.btnOver.UseVisualStyleBackColor = true;
            this.btnOver.Click += new System.EventHandler(this.BtnOver_Click);
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(226, 35);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 23);
            this.btnYes.TabIndex = 9;
            this.btnYes.Text = "确认修改";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.Button1_Click);
            // 
            // txtNewvalue
            // 
            this.txtNewvalue.Location = new System.Drawing.Point(171, 5);
            this.txtNewvalue.Name = "txtNewvalue";
            this.txtNewvalue.Size = new System.Drawing.Size(127, 21);
            this.txtNewvalue.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(143, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "To:";
            // 
            // SFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 324);
            this.Controls.Add(this.panelUpdate);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lstBoxShowFilter);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInFilter);
            this.MaximizeBox = false;
            this.Name = "SFilter";
            this.Text = "sFilter";
            this.Load += new System.EventHandler(this.SFilter_Load);
            this.panelUpdate.ResumeLayout(false);
            this.panelUpdate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lstBoxShowFilter;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox txtOldvalue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelUpdate;
        private System.Windows.Forms.TextBox txtNewvalue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnOver;
    }
}