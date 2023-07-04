using AutoMapper;
using Core.Models;

namespace Core.DTOs
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
            CreateMap<ContactDTO, Contact>();
            CreateMap<Contact, ContactDTO>();
            CreateMap<CreateContactDTO, Contact>();
            CreateMap<Contact, CreateContactDTO>();
            CreateMap<UpdateContactDTO, Contact>();
            CreateMap<Contact, UpdateContactDTO>();
            CreateMap<SkillDTO, Skill>();
            CreateMap<Skill, SkillDTO>(); 
            CreateMap<CreateSkillDTO, Skill>();
            CreateMap<Skill, CreateSkillDTO>();
            CreateMap<UpdateSkillDTO, Skill>();
            CreateMap<Skill, UpdateSkillDTO>();
            CreateMap<UserSkillDTO, UserSkill>();
            CreateMap<UserSkill, UserSkillDTO>();
        }
    }
}
