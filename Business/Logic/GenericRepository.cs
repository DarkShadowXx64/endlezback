using Business.Data;
using Core.Interface;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace Business.Logic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EcomerceDbContext _context;

        public GenericRepository(EcomerceDbContext context)
        {
            _context = context;
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdWhitSpec(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllWhitSpec(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync();

        }

        private IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), specification);
        }
        public async Task<T> Insert(T obj)
        {
            await _context.Set<T>().AddAsync(obj);
            await SaveAsync();
            return obj;
        }
        public void Update(T obj)
        {
            _context.Set<T>().Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            T? existing = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(existing);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<T?> GetByGuidAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);


        }

        public async Task Delete(Guid id)
        {
            T? existing = await _context.Set<T>().FindAsync(id);
            if (existing == null)
            {
                throw new ArgumentException($"Entity with ID {id} not found.");
            }

            _context.Set<T>().Remove(existing);
            await SaveAsync();
        }


        public async Task SoftDelete(int id)
        {
            T? existing = await _context.Set<T>().FindAsync(id);

            if (existing != null)
            {
                PropertyInfo isDeletedProp = typeof(T).GetProperty("IsDeleted")!;
                if (isDeletedProp != null && isDeletedProp.PropertyType == typeof(bool))
                {
                    isDeletedProp.SetValue(existing, true);
                    PropertyInfo deletedDateProp = typeof(T).GetProperty("DeletedDate")!;
                    if (deletedDateProp != null && deletedDateProp.PropertyType == typeof(DateTime))
                    {
                        deletedDateProp.SetValue(existing, DateTime.UtcNow); // O la fecha actual que desees
                    }
                    _context.SaveChanges();
                }

            }

        }


        public async Task SoftDeleteByGuid(Guid id)
        {
            T? existing = await _context.Set<T>().FindAsync(id);

            if (existing != null)
            {
                PropertyInfo isDeletedProp = typeof(T).GetProperty("IsDeleted")!;
                if (isDeletedProp != null && isDeletedProp.PropertyType == typeof(bool))
                {
                    isDeletedProp.SetValue(existing, true);
                    //PropertyInfo deletedDateProp = typeof(T).GetProperty("DeletedDate")!;
                   // deletedDateProp.SetValue(existing, DateTime.UtcNow); // O la fecha actual que desees
                    _context.SaveChanges();
                }

            }
        }
    }
}
