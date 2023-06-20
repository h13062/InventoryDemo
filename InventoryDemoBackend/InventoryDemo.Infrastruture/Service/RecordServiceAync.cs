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
    public class RecordServiceAync : IRecordServiceAync
    {
        private readonly IRecordRepositoryAsync _recordRepositoryAsync;
        public RecordServiceAync(IRecordRepositoryAsync recordRepositoryAsync)
        {
            _recordRepositoryAsync = recordRepositoryAsync;
        }

        public Task<int> AddRecordAsync(RecordRequestModel record)
        {
            throw new NotImplementedException();
        }

        //public async Task<int> AddRecordAsync(RecordRequestModel record)
        //{
        //    Records r = new Records();
        //    r.PO = record.PO;
        //    r.orderNumber = record.orderNumber;
        //    r.operatorName = record.operatorName;
        //    r.operatorDatetime = DateTime.Parse(record.operatorDatetime);
        //   // r.modifyDatetime = record.modifyDatetime;
        //    r.machineName = record.machineName;
        //    r.LOTnumber = record.LOTnumber;
        //    r.productCode = record.productCode;
        //    return await _recordRepositoryAsync.InsertAsync(r);
        //}

        public async Task<int?> DeleteByIdAsync(int id)
        {
            return await _recordRepositoryAsync.DeleteAsync(id);
        }

        public Task<IEnumerable<RecordResponseModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RecordResponseModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateRecordAsync(RecordRequestModel record)
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<RecordResponseModel>> GetAllAsync()
        //{
        //    var collection = await _recordRepositoryAsync.GetAllAsync();
        //    if (collection != null)
        //    {
        //        List<RecordResponseModel> result = new List<RecordResponseModel>();
        //        foreach (var item in collection)
        //        {
        //            RecordResponseModel model = new RecordResponseModel();
        //            model.PO = item.PO;
        //            model.orderNumber = item.orderNumber;
        //            model.operatorName = item.operatorName;
        //            model.operatorDatetime = item.operatorDatetime;
        //            // model.modifyDatetime = record.modifyDatetime;
        //            model.machineName = item.machineName;
        //            model.LOTnumber = item.LOTnumber;
        //            model.productCode = item.productCode;

        //            result.Add(model);
        //        }
        //        return result;
        //    }
        //    return null;
        //}

        //public async Task<RecordResponseModel> GetByIdAsync(int id)
        //{
        //    var item = await _recordRepositoryAsync.GetByIdAsync(id);
        //    if (item != null)
        //    {
        //        RecordResponseModel model = new RecordResponseModel();
        //        model.PO = item.PO;
        //        model.orderNumber = item.orderNumber;
        //        model.operatorName = item.operatorName;
        //        model.operatorDatetime = item.operatorDatetime;
        //        // model.modifyDatetime = record.modifyDatetime;
        //        model.machineName = item.machineName;
        //        model.LOTnumber = item.LOTnumber;
        //        model.productCode = item.productCode;
        //        return model;
        //    }
        //    return null;
        //}

        //public async Task<int> UpdateRecordAsync(RecordRequestModel record)
        //{
        //    Records r = new Records();
        //    r.PO = record.PO;
        //    r.orderNumber = record.orderNumber;
        //    r.operatorName = record.operatorName;
        //    r.operatorDatetime = DateTime.Parse(record.operatorDatetime);
        //    // r.modifyDatetime = record.modifyDatetime;
        //    r.machineName = record.machineName;
        //    r.LOTnumber = record.LOTnumber;
        //    r.productCode = record.productCode;
        //    return await _recordRepositoryAsync.UpdateAsync(r);
        //}

    }
}
