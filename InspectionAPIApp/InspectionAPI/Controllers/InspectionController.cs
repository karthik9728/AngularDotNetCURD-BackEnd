using AutoMapper;
using InspectionAPI.DTO;
using InspectionAPI.Model;
using InspectionAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InspectionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectionController : ControllerBase
    {
        private readonly IInspectionRepository _inspectionRepository;
        private readonly IMapper _mapper;
        public InspectionController(IInspectionRepository inspectionRepository, IMapper mapper)
        {
            _inspectionRepository = inspectionRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Inspections From Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Inspection))]
        public IActionResult GetInscpections()
        {
            var objList = _inspectionRepository.GetInspections();
            var objDto = new List<Inspection>();
            foreach (var obj in objList)
            {
                objDto.Add(_mapper.Map<Inspection>(obj));
            }
            return Ok(objDto);
        }


        /// <summary>
        /// Get Individual Inspection Data
        /// </summary>
        /// <param name="id">Inspection ID</param>
        /// <returns></returns>
        [HttpGet("{id:int}",Name = "GetInspection")]
        [ProducesResponseType(200,Type = typeof(InspectionDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public IActionResult GetInspection(int id)
        {
            var obj = _inspectionRepository.GetInspection(id);
            if(obj == null)
            {
                return NotFound();
            }
            var objDto = _mapper.Map<InspectionDto>(obj);
            return Ok(objDto);
        }

        /// <summary>
        /// Create New Inspection Data
        /// </summary>
        /// <param name="inspectionDto">Inspection Data</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InspectionDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateInspection([FromBody] InspectionDto inspectionDto)
        {
            if(inspectionDto == null)
            {
                return BadRequest(ModelState);
            }
            if (_inspectionRepository.InspectionExists(inspectionDto.Status))
            {
                ModelState.AddModelError("", "Inspection Id is Already Exists");
                return StatusCode(404, ModelState);
            }

            var inspectionObj = _mapper.Map<Inspection>(inspectionDto);

            if (!_inspectionRepository.CreateInspection(inspectionObj))
            {
                ModelState.AddModelError("", "Something went worng while creating data");
                return StatusCode(500, ModelState);
            }

            return Ok(inspectionObj);
        }


        /// <summary>
        /// Update Inspection Data
        /// </summary>
        /// <param name="id">Id of Inspection</param>
        /// <param name="updateInspectionDto">Update Inspection Data</param>
        /// <returns></returns>
        [HttpPut("{id:int}",Name = "UpdateInspection")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType (StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateInspection(int id,[FromBody] UpdateInspectionDto updateInspectionDto)
        {
            if(updateInspectionDto == null || id != updateInspectionDto.Id)
            {
                return BadRequest(ModelState);
            }

            var inspectionObj = _mapper.Map<Inspection>(updateInspectionDto);

            if (!_inspectionRepository.UpdateInspection(inspectionObj))
            {
                ModelState.AddModelError("", "Something went worng while update");
                return StatusCode(500,ModelState);
            }

            return NoContent();
        }

        /// <summary>
        /// Delete Inspection Data
        /// </summary>
        /// <param name="id">Id of Inspection</param>
        /// <returns></returns>
        [HttpDelete("{id:int}",Name = "DeleteInspection")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult DeleteInspection(int id)
        {
            if (!_inspectionRepository.InspectionExists(id))
            {
                return NotFound();
            }
            var inspectionObj = _inspectionRepository.GetInspection(id);
            if (!_inspectionRepository.DeleteInspection(inspectionObj))
            {
                ModelState.AddModelError("", $"Smomething went worng while deleting the record {inspectionObj.Id}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
