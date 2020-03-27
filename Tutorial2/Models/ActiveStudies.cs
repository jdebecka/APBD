using System;
using System.Security.Cryptography;

namespace Tutorial2.Models
{
    [Serializable]
    public class ActiveStudies
    {
        private string Name { get; set; }
        private int NumberOfStudents { get; set; }

        public void increaseNumberOfStudents(int currentCount)
        {
            NumberOfStudents += 1;
        }
    }
}