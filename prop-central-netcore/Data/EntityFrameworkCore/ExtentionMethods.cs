using System;
using System.Data.Common;

namespace prop_central_netcore.Data.EntityFrameworkCore
{
    public static class ExtentionMethods
    {
        // ### IDataReader extensions #################################################################################
        /// <summary>
        /// Generic Method that creates a list of T from a given datareader </summary>
        /// <typeparam name="T">The type of objects, the list should contain.</typeparam>
        /// <param name="dr">The data reader from which the list should be populated.</param>
        /// <returns>A generic list with objects of the given Type.</returns>
        public static async Task<List<T>> MapToList<T>(this DbDataReader dr, CancellationToken cancellationToken = default)
        {
            var list = new List<T>();
            while (await dr.ReadAsync(cancellationToken))
            {
                var obj = Activator.CreateInstance<T>();
                foreach (var prop in obj.GetType().GetProperties())
                {
                    if (!Equals(dr[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, dr[prop.Name], null);
                    }
                }
                list.Add(obj);
            }
            return list;
        }

        public static async Task<T> MapToObject<T>(this DbDataReader dr, CancellationToken cancellationToken = default)
        {
            var obj = Activator.CreateInstance<T>();
            while (await dr.ReadAsync(cancellationToken))
            {
                foreach (var prop in obj.GetType().GetProperties())
                {
                    if (!Equals(dr[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, dr[prop.Name], null);
                    }
                }
            }
            return obj;
        }
    }
}

