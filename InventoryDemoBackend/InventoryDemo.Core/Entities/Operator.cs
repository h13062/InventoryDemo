using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDemo.Core.Entities
{
    public class Operator
    {
        public int OperatorId { get; set; }
        public string OperatorName { get; set; }
        public List<RecordOperator> RecordOperators { get; set; }
    }
}
