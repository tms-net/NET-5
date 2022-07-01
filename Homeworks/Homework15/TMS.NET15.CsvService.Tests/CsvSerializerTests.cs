using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Globalization;
using TMS.NET15.CsvService.Services;
using TMS.NET15.CsvService.Tests.Stubs;

namespace TMS.NET15.CsvService.Tests
{
    [TestClass]
    public class CsvSerializerTests
    {
        [TestMethod]
        public void SerializeShouldNotFailForNullValues()
        {
            // arrange
            var models = new[] { new SimpleClass(), new SimpleClass() };
            var serializer = new CsvSerializer();
            // Fake, Stub, Mock

            // act
            var csv = serializer.Serialize((IEnumerable<string>) null);

            // assert
        }

        [TestMethod]
        public void SerializeShouldCorrectlyFormatSimpleClasses()
        {
            // arrange
            var models = new[] { new SimpleClass(), new SimpleClass() };
            var serializer = new CsvSerializer();

            // Fake, Stub, Mock

            // act
            var csv = serializer.Serialize(models);

            // assert
            Assert.AreEqual(
@"""BoolProperty"",""IntProperty"",""StringProperty""
""False"",""0"",""""
""False"",""0"",""""", 
            csv);
        }

        [TestMethod]
        public void SerializeShouldCorrectlyEscapeSpecialSymbols()
        {
            // arrange
            var models = new[] { new SimpleClass
            {
                StringProperty = "\"Quoted\""
            },
             new SimpleClass() };
            var serializer = new CsvSerializer();

            // Fake, Stub, Mock

            // act
            var csv = serializer.Serialize(models);

            // assert
            Assert.AreEqual(
@"""BoolProperty"",""IntProperty"",""StringProperty""
""False"",""0"",""""""Quoted""""""
""False"",""0"",""""",
            csv);
        }

        //[TestCase("en-US")]
        //[TestCase("fr-FR")]
        [DataRow("en-US")]
        [DataRow("fr-FR")]
        [TestMethod]
        public void SerializeShouldCorrectlyHandleNumberFormat(string culture)
        {
            // arrange
            CultureInfo.CurrentCulture = new CultureInfo(culture);
            var models = new[]
            {
                new SimpleClassWithDecimal
                {
                    DecimalProperty = (decimal)10.5
                },
                new SimpleClassWithDecimal()
            };
            var serializer = new CsvSerializer();

            // Fake, Stub, Mock

            // act
            var csv = serializer.Serialize(models);

            // assert
            Assert.AreEqual(
@"""DecimalProperty"",""StringProperty""
""10.5"",""""
""0"",""""",
            csv);
        }

        [TestMethod]
        public void SerializeShouldCorrectlyHandleHeaderAttribute()
        {
            // arrange
            var models = new[] { 
                new SimpleClassWithAttributes(),
                new SimpleClassWithAttributes() 
            };
            var serializer = new CsvSerializer();

            // Fake, Stub, Mock

            // act
            var csv = serializer.Serialize(models);

            // assert
            Assert.AreEqual(
@"""NewHeader""
""""
""""",
            csv);
        }
    }
}