using System.Collections.Generic;

namespace QIQO.Core.Contracts
{
    public interface IRepository { }

    public interface IReadWriteRepository<T> : IReadOnlyRepository<T>, IWriteOnlyRepository<T>, IRepository
        where T : class, IEntity, new() { }

    public interface IReadOnlyRepository<T> : IRepository
        where T : class, IEntity, new()
    {
        IEnumerable<T> GetAll();
        T GetByID(int entity_id);
        T GetByCode(string entity_code);
    }

    public interface IWriteOnlyRepository<T> : IRepository
        where T : class, IEntity, new()
    {
        int Insert(T entity);
        void Delete(T entity);
        int Save(T entity);
    }

}
