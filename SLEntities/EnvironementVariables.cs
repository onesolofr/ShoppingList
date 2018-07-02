using SLEntities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace SLHelpers.AppEnvironement
{
    public class EnvironementVariables
    {
        private static EnvironementVariables _instance;
        public static EnvironementVariables Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EnvironementVariables();
                }
                return _instance;
            }
        }

        public string ConnectionName { get; set; }

        public string ConnectionString
        {
            get { return Instance.ConnectionProviders?[ConnectionName].ConnectionString; }
        }

        public string ProviderName
        {
            get { return Instance.ConnectionProviders?[ConnectionName].Name; }
        }

        public IDictionary<string, ConnectionProvider> ConnectionProviders { get; private set; }

        public void AddConnectionProviders(ConnectionProvider connectionProvider)
        {
            if (ConnectionProviders == null) ConnectionProviders = new Dictionary<string, ConnectionProvider>();
            if (!ConnectionProviders.ContainsKey(connectionProvider.Name))
            {
                ConnectionProviders.Add(connectionProvider.Name, connectionProvider);
                DbProviderFactories.RegisterFactory(connectionProvider.Name, connectionProvider.Type);
            }
        }
    }
}
