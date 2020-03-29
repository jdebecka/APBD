using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Tutorial2.Models
{
    [Serializable]
    public class Studies
    {
        [XmlAttribute(attributeName: "name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [XmlAttribute(attributeName: "mode")]
        [JsonPropertyName("mode")]
        public string Mode { get; set; }

        public Studies(string name, string mode)
        {
            Name = name;
            Mode = mode;
        }
    }
}
