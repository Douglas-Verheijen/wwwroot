using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Configuration;
using System.IO;
using System.Linq;

namespace Liquid.Home.UI.Configuration
{
    public class EnvironmentConfiguration
    {
        private const string _defaultFilename = "Environment.Unity.config";
        private const string _localFilename = "Environment.Local.Unity.config";
        private static volatile IUnityContainer _configurationContainer;
        private static object _syncRoot = new object();

        public static void Initialize()
        {
            lock (_syncRoot)
            {
                _configurationContainer = new UnityContainer();
                ConfigurationSections(_configurationContainer, _defaultFilename);
                ConfigurationSections(_configurationContainer, _localFilename);
            }
        }

        private static void ConfigurationSections(IUnityContainer container, string filename)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename);
            var fileMap = new ExeConfigurationFileMap() { ExeConfigFilename = path };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            foreach (var section in configuration.Sections.OfType<UnityConfigurationSection>())
                section.Configure(container);
        }

        public static IEmailConfiguration Email
        {
            get
            {
                var emailConfiguration = _configurationContainer.Resolve<IEmailConfiguration>();
                return emailConfiguration;
            }
        }
    }
}