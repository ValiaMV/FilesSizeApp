using FilesSizeApp.Interfaces;
using FilesSizeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesSizeApp.Services
{
    public class SizeService
    {
        private IFolder _folder;
        public SizeService(IFolder folder)
        {
            _folder = folder;
        }
        public void SetFolder(string path)
        {
            _folder.Path = path;
        }
        public async Task<long> FileSize(string path)
        {
            return await _folder.Files.Single(file => file.Path == path).Size;
        }
        public async Task FileSizePrint(Action<long> printMethod, string path)
        {
            var size = await FileSize(path);
            printMethod(size);
        }
        public async Task FolderSizesPrint(Action<long> printMethod)
        {
            foreach(var file in _folder.Files)
            {
                await FileSizePrint(printMethod, file.Path);
            }
        }
    }
}
