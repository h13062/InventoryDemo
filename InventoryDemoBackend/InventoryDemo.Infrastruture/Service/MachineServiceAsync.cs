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
    public class MachineServiceAsync : IMachineServiceAsync
    {
        private readonly IMachineRepositoryAsync _machineRepositoryAsync;
        public MachineServiceAsync(IMachineRepositoryAsync machineRepositoryAsync)
        {
            _machineRepositoryAsync = machineRepositoryAsync;
        }

        public async Task<int> AddMachineAsync(MachineRequestModel machine)
        {
            Machine m = new Machine();
            m.MachineId = machine.MachineId;
            m.MachineName = machine.MachineName;
            return await _machineRepositoryAsync.InsertAsync(m);
        }

        public async Task<int?> DeleteByMachineIdAsync(int id)
        {
            return await _machineRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<MachineResponseModel>?> GetAllMachineAsync()
        {
            var collection = await _machineRepositoryAsync.GetAllAsync();
            if (collection != null)
            {
                List<MachineResponseModel> result = new List<MachineResponseModel>();
                foreach (var item in collection)
                {
                    MachineResponseModel model = new MachineResponseModel();
                    model.MachineId = item.MachineId;
                    model.MachineName = item.MachineName;
                    result.Add(model);

                }
                return result;
            }
            return null;
        }

        public async Task<MachineResponseModel?> GetByMachineIdAsync(int id)
        {
            var item = await _machineRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                MachineResponseModel model = new MachineResponseModel();
                model.MachineId = item.MachineId;
                model.MachineName = item.MachineName;
                return model;
            }
            return null;
        }

        public async Task<int> UpdateMachineAsync(MachineRequestModel machine)
        {
            Machine m = new Machine();
            m.MachineId = machine.MachineId;
            m.MachineName = machine.MachineName;
            return await _machineRepositoryAsync.UpdateAsync(m);
        }
    }
}
