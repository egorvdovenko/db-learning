using System;
using System.Collections.Generic;

namespace DBLearning.Models
{
	public class RoomsScheduleReportViewModel
    {
        public string TreatmentSetRoom { get; set; }
        public List<TreatmentSetViewModel> TreatmentSets { get; set; }
    }
}
