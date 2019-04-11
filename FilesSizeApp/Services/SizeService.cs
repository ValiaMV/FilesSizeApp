using FilesSizeApp.Interfaces;
using FilesSizeApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
        public long FileSize(string path)
        {
            return _folder.Files.Single(file => file.Path == path).Size;
        }
        public async Task FileSizePrint(Func<Task<long>, Task> printMethod, string path)
        {
            await printMethod(Task.FromResult(FileSize(path)));
        }
        public async Task FolderSizesPrint(Func<Task<long>, Task> printMethod)
        {
            foreach(var file in _folder.Files)
            {
                await FileSizePrint(printMethod, file.Path);
            }
        }
        public void MakeXml()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(FileDetails[]));
            using (FileStream fs = new FileStream(_folder.Path + "//sizes.xml", FileMode.OpenOrCreate))
            {
                    formatter.Serialize(fs, _folder.Files.Select(file => (FileDetails)file).ToArray());
            }
        }
    }
}
