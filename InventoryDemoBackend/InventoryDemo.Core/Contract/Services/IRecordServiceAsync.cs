using InventoryDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDemo.Core.Contract.Services
{
    public interface IRecordServiceAsync
    {
        Task<IEnumerable<RecordResponseModel>> GetAllAsync();
        Task<int> AddRecordAsync(RecordRequestModel record);
        Task<RecordResponseModel> GetByIdAsync(int id);
        Task<int> UpdateRecordAsync(RecordRequestModel record);
        Task<int?> DeleteByIdAsync(int id);
    }
}
