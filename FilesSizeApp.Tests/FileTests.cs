using System;
using Xunit;
using FilesSizeApp.Models;
using System.IO;


namespace FilesSizeApp.Tests
{
    public class FileTests
    {
        public string MakeTempFile()
        {
            string path = Path.GetTempFileName();
            FileInfo file = new FileInfo(path);

            using (StreamWriter sw = file.CreateText())
            {
                sw.WriteLine("Temp test file");
            }
            return path;
        }
        [Fact]
        public void CreationTest()
        {
            string testFilePath = MakeTempFile();
            FileDetails testFile = new FileDetails(testFilePath);
            Assert.NotNull(testFile);
        }
        [Fact]
        public void EmptyArgumentTest()
        {
            Assert.Throws<ArgumentNullException>(() => new FileDetails(""));
        }
        [Fact]
        public void NullArgumentTest()
        {
            Assert.Throws<ArgumentNullException>(() => new FileDetails(null));
        }
    }
}
