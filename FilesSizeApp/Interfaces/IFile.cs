using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesSizeApp.Interfaces
{
    public interface IFile
    {
        string Path { get; set; }
        Task<long> Size { get; }
    }
}
