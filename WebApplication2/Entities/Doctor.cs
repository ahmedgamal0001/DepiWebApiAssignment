namespace WebApplication2.Entities
{
    public class Doctor :BaseEntities
    {
        public string Specialization { get; set; } = default!;

        public ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();

    }
}
