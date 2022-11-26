using Microsoft.Toolkit.Uwp.Notifications;
using Microsoft.Web.WebView2.Core;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows;
using WebViewWPFVue.Helpers;

namespace WebViewWPFVue.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await webView.EnsureCoreWebView2Async();

            webView.CoreWebView2.SetVirtualHostNameToFolderMapping(hostName: "vueapp", folderPath: "..\\..\\..\\..\\vueproject\\dist", accessKind: CoreWebView2HostResourceAccessKind.Allow);
            webView.CoreWebView2.Navigate("https://vueapp/index.html");
        }
    }
}
