using Microsoft.AspNetCore.Mvc;
using SmartClinicApp.Interfaces;
using SmartClinicApp.Domain;

namespace SmartClinicApp.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IPatientRepository _repository;

        // الـ Constructor لتعريف المخزن
        public PatientsController(IPatientRepository repository)
        {
            _repository = repository;
        }

        // عرض قائمة المرضى
        public IActionResult Index()
        {
            var patients = _repository.GetAllPatients();
            return View(patients);
        }

        // فتح صفحة الإضافة (الرسمة)
        public IActionResult Create()
        {
            return View();
        }

        // استقبال البيانات من الصفحة وحفظها
        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            _repository.AddPatient(patient);
            return RedirectToAction("Index");
        }
    }
}