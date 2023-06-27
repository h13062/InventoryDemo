using InventoryDemo.Core.Contract.Repositories;
using InventoryDemo.Core.Contract.Services;
using InventoryDemo.Core.Entities;
using InventoryDemo.Core.Models;
using InventoryDemo.Infrastructure.Data;
using InventoryDemo.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDemo.Infrastructure.Service
{
    public class RecordServiceAsync 
    {
        private readonly InventoryDemoDbContext _dbContext;

        public RecordServiceAsync(InventoryDemoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateRecord(int POnumber, int OrderNumber, DateTime OrderDate, DateTime DueDate, DateTime CompleteDate, string LOTnumber, int ProductCode, List<int> operatorIds, List<int> machineIds, List<int> materialIds)
        {
            var record = new Record
            {
                POnumber = POnumber,
                OrderNumber = OrderNumber,
                OrderDate = OrderDate,
                DueDate = DueDate,
                CompleteDate = CompleteDate,
                LOTnumber = LOTnumber,
                ProductCode = ProductCode,
                RecordOperators = operatorIds.Select(operatorId => new RecordOperator
                {
                    OperatorId = operatorId,
                    POnumber = POnumber
                }).ToList(),
                RecordMachines = machineIds.Select(machineId => new RecordMachine
                {
                    MachineId = machineId,
                    POnumber = POnumber
                }).ToList(),
                RecordMaterials = materialIds.Select(materialId => new RecordMaterial
                {
                    MaterialId = materialId,
                    POnumber = POnumber
                }).ToList()
            };

            _dbContext.Records.Add(record);
            _dbContext.SaveChanges();
        }


        public Record GetRecord(int POnumber)
        {
            return _dbContext.Records
                .Include(r => r.RecordOperators)
                .Include(r => r.RecordMachines)
                .Include(r => r.RecordMaterials)
                .FirstOrDefault(r => r.POnumber == POnumber);
        }

        public List<Record> GetAllRecords()
        {
            return _dbContext.Records.ToList();
        }

        public void DeleteRecord(int POnumber)
        {
            var record = _dbContext.Records.FirstOrDefault(r => r.POnumber == POnumber);
            if (record != null)
            {
                _dbContext.Records.Remove(record);
                _dbContext.SaveChanges();
            }
        }
    }
}