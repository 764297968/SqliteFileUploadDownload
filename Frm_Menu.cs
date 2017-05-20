using System;
using System.Windows.Forms;

namespace SqliteUploadAndDownLoad
{
    public partial class Frm_Menu : Form
    {
        public Frm_Menu()
        {
            InitializeComponent();

            Load += Frm_Menu_Load;
        }

        void Frm_Menu_Load(object sender, EventArgs e)
        {
            InitEvent();
        }

        private void InitEvent()
        {
            上传ToolStripMenuItem.Click += 上传ToolStripMenuItem_Click;
            下载ToolStripMenuItem.Click += 下载ToolStripMenuItem_Click;
        }

        void 上传ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm_upload = new Frm_UploadFile();
            foreach (var frm in MdiChildren)
            { 
                if (frm is Frm_UploadFile)
                {
                    frm.Focus();
                    return;
                }
            }
            frm_upload.MdiParent = this;
            frm_upload.Show();
        }

        void 下载ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm_download = new Frm_DownloadFile();

            foreach (var frm in MdiChildren)
            {
                if (frm is Frm_DownloadFile)
                {
                    frm.Focus();
                    return;
                }
            }
            frm_download.MdiParent = this;
            frm_download.Show();
        }
    }
}
