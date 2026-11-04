namespace WebApplication2.Dtos.PatientDtos
{
    public class UpdatePatientRequest
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public DateOnly DateOfBirth { get; set; }
    }
}
