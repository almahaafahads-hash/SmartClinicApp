using Microsoft.AspNetCore.Mvc;
using SmartClinicApp.Interfaces;
using SmartClinicApp.Repositories;

namespace SmartClinicApp.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IPatientRepository _patientRepo;

        public PatientsController(IPatientRepository patientRepo)
        {
            _patientRepo = patientRepo;
        }

        public IActionResult Index()
        {
            // نطلب قائمة المرضى من الريبو
            var patients = _patientRepo.GetAllPatients();
            return View(patients);
        }
    }
}