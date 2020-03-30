using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using RecursivePatterns;
using Tutorial2.Exception;
using Tutorial2.FileConverter;
using Tutorial2.Models;

namespace Tutorial2.FileReader
{
    public class Reader
    {

        public static void readFile(string initPath, string finPath, string finalFormat)
        {
            var listOfStudents = new HashSet<Student>(new CustomComparer());
            var activeStudies = new HashSet<ActiveStudies>(new ActiveStudiesComparer());
            var fi = new FileInfo(initPath);
            try
            {
                using (var stream = new StreamReader(fi.OpenRead()))
                {
                    string line = null;
                    //Check if line exist, because if line == null it means that we have reached the end of the file
                    mainLoop: while ((line = stream.ReadLine()) != null)
                    {
                        var columns = line.Split(',');
                        if (columns.Length < 9)
                        {
                            issueWhileReading(columns);
                        }

                        if(columns.Any(string.IsNullOrWhiteSpace))
                        {
                            issueWhileReading(columns);
                            continue;
                        }
                        
                        //Creates new objects
                        var newStudent = new Student(columns[4], columns[0], columns[1], columns[5], columns[6],
                            columns[7], columns[8]);
                        var studies = new Studies(columns[2], columns[3]);
                        var possibleActiveStudy = new ActiveStudies(studies);
                        //appends studies to new Student
                        newStudent.appendStudies(studies);
                        
                        //tries to add student to list of student
                        //if exists then appends additional studies to the existing student
                        if(!listOfStudents.Add(newStudent))
                        {
                            try
                            {
                                throw new DuplicateMemberException(newStudent);
                            }
                            catch (System.Exception)
                            {
                            }
                            var studentToUpdate = listOfStudents.First(stu => stu.IndexNumber == newStudent.IndexNumber);
                            studentToUpdate.appendStudies(studies);
                        }

                        //tries to add active study
                        //if exist then increases the number of students by 1
                        if(!activeStudies.Add(possibleActiveStudy))
                        {
                            var studyToUpdate = activeStudies.First(active => active.StudyName == possibleActiveStudy.StudyName);
                            studyToUpdate.increaseNumberOfStudents();
                        }
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
            University university =  new University(listOfStudents, activeStudies);
            if (finalFormat.Equals("xml", StringComparison.OrdinalIgnoreCase))
            {
                new XmlFormatter().Save(university);
            }
            else
            {
                new JsonFormatter().Serialize(university);
            }
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