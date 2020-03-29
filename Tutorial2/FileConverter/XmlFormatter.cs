using System;
using System.IO;
using System.Xml.Serialization;
using Tutorial2.Models;

namespace Tutorial2.FileConverter
{
    public class XmlFormatter
    {
        public void Save(University university, string filePath)
        {
            var parsedDate = DateTime.Parse("2000-02-12");
            var xs = new XmlSerializer(typeof(University), new XmlRootAttribute("university"));
            using(var writer = new FileStream(@"result.xml", FileMode.Create))
            {
                xs.Serialize(writer, university);
            }
        }
    }
}