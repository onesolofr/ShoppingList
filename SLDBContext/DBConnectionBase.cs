using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace SLHelpers.Data
{
    public abstract class DBConnectionBase
    {
        protected DbConnection Cnx { get; private set; }

        public DBConnectionBase(string connectionString, string providerInvariantName)
        {
            Cnx = DbProviderFactories.GetFactory(providerInvariantName).CreateConnection();
            Cnx.ConnectionString = connectionString;
        }
    }
}
