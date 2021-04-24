using System;
using System.Collections.Generic;

namespace DBLearning.Tbls
{
    public partial class TblPatient
    {
        public TblPatient()
        {
            TblTreatmentSet = new HashSet<TblTreatmentSet>();
        }

        public int IntPatientId { get; set; }
        public string TxtPatientSurname { get; set; }
        public string TxtPatientName { get; set; }
        public string TxtPatientSecondName { get; set; }
        public DateTime? DatBirthday { get; set; }
        public string TxtAddress { get; set; }

        public virtual ICollection<TblTreatmentSet> TblTreatmentSet { get; set; }
    }
}
