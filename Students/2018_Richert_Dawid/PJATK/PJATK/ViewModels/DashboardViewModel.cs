using System;
using PJATK.DataModels;
using PJATK.Utils;
using Xamarin.Forms;

namespace PJATK.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private AppData _appData;
        public string UserName { get; set; }
        
        public override void Init(object initData)
        {
            base.Init(initData);

            if (initData is AppData appData)
            {
                _appData = appData;
                UserName = appData.StudentPersonalData.Imie;
            }
        }

        public Command QuickLinkCommand
        {
            get
            {
                return new Command(parameter =>
                {
                    Device.OpenUri(new Uri(parameter.ToString()));
                });
            }
        }
        
        public Command PaymentsCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await CoreMethods.PushPageModel<PaymentsViewModel>(_appData.PaymentsDataModel);
                });
            }
        }

        public Command GradesCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await CoreMethods.PushPageModel<GradesViewModel>(_appData.GradesDataModels);
                });
            }
        }

        public Command LogoutCommand
        {
            get
            {
                return new Command(async () =>
                {
                    CredentialLocker.RemoveUserCredentials();
                    await CoreMethods.PushPageModel<LoginViewModel>();
                    CoreMethods.RemoveFromNavigation();
                });
            }
        }
    }
}
