namespace Core.DTOs
{
    public class SkillDTO : CreateSkillDTO
    {
        public String Id { get; set; }
    }

    public class CreateSkillDTO
    {
        public string Name { get; set; }
        public DateTime LastModified { get; set; } = DateTime.UtcNow;
        public String LastModifiedBy { get; set; }
    }

    public class UpdateSkillDTO : CreateSkillDTO
    {
        public String Id { get; set; }
    }
    

}
