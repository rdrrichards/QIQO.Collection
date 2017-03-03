using QIQO.Core.Contracts;
using System.Collections.Generic;
using System.Data.Common;

namespace QIQO.Data
{
    public abstract class ReadWriteRepositoryBase<T> : RepositoryBase<T>, IReadWriteRepository<T>
        where T : class, IEntity, new()
    {
        public ReadWriteRepositoryBase(IDBContext dbContext, IMapper<T> mapper) : base(dbContext, mapper) { }

        public abstract void Delete(T entity);
        public abstract IEnumerable<T> GetAll();
        public abstract T GetByCode(string entity_code);
        public abstract T GetByID(int entity_id);
        public abstract int Insert(T entity);
        public abstract int Save(T entity);
    }

    public abstract class ReadOnlyRepositoryBase<T> : RepositoryBase<T>, IReadOnlyRepository<T>
        where T : class, IEntity, new()
    {
        public ReadOnlyRepositoryBase(IDBContext dbContext, IMapper<T> mapper) : base(dbContext, mapper) { }
        public abstract IEnumerable<T> GetAll();
        public abstract T GetByCode(string entity_code);
        public abstract T GetByID(int entity_id);
    }

    public abstract class WriteOnlyRepositoryBase<T> : RepositoryBase<T>, IWriteOnlyRepository<T>
        where T : class, IEntity, new()
    {
        public WriteOnlyRepositoryBase(IDBContext dbContext, IMapper<T> mapper) : base(dbContext, mapper) { }

        public abstract void Delete(T entity);
        public abstract int Insert(T entity);
        public abstract int Save(T entity);
    }


    public class RepositoryBase<T>
        where T : class, IEntity, new()
    {
        protected readonly IMapper<T> Mapper;
        protected readonly IDBContext DbContext;

        public RepositoryBase(IDBContext dbContext, IMapper<T> mapper)
        {
            Mapper = mapper;
            DbContext = dbContext;
        }

        protected IEnumerable<T> MapRows(DbDataReader dr)
        {
            var rows = new List<T>();
            while (dr.Read())
                rows.Add(Mapper.Map(dr));
            dr.Close();
            return rows;
        }

        protected T MapRow(DbDataReader dr)
        {
            if (dr.Read())
                return Mapper.Map(dr);
            else
                return new T();
        }
    }
}
