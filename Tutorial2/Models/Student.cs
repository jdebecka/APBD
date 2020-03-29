using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using Tutorial2.Exception;

namespace Tutorial2.Models
{
    [Serializable]
    public class Student
    {
        public Student(string index, string name, string lname, string dob, string email, string mName, string fName)
        {
            IndexNumber = index;
            FirstName = name;
            LastName = lname;
            BirthDate = dob;
            Email = email;
            MothersName = mName;
            FathersName = fName;
            Studieses = new HashSet<Studies>(new StudiesComparer());
        }

        [XmlAttribute(attributeName:"index")]
        [JsonPropertyName("indexNumber")]
        public string IndexNumber{ get; set; }
        
        [XmlElement(ElementName = "fname")]
        [JsonPropertyName("fname")]
        public string FirstName{ get; set; }
        
        [XmlElement(ElementName  = "lname")]
        [JsonPropertyName("lname")]
        public string LastName{ get; set; }
        
        [XmlElement(ElementName  = "birthdate")]
        [JsonPropertyName("birthdate")]
        public string BirthDate{ get; set; }
        
        [XmlElement(ElementName  = "email")]
        [JsonPropertyName("email")]
        public string Email{ get; set; }
        
        [XmlElement(ElementName  = "mothersName")]
        [JsonPropertyName("mothersName")]
        public string MothersName{ get; set; }
        
        [XmlElement(ElementName  = "fathersName")]
        [JsonPropertyName("fathersName")]
        public string FathersName{ get; set; }
        // [XmlArray("studies")]
        [XmlArrayItem("activeStudies", typeof(HashSet<Studies>))] 
        [JsonPropertyName("studies")]
        public HashSet<Studies> Studieses { get; set; }

        public void appendStudies(Studies degree)
        {
            try
            {
                Studieses.Add(degree);
            }
            catch (System.Exception e)
            {
                throw new DuplicateMemberException(degree);
            }
            
        }
    }
}
