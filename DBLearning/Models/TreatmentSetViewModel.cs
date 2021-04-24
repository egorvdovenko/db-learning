using System;
using System.Collections.Generic;

namespace DBLearning.Models
{
	public class TreatmentSetViewModel
	{
        public int TreatmentSetId { get; set; }
        public int? DoctorId { get; set; }
        public int? PatientId { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public string TreatmentSetRoom { get; set; }
        public int? TreatmentSetCount { get; set; }
        public int? TreatmentSetCountFact { get; set; }
        public int? TreatmentTypeId { get; set; }

        public DoctorViewModel Doctor { get; set; }
        public PatientViewModel Patient { get; set; }
        public TreatmentTypeViewModel TreatmentType { get; set; }
        public List<TreatmentVisitViewModel> TreatmentVisits { get; set; }
    }
}
