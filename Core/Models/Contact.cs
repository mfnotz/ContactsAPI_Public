namespace Core.Models
{
    public class Contact : BaseEntityModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string MobilePhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String? UserId { get; set; }
        public User? User { get; set; }
        public ICollection<UserSkill>? Skills { get; set; } = new List<UserSkill>();
    }
}
