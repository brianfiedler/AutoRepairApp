using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class WorkOrderItem
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
        public DateTime ApprovedOn { get; set; }
    }
}
