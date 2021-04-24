using System;
using System.Collections.Generic;

namespace DBLearning.Models
{
	public class AddPatientTreatmentViewModel
	{
		public PatientViewModel Patient { get; set; }
		public List<DoctorViewModel> Doctors { get; set; }
		public List<TreatmentTypeViewModel> TreatmentTypes { get; set; }
	}
}
