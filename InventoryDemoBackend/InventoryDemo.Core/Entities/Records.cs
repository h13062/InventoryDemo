using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDemo.Core.Entities
{
    public class Records
    {
        public int POnumber { get; set; } //this is the ID to distinguish orders from others
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CompleteDate { get; set; }
        public string LOTnumber { get; set; }
        public int ProductCode { get; set; }
        public List<Machines> Machine { get; set; }
        public List<Operators> Operator { get; set; }
        public Material Material { get; set; }
    }
}
