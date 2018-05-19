using System.Collections.Generic;
using PJATK.Models;

namespace PJATK.DataModels
{
    public class AppData
    {
        public StudentPersonalData StudentPersonalData { get; set; }
        public IList<ScheduleDataModel> StudentScheduleDataModels { get; set; }
        public PaymentsDataModel PaymentsDataModel { get; set; }
        public IList<GradesDataModel> GradesDataModels { get; set; }
    }
}
