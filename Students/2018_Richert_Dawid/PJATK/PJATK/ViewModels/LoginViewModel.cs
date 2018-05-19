using System.Threading.Tasks;
using PJATK.Services;
using PJATK.Utils;
using Xamarin.Forms;

namespace PJATK.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        
        public Command LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await OnLogin();
                });
            }
        }

        private async Task OnLogin()
        {
            WebService.Instance.SetUserCredentials(Login, Password);
            var result = await WebService.Instance.GetStudentPersonalData();

            if (result != null)
            {
                CredentialLocker.SaveUserCredentials(Login, Password);

                await CoreMethods.PushPageModel<SplashViewModel>(result);
            }
            else
            {
                await CoreMethods.DisplayAlert("Błąd logowania", "Niepoprawny login lub hasło.\nSpróbuj jeszcze raz.\n\nJeśli nie pamiętasz hasła,\nużyj opcji odzyskiwania hasła.", "Ok");
            }
        }
    }
}
