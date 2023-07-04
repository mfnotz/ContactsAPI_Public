using Core.Helpers;

namespace Core.DTOs
{
    public class UserSkillDTO : BaseEntityDTO
    {
        public String SkillId { get; set; }
        public SkillDTO Skill { get; set; }
        public String ContactId { get; set; }
        public ContactDTO Contact { get; set; }
        public SkillLevelEnum Level { get; set; }
    }
}
