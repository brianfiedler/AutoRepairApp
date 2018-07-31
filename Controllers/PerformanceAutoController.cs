using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DataAccess;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/performanceauto")]
    [ApiController]
    public class PerformanceAutoController : ControllerBase

    {
        private readonly AutoRepairContext _context = new AutoRepairContext();
        //GET api/{id}
        [HttpGet("{id}")]
        public ActionResult<PerformanceAuto> Get(int id)

        {
            //look up any perfoprmance autos in database by id and return
            return Ok(_context.PerformanceAutos.FirstOrDefault(pa => pa.Id == id));
        }

        //GET api/search
        [HttpGet]
        public ActionResult<List<PerformanceAuto>> GetCollection(SearchFilter searchCriteria)
        {
            //lookup performance autos in database filter
            var foundPerformanceAutos = _context.PerformanceAutos.AsQueryable();

            //workorder number
            if (searchCriteria.SearchNumber > 0)

            {
                foundPerformanceAutos = foundPerformanceAutos.Where(pa => pa.WorkorderNumber == searchCriteria.SearchNumber);
            }

            //model
            if (!string.IsNullOrEmpty(searchCriteria.Make))

            {
                foundPerformanceAutos = foundPerformanceAutos.Where(pa => pa.Make.Contains(searchCriteria.Make));
            }

            //make
            if (!string.IsNullOrEmpty(searchCriteria.Model))
            {
                foundPerformanceAutos = foundPerformanceAutos.Where(pa => pa.Model.Contains(searchCriteria.Model));
            }

            //year
            if (searchCriteria.Year > 0)
            {
                foundPerformanceAutos = foundPerformanceAutos.Where(pa => pa.Year == searchCriteria.Year);
            }

            //miles
            if (searchCriteria.SearchNumber > 0)
            {
                foundPerformanceAutos = foundPerformanceAutos.Where(pa => pa.Miles == searchCriteria.SearchNumber);
            }

            //color
            if (!string.IsNullOrEmpty(searchCriteria.Color))
            {
                foundPerformanceAutos = foundPerformanceAutos.Where(pa => pa.Color.Contains(searchCriteria.Color));
            }

            //RaceTeam
            if (!string.IsNullOrEmpty(searchCriteria.SearchText))
            {
                foundPerformanceAutos = foundPerformanceAutos.Where(pa => pa.RaceTeam.Contains(searchCriteria.SearchText));
            }

            //Torque
            if (searchCriteria.SearchNumber > 0)
            {
                foundPerformanceAutos = foundPerformanceAutos.Where(pa => pa.Torque == (searchCriteria.SearchNumber));
            }


            return Ok(foundPerformanceAutos.ToList());
       

        }



        [HttpPost]
        public ActionResult<PerformanceAuto> Post([FromBody]PerformanceAuto moto)
        {
            //chjeck to make sure this PerformanceAuto dosen't already exist in the database


            var isExistingPerformanceAuto = _context.PerformanceAutos.Any(m => m.Id == moto.Id);

            if (isExistingPerformanceAuto)
            {

                return BadRequest("Duplicate. PerformanceAuto already exists in database");
            }

            //add to database
            _context.PerformanceAutos.Add(moto);
            _context.Entry(moto).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();

            return Ok(moto);

        }


        [HttpPatch]
        public ActionResult<PerformanceAuto> Patch([FromBody]PerformanceAuto moto)
        {
            //check to make sure this PerformanceAuto exists in the database
            var existingPerformanceAuto = _context.PerformanceAutos.FirstOrDefault(m => m.Id == moto.Id);

            if (existingPerformanceAuto == null || existingPerformanceAuto.Id == 0)
            {
                return BadRequest("PerformanceAuto dose not exist in database.");
            }

            //map properties to be updated
            existingPerformanceAuto.Make = moto.Make;
            existingPerformanceAuto.Model = moto.Model;
            existingPerformanceAuto.Year = moto.Year;
            existingPerformanceAuto.Weight = moto.Weight;
            existingPerformanceAuto.NumberOfAxels = moto.NumberOfAxels;
            existingPerformanceAuto.NumberOfPassengers = moto.NumberOfPassengers;
            existingPerformanceAuto.Id = moto.Id;


            //add to database
            _context.Entry(existingPerformanceAuto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();


            return Ok(moto);

        }
        [HttpDelete("[id}")]
        public ActionResult Delete(int id)
        {
            //check if existing PerformanceAuto is in database, if so delete it
            var existingMoto = _context.PerformanceAutos.FirstOrDefault(m => m.Id == id);
            _context.Entry(existingMoto).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();

            return Ok();
        }







    }
}