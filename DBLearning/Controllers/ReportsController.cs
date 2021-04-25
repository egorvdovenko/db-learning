using Microsoft.AspNetCore.Mvc;
using System.Linq;
using DBLearning.Models;

namespace DBLearning.Controllers
{
	public class ReportsController : Controller
	{
		Db222zisContext db;

		public ReportsController(Db222zisContext context)
		{
			db = context;
		}

		[HttpGet]
		public IActionResult Index()
		{
			var doctors = db.TblDoctor
				.Select(d => new DoctorViewModel
				{
					DoctorId = d.IntDoctorId,
					DoctorName = d.TxtDoctorName
				})
				.ToList();

			var viewModel = new ReportsIndexViewModel
			{
				Doctors = doctors
			};

			return View(viewModel);
		}

		[HttpGet]
		public IActionResult RoomsScheduleReport()
		{
			var treatmentSets = db.TblTreatmentSet
				.Select(ts => new TreatmentSetViewModel
				{
					TreatmentSetRoom = ts.TxtTreatmentSetRoom,
					TreatmentVisits = db.TblTreatmentVisit
						.Where(tv => tv.IntTreatmentSetId == ts.IntTreatmentSetId)
						.Select(tv => new TreatmentVisitViewModel
						{
							TreatmentVisitDate = tv.DatTreatmentVisitDate
						})
						.ToList(),
					Patient = db.TblPatient
						.Where(p => p.IntPatientId == ts.IntPatientId)
						.Select(p => new PatientViewModel
						{
							PatientName = p.TxtPatientName,
							PatientSecondName = p.TxtPatientSecondName,
							PatientSurname = p.TxtPatientSurname
						})
						.FirstOrDefault(),
					TreatmentType = db.TblTreatmentType
						.Where(tt => tt.IntTreatmentTypeId == ts.IntTreatmentTypeId)
						.Select(tt => new TreatmentTypeViewModel
						{
							TreatmentTypeName = tt.TxtTreatmentTypeName,
						})
						.FirstOrDefault()
				})
				.ToList();

			var viewModel = treatmentSets
				.GroupBy(ts => ts.TreatmentSetRoom)
				.Select(g => new RoomsScheduleReportViewModel
				{
					TreatmentSetRoom = g.Key,
					TreatmentSets = g
						.Select(ts => ts)
						.ToList()
				})
				.ToList();

			return View(viewModel);
		}

		[HttpGet]
		public IActionResult PatientsReport()
		{
			var viewModel = db.TblPatient
				.Select(p => new PatientViewModel
				{
					PatientId = p.IntPatientId,
					PatientSurname = p.TxtPatientSurname,
					PatientName = p.TxtPatientName,
					PatientSecondName = p.TxtPatientSecondName,
					Birthday = p.DatBirthday,
					Address = p.TxtAddress,
					TreatmentSets = db.TblTreatmentSet
						.Where(ts => ts.IntPatientId == p.IntPatientId)
						.Select(ts => new TreatmentSetViewModel
						{
							TreatmentType = db.TblTreatmentType
								.Where(tt => tt.IntTreatmentTypeId == ts.IntTreatmentTypeId)
								.Select(tt => new TreatmentTypeViewModel
								{
									TreatmentTypeName = tt.TxtTreatmentTypeName,
								})
								.FirstOrDefault(),
							DateBegin = ts.DatDateBegin,
							DateEnd = ts.DatDateEnd,
							TreatmentSetCount = ts.IntTreatmentSetCount,
							TreatmentSetCountFact = ts.IntTreatmentSetCountFact,
							TreatmentSetRoom = ts.TxtTreatmentSetRoom,
							TreatmentVisits = db.TblTreatmentVisit
								.Where(tv => tv.IntTreatmentSetId == ts.IntTreatmentSetId)
								.Select(tv => new TreatmentVisitViewModel
								{
									TreatmentVisitDate = tv.DatTreatmentVisitDate
								})
								.ToList()
						})
						.ToList()
				})
				.ToList();

			return View(viewModel);
		}

		[HttpGet]
		public IActionResult DoctorReport(int doctorId)
		{
			var viewModel = db.TblDoctor
				.Where(d => d.IntDoctorId == doctorId)
				.Select(d => new DoctorViewModel
				{
					DoctorName = d.TxtDoctorName,
					Specialist = d.TxtSpecialist,
					DoctorWork = d.DatDoctorWork,
					TreatmentSets = db.TblTreatmentSet
						.Where(ts => ts.IntDoctorId == d.IntDoctorId)
						.Select(ts => new TreatmentSetViewModel
						{
							Patient = db.TblPatient
								.Where(p => p.IntPatientId == ts.IntPatientId)
								.Select(p => new PatientViewModel
								{
									PatientName = p.TxtPatientName,
									PatientSecondName = p.TxtPatientSecondName,
									PatientSurname = p.TxtPatientSurname
								})
								.FirstOrDefault(),
							TreatmentType = db.TblTreatmentType
								.Where(tt => tt.IntTreatmentTypeId == ts.IntTreatmentTypeId)
								.Select(tt => new TreatmentTypeViewModel
								{
									TreatmentTypeName = tt.TxtTreatmentTypeName,
								})
								.FirstOrDefault(),
							DateBegin = ts.DatDateBegin,
							DateEnd = ts.DatDateEnd
						})
						.ToList()
				})
				.FirstOrDefault();

			return View(viewModel);
		}
	}
}
