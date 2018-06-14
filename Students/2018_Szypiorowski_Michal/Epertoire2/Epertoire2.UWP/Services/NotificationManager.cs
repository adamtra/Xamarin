using Epertoire2.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Xamarin.Forms;

[assembly: Dependency(typeof(Epertoire2.UWP.Services.NotificationManager))]
namespace Epertoire2.UWP.Services
{
    public class NotificationManager : INotificationManager
    {
        private Dictionary<string, ManualResetEvent> _events;
        private Dictionary<string, bool> _runnableActions;

        public NotificationManager()
        {
            _events = new Dictionary<string, ManualResetEvent>();
            _runnableActions = new Dictionary<string, bool>();
        }

        private string CreateToastVisual(string title, string content)
        {
            var visualXmlString =
            $@"<visual>
                <binding template='ToastGeneric'>
                    <text>{title}</text>
                    <text>{content}</text>
                </binding>
            </visual>";
            return visualXmlString;
        }

        private string CreateToastAction(string text)
        {
            var lower = text.ToLower();
            var arguments = $"action={lower}";
            var actionsXmlString =
                $@"<actions>
                    <action content='{text}'
                            arguments='{arguments}'
                            activationType='foreground'/>
                </actions>";
            return actionsXmlString;
        }

        private ToastNotification CreateToastNotification(string visualXmlString, string actionsXmlString, int expiration)
        {
            if (actionsXmlString == null)
            {
                actionsXmlString = String.Empty;
            }

            var toastXmlString =
                $@"<toast>
                    {visualXmlString}
                    {actionsXmlString}
                </toast>";

            var toastXml = new XmlDocument();
            toastXml.LoadXml(toastXmlString);
            var toast = new ToastNotification(toastXml)
            {
                ExpirationTime = DateTime.Now.AddMilliseconds(expiration)
            };

            return toast;
        }

        private ToastNotification CreateToastNotification(string visual, int expiration)
        {
            return CreateToastNotification(visual, null, expiration);
        }

        private void ToastActivated(ToastNotification sender, object e)
        {
            var tag = sender.Tag;
            var resetEvent = _events[tag];

            if (_runnableActions.ContainsKey(tag))
            {
                _runnableActions[tag] = true;
            }

            CreateToastNotifier("Done", "Done", 500);
            resetEvent.Set();
        }

        private void ToastDismissed(ToastNotification sender, ToastDismissedEventArgs e)
        {
            var tag = sender.Tag;
            var resetEvent = _events[tag];
            resetEvent.Set();
        }

        private void ToastFailed(ToastNotification sender, ToastFailedEventArgs e)
        {
            var tag = sender.Tag;
            var resetEvent = _events[tag];
            resetEvent.Set();
        }

        public void CreateToastNotifier(string title, string content, int expiration, string action, Action callback)
        {
            var actionString = action.ToLower();
            var resetEvent = new ManualResetEvent(false);

            _events.Add(actionString, resetEvent);
            _runnableActions.Add(actionString, false);

            var visualXmlString = CreateToastVisual(title, content);
            var actionsXmlString = CreateToastAction(action);
            var toast = CreateToastNotification(visualXmlString, actionsXmlString, expiration);

            toast.Activated += ToastActivated;
            toast.Dismissed += ToastDismissed;
            toast.Failed += ToastFailed;
            toast.Tag = actionString;

            ToastNotificationManager.CreateToastNotifier().Show(toast);

            resetEvent.WaitOne();

            if (_runnableActions[actionString])
            {
                callback();
            }

            _events.Remove(actionString);
            _runnableActions.Remove(actionString);
        }

        public void CreateToastNotifier(string title, string content, int expiration)
        {
            var visual = CreateToastVisual(title, content);
            var toast = CreateToastNotification(visual, expiration);

            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }
}
