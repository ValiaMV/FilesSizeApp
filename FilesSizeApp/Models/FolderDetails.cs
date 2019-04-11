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
        private string _path;
        public string Path {
            get { return _path; }
            set
            {
                if (value != string.Empty)
                {
                    _path = value;
                    _folderInfo = new DirectoryInfo(_path);
                    Files = _folderInfo.GetFiles().Select(file => new FileDetails(file.FullName));
                }
                else
                {
                    throw new ArgumentNullException(nameof(value));
                }
            }
        }

        public IEnumerable<IFile> Files { get; private set; }
        public FolderDetails()
        {

        }
    }
}
