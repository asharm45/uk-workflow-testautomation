using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using FluentAssertions.Equivalency;
using Microsoft.Playwright;

namespace WorkflowSpecflowTests.Config
{
    public interface IXMLUpdate
    {
        Task<string> UpdateXMLFile(string fileName, string tagName, string newValue, int index);
        Task<string> GetXml(string fileName);
        Task<string> GetElementFromResponse(XDocument fileName, string elementName, int index);
        Task<string> GetElementByAttribute(XDocument response, string tagName, string attributeName, int index);
        Task<string> UpdateElementByAttribute(string fileName, string tagName, string attributeName, string newValue, int index);
        Task<string> GetCurrentTimestamp();
        Task<string> GetTimestamp();
        Task<string> GetStartDate();
        Task<string> GetEndDate();
        Task<string> GetNextYearDate();
        Task<string> Get45Days();
    }

    public class XMLUpdate : IXMLUpdate
    {

        private string GetRootDir()
        {
           
            string currentDirectory = Directory.GetCurrentDirectory();
            int binIndex = currentDirectory.IndexOf("bin");
            if (binIndex != -1)
            {
                return currentDirectory.Substring(0, binIndex - 1);

            }
            return null;
        }

        public async Task<string> UpdateXMLFile(string fileName, string tagName, string newValue, int index)
        {

            
            var path = GetRootDir() + $"/XML/{fileName}.xml";
            XDocument doc;
            using (var stream = File.OpenRead(path))
            {
                doc = await XDocument.LoadAsync(stream, LoadOptions.None, default);
            }

            XElement element;

            element = doc.Root.Descendants(tagName).ElementAt(index);

            if (element != null)
            {
                element.Value = newValue;

                using (var stream = File.Open(path, FileMode.Create, FileAccess.Write))
                {
                    await doc.SaveAsync(stream, SaveOptions.None, default);
                }
                //add log statement
                return doc.ToString();
            }
            else
            {
                //add log statement
                return null;
            }

        }




        public async Task<string> GetXml(string fileName)
        {
            
            var path = GetRootDir() + $"/XML/{fileName}.xml";
            XDocument doc;
            using (var stream = File.OpenRead(path))
            {
                doc = await XDocument.LoadAsync(stream, LoadOptions.None, default);
            }
            return doc.ToString();
        }

        public async Task<string> GetElementFromResponse(XDocument response, string elementName, int index)
        {
            XElement resultElement;

            resultElement = response.Descendants(elementName).ElementAt(index);

            if (resultElement != null)
            {
                return resultElement.Value;
            }
            else
            {
                throw new Exception("Response element not found");
            }
        }


        public async Task<string> GetElementByAttribute(XDocument response, string tagName, string attributeName, int index)
        {

            XElement resultElement;

            resultElement = response.Descendants(tagName).ElementAt(index);

            return resultElement.Attribute(attributeName).Value;

        }


        public async Task<string> UpdateElementByAttribute(string fileName, string tagName, string attributeName, string newValue, int index)
        {
            var path = GetRootDir() + $"/XML/{fileName}.xml";
            XDocument doc;
            using (var stream = File.OpenRead(path))
            {
                doc = await XDocument.LoadAsync(stream, LoadOptions.None, default);
            }

            XElement element;

            if (tagName.Equals("contactIVO") || tagName.Equals("policyHeaderIVO"))
            {
                XNamespace ns = "http://www.idit.co.il/schemas/all/interfaces-root";
                element = doc.Descendants(ns + tagName).ElementAt(index);
            }
            else
            {
                element = doc.Descendants(tagName).ElementAt(index);
            }


            if (element != null)
            {
                element.SetAttributeValue(attributeName, newValue);
                using (var stream = File.Open(path, FileMode.Create, FileAccess.Write))
                {
                    await doc.SaveAsync(stream, SaveOptions.None, default);
                }
            }
            return doc.ToString();

        }


        public async Task<string> GetCurrentTimestamp()
        {
            DateTimeOffset now = (DateTimeOffset)DateTime.UtcNow;

            return now.ToString("yyyyMMddHHmmss").ToString();
        }

        public async Task<string> GetTimestamp()
        {
            DateTimeOffset now = (DateTimeOffset)DateTime.UtcNow;

            var today = now.ToString("yyyy-MM-ddT00:00:00").ToString();
            var next = now.AddYears(1).AddDays(-1).ToString("yyyy-MM-ddT00:00:00").ToString();

            return now.ToString("yyyy-MM-ddTHH:mm:ss.fff").ToString();
        }

        public async Task<string> GetStartDate()
        {
            DateTimeOffset now = (DateTimeOffset)DateTime.UtcNow;

            return now.ToString("yyyy-MM-ddT00:00:00").ToString();

        }

        public async Task<string> GetEndDate()
        {
            DateTimeOffset now = (DateTimeOffset)DateTime.UtcNow;

            return now.AddYears(1).AddDays(-1).ToString("yyyy-MM-ddT00:00:00").ToString();

        }

        public async Task<string> GetNextYearDate()
        {
            DateTimeOffset now = (DateTimeOffset)DateTime.UtcNow;

            return now.AddYears(1).ToString("yyyy-MM-ddT00:00:00").ToString();

        }

        public async Task<string> Get45Days()
        {
            DateTimeOffset now = (DateTimeOffset)DateTime.UtcNow;

            return now.AddDays(45).ToString("yyyy-MM-ddT00:00:00").ToString();

        }
    }
}
