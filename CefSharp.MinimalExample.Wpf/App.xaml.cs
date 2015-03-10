using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Linq;

namespace CefSharp.MinimalExample.Wpf
{
    public partial class App : Application
    {
        public App()
        {
          var settings = new CefSettings();

#if DEBUG
          settings.LogFile = @"c:\temp\ceflog.txt";
          settings.LogSeverity = LogSeverity.Verbose;
          settings.IgnoreCertificateErrors = true;
#endif
          CefCustomScheme mailtoScheme = new CefCustomScheme();
          mailtoScheme.SchemeName = "mailto";
          mailtoScheme.SchemeHandlerFactory = new SchemeHandlerFactory();

          CefCustomScheme filesScheme = new CefCustomScheme();
          mailtoScheme.SchemeName = "file";
          mailtoScheme.SchemeHandlerFactory = new SchemeHandlerFactory();

          settings.RegisterScheme(mailtoScheme);
          settings.RegisterScheme(filesScheme);

            Cef.Initialize(new CefSettings());
        }
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
//      private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
      #region Implementation of ISchemeHandler

      public bool ProcessRequestAsync(IRequest request, ISchemeHandlerResponse response, OnRequestCompletedHandler requestCompletedCallback)
      {
//        _log.DebugFormat("Processing url: {0}", request.Dump());

        var knownContentTypes = new[] { ".csv", ".xsls", ".xlsx", ".pdf", ".txt" };
        var ext = Path.GetExtension(request.Url);
        if (knownContentTypes.Contains(ext) || request.Url.Contains("mailto:"))       
        {
//          _log.DebugFormat("Starting process for: {0}", request.Url);
          Process.Start(request.Url);
          return false;
        }
        return true;
      }

      #endregion
    }
}
