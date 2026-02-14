using Microsoft.AspNetCore.Mvc;
using SmartClinicApp.Domain.Doctors; // يربط الكنترولر بملف الدكتور

namespace SmartClinicApp.Controllers
{
    public class DoctorsController : Controller
    {
        public IActionResult Index()
        {
            // قائمة وهمية للأطباء
            var doctors = new List<Doctor>
            {
                new Doctor { Id = 1, Name = "د. خالد", Specialization = "باطنية" },
                new Doctor { Id = 2, Name = "د. هند", Specialization = "أطفال" }
            };

            return View(doctors);
        }
    }
}