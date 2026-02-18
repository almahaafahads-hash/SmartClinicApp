using System;
using System.ComponentModel.DataAnnotations;

namespace SmartClinicApp.Domain
{
    public class Appointment
    {
        // المفتاح الأساسي
        public int Id { get; set; }

        // رقم المريض
        [Display(Name = "المريض")]
        public int PatientId { get; set; }

        // رقم الطبيب
        [Display(Name = "الطبيب")]
        public int DoctorId { get; set; }

        // تاريخ ووقت الموعد
        [Display(Name = "تاريخ الموعد")]
        public DateTime AppointmentDate { get; set; }

        // مدة الزيارة (30 دقيقة افتراضياً)
        [Display(Name = "مدة الزيارة")]
        public int DurationInMinutes { get; set; } = 30;

        // ملاحظات
        [Display(Name = "ملاحظات")]
        public string? Notes { get; set; }

        // Navigation Properties (عشان نجيب الاسم بدل الرقم)
        public virtual Patient? Patient { get; set; }
        public virtual Doctor? Doctor { get; set; }
    }
}