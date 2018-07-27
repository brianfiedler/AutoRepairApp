using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DataAccess;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/motorcycles")]
    [ApiController]
    public class MotorcyclesController : Controller


    {
        private readonly AutoRepairContext _context = new AutoRepairContext();
        //GET api/{id}
        [HttpGet("{id}")]
        public ActionResult<Motorcycle> Get(int id)

        {
            //lookup Motorcycle in database by id and return
            return Ok(_context.Motorcycles.FirstOrDefault(m => m.Id == id));

        }


        // GET api/search
        [HttpGet]
        public ActionResult<List<Motorcycle>> GetCollection(SearchFilter searchCriteria)
        {
            //lookup Motorcycles in database filter
            var foundMotorcycles = _context.Motorcycles.AsQueryable();

            //model
            if (!string.IsNullOrEmpty(searchCriteria.Model))
            {
                foundMotorcycles = foundMotorcycles.Where(m => m.Model.Contains(searchCriteria.Model));
            }

            //make
            if (!string.IsNullOrEmpty(searchCriteria.Make))

            {
                foundMotorcycles = foundMotorcycles.Where(m => m.Make.Contains(searchCriteria.Make));
            }

            //year
            if (searchCriteria.Year > 0)

            {
                foundMotorcycles = foundMotorcycles.Where(m => m.Year == searchCriteria.Year);
            }

            //color
            if (!string.IsNullOrEmpty(searchCriteria.Color))

            {
                foundMotorcycles = foundMotorcycles.Where(m => m.Color == searchCriteria.Color);
            }


            return Ok(foundMotorcycles.ToList());

        }


        [HttpPost]
        public ActionResult<Motorcycle> Post([FromBody]Motorcycle moto)
        {
            //chjeck to make sure this motorcycle dosen't already exist in the database


            var isExistingMotorcycle = _context.Motorcycles.Any(m => m.Id == moto.Id);

            if (isExistingMotorcycle)
            {

                return BadRequest("Duplicate. Motorcycle already exists in database");
            }

            //add to database
            _context.Motorcycles.Add(moto);
            _context.Entry(moto).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();

            return Ok(moto);

        }


        [HttpPatch]
        public ActionResult<Motorcycle> Patch([FromBody]Motorcycle moto)
        {
            //check to make sure this motorcycle exists in the database
            var existingMotorcycle = _context.Motorcycles.FirstOrDefault(m => m.Id == moto.Id);

            if (existingMotorcycle == null || existingMotorcycle.Id == 0)
            {
                return BadRequest("Motorcycle dose not exist in database.");
            }

            //map properties to be updated
            existingMotorcycle.Make = moto.Make;
            existingMotorcycle.Model = moto.Model;
            existingMotorcycle.Year = moto.Year;
            existingMotorcycle.Weight = moto.Weight;
            existingMotorcycle.NumberOfAxels = moto.NumberOfAxels;
            existingMotorcycle.NumberOfPassengers = moto.NumberOfPassengers;
            existingMotorcycle.IsAHarley = moto.IsAHarley;
            existingMotorcycle.EngineSize = moto.EngineSize;
            existingMotorcycle.Id = moto.Id;


            //add to database
            _context.Entry(existingMotorcycle).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();


            return Ok(moto);

        }
        [HttpDelete ("[id}")]
        public ActionResult Delete(int id)
        {
            //check if existing motorcycle is in database, if so delete it
            var existingMoto = _context.Motorcycles.FirstOrDefault(m => m.Id == id);
            _context.Entry(existingMoto).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();

            return Ok();
        }
  
    }

}
