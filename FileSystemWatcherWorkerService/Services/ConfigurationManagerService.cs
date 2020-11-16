using Microsoft.Extensions.Configuration;
using System;

namespace FileSystemWatcherWorkerService.Services
{
    public class ConfigurationManagerService
    {
        private readonly IConfiguration _configuration;

        public ConfigurationManagerService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetFilePath()
        {
            var result =
               _configuration.GetValue<string>("FilePath");
            if (string.IsNullOrEmpty(result))
            {
                throw new Exception("Couldn't find value for FilePath in the appsettings.json file");
            }
            return result;
        }

    }
}