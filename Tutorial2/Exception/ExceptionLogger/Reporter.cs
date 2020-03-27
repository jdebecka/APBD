﻿using System;
 using System.IO;
 using Tutorial2.Exception;
 namespace RecursivePatterns
 {
     public class Reporter : IReporter
     {
         public Reporter() { }
         public void Report(Exception ex, string description, SecurityLevel level)
         {
             using var sw = new StreamWriter(@"log.txt");
             sw.WriteLine($"{level}: {ex}, Description: {description}");
         }
     }
 }
