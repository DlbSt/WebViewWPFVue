using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using Microsoft.Xaml.Behaviors;
using System.Threading.Tasks;
using System.Windows;

namespace WebViewWPFVue.Behaviors
{
    public class WebViewInitializationBehavior : Behavior<WebView2>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        private async void AssociatedObject_Loaded(object sender, RoutedEventArgs e) => await InitializeWebView();

        private async Task InitializeWebView()
        {
            await AssociatedObject.EnsureCoreWebView2Async();

            AssociatedObject.CoreWebView2.SetVirtualHostNameToFolderMapping(hostName: "vueapp", folderPath: "..\\..\\..\\..\\vueproject\\dist", accessKind: CoreWebView2HostResourceAccessKind.Allow);
            AssociatedObject.CoreWebView2.Navigate("https://vueapp/index.html");
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= AssociatedObject_Loaded;

            base.OnDetaching();
        }
    }
}
