using System;
using System.Collections.Generic;
using Tutorial2.Models;

namespace Tutorial2
{
    public class ActiveStudiesComparer : IEqualityComparer<ActiveStudies>
    {
        public bool Equals(ActiveStudies x, ActiveStudies y)
        {
            return StringComparer
                .InvariantCultureIgnoreCase
                .Equals($"{x.StudyName}",
                    $"{y.StudyName}");
        }
        public int GetHashCode(ActiveStudies obj)
        {
            return StringComparer.CurrentCultureIgnoreCase
                .GetHashCode($"{obj.StudyName}");
        }
    }
}