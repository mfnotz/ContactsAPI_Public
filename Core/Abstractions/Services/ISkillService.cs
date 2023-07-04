using Core.DTOs;

namespace Core.Abstractions.Services
{
    public interface ISkillService
    {
        public IEnumerable<SkillDTO> GetAllSkills();
        public SkillDTO GetSkillById(String id);
        public String CreateSkill(CreateSkillDTO skill);
        public UpdateSkillDTO UpdateSkill(UpdateSkillDTO skill);
        public void DeleteSkill(String id);
    }
}
