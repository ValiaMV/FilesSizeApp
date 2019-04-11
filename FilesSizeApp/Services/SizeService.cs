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
            var size = await _folder.Files.Single(file => file.Path == path).Size;
            return size;
        }
        public async Task FileSizePrint(Func<Task<long>, Task> printMethod, string path)
        {
            await printMethod(await Task.FromResult(FileSize(path)));
        }
        public async Task FolderSizesPrint(Func<Task<long>, Task> printMethod)
        {
            foreach(var file in _folder.Files)
            {
                await FileSizePrint(printMethod, file.Path);
            }
        }
    }
}
