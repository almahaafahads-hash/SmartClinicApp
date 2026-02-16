using Microsoft.AspNetCore.Mvc;
using SmartClinicApp.Domain;
using SmartClinicApp.Interfaces;
using SmartClinicApp.Repositories;

namespace SmartClinicApp.Controllers
{
    public class DoctorsController : Controller
    {
        // وحدنا الاسم هنا ليكون _repository عشان يسهل عليكِ
        private readonly IDoctorRepository _repository;

        public DoctorsController(IDoctorRepository repository)
        {
            _repository = repository;
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
            // الحين الاسم صار مطابق للي عرفناه فوق
            _repository.AddDoctor(doctor);
            return RedirectToAction("Index");
        }
    }
}