using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TMS.NET15.CsvService.Services;
using TMS.NET15.CsvService.Tests.Stubs;

namespace TMS.NET15.CsvService.Tests
{
    [TestClass]
    public class CsvServiceTests
    {
        [TestMethod]
        public void PersistShouldCreateFileInDocumentsFolder()
        {
            // arrange
            ICsvSerializer serializer = Mock.Of<ICsvSerializer>();

            var sut = new CsvStoreService(serializer);

            //act
            sut.Persist(new[] { new object() });

            //assert

            // AAA
        }
    }
}
