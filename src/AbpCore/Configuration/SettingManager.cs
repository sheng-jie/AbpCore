using System;
using System.Threading.Tasks;

namespace AbpCore.Configuration
{
    public class SettingManager : ISettingManager
    {
        public ISettingStore SettingStore { get; set; }

        private readonly ISettingDefinitionManager _settingDefinitionManager;

        public SettingManager(ISettingDefinitionManager settingDefinitionManager)
        {
            SettingStore = MemorySettingStore.Instance;
            _settingDefinitionManager = settingDefinitionManager;
        }

        public Task<string> GetSettingValueAsync(string name, int? tenantId, int? userId)
        {
            //1. Get the setting definition first by name.
            var settingDefinition = _settingDefinitionManager.GetSettingDefinition(name);

            if (settingDefinition == null)
            {
                throw new Exception("There is no setting defined for name: " + name);
            }

            var result = SettingStore.GetSettingOrNullAsync(tenantId, userId, name);

            var strVal = result.Result?.Value;

            if (result.Result == null)
            {
                strVal = settingDefinition.DefaultValue;
                SettingStore.CreateAsync(new SettingInfo(tenantId,userId,name,strVal));
            }

            return Task.FromResult(strVal);


        }

        public Task ChangeSettingsAsync(string name, string value, int? tenantId, int? userId)
        {
            var task = SettingStore.UpdateAsync(new SettingInfo(tenantId, userId, name, value));

            return Task.FromResult(task);
        }
    }
}