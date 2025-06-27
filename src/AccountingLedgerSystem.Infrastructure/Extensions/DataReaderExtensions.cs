using System.Data.Common;
using System.Diagnostics;
using System.Reflection;

namespace AccountingLedgerSystem.Infrastructure.Extensions
{
    public static class DataReaderExtensions
    {
        public static async Task<List<T>> ToListAsync<T>(this DbDataReader reader) where T : new()
        {
            var items = new List<T>();
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Create column-to-property map (case insensitive)
            var columnMap = new Dictionary<string, PropertyInfo>();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                var columnName = reader.GetName(i);
                var property = properties.FirstOrDefault(p =>
                    p.Name.Equals(columnName, StringComparison.OrdinalIgnoreCase));

                if (property != null)
                {
                    columnMap[columnName] = property;
                }
                // Columns without matching properties are ignored
            }

            while (await reader.ReadAsync())
            {
                var item = new T();

                foreach (var column in columnMap)
                {
                    try
                    {
                        if (reader[column.Key] is DBNull)
                            continue;

                        column.Value.SetValue(item, reader[column.Key]);
                    }
                    catch (Exception ex)
                    {
                        // Optional: Log mismatch or conversion errors
                        Debug.WriteLine($"Error mapping column {column.Key}: {ex.Message}");
                        // Continue to next column
                    }
                }

                items.Add(item);
            }

            return items;
        }
    }
}
