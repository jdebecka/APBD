using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Microsoft.VisualBasic;

namespace Tutorial2.Models
{
    [Serializable]
    public class University
    {
        [XmlArrayItem("student", typeof(Student))] 
        [JsonPropertyName("students")]
        public HashSet<Student> students { get; set; }

        [XmlArrayItem("activeStudies", typeof(ActiveStudies))]
        private Dictionary<Studies, int> activeStudies { get; set; }


        public University(){ }

        public University(HashSet<Student> students)
        {
            this.students = students;

        }

        void appendActiveStudies()
        {
            foreach (var VARIABLE in students)
            {
                var subjectCount = activeStudies;
                try
                {
                    foreach (var VarVar in VARIABLE.Studieses)
                    {
                        try
                        {
                            activeStudies.Add(VarVar, 1);
                        }
                        catch (ArgumentException)
                        {
                            int studMore = activeStudies[VarVar];
                            studMore += 1;
                            activeStudies.Add(VarVar, studMore);
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