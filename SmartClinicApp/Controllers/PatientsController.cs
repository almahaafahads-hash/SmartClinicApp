using Microsoft.AspNetCore.Mvc;
using SmartClinicApp.Domain.Patients; // الربط بملف المريض

namespace SmartClinicApp.Controllers
{
    public class PatientsController : Controller
    {
        // عرض قائمة المرضى
        public IActionResult Index()
        {
            var patients = new List<Patient>
            {
                new Patient { Id = 1, FullName = "ريما محمد", MedicalHistory = "متابعة" },
                new Patient { Id = 2, FullName = "سارة المنصور", MedicalHistory = "فحص" }
            };

            return View(patients);
        }
    }
}