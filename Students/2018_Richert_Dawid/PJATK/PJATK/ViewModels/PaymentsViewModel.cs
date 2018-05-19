using PJATK.DataModels;

namespace PJATK.ViewModels
{
    public class PaymentsViewModel : BaseViewModel
    {
        public PaymentsDataModel PaymentsDataModel { get; set; }
        
        public override void Init(object initData)
        {
            base.Init(initData);

            if (initData is PaymentsDataModel paymentsDataModel)
            {
                PaymentsDataModel = paymentsDataModel;
            }
        }
    }
}
