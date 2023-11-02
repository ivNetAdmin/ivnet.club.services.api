using ivnet.club.services.api.Models;
using System.Collections.Generic;

namespace ivnet.club.services.api.Services.Interfaces
{
    public interface IUserDataService
    {
        IEnumerable<User> FindAll();

        User FindById(string id);
        User FindByUsername(string username);

        IEnumerable<User> FindByEmailAndClubCode(string email, string clubcode);

        void Add(User user);

        void Patch(User user);
    }
}