using AutoMapper;
using Behnam_BehnamAPI.Data;
using Behnam_BehnamAPI.Model;
using Behnam_BehnamAPI.Models;
using Behnam_BehnamAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Behnam_BehnamAPI.Controllers
{
    [Route("api/Duty")]
    //required to have basic validation on DTO models
    [ApiController]
    public class DutyController:ControllerBase
    {
        protected APIResponse _response;
        private readonly IDutyRepository _dbDuty;
        private readonly IMapper _mapper;
        public DutyController(IDutyRepository dbDuty, IMapper mapper)
        {
            _dbDuty = dbDuty;
            _mapper = mapper;
            this._response = new();
        }
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetDuties()
        {
            IEnumerable<Duty>  duties = await _dbDuty.GetAll();
            _response.Result = _mapper.Map<List<DutyDTO>>(duties);
            _response.httpStatusCode = System.Net.HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpGet("{id:int}",Name ="GetDuty")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DutyDTO?>> GetDuty(int id)
        {
            if(id == 0)
                return BadRequest();
            var duty = await _dbDuty.Get(elm=>elm.Id==id);
            if (duty == null)
                return NotFound();
            return Ok(_mapper.Map<DutyDTO>(duty));
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DutyDTO>> CreatDuty([FromBody] DutyDTO dutyDTO)
        {
            //check the DTO validation annotations 
            //if (ModelState.IsValid)
            if(await _dbDuty.Get(e=>e.Name.ToLower()==dutyDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "Is not unique");
                return BadRequest(ModelState);
            }
            if(dutyDTO == null)
                return BadRequest(dutyDTO);
            if(dutyDTO.Id > 0)            
                return StatusCode(StatusCodes.Status500InternalServerError);
            await _dbDuty.Creat(_mapper.Map<Duty>(dutyDTO));          
            return CreatedAtRoute("GetDuty",new {id=dutyDTO.Id},dutyDTO);         
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}",Name = "DeleteDuty")]
        [Authorize(Roles = "custom")]
        public async Task<IActionResult> DeleteDuty(int id)
        {
            if (id == null)
                return BadRequest();
            var duty = await _dbDuty.Get(elm=>elm.Id==id);
            if (duty == null)
                return NotFound();
            await _dbDuty.Remove(duty);
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateDuty")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateDuty(int id, [FromBody]DutyDTO dutyDTO)
        {
            if (dutyDTO == null || dutyDTO.Id != id)
                return BadRequest();
            await _dbDuty.Update(_mapper.Map<Duty>(dutyDTO));
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPatch("{id:int}", Name = "UpdatePartialDuty")]
        public async Task<IActionResult> UpdatePartialDuty(int? id,JsonPatchDocument<DutyDTO> dutyDTO)
        {
            if (id == null)
                return BadRequest();
            var duty = await _dbDuty.Get(elm => elm.Id == id);
            if (duty == null)
                return NotFound();
            DutyDTO dutyDTO1 = _mapper.Map<DutyDTO>(duty);
            dutyDTO.ApplyTo(dutyDTO1, ModelState);
            if(!ModelState.IsValid)
                return BadRequest();
            await _dbDuty.Update(_mapper.Map<Duty>(dutyDTO1));
            return NoContent();
        }
    }
}
