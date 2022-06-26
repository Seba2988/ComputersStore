using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Computers.Models;
using Computers.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;

namespace Computers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ComputersController : ControllerBase
    {
        private readonly IComputerRespository _computerRespository;

        public ComputersController(IComputerRespository computerRespository)
        {
            _computerRespository = computerRespository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllComputers()
        {
            var computers = await _computerRespository.GetAllComputersAsync();
            if (computers == null || computers.Count == 0) return NotFound();
            return Ok(computers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComputerById([FromRoute] int id)
        {
            var computer = await _computerRespository.GetComputerByIdAsync(id);
            if(computer == null) return NotFound();
            return Ok(computer);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewComputer([FromBody] ComputerModel computerModel)
        {
            var newComputerId =  await _computerRespository.AddComputerAsync(computerModel);
            return CreatedAtAction(nameof(GetComputerById), new {id=newComputerId, controller="computers"}, newComputerId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComputer([FromBody] ComputerModel computerModel, [FromRoute] int id)
        {
            await _computerRespository.UpdateComputerAsync(id, computerModel);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchComputer([FromBody] JsonPatchDocument computerModel, [FromRoute] int id)
        {
            await _computerRespository.UpdateComputerPatchAsync(id, computerModel);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComputer([FromRoute] int id)
        { 
            await _computerRespository.DeleteComputerAsync(id);
            return Ok();
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchComputers([FromQuery] SearchModel searchModel)
        {
            var results = await _computerRespository.GetComputersByCriteria(searchModel);
            return Ok(results);
        }

    }
}
