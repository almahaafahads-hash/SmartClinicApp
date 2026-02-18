using System.Collections.Generic;
using SmartClinicApp.Domain;

namespace SmartClinicApp.Interfaces
{
    public interface IPatientRepository
    {
        List<Patient> GetAllPatients();
        Patient? GetPatientById(int id);

        void AddPatient(Patient patient);
        void UpdatePatient(Patient patient);
        void DeletePatient(int id);
    }
}