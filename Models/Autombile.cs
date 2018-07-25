using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{

    public class Automobile : Vehicle
    {
        [Key]
        public int Id { get; set; }
        public int RideHigh { get; set; }
        public string Color { get; set; }
    }



}