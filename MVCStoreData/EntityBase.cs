namespace MVCStoreData
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }

        //Soft Delete

        public bool Enabled { get; set; }
    }
}
