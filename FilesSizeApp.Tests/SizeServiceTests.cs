using FilesSizeApp.Models;
using FilesSizeApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FilesSizeApp.Tests
{
    public class SizeServiceTests
    {
        private string _tempFolderPath = Path.GetTempPath();
        private string _tempFilePath = Path.GetTempFileName();
        private string _printedData;
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
            SizeService service = new SizeService(new FolderDetails(_tempFolderPath));
            Assert.NotNull(service);
        }
        [Fact]
        public async Task FileSizeCreationTest()
        {
            MakeTempFile();
            SizeService service = new SizeService(new FolderDetails(_tempFolderPath));
            var size = await service.FileSize(_tempFilePath);
            Assert.True(size != 0);
        }
        [Fact]
        public async Task FileSizeAccuracyTest()
        {
            MakeTempFile();
            SizeService service = new SizeService(new FolderDetails(_tempFolderPath));
            var size = await service.FileSize(_tempFilePath);
            FileInfo file = new FileInfo(_tempFilePath);

            Assert.Equal(file.Length, size);
        }
        private void printToString(long number)
        {
            _printedData += number.ToString() + " ";
        }
        [Fact]
        public async Task FileSizePrintAccuracyTest()
        {
            _printedData = string.Empty;
            MakeTempFile();
            SizeService service = new SizeService(new FolderDetails(_tempFolderPath));
            await service.FileSizePrint(printToString, _tempFilePath);
            FileInfo file = new FileInfo(_tempFilePath);
            Assert.Equal(file.Length.ToString(), _printedData.Trim());
        }
        [Fact]
        public async Task FolderSizesPrintAccuracyTest()
        {
            _printedData = string.Empty;
            MakeTempFile();
            SizeService service = new SizeService(new FolderDetails(_tempFolderPath));
            await service.FolderSizesPrint(printToString);
            DirectoryInfo expected = new DirectoryInfo(_tempFolderPath);
            
            Assert.Equal(String.Join(" ", expected.GetFiles().Select(file => file.Length).ToArray()), _printedData.Trim());

        }
    }
}
