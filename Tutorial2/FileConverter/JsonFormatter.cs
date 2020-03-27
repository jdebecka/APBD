using System;
using System.IO;
using System.Text.Json;
using Tutorial2.Models;

namespace Tutorial2.FileConverter
{
    public class JsonFormatter
    {
        public JsonFormatter(string finFile, Object classa)
        {
            using (FileStream fs = File.Create(finFile))
            {
                File.WriteAllText("result.json", JsonSerializer.Serialize(classa));
            }
        }
    }
}