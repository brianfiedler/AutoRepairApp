using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DataAccess;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/autos")]
    [ApiController]
    public class AutomobilesController : Controller
    {
        private readonly AutoRepairContext _context = new AutoRepairContext();
        // GET api/{id}
        [HttpGet("{id}")]
        public ActionResult<Automobile> Get(int id)
        {
            //lookup Automboile in database by id and return 
            return Ok(_context.Automobiles.FirstOrDefault(a=>a.Id == id));
        }


        // GET api/search
        [HttpGet]
        public ActionResult<List<Automobile>> GetCollection(SearchFilter searchCriteria)
        {
            //lookup Automboile in database by filter
            var foundAutomobiles = _context.Automobiles.AsQueryable();
            
            //model
            if(!string.IsNullOrEmpty(searchCriteria.Model))
            {
                foundAutomobiles = foundAutomobiles.Where(a => a.Model.Contains(searchCriteria.Model));
            }

            //make
            if (!string.IsNullOrEmpty(searchCriteria.Make))
            {
                foundAutomobiles = foundAutomobiles.Where(a => a.Make.Contains(searchCriteria.Make));
            }

            //year
            if(searchCriteria.Year > 0)
            {
                foundAutomobiles = foundAutomobiles.Where(a => a.Year == searchCriteria.Year);
            }

            //color
            if (!string.IsNullOrEmpty(searchCriteria.Color))
            {
                foundAutomobiles = foundAutomobiles.Where(a => a.Year == searchCriteria.Year);
            }

            return Ok(foundAutomobiles.ToList());
        }

        [HttpPost]
        public ActionResult<Automobile> Post([FromBody]Automobile auto)
        {
            //check to make sure this automobile doesn't already exist in the database


            var isExistingAutomobile = _context.Automobiles.Any(a => a.Id == auto.Id);

            if(isExistingAutomobile)
            {
                return BadRequest("Duplicate. Automobile already exists in database.");
            }

            //add to database
            _context.Automobiles.Add(auto);
            _context.Entry(auto).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();

            return Ok(auto);
        }


        [HttpPatch]
        public ActionResult<Automobile> Patch([FromBody]Automobile auto)
        {
            //check to make sure this automobile exists in the database
            var existingAutomobile = _context.Automobiles.FirstOrDefault(a => a.Id == auto.Id);

            if (existingAutomobile == null || existingAutomobile.Id == 0)
            {
                return BadRequest("Automobile does not exist in database.");
            }

            //map properties to be updated
            existingAutomobile.Make = auto.Make;
            existingAutomobile.NumberOfAxels = auto.NumberOfAxels;
            existingAutomobile.NumberOfPassengers = auto.NumberOfPassengers;
            existingAutomobile.RideHigh = auto.RideHigh;
            existingAutomobile.Weight = auto.Weight;
            existingAutomobile.Year = auto.Year;

            //add to database
            _context.Entry(existingAutomobile).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(auto);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            //check if existing automobile in database, if so delete it
            var existingAuto = _context.Automobiles.FirstOrDefault(a => a.Id == id);
            _context.Entry(existingAuto).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();

            return Ok();
        }

    }
}
