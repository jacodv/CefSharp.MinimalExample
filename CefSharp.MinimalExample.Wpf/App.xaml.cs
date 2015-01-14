using System.Windows;

namespace CefSharp.MinimalExample.Wpf
{
    public partial class App : Application
    {
        public App()
        {
            var settings = new CefSettings();

            settings.CefCommandLineArgs.Add("high-dpi-support", "1");
            //NOTE: Might be worth tinkering with this value
            //settings.CefCommandLineArgs.Add("force-device-scale-factor", "1");
            Cef.Initialize(settings);
        }
    }
}
