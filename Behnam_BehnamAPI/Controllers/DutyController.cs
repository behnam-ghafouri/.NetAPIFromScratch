using Behnam_BehnamAPI.Data;
using Behnam_BehnamAPI.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Behnam_BehnamAPI.Controllers
{
    [Route("api/Duty")]
    //required to have basic validation on DTO models
    [ApiController]
    public class DutyController:ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public DutyController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<DutyDTO>> GetDuties()
        {
            return Ok(_db.Duties.ToList());
        }

        [HttpGet("{id:int}",Name ="GetDuty")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<DutyDTO?> GetDuty(int id)
        {
            if(id == 0)
                return BadRequest();
            var duty = _db.Duties.FirstOrDefault(elm=>elm.Id==id);
            if (duty == null)
                return NotFound();
            return Ok(duty);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<DutyDTO> CreatDuty([FromBody] DutyDTO dutyDTO)
        {
            //check the DTO validation annotations 
            //if (ModelState.IsValid)
            if(_db.Duties.FirstOrDefault(e=>e.Name.ToLower()==dutyDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "Is not unique");
                return BadRequest(ModelState);
            }
            if(dutyDTO == null)
                return BadRequest(dutyDTO);
            if(dutyDTO.Id > 0)            
                return StatusCode(StatusCodes.Status500InternalServerError);
            Duty duty = new()
                {
                    Name = dutyDTO.Name,
                    Rate = dutyDTO.Rate,
                    ImageUrl = dutyDTO.ImageUrl,
                    Sqft = dutyDTO.Sqft,
                };
            _db.Duties.AddAsync(duty);
            _db.SaveChanges();
            return CreatedAtRoute("GetDuty",new {id=dutyDTO.Id},dutyDTO);         
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}",Name = "DeleteDuty")]
        public IActionResult DeleteDuty(int id)
        {
            if (id == null)
                return BadRequest();
            var duty = _db.Duties.FirstOrDefault(elm => elm.Id == id);
            if (duty == null)
                return NotFound();
            _db.Duties.Remove(duty);
            _db.SaveChanges();
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPatch("{id:int}", Name = "UpdatePartialDuty")]
        public IActionResult UpdatePartialDuty(int id,JsonPatchDocument<DutyDTO> dutyDTO)
        {
            if (id == null)
                return BadRequest();
            var duty = _db.Duties.AsNoTracking().FirstOrDefault(elm => elm.Id == id);
            if (duty == null)
                return NotFound();
            DutyDTO dutydto_ = new()
            {
                Id = duty.Id,
                Name = duty.Name,
                Rate = duty.Rate,
                ImageUrl = duty.ImageUrl,
                Sqft = duty.Sqft,
            };
            dutyDTO.ApplyTo(dutydto_, ModelState);
            Duty duty1 = new()
            {
                Id = dutydto_.Id,
                Name = dutydto_.Name,
                Rate = dutydto_.Rate,
                ImageUrl = dutydto_.ImageUrl,
                Sqft = dutydto_.Sqft,
            };
            _db.Update(duty1);
            _db.SaveChanges();
            if(!ModelState.IsValid)
                return BadRequest();
            return NoContent();
        }
    }
}
