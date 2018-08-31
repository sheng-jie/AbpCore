using System.Collections.Generic;

namespace AbpCore.Configuration
{
    /// <summary>
    /// 设置定义管理器
    /// </summary>
    public interface ISettingDefinitionManager
    {
        /// <summary>
        /// Get the <see cref="SettingDefinition"/> object with the unique name.
        /// </summary>
        /// <param name="name">Unique name of the Setting</param>
        /// <returns>The <see cref="SettingDefinition"/>object.</returns>
        SettingDefinition GetSettingDefinition(string name);

        /// <summary>
        /// Get a list of all setting definitions.
        /// </summary>
        /// <returns>All Settings</returns>
        IEnumerable<SettingDefinition> GetAllSettingDefinitions();
    }
}
