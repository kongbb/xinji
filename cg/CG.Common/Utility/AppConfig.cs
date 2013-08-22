using System.Configuration;

namespace CG.Common.Utility
{
    public class AppConfig : IConfig
    {
        public int GetInt(string name)
        {
            int temp;
            if (!int.TryParse(ConfigurationManager.AppSettings[name], out temp))
            {
                return 0;
            }

            return temp;
        }

        public string GetString(string name)
        {
            return ConfigurationManager.AppSettings[name];
        }
    }
}
