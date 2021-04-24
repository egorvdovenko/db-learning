using System;
using System.Collections.Generic;

namespace DBLearning.Models
{
	public class DoctorViewModel
	{
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string Specialist { get; set; }
        public DateTime? DoctorWork { get; set; }
        public List<TreatmentSetViewModel> TreatmentSets { get; set; }
    }
}
