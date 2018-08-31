using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbpCore.Configuration
{
    /// <summary>
    /// 存储设置项于内存中
    /// </summary>
    public class MemorySettingStore : ISettingStore
    {
        private ConcurrentDictionary<string, List<SettingInfo>> _allSettings;

        public static MemorySettingStore Instance { get; } = new MemorySettingStore();

        private MemorySettingStore()
        {
            _allSettings = new ConcurrentDictionary<string, List<SettingInfo>>();
        }

        public Task<SettingInfo> GetSettingOrNullAsync(int? tenantId, long? userId, string name)
        {
            var settings = _allSettings[name];

            if (settings == null)
            {
                return Task.FromResult<SettingInfo>(null);
            }

            var value = settings.FirstOrDefault(s => s.TenantId == tenantId && s.UserId == userId);

            return Task.FromResult<SettingInfo>(value);
        }

        public Task DeleteAsync(SettingInfo setting)
        {
            var settingsTobeDelete = _allSettings[setting.Name]
                .Where(s => s.TenantId == setting.TenantId && s.UserId == setting.UserId);

            foreach (var delSetting in settingsTobeDelete)
            {
                _allSettings[setting.Name].Remove(delSetting);
            }

            if (!_allSettings[setting.Name].Any())
            {
                _allSettings.TryRemove(setting.Name, out var removedItems);
            }

            return Task.CompletedTask;
        }

        public Task CreateAsync(SettingInfo setting)
        {
            var existsSettings = _allSettings[setting.Name];
            if (existsSettings.Any())
            {
                _allSettings[setting.Name].Add(setting);
            }
            else
            {
                _allSettings.TryAdd(setting.Name, new List<SettingInfo>() { setting });
            }

            return Task.CompletedTask;

        }

        public Task UpdateAsync(SettingInfo setting)
        {
            if (_allSettings.ContainsKey(setting.Name))
            {
                var needUpdateSetting = _allSettings[setting.Name]
                    .FirstOrDefault(s => s.TenantId == setting.TenantId && s.UserId == setting.UserId);
                _allSettings[setting.Name].Remove(needUpdateSetting);
                _allSettings[setting.Name].Add(setting);
            }

            return Task.CompletedTask;
        }

        public Task<List<SettingInfo>> GetAllListAsync(int? tenantId, long? userId)
        {
            var allSettingInfos = new List<SettingInfo>();

            _allSettings.Values.AsParallel().ForAll((settings) =>
            {
                allSettingInfos.AddRange(settings.Where(s => s.TenantId == tenantId && s.UserId == userId));
            });

            return Task.FromResult(allSettingInfos);
        }
    }
}