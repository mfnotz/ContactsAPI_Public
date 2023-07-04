
namespace Core.DTOs
{
    public class UserDTO : BaseEntityDTO
    {
        public string UserName { get; set; }
        public string ContactId { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public ContactDTO Contact { get; set; }
        public Boolean IsActive {get; set;}
    }
}
