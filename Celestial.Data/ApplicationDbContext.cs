using Celestial.Entities.Common;
using Common.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Celestial.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Add your custom model configurations here


            // Get the assembly containing the entities
            var entitiesAssembly = typeof(IEntity).Assembly;
            // Register all entities that inherit from IBaseEntity or BaseEntity
            modelBuilder.RegisterAllEntities<IEntity>(entitiesAssembly);
            // Register all IEntityTypeConfiguration
            modelBuilder.RegisterEntityTypeConfiguration(entitiesAssembly);
            // Set DeleteBehavior.Restrict by default for relations
            modelBuilder.AddRestrictDeleteBehaviorConvention();
            // Set SequentialGuid for Id by default
            modelBuilder.AddSequentialGuidForIdConvention();
            // Set PluralizingTableNameConvention for table names
            modelBuilder.AddPluralizingTableNameConvention();

        }
        public override int SaveChanges()
        {
            _cleanString();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            _cleanString();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            _cleanString();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            _cleanString();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void _cleanString()
        {
            var changedEntities = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);
            foreach (var item in changedEntities)
            {
                if (item.Entity == null)
                    continue;

                var properties = item.Entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.CanRead && p.CanWrite && p.PropertyType == typeof(string));

                foreach (var property in properties)
                {
                    var propName = property.Name;
                    var val = (string)property.GetValue(item.Entity, null);

                    if (val.HasValue())
                    {
                        var newVal = val.Fa2En().FixPersianChars();
                        if (newVal == val)
                            continue;
                        property.SetValue(item.Entity, newVal, null);
                    }
                }
            }
        }

    }
}
