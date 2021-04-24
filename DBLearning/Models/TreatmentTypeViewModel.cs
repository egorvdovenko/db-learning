using System;
using System.Collections.Generic;

namespace DBLearning.Models
{
	public class TreatmentTypeViewModel
	{
        public int TreatmentTypeId { get; set; }
        public string TreatmentTypeName { get; set; }
        public string TreatmentTypeDescription { get; set; }
        public decimal? TreatmentPrice { get; set; }
        public List<TreatmentSetViewModel> TreatmentSets { get; set; }
    }
}
