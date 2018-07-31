using System;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class Customer : Domain
    {
        [Key]
        public int Id { get; set; }

        public int StatusId { get; set; }
        public virtual Status Status { get; set; }
    }



}