using System;
namespace prop_central_netcore.Shared.Configuration
{
	public static class AppSettings
	{
        public static string APIBaseUrl { get; set; } = ConfigHelper.GetValueByParent("AppSetting", "apibaseurl");
        public static string PhotoBaseUrl { get; set; } = ConfigHelper.GetValueByParent("AppSetting", "photosuploadurl");
        public static string ApplicationBaseUrl { get; set; } = ConfigHelper.GetValueByParent("AppSetting", "EmailHostUrl");
        public static string EmailHostUrl { get; set; } = ConfigHelper.GetValueByParent("AppSetting", "ApplicationBaseUrl");
        public static string SmtpPort { get; set; } = ConfigHelper.GetValueByParent("AppSetting", "No_replyEmail");
        public static string No_replyEmail { get; set; } = ConfigHelper.GetValueByParent("AppSetting", "IdentityServerApiUrl");
        public static string No_replyPassword { get; set; } = ConfigHelper.GetValueByParent("AppSetting", "No_replyPassword");
        public static string DbConnectionString { get; set; } = ConfigHelper.GetValueByParent("ConnectionStrings", "Default");
     
    }
}

