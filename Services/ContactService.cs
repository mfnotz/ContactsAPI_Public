using AutoMapper;
using Core.Abstractions.Repositories;
using Core.Abstractions.Services;
using Core.DTOs;
using Core.Models;

namespace Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public ContactService(IContactRepository contactRepository, IUserService userService, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _userService = userService;
            _mapper = mapper;
        }

        public IEnumerable<ContactDTO> GetAllContacts()
        {
            var items = _contactRepository.GetAllContacts();

            return _mapper.Map<IEnumerable<ContactDTO>>(items);
        }


        public ContactDTO GetContactById(String id)
        {
            var found = _contactRepository.GetContactById(id);

            if (found == null) return null;

            return _mapper.Map<ContactDTO>(found);
        }

        //Only Admin users can edit in any case, or the User if the Contact is bound to it
        public Boolean CanEdit(String userName, UpdateContactDTO contactDTO)
        {
            var isAdmin = _userService.IsAdmin(userName);

            if (!isAdmin) 
            {
                var found = _contactRepository.GetContactByUserName(userName);

                if (found == null) return false;

                return found.UserId == contactDTO.UserId;
            }

            return true;
        }

        //We don't want any user without Contact. It should update instead to a new Contact
        public Boolean CanDelete(String userName, String Id)
        {
            var found = _contactRepository.GetContactByUserName(userName);

            if (found == null) return false;

            if(found.UserId == Id) return false;

            return true;
        }

        public Boolean CanEditSkills(String userName, String contactId)
        {
            var isAdmin = _userService.IsAdmin(userName);

            if (!isAdmin)
            {
                var found = _contactRepository.GetContactByUserName(userName);

                if (found == null) return false;

                return found.Id == contactId;
            }

            return true;
        }

        public UpdateContactDTO GetContactByIdForUpdate(String id)
        {
            var found = _contactRepository.GetContactById(id);

            if (found == null) return null;

            return _mapper.Map<UpdateContactDTO>(found);
        }

        public String CreateContact(CreateContactDTO contact)
        {
            try
            {
                // Perform validation here
                // ...
                var obj = _mapper.Map<Contact>(contact);

                obj.Id = Guid.NewGuid().ToString();

                var result = _contactRepository.AddContact(obj);

                return result.Id;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public UpdateContactDTO UpdateContact(UpdateContactDTO contact)
        {
            // Perform validation here
            // Can't update if is the user is the same contact

            var obj = _mapper.Map<Contact>(contact);

            var result = _contactRepository.UpdateContact(obj);

            var dto = _mapper.Map<UpdateContactDTO>(result);

            return dto;
        }

        public void DeleteContact(String id)
        {
            var found = _contactRepository.GetContactById(id);

            _contactRepository.DeleteContact(found);
        }

        public UpdateContactDTO AddSkillToContact(UpdateContactDTO contactDTO, UserSkillDTO skillDTO)
        {
            var obj = _mapper.Map<Contact>(contactDTO);
            var skill = _mapper.Map<UserSkill>(skillDTO);

            obj.Skills.Add(skill);

            var result = _contactRepository.UpdateContact(obj);

            return _mapper.Map<UpdateContactDTO>(result);
        }

        public UpdateContactDTO UpdateContactSkill(UpdateContactDTO contactDTO, UserSkillDTO skillDTO)
        {
            var obj = _mapper.Map<Contact>(contactDTO);
            var skill = _mapper.Map<UserSkill>(skillDTO);

            obj.Skills.Add(skill);

            var result = _contactRepository.UpdateContact(obj);

            return _mapper.Map<UpdateContactDTO>(result);
        }

        public UpdateContactDTO RemoveContactSkill(UpdateContactDTO contactDTO, UserSkillDTO skillDTO)
        {
            var obj = _mapper.Map<Contact>(contactDTO);
            var skill = _mapper.Map<UserSkill>(skillDTO);

            obj.Skills.Remove(skill);

            var result = _contactRepository.UpdateContact(obj);

            return _mapper.Map<UpdateContactDTO>(result);
        }
    }

}