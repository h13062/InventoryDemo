using InventoryDemo.Core.Contract.Services;
using InventoryDemo.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialServiceAsync materialServiceAsync;
        public MaterialController(IMaterialServiceAsync materialServiceAsync)
        {
            this.materialServiceAsync = materialServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await materialServiceAsync.GetAllMaterialAsync());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await materialServiceAsync.GetByMaterialIdAsync(id);
            if (result == null)
            {
                return NotFound($"Material object with Id = {id} is not available");
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Post(MaterialRequestModel model)
        {
            var result = await materialServiceAsync.AddMaterialAsync(model);
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
            var result = await materialServiceAsync.DeleteByMaterialIdAsync(id);
            if (result != 0)
            {
                return Ok("Material was Deleted Successfully");
            }
            return BadRequest();
        }
    }
}
