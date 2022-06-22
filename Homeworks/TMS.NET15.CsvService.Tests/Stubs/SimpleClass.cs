using System.Collections.Generic;
using TMS.NET15.CsvService.Services;

namespace TMS.NET15.CsvService.Tests.Stubs
{
    public class MockSerializer : ICsvSerializer
    {
        public IEnumerable<T> Deserialize<T>(string model)
        {
            throw new System.NotImplementedException();
        }

        public string Serialize<T>(IEnumerable<T> models)
        {
            throw new System.NotImplementedException();
        }
    }

    public class SimpleClass
    {
        public bool BoolProperty { get; set; }

        public int IntProperty { get; set; }

        public string StringProperty { get; set; }

        private string AnotherStringProperty { get; set; }
    }


    public class SimpleClassWithDecimal
    {
        public decimal DecimalProperty { get; set; }

        public string StringProperty { get; set; }
    }


    public class SimpleClassWithAttributes
    {
        [HeaderName("NewHeader")]
        public string StringProperty { get; set; }
    }

}
