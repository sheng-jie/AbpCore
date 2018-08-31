using System.Threading.Tasks;

namespace AbpCore.Configuration
{
    public interface ISettingManager
    {
        Task<string> GetSettingValueAsync(string name, int? tenantId, int? userId);

        Task ChangeSettingsAsync(string name, string value, int? tenantId, int? userId);
    }
}