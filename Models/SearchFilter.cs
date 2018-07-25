using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class SearchFilter
    {
        public int Year { get; set; }
        public string Color { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public bool IsHarley { get; set; }
        public int EngineSize { get; set; }
    }
}
