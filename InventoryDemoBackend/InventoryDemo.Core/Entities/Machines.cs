using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDemo.Core.Entities
{
    public class Machines
    {
        public int MachineId { get; set; }
        public string MachineName { get; set; }
        public List<Records> Record { get; set; }
        
    }
}
