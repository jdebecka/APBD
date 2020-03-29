using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Tutorial2.Models
{
    [Serializable]
    public class ActiveStudies
    {
        [XmlAttribute(attributeName:"name")]
        [DataMember]
        [JsonPropertyName("name")]
        private string Name { get; set; }
        
        [XmlAttribute(attributeName:"numberOfStudents")]
        [JsonPropertyName("numberOfStudents")]
        private int NumberOfStudents { get; set; }

        public void increaseNumberOfStudents(int currentCount)
        {
            NumberOfStudents += 1;
        }
    }
}