using Domain.Entity;
using Domain.UseCase.Result;

namespace Domain.UseCases
{
    public interface IRepositoryAsync<TEntity> where TEntity : class, IEntity
    {
        Task<NoteResult> InsertAsync(TEntity entity);
        Task<NoteResult> UpdateAsync(TEntity entity);
        Task<NoteResult> RemoveAsync(Guid id);
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
    }
}
