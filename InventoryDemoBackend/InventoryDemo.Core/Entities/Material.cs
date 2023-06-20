using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDemo.Core.Entities
{
    public class Material
    {
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public List<Records> Record { get; set; }
    }
}
