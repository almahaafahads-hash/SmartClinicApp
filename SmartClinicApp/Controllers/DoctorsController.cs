using Microsoft.AspNetCore.Mvc;
using SmartClinicApp.Interfaces; // استدعاء الانترفيس
using SmartClinicApp.Repositories;

namespace SmartClinicApp.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IDoctorRepository _doctorRepo;

        // Constructor: هنا نربط الكنترولر بالريبو
        public DoctorsController(IDoctorRepository doctorRepo)
        {
            _doctorRepo = doctorRepo;
        }

        public IActionResult Index()
        {
            // الحين نجيب البيانات من الريبو مو يدوي
            var doctors = _doctorRepo.GetAllDoctors();
            return View(doctors);
        }
    }
}