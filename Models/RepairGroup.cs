using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class RepairGroup
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
    }
}
