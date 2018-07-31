using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Facility : Domain
    {
        [Key]
        public int Id { get; set; }
        public int Fax { get; set; }

        public int StatusId { get; set; }
        public virtual Status Status { get; set; }
    }
}
