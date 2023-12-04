using System;

namespace ivnet.club.services.api.Services.Interfaces
{
    public interface ILogDataService
    {
        void LogError(Exception ex);
    }
}