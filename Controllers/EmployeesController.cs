using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DataAccess;
using WebApplication1.Models;

namespace AutoRepsir.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    { private readonly AutoRepairContext _context = new AutoRepairContext();
        // GET api/{id}
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            //lookup Employee in database by id and return 
            return Ok(_context.Employees.FirstOrDefault(e => e.Id == id));
        }


        // GET api/search
        [HttpGet]
        public ActionResult<List<Employee>> GetCollection(SearchFilter searchCriteria)
        {
            //lookup Employee in database by filter
            var foundEmployees = _context.Employees.AsQueryable();

            //Name
            if (!string.IsNullOrEmpty(searchCriteria.SearchText))

            {
                foundEmployees = foundEmployees.Where(e => e.Name.Contains(searchCriteria.SearchText));
            }

            //City
            if (!string.IsNullOrEmpty(searchCriteria.SearchText))
            {
                foundEmployees = foundEmployees.Where(a => a.City.Contains(searchCriteria.SearchText));
            }

            //State
            if (!string.IsNullOrEmpty(searchCriteria.SearchText))
            {
                foundEmployees = foundEmployees.Where(a => a.State.Contains(searchCriteria.SearchText));
            }

            //Street1
            if (string.IsNullOrEmpty(searchCriteria.SearchText))
            {
                foundEmployees = foundEmployees.Where(e => e.Street1.Contains(searchCriteria.SearchText));
            }

            //Street2
            if (string.IsNullOrEmpty(searchCriteria.SearchText))
            {
                foundEmployees = foundEmployees.Where(e => e.Street2.Contains(searchCriteria.SearchText));
            }

            //Zip
            if (string.IsNullOrEmpty(searchCriteria.SearchText))
            {
                foundEmployees = foundEmployees.Where(e => e.Zip.Contains(searchCriteria.SearchText));
            }

            //Phone
            if (searchCriteria.SearchNumber > 0)
            {
                foundEmployees = foundEmployees.Where(c => c.Phone == searchCriteria.SearchNumber);
            }

            //Title
            if (string.IsNullOrEmpty(searchCriteria.SearchText))
            {
                foundEmployees = foundEmployees.Where(e => e.Title.Contains(searchCriteria.SearchText));
            }

            //Location
            if (string.IsNullOrEmpty(searchCriteria.SearchText))
            {
                foundEmployees = foundEmployees.Where(e => e.Location.Contains(searchCriteria.SearchText));
            }


            return Ok(foundEmployees.ToList());

        }

       
           
            

            
        

        [HttpPost]
        public ActionResult<Employee> Post([FromBody]Employee empl)
        {
            //check to make sure this Employee doesn't already exist in the database


            var isExistingEmployee = _context.Employees.Any(e => e.Id == empl.Id);

            if(isExistingEmployee)
            {
                return BadRequest("Duplicate. Employee already exists in database.");
            }

            //add to database
            _context.Employees.Add(empl);
            _context.Entry(empl).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();

            return Ok(empl);
        }


        [HttpPatch]
        public ActionResult<Employee> Patch([FromBody]Employee empl)
        {
            //check to make sure this automobile exists in the database
            var existingEmployee = _context.Employees.FirstOrDefault(e => e.Id == empl.Id);

            if (existingEmployee == null || existingEmployee.Id == 0)
            {
                return BadRequest("Employeee does not exist in database.");
            }

            //map properties to be updated
            existingEmployee.Name = empl.Name;
            existingEmployee.City = empl.City;
            existingEmployee.State = empl.State;
            existingEmployee.Street1 = empl.Street1;
            existingEmployee.Street2 = empl.Street2;
            existingEmployee.Phone = empl.Phone;
            existingEmployee.Title = empl.Title;
            existingEmployee.Location = empl.Location;

            //add to database
            _context.Entry(existingEmployee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(empl);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            //check if existing automobile in database, if so delete it
            var existingAuto = _context.Employees.FirstOrDefault(e => e.Id == id);
            _context.Entry(existingAuto).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();

            return Ok();
        }

    }
}