using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDemo.Core.Entities
{
    public class RecordOperator
    {
        public int POnumber { get; set; }
        public Record Record { get; set; }

        public int OperatorId { get; set; }
        public Operator Operator { get; set; }
    }
}
