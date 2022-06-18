using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TMS.NET15.CsvService.Services
{
    public class CsvSerializer
    {
        public static IEnumerable<T> Deserialize<T>(string model)
        {
            // TODO: написать логику для создания объекта из csv формата

            throw new NotImplementedException();
        }

        public static string Serialize<T>(IEnumerable<T> models)
        {
            // TODO: написать логику для конвертации объекта в csv формат

            var sb = new StringBuilder();

            sb.AppendLine(GetHeaderRow<T>());

            foreach (var model in models)
            {
                sb.AppendLine(GetDataRow(model));
            }

            return sb.ToString();

        }

        private static string GetDataRow<T>(T model)
        {
            var properties = GetProperties<T>();

            return string.Join(
                ',', 
                properties
                    .Select(p => FormatValue(p.GetValue(model)?.ToString())));

            // 4.ToString(CultureInfo.InvariantCulture);
            // DateTime.Now.ToString(CultureInfo.InvariantCulture);
        }

        private static string GetHeaderRow<T>()
        {
            return string.Join(',', GetProperties<T>().Select(GetHeaderName));
        }

        private static IEnumerable<PropertyInfo> GetProperties<T>()
        {
            return typeof(T)
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.GetCustomAttribute<IgnoreAttribute>() == null)
                .OrderBy(GetPropertyOrder);
        }

        private static int GetPropertyOrder(PropertyInfo property)
        {
            var attribute = property.GetCustomAttribute<OrderAttribute>();

            return attribute?.Order ?? -1;
        }

        private static string GetHeaderName(PropertyInfo property)
        {
            var attribute = property.GetCustomAttribute<HeaderNameAttribute>();

            return FormatValue(attribute?.HeaderName ?? property.Name);
        }

        private static string FormatValue(string value)
        {
            return $"\"{value?.Replace("\"", "\"\"")}\"";
        }
    }

    public class OrderAttribute : Attribute
    {
        public OrderAttribute(int order)
        {
            Order = order;
        }

        public int Order { get; }
    }

    public class IgnoreAttribute : Attribute
    {
    }

    public class HeaderNameAttribute : Attribute
    {
        public HeaderNameAttribute(string headerName)
        {
            HeaderName = headerName;
        }

        public string HeaderName { get; }
    }
}
