
namespace Core.Interface
{
    public interface IGenericRepository<T> where T: class
    {
        Task<T?> GetByIdAsync(int id);

        Task<T?> GetByGuidAsync(Guid id);
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> GetByIdWhitSpec(ISpecification<T> specification);

        Task<IReadOnlyList<T>> GetAllWhitSpec(ISpecification<T> specification);


        Task<T> Insert(T obj);
        void Update(T obj);
        Task Delete(Guid id);
        Task Delete(int id);
        Task SoftDelete(int id);

        Task SoftDeleteByGuid(Guid id);
        Task<int> SaveAsync();

    }
}
