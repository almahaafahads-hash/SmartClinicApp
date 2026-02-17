namespace SmartClinicApp.Domain
{
    public class Appointment
    {
        public int Id { get; set; }

        // رقم المريض
        public int PatientId { get; set; }

        // رقم الطبيب
        public int DoctorId { get; set; }

        // تاريخ ووقت الموعد
        public DateTime AppointmentDate { get; set; }

        // مدة الزيارة (30 دقيقة مثلاً)
        public int DurationInMinutes { get; set; } = 30;

        // ملاحظات
        public string? Notes { get; set; }
    }
}
