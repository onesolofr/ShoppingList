using SLHelpers.AppEnvironement;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace SLHelpers.Data
{
    public class DefaultDBConnection : DBConnectionBase
    {
        public DefaultDBConnection() : base(EnvironementVariables.Instance.ConnectionString, EnvironementVariables.Instance.ProviderName) { }
        public DbConnection GetConnnection() => Cnx;
    }
}
