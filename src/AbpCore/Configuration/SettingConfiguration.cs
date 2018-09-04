using AbpCore.Collections;

namespace AbpCore.Configuration
{
    public class SettingConfiguration : ISettingConfiguration
    {
        public ITypeList<SettingProvider> Providers { get; private set; }

        public SettingConfiguration()
        {
            Providers = new TypeList<SettingProvider>();
        }
    }
}