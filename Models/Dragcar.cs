using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Dragcar 
    {
        [Key]
        public int Id { get; set; }
        public int QtrMileTime { get; set; }
        public bool HasParachute { get; set; }
        public bool HasWheelieBar { get; set; }
        public bool HasNitrose { get; set; }
        public string FuelType { get; set; }
        public string RaceTeam { get; set; }
    }
}
