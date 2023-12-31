﻿using InventoryDemo.Core.Contract.Repositories;
using InventoryDemo.Core.Entities;
using InventoryDemo.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDemo.Infrastructure.Repository
{
    public class MaterialRepositoryAsync : BaseRepository<Material>, IMaterialRepositoryAsync
    {
        private readonly InventoryDemoDbContext _db;

        public MaterialRepositoryAsync(InventoryDemoDbContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }
    }
}
