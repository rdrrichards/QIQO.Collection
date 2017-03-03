using QIQO.Core.Contracts;
using QIQO.Data.Common;
using QIQO.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QIQO.Data.Maps
{
    public class TestMapper : MapperBase, ITestMapper
    {
        public TestData Map(IDataReader ds)
        {
            try
            {
                return new TestData { };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SqlParameter> MapParamsForDelete(int entity_key)
        {
            throw new NotImplementedException();
        }

        public List<SqlParameter> MapParamsForDelete(TestData entity)
        {
            throw new NotImplementedException();
        }

        public List<SqlParameter> MapParamsForUpsert(TestData entity)
        {
            throw new NotImplementedException();
        }
    }
}
