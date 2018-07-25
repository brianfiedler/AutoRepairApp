using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DataAccess;

namespace WebApplication1.Controllers
{
    [Route("api/repair")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        
        
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("home")]
        public ActionResult<int> Home()
        {

            List<string> values = new List<string>();
            values.Add("Suck yourself and");
            values.Add("fuck yourself and more");
            values.Add("Suck yourself and");
            values.Add("Suck yourself and");

            return values.Distinct().Count();
        }
   

        // GET api/values
        [HttpGet("car")]
        public ActionResult<Automobile> GetCars()
        {
            Automobile myVehicles = new Automobile();
            myVehicles.Make = "Kia";
            myVehicles.Model = "Optima";
            myVehicles.Year = 2015;
            myVehicles.NumberOfAxels = 2;
            myVehicles.NumberOfPassengers = 5;
            myVehicles.Weight = 50;
            myVehicles.Color = "black";
            myVehicles.RideHigh = 6;
               
            return myVehicles;
        }


        // GET api/values
        [HttpGet("{carToSearch}")]
        public ActionResult<Automobile> GetCars(string carToSearch)
        {
            List<Automobile> autos = new List<Automobile>();

            Automobile myVehicles = new Automobile();
            myVehicles.Make = "Kia";
            myVehicles.Model = "Optima";
            myVehicles.Year = 2015;
            myVehicles.NumberOfAxels = 2;
            myVehicles.NumberOfPassengers = 5;
            myVehicles.Weight = 50;
            myVehicles.Color = "black";
            myVehicles.RideHigh = 6;
            autos.Add(myVehicles);

            Automobile myVehicles1 = new Automobile();
            myVehicles1.Make = "Kia";
            myVehicles1.Model = "Sorrento";
            myVehicles1.Year = 2013;
            myVehicles1.NumberOfAxels = 2;
            myVehicles1.NumberOfPassengers = 8;
            myVehicles1.Weight = 50;
            myVehicles1.Color = "Green";
            myVehicles1.RideHigh = 50;
            autos.Add(myVehicles1);

            //seach list of vehicles based on string passed in
            
            return autos.Where(a => a.Model.Contains(carToSearch)).FirstOrDefault();;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post()
        {

            Vehicle myFirstVehicle = new Vehicle();
            myFirstVehicle.Make = "Kia";
            myFirstVehicle.Model = "Optima";
            myFirstVehicle.Year = 2015;
            myFirstVehicle.NumberOfAxels = 2;
            myFirstVehicle.NumberOfPassengers = 5;
            myFirstVehicle.Weight = 50;

            using (var context = new AutoRepairContext())
            {
                context.Vehicles.Add(myFirstVehicle);
                context.Entry(myFirstVehicle).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                context.SaveChanges();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Vehicle updatedVehicle)
        {

            
            using (var context = new AutoRepairContext())
            {
                //get existing vehicle by id
                var existingVehicle = context.Vehicles.FirstOrDefault(a=>a.Identifier == id);

                //update existing vehicle from the db with the data passd into the api
                existingVehicle.Year = updatedVehicle.Year;
                existingVehicle.Make = updatedVehicle.Make;
                existingVehicle.Model = updatedVehicle.Model;

                //don't forget to save chagnes
                context.Entry(existingVehicle).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var context = new AutoRepairContext())
            {
                //get existing vehicle by id
                var existingVehicle = context.Vehicles.FirstOrDefault(a => a.Identifier == id);


                //don't forget to save chagnes
                context.Entry(existingVehicle).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
