using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Efectura.Model;
using Microsoft.EntityFrameworkCore;

namespace Efectura.DBContext
{
    public class UserContext : DbContext
    {

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }


        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {  
        }


        // Override Save Method for update LastModified field for every record.
        public override int SaveChanges()
        {
            DateTime saveTime = DateTime.Now;
            foreach (var entry in this.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified))
            {
 
                    entry.Property("LastModified").CurrentValue = saveTime;
            }
            return base.SaveChanges();
        }
    }
}
