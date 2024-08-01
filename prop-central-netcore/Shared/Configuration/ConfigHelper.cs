using System;
namespace prop_central_netcore.Shared.Configuration
{
	public static class ConfigHelper
	{
        public static string GetValueByParent(string parent, string Key)
        {
            return GetCurrentSettings().GetSection(parent).GetValue<string>(Key);
        }
        private static IConfigurationRoot GetCurrentSettings()
        {
            var builder = new ConfigurationBuilder()
           .AddJsonFile($"appsettings.{GetEnvironmentFromAppSettings()}.json", optional: false, reloadOnChange: true)
             .AddEnvironmentVariables();
            return builder.Build();
        }
        private static string GetEnvironmentFromAppSettings()
        {
            var builder = new ConfigurationBuilder()
          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();
            return builder.Build().GetSection("environmentVariables").GetValue<string>("ASPNETCORE_ENVIRONMENT");
        }
    }
}

