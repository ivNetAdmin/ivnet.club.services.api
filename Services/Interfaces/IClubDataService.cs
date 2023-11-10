using ivnet.club.services.api.Models;
using System.Collections.Generic;

namespace ivnet.club.services.api.Services.Interfaces
{
    public interface IClubDataService 
    {
        IEnumerable<Club> FindAll();
        Club FindById(string id);

        Club FindByCode(string code);

    }
}