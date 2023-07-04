using AutoMapper;
using Core.Abstractions.Repositories;
using Core.Abstractions.Services;
using Core.DTOs;
using Core.Models;

namespace Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;

        public SkillService(ISkillRepository skillRepository, IMapper mapper)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
        }

        public IEnumerable<SkillDTO> GetAllSkills()
        {
            var items = _skillRepository.GetAllSkills();

            return _mapper.Map<IEnumerable<SkillDTO>>(items);
        }


        public SkillDTO GetSkillById(String id)
        {
            var found = _skillRepository.GetSkillById(id);

            if (found == null) return null;

            return _mapper.Map<SkillDTO>(found);
        }

        public String CreateSkill(CreateSkillDTO skill)
        {
            try
            {
                // Perform validation here
                // ...
                var obj = _mapper.Map<Skill>(skill);

                obj.Id = Guid.NewGuid().ToString();

                _skillRepository.AddSkill(obj);

                return obj.Id;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public UpdateSkillDTO UpdateSkill(UpdateSkillDTO skill)
        {
            // Perform validation here

            var obj = _mapper.Map<Skill>(skill);

            _skillRepository.UpdateSkill(obj);

            var dto = _mapper.Map<UpdateSkillDTO>(_skillRepository.GetSkillById(obj.Id));

            return dto;
        }

        public void DeleteSkill(String id)
        {
            var found = _skillRepository.GetSkillById(id);

            _skillRepository.DeleteSkill(found);
        }
    }
}
