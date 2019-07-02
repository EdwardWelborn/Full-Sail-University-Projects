using System;
using System.IO;

namespace FileSystemText
{
    class FileSystem
    {

        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }
        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

    }
}
