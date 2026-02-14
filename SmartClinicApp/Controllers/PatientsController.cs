using Microsoft.AspNetCore.Mvc;
using SmartClinicApp.Domain.Patients; // استدعاء مودل المريض

namespace SmartClinicApp.Controllers
{
    public class PatientsController : Controller
    {
        // الأكشن اللي تعرض قائمة المرضى
        public IActionResult Index()
        {
            var patients = new List<Patient>
            {
                new Patient { Id = 1, FullName = "ريما محمد ", MedicalHistory = "فحص دوري" },
                new Patient { Id = 2, FullName = "سارة المنصور", MedicalHistory = "متابعة سكري" }
            };
            return View(patients); // ترسل البيانات للـ View
        }
    }
}