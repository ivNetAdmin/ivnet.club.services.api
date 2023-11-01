using ivnet.club.services.api.Models;
using System.Collections.Generic;

namespace ivnet.club.services.api.Services.Interfaces
{
    public interface IRinkBookingDataService
    {
        IEnumerable<RinkBooking> FindAll();
    }
}