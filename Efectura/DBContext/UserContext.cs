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

    //    public override Task<int> SaveChangesAsync(
    //bool acceptAllChangesOnSuccess,
    //CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        var AddedEntities = ChangeTracker.Entries()
    //            .Where(E => E.State == EntityState.Added)
    //            .ToList();

    //        AddedEntities.ForEach(E =>
    //        {
    //            E.Property("CreationDate").CurrentValue = DateTime.Now;
    //        });

    //        var EditedEntities = ChangeTracker.Entries()
    //            .Where(E => E.State == EntityState.Modified)
    //            .ToList();

    //        EditedEntities.ForEach(E =>
    //        {
    //            E.Property("LastModified").CurrentValue = DateTime.Now;
    //        });

    //        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    //    }

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
