using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain.Common;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        //Keeping it protected so that all derived repositories can access the same context
        protected readonly HrDatabaseContext _context;

        //Getting DBContext
        public GenericRepository(HrDatabaseContext context)
        {
            this._context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync()
        {
            //Adding AsNoTracking() to disable changeTracker. This will increase the performance of Get requests from DB
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task UpdateAsync(T entity)
        {
            //Approach#1 - Use Update and save
            //_context.Update(entity);
            //await _context.SaveChangesAsync();

            //Approach#2 - Setting state to Modified
            //Mark as dirty. When we cann save changes, it will execute the SaveChanges related code we overridden at HrDatabaseContext
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
