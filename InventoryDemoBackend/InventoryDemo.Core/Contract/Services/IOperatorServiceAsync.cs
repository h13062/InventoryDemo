using InventoryDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDemo.Core.Contract.Services
{
    public interface IOperatorServiceAsync
    {
        Task<IEnumerable<OperatorResponseModel>> GetAllOperatorAsync();
        Task<int> AddOperatorAsync(OperatorRequestModel op);
        Task<OperatorResponseModel> GetByOperatorIdAsync(int id);
        Task<int> UpdateOperatorAsync(OperatorRequestModel op);
        Task<int?> DeleteByOperatorIdAsync(int id);
    }
}
