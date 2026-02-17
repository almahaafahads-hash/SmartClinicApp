using Microsoft.AspNetCore.Mvc;
using SmartClinicApp.Domain;
using SmartClinicApp.Interfaces;
using System;

namespace SmartClinicApp.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentRepository _repository;

        public AppointmentsController(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(_repository.GetAllAppointments());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Appointment appointment)
        {
            try
            {
                _repository.AddAppointment(appointment);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(appointment);
            }
        }
    }
}
