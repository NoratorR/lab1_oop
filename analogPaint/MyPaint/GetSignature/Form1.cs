using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace GetSignature
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string file = String.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                 file = openFileDialog1.FileName;
            if (!String.IsNullOrEmpty(file))
                GetHashCode(file);

        }

        public void GetHashCode(string filePath)
        {
            byte[] fileContent = File.ReadAllBytes(filePath);
            MD5 mdHash = MD5.Create();
            byte[] data = mdHash.ComputeHash(fileContent);
            FileStream file =  new FileStream(filePath, FileMode.Append, FileAccess.Write);
            file.Write(data,0,16);
            file.Close();
            label1.Text = "Hash" + Encoding.ASCII.GetString(data);

        }
    }
}
