using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    
    public class Vehicle 
    {
        [Key]
        public int Id { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }        
        public string EngineSize { get; set; }
        public bool HasAbs { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int NumberOfAxels { get; set; }
        public int NumberOfPassengers { get; set; }
        public int RideHigh { get; set; }

        public int VehicleTypeId { get; set; }
        public virtual VehicleType VehicleType { get; set; }

        public int Weight { get; set; }
        public int Year { get; set; }
    }



}