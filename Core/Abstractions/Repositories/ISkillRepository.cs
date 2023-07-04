using Core.Models;

namespace Core.Abstractions.Repositories
{
    public interface ISkillRepository
    {
        IEnumerable<Skill> GetAllSkills();
        Skill GetSkillById(String skillId);
        void AddSkill(Skill skill);
        void UpdateSkill(Skill skill);
        void DeleteSkill(Skill skill);
    }

}
