using System.Collections.Concurrent;

namespace BlacksmithAPI
{
    /// <summary>
    /// A class that simulates a simple database. This file is not a part of the challenge and shouldn't change.
    /// </summary>
    public static class BlacksmithDatabase
    {
        private static ConcurrentDictionary<string, List<object>> _tables = new ConcurrentDictionary<string, List<object>>(GenerateDatabaseData());

        private static IEnumerable<KeyValuePair<string, List<object>>> GenerateDatabaseData()
        {
            return new List<KeyValuePair<string, List<object>>>
            {
                new KeyValuePair<string, List<object>>("materials", GenerateMaterialsData()),
                new KeyValuePair<string, List<object>>("customers", GenerateCustomersData()),
                new KeyValuePair<string, List<object>>("orders", new List<object>()),
            };
        }

        public static T? Get<T>(string tableName,Func<T, bool> searchPredicate) where T : class
        {
            if(_tables.TryGetValue(tableName, out var table))
            {
                return table.Cast<T>().SingleOrDefault(searchPredicate);
            }

            return null;
        }

        public static bool Add(string tableName, object newItem)
        {
            if (_tables.TryGetValue(tableName, out var table))
            {
                var updatedTable = new List<object>(table)
                {
                    newItem
                };

                return _tables.TryUpdate(tableName, updatedTable, table);
            }

            return false;
        }

        private static List<object> GenerateMaterialsData()
        {
            return new List<object>
            {
                new Material("wood", 1f),
                new Material("bronze", 1.3f),
                new Material("iron", 2.2f),
                new Material("gold", 6.8f),
            };
        }

        private static List<object> GenerateCustomersData()
        {
            return new List<object>
            {
                new Customer(1, "Regular"),
                new Customer(2, "Express"),
                new Customer(3, "Premium"),
            };
        }
    }
}
