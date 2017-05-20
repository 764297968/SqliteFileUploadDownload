using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SqliteUploadAndDownLoad
{
    public partial class Frm_DownloadFile : Form
    {
        SqliteHelper.SqliteHelper instance;
        List<Model> list;
        public Frm_DownloadFile()
        {
            InitializeComponent();
            Load += Form1_Load;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            instance = SqliteHelper.SqliteHelper.Instance;
            InitEvent();
        }
        private void InitEvent()
        {
            bt_See.Click += bt_See_Click;
            tree_See.DoubleClick += tree_See_DoubleClick;
        }
        #region 事件
        private void bt_See_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            instance.SetDataSourcePath(openFileDialog.FileName);
            txt_UseDataSource.Text = openFileDialog.FileName;
            instance.Init();
            var sql = "select * from FileInfo ";
            var table = instance.GetTable(sql, default(SQLiteParameter[]));
            if (table == null)
                return;
            list = new List<Model>();
            foreach (DataRow row in table.Rows)
                list.Add(new Model(row));
            tree_See.Nodes.Clear();
            var rootTreeNodeModel = list.FirstOrDefault(predicate => string.IsNullOrEmpty(predicate.parentID));
            var treeNode = new TreeNode();
            treeNode.Text = rootTreeNodeModel.fileName;
            treeNode.Tag = rootTreeNodeModel;
            tree_See.Nodes.Add(treeNode);
            AddNextTreeNode(treeNode, rootTreeNodeModel.fileID);

            var contextMenu = new ContextMenu();
            var menuItem = new MenuItem();
            menuItem.Text = "下载.";
            menuItem.Click += menuItem_Click;
            contextMenu.MenuItems.Add(menuItem);
            list_DownLoad.ContextMenu = contextMenu;
        }
        private void tree_See_DoubleClick(object sender, EventArgs e)
        {
            var selectedNode = tree_See.SelectedNode;
            if (selectedNode == null)
                return;
            var model = selectedNode.Tag as Model;
            if (!string.IsNullOrEmpty(model.fileMD5))
            {
                var listViewItem = new ListViewItem();
                listViewItem.Tag = model;
                listViewItem.Text = model.fileName;
                list_DownLoad.Items.Add(listViewItem);
            }
        }
        private void menuItem_Click(object sender, EventArgs e)
        {
            var selectedItems = list_DownLoad.SelectedItems;
            if (selectedItems.Count == 0)
            {
                MessageBox.Show("选择的项不匹配.");
                return;
            }
            var folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = "R:\\测试";
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                return;
            foreach (ListViewItem selectedItem in selectedItems)
            {
                var model = selectedItem.Tag as Model;
                DownLoadByParentID(model.fileID, folderBrowserDialog.SelectedPath);
            }
        }
        #endregion
        #region 自定义方法
        private void DownLoadByParentID(string parentID, string path)
        {
            var dir = list.FirstOrDefault(predicate => predicate.fileID == parentID).fileName;
            Directory.CreateDirectory(Path.Combine(path, dir));
            var _list = list.Where(predicate => predicate.parentID == parentID);
            int level = -1;
            if (_list.Count() == 0)
            {
                Directory.Delete(Path.Combine(path, dir));
                var model = list.FirstOrDefault(predicate => predicate.fileID == parentID);
                File.WriteAllBytes(Path.Combine(path, dir), model.fileInfo);
            }
            else
            {
                level = _list.Min(predicate => predicate.filePath.Split('\\').Length);
                DownLoad(_list, new List<string>() { path, dir }, level);
            }
        }
        private void DownLoad(IEnumerable<Model> _list, List<string> paths, int level)
        {
            foreach (var model in _list.OrderBy(predicate => predicate.fileName.Count(p => p == '\\')).Where(predicate => predicate.filePath.Split('\\').Length == level))
            {
                var _model = list.FirstOrDefault(predicate => predicate.fileID == model.parentID);
                var _paths = paths;
                _paths.Add(model.fileName);
                if (string.IsNullOrEmpty(model.fileMD5.Trim()))
                {
                    Directory.CreateDirectory(Path.Combine(_paths.ToArray()));
                    DownLoad(list.Where(predicate => predicate.parentID == model.fileID), _paths, level + 1);
                }
                else
                    File.WriteAllBytes(Path.Combine(_paths.ToArray()), model.fileInfo);
                _paths.RemoveAt(_paths.Count - 1);
            }
        }
        private void AddNextTreeNode(TreeNode treeNode, string guid)
        {
            var nodes = list.Where(predicate => predicate.parentID == guid);

            foreach (var model in nodes)
            {
                var tNode = new TreeNode();
                tNode.Text = model.fileName;
                tNode.Tag = model;
                tNode.ContextMenu = GetMenu(model);
                treeNode.Nodes.Add(tNode);
                AddNextTreeNode(tNode, model.fileID);
            }
        }
        ContextMenu GetMenu(Model model)
        {
            var contextMenu = new ContextMenu();
            var menuItem = new MenuItem();
            menuItem.Text = "添加到下载列表.";
            menuItem.Tag = model;
            menuItem.Click += (sender, e) =>
            {
                var listViewItem = new ListViewItem();
                listViewItem.Tag = model;
                listViewItem.Text = model.fileName;
                list_DownLoad.Items.Add(listViewItem);
            };
            contextMenu.MenuItems.Add(menuItem);
            return contextMenu;
        }
        #endregion
    }
}
