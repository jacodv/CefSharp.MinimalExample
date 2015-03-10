using System;
using System.IO;
using System.Windows;
using CefSharp.MinimalExample.Wpf.ViewModels;

namespace CefSharp.MinimalExample.Wpf
{
  /// <summary>
  /// Interaction logic for jacodvStart.xaml
  /// </summary>
  public partial class jacodvStart : Window
  {
    public jacodvStart()
    {
      InitializeComponent();

      var path = "file:///" + Path.Combine(Environment.CurrentDirectory, "SampleFiles\\Index.htm").Replace(@"\", "/");
     
      DataContext = new jacodvModel()
      {
        Title = "Sample Page",
        Source = path
      };

      WebBrowserCtl.Source = new Uri(path);
    }
  }
}
