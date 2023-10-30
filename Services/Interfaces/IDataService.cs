using ivnet.club.services.api.Models;
using LiteDB;
using System.Collections.Generic;

namespace ivnet.club.services.api.Services.Interfaces
{
    public interface IDataService
    {
        IEnumerable<RinkBooking> FindAll();
    }
}