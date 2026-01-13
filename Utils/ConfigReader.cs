using Microsoft.Extensions.Configuration;

namespace LoginAutomationTest.Utils
{
    public static class ConfigReader
    {
        public static IConfiguration Config { get; }

        static ConfigReader()
        {
            Config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}
