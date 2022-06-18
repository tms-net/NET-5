using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TMS.NET15.Lesson16.Serialization
{
    

    //[Description]
    public class JsonClass
    {
        public JsonClass()
        {
            var xml =
                @"
                <JsonClass 'StringProp'='sgifn' 'numProp'='3'>
                    <objProp>
                    </objProp>
                </JsonClass>";

            var json =
                @"
                {
                    'StringProp': 'sgifn',
                    'numProp': 3,
                    'objProp':
                        {
                        },
                    'arrayProp': [{'anotherNumProp': 5}],
                    'boolProp': true
                }";
        }

        [JsonPropertyName("stringProp")]
        //[Description(Description = "Description"), Description(Type = ObjectType.Regular)]
        //[Description(Handler = typeof(JsonClass))]
        public string StringProp { get; set; }
        public int numProp { get; set; }
        public object objProp { get; set; }
        public object[] arrayProp { get; set; }

        [JsonIgnore]
        public bool boolProp { get; set; }
        public object unknownProp { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class DescriptionAttribute : Attribute
    {
        public string Description { get; set; }

        public ObjectType Type { get; set; }

        public Type Handler { get; set; }


        public string GetDescription()
        {
            return $"Attribute:{Description}";
        }
    }

    public enum ObjectType
    {
        Regular
    }

    class Program
    {
        // TODO: review how JsonSerializer works with objects
        // - JsonSerializerOptions (case sensitivity, WriteIndented)
        // - work with names (use attributes (JsonPropertyName, JsonIgnore, JsonInclude), known/unknown props)
        // - unknown objects
        // - array with different types (JsonElement, etc.)
        // - serialization exceptions
        
        // Binary in memory
        //  (1,2,ref1) ...... (ref1:3,4)
        
        // Binary -> [..1,2,..3]
        
        // Text -> "1,2,3"
            // XML
            // JSON
            // HTML
            // CSV

        static void Main(string[] args)
        {
            var json = @"
{
    ""stringProp"": ""this is a string"",
    ""numProp"": 100,
    ""objProp"": {
        ""innerProp"": ""this is inner string""
    },
    ""boolProp"": true,
    ""arrayProp"": [1, ""string"", { ""arrayObjProp"": ""this is string in array""}]
}";

            Console.WriteLine(json);

            try
            {
	            var obj = JsonSerializer.Deserialize<JsonClass>(json,
                    new JsonSerializerOptions()
                    );
	            obj.StringProp = "for serialization";
                obj.boolProp = true;
                Console.WriteLine(JsonSerializer.Serialize(obj));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}
