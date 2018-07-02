using SLEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SLHelpers.Data
{
    public static class DbCommandExtention
    {
        public static void Addwithvalue(this IDbCommand command, string parameterName, object value)
        {
            IDataParameter parameter = command.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.Value = value;
            command.Parameters.Add(parameter);
        }

        public static void Addwithvalue(this IDbCommand command, DbDataParameter dbDataParameter)
        {
            IDataParameter parameter = command.CreateParameter();
            parameter.ParameterName = dbDataParameter.ParameterName;
            parameter.Value = dbDataParameter.Value;
            command.Parameters.Add(parameter);
        }
    }
}
