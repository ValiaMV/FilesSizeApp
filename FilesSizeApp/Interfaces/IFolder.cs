using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesSizeApp.Interfaces
{
    public interface IFolder
    {
        string Path { get; set; }

        IEnumerable<IFile> Files { get; }
    }
}
