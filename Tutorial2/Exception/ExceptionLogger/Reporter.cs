﻿using System;
 using System.IO;
 namespace RecursivePatterns
 {
     public class Reporter : IReporter
     {
         public Reporter() { }
         public void Report(Exception ex, string description, SecurityLevel level)
         {
             using var sw = new StreamWriter(@"/Users/juliadebecka/Desktop/4th_semester/Tutorial2_Solution/Tutorial2/Data/log.txt");
             sw.WriteLine($"{level}: {ex}, Description: {description}");
         }
     }
 }
