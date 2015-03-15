using System.Diagnostics;
using System.Reflection;
using System.Windows;

namespace CefSharp.MinimalExample.Wpf
{
  public partial class App : Application
  {
    public App()
    {
    }

    #region Overrides of Application

    protected override void OnStartup(StartupEventArgs e)
    {
      base.OnStartup(e);
      var settings = new CefSettings();

#if DEBUG
      settings.LogFile = @"c:\temp\ceflog.txt";
      settings.LogSeverity = LogSeverity.Verbose;
      settings.IgnoreCertificateErrors = true;
#endif
      CefCustomScheme mailtoScheme = new CefCustomScheme();
      mailtoScheme.SchemeName = "mailto";
      mailtoScheme.SchemeHandlerFactory = new SchemeHandlerFactory();

      settings.RegisterScheme(mailtoScheme);

      Cef.Initialize(settings);
    }

    #region Overrides of Application

    protected override void OnExit(ExitEventArgs e)
    {
      try { Cef.Shutdown(); }
      catch { }
      
      base.OnExit(e);
    }

    #endregion

    #endregion
  }

  public class SchemeHandlerFactory : ISchemeHandlerFactory
  {
    #region Implementation of ISchemeHandlerFactory

    public ISchemeHandler Create()
    {
      return new CustomSchemeHandler();
    }

    #endregion
  }

  public class CustomSchemeHandler : ISchemeHandler
  {
    #region Implementation of ISchemeHandler
    public bool ProcessRequestAsync(IRequest request, ISchemeHandlerResponse response, OnRequestCompletedHandler requestCompletedCallback)
    {
      Process.Start(request.Url);
      return false;
    }
    #endregion
  }
}
