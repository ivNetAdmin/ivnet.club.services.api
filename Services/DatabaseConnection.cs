using System.Configuration;

namespace ivnet.club.services.api.Services
{
    public static class DatabaseConnection
    {
        public static string Location
        {
            get
            {
               var folder = System.AppContext.BaseDirectory;
                var dbConStr = ConfigurationManager.ConnectionStrings["liteDbConStr"].ConnectionString;

                folder = folder.Replace(@"www\", "");
                return dbConStr.Replace("(folder)", folder);
            }
        }
    }
}