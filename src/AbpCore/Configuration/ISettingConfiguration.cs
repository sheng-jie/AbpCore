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
}