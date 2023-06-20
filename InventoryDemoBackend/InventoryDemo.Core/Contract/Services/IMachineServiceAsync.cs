using InventoryDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDemo.Core.Contract.Services
{
    public interface IMachineServiceAsync
    {   
        Task<IEnumerable<MachineResponseModel>> GetAllMachineAsync();
        Task<int> AddMachineAsync(MachineRequestModel machine);
        Task<MachineResponseModel> GetByMachineIdAsync(int id);
        Task<int> UpdateMachineAsync(MachineRequestModel machine);
        Task<int?> DeleteByMachineIdAsync(int id);
    }
}
