using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace SqliteUploadAndDownLoad
{
    public partial class Frm_UploadFile : Form
    {
        SqliteHelper.SqliteHelper instance;
        public List<Model> list { get; set; }
        public Frm_UploadFile()
        {
            InitializeComponent();

            Load += Frm_UploadFile_Load;
        }
        private void Frm_UploadFile_Load(object sender, EventArgs e)
        {
            instance = SqliteHelper.SqliteHelper.Instance;

            InitUI();
            InitEvent();
        }
        private void InitUI(bool flag = true)
        {
            MaximumSize = MinimumSize = Size = new Size(425, (flag ? 127 : 557));
        }
        private void InitEvent()
        {
            //数据库设置
            bt_SeeDataSourcePath.Click += bt_SeeDataSourcePath_Click;
            bt_CreateDataSource.Click += bt_CreateDataSource_Click;
            bt_UseDataSource.Click += bt_UseDataSource_Click;
            txt_DataSourceExistsFilePath.Click += txt_DataSourceExistsFilePath_Click;
            //操作
            bt_SeeUpload.Click += bt_SeeUpload_Click;
            bt_InsertToNode.Click += bt_InsertToNode_Click;
            bt_DeleteNode.Click += bt_DeleteNode_Click;
        }

        #region 事件
        #region 数据库设置
        private void bt_SeeDataSourcePath_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                return;
            txt_DataSourceFilePath.Text = folderBrowserDialog.SelectedPath;
        }
        private void bt_CreateDataSource_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_DataSourceFilePath.Text))
            {
                MessageBox.Show("请选择路径.");
                return;
            }
            if (string.IsNullOrEmpty(txt_DataSourceFileName.Text))
            {
                MessageBox.Show("请输入文件名.");
                return;
            }
            instance.SetDataSourcePath(Path.Combine(txt_DataSourceFilePath.Text, txt_DataSourceFileName.Text));
            var conn = new System.Data.SQLite.SQLiteConnection(Path.Combine(txt_DataSourceFilePath.Text, txt_DataSourceFileName.Text));
            conn.SetPassword("123456");
            var parameters = new List<string[]>();
            parameters.Add(new[] { "fileID", "varchar", "(50)" });
            parameters.Add(new[] { "fileMD5", "varchar", "(32)" });
            parameters.Add(new[] { "fileName", "varchar", "(200)" });
            parameters.Add(new[] { "filePath", "varchar", "(1000)" });
            parameters.Add(new[] { "fileInfo", "blob", "(20480)" });
            parameters.Add(new[] { "parentID", "varchar", "(50)" });
            instance.CreateTable("FileInfo", parameters.ToArray());
            Add(new Model(Guid.NewGuid(), "根目录"));
            InitDataSource();
            InitUI(false);
        }
        private void bt_UseDataSource_Click(object sender, EventArgs e)
        {
            if (txt_DataSourceExistsFilePath.Tag == null)
            {
                MessageBox.Show("请选择数据文件.");
                return;
            }
            instance.SetDataSourcePath(txt_DataSourceExistsFilePath.Text);
            instance.Init();
            InitUI(false);
            InitDataSource();
        }
        private void txt_DataSourceExistsFilePath_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            txt_DataSourceExistsFilePath.Tag = txt_DataSourceExistsFilePath.Text = openFileDialog.FileName;
        }
        #endregion
        #region 操作
        private void bt_SeeUpload_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("选择\"是\"选择文件,\n选择\"否\"选择文件夹。", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            switch (dialogResult)
            {
                case DialogResult.Yes:
                    var openFileDialog = new OpenFileDialog();
                    if (openFileDialog.ShowDialog() != DialogResult.OK)
                        return;
                    txt_UploadFile.Text = openFileDialog.FileName;
                    txt_UploadFile.Tag = "File";
                    break;
                case DialogResult.No:
                    var folderBrowserDialog = new FolderBrowserDialog();
                    if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                        return;
                    txt_UploadFile.Text = folderBrowserDialog.SelectedPath;
                    txt_UploadFile.Tag = "Directory";
                    break;
                default:
                    return;
            }
        }
        private void bt_InsertToNode_Click(object sender, EventArgs e)
        {
            var selectedNode = tree_See.SelectedNode;
            var type = txt_UploadFile.Tag;

            if (selectedNode == null)
            {
                MessageBox.Show("请选择节点.");
                return;
            }
            if (type == null)
            {
                MessageBox.Show("请选择数据.");
                return;
            }
            var fileInfo = new FileInfo(txt_UploadFile.Text);
            var selectedModel = selectedNode.Tag as Model;
            switch (type.ToString())
            {
                case "File":
                    var model = new Model(Guid.NewGuid(), fileInfo.Name, fileInfo.FullName,
                        GetMD5ByFile(fileInfo.FullName), File.ReadAllBytes(fileInfo.FullName), selectedModel.fileID);
                    Add(model);
                    AddNextTreeNode(selectedNode, selectedModel.fileID);
                    break;
                case "Directory":
                    AddDirs(selectedNode, new DirectoryInfo(fileInfo.FullName).FullName, selectedModel.fileID);
                    break;
                default:
                    break;
            }
        }
        private void bt_DeleteNode_Click(object sender, EventArgs e)
        {
            var selectedNode = tree_See.SelectedNode;
            if (selectedNode == null)
            {
                MessageBox.Show("请选择要删除的项.");
                return;
            }
            var model = selectedNode.Tag as Model;
            if (model.fileName == "根目录")
            {
                MessageBox.Show("不能删除根节点.");
                return;
            }
            var deleteList = new List<Model>() { model };
            DeleteDir(model.fileID, ref deleteList);
            Delete(model.fileID);
            foreach (var deleteItem in deleteList)
                list.Remove(deleteItem);
            tree_See.Nodes.Remove(selectedNode);
        }
        #endregion
        #endregion

        #region 自定义
        private void AddNextTreeNode(TreeNode treeNode, string guid)
        {
            var nodes = list.Where(predicate => predicate.parentID == guid);
            foreach (var model in nodes)
            {
                var tNode = new TreeNode();
                tNode.Text = model.fileName;
                tNode.Tag = model;
                var flag = false;
                foreach (TreeNode node in treeNode.Nodes)
                {
                    if (node.Tag == model)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag) continue;
                treeNode.Nodes.Add(tNode);
                AddNextTreeNode(tNode, model.fileID);
            }
        }
        private void InitDataSource()
        {
            var sql = "select * from FileInfo ";
            var table = instance.GetTable(sql, default(SQLiteParameter[]));
            if (table == null)
                return;
            tree_See.Nodes.Clear();
            list = new List<Model>();
            foreach (DataRow row in table.Rows)
                list.Add(new Model(row));
            var rootTreeNodeModel = list.FirstOrDefault(predicate => string.IsNullOrEmpty(predicate.parentID));
            var treeNode = new TreeNode();
            treeNode.Text = rootTreeNodeModel.fileName;
            treeNode.Tag = rootTreeNodeModel;
            tree_See.Nodes.Add(treeNode);
            AddNextTreeNode(treeNode, rootTreeNodeModel.fileID);
        }

        private void Add(Model model)
        {
            var sql = "insert into FileInfo values(@fileID,@filemd5,@fileName,@filepath,@fileInfo,@parentID)";
            var sqliteparameters = new List<SQLiteParameter>();
            sqliteparameters.Add(new SQLiteParameter("@fileID", model.fileID));
            sqliteparameters.Add(new SQLiteParameter("@filemd5", model.fileMD5));
            sqliteparameters.Add(new SQLiteParameter("@fileName", model.fileName));
            sqliteparameters.Add(new SQLiteParameter("@filepath", model.filePath));
            sqliteparameters.Add(new SQLiteParameter("@fileInfo", model.fileInfo));
            sqliteparameters.Add(new SQLiteParameter("@parentID", model.parentID));
            instance.ExecuteNonQuery(sql, sqliteparameters.ToArray());
            if (list == null)
                list = new List<Model>();
            list.Add(model);
        }

        private void DeleteDir(string fileID, ref List<Model> deleteList)
        {
            if (deleteList == null)
                deleteList = new List<Model>();
            var deleteDirs = list.Where(predicate => predicate.parentID == fileID);
            foreach (var deleteDir in deleteDirs)
            {
                DeleteDir(deleteDir.fileID, ref deleteList);
                Delete(deleteDir.fileID);
            }
            deleteList.AddRange(deleteDirs);
        }

        private void Delete(string fileID)
        {
            var sql = "delete from FileInfo where fileID = @fileID";
            var sqliteparameters = new List<SQLiteParameter>();
            sqliteparameters.Add(new SQLiteParameter("@fileID", fileID));
            instance.ExecuteNonQuery(sql, sqliteparameters.ToArray());
        }

        private string GetMD5ByFile(string path)
        {
            using (var Stream = new FileStream(path, FileMode.Open))
            {
                var stringBuilder = new StringBuilder();
                var md5 = new MD5CryptoServiceProvider();
                byte[] data = md5.ComputeHash(Stream);
                foreach (byte item in data)
                    stringBuilder.AppendFormat("{0:x2}", item);
                return stringBuilder.ToString();
            }
        }
        private void AddDirs(TreeNode treeNode, string path, string guid)
        {
            var sql = "insert into FileInfo values(@fileID,@filemd5,@fileName,@filepath,@fileInfo,@parentID)";
            var fileInfo = new FileInfo(path);
            var model = new Model(Guid.NewGuid(), fileInfo.Name,  fileInfo.FullName,null , null, guid.ToString());
            var sqliteparameters = new List<SQLiteParameter>();
            sqliteparameters.Add(new SQLiteParameter("@fileID", model.fileID));
            sqliteparameters.Add(new SQLiteParameter("@filemd5", null));
            sqliteparameters.Add(new SQLiteParameter("@fileName", model.fileName));
            sqliteparameters.Add(new SQLiteParameter("@filepath", model.filePath));
            sqliteparameters.Add(new SQLiteParameter("@fileInfo", null));
            sqliteparameters.Add(new SQLiteParameter("@parentID", model.parentID));
            var dirs = Directory.GetDirectories(path);
            var node = new TreeNode();
            node.Text = fileInfo.Name;
            node.Tag = model;
            treeNode.Nodes.Add(node);
            instance.ExecuteNonQuery(sql, sqliteparameters.ToArray());
            guid = model.fileID;
            foreach (var dir in dirs)
                AddDirs(node, dir, model.fileID);
            var filePaths = Directory.GetFiles(path);
            foreach (var filePath in filePaths)
            {
                fileInfo = new FileInfo(filePath);
                model = new Model(Guid.NewGuid(), fileInfo.Name,fileInfo.FullName, GetMD5ByFile(fileInfo.FullName),  File.ReadAllBytes(filePath), guid);
                Add(model);
                if ((node.Tag as Model).fileID == guid)
                    AddNextTreeNode(node, model.parentID);
            }
        }
        #endregion

        private void bt_CreateDataSource_Click_1(object sender, EventArgs e)
        {

        }
    }
}
