using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{

    public class Automobile 
    {
        [Key]
        public int Identifier { get; set; }
        public int NumberOfAxels { get; set; }
        public int Weight { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int NumberOfPassengers { get; set; }
        public int Year { get; set; }
        public int RideHigh { get; set; }
        public string Color { get; set; }
    }



}