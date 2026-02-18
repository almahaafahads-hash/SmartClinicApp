using System;
using System.ComponentModel.DataAnnotations;

namespace SmartClinicApp.Domain
{
    public class Appointment
    {
        // المفتاح الأساسي للموعد
        public int Id { get; set; }

        // رقم المريض (Foreign Key)
        [Display(Name = "المريض")]
        public int PatientId { get; set; }

        // رقم الطبيب (Foreign Key)
        [Display(Name = "الطبيب")]
        public int DoctorId { get; set; }

        // تاريخ ووقت الموعد
        [Display(Name = "تاريخ الموعد")]
        public DateTime AppointmentDate { get; set; }

        // مدة الزيارة (افتراضياً 30 دقيقة)
        [Display(Name = "مدة الزيارة")]
        public int DurationInMinutes { get; set; } = 30;

        // ملاحظات إضافية عن الحالة
        [Display(Name = "ملاحظات")]
        public string? Notes { get; set; }

        // --- الربط البرمجي (Navigation Properties) ---
        // هذه الأسطر هي التي تعالج أخطاء CS1061 وتسمح لكِ بعرض الأسماء بدلاً من الأرقام

        [Display(Name = "المريض")]
        public virtual Patient Patient { get; set; }

        [Display(Name = "الطبيب")]
        public virtual Doctor Doctor { get; set; }
    }
}