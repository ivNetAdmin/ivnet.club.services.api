﻿using ivnet.club.services.api.Models;
using System.Collections.Generic;

namespace ivnet.club.services.api.Services.Interfaces
{
    public interface IMemberDataService
    {
        IEnumerable<Member> FindAll();

        Member FindById(string id);
        Member FindByUsername(string username);

        IEnumerable<Member> FindByEmailAndClubCode(string email, string clubcode);

        void Add(Member user);

        void Patch(Member user);
    }
}