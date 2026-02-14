using SmartClinicApp.Domain.Doctors;
using SmartClinicApp.Interfaces;

namespace SmartClinicApp.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        public IEnumerable<Doctor> GetAllDoctors()
        {
            return new List<Doctor>
            {
                new Doctor { Id = 1, Name = "د. خالد", Specialization = "باطنية" },
                new Doctor { Id = 2, Name = "د. هند", Specialization = "أطفال" }
            };
        }
    }
}
