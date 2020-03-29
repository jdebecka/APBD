using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Tutorial2.Models
{
    [Serializable]
    public class University
    {
        [XmlArrayItem("student", typeof(HashSet<Student>))] 
        [JsonPropertyName("students")]
        public HashSet<Student> students { get; set; }

        [JsonPropertyName("activeStudies")]
        [XmlArrayItem("activeStudies", typeof(Dictionary<string, int>))] 
        public Dictionary<string, int> activeStudies { get; set; }
        
        public University(){ }

        public University(HashSet<Student> students)
        {
            this.students = students;
            activeStudies = new Dictionary<String, int>();
            appendActiveStudies();

        }
        
        void appendActiveStudies()
        {
            foreach (var student in students)
            {
                var subjectCount = activeStudies;
                try
                {
                    foreach (var study in student.Studieses)
                    {
                        try
                        {
                            activeStudies.Add(study.Name, 1);
                        }
                        catch (ArgumentException)
                        {
                            int studMore = activeStudies[study.Name];
                            studMore += 1;
                            activeStudies[study.Name] = studMore;
                        }
                        
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("An element with Key = \"txt\" already exists.");
                }
            }
        }

    }
}