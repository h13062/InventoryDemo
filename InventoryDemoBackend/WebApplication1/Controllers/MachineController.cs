using InventoryDemo.Core.Contract.Services;
using InventoryDemo.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineController : ControllerBase
    {
        private readonly IMachineServiceAsync machineServiceAsync;
        public MachineController(IMachineServiceAsync machineServiceAsync)
        {
            this.machineServiceAsync = machineServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await machineServiceAsync.GetAllMachineAsync());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await machineServiceAsync.GetByMachineIdAsync(id);
            if (result == null)
            {
                return NotFound($"Machine object with Id = {id} is not available");
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Post(MachineRequestModel model)
        {
            var result = await machineServiceAsync.AddMachineAsync(model);
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
            var result = await machineServiceAsync.DeleteByMachineIdAsync(id);
            if (result != 0)
            {
                return Ok("Machine was Deleted Successfully");
            }
            return BadRequest();
        }
    }
}
