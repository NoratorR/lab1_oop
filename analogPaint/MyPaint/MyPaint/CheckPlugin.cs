using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace MyPaint
{
    class CheckPlugin
    {
        private byte[] readhash = new byte[16];
        private byte[] filecash = new byte[16];

        private FileStream file;
        private string path;

        public CheckPlugin(string path)
        {
           file = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
            this.path = path;
        }

        public bool  CheckIfCorrect()
        {
            if (!readFileCash())
                return false;
            if (!CountFileCash())
                return false;
            for (int i = 0; i < readhash.Length - 1; i++)
                if (readhash[i] != filecash[i])
                    return false;
            RefreshFile();
            return true;


        }


        public bool CountFileCash()
        {
            try
            {
               
                byte[] fileContent = File.ReadAllBytes(path);
                MD5 mdhash = MD5.Create();
                filecash =  mdhash.ComputeHash(fileContent);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool readFileCash()
        {
            
                if (file.Length <= 16)
                    return false;
                file.Seek(-16, SeekOrigin.End);
                file.Read(readhash, 0, 16);
                file.Close();
                byte[] fileData = File.ReadAllBytes(path);
                Array.Resize(ref fileData, fileData.Length - 16);
                File.WriteAllBytes(path, fileData);
                return true;
           
        }

        public void RefreshFile()
        {
            file =  new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
            file.Seek(0,SeekOrigin.End);
            file.Write(readhash,0,16);
            file.Close();

        }


    }
}
