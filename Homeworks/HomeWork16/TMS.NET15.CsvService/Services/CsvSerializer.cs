using System;
using System.Collections.Generic;
using System.Linq;
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

            throw new NotImplementedException();
        }
    }
}
