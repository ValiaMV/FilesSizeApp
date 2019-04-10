using FilesSizeApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesSizeApp.Models
{
    public class FolderDetails : IFolder
    {
        public string Path { get; set; }

        public IEnumerable<IFile> Files { get; }

        public FolderDetails(string path)
        {
            if (path != string.Empty)
            {
                Path = path;
            }
            else
            {
                throw new ArgumentNullException(nameof(path));
            }
        }
    }
}
