using System;
using System.Collections.Generic;

namespace DBLearning.Tbls
{
    public partial class TblTreatmentVisit
    {
        public int IntTreatmentVisitId { get; set; }
        public int? IntTreatmentSetId { get; set; }
        public DateTime? DatTreatmentVisitDate { get; set; }

        public virtual TblTreatmentSet IntTreatmentSet { get; set; }
    }
}
