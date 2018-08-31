using System.Collections.Generic;
using AbpCore.Configuration;

namespace AbpCore.Tests.Configuration
{
    public class TestSettingProvider : SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions()
        {
            return new List<SettingDefinition>()
            {
                new SettingDefinition("EmailSettingNames.DefaultFromAddress", "admin@mydomain.com"),
                new SettingDefinition("EmailSettingNames.DefaultFromDisplayName", "mydomain.com mailer"),
                new SettingDefinition("EmailSettingNames.Smtp.Port", "587"),
                new SettingDefinition("EmailSettingNames.Smtp.Host", "smtp.qq.com"),
                new SettingDefinition("EmailSettingNames.Smtp.UserName", "ysjshengjie@qq.com"),
                new SettingDefinition("EmailSettingNames.Smtp.Password", "123456"),
                new SettingDefinition("EmailSettingNames.Smtp.Domain", ""),
                new SettingDefinition("EmailSettingNames.Smtp.EnableSsl", "true"),
                new SettingDefinition("EmailSettingNames.Smtp.UseDefaultCredentials", "false")

            };
        }
    }
}