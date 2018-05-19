using System;
using System.Linq;
using PJATK.DataModels;
using PJATK.Models;
using PJATK.Services;
using PJATK.Utils;

namespace PJATK.ViewModels
{
    public class SplashViewModel : BaseViewModel
    {
        private object _initData;

        protected override async void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            var currentUserCredentials = CredentialLocker.GetUserCredentials();
            if (currentUserCredentials == null)
            {
                await CoreMethods.PushPageModel<LoginViewModel>();
                CoreMethods.RemoveFromNavigation();
            }
            else
            {
                var appData = new AppData();
                if (_initData is StudentPersonalData studentPersonalData)
                {
                    appData.StudentPersonalData = studentPersonalData;
                }
                else
                {
                    appData.StudentPersonalData = await WebService.Instance.GetStudentPersonalData();
                }

                appData.GradesDataModels = appData.StudentPersonalData.Oceny
                    .GroupBy(x => x.Semestr)
                    .OrderByDescending(x => x.Key)
                    .Select(group => new GradesDataModel
                    {
                        Name = group.Key,
                        Grades = group.ToList()
                    }).ToList();

                appData.PaymentsDataModel = new PaymentsDataModel
                {
                    Konto_wplat = appData.StudentPersonalData.Konto_wplat,
                    Konto_wyplat = appData.StudentPersonalData.Konto_wyplat,
                    Kwota_naleznosci = appData.StudentPersonalData.Kwota_naleznosci,
                    Kwota_wplat = appData.StudentPersonalData.Kwota_wplat,
                    Kwota_wyplat = appData.StudentPersonalData.Kwota_wyplat,
                    Saldo = appData.StudentPersonalData.Saldo,
                    Oplaty = appData.StudentPersonalData.Oplaty.OrderByDescending(x => x.TerminPlatnosci).ToList(),
                    Platnosci = appData.StudentPersonalData.Platnosci.OrderByDescending(x => x.DataWplaty).ToList()
                };

                var today = DateTime.Today;
                var studentSchedules = await WebService.Instance.GetStudentSchedules(today, today.AddMonths(1));
                appData.StudentScheduleDataModels = studentSchedules
                    .GroupBy(x => x.Data_roz.Date)
                    .OrderBy(x => x.Key)
                    .Select(group => new ScheduleDataModel
                    {
                        Date = group.Key,
                        StudentSchedules = group.ToList()
                    }).ToList();

                await CoreMethods.PushPageModel<DashboardViewModel>(appData);
                CoreMethods.RemoveFromNavigation();
            }
        }

        public override void Init(object initData)
        {
            base.Init(initData);

            _initData = initData;
        }
    }
}
