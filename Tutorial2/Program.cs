using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using RecursivePatterns;
using Tutorial2.Exception;
using Tutorial2.FileReader;
using Tutorial2.Models;

namespace Tutorial2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var userInput = input.Split(" ");
            var initPath = userInput[0];
            var finPath = userInput[1];
            var finFormat = userInput[2];
            
            do
            {
                if (initPath == "" || finPath == "" || finFormat == "")
                {
                    try
                    {
                        throw new WrongInputException(100);
                    }
                    catch (System.Exception ex)
                    {
                    }
                }
                else
                {
                    break;
                }
                input = Console.ReadLine();
            } while (true);
            
            
            Reader.readFile(initPath, finPath, finFormat);
            
            //Parse the string with date into the type DateTime
            var parsedDate = DateTime.Parse("2000-02-12");
            Console.WriteLine(parsedDate);

        }
    }
}
