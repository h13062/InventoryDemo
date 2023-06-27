using InventoryDemo.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDemo.Core.Models
{
    public class RecordRequestModel
    {
        public int POnumber { get; set; }
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CompleteDate { get; set; }
        public string LOTnumber { get; set; }
        public int ProductCode { get; set; }
        public List<int> OperatorIds { get; set; }
        public List<int> MachineIds { get; set; }
        public List<int> MaterialIds { get; set; }
    }
}
