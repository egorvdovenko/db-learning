using System;
using System.Collections.Generic;

namespace DBLearning.Models
{
	public class AddPatientRequest
	{
		public string PatientSurname { get; set; }
		public string PatientName { get; set; }
		public string PatientSecondName { get; set; }
		public DateTime? Birthday { get; set; }
		public string Address { get; set; }
	}
}
