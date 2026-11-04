namespace WebApplication2.Entities
{
    public class BaseEntities
    {
        public int ID { get; set; }
        public string Name { get; set; } = default!;
        #region Aduit
        public bool IsDeleted { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public int MOdifiedBy { get; set; }
        #endregion

    }
}
