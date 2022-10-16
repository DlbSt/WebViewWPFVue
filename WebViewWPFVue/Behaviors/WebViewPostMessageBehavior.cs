using Microsoft.Web.WebView2.Wpf;
using Microsoft.Xaml.Behaviors;
using WebViewWPFVue.ViewModels;

namespace WebViewWPFVue.Behaviors
{
    public class WebViewPostMessageBehavior : Behavior<WebView2>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            var viewModel = (MainWindowViewModel)AssociatedObject.DataContext;
            viewModel.WebMessagePosted += ViewModel_WebMessagePosted;
        }

        private void ViewModel_WebMessagePosted(object sender, string e)
        {
            AssociatedObject.CoreWebView2.PostWebMessageAsJson(e);
        }

        protected override void OnDetaching()
        {
            var viewModel = (MainWindowViewModel)AssociatedObject.DataContext;
            viewModel.WebMessagePosted -= ViewModel_WebMessagePosted;

            base.OnDetaching();
        }
    }
}
