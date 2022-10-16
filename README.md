# WebViewWPFVue
Project showing possible interaction between Vue.JS web app and WPF app (using WebView2).

## Setup
There is no need to start vue app independently, since there is webview2 api used. If the app is not started via WPF app, there will be an error in web console.

You have to first build the web app, using following commands (e.g. in vs code terminal).
```sh
npm install
npm run build
```

Then locate the dist folder and host it to local web server (XAMPP for example).

Go to [MainWindow.xaml](https://github.com/DlbSt/WebViewWPFVue/blob/main/WebViewWPFVue/Views/MainWindow.xaml) in WPF project and change the source IP address of webview. Then build the WPF project and you can try the functionality.

## Projects
Repo consists of two project - WPF app (WebViewWPFVue folder) and Vue app (vueproject folder). These two apps communicate between each other via WebView2 API. They just simply exchange JSON. In Vue app, all the logic is in [App.vue](https://github.com/DlbSt/WebViewWPFVue/blob/main/vueproject/src/App.vue). In WPF app you can see the main logic in [MainWindow.xaml](https://github.com/DlbSt/WebViewWPFVue/blob/main/WebViewWPFVue/Views/MainWindow.xaml), where the WebView is declared, in [MainWindowViewModel.cs](https://github.com/DlbSt/WebViewWPFVue/blob/main/WebViewWPFVue/ViewModels/MainWindowViewModel.cs) and in [WebViewPostMessageBehavior.cs](https://github.com/DlbSt/WebViewWPFVue/blob/main/WebViewWPFVue/Behaviors/WebViewPostMessageBehavior.cs).
