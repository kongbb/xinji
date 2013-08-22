using CG.Common.Utility;
using CG.Presentation.WebHost.Constants;
using Microsoft.Practices.Unity;

namespace CG.Presentation.WebHost.Helper
{
    public class WebHostConfigurationManager
    {
        [Dependency]
        public IConfig Config { get; set; }

        private static WebHostConfigurationManager _configManager;

        public static WebHostConfigurationManager Current
        {
            get
            {
                if (_configManager == null)
                {
                    _configManager = UnityHelper.Container.Resolve<WebHostConfigurationManager>();
                }

                return _configManager;
            }
        }

        public string GetApiDomainUrl
        {
            get { return Config.GetString(ConfigNames.ApiDomainUrl); }
        }
    }
}