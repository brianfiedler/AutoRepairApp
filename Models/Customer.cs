using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Controllers
{

    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public string Number { get; set; }
        public int Phone { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }

    }



}