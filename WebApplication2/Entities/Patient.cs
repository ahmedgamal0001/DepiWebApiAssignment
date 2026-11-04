namespace WebApplication2.Entities
{
    public class Patient : BaseEntities
    {
        public DateOnly DateOfBirth { get; set; } = default!;

        public ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();

    }
}
