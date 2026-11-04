namespace WebApplication2.Entities
{
    public class Appointment
    {
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = default!;

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = default!;

        public DateTime AppointmentDate { get; set; } = default!;
    }
}
