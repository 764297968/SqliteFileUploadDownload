namespace SqliteUploadAndDownLoad
{
    partial class Frm_UploadFile
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_DataSourceFilePath = new System.Windows.Forms.TextBox();
            this.txt_DataSourceFileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_CreateDataSource = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_DataSourceExistsFilePath = new System.Windows.Forms.TextBox();
            this.bt_UseDataSource = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_SeeDataSourcePath = new System.Windows.Forms.Button();
            this.tree_See = new System.Windows.Forms.TreeView();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_UploadFile = new System.Windows.Forms.TextBox();
            this.bt_SeeUpload = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bt_DeleteNode = new System.Windows.Forms.Button();
            this.bt_InsertToNode = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "本地数据库路径:";
            // 
            // txt_DataSourceFilePath
            // 
            this.txt_DataSourceFilePath.Location = new System.Drawing.Point(116, 8);
            this.txt_DataSourceFilePath.Name = "txt_DataSourceFilePath";
            this.txt_DataSourceFilePath.ReadOnly = true;
            this.txt_DataSourceFilePath.Size = new System.Drawing.Size(208, 21);
            this.txt_DataSourceFilePath.TabIndex = 1;
            // 
            // txt_DataSourceFileName
            // 
            this.txt_DataSourceFileName.Location = new System.Drawing.Point(116, 35);
            this.txt_DataSourceFileName.Name = "txt_DataSourceFileName";
            this.txt_DataSourceFileName.Size = new System.Drawing.Size(208, 21);
            this.txt_DataSourceFileName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "本地数据库文件名:";
            // 
            // bt_CreateDataSource
            // 
            this.bt_CreateDataSource.Location = new System.Drawing.Point(330, 33);
            this.bt_CreateDataSource.Name = "bt_CreateDataSource";
            this.bt_CreateDataSource.Size = new System.Drawing.Size(75, 23);
            this.bt_CreateDataSource.TabIndex = 4;
            this.bt_CreateDataSource.Text = "创建数据库";
            this.bt_CreateDataSource.UseVisualStyleBackColor = true;
            this.bt_CreateDataSource.Click += new System.EventHandler(this.bt_CreateDataSource_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "使用本地数据库:";
            // 
            // txt_DataSourceExistsFilePath
            // 
            this.txt_DataSourceExistsFilePath.Location = new System.Drawing.Point(116, 62);
            this.txt_DataSourceExistsFilePath.Name = "txt_DataSourceExistsFilePath";
            this.txt_DataSourceExistsFilePath.ReadOnly = true;
            this.txt_DataSourceExistsFilePath.Size = new System.Drawing.Size(208, 21);
            this.txt_DataSourceExistsFilePath.TabIndex = 6;
            this.txt_DataSourceExistsFilePath.Text = "双击此处选择文件";
            // 
            // bt_UseDataSource
            // 
            this.bt_UseDataSource.Location = new System.Drawing.Point(330, 60);
            this.bt_UseDataSource.Name = "bt_UseDataSource";
            this.bt_UseDataSource.Size = new System.Drawing.Size(75, 23);
            this.bt_UseDataSource.TabIndex = 7;
            this.bt_UseDataSource.Text = "使用数据库";
            this.bt_UseDataSource.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bt_SeeDataSourcePath);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.bt_UseDataSource);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt_DataSourceExistsFilePath);
            this.panel1.Controls.Add(this.txt_DataSourceFilePath);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_DataSourceFileName);
            this.panel1.Controls.Add(this.bt_CreateDataSource);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(432, 100);
            this.panel1.TabIndex = 8;
            // 
            // bt_SeeDataSourcePath
            // 
            this.bt_SeeDataSourcePath.Location = new System.Drawing.Point(330, 6);
            this.bt_SeeDataSourcePath.Name = "bt_SeeDataSourcePath";
            this.bt_SeeDataSourcePath.Size = new System.Drawing.Size(75, 23);
            this.bt_SeeDataSourcePath.TabIndex = 2;
            this.bt_SeeDataSourcePath.Text = "浏览...";
            this.bt_SeeDataSourcePath.UseVisualStyleBackColor = true;
            // 
            // tree_See
            // 
            this.tree_See.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree_See.Location = new System.Drawing.Point(0, 173);
            this.tree_See.Name = "tree_See";
            this.tree_See.Size = new System.Drawing.Size(432, 351);
            this.tree_See.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "选择要上传的数据：";
            // 
            // txt_UploadFile
            // 
            this.txt_UploadFile.Location = new System.Drawing.Point(117, 13);
            this.txt_UploadFile.Name = "txt_UploadFile";
            this.txt_UploadFile.ReadOnly = true;
            this.txt_UploadFile.Size = new System.Drawing.Size(208, 21);
            this.txt_UploadFile.TabIndex = 2;
            // 
            // bt_SeeUpload
            // 
            this.bt_SeeUpload.Location = new System.Drawing.Point(331, 11);
            this.bt_SeeUpload.Name = "bt_SeeUpload";
            this.bt_SeeUpload.Size = new System.Drawing.Size(75, 23);
            this.bt_SeeUpload.TabIndex = 3;
            this.bt_SeeUpload.Text = "浏览...";
            this.bt_SeeUpload.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_UploadFile);
            this.panel2.Controls.Add(this.bt_DeleteNode);
            this.panel2.Controls.Add(this.bt_InsertToNode);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.bt_SeeUpload);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(432, 73);
            this.panel2.TabIndex = 10;
            // 
            // bt_DeleteNode
            // 
            this.bt_DeleteNode.Location = new System.Drawing.Point(277, 40);
            this.bt_DeleteNode.Name = "bt_DeleteNode";
            this.bt_DeleteNode.Size = new System.Drawing.Size(129, 23);
            this.bt_DeleteNode.TabIndex = 5;
            this.bt_DeleteNode.Text = "删除";
            this.bt_DeleteNode.UseVisualStyleBackColor = true;
            // 
            // bt_InsertToNode
            // 
            this.bt_InsertToNode.Location = new System.Drawing.Point(12, 40);
            this.bt_InsertToNode.Name = "bt_InsertToNode";
            this.bt_InsertToNode.Size = new System.Drawing.Size(129, 23);
            this.bt_InsertToNode.TabIndex = 4;
            this.bt_InsertToNode.Text = "将数据插入选中节点";
            this.bt_InsertToNode.UseVisualStyleBackColor = true;
            // 
            // Frm_UploadFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 524);
            this.Controls.Add(this.tree_See);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "Frm_UploadFile";
            this.Text = "本地数据库_上传";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_DataSourceFilePath;
        private System.Windows.Forms.TextBox txt_DataSourceFileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_CreateDataSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_DataSourceExistsFilePath;
        private System.Windows.Forms.Button bt_UseDataSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bt_SeeDataSourcePath;
        private System.Windows.Forms.TreeView tree_See;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_UploadFile;
        private System.Windows.Forms.Button bt_SeeUpload;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bt_DeleteNode;
        private System.Windows.Forms.Button bt_InsertToNode;
    }
}