using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfosController : ControllerBase
    {

        IContactInfoService _contactInfoService;

        public ContactInfosController(IContactInfoService contactInfoService)
        {
            _contactInfoService = contactInfoService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _contactInfoService.GetListAsync();
            if (result != null)
                return Ok(result);
            return BadRequest();
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetDirectoryDetailDto(int id)
        {
            var result = _contactInfoService.GetDirectoryDetailDto(id);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }
        [HttpGet]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _contactInfoService.GetByIdAsync(id);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Add([FromBody] ContactInfo contactInfo)
        {
            var result = await _contactInfoService.AddAsync(contactInfo);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }
        [HttpDelete]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _contactInfoService.DeleteAsync(id);
            if (result)
                return Ok(true);
            return BadRequest(false);
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update([FromBody] ContactInfo contactInfo)
        {
            var result = await _contactInfoService.UpdateAsync(contactInfo);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }
    }
}