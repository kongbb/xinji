using CG.Common.Helpers;
using CG.Common.Utility;
using CG.Presentation.WebHost.Constants;
using Microsoft.Practices.Unity;
using NLog;

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
                    _configManager = UnityHelper.Current.Resolve<WebHostConfigurationManager>();
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