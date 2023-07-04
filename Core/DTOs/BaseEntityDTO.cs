
namespace Core.DTOs
{
    public abstract class BaseEntityDTO
    {
        private String _id;

        public String Id { get => _id; set => _id = value; }
        public DateTime LastModified { get; set; } = DateTime.UtcNow;
        public String LastModifiedBy { get; set; }

    }
}
