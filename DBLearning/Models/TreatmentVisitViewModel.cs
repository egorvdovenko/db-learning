using System;
using System.Collections.Generic;

namespace DBLearning.Models
{
	public class TreatmentVisitViewModel
	{
        public int TreatmentVisitId { get; set; }
        public int? TreatmentSetId { get; set; }
        public DateTime? TreatmentVisitDate { get; set; }
        public TreatmentSetViewModel TreatmentSet { get; set; }
    }
}
