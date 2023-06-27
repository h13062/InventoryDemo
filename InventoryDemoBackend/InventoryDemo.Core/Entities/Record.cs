using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDemo.Core.Entities
{
    public class Record
    {

        [Key]
        public int POnumber { get; set; } //this is the ID to distinguish orders from others
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CompleteDate { get; set; }
        public string LOTnumber { get; set; }
        public int ProductCode { get; set; }
        public List<RecordMachine> RecordMachines { get; set; } 
        public List<RecordOperator> RecordOperators { get; set; }
        public List<RecordMaterial> RecordMaterials { get; set; } 
    }
}
