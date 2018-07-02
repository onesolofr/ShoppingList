using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace SLHelpers.Data
{
    public static class DbDataReaderExtention
    {
        public static T GetJsonObject<T>(this DbDataReader read, string columnName) where T : class
        {
            int index = read.GetOrdinal(columnName);
            if (index > -1)
            {
                object value = read.GetValue(read.GetOrdinal(columnName));
                if (value is string)
                    return JsonConvert.DeserializeObject<T>((string)value);
                else return default(T);
            }
            else return default(T);
        }

        public static JObject GetJObject(this DbDataReader read, string columnName)
        {
            int index = read.GetOrdinal(columnName);
            if (index > -1)
            {
                object value = read.GetValue(index);
                if (value is string)
                    return JObject.Parse((string)value);
                else return default(JObject);
            }
            else return default(JObject);
        }

        public static T GetValue<T>(this DbDataReader read, string columnName) where T : class
        {
            int index = read.GetOrdinal(columnName);
            if (index > -1)
            {
                object value = read.GetValue(read.GetOrdinal(columnName));
                if (value is T)
                    return (T)value;
                else return default(T);
            }
            else return default(T);
        }
    }
}
