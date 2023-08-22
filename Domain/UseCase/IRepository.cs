using Domain.UseCase.Result;

namespace Domain.UseCases
{
    public interface IRepository<IEntity>
    {
        public Task<NoteResult> SaveAsync(IEntity entity);
        public void Update(IEntity entity);
        public IEntity GetById();
        public IEnumerable<IEntity> GetAll();
        public void Delete(Guid id);
    }
}
