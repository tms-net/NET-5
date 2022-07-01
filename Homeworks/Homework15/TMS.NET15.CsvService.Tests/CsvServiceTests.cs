using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using TMS.NET15.CsvService.Services;
using System.Linq;
using System;
using System.IO;

namespace TMS.NET15.CsvService.Tests
{
    [TestClass]
    public class CsvServiceTests
    {
        [TestMethod]
        public void PersistShouldCreateFileInDocumentsFolder()
        {
            // arrange
            var root = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "CsvService");
            Directory.Delete(root, true);
            var mock = new Mock<ICsvSerializer>();
            mock.Setup(serializer =>
                    serializer.Serialize(
                        It.Is<IEnumerable<object>>(
                            models => models != null)))
                .Returns("serialized");
            var sut = new CsvStoreService(mock.Object);

            //act
            sut.Persist(new[] { new object() });

            //assert
            Assert.IsTrue(Directory.Exists(root));
            Assert.IsTrue(Directory.EnumerateFiles(root).Any());
            
            mock.Verify(serializer => 
                    serializer.Serialize(
                        It.IsAny<IEnumerable<object>>()),
                Times.Once());

            mock.Verify(serializer =>
                    serializer.Deserialize<IEnumerable<object>>(
                        It.IsAny<string>()),
                Times.Never());

            // assert file content

            // AAA
        }
    }
}
