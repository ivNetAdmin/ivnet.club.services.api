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
        private readonly ILogDataService _logService;
        private string _dbConStr;
        public FixtureDataService(LogDataService logService)
        {
            _logService = logService;
            _dbConStr = DatabaseConnection.Location;
        }

        public IEnumerable<Fixture> FindAll()
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                try
                {
                    return db.GetCollection<Fixture>("Fixtures").FindAll();
                }
                catch (Exception ex)
                {
                    _logService.LogError(ex);
                    throw ex;
                }
            }
        }

        public Fixture FindById(string id)
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                try
                {
                    return db.GetCollection<Fixture>("Fixtures").FindById(id);
                }
                catch (Exception ex)
                {
                    _logService.LogError(ex);
                    throw ex;
                }
            }
        }

        public bool BuildAll()
        {
            try
            {
                var xmlDoc = new XmlDocument();
                var path = Path.Combine(
                            HttpContext.Current.Server.MapPath($"~/uploads/fixtures"),
                            "fixtures.csv");

                var xml = DocumentConverter.Instance.CsvToXml(path);

                if (string.IsNullOrEmpty(xml)) return false;

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
                                Kit = fixtureXml.SelectSingleNode("Kit").InnerText,
                                Trips = fixtureXml.SelectSingleNode("Trips").InnerText
                            };

                            collection.Insert(fixture);
                        }
                        catch (Exception) { }
                    }

                    return collection.Count() > 0;
                }
            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
                throw ex;
            }
        }
        public void Patch(Fixture fixture)
        {
            using (var db = new LiteDatabase(_dbConStr))
            {
                try
                {
                    var collection = db.GetCollection<Fixture>("Fixtures");
                    collection.Update(fixture);
                }
                catch (Exception ex)
                {
                    _logService.LogError(ex);
                    throw ex;
                }
            }
        }

        public void Clear()
        {
            try
            {
                using (var db = new LiteDatabase(_dbConStr))
                {
                    var collection = db.GetCollection<Fixture>("Fixtures");
                    collection.DeleteAll();
                }
            }
            catch (Exception ex)
            {
                _logService.LogError(ex);
                throw ex;
            }
        }
    }
}