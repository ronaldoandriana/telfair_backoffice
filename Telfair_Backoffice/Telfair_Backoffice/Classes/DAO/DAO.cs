using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telfair_Backend.Classes.Entity;

namespace Telfair_Backend.Classes.DAO
{
    public class DAO
    {
        public MySchoolContext dbcontext;
        public static string ConnectionString { get; set; }
        public static string CoreConnectionString { get; set; }

        public DAO()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            ConnectionString = configuration.GetConnectionString("DB_CONFIGURATION");
            CoreConnectionString = configuration.GetConnectionString("DB_CONFIGURATION_CORE");
            dbcontext = new MySchoolContext(ConnectionString);
        }
    }
}
