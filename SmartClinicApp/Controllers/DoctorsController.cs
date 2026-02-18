using Microsoft.AspNetCore.Mvc;
using SmartClinicApp.Domain;
using SmartClinicApp.Interfaces;

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

        // ✅ عرض صفحة جدول الأطباء
        public IActionResult Index()
        {
            var doctors = _repository.GetAllDoctors();
            return View(doctors);
        }

        // ✅ فتح صفحة إضافة طبيب جديد
        public IActionResult Create()
        {
            return View();
        }

        // ✅ حفظ الطبيب الجديد
        [HttpPost]
        public IActionResult Create(Doctor doctor)
        {
            _repository.AddDoctor(doctor);
            return RedirectToAction("Index");
        }

        // ===================== EDIT =====================

        // ✅ EDIT (GET) - يفتح صفحة التعديل
        public IActionResult Edit(int id)
        {
            var doctor = _repository.GetDoctorById(id);
            if (doctor == null) return NotFound();

            return View(doctor);
        }

        // ✅ EDIT (POST) - يحفظ التعديل
        [HttpPost]
        public IActionResult Edit(Doctor doctor)
        {
            _repository.UpdateDoctor(doctor);
            return RedirectToAction("Index");
        }

        // ===================== DELETE =====================

        // ✅ DELETE (GET) - يفتح صفحة تأكيد الحذف
        public IActionResult Delete(int id)
        {
            var doctor = _repository.GetDoctorById(id);
            if (doctor == null) return NotFound();

            return View(doctor);
        }

        // ✅ DELETE (POST) - ينفذ الحذف النهائي
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.DeleteDoctor(id);
            return RedirectToAction("Index");
        }
    }
}