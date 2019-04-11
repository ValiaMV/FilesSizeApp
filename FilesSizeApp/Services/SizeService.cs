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
        public void FileSizePrint(Action<string, string> printMethod, string path)
        {
            printMethod.Invoke(_folder.Files.Single( file => file.Path == path).Size.ToString(), path);
        }
        public void FolderSizesPrint(Action<string, string> printMethod)
        {
            Parallel.ForEach(_folder.Files, (currentFile) =>
            {
                FileSizePrint(printMethod, currentFile.Path);
            });
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
