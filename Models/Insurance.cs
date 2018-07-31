using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Insurance : Domain
    {
        [Key]
        public int Id { get; set; }
        public string ContactName { get; set; }
        public int ContactPhone { get; set; }
        public string Identifier { get; set; }
    }
}
