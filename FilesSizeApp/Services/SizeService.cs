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
    /// <summary>
    /// Service for getting files sizes from folder 
    /// </summary>
    public class SizeService
    {
        private IFolder _folder;
        public SizeService(IFolder folder)
        {
            _folder = folder;
        }
        /// <summary>
        /// Set folder directory for service
        /// </summary>
        /// <param name="path"></param>
        public void SetFolder(string path)
        {
            _folder.Path = path;
        }
        public async Task FileSizePrint(Func<string, string, Task> printMethod, string path)
        {
            await Task.Run(() => {
                printMethod.Invoke(_folder.Files.SingleOrDefault(file => file.Path == path)?.Size.ToString(), path);
            }); 
        }
        /// <summary>
        /// Print files sizes from folder with specified async method
        /// </summary>
        /// <param name="printMethod">Async method for printing two string values</param>
        /// <returns></returns>
        public async Task FolderSizesPrint(Func<string, string, Task> printMethod)
        {
            foreach(var file in _folder.Files)
            {
                await FileSizePrint(printMethod, file.Path);
            }
        }
        /// <summary>
        /// Serializes the files objects and write XML file with names ans sizes
        /// </summary>
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
