using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using QIQO.Core.Contracts;

namespace QIQO.Data.Repositories
{
    public class TestRepository : ReadOnlyRepositoryBase<TestData>, ITestRepository
    {
        public TestRepository(IMainDBContext dbContext, IMapper<TestData> mapper) : base(dbContext, mapper) { }

        public override IEnumerable<TestData> GetAll()
        {
            using (DbContext)
            {
                return MapRows(DbContext.ExecuteProcedureAsSqlDataReader(StoredProcedures.usp_test_get_all));
            }
        }

        public override TestData GetByCode(string entity_code)
        {
            throw new NotImplementedException();
        }

        public override TestData GetByID(int entity_id)
        {
            throw new NotImplementedException();
        }
    }
}
