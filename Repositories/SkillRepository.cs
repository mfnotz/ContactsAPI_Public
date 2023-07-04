using Core.Abstractions.Repositories;
using Core.Models;

namespace Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly IContactsDbContext _dbContext;

        public SkillRepository(ContactsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Skill> GetAllSkills() 
        {
            return _dbContext.Skills.AsEnumerable();
        }

        public Skill GetSkillById(String skillId)
        {
            return _dbContext.Skills.Find(skillId);
        }

        public void AddSkill(Skill skill)
        {
            _dbContext.Skills.Add(skill);
            _dbContext.SaveChanges();
        }

        public void UpdateSkill(Skill skill)
        {
            _dbContext.Skills.Update(skill);
            _dbContext.SaveChanges();
        }

        public void DeleteSkill(Skill skill)
        {
            _dbContext.Skills.Remove(skill);
            _dbContext.SaveChanges();
        }
    }

}
