using System;
using System.IO;
using System.Text.Json;
using Tutorial2.Models;

namespace Tutorial2.FileConverter
{
    public class JsonFormatter {
        public void Serialize (University university) {
            var jsonString = JsonSerializer.Serialize(university, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
            File.WriteAllText(@"/Users/juliadebecka/Desktop/4th_semester/Tutorial2_Solution/Tutorial2/Data/result.json", jsonString);
        }
        }
    }