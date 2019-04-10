using System;
using Xunit;
using FilesSizeApp.Models;
using System.IO;
using System.Linq;

namespace FilesSizeApp.Tests
{
    public class FolderTests
    {
        private void MakeTempFolder()
        {
            string path = Path.GetTempFileName();
            FileInfo file = new FileInfo(path);

            using (StreamWriter sw = file.CreateText())
            {
                sw.WriteLine("Temp test file");
            }
        }
        [Fact]
        public void CreationTest()
        {
            FolderDetails testFolder = new FolderDetails(Path.GetTempPath());
            Assert.NotNull(testFolder);
        }
        [Fact]
        public void EmptyArgumentCreationTest()
        {            
            Assert.Throws<ArgumentNullException>(() => new FolderDetails(""));
        }
        [Fact]
        public void FilesInFolderTest()
        {
            MakeTempFolder();
            MakeTempFolder();
            MakeTempFolder();
            MakeTempFolder();
            FolderDetails testFolder = new FolderDetails(Path.GetTempPath());
            DirectoryInfo expectedDirectory = new DirectoryInfo(Path.GetTempPath());
            Assert.Equal(expectedDirectory.GetFiles().Select(file => file.FullName), testFolder.Files.Select(file => file.Path));
        }
    }
}
