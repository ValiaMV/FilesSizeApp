using System;
using Xunit;
using FilesSizeApp.Models;
using System.IO;
using System.Linq;
using AutoFixture.Xunit2;
using System.Threading.Tasks;

namespace FilesSizeApp.Tests
{
    public class FolderTests
    {
        private string _tempFolderPath = Path.GetTempPath();
        private string _tempFilePath = Path.GetTempFileName();
        private void MakeTempFolder(int count)
        {
            for(int i = 0; i < count; i++)
            {
                MakeTempFile();
            }
        }
        private void MakeTempFile()
        {
            FileInfo file = new FileInfo(_tempFilePath);

            using (StreamWriter sw = file.CreateText())
            {
                sw.WriteLine("Temp test file");
            }
        }
        [Fact]
        public void CreationTest()
        {
            FolderDetails testFolder = new FolderDetails { Path = _tempFolderPath };
            Assert.NotNull(testFolder);
        }
        [Theory, AutoData]
        public void FilesInFolderTest(int filesCount)
        {
            MakeTempFolder(filesCount);
            FolderDetails testFolder = new FolderDetails { Path = _tempFolderPath }; ;
            DirectoryInfo expectedDirectory = new DirectoryInfo(_tempFolderPath);
            Assert.Equal(expectedDirectory.GetFiles().Select(file => file.FullName), testFolder.Files.Select(file => file.Path));
        }
    }
}
