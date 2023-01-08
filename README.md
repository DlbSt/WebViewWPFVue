# WebViewWPFVue

Project showing possible interaction between Vue.JS web app and WPF app (using WebView2).

## Setup

There is no need to start vue app independently, since there is webview2 api used. If the app is not started via WPF app, there will be an error in web console.

You have to first build the web app, using following commands (e.g. in vs code terminal).

```sh
npm install
npm run build
```

The app should be build and dist folder should be correctly mapped in WebView. Then build the WPF project and you can try the functionality. If the Vue app is not loaded, go to [WebViewInitializationBehavior](https://github.com/DlbSt/WebViewWPFVue/blob/main/WebViewWPFVue/Behaviors/WebViewInitializationBehavior.cs) in WPF project and change the folder path of virtual host.

## Projects

Repo consists of two project - WPF app (WebViewWPFVue folder) and Vue app (vueproject folder). These two apps communicate between each other via WebView2 API. They just simply exchange JSON. In Vue app, you can find the Toast Notification component in [ToastNotification.vue](https://github.com/DlbSt/WebViewWPFVue/blob/main/vueproject/src/components/ToastNotification.vue) and the Computer Info component in [ComputerInfo.vue](https://github.com/DlbSt/WebViewWPFVue/blob/main/vueproject/src/components/ComputerInfo.vue). In WPF app you can see the main logic in [MainWindow.xaml](https://github.com/DlbSt/WebViewWPFVue/blob/main/WebViewWPFVue/Views/MainWindow.xaml), where the WebView is declared, in [MainWindowViewModel.cs](https://github.com/DlbSt/WebViewWPFVue/blob/main/WebViewWPFVue/ViewModels/MainWindowViewModel.cs) and in [WebViewPostMessageBehavior.cs](https://github.com/DlbSt/WebViewWPFVue/blob/main/WebViewWPFVue/Behaviors/WebViewPostMessageBehavior.cs). The WebView initialization was put to [WebViewInitializationBehavior](https://github.com/DlbSt/WebViewWPFVue/blob/main/WebViewWPFVue/Behaviors/WebViewInitializationBehavior.cs).
