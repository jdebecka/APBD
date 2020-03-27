using RecursivePatterns;
using Tutorial2.Models;

namespace Tutorial2.Exception
{
    public class DuplicateMemberException : System.Exception
    {
        public DuplicateMemberException(Student student)
        {
            IReporter reporter = new Reporter();
            reporter.Report(this, $"Member {student} already exist. He was not duplicated.", SecurityLevel.Warning);
        }
    }
}