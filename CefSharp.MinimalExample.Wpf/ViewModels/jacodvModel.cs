using CefSharp.MinimalExample.Wpf.Mvvm;
using CefSharp.Wpf;
using System.ComponentModel;
using System.Windows;

namespace CefSharp.MinimalExample.Wpf.ViewModels
{
  public class jacodvModel
  {
    public event PropertyChangedEventHandler PropertyChanged;

    private IWpfWebBrowser webBrowser;
    public IWpfWebBrowser WebBrowser
    {
      get { return webBrowser; }
      set { PropertyChanged.ChangeAndNotify(ref webBrowser, value, () => WebBrowser); }
    }

    private string title;
    public string Title
    {
      get { return title; }
      set { PropertyChanged.ChangeAndNotify(ref title, value, () => Title); }
    }

    private string _source;
    public string Source
    {
      get { return _source; }
      set { PropertyChanged.ChangeAndNotify(ref _source, value, () => Source); }
    }


    public jacodvModel()
    {
      PropertyChanged += OnPropertyChanged;
    }

    private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      if (e.PropertyName == "Title")
      {
        Application.Current.MainWindow.Title = "CefSharp.MinimalExample.Wpf - " + Title;
      }
    }
  }
}
