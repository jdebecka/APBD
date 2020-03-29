using RecursivePatterns;

namespace Tutorial2.Exception
{
    public class WrongInputException : System.Exception
    {
        public WrongInputException(int statusCode)
        {
            Reporter reporter = new Reporter();
            reporter.Report(this, "Warning: Wrong number of arguments: ", SecurityLevel.Warning);
        }
    }
}