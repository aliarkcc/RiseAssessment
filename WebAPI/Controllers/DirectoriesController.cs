using Business.Abstract;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Redis;
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
    public class DirectoriesController : ControllerBase
    {
        ICacheService _cacheService;
        IDirectoryService _directoryService;

        public DirectoriesController(IDirectoryService directoryService)
        {
            _directoryService = directoryService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _directoryService.GetListAsync();
            if (result != null)
                return Ok(result);
            return BadRequest();
        }
        [HttpGet]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _directoryService.GetByIdAsync(id);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Add([FromBody] Directory directory)
        {
            var result = await _directoryService.AddAsync(directory);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }
        [HttpDelete]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _directoryService.DeleteAsync(id);
            if (result)
                return Ok(true);
            return BadRequest(false);
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update([FromBody] Directory directory)
        {
            var result = await _directoryService.UpdateAsync(directory);
            if (result != null)
                return Ok(result);
            return BadRequest();
        }
    }
}