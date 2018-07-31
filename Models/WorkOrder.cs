using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class WorkOrder
    {
        [Key]
        public int Id { get; set; }
        public string Adjuster { get; set; }
        public DateTime CompletedOn { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }

        public int CustomerId { get; set; }
        [Required]
        public virtual Customer Customer { get; set; }

        public string Description { get; set; }
        public DateTime EstimatedCompletionDate { get; set; }
        public virtual Insurance Insurance { get; set; }
        public string License { get; set; }
        public int MilageIn { get; set; }
        public int MilageOut { get; set; }
        public string OrderNumber { get; set; }

        public int StatusId { get; set; }
        public virtual Status Status { get; set; }

        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        public string Vin { get; set; }

        [Required]
        public virtual List<WorkOrderItem> WorkOrderItems { get; set; }

    }
}