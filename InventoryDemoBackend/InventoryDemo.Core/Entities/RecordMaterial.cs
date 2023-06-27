using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDemo.Core.Entities
{
    public class RecordMaterial
    {
        public int MaterialId { get; set; }
        public Material Material { get; set; }

        public int POnumber { get; set; }
        public Record Record { get; set; }
    }
}
