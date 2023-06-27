using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDemo.Core.Entities
{
    public class RecordMachine
    {
        public int POnumber { get; set; }
        public Record Record { get; set; }

        public int MachineId { get; set; }
        public Machine Machine { get; set; }
    }
}
