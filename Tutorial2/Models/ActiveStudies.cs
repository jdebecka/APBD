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
        public string StudyName { get; set; }
        
        [XmlAttribute(attributeName:"numberOfStudents")]
        [JsonPropertyName("numberOfStudents")]
        public int NumberOfStudents { get; set; }

        public ActiveStudies() { }

        public ActiveStudies(Studies study)
        {
            StudyName = study.Name;
            NumberOfStudents = 1;
        }
        public void increaseNumberOfStudents()
        {
            NumberOfStudents += 1;
        }
    }
}