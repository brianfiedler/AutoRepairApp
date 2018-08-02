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
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AutoRepairContext _context = new AutoRepairContext();
        
        //GET api/{id}
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)

        { //look up customer in database by id and return
            return Ok(_context.Customers.FirstOrDefault(c=>c.Id == id));
        }
        
        //GET api/search 
        [HttpGet]
        public ActionResult<List<Customer>> GetCollection(SearchFilter searchCriteria)

        {
            //look customer in database by filter
            var foundCustomers = _context.Customers.AsQueryable();

            //name
            if(!string.IsNullOrEmpty(searchCriteria.SearchText))
            {
                foundCustomers = foundCustomers.Where(c => c.Name.Contains(searchCriteria.SearchText));
            }

            //number 
            if(!string.IsNullOrEmpty(searchCriteria.SearchText))
            {
                foundCustomers = foundCustomers.Where(c => c.Number == searchCriteria.SearchText);
            }

            //city
            if(!string.IsNullOrEmpty(searchCriteria.SearchText))
            {
                foundCustomers = foundCustomers.Where(c => c.City.Contains(searchCriteria.SearchText));
            }

            //state
            if(!string.IsNullOrEmpty(searchCriteria.SearchText))
            {
                foundCustomers = foundCustomers.Where(c => c.State.Contains(searchCriteria.SearchText));
            }

            //street1
            if(string.IsNullOrEmpty(searchCriteria.SearchText))
            {
                foundCustomers = foundCustomers.Where(c => c.Street1.Contains(searchCriteria.SearchText));
            }

            //street2
            if(!string.IsNullOrEmpty(searchCriteria.SearchText))
            {
                foundCustomers = foundCustomers.Where(c => c.Street1.Contains(searchCriteria.SearchText));
            }

            //Zip
            if(!string.IsNullOrEmpty(searchCriteria.SearchText))
            {
                foundCustomers = foundCustomers.Where(c => c.Zip.Contains(searchCriteria.SearchText));
            }

            //created by
            if(!string.IsNullOrEmpty(searchCriteria.SearchText))
            {
                foundCustomers = foundCustomers.Where(c => c.CreatedBy.Contains(searchCriteria.SearchText));
            }

            return Ok(foundCustomers.ToList());
        }


        [HttpPost]
        public ActionResult<Customer> Post([FromBody]Customer cust)
        {
            //check to make sure the customer dosent already exist in database

            var isExistingCustomer = _context.Customers.Any(c => c.Id == cust.Id);
            if(isExistingCustomer)
           
            {
                return BadRequest("Duplicate, Customer already in database");
            }

            //add to database
            _context.Customers.Add(cust);
            _context.Entry(cust).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();

            return Ok(cust);
        }

        [HttpPatch]
        public ActionResult<Customer> Patch([FromBody]Customer cust)
        {
            //check to make sure this automobile exists in the database
                var existingCustomer = _context.Customers.FirstOrDefault(c => c.Id == cust.Id);

                if (existingCustomer == null || existingCustomer.Id == 0)

                {
                   return BadRequest("Automobile does not exist in database.");
                }

                //map properties to be updated
                existingCustomer.Name = cust.Name;
                existingCustomer.Number = cust.Number;
                existingCustomer.State = cust.State;
                existingCustomer.City = cust.City;
                existingCustomer.Street1 = cust.Street1;
                existingCustomer.Street2 = cust.Street2;
                existingCustomer.Zip = cust.Zip;
                existingCustomer.CreatedBy = cust.CreatedBy;

                //add to database
                _context.Entry(existingCustomer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();

                return Ok(cust);
            }
            [HttpDelete("{id}")]
            public ActionResult Delete(int id)
            {
                //check if existing automobile in database, if so delete it
                var existingAuto = _context.Customers.FirstOrDefault(a => a.Id == id);
                _context.Entry(existingAuto).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _context.SaveChanges();

                return Ok();
            } 
        }




    
}