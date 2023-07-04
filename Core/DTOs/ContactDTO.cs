using Core.Models;

namespace Core.DTOs
{
    public class ContactDTO : CreateContactDTO
    {
        public String Id { get; set; }
    }

    public class CreateContactDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string MobilePhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String UserId { get; set; }
        public UserDTO User { get; set; }
        public ICollection<UserSkillDTO>? Skills { get; set; } = new List<UserSkillDTO>();
        public DateTime LastModified { get; set; } = DateTime.UtcNow;
        public String LastModifiedBy { get; set; }
    }

    public class UpdateContactDTO : ContactDTO
    { 
        public String Id { get; set; }
    }
}
