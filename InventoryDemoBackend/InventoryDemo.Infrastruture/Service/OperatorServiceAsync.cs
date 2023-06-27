using InventoryDemo.Core.Contract.Repositories;
using InventoryDemo.Core.Contract.Services;
using InventoryDemo.Core.Entities;
using InventoryDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDemo.Infrastructure.Service
{
    public class OperatorServiceAsync : IOperatorServiceAsync
    {
        private readonly IOperatorRepositoryAsync _operatorRepositoryAsync;
        public OperatorServiceAsync(IOperatorRepositoryAsync operatorRepositoryAsync)
        {
            _operatorRepositoryAsync = operatorRepositoryAsync;
        }
        public async Task<int> AddOperatorAsync(OperatorRequestModel op)
        {
            Operator o = new Operator();
            o.OperatorId = op.OperatorId;
            o.OperatorName = op.OperatorName;
            return await _operatorRepositoryAsync.InsertAsync(o);
        }

        public async Task<int?> DeleteByOperatorIdAsync(int id)
        {
            return await _operatorRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<OperatorResponseModel>?> GetAllOperatorAsync()
        {
            var collection = await _operatorRepositoryAsync.GetAllAsync();
            if (collection != null)
            {
                List<OperatorResponseModel> result = new List<OperatorResponseModel>();
                foreach (var item in collection)
                {
                    OperatorResponseModel model = new OperatorResponseModel();
                    model.OperatorId = item.OperatorId;
                    model.OperatorName = item.OperatorName;
                    result.Add(model);
                }
                return result; 
            }
            return null;
        }

        public async Task<OperatorResponseModel?> GetByOperatorIdAsync(int id)
        {
            var item = await _operatorRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                OperatorResponseModel model = new OperatorResponseModel();
                model.OperatorId = item.OperatorId;
                model.OperatorName = item.OperatorName;
                return model;
            }
            return null;
        }

        public async Task<int> UpdateOperatorAsync(OperatorRequestModel op)
        {
            Operator o = new Operator();
            o.OperatorId = op.OperatorId;
            o.OperatorName = op.OperatorName;
            return await _operatorRepositoryAsync.UpdateAsync(o);
        }
    }
}
