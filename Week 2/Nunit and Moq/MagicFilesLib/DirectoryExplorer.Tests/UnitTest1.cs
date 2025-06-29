using NUnit.Framework;
using Moq;
using MagicFilesLib;
using System.Collections.Generic;

namespace DirectoryExplorer.Tests
{
    [TestFixture]
    public class DirectoryExplorerTests
    {
        private Mock<IDirectoryExplorer> mockExplorer;
        private readonly string _file1 = "file.txt";
        private readonly string _file2 = "file2.txt";

        [OneTimeSetUp]
        public void Init()
        {
            mockExplorer = new Mock<IDirectoryExplorer>();
            mockExplorer.Setup(m => m.GetFiles(It.IsAny<string>()))
                        .Returns(new List<string> { _file1, _file2 });
        }

        [TestCase]
        public void GetFiles_ShouldReturnExpectedFiles()
        {
            var result = mockExplorer.Object.GetFiles("dummy/path");

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result, Contains.Item(_file1));
        }
    }
}
