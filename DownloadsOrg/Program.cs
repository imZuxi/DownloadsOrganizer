using System;
using System.IO;
using System.Linq;

namespace DownloadsMover9000
{
    internal class Download
    {
        static void Main(string[] args)
        {
           
            //Setup for Total Files Moved

            int totalFilesMoved = 0;
            int totalFiles = 0;

            // Get Users Download Folder

            string UserFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string DlowF = Path.Combine(UserFolder, "Downloads");

            // Common File Extentions Add or Change as needed :P
            string[] ImgList = { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff", ".ico", ".svg", ".webp", ".heic" };
            string[] VideoList = { ".mp4", ".avi", ".mov", ".wmv", ".mkv", ".flv", ".webm", ".m4v", ".mpg", ".mpeg", ".3gp" };
            string[] CompressedList = { ".zip", ".rar", ".7z", ".tar", ".gz", ".bz2", ".xz", ".z" };
            string[] AudioList = { ".mp3", ".wav", ".m4a", ".aac", ".ogg", ".flac", ".wma", ".aiff", ".alac", ".opus" };
            string[] windowsExecutablesList = { ".exe", ".dll", ".bat", ".cmd", ".com", ".msi", ".ps1", ".scr", ".jar" };
            
            // setup dir path to not have to rewrite them :P

            string VideoPath = Path.Combine(DlowF, "Videos");
            string UnityPackagePath = Path.Combine(DlowF, "UnityPackage");
            string ZipPath = Path.Combine(DlowF, "CompressedFiles");
            string MusicPath = Path.Combine(DlowF, "Music");
            string ExecutablesPath = Path.Combine(DlowF, "Executables");
            string imgPath = Path.Combine(DlowF, "Images");

            //Loop through all files in Downloads Folder
            foreach (string text in Directory.GetFiles(DlowF))
            {
                // Add to our total Number :P
                totalFiles++;
                Console.Title = "Download Organiser Moved: " + totalFilesMoved + "/" + totalFiles + " Files!";
                //Get The File Info
                FileInfo fi = new FileInfo(text);

                // Check For current file if it is continue though the loop instead of attempting to move it
                if (fi.FullName.ToLower() == System.AppDomain.CurrentDomain.FriendlyName.ToLower())
                    continue;

                try
                {
                    // Do the File Moveing 
                    if (ImgList.Contains<string>(fi.Extension))
                    {
                        if (!Directory.Exists(imgPath))
                            Directory.CreateDirectory(imgPath);
                        File.Move(text, imgPath + "\\" + fi.Name);
                        Console.WriteLine(fi.Name);
                        totalFilesMoved++;
                    }

                    if (VideoList.Contains<string>(fi.Extension))
                    {
                        if (!Directory.Exists(VideoPath))
                            Directory.CreateDirectory(VideoPath);
                        File.Move(text, VideoPath + "\\" + fi.Name);
                        Console.WriteLine(fi.Name);
                        totalFilesMoved++;
                    }

                    if (CompressedList.Contains<string>(fi.Extension))
                    {
                        if (!Directory.Exists(ZipPath))
                            Directory.CreateDirectory(ZipPath);
                        File.Move(text, ZipPath + "\\" + fi.Name);
                        Console.WriteLine(fi.Name);
                        totalFilesMoved++;
                    }

                    if (AudioList.Contains<string>(fi.Extension))
                    {
                        if (!Directory.Exists(MusicPath))
                            Directory.CreateDirectory(MusicPath);
                        File.Move(text, MusicPath + "\\" + fi.Name);
                        Console.WriteLine(fi.Name);
                        totalFilesMoved++;
                    }
                   
                    if (windowsExecutablesList.Contains<string>(fi.Extension))
                    {
                        if (!Directory.Exists(ExecutablesPath))
                            Directory.CreateDirectory(ExecutablesPath);
                        File.Move(text, ExecutablesPath + "\\" + fi.Name);
                        Console.WriteLine(fi.Name);
                        totalFilesMoved++;
                    }

                    if (text.ToLower().Contains(".unitypackage"))
                    {
                        File.Move(text, UnityPackagePath + "\\" + fi.Name);
                        Console.WriteLine(text);
                        totalFilesMoved++;
                    }

                }
                catch (Exception ex) { Console.WriteLine(ex.Message); continue; }
            }

            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("Done! Successfully moved: " + totalFilesMoved + "/" + totalFiles + " Files!");
            Console.ReadLine();
        }
    }
}
