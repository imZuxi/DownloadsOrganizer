using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
            string[] ImgList =
                { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff", ".ico", ".svg", ".webp", ".heic", ".psd" };
            string[] VideoList = { ".mp4", ".avi", ".mov", ".wmv", ".mkv", ".flv", ".webm", ".m4v", ".mpg", ".mpeg", ".3gp", ".m3u8" };
            string[] CompressedList = { ".zip", ".rar", ".7z", ".tar", ".gz", ".bz2", ".xz", ".z", ".iso" };
            string[] AudioList = { ".mp3", ".wav", ".m4a", ".aac", ".ogg", ".flac", ".wma", ".aiff", ".alac", ".opus" };
            string[] windowsExecutablesList = { ".exe", ".dll", ".bat", ".cmd", ".com", ".msi", ".ps1", ".scr", ".jar" };
            string[] TextFile = { ".txt", ".json", ".csv", ".pdf" };
            string[] threedfiles = { ".unitypackage", ".fbx", ".prefab" };
            // setup dir path to not have to rewrite them :P

            string VideoPath = Path.Combine(DlowF, "Videos");
            string UnityPackagePath = Path.Combine(DlowF, "UnityPackage");
            string ZipPath = Path.Combine(DlowF, "CompressedFiles");
            string MusicPath = Path.Combine(DlowF, "Music");
            string ExecutablesPath = Path.Combine(DlowF, "Executables");
            string imgPath = Path.Combine(DlowF, "Images");
            string TextPath = Path.Combine(DlowF, "TextFiles");
            //Loop through all files in Downloads Folder
            foreach (string text in Directory.GetFiles(DlowF))
            {
                
                // Add to our total Number :P
                totalFiles++;
                Console.Title = "Download Organiser Moved: " + totalFilesMoved + "/" + totalFiles + " Files!";
                //Get The File Info
                FileInfo fi = new FileInfo(text);


                Console.Write("{0}", fi.Name);


                // Check For current file if it is continue though the loop instead of attempting to move it
                if (fi.FullName.ToLower() == System.AppDomain.CurrentDomain.FriendlyName.ToLower())
                    continue;


                try
                {
                    // Do the File Moveing 
                    if (ImgList.Contains<string>(fi.Extension.ToLower()))
                    {
                        if (!Directory.Exists(imgPath))
                            Directory.CreateDirectory(imgPath);
                        
                       
                        
                        File.Move(text, imgPath + "\\" + fi.Name);
                       // Console.WriteLine(fi.Name);
                        totalFilesMoved++;
                         
                        Console.WriteLine($" -> Moved SuccessFully");
                    }

                    if (VideoList.Contains<string>(fi.Extension.ToLower()))
                    {
                        if (!Directory.Exists(VideoPath))
                            Directory.CreateDirectory(VideoPath);
                        File.Move(text, VideoPath + "\\" + fi.Name);
                      
                        totalFilesMoved++;
                        Console.Write($" -> Moved SuccessFully");
                    }

                    if (CompressedList.Contains<string>(fi.Extension.ToLower()))
                    {
                        if (!Directory.Exists(ZipPath))
                            Directory.CreateDirectory(ZipPath);
                        File.Move(text, ZipPath + "\\" + fi.Name);
                       // Console.WriteLine(fi.Name);
                        totalFilesMoved++;


                        Console.Write($" -> Moved SuccessFully");
                    }

                    if (AudioList.Contains<string>(fi.Extension.ToLower()))
                    {
                        if (!Directory.Exists(MusicPath))
                            Directory.CreateDirectory(MusicPath);
                        File.Move(text, MusicPath + "\\" + fi.Name);
                       // Console.WriteLine(fi.Name);
                        totalFilesMoved++;

                        Console.Write($" -> Moved SuccessFully");
                    }
                   
                    if (windowsExecutablesList.Contains<string>(fi.Extension.ToLower()))
                    {
                        if (!Directory.Exists(ExecutablesPath))
                            Directory.CreateDirectory(ExecutablesPath);
                        File.Move(text, ExecutablesPath + "\\" + fi.Name);
                        //Console.WriteLine(fi.Name);
                        totalFilesMoved++;

                        Console.Write($" -> Moved SuccessFully");
                    }

                    if (TextFile.Contains<string>(fi.Extension.ToLower()))
                    {
                        if (!Directory.Exists(TextPath))
                            Directory.CreateDirectory(TextPath);
                        File.Move(text, TextPath + "\\" + fi.Name);
                        //Console.WriteLine(fi.Name);
                        totalFilesMoved++;

                        Console.Write($" -> Moved SuccessFully");
                    }

                    if (threedfiles.Contains<string>(fi.Extension.ToLower()) )
                    {
                        if (!Directory.Exists(UnityPackagePath))
                            Directory.CreateDirectory(UnityPackagePath);

                        File.Move(text, UnityPackagePath + "\\" + fi.Name);
                        //Console.WriteLine(fi.Name);

                        Console.Write($" -> Moved SuccessFully");
                        totalFilesMoved++;
                    }
                    Console.WriteLine("!");
                }
                catch (Exception ex) { Console.WriteLine(); Console.WriteLine(ex.Message); continue; }
            }

            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("Done! Successfully moved: " + totalFilesMoved + "/" + totalFiles + " Files!");
            System.Threading.Thread.Sleep(20000);
        }
    }
}
