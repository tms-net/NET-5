using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.NET15.CsvService.Services
{
    public class CsvService
    {
        private readonly string _rootPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "CsvService");

        public void Persist<T>(IEnumerable<T> models)
        {
            var path = Path.Combine(_rootPath, DateTime.Now.ToString(), ".csv");
            using (var fs = new FileStream(path, FileMode.Create))
            {
                fs.Write(Encoding.UTF8.GetBytes(CsvSerializer.Serialize(models)));
            }
        }

        public IEnumerable<T> Read<T>(DateTime? version = null)
        {
            FileInfo file = null;
            var allFiles = Directory.EnumerateFiles(_rootPath).Select(file => new FileInfo(file));
            
            if (version.HasValue)
            {
                // TODO: Найти нужный файл
                throw new NotImplementedException();
            }
            else
            {
                file = allFiles.OrderBy(file => file.LastWriteTime).LastOrDefault();
            }

            if (file == null)
            {
                throw new FileNotFoundException();
            }

            return CsvSerializer.Deserialize<T>(File.ReadAllText(file.FullName));
        }
    }
}
