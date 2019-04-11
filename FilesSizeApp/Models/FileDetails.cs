using FilesSizeApp.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FilesSizeApp.Models
{
    [Serializable]

    public class FileDetails : IFile
    {
        private FileInfo _fileInfo;
        public string Path { get; set; }        
        public long Size { get => _fileInfo.Length; set { } } 
        public FileDetails()
        {

        }
        public FileDetails(string path)
        {
            if(path != string.Empty)
            {
                Path = path;
                _fileInfo = new FileInfo(Path);
            }
            else
            {
                throw new ArgumentNullException(nameof(path));
            }
        }

        public async Task<long> TakeSize()
        {
            return await Task.FromResult(_fileInfo.Length);
        }
    }
}
