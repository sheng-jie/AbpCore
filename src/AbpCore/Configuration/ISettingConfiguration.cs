using System.Collections.Generic;
using AbpCore.Collections;

namespace AbpCore.Configuration
{
    /// <summary>
    /// 用于提供入口去注入设置提供者类型
    /// </summary>
    public interface ISettingConfiguration
    {
        ITypeList<SettingProvider> Providers { get; } 
    }

    public class SettingConfiguration : ISettingConfiguration
    {
        public ITypeList<SettingProvider> Providers { get; private set; }

        public SettingConfiguration()
        {
            Providers = new TypeList<SettingProvider>();
        }
    }

    /// <summary>
    /// 设置提供者，用来返回具体的配置项列表。
    /// </summary>
    public abstract class SettingProvider
    {
        public abstract IEnumerable<SettingDefinition> GetSettingDefinitions();
    }
}