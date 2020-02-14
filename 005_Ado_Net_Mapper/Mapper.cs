using _005_AdoNet_Mapper.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _005_Ado_Net_Mapper
{
    public static class Mapper
    {
        public static T ToModel<T>(this IDataReader dataReader)
           where T : class, new()
        {
            Type type = typeof(T);

            var members = type
                .GetProperties()
                .Where(p => p.GetCustomAttribute<IgnoreAttribute>() == null)
                .ToList();

            var source = new T();
            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].GetCustomAttribute<DateAttribute>() != null)
                {
                    if (DateTime.TryParse(dataReader.GetValue(i).ToString(), out DateTime date))
                    {
                        members[i].SetValue(source, date);
                    }
                }
                else
                {
                    if (!dataReader.IsDBNull(i))
                    {
                        members[i].SetValue(source, dataReader.GetValue(i));
                    }
                }

            }
            return source;
        }
    }
}

