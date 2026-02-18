using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartClinicApp.Domain;
using SmartClinicApp.Interfaces;

namespace SmartClinicApp.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;

        public AppointmentsController(
            IAppointmentRepository appointmentRepository,
            IPatientRepository patientRepository,
            IDoctorRepository doctorRepository)
        {
            _appointmentRepository = appointmentRepository;
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
        }

        public IActionResult Index()
        {
            return View(_appointmentRepository.GetAllAppointments());
        }

        public IActionResult Create()
        {
            FillLists();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _appointmentRepository.AddAppointment(appointment);
                return RedirectToAction("Index");
            }

            FillLists();
            return View(appointment);
        }

        // ✅ EDIT
        public IActionResult Edit(int id)
        {
            var appt = _appointmentRepository.GetAppointmentById(id);
            FillLists();
            return View(appt);
        }

        [HttpPost]
        public IActionResult Edit(Appointment appointment)
        {
            _appointmentRepository.UpdateAppointment(appointment);
            return RedirectToAction("Index");
        }

        // ✅ DELETE
        public IActionResult Delete(int id)
        {
            var appt = _appointmentRepository.GetAppointmentById(id);
            return View(appt);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _appointmentRepository.DeleteAppointment(id);
            return RedirectToAction("Index");
        }

        private void FillLists()
        {
            ViewBag.PatientId =
                new SelectList(_patientRepository.GetAllPatients(), "Id", "FullName");

            ViewBag.DoctorId =
                new SelectList(_doctorRepository.GetAllDoctors(), "Id", "Name");
        }
    }
}