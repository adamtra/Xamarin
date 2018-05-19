using System.Collections.Generic;
using PJATK.DataModels;

namespace PJATK.ViewModels
{
    public class GradesViewModel : BaseViewModel
    {
        public IList<GradesDataModel> GradesDataModels { get; set; }
        
        public override void Init(object initData)
        {
            base.Init(initData);
            
            if (initData is IList<GradesDataModel> gradesDataModels)
            {
                GradesDataModels = gradesDataModels;
            }
        }
    }
}
