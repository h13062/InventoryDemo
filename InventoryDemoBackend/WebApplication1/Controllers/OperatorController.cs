using InventoryDemo.Core.Contract.Services;
using InventoryDemo.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperatorController : ControllerBase
    {
        private readonly IOperatorServiceAsync operatorServiceAsync;
        public OperatorController(IOperatorServiceAsync operatorServiceAsync)
        {
            this.operatorServiceAsync = operatorServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await operatorServiceAsync.GetAllOperatorAsync());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await operatorServiceAsync.GetByOperatorIdAsync(id);
            if (result == null)
            {
                return NotFound($"Operator object with Id = {id} is not available");
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Post(OperatorRequestModel model)
        {
            var result = await operatorServiceAsync.AddOperatorAsync(model);
            if (result != 0)
            {
                return Ok(model);
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await operatorServiceAsync.DeleteByOperatorIdAsync(id);
            if (result != 0)
            {
                return Ok("Operator was Deleted Successfully");
            }
            return BadRequest();
        }

    }
}
