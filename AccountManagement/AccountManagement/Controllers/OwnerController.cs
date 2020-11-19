using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataLayer.DataTransferObjects;
using DataLayer.DomainModels;
using IRepository.IRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountManagement.Controllers
{
    [Route("api/owner")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        //ApplicationDbContext db = new ApplicationDbContext();
        public OwnerController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllOwners()
        {
            //return NotFound();
            //return StatusCode(500, "Internal Error");
            try
            {
                var owners = _repository.Owner.GetAllOwners();
                _logger.LogInfo($"Returned all owners from database");

                var ownerResults = _mapper.Map<IEnumerable<OwnerDto>>(owners);
                return Ok(ownerResults);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        //[HttpGet("{id}",Name ="OwnerById")]
        //public IActionResult GetOwnerById(Guid id)
        //{
        //    try
        //    {
        //        var owner = _repository.Owner.GetOwnerById(id);
        //        if (owner == null)
        //        {
        //            _logger.LogError($"Owner with id: {id} has not been found in db.");
        //            return NotFound();
        //        }
        //        else
        //        {
        //            _logger.LogInfo($"Returned Owner with id : {id}.");
        //            var ownerResult = _mapper.Map<OwnerDto>(owner);
        //            return Ok(ownerResult);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
        //        return StatusCode(500, "Internal Server Error");
        //    }
        //}

        [HttpGet("{id}")]
        public IActionResult GetOwnerWithDetails(Guid id)
        {
            try
            {
                var owner = _repository.Owner.GetOwnerWithDetails(id);
                if (owner == null)
                {
                    _logger.LogError($"Owner with id: {id}, has not been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned Owner with details for id: {id}");
                    var ownerResult = _mapper.Map<OwnerDto>(owner);
                    return Ok(ownerResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerWithDetails action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost]
        public IActionResult CreateOwner([FromBody]OwnerForCreatingDto owner)
        {
            try
            {
                if (owner == null)
                {
                    _logger.LogError("Owner object sent from client is null");
                    return BadRequest("Owner object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client");
                    return BadRequest("Invalid model object");
                }

                var ownerEntity = _mapper.Map<Owner>(owner);

                _repository.Owner.CreateOwner(ownerEntity);
                _repository.Save();

                var createdOwner = _mapper.Map<OwnerDto>(ownerEntity);
                return CreatedAtRoute("OwnerById", new { id = createdOwner.Id },createdOwner);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside created owner action: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOwner(Guid id, [FromBody]OwnerForUpdateDto owner)
        {
            try
            {
                if (owner == null)
                {
                    _logger.LogError("Owner object sent from client is null");
                    return BadRequest("Owner object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var ownerEntity = _repository.Owner.GetOwnerById(id);
                if (ownerEntity == null)
                {
                    _logger.LogError($"Owner with id: {id}, has not been found in db");
                    return NotFound();
                }
                _mapper.Map(owner, ownerEntity);

                _repository.Owner.UpdateOwner(ownerEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeletOwner(Guid id)
        {
            try
            {
                var owner = _repository.Owner.GetOwnerById(id);
                if (owner == null)
                {
                    _logger.LogError($"Owner with id: {id}, has not been found in db");
                    return NotFound();
                }

                //returning bad request in stead of internal server error
                if (_repository.Account.AccountByOwner(id).Any())
                {
                    _logger.LogError($"Cannot delete owner with id: {id}. It has related accounts. Delete those accounts first");
                    return BadRequest("Cannot delete owner. It has related accounts. Delete those accounts first");
                }

                _repository.Owner.DeleteOwner(owner);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteOwner Action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
