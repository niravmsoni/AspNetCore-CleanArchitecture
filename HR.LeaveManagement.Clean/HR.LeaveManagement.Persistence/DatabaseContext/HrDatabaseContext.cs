using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.DatabaseContext
{
    public class HrDatabaseContext : DbContext
    {
        private readonly IUserService _userService;

        public HrDatabaseContext(DbContextOptions<HrDatabaseContext> options,
            IUserService userService) : base(options)
        {
            _userService = userService;
        }

        public DbSet<LeaveType> LeaveTypes { get; set; }

        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }

        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        //Useful for seeding data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Approach#1 - All configurations inheriting from IEntityTypeConfiguration in this assembly will be automatically registered
            //Preferred approach. File for LeaveType would be present in Persistence.Configurations
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HrDatabaseContext).Assembly);

            //Approach#2 - Manually entering seed data here
            //modelBuilder.Entity<LeaveType>().HasData(
            //    new LeaveType
            //    {
            //        Id = 1,
            //        Name = "Vacation",
            //        DefaultDays = 10,
            //        DateCreated = DateTime.Now,
            //        DateModified = DateTime.Now
            //    });

            //Approach#3 - Manually seeding data for each type here.
            //modelBuilder.ApplyConfiguration(new LeaveTypeConfiguration()
            //{
            //});

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //All domain objects inherit from BaseEntity
            //Additional logic to update DateModified and DateCreated based on ChangeTracker
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                    .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                //Added auditing related implementation here
                entry.Entity.DateModified = DateTime.Now;
                entry.Entity.ModifiedBy = _userService.UserId;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                    entry.Entity.CreatedBy = _userService.UserId;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
