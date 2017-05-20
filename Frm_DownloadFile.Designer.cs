namespace SqliteUploadAndDownLoad
{
    partial class Frm_DownloadFile
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.list_DownLoad = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tree_See = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_UseDataSource = new System.Windows.Forms.TextBox();
            this.bt_See = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tree_See);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.list_DownLoad);
            this.splitContainer1.Size = new System.Drawing.Size(880, 604);
            this.splitContainer1.SplitterDistance = 293;
            this.splitContainer1.TabIndex = 2;
            // 
            // list_DownLoad
            // 
            this.list_DownLoad.AllowDrop = true;
            this.list_DownLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_DownLoad.Location = new System.Drawing.Point(0, 0);
            this.list_DownLoad.Name = "list_DownLoad";
            this.list_DownLoad.Size = new System.Drawing.Size(583, 604);
            this.list_DownLoad.TabIndex = 0;
            this.list_DownLoad.UseCompatibleStateImageBehavior = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bt_See);
            this.panel1.Controls.Add(this.txt_UseDataSource);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 53);
            this.panel1.TabIndex = 0;
            // 
            // tree_See
            // 
            this.tree_See.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree_See.Location = new System.Drawing.Point(0, 53);
            this.tree_See.Name = "tree_See";
            this.tree_See.Size = new System.Drawing.Size(293, 551);
            this.tree_See.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择sqlite文件：";
            // 
            // txt_UseDataSource
            // 
            this.txt_UseDataSource.Location = new System.Drawing.Point(14, 24);
            this.txt_UseDataSource.Name = "txt_UseDataSource";
            this.txt_UseDataSource.ReadOnly = true;
            this.txt_UseDataSource.Size = new System.Drawing.Size(195, 21);
            this.txt_UseDataSource.TabIndex = 1;
            // 
            // bt_See
            // 
            this.bt_See.Location = new System.Drawing.Point(215, 22);
            this.bt_See.Name = "bt_See";
            this.bt_See.Size = new System.Drawing.Size(75, 23);
            this.bt_See.TabIndex = 2;
            this.bt_See.Text = "浏览...";
            this.bt_See.UseVisualStyleBackColor = true;
            // 
            // Frm_DownloadFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 604);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Frm_DownloadFile";
            this.Text = "本地数据库_下载";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView list_DownLoad;
        private System.Windows.Forms.TreeView tree_See;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bt_See;
        private System.Windows.Forms.TextBox txt_UseDataSource;
        private System.Windows.Forms.Label label1;
    }
}