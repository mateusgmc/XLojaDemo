using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace XLojaDemo.App.Helpers
{
    public class Settings
    {
        static ISettings AppSettings => CrossSettings.Current;

        private static Settings _instance;
        public static Settings Current => _instance ?? (_instance = new Settings());

        private Settings()
        {
        }

        readonly string HostUriDefault = "http://192.168.0.101";
        public string HostUri
        {
            get { return AppSettings.GetValueOrDefault(nameof(HostUri), HostUriDefault); }
            set { AppSettings.AddOrUpdateValue(nameof(HostUri), value); }
        }
    }
}
