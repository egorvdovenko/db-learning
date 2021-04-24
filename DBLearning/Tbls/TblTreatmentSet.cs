using System;
using System.Collections.Generic;

namespace DBLearning.Tbls
{
    public partial class TblTreatmentSet
    {
        public TblTreatmentSet()
        {
            TblTreatmentVisit = new HashSet<TblTreatmentVisit>();
        }

        public int IntTreatmentSetId { get; set; }
        public int? IntDoctorId { get; set; }
        public int? IntPatientId { get; set; }
        public DateTime? DatDateBegin { get; set; }
        public DateTime? DatDateEnd { get; set; }
        public string TxtTreatmentSetRoom { get; set; }
        public int? IntTreatmentSetCount { get; set; }
        public int? IntTreatmentSetCountFact { get; set; }
        public int? IntTreatmentTypeId { get; set; }

        public virtual TblDoctor IntDoctor { get; set; }
        public virtual TblPatient IntPatient { get; set; }
        public virtual TblTreatmentType IntTreatmentType { get; set; }
        public virtual ICollection<TblTreatmentVisit> TblTreatmentVisit { get; set; }
    }
}
