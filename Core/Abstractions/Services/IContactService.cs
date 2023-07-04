using Core.DTOs;
using Core.Models;

namespace Core.Abstractions.Services
{
    public interface IContactService
    {
        IEnumerable<ContactDTO> GetAllContacts();
        ContactDTO GetContactById(String id);
        Boolean CanEdit(String userName, UpdateContactDTO contactDTO);
        Boolean CanDelete(String userName, String Id);
        Boolean CanEditSkills(String userName, String contactId);
        UpdateContactDTO GetContactByIdForUpdate(String id);
        String CreateContact(CreateContactDTO contact);
        UpdateContactDTO UpdateContact(UpdateContactDTO contact);
        void DeleteContact(String id);
        UpdateContactDTO AddSkillToContact(UpdateContactDTO contact, UserSkillDTO skillDto);
        UpdateContactDTO UpdateContactSkill(UpdateContactDTO contact, UserSkillDTO skillDTO);
        UpdateContactDTO RemoveContactSkill(UpdateContactDTO contact, UserSkillDTO skillDTO);
    }
}
