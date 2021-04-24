using System;
using System.Collections.Generic;

namespace DBLearning.Tbls
{
    public partial class TblTreatmentType
    {
        public TblTreatmentType()
        {
            TblTreatmentSet = new HashSet<TblTreatmentSet>();
        }

        public int IntTreatmentTypeId { get; set; }
        public string TxtTreatmentTypeName { get; set; }
        public string TxtTreatmentTypeDescription { get; set; }
        public decimal? FltTreatmentPrice { get; set; }

        public virtual ICollection<TblTreatmentSet> TblTreatmentSet { get; set; }
    }
}
