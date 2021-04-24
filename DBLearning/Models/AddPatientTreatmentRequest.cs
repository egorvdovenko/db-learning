using System;
using System.Collections.Generic;

namespace DBLearning.Models
{
	public class AddPatientTreatmentRequest
	{
		public int? PatientId { get; set; }
		public int? TreatmentTypeId { get; set; }
		public int? DoctorId { get; set; }
		public DateTime? DateBegin { get; set; }
		public DateTime? DateEnd { get; set; }
		public int? TreatmentSetCount { get; set; }
		public string TreatmentSetRoom { get; set; }
	}
}
