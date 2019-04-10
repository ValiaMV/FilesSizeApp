using FilesSizeApp.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesSizeApp.Models
{
    public class FolderDetails : IFolder
    {
        private DirectoryInfo _folderInfo;
        public string Path { get; set; }

        public IEnumerable<IFile> Files { get; }

        public FolderDetails(string path)
        {
            if (path != string.Empty)
            {
                Path = path;
                _folderInfo = new DirectoryInfo(Path);
                foreach (var file in _folderInfo.GetFiles())
                {
                    Files.Append( new FileDetails(file.FullName));
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(path));
            }
        }
    }
}
