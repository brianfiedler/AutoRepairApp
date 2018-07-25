using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{

    public class Motorcycle 
    {
        [Key]
        public int Identifier { get; set; }
        public int NumberOfAxels { get; set; }
        public int Weight { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int NumberOfPassengers { get; set; }
        public int Year { get; set; }
        public string EngineSize { get; set; }
        public bool IsAHarley { get; set; }
    }



}