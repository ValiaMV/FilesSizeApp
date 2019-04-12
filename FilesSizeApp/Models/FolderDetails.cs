using FilesSizeApp.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesSizeApp.Models
{
    /// <summary>
    /// Provides properties and intances for working with folder files
    /// </summary>
    public class FolderDetails : IFolder
    {
        private DirectoryInfo _folderInfo;
        public IEnumerable<IFile> Files { get; private set; }
        private string _path;
        public string Path {
            get { return _path; }
            set
            {
                if (value != string.Empty)
                {
                    _path = value;
                    _folderInfo = new DirectoryInfo(_path);
                    Files = Directory.GetFiles(_folderInfo.FullName, "*.*", SearchOption.AllDirectories).Select(path => new FileDetails(path));
                }
                else
                {
                    throw new ArgumentNullException(nameof(value));
                }
            }
        }
        public FolderDetails()
        {

        }
    }
}
