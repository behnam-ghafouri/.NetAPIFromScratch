using AutoMapper;
using Behnam_BehnamAPI.Data;
using Behnam_BehnamAPI.Model;
using Behnam_BehnamAPI.Models;
using Behnam_BehnamAPI.Repository.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Behnam_BehnamAPI.Controllers
{
    [Route("api/DutyNumber")]
    //required to have basic validation on DTO models
    [ApiController]
    public class DutyNumberController:ControllerBase
    {
        protected APIResponse _response;
        private readonly IDutyNumberRepository _dbDutyNumber;
        private readonly IMapper _mapper;
        public DutyNumberController(IDutyNumberRepository dbDutyNumber, IMapper mapper)
        {
            _dbDutyNumber = dbDutyNumber;
            _mapper = mapper;
            this._response = new();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetDutyNumbers()
        {
            IEnumerable<DutyNumber>  duties = await _dbDutyNumber.GetAll();
            _response.Result = _mapper.Map<List<DutyNumberDTO>>(duties);
            _response.httpStatusCode = System.Net.HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpGet("{id:int}",Name ="GetDutyNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetDutyNumber(int id)
        {
            if(id == 0)
                return BadRequest();
            var dutyNumber = await _dbDutyNumber.Get(elm=>elm.DutyNo==id);
            if (dutyNumber == null)
                return NotFound();
            _response.Result= _mapper.Map<DutyNumberDTO>(dutyNumber);
            return Ok(_response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreatDutyNumber([FromBody] DutyNumberDTO dutyNumberDTO)
        {
            //check the DTO validation annotations 
            //if (ModelState.IsValid)
            if(await _dbDutyNumber.Get(e=>e.DutyNo==dutyNumberDTO.DutyNo) != null)
            {
                ModelState.AddModelError("CustomError", "Is not unique");
                return BadRequest(ModelState);
            }
            if(dutyNumberDTO == null)
                return BadRequest(dutyNumberDTO);
            //if(dutyNumberDTO.DutyNo > 0)            
            //    return StatusCode(StatusCodes.Status500InternalServerError);
            await _dbDutyNumber.Creat(_mapper.Map<DutyNumber>(dutyNumberDTO));          
            return CreatedAtRoute("GetDuty",new {id=dutyNumberDTO.DutyNo}, dutyNumberDTO);         
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}",Name = "DeleteDutyNumber")]
        public async Task<IActionResult> DeleteDutyNumber(int id)
        {
            if (id == null)
                return BadRequest();
            var dutyNumber = await _dbDutyNumber.Get(elm=>elm.DutyNo==id);
            if (dutyNumber == null)
                return NotFound();
            await _dbDutyNumber.Remove(dutyNumber);
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateDutyNumber")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateDutyNumber(int id, [FromBody]DutyNumberDTO dutyNumberDTO)
        {
            if (dutyNumberDTO == null || dutyNumberDTO.DutyNo != id)
                return BadRequest();
            await _dbDutyNumber.Update(_mapper.Map<DutyNumber>(dutyNumberDTO));
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPatch("{id:int}", Name = "UpdatePartialDutyNumber")]
        public async Task<IActionResult> UpdatePartialDutyNumber(int? id,JsonPatchDocument<DutyNumberDTO> dutyNumberDTO)
        {
            if (id == null)
                return BadRequest();
            var duty = await _dbDutyNumber.Get(elm => elm.DutyNo == id);
            if (duty == null)
                return NotFound();
            DutyNumberDTO dutyDTO1 = _mapper.Map<DutyNumberDTO>(duty);
            dutyNumberDTO.ApplyTo(dutyDTO1, ModelState);
            if(!ModelState.IsValid)
                return BadRequest();
            await _dbDutyNumber.Update(_mapper.Map<DutyNumber>(dutyDTO1));
            return NoContent();
        }
    }
}
