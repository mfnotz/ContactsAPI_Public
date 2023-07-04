namespace Core.Models
{
    public abstract class BaseEntityModel
    {
        public String Id { get; set; }
        public DateTime LastModified { get; set; } = DateTime.UtcNow;
        public String LastModifiedBy { get; set; }
    }
}
