using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace ivnet.club.services.api.Helpers
{
    public class DocumentConverter
    {
        #region Singleton
        static DocumentConverter _documentConverter = null;

        private DocumentConverter() { }

        public static DocumentConverter Instance
        {
            get
            {
                if (_documentConverter == null)
                {
                    _documentConverter = new DocumentConverter();
                }

                return _documentConverter;
            }
        }
        #endregion

        public string CsvToXml(string sourcePath)
        {
            var fileExists = File.Exists(sourcePath);

            if (fileExists)
            {
                var formatedLines = LoadCsv(sourcePath);
                var headers = formatedLines[0].Split(',').Select(x => x.Trim('\"').Replace(" ", string.Empty)).ToArray();

                var xml = new XElement("Root",
                   formatedLines.Where((line, index) => index > 0).
                       Select(line => new XElement("Item",
                          line.Split(',').Select((field, index) => new XElement(headers[index], field)))));

                return xml.InnerXml();
            }

            return null;
        }

        private List<string> LoadCsv(string sourcePath)
        {
            var lines = File.ReadAllLines(sourcePath).ToList();

            var formatedLines = new List<string>();

            foreach (var line in lines)
            {
                var formatedLine = line.TrimEnd(',');
                formatedLines.Add(formatedLine);
            }
            return formatedLines;
        }
    }
}