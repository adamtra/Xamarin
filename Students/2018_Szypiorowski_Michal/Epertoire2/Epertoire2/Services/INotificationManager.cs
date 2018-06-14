using System;

namespace Epertoire2.Services
{
    public interface INotificationManager
    {
        void CreateToastNotifier(string title, string content, int expiration, string action, Action callback);
        void CreateToastNotifier(string title, string content, int expiration);
    }
}
