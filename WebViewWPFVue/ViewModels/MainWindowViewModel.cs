using Microsoft.Web.WebView2.Core;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Text.Json;
using System.Windows.Markup;
using WebViewWPFVue.Helpers;
using WebViewWPFVue.Services;

namespace WebViewWPFVue.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        #region Fields
        private JsonSerializerOptions serializerOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        }; 
        #endregion

        #region Properties
        private string _title = "WPF WebView App";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        #endregion

        #region Commands
        public DelegateCommand<CoreWebView2WebMessageReceivedEventArgs> OnWebMessageReceivedCommand { get; set; }
        #endregion

        #region Services
        private readonly IToastNotificationService _toastNotificationService;
        private readonly ICommandLineService _commandLineService;
        #endregion

        #region Events
        public event EventHandler<string> WebMessagePosted;
        #endregion

        #region Constructor
        public MainWindowViewModel(IToastNotificationService toastNotificationService,
                                   ICommandLineService commandLineService)
        {
            #region Services
            _toastNotificationService = toastNotificationService;
            _commandLineService = commandLineService;
            #endregion

            #region Commands
            OnWebMessageReceivedCommand = new DelegateCommand<CoreWebView2WebMessageReceivedEventArgs>(WebMessageReceived);
            #endregion
        }
        #endregion

        private void WebMessageReceived(CoreWebView2WebMessageReceivedEventArgs e)
        {
            var message = JsonSerializer.Deserialize<WebViewMessage>(e.WebMessageAsJson, serializerOptions);

            if (message.Type == "request")
            {
                var data = _commandLineService.GetComputerInfo();

                WebMessagePosted?.Invoke(this, JsonSerializer.Serialize<ComputerInfoMessage>(data, serializerOptions));
            }
            else
            {
                _toastNotificationService.ShowNotification(message.Text);
            }
        }
    }
}
