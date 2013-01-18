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
            if (fileName == null)
            {
                throw new ArgumentNullException("fileName");
            }
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            this.FileName = fileName;
            this.Data = data;
        }

        public UploadFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found.", filePath);
            }

            this.FileName = Path.GetFileName(filePath);
            this.Data = File.ReadAllBytes(filePath);
        }
    }
}
