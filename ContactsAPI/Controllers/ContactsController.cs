using Core.Abstractions.Services;
using Core.DTOs;
using Core.Models;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/contacts")]
    public class ContactsController : BaseController
    {
        private readonly IContactService _contactService;
        private readonly ISkillService _skillService;
        private readonly IValidator<CreateContactDTO> _createContactValidator;
        private readonly IValidator<UpdateContactDTO> _updateContactValidator;
        public ContactsController(IContactService contactService, ISkillService skillService, IValidator<CreateContactDTO> createContactValidator, IValidator<UpdateContactDTO> updateContactValidator)
        { 
            _contactService = contactService;
            _skillService = skillService;
            _createContactValidator = createContactValidator;
            _updateContactValidator = updateContactValidator;
        }

        // GET: api/contacts
        [HttpGet]
        public ActionResult<IEnumerable<Contact>> GetContacts()
        {
            var contacts = _contactService.GetAllContacts();

            return Ok(contacts);
        }

        // GET: api/contacts/{id}
        [HttpGet("{id}")]
        public ActionResult<Contact> GetContact(String id)
        {
            var contact = _contactService.GetContactById(id);
            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        // POST: api/contacts
        [HttpPost]
        public ActionResult<ContactDTO> CreateContact(CreateContactDTO contact)
        {
            var validationResult = _createContactValidator.Validate(contact);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.ToString("~"));

            contact.LastModifiedBy = _loggedUser;
            var Id = _contactService.CreateContact(contact);
            var result =  _contactService.GetContactById(Id);


            return CreatedAtAction(nameof(GetContact), new { id = Id }, result);
        }

        // PUT: api/contacts/{id}
        [HttpPut("{id}")]
        public ActionResult<UpdateContactDTO> UpdateContact(String id, UpdateContactDTO updatedContact)
        {
            var validationResult = _updateContactValidator.Validate(updatedContact);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.ToString("~"));

            var canEdit = _contactService.CanEdit(_loggedUser, updatedContact);

            if(!canEdit) return Forbid();

            var contact = _contactService.GetContactById(id);
            if (contact == null)
                return NotFound();

            contact.LastModifiedBy = _loggedUser;

            var result = _contactService.UpdateContact(updatedContact);

            return Ok(result);
        }

        // DELETE: api/contacts/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteContact(String id)
        {
            var canDelete = _contactService.CanDelete(_loggedUser, id);

            if(!canDelete) return Forbid();

            var contact = _contactService.GetContactById(id);
            if (contact == null)
                return NotFound();

            _contactService.DeleteContact(id);

            return NoContent();
        }

        [HttpPost]
        [Route("contacts/{contactId}/skills")]
        public ActionResult AddSkillToContact(String contactId, UserSkillDTO skillDTO)
        {
            // Check if can edit
            var canEdit = _contactService.CanEditSkills(_loggedUser, contactId);

            if (!canEdit) return Forbid();

            // Retrieve the contact by contactId from the database
            var contact = _contactService.GetContactByIdForUpdate(contactId);
            if (contact == null)
            {
                return NotFound(); // Return appropriate response if the contact is not found
            }

            contact.LastModifiedBy = skillDTO.LastModifiedBy = _loggedUser;

            var result = _contactService.AddSkillToContact(contact, skillDTO);

            return Ok(result); // Return appropriate response indicating success
        }

        [HttpPut]
        [Route("contacts/{contactId}/skills/{skillId}")]
        public ActionResult UpdateContactSkill(String contactId, String skillId, UserSkillDTO skillDTO)
        {
            // Check if can edit
            var canEdit = _contactService.CanEditSkills(_loggedUser, contactId);

            if(!canEdit) return Forbid();

            // Retrieve the contact by contactId from the database
            var contact = _contactService.GetContactByIdForUpdate(contactId);
            if (contact == null)
            {
                return NotFound(); // Return appropriate response if the contact is not found
            }

            var skill = _skillService.GetSkillById(skillId);
            if (skill == null)
            {
                return NotFound(); // Return appropriate response if the contact is not found
            }

            contact.LastModifiedBy = skillDTO.LastModifiedBy = _loggedUser;

            var result = _contactService.UpdateContactSkill(contact, skillDTO);


            return Ok(result); // Return appropriate response indicating success
        }

        [HttpDelete]
        [Route("contacts/{contactId}/skills/{skillId}")]
        public ActionResult DeleteContactSkill(String contactId, String skillId)
        {
            // Check if can edit
            var canEdit = _contactService.CanEditSkills(_loggedUser, contactId);

            if (!canEdit) return Forbid();

            // Retrieve the contact by contactId from the database
            var contact = _contactService.GetContactByIdForUpdate(contactId);
            if (contact == null)
            {
                return NotFound(); // Return appropriate response if the contact is not found
            }

            var skill = contact.Skills.FirstOrDefault(x => x.SkillId == skillId);
            if (skill == null)
            {
                return NotFound(); // Return appropriate response if the contact is not found
            }

            contact.LastModifiedBy = _loggedUser;

            var result = _contactService.RemoveContactSkill(contact, skill);

            return Ok(result); // Return appropriate response indicating success
        }

    }

}