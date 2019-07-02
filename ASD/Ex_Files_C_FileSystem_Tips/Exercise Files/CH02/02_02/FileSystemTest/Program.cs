using System;
using System.IO;

namespace FileSystemTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new Program();
            app.CreateDirectory();
            Console.Read();
        }

        public void CreateDirectory()
        {
            var dirName = "TestFolder";
            if (Directory.Exists(dirName))
            {
                Console.WriteLine("Dir '" + dirName + "' exists");
            }else
            {
                Directory.CreateDirectory(dirName);
                Console.WriteLine("Create dir '" + dirName + "'");
            }
            
        }
    }
}
