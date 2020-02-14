using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace _003_Ado_Net_Mapper
{
    public static class DataReaderExtensions
    {
        public static string GetValueToString(this IDataReader reader, string colName)
        {
            var value = reader[colName];
            return value == DBNull.Value ? null : (string)value;
        }
    }
}