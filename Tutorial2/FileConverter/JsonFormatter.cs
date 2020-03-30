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
            File.WriteAllText(@"/Users/juliadebecka/Documents/GitHub/APBD/Tutorial2/Data/result.json", jsonString);
        }
        }
    }