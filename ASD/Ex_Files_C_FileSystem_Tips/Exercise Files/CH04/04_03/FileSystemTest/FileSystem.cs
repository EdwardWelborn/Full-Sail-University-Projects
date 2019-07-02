using System;
using System.IO;

namespace FileSystemTest
{
    public class FileSystem
    {
        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        public void DeleteDirectory(string path, bool recursive = true)
        {
            Directory.Delete(path, recursive);
        }

        public void MoveDirectory(string srcPath, string destPath)
        {
            Directory.Move(srcPath, destPath);
        }
    }
}
