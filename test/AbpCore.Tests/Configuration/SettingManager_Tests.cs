using AbpCore.Collections;
using AbpCore.Configuration;
using Moq;
using Shouldly;
using Xunit;

namespace AbpCore.Tests.Configuration
{
    public class SettingManager_Tests
    {
        [Fact]
        public void Should_Get_Default_Value()
        {
            var fakeSettingConfiguration = new Mock<ISettingConfiguration>();
            fakeSettingConfiguration.Setup(x => x.Providers).Returns(new TypeList<SettingProvider>());

            fakeSettingConfiguration.Object.Providers.Add<TestSettingProvider>();

            var fakeSettingDefinitionManager = new SettingDefinitonManager(fakeSettingConfiguration.Object);

            fakeSettingDefinitionManager.Initialize();

            var settingManager = new SettingManager(fakeSettingDefinitionManager);

            var value = settingManager.GetSettingValueAsync("EmailSettingNames.DefaultFromAddress", null, null);
            value.Result.ShouldBe("admin@mydomain.com");
        }

        [Fact]
        public void Should_Change_Setting()
        {
            var fakeSettingConfiguration = new Mock<ISettingConfiguration>();
            fakeSettingConfiguration.Setup(x => x.Providers).Returns(new TypeList<SettingProvider>());

            fakeSettingConfiguration.Object.Providers.Add<TestSettingProvider>();

            var fakeSettingDefinitionManager = new SettingDefinitonManager(fakeSettingConfiguration.Object);

            fakeSettingDefinitionManager.Initialize();

            var settingManager = new SettingManager(fakeSettingDefinitionManager);
            settingManager.GetSettingValueAsync("EmailSettingNames.DefaultFromAddress", null, null);
            settingManager.ChangeSettingsAsync("EmailSettingNames.DefaultFromAddress", "test@abp.com", null, null);

            var changedResult = settingManager.GetSettingValueAsync("EmailSettingNames.DefaultFromAddress", null, null);

            changedResult.Result.ShouldBe("test@abp.com");
        }
    }
}
