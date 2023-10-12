using _2_oy_imtihon_project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace _2_oy_imtihon_project.ServiceLayer
{
    public class FileContext<T> : IFileContext<T> where T : class
    {

        private string sourcePath;

        public FileContext(string path)
        {
            sourcePath = path;
            if (string.IsNullOrEmpty(File.ReadAllText(sourcePath)))
                File.WriteAllText(sourcePath, "[ ]");
        }

        public IEnumerable<T> Readtext()
        {
            var jsonString = File.ReadAllText(sourcePath);
            var jsonData = JsonSerializer.Deserialize<IEnumerable<T>>(jsonString);
            return jsonData;
        }

        public bool Writetext<T>(List<T> data)
        {
            var jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(sourcePath, jsonData);
            return true;
        }
    }
}

