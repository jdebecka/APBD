﻿using System;
 using System.IO;
 namespace RecursivePatterns
 {
     public class Reporter : IReporter
     {
         public Reporter() { }
         public void Report(Exception ex, string description, SecurityLevel level)
         {
             FileStream fs = new FileStream(@"/Users/juliadebecka/Documents/GitHub/APBD/Tutorial2/Data/log.txt", FileMode.Open, FileAccess.ReadWrite);
             fs.Seek(0, SeekOrigin.Begin);
        
             StreamWriter sw = new StreamWriter(fs);
             sw.WriteLine($"{level}: {ex}, Description: {description}");
             
             sw.Close();
             fs.Close();

         }
     }
 }
