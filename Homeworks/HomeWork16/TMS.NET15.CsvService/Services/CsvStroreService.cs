using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.NET15.CsvService.Services
{
    public class CsvStoreService
    {
        private readonly ICsvSerializer _csvSerializer;
        private readonly string _rootPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "CsvService");

        public CsvStoreService(ICsvSerializer csvSerializer)
        {
            if (!Directory.Exists(_rootPath))
            {
                Directory.CreateDirectory(_rootPath);
            }

            this._csvSerializer = csvSerializer;
        }

        public void Persist<T>(IEnumerable<T> models)
        {
            var path = Path.Combine(
                _rootPath, 
                DateTime.Now.ToString("yyyy-dd-MM_hh-mm-ss") + ".csv");
            using (var fs = new FileStream(path, FileMode.Create))
            {
                fs.Write(Encoding.UTF8.GetBytes(_csvSerializer.Serialize(models)));
            }
        }

        public IEnumerable<T> Read<T>(DateTime? version = null)
        {
            //string str = null;
            //var length = str?.Length;

            //int? num = null;

            //Nullable<int> num2 = null;

            //if (num2 == null)
            //{
            //    num2 = 5;
            //}

            FileInfo file = null;
            var allFiles = Directory.EnumerateFiles(_rootPath).Select(file => new FileInfo(file));
            
            if (version.HasValue)
            {
                allFiles.Where(fileInfo => fileInfo.LastWriteTime < version.Value)
                        .OrderBy(fileInfo => fileInfo.LastWriteTime)
                        .LastOrDefault();

                //var closestDate = DateTime.MinValue;
                //foreach (var fileInfo in allFiles)
                //{
                //    if (fileInfo.LastWriteTime < version.Value &&
                //        fileInfo.LastWriteTime > closestDate)
                //    {
                //        file = fileInfo;
                //        closestDate = fileInfo.LastWriteTime;
                //    }
                //}

                //file = allFiles.FirstOrDefault()
            }
            else
            {
                file = allFiles.OrderBy(file => file.LastWriteTime).LastOrDefault();
            }

            if (file == null)
            {
                throw new FileNotFoundException();
            }

            return _csvSerializer.Deserialize<T>(File.ReadAllText(file.FullName));
        }
    }
}
