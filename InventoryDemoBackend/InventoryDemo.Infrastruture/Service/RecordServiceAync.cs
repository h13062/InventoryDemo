using InventoryDemo.Core.Contract.Repositories;
using InventoryDemo.Core.Contract.Services;
using InventoryDemo.Core.Entities;
using InventoryDemo.Core.Models;
using InventoryDemo.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDemo.Infrastructure.Service
{
    public class RecordServiceAync : IRecordServiceAsync
    {
        private readonly IRecordRepositoryAsync _recordRepositoryAsync;
        public RecordServiceAync(IRecordRepositoryAsync recordRepositoryAsync)
        {
            _recordRepositoryAsync = recordRepositoryAsync;
        }

        public async Task<int> AddRecordAsync(RecordRequestModel record)
        {
            Records r = new Records();
            r.POnumber = record.POnumber;
            r.OrderNumber = record.OrderNumber;
            r.OrderDate = record.OrderDate;
            r.DueDate = record.DueDate;
            r.CompleteDate = record.CompleteDate;
            r.LOTnumber = record.LOTnumber;
            r.ProductCode = record.ProductCode;
            return await _recordRepositoryAsync.InsertAsync(r);
        }
        public async Task<int?> DeleteByIdAsync(int id)
        {
            return await _recordRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<RecordResponseModel>?> GetAllAsync()
        {
            var collection = await _recordRepositoryAsync.GetAllAsync();
            if (collection != null)
            {
                List<RecordResponseModel> result = new List<RecordResponseModel>();
                foreach (var item in collection)
                {
                    RecordResponseModel model = new RecordResponseModel();
                    model.POnumber = item.POnumber;
                    model.OrderNumber = item.OrderNumber;
                    model.OrderDate = item.OrderDate;
                    model.DueDate = item.DueDate;
                    model.CompleteDate = item.CompleteDate;
                    model.LOTnumber = item.LOTnumber;
                    model.ProductCode = item.ProductCode;
                    result.Add(model);

                }
                return result;
            }
            return null;
        }

        public async Task<RecordResponseModel?> GetByIdAsync(int id)
        {
            var item = await _recordRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                RecordResponseModel model = new RecordResponseModel();
                model.POnumber = item.POnumber;
                model.OrderNumber = item.OrderNumber;
                model.OrderDate= item.OrderDate;
                model.DueDate= item.DueDate;
                model.CompleteDate= item.CompleteDate;
                model.LOTnumber= item.LOTnumber;
                model.ProductCode= item.ProductCode;
                return model;
            }
            return null;
        }

        public async Task<int> UpdateRecordAsync(RecordRequestModel record)
        {
            Records r = new Records();
            r.POnumber = record.POnumber;
            r.OrderNumber = record.OrderNumber;
            r.OrderDate = record.OrderDate;
            r.DueDate = record.DueDate;
            r.CompleteDate = record.CompleteDate;
            r.LOTnumber = record.LOTnumber;
            r.ProductCode = record.ProductCode;
            return await _recordRepositoryAsync.UpdateAsync(r);
        }

    }
}
