using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDemo.Core.Models
{
    public class RecordResponseModel
    {
        public int POnumber { get; set; }
        public int OrderNumber { get; set; }
        public string OperatorName { get; set; }
        public DateTime OperatorDatetime { get; set; }
        public DateTime? Modifytime { get; set; }
        public string MachineName { get; set; }
        public int LOTnumber { get; set; }
        public int ProductCode { get; set; }
    }
}
