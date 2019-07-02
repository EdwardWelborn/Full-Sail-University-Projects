using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace FileSystemTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new Program();
            app.CreateConfig();
            app.ReadConfig();
            app.CreateDirectory();
            app.CreateFile();
            Console.Read();
            app.ArchiveConfig();
            app.SaveImage();
            app.CopySaveData();
            app.DeleteTmp();
        }

        private FileSystem fileSystem;

        public Program()
        {
            fileSystem = new FileSystem();
        }

        public string[] folders =
        {
            @"Workspace\",
            @"Workspace\Archive\",
            @"Workspace\Tmp\",
            @"Workspace\Tmp\SaveData\"
        };

        public string configFile
        {
            get { return GetUserDataFolder() + "Config.txt"; }
        }

        public enum FolderNames
        {
            Workspace,
            Archive,
            Tmp,
            SaveData
        }

        public void CreateDirectory()
        {
            var total = folders.Length;

            for (var i = 0; i < total; i++)
            {
                var dirName = GetFolderByName((FolderNames)i);
                if (fileSystem.DirectoryExists(dirName))
                {
                    Console.WriteLine("Dir '" + dirName + "' exists");
                }
                else
                {
                    fileSystem.CreateDirectory(dirName);
                    Console.WriteLine("Create dir '" + dirName + "'");
                }
            }
            
        }

        public void DeleteTmp()
        {
            var tmpDir = GetFolderByName(FolderNames.Tmp);

            if (fileSystem.DirectoryExists(tmpDir))
            {
                fileSystem.DeleteDirectory(tmpDir);
            }
            
        }

        public void CopySaveData()
        {
            var saveDataDir = GetFolderByName(FolderNames.SaveData);

            if (fileSystem.DirectoryExists(saveDataDir))
            {
                var destDirName = GetFolderByName(FolderNames.Archive);
                destDirName += fileSystem.GetFileName(saveDataDir.TrimEnd(fileSystem.DirectorySeparatorChar));
                destDirName += "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                fileSystem.MoveDirectory(saveDataDir, destDirName);
            }
        }

        public string GetFolderByName(FolderNames name)
        {
            return GetUserDataFolder() + folders[(int)name];
        }

        public void CreateFile()
        {
            var path = GetFolderByName(FolderNames.SaveData) + "TestFile.txt";

            fileSystem.WriteAllText(path, "Hello World");

            var fileInfo = new FileInfo(path);
            var name = fileSystem.GetFileNameWithoutExtension(fileInfo.FullName);
            var ext = fileInfo.Extension;
            var size = fileInfo.Length;

            Console.WriteLine("Created file " + name + " with ext " + ext + " with a size of " + size + " bytes");

        }

        public void CreateConfig()
        {
            if (!fileSystem.FileExists(configFile))
            {
                fileSystem.WriteAllLines(configFile, folders);
            }
        }

        public void ReadConfig()
        {
            var lines = fileSystem.ReadAllLines(configFile);
            var total = lines.Length;

            Array.Resize(ref folders, total);

            for(var i = 0; i < total; i++)
            {
                var pathString = lines[i];
                Console.WriteLine("Setting path - " + pathString);
                folders[i] = pathString;
            }
        }

        public void ArchiveConfig()
        {
            var configPath = configFile;
            var configName = fileSystem.GetFileName(configPath);
            var tmpPath = GetFolderByName(FolderNames.Tmp) + configName;
            var newPath = GetFolderByName(FolderNames.SaveData) + configName;

            fileSystem.CopyFile(configPath, tmpPath);

            var lines = fileSystem.ReadAllLines(tmpPath);
            var configString = String.Join(Environment.NewLine, lines);
            var workspaceDirName = fileSystem.GetDirectoryName(GetFolderByName(FolderNames.Workspace));
            var newWorkspaceDirName = workspaceDirName + DateTime.Now.ToString("yyyyMMddHHmmss");

            configString = configString.Replace(workspaceDirName, newWorkspaceDirName);

            fileSystem.WriteAllText(tmpPath, configString);

            fileSystem.MoveFile(tmpPath, newPath);
        }

        public void SaveImage()
        {
            var imagefileName = GetFolderByName(FolderNames.SaveData) + "Image.jpg";

            var bitmap = new Bitmap(128, 128, PixelFormat.Format24bppRgb);
            var g = Graphics.FromImage(bitmap);
            g.Clear(Color.Magenta);

            bitmap.Save(imagefileName, ImageFormat.Jpeg);
        }

        public string GetUserDataFolder()
        {
            var dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            dir += @"\FileSystemTest\";

            if (!fileSystem.DirectoryExists(dir))
            {
                fileSystem.CreateDirectory(dir);
            }

            return dir;

        }
    }
}
