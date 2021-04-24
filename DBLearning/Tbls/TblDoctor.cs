using System;
using System.Collections.Generic;

namespace DBLearning.Tbls
{
    public partial class TblDoctor
    {
        public TblDoctor()
        {
            TblTreatmentSet = new HashSet<TblTreatmentSet>();
        }

        public int IntDoctorId { get; set; }
        public string TxtDoctorName { get; set; }
        public string TxtSpecialist { get; set; }
        public DateTime? DatDoctorWork { get; set; }

        public virtual ICollection<TblTreatmentSet> TblTreatmentSet { get; set; }
    }
}
