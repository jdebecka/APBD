using RecursivePatterns;
using Tutorial2.Models;

namespace Tutorial2.Exception
{
    public class InvalidNumberOfPersonArguments : System.Exception
    {
        public InvalidNumberOfPersonArguments(string invalidStudent)
        {
            IReporter reporter = new Reporter();
            reporter.Report(this, $"Human: {invalidStudent} is broken: ", SecurityLevel.Error);
        }
    }
}