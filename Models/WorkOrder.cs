using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Controllers
{

    public class WorkOrder
    {
        [Key]
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string Description { get; set; }
        public DateTime CompletedOn { get; set; }
        public DateTime EstimatedCompletionDate { get; set; }
    }



}