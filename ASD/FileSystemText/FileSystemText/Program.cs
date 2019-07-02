using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace FileSystemText
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
            app.ArchiveConfig();
            app.SaveImage();
            app.CopySaveData();
            app.DeleteTemp();
            Console.ReadKey();
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
            @"Workspace\temp\",
            @"Workspace\temp\SaveData\"
        };
        public enum FolderNames
        {
            Workspace,
            Archive,
            Temp,
            SaveData
        }
        public string configFile
        {
            get { return GetUserDataFolder() + "Config.txt"; }
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
        public void DeleteTemp()
        {
            var tmpDir = GetFolderByName((FolderNames.Temp));
            if (fileSystem.DirectoryExists(tmpDir))
            {
                fileSystem.DirectoryDelete(tmpDir, true);
            }
        }
        public void CopySaveData()
        {
            var saveDataDir = GetFolderByName(FolderNames.SaveData);
            if (fileSystem.DirectoryExists(saveDataDir))
            {
                var destDirName = GetFolderByName(FolderNames.Archive);
                destDirName += Path.GetFileName(saveDataDir.TrimEnd(Path.DirectorySeparatorChar));
                destDirName += "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                Directory.Move(saveDataDir, destDirName);
            }
        }
        public string GetFolderByName(FolderNames name)
        {
            return GetUserDataFolder() + folders[(int)name];
        }
        public void CreateFile()
        {
            var path = GetFolderByName(FolderNames.SaveData) + "TestFile.txt";

            File.WriteAllText(path, "Hello World");

            var fileInfo = new FileInfo(path);
            var name = Path.GetFileNameWithoutExtension(fileInfo.FullName);
            var ext = fileInfo.Extension;
            var size = fileInfo.Length;

            Console.WriteLine("Created file " + name + " with ext " + ext + " with a size of " + size + " bytes");
        }
        public void CreateConfig()
        {
            if (!File.Exists(configFile))
            {
                File.WriteAllLines(configFile, folders);
            }
        }
        public void ReadConfig()
        {
            var lines = File.ReadAllLines(configFile);
            var total = lines.Length;

            Array.Resize(ref folders, total);

            for (var i = 0; i < total; i++)
            {
                var pathString = lines[i];
                Console.WriteLine("Setting path - " + pathString);
                folders[i] = pathString;
            }
        }
        public void ArchiveConfig()
        {
            var configPath = configFile;
            var configName = Path.GetFileName(configPath);
            var tmpPath = GetFolderByName(FolderNames.Temp) + configName;
            var newPath = GetFolderByName(FolderNames.SaveData) + configName;

            File.Copy(configPath, tmpPath);

            var lines = File.ReadAllLines(tmpPath);
            var configString = String.Join(Environment.NewLine, lines);
            var workspaceDirName = Path.GetDirectoryName(GetFolderByName(FolderNames.Workspace));
            var newWorkspaceDirName = workspaceDirName + DateTime.Now.ToString("yyyyMMddHHmmss");

            configString = configString.Replace(workspaceDirName, newWorkspaceDirName);

            File.WriteAllText(tmpPath, configString);

            var lines2 = File.ReadAllLines(tmpPath);
            var configString2 = String.Join(Environment.NewLine, lines2);
            var workspaceDirName2 = Path.GetDirectoryName(GetFolderByName(FolderNames.Workspace));
            var newWorkSpaceDirName2 = workspaceDirName2 + DateTime.Now.ToString("yyyyMMddHHmmss");

            configString2 = configString2.Replace(newWorkSpaceDirName2, newWorkSpaceDirName2);

            File.WriteAllText(tmpPath, configString2);

            File.Move(tmpPath, newPath);
        }
        public void SaveImage()
        {
            var imageFileName = GetFolderByName(FolderNames.SaveData) + "image.jpg";

            var bitmap = new Bitmap(128, 128, PixelFormat.Format24bppRgb);
            var g = Graphics.FromImage(bitmap);
            g.Clear(Color.Magenta);

            bitmap.Save(imageFileName, ImageFormat.Jpeg);
        }
        public string GetUserDataFolder()
        {
            var dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            dir2 += @"\FileSystemTest\";
            if(!fileSystem.DirectoryExists(dir2))
            {
                fileSystem.CreateDirectory(dir2);
            }

            return dir2;
        }
    }
}
