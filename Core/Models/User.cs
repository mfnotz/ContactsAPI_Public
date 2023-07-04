namespace Core.Models
{
    public class User : BaseEntityModel
    {
        public string UserName { get; set; }
        public string ContactId { get; set; }
        public string Email { get; set; }
        public Contact Contact { get; set; }
        public String Password { get; set; }
        public Boolean IsActive { get; set; }
        public Boolean IsAdmin { get; set; }
    }
}
