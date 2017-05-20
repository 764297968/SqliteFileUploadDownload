using System;
using System.Data;

namespace SqliteUploadAndDownLoad
{
    public class Model
    {
        public string fileID { get; set; }
        public string fileMD5 { get; set; }
        public string fileName { get; set; }
        public string filePath { get; set; }
        public byte[] fileInfo { get; set; }
        public string parentID { get; set; }
        public Model(DataRow row)
        {
            this.fileID = row[0].ToString();
            this.fileMD5 = row[1].ToString();
            this.fileName = row[2].ToString();
            this.filePath = row[3].ToString();
            this.fileInfo = row[4] == DBNull.Value ? null : (byte[])row[4];
            this.parentID = row[5].ToString();
        }
        public Model(Guid fileID, string fileName, string filePath = null)
        {
            this.fileID = fileID.ToString();
            this.fileName = fileName;
        }
        public Model(Guid fileID, string fileName, string filePath, string fileMD5, byte[] fileInfo, string parentID)
            : this(fileID, fileName, filePath)
        {
            this.fileMD5 = fileMD5;
            this.fileInfo = fileInfo;
            this.parentID = parentID;
        }
    }
}
