using SmartClinicApp.Data;
using SmartClinicApp.Domain;
using SmartClinicApp.Interfaces;

namespace SmartClinicApp.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        // هنا نربط المستودع بقاعدة البيانات اللي سويتيها
        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // يجيب كل المرضى من الـ SQL
        public IEnumerable<Patient> GetAllPatients()
        {
            return _context.Patients.ToList();
        }

        // يضيف مريض جديد في الـ SQL ويحفظه للأبد
        public void AddPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }
    }
}