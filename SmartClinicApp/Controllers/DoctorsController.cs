using Microsoft.AspNetCore.Mvc;
using SmartClinicApp.Domain;
using SmartClinicApp.Interfaces;

namespace SmartClinicApp.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IDoctorRepository _repository;
        private readonly IAppointmentRepository _appointmentRepository;

        public DoctorsController(IDoctorRepository repository, IAppointmentRepository appointmentRepository)
        {
            _repository = repository;
            _appointmentRepository = appointmentRepository;
        }

        public IActionResult Index()
        {
            var doctors = _repository.GetAllDoctors();
            return View(doctors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Doctor doctor)
        {
            _repository.AddDoctor(doctor);
            return RedirectToAction("Index");
        }

        // ✅ EDIT (GET)
        public IActionResult Edit(int id)
        {
            var doctor = _repository.GetDoctorById(id);
            if (doctor == null) return NotFound();

            return View(doctor);
        }

        // ✅ EDIT (POST)
        [HttpPost]
        public IActionResult Edit(Doctor doctor)
        {
            _repository.UpdateDoctor(doctor);
            return RedirectToAction("Index");
        }

        // ✅ DELETE (GET)
        public IActionResult Delete(int id)
        {
            var doctor = _repository.GetDoctorById(id);
            if (doctor == null) return NotFound();

            return View(doctor);
        }

        // ✅ DELETE (POST)
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.DeleteDoctor(id);
            return RedirectToAction("Index");
        }

        // ✅ مواعيد اليوم لطبيب معيّن
        public IActionResult TodayAppointments(int id)
        {
            var today = DateTime.Today;

            var appts = _appointmentRepository
                .GetAllAppointments()
                .Where(a => a.DoctorId == id && a.AppointmentDate.Date == today)
                .ToList();

            ViewBag.DoctorId = id;
            return View(appts);
        }
    }
}