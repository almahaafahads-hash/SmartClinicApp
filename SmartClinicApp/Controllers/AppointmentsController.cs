using Microsoft.AspNetCore.Mvc;
using SmartClinicApp.Interfaces;
using SmartClinicApp.Domain;

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

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Appointment appointment)
        {
            _repository.AddAppointment(appointment);
            return RedirectToAction("Index");
        }
    }
}