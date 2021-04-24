using System;
using System.Collections.Generic;

namespace DBLearning.Models
{
	public class PatientTreatmentsViewModel
	{
		public PatientViewModel Patient { get; set; }
		public List<TreatmentSetViewModel> TreatmentSets { get; set; }
	}
}
