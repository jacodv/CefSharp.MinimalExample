using System.Collections.Generic;
using System.Diagnostics;

namespace CefSharp.MinimalExample.Wpf.Handlers
{
  public class LocalResourceHandler : IResourceHandler
  {
    private Dictionary<string, ResourceHandler> _handlers; 
    
    #region Implementation of IResourceHandler

    public void RegisterHandler(string url, ResourceHandler handler)
    {
      if(_handlers==null)
        _handlers=new Dictionary<string, ResourceHandler>();
      
      _handlers.Add(url,handler);
    }

    public void UnregisterHandler(string url)
    {
      if (_handlers != null && _handlers.ContainsKey(url))
        _handlers.Remove(url);
    }

    public ResourceHandler GetResourceHandler(IWebBrowser browser, IRequest request)
    {
      string loweredUrl = request.Url.ToLower();
      if (loweredUrl.EndsWith(".htm") || loweredUrl.EndsWith(".html"))
        return null;

      Process.Start(request.Url);
      if (loweredUrl.EndsWith(".pdf"))
        return new ResourceHandler("application/pdf");
      return null;
    }

    #endregion
  }
}
