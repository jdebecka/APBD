using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.IO;
using System.Reflection.Emit;
using System.Runtime.Serialization.Formatters;
using System.Text;
using RecursivePatterns;
using Tutorial2.Exception;
using Tutorial2.Models;

namespace Tutorial2.FileReader
{
    public class Reader
    {

        public static void readFile(string initPath, string finPath, string finalFormat)
        {
            var listOfStudents = new HashSet<Student>(new CustomComparer());
            var fi = new FileInfo(initPath);
            try
            {
                using (var stream = new StreamReader(fi.OpenRead()))
                {
                    string line = null;
                    //Check if line exist, because if line == null it means that we have reached the end of the file
                    while ((line = stream.ReadLine()) != null)
                    {
                        var columns = line.Split(',');
                        if (columns.Length < 9)
                        {
                            issueWhileReading(columns);
                        }

                        foreach (var VARIABLE in columns)
                        {
                            if(string.IsNullOrWhiteSpace(VARIABLE))
                            {
                                issueWhileReading(columns);
                                break;
                            }
                        }
                        var newStudent = new Student(columns[0], columns[1], columns[4], columns[5], columns[6],
                            columns[7], columns[8]);
                        
                        var studeies = new Studies(columns[2], columns[3]);

                        if(!listOfStudents.Add(newStudent))
                        {
                            try
                            {
                                var str = new StringBuilder();
                                str.Append(columns);
                                throw new DuplicateMemberException(newStudent);
                            }
                            catch (System.Exception e)
                            {
                                //doNothing
                            }
                        }
                        
                        newStudent.appendStudies(studeies);
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                IReporter reporter = new Reporter();
                reporter.Report(ex, $"ERROR: Incorrect path: {initPath}", SecurityLevel.Error);
            }
            catch(FileNotFoundException ex)
            {
                IReporter reporter = new Reporter();
                reporter.Report(ex, $"ERROR: File does not exist: {initPath}", SecurityLevel.Error);
            }
            
            //adding students to the university
            new University(listOfStudents);
            
            //Exception reporting
            void issueWhileReading(string[] columns)
            {
                try
                {
                    var str = new StringBuilder();
                    str.Append(columns);
                    throw new InvalidNumberOfPersonArguments(str.ToString());
                }
                catch (System.Exception e)
                {
                }
            }
        }
    }
}