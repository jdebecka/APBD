using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Tutorial2.Models;

namespace Tutorial2
{
    //Create our custom comparer which implements the interface IEqualityComparer<T>
    //Comparer works on objects of class Student
    public class CustomComparerStudies : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            //We use the class StringComparer to compare our objects
            //In the method Equals of the class StringComparer we create to strings from our objects
            //which will be compared
            return StringComparer
                        .InvariantCultureIgnoreCase
                        .Equals($"{x.Studieses}",
                                $"{y.Studieses}");
        }
        public int GetHashCode(Student obj)
        {
            return StringComparer.
                    CurrentCultureIgnoreCase
                    .GetHashCode($"{obj.Studieses}");
        }
    }
}
