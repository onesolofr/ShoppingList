using SLEntities;
using SLHelpers.Data;
using System;
using System.Data.Common;

namespace SLDBContext
{
    public class DataProvider
    {
        private static void ExecuteReaderQuery(string query, Action<DbDataReader> read, params DbDataParameter[] parameters)
        {
            DbConnection connection = (new DefaultDBConnection()).GetConnnection();
            try
            {
                connection.Open();

                var selectCommand = connection.CreateCommand();

                selectCommand.CommandText = query;

                if (parameters != null)
                {
                    foreach (DbDataParameter parameter in parameters)
                        selectCommand.Addwithvalue(parameter);
                }

                using (var reader = selectCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                            read(reader);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
                connection = null;
            }
        }
    }
}
