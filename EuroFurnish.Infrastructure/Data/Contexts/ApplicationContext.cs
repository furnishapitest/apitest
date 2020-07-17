using EuroFurnish.ApplicationCore.Entities;
using EuroFurnish.ApplicationCore.Entities.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EuroFurnish.Infrastructure.Data.Contexts
{
    public class ApplicationContext : IdentityDbContext<AppUser,IdentityRole<long>,long, IdentityUserClaim<long>, IdentityUserRole<long>,
        IdentityUserLogin<long>, IdentityRoleClaim<long>, IdentityUserToken<long>>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relationship in builder.Model.GetEntityTypes().Where(e => !e.IsOwned()).SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(builder);

        }

        #region ChangeTrackerSetter
        public override int SaveChanges()
        {
            TrackChanges();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            TrackChanges();
            return await base.SaveChangesAsync(cancellationToken);
        }
        private Func<DateTime> TimestampProvider { get; set; } = () => DateTime.UtcNow;
        private void TrackChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted))
            {
                if (entry.Entity is IAuditEntity)
                {
                    var audiTable = entry.Entity as IAuditEntity;
                    if (entry.State == EntityState.Added)
                    {
                        audiTable.CreatedDate = TimestampProvider();
                        audiTable.IsDeleted = false;
                        audiTable.IsActive = true;
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        audiTable.UpdatedDate = TimestampProvider();
                        //audiTable.IsDeleted = false;
                        //audiTable.IsActive = true;
                    }
                    else if (entry.State == EntityState.Deleted)
                    {
                        audiTable.UpdatedDate = TimestampProvider();
                        audiTable.IsDeleted = true;
                        audiTable.IsActive = false;
                        entry.State = EntityState.Modified;
                    }
                }
            }
        }
        #endregion

    }
}
