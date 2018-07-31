using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Tuner : Dragcar
    {
        [Key]
        public new int Id { get; set; }
        public bool HasBodykit { get; set; }
        public bool Hasturbo { get; set; }
        public bool HasSupercharger { get; set; }
        public bool HasAirbags { get; set; }
        public string RacingTeam { get; set; }
        public string PriorBuildShop { get; set; }
        public int RideHigh { get; set; }
        public string Color { get; set; }
        public int NumberOfAxels { get; set; }
        public int Weight { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int NumberOfPassengers { get; set; }
        public int Year { get; set; }
        public int Miles { get; set; }
        public int Horsepower { get; set; }
        public int Torque { get; set; }
        public int ZeroToSixteyTime { get; set; }
        public int TopSpeed { get; set; }



    }
}
