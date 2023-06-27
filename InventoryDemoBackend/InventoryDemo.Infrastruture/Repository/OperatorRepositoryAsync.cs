using InventoryDemo.Core.Contract.Repositories;
using InventoryDemo.Core.Entities;
using InventoryDemo.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDemo.Infrastructure.Repository
{
    public class OperatorRepositoryAsync : BaseRepository<Operator>, IOperatorRepositoryAsync
    {
        private readonly InventoryDemoDbContext _db;
        public OperatorRepositoryAsync(InventoryDemoDbContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }
    }
}
