using System;
using System.Diagnostics;

namespace CefSharp.MinimalExample.Wpf.Handlers
{
  class LocalRequestHandler : IRequestHandler
  {
    #region Implementation of IRequestHandler

    public bool OnBeforeBrowse(IWebBrowser browser, IRequest request, bool isRedirect)
    {
      return false;
    }

    public bool OnCertificateError(IWebBrowser browser, CefErrorCode errorCode, string requestUrl)
    {
      return false;
    }

    public void OnPluginCrashed(IWebBrowser browser, string pluginPath)
    {
      throw new NotImplementedException();
    }

    public bool OnBeforeResourceLoad(IWebBrowser browser, IRequest request, IResponse response)
    {

      string loweredUrl = request.Url.ToLower();
      if (loweredUrl.EndsWith(".htm") || loweredUrl.EndsWith(".html"))
        return false;

      Process.Start(request.Url);
      //if (loweredUrl.EndsWith(".pdf"))
      //  return new ResourceHandler("application/pdf");
      //return null;

      //if (request.Url.ToLower().EndsWith(".pdf"))
      //{
      //  Process.Start(request.Url);
      //  return true;
      //}
      return true;
    }

    public bool GetAuthCredentials(IWebBrowser browser, bool isProxy, string host, int port, string realm, string scheme, ref string username, ref string password)
    {
      return false;
    }

    public bool OnBeforePluginLoad(IWebBrowser browser, string url, string policyUrl, IWebPluginInfo info)
    {
      return false;
    }

    public void OnRenderProcessTerminated(IWebBrowser browser, CefTerminationStatus status)
    {
      return;
      
    }

    #endregion
  }
}
