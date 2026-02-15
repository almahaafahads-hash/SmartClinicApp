using System;

namespace SmartClinicApp.Domain.Patients
{
    // هذا الكلاس يمثل بيانات المريض في النظام
    public class Patient
    {
        // المعرف الفريد للمريض (ID)
        public int Id { get; set; }

        // اسم المريض بالكامل
        public string FullName { get; set; }

        // تاريخ ميلاد المريض
        public DateTime DateOfBirth { get; set; }

        // السجل الطبي البسيط أو الملاحظات
        public string MedicalHistory { get; set; }
        public string NationalId { get; set; }

    }
}
