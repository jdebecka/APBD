using System;
using System.IO;
using System.Xml.Serialization;
using Tutorial2.Models;

namespace Tutorial2.FileConverter
{
    public class XmlFormatter
    {
        public void Save(University university)
        {
            FileStream writer = new FileStream(@"/Users/juliadebecka/Documents/GitHub/APBD/Tutorial2/Data/result.xml", FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(University));
            serializer.Serialize(writer, university);
        }
    }
}