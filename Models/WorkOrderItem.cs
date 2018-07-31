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
        public DateTime ApprovedOn { get; set; }
        public double Cost { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }

        public double EstimatedLabor { get; set; }
        public double EstimatedPaint { get; set; }
        public DateTime? LaborCompleted { get; set; }
        public DateTime? LaborStarted { get; set; }
        public DateTime? RefinishCompleted { get; set; }
        public DateTime? RefinishStarted { get; set; }
        public int Quantity { get; set; }

        public int RepairGroupId { get; set; }
        public virtual RepairGroup RepairGroup { get; set; }

        public int StatusId { get; set; }
        public virtual Status Status { get; set; }

        public string VendorIdentifier { get; set; }
    }
}
