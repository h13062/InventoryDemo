using InventoryDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDemo.Core.Contract.Services
{
    public interface IMaterialServiceAsync
    {
        Task<IEnumerable<MaterialResponseModel>> GetAllMaterialAsync();
        Task<int> AddMaterialAsync(MaterialRequestModel material);
        Task<MaterialResponseModel> GetByMaterialIdAsync(int id);
        Task<int> UpdateMaterialAsync(MaterialRequestModel material);
        Task<int?> DeleteByMaterialIdAsync(int id);
    }
}
