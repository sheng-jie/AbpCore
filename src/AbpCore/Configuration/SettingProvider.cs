using System.Collections.Generic;

namespace AbpCore.Configuration
{
    /// <summary>
    /// 设置提供者，用来返回具体的配置项列表。
    /// </summary>
    public abstract class SettingProvider
    {
        public abstract IEnumerable<SettingDefinition> GetSettingDefinitions();
    }
}