using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InventoryDemo.Models.DataModels;

namespace InventoryDemo.Data
{
    public class InventoryDemoContext : DbContext
    {
        public InventoryDemoContext (DbContextOptions<InventoryDemoContext> options)
            : base(options)
        {
        }

        public DbSet<InventoryDemo.Models.DataModels.CompanyInfo> CompanyInfo { get; set; }
        public DbSet<InventoryDemo.Models.DataModels.Customer> Customer { get; set; }
        public DbSet<InventoryDemo.Models.DataModels.Login> Login { get; set; }
        public DbSet<InventoryDemo.Models.DataModels.Product> Product { get; set; }
        public DbSet<InventoryDemo.Models.DataModels.PurchasedProduct> PurchasedProduct { get; set; }
        public DbSet<InventoryDemo.Models.DataModels.Register> Register { get; set; }
        public DbSet<InventoryDemo.Models.DataModels.Sale> Sale { get; set; }
        public DbSet<InventoryDemo.Models.DataModels.Salesman> Salesman { get; set; }
        public DbSet<InventoryDemo.Models.DataModels.UserData> UserData { get; set; }
    }
}
