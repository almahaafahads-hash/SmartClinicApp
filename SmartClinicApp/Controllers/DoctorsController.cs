using Microsoft.AspNetCore.Mvc;
using SmartClinicApp.Domain;
using SmartClinicApp.Interfaces;
using SmartClinicApp.Repositories;

namespace SmartClinicApp.Controllers
{
    public class DoctorsController : Controller
    {
        // تعريف المستودع (Repository) للتعامل مع بيانات الأطباء
        private readonly IDoctorRepository _repository;

        // ربط المستودع من خلال الـ Constructor
        public DoctorsController(IDoctorRepository repository)
        {
            _repository = repository;
        }

        // عرض صفحة جدول الأطباء
        public IActionResult Index()
        {
            var doctors = _repository.GetAllDoctors();
            return View(doctors);
        }

        // فتح صفحة نموذج إضافة طبيب جديد
        public IActionResult Create()
        {
            return View();
        }

        // استقبال بيانات الطبيب الجديد وحفظها
        [HttpPost]
        public IActionResult Create(Doctor doctor)
        {
            // حفظ البيانات في القائمة عبر المستودع
            _repository.AddDoctor(doctor);

            // إعادة التوجيه لجدول الأطباء بعد الحفظ بنجاح
            return RedirectToAction("Index");
        }
    }
}