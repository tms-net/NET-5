using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TMS.NET15.CsvService.Services
{
    public interface ICsvSerializer
    {
        string Serialize<T>(IEnumerable<T> models);
        IEnumerable<T> Deserialize<T>(string model);
    }

    public class CsvSerializer : ICsvSerializer
    {
        public IEnumerable<T> Deserialize<T>(string model)
        {
            return DeserializeInternal<T>(model);
        }

        public string Serialize<T>(IEnumerable<T> models)
        {
            return SerializeInternal(models);
        }

        internal static IEnumerable<T> DeserializeInternal<T>(string model)
        {
            // TODO: написать логику для создания объекта из csv формата

            throw new NotImplementedException();
        }

        internal static string SerializeInternal<T>(IEnumerable<T> models)
        {
            // TODO: написать логику для конвертации объекта в csv формат

            if (models == null)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();

            sb.Append(GetHeaderRow<T>());

            foreach (var model in models)
            {
                sb.AppendLine();
                sb.Append(GetDataRow(model));
            }

            return sb.ToString();

        }

        private static string GetDataRow<T>(T model)
        {
            var properties = GetProperties(typeof(T));

            return string.Join(
                ',', 
                properties
                    .Select(p => FormatValue(p.GetValue(model)?.ToString())));

            // 4.ToString(CultureInfo.InvariantCulture);
            // DateTime.Now.ToString(CultureInfo.InvariantCulture);
        }

        private static string GetHeaderRow<T>()
        {
            return string.Join(',', GetProperties(typeof(T)).Select(GetHeaderName));
        }

        private static IEnumerable<PropertyInfo> GetProperties(Type type)
        {
            var properties = type
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.GetCustomAttribute<IgnoreAttribute>() == null)
                .OrderBy(GetPropertyOrder);

            foreach (var property in properties)
            {
                if (!property.PropertyType.IsClass ||
                    property.PropertyType == typeof(string))
                {
                    yield return property;
                }
                else
                {
                    foreach (var otherProperty in GetProperties(property.PropertyType))
                    {
                        yield return property;
                    }
                }
            }
        }

        private static int GetPropertyOrder(PropertyInfo property)
        {
            var attribute = property.GetCustomAttribute<OrderAttribute>();

            return attribute?.Order ?? -1;
        }

        private static string GetHeaderName(PropertyInfo property)
        {
            var attribute = property.GetCustomAttribute<HeaderNameAttribute>();

            return FormatValue(/*property.DeclaringType.Name + */(attribute?.HeaderName ?? property.Name));
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
