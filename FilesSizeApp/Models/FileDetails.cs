﻿using FilesSizeApp.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FilesSizeApp.Models
{
    public class FileDetails : IFile
    {
        private FileInfo _fileInfo;
        public string Path { get; set; }
        public Task<long> Size
        {
            get => TakeSize();

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
