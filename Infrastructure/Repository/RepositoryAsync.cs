using Domain.Entity;
using Domain.UseCase.Result;
using Domain.UseCases;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class RepositoryAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity : class, IEntity
    {
        public RepositoryAsync(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        private ApplicationDbContext _dbContext;

        private DbSet<TEntity> _dbSet;

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Task.FromResult(_dbSet);
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<NoteResult> InsertAsync(TEntity entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            await _dbSet.AddAsync(entity);
            return NoteResult.Success;
        }

        public async Task<NoteResult> RemoveAsync(Guid id)
        {
            TEntity? entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
            return NoteResult.Success;
        }

        public async Task<NoteResult> UpdateAsync(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            return await Task.FromResult(NoteResult.Success);
        }
    }
}
