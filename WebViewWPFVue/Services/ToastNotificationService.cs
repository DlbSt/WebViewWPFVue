using Microsoft.Toolkit.Uwp.Notifications;

namespace WebViewWPFVue.Services
{
    public class ToastNotificationService : IToastNotificationService
    {
        public void ShowNotification(string text)
        {
            new ToastContentBuilder().AddText("Message from Vue JS!")
                                     .AddText(text)
                                     .Show();
        }
    }

    #region Interface
    public interface IToastNotificationService
    {
        #region Methods
        void ShowNotification(string text); 
        #endregion
    }
    #endregion
}
