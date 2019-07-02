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
            app.CopySaveData();
            app.DeleteTmp();
        }

        public string[] folders =
        {
            @"Workspace\",
            @"Workspace\Archive\",
            @"Workspace\Tmp\",
            @"Workspace\Tmp\SaveData\"
        };

        public void CreateDirectory()
        {
            var total = folders.Length;

            for (var i = 0; i < total; i++)
            {
                var dirName = folders[i];
                if (Directory.Exists(dirName))
                {
                    Console.WriteLine("Dir '" + dirName + "' exists");
                }
                else
                {
                    Directory.CreateDirectory(dirName);
                    Console.WriteLine("Create dir '" + dirName + "'");
                }
            }
            
        }

        public void DeleteTmp()
        {
            var tmpDir = folders[2];

            if (Directory.Exists(tmpDir))
            {
                Directory.Delete(tmpDir, true);
            }
            
        }

        public void CopySaveData()
        {
            var saveDataDir = folders[3];

            if (Directory.Exists(saveDataDir))
            {
                var destDirName = folders[1] + "SaveData_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                Directory.Move(saveDataDir, destDirName);
            }
        }
    }
}
