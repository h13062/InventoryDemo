using InventoryDemo.Core.Entities;
using InventoryDemo.Core.Models;
using InventoryDemo.Infrastructure.Data;
using InventoryDemo.Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryDemoAPI.Controllers
{
    [ApiController]
    [Route("api/records")]
    public class RecordController : ControllerBase
    {
        private readonly RecordServiceAsync _recordService;
        private readonly InventoryDemoDbContext _dbContext;

        public RecordController(RecordServiceAsync recordService, InventoryDemoDbContext dbContext)
        {
            _recordService = recordService;
            _dbContext = dbContext;
        }
        [HttpPost]
        public IActionResult CreateRecord([FromBody] RecordRequestModel createRecordDto)
        {
            _recordService.CreateRecord(
                createRecordDto.POnumber,
                createRecordDto.OrderNumber,
                createRecordDto.OrderDate,
                createRecordDto.DueDate,
                createRecordDto.CompleteDate,
                createRecordDto.LOTnumber,
                createRecordDto.ProductCode,
                createRecordDto.OperatorIds,
                createRecordDto.MachineIds,
                createRecordDto.MaterialIds
            );

            return Ok();
        }
        [HttpGet]
        public IActionResult GetAllRecords()
        {
            var records = _recordService.GetAllRecords();

            var recordResponseModels = records.Select(record => new RecordResponseModel
            {
                POnumber = record.POnumber,
                OrderNumber = record.OrderNumber,
                OrderDate = record.OrderDate,
                DueDate = record.DueDate,
                CompleteDate = record.CompleteDate,
                LOTnumber = record.LOTnumber,
                ProductCode = record.ProductCode,
                OperatorIds = _dbContext.RecordOperators
                        .Where(ro => ro.POnumber == record.POnumber)
                        .Select(ro => ro.OperatorId)
                        .ToList(),
                MachineIds = _dbContext.RecordMachines
                        .Where(ro => ro.POnumber == record.POnumber)
                        .Select(ro => ro.MachineId)
                        .ToList(),
                MaterialIds = _dbContext.RecordMaterials
                        .Where(ro => ro.POnumber == record.POnumber)
                        .Select(ro => ro.MaterialId)
                        .ToList(),
            }).ToList();

            return Ok(recordResponseModels);
        }


        [HttpDelete("{POnumber}")]
        public IActionResult DeleteRecord(int POnumber)
        {
            _recordService.DeleteRecord(POnumber);
            return Ok();
        }
    }

}
