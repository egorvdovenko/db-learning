using DBLearning.Models;
using DBLearning.Tbls;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DBLearning.Controllers
{
	public class PatientsController : Controller
	{
		Db222zisContext db;

		public PatientsController(Db222zisContext context)
		{
			db = context;
		}

		[HttpGet]
		public IActionResult Index()
		{
			var viewModel = db.TblPatient
				.Select(p => new PatientViewModel
				{
					PatientId = p.IntPatientId,
					PatientSurname = p.TxtPatientSurname,
					PatientName = p.TxtPatientName,
					PatientSecondName = p.TxtPatientSecondName,
					Birthday = p.DatBirthday,
					Address = p.TxtAddress
				})
				.ToList();

			return View(viewModel);
		}

		[HttpGet]
		public IActionResult AddPatient()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddPatient(AddPatientRequest request)
		{
			var patient = new TblPatient
			{
				TxtPatientSurname = request.PatientSurname,
				TxtPatientName = request.PatientName,
				TxtPatientSecondName = request.PatientSecondName,
				DatBirthday = request.Birthday,
				TxtAddress = request.Address
			};

			db.TblPatient.Add(patient);
			db.SaveChanges();

			return RedirectToAction("AddPatientSuccess");
		}

		[HttpGet]
		public IActionResult AddPatientSuccess()
		{
			return View();
		}

		[HttpGet]
		public IActionResult PatientTreatments(int patientId)
		{

			var patient = db.TblPatient
				.Where(p => p.IntPatientId == patientId)
				.Select(p => new PatientViewModel
				{
					PatientId = p.IntPatientId,
					PatientSurname = p.TxtPatientSurname,
					PatientName = p.TxtPatientName,
					PatientSecondName = p.TxtPatientSecondName,
					Birthday = p.DatBirthday,
					Address = p.TxtAddress
				})
				.FirstOrDefault();

			var treatmentSets = db.TblTreatmentSet
				.Where(ts => ts.IntPatientId == patientId)
				.Select(ts => new TreatmentSetViewModel
				{
					DateBegin = ts.DatDateBegin,
					DateEnd = ts.DatDateEnd,
					TreatmentSetCount = ts.IntTreatmentSetCount,
					TreatmentSetCountFact = ts.IntTreatmentSetCountFact,
					TreatmentType = db.TblTreatmentType
						.Where(tt => tt.IntTreatmentTypeId == ts.IntTreatmentTypeId)
						.Select(tt => new TreatmentTypeViewModel
						{
							TreatmentTypeName = tt.TxtTreatmentTypeName
						})
						.FirstOrDefault(),
					Doctor = db.TblDoctor
						.Where(d => d.IntDoctorId == ts.IntDoctorId)
						.Select(d => new DoctorViewModel
						{
							DoctorName = d.TxtDoctorName
						})
						.FirstOrDefault()
				})
				.ToList();

			var viewModel = new PatientTreatmentsViewModel
			{
				Patient = patient,
				TreatmentSets = treatmentSets
			};

			return View(viewModel);
		}

		[HttpGet]
		public IActionResult AddPatientTreatment(int patientId)
		{
			var patient = db.TblPatient
				.Where(p => p.IntPatientId == patientId)
				.Select(p => new PatientViewModel
				{
					PatientId = p.IntPatientId,
					PatientSurname = p.TxtPatientSurname,
					PatientName = p.TxtPatientName,
					PatientSecondName = p.TxtPatientSecondName,
					Birthday = p.DatBirthday,
				})
				.FirstOrDefault();

			var doctors = db.TblDoctor
				.Select(d => new DoctorViewModel
				{
					DoctorId = d.IntDoctorId,
					DoctorName = d.TxtDoctorName
				})
				.ToList();

			var treatmentTypes = db.TblTreatmentType
				.Select(tt => new TreatmentTypeViewModel
				{
					TreatmentTypeId = tt.IntTreatmentTypeId,
					TreatmentTypeName = tt.TxtTreatmentTypeName
				})
				.ToList();

			var viewModel = new AddPatientTreatmentViewModel
			{
				Patient = patient,
				Doctors = doctors,
				TreatmentTypes = treatmentTypes
			};

			return View(viewModel);
		}

		[HttpPost]
		public IActionResult AddPatientTreatment(AddPatientTreatmentRequest request)
		{
			var treatment = new TblTreatmentSet
			{
				IntPatientId = request.PatientId,
				IntTreatmentTypeId = request.TreatmentTypeId,
				IntDoctorId = request.DoctorId,
				DatDateBegin = request.DateBegin,
				DatDateEnd = request.DateEnd,
				IntTreatmentSetCount = request.TreatmentSetCount,
				TxtTreatmentSetRoom = request.TreatmentSetRoom,
			};

			db.TblTreatmentSet.Add(treatment);
			db.SaveChanges();

			return RedirectToAction("AddPatientTreatmentSuccess", new { patientId = request.PatientId });
		}

		[HttpGet]
		public IActionResult AddPatientTreatmentSuccess(int patientId)
		{
			var viewModel = db.TblPatient
				.Where(p => p.IntPatientId == patientId)
				.Select(p => new PatientViewModel
				{
					PatientId = p.IntPatientId,
				})
				.FirstOrDefault();

			return View(viewModel);
		}
	}
}
