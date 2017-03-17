using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml.Serialization;
using System.IO;

namespace MyPaint
{
    
    class Serialize
    {
        private XmlSerializer format;
        private string fileName;

        public Serialize(string fileName)
        {
            this.fileName = fileName;
        }
        public void getSave(List<SaveData> Svd)
        {
             
               format = new XmlSerializer(typeof(List<SaveData>));
               using (FileStream fs = File.Open(fileName, FileMode.Open))
               format.Serialize(fs, Svd);
              
        }

        public List<SaveData> getLoad(string filename)
        {
            List<SaveData> temp = new List<SaveData>();
            XmlSerializer deserializer = new XmlSerializer(typeof(List<SaveData>));
            TextReader reader = new StreamReader(fileName);
             object obj = deserializer.Deserialize(reader);
            List<SaveData> XmlData = (List<SaveData>)obj;
            reader.Close();
            return XmlData;
        }


    }
}
