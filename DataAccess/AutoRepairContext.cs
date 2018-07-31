using Microsoft.EntityFrameworkCore;

using System.Data.Common;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Controllers;
using WebApplication1.Models;

namespace WebApplication1.DataAccess
{
    public class AutoRepairContext : DbContext
    {

        public AutoRepairContext() 
        {
            
        }

        //public virtual DbSet<Vehicle> Vehicles { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Facility> Facilities { get; set; }
        public virtual DbSet<Insurance> Insurance { get; set; }
        public virtual DbSet<RepairGroup> RepairGroups { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<VehicleType> VehicleTypes { get; set; }
        public virtual DbSet<WorkOrderItem> WorkOrderItems { get; set; }
        public virtual DbSet<WorkOrder> WorkOrders { get; set; }
        


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AutoRepair;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<WorkOrder>().HasOne(a=>a.Status).WithOne(p => p.WorkOrder).OnDelete(DeleteBehavior.Delete);
            //modelBuilder.Entity<Vehicle>().HasKey(c => c.Identifier);
            //modelBuilder.Entity<Automobile>().HasKey(c => c.Id);
            //modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            //modelBuilder.Entity<Motorcycle>().HasKey(c => c.Id);
            //modelBuilder.Entity<WorkOrder>().HasKey(c => c.Id);
            var cascadeFKs = modelBuilder.Model.GetEntityTypes("Status")
             .SelectMany(t => t.GetForeignKeys())
             .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            var cascadeFKsWorkOrder = modelBuilder.Model.GetEntityTypes("WorkOrder")
                 .SelectMany(t => t.GetForeignKeys())
                 .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKsWorkOrder)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            var cascadeFKsWorkOrderItem = modelBuilder.Model.GetEntityTypes("WorkOrderItem")
                 .SelectMany(t => t.GetForeignKeys())
                 .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKsWorkOrderItem)
                fk.DeleteBehavior = DeleteBehavior.Restrict;


            modelBuilder.Ignore<Automobile>();
            modelBuilder.Ignore<Motorcycle>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
