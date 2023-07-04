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
    [Route("api/skills")]
    public class SkillsController : BaseController
    {
        private readonly ISkillService _skillService;
        private readonly IValidator<CreateSkillDTO> _createSkillValidator;
        private readonly IValidator<UpdateSkillDTO> _updateSkillValidator;
        public SkillsController(ISkillService skillService, IValidator<CreateSkillDTO> createSkillValidator, IValidator<UpdateSkillDTO> updateSkillValidator)
        {
            _skillService = skillService;
            _createSkillValidator = createSkillValidator;
            _updateSkillValidator = updateSkillValidator;
        }

        // GET: api/skills
        [HttpGet]
        public ActionResult<IEnumerable<SkillDTO>> GetSkills()
        {
            var contacts = _skillService.GetAllSkills();

            return Ok(contacts);
        }

        // GET: api/skills/{id}
        [HttpGet("{id}")]
        public ActionResult<SkillDTO> GetSkill(String id)
        {
            var contact = _skillService.GetSkillById(id);
            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        // POST: api/skills
        [HttpPost]
        public ActionResult<SkillDTO> CreateSkill(CreateSkillDTO skillDTO)
        {
            var validationResult = _createSkillValidator.Validate(skillDTO);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.ToString("~"));

            skillDTO.LastModifiedBy = _loggedUser;
            var Id = _skillService.CreateSkill(skillDTO);
            var result = _skillService.GetSkillById(Id);

            return CreatedAtAction(nameof(GetSkill), new { id = Id }, result);
        }

        // PUT: api/skills/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateSkill(String id, UpdateSkillDTO updatedSkill)
        {
            var validationResult = _updateSkillValidator.Validate(updatedSkill);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.ToString("~"));

            var skill = _skillService.GetSkillById(id);
            if (skill == null)
                return NotFound();

            updatedSkill.LastModifiedBy = _loggedUser;
            var result = _skillService.UpdateSkill(updatedSkill);

            return Ok(result);
        }

        // DELETE: api/skills/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteSkill(String id)
        {
            var contact = _skillService.GetSkillById(id);
            if (contact == null)
                return NotFound();

            _skillService.DeleteSkill(id);

            return NoContent();
        }
    }

}
