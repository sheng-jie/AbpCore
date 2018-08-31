using System;
using System.Collections.Generic;

namespace AbpCore.Configuration
{
    public class SettingDefinitonManager : ISettingDefinitionManager
    {
        private readonly ISettingConfiguration _settingConfiguration;
        private readonly IDictionary<string, SettingDefinition> _settings;

        public SettingDefinitonManager(ISettingConfiguration settingConfiguration)
        {
            _settingConfiguration = settingConfiguration;
            _settings = new Dictionary<string, SettingDefinition>();
        }

        /// <summary>
        /// 初始化（加载系统定义的所有设置项）
        /// </summary>
        public void Initialize()
        {
            foreach (var providerType in _settingConfiguration.Providers)
            {
                if (Activator.CreateInstance(providerType) is SettingProvider provider)
                    foreach (var setting in provider.GetSettingDefinitions())
                    {
                        _settings[setting.Name] = setting;
                    }
            }
        }

        /// <summary>
        /// 根据设置项的名称获取设置定义
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public SettingDefinition GetSettingDefinition(string name)
        {
            if (!_settings.TryGetValue(name, out var settingDefinition))
            {
                throw new Exception("There is no setting defined with name: " + name);
            }

            return settingDefinition;
        }

        /// <summary>
        /// 获取所有的设置定义
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SettingDefinition> GetAllSettingDefinitions()
        {
            return _settings.Values;
        }
    }
}