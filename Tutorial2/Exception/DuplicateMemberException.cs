using RecursivePatterns;

namespace Tutorial2.Exception
{
    public class DuplicateMemberException : System.Exception
    {
        public DuplicateMemberException(object obj)
        {
            IReporter reporter = new Reporter();
            reporter.Report(this, $"Member {obj.ToString()} already exist. He was not duplicated.", SecurityLevel.Warning);
        }
    }
}