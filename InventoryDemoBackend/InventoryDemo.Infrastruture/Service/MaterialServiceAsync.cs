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
    public class MaterialServiceAsync : IMaterialServiceAsync
    {
        private readonly IMaterialRepositoryAsync _materialRepositoryAsync;
        public MaterialServiceAsync(IMaterialRepositoryAsync materialRepositoryAsync)
        {
            _materialRepositoryAsync = materialRepositoryAsync;
        }

        public async Task<int> AddMaterialAsync(MaterialRequestModel material)
        {
            Material ma = new Material();
            ma.MaterialId = material.MaterialId;
            ma.MaterialName = material.MaterialName;
            return await _materialRepositoryAsync.InsertAsync(ma);
        }

        public async Task<int?> DeleteByMaterialIdAsync(int id)
        {
            return await _materialRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<MaterialResponseModel>?> GetAllMaterialAsync()
        {
            var collection = await _materialRepositoryAsync.GetAllAsync();
            if (collection != null)
            {
                List<MaterialResponseModel> result = new List<MaterialResponseModel>();
                foreach (var item in collection)
                {
                    MaterialResponseModel model = new MaterialResponseModel();
                    model.MaterialId = item.MaterialId;
                    model.MaterialName = item.MaterialName;
                    result.Add(model);
                }
                return result;
            }
            return null;
        }
        public async Task<MaterialResponseModel?> GetByMaterialIdAsync(int id)
        {
            var item = await _materialRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                MaterialResponseModel model = new MaterialResponseModel();
                model.MaterialId = item.MaterialId;
                model.MaterialName=item.MaterialName;
                return model;
            }
            return null;
        }

        public async Task<int> UpdateMaterialAsync(MaterialRequestModel material)
        {
            Material ma = new Material();
            ma.MaterialId = material.MaterialId;
            ma.MaterialName = material.MaterialName;
            return await _materialRepositoryAsync.UpdateAsync(ma);
        }
    }
}
