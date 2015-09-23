using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace MyBackgroundTask
{
    public sealed class TimeZoneTask: IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            var toastNotifier = ToastNotificationManager.CreateToastNotifier();
            var toastxml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText01);
            var toastText = toastxml.GetElementsByTagName("text");
            (toastText[0] as XmlElement).InnerText = "Hello from Background Task";
            var toast = new ToastNotification(toastxml);
            toastNotifier.Show(toast);
        }
    }
}
