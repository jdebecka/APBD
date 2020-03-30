using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Tutorial2.Models
{
    [Serializable]
    public class University
    {
        [XmlArrayItem("student", typeof(Student))] 
        [JsonPropertyName("students")]
        public HashSet<Student> Students { get; set; }

        [JsonPropertyName("activeStudies")]
        [XmlArrayItem("activeStudies", typeof(ActiveStudies))] 
        public HashSet<ActiveStudies> ActiveStudies { get; set; }
        
        public University(){ }

        public University(HashSet<Student> students, HashSet<ActiveStudies> activeStudies)
        {
            Students = students;
            ActiveStudies = activeStudies;

        }
    }
}