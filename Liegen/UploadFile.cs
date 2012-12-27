using System;
using System.IO;

namespace Meton.Liegen
{
    public class UploadFile
    {
        public string FileName { get; set; }
        public byte[] Data { get; set; }

        public UploadFile(string fileName, byte[] data)
        {
            if (fileName == null || data == null)
            {
                throw new InvalidOperationException("fileName/data: null");
            }

            this.FileName = fileName;
            this.Data = data;
        }

        public UploadFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new IOException("File not found.");
            }
            this.FileName = Path.GetFileName(filePath);
            this.Data = File.ReadAllBytes(filePath);
        }
    }
}
