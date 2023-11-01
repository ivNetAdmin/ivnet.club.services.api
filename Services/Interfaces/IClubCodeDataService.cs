using ivnet.club.services.api.Models;
using System.Collections.Generic;

namespace ivnet.club.services.api.Services.Interfaces
{
    public interface IClubCodeDataService 
    {
        IEnumerable<ClubCode> FindAll();
        ClubCode FindById(string id);

        ClubCode FindByCode(string code);

    }
}