using System;
using Plugin.SecureStorage;

namespace PJATK.Utils
{
    public static class CredentialLocker
    {
        private const string UserLoginResourceName = "UserLogin";
        private const string UserPasswordResourceName = "UserPassword";
        private const string PinCodeResourceName = "PinCode";

        public static PasswordCredential GetUserCredentials()
        {
            if (CrossSecureStorage.Current.HasKey(UserLoginResourceName) && CrossSecureStorage.Current.HasKey(UserPasswordResourceName))
            {
                return new PasswordCredential
                {
                    UserName = CrossSecureStorage.Current.GetValue(UserLoginResourceName),
                    Password = CrossSecureStorage.Current.GetValue(UserPasswordResourceName)
                };
            }

            return null;
        }

        public static string GetPinCode()
        {
            if (CrossSecureStorage.Current.HasKey(PinCodeResourceName))
            {
                return CrossSecureStorage.Current.GetValue(PinCodeResourceName);
            }
            return null;
        }

        public static void SaveUserCredentials(string username, string password)
        {
            RemoveUserCredentials();
            CrossSecureStorage.Current.SetValue(UserLoginResourceName, username);
            CrossSecureStorage.Current.SetValue(UserPasswordResourceName, password);
        }

        public static void SavePinCode(string pin)
        {
            RemovePinCode();
            CrossSecureStorage.Current.SetValue(PinCodeResourceName, pin);
        }

        public static void RemoveUserCredentials()
        {
            var currentUserCredentials = GetUserCredentials();
            if (currentUserCredentials != null)
            {
                CrossSecureStorage.Current.DeleteKey(UserLoginResourceName);
                CrossSecureStorage.Current.DeleteKey(UserPasswordResourceName);
            }
            RemovePinCode();
        }

        public static void RemovePinCode()
        {
            var currentPinCode = GetPinCode();
            if (currentPinCode != null)
            {
                CrossSecureStorage.Current.DeleteKey(PinCodeResourceName);
            }
        }
    }
}
