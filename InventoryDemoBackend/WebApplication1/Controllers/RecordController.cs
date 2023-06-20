﻿using InventoryDemo.Core.Contract.Services;
using InventoryDemo.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private readonly IRecordServiceAsync recordServiceAsync;
        public RecordController(IRecordServiceAsync recordServiceAsync)
        {
            this.recordServiceAsync = recordServiceAsync;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await recordServiceAsync.GetAllAsync());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await recordServiceAsync.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound($"Record object with Id = {id} is not available");
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Post(RecordRequestModel model)
        {
            var result = await recordServiceAsync.AddRecordAsync(model);
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
            var result = await recordServiceAsync.DeleteByIdAsync(id);
            if (result != 0)
            {
                return Ok("Record was Deleted Successfully");
            }
            return BadRequest();
        }
    }
}
