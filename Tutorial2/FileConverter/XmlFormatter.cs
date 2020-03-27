using System;
using System.IO;
using System.Xml.Serialization;

namespace Tutorial2.FileConverter
{
    public class XmlFormatter
    {
        public void Save(Type dataType, object data, string filePath)
        {
            using(var stream = new FileStream(filePath, FileMode.Create))
            {
                XmlSerializer XML = new XmlSerializer(dataType);
                XML.Serialize(stream, data);
            }
        }
        
        public void Save(Type dataType, object data, string parent, string filePath)
        {
            using(var stream = new FileStream(filePath, FileMode.Create))
            {
                XmlSerializer XML = new XmlSerializer((dataType), new XmlRootAttribute(parent));
                XML.Serialize(stream, data);
            }
        }
    }
}