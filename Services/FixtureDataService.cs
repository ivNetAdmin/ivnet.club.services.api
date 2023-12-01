using ivnet.club.services.api.Helpers;
using ivnet.club.services.api.Models;
using ivnet.club.services.api.Services.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Xml;

namespace ivnet.club.services.api.Services
{
    public class FixtureDataService : IFixtureDataService
    {
        private string _dbConStr;
        public FixtureDataService()
        {
            _dbConStr = DatabaseConnection.Location;
        }

        public IEnumerable<Fixture> FindAll()
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                return db.GetCollection<Fixture>("Fixtures").FindAll();
            }
        }

        public IEnumerable<Fixture> BuildAll()
        {
            var xmlDoc = new XmlDocument();
            var path = Path.Combine(
                        HttpContext.Current.Server.MapPath($"~/uploads/fixtures"),
                        "fixtures.csv");

            var xml = DocumentConverter.Instance.CsvToXml(path);
            
            if(string.IsNullOrEmpty(xml)) return null;

            xmlDoc.LoadXml($"<root>{xml}</root>");

            using (var db = new LiteDatabase(_dbConStr))
            {
                var collection = db.GetCollection<Fixture>("Fixtures");
                collection.DeleteAll();

                foreach (XmlElement fixtureXml in xmlDoc.DocumentElement.SelectNodes("Item"))
                {
                    try
                    {
                        var fixture = new Fixture
                        {
                            Id = Guid.NewGuid().ToString(),
                            Date = fixtureXml.SelectSingleNode("Date").InnerText,
                            Time = fixtureXml.SelectSingleNode("Time").InnerText,
                            Opponent = fixtureXml.SelectSingleNode("Opponent").InnerText,
                            HomeOrAway = fixtureXml.SelectSingleNode("HomeOrAway").InnerText,
                            Kit = fixtureXml.SelectSingleNode("Kit").InnerText
                        };

                        collection.Insert(fixture);
                    }
                    catch (Exception) { }
                }

                return db.GetCollection<Fixture>("Fixtures").FindAll();
            }
        }

    }
}