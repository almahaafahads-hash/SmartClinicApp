using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartClinicApp.Domain;
using SmartClinicApp.Interfaces;
using System;

namespace SmartClinicApp.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;

        // تهيئة الـ Controller وسحب جميع المستودعات المطلوبة
        public AppointmentsController(
            IAppointmentRepository appointmentRepository,
            IPatientRepository patientRepository,
            IDoctorRepository doctorRepository)
        {
            _appointmentRepository = appointmentRepository;
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
        }

        // عرض قائمة المواعيد
        public IActionResult Index()
        {
            var appointments = _appointmentRepository.GetAllAppointments();
            return View(appointments);
        }

        // GET: Appointments/Create
        // هذه الدالة تفتح صفحة الإضافة وتعبئة القوائم المنسدلة
        public IActionResult Create()
        {
            var patients = _patientRepository.GetAllPatients();
            ViewBag.PatientId = new SelectList(patients, "Id", "FullName");

            var doctors = _doctorRepository.GetAllDoctors();
            ViewBag.DoctorId = new SelectList(doctors, "Id", "Name");

            return View();
        }

        // POST: Appointments/Create
        [HttpPost]
        public IActionResult Create(Appointment appointment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _appointmentRepository.AddAppointment(appointment);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "حدث خطأ أثناء الحفظ: " + ex.Message;
            }

            // إذا فشل الحفظ نعيد تعبئة القوائم
            ViewBag.PatientId = new SelectList(_patientRepository.GetAllPatients(), "Id", "FullName", appointment.PatientId);
            ViewBag.DoctorId = new SelectList(_doctorRepository.GetAllDoctors(), "Id", "Name", appointment.DoctorId);

            return View(appointment);
        }
    }
}