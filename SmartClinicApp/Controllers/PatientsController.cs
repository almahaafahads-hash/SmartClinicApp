using Microsoft.AspNetCore.Mvc;
using SmartClinicApp.Interfaces;
using SmartClinicApp.Domain;

namespace SmartClinicApp.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IPatientRepository _repository;

        public PatientsController(IPatientRepository repository)
        {
            _repository = repository;
        }

        // ✅ عرض قائمة المرضى
        public IActionResult Index()
        {
            var patients = _repository.GetAllPatients();
            return View(patients);
        }

        // ✅ فتح صفحة إضافة مريض
        public IActionResult Create()
        {
            return View();
        }

        // ✅ حفظ المريض الجديد
        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            _repository.AddPatient(patient);
            return RedirectToAction("Index");
        }

        // ✅ فتح صفحة التعديل
        public IActionResult Edit(int id)
        {
            var patient = _repository.GetPatientById(id);
            if (patient == null) return NotFound();

            return View(patient);
        }

        // ✅ حفظ التعديل
        [HttpPost]
        public IActionResult Edit(Patient patient)
        {
            _repository.UpdatePatient(patient);
            return RedirectToAction("Index");
        }

        // ✅ فتح صفحة تأكيد الحذف
        public IActionResult Delete(int id)
        {
            var patient = _repository.GetPatientById(id);
            if (patient == null) return NotFound();

            return View(patient);
        }

        // ✅ تنفيذ الحذف النهائي (POST)
        // مهم: اسم الـ Action في الرابط يكون "Delete" وليس "DeleteConfirmed"
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.DeletePatient(id);
            return RedirectToAction("Index");
        }
    }
}