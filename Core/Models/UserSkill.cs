using Core.Helpers;

namespace Core.Models
{
    public class UserSkill : BaseEntityModel
    {
        public String SkillId { get; set; }
        public Skill Skill { get; set; }
        public String ContactId { get; set; }
        public Contact Contact { get; set; }
        public SkillLevelEnum Level { get; set; }
    }
}
