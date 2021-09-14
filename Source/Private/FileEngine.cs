using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Net.NetworkInformation;
using System.Globalization;
using System.Net;
using System.Text;


namespace Winds_Path.Source.Private
{
    class FileEngine
    {
        /// <summary>
        /// store \text location absolute path
        /// </summary>
        private static string RootPath = "";
        /// <summary>
        /// store source absoloute path
        /// </summary>
        private static string ParentRootPath = "";

        /// <summary>
        /// Get file in the rootpath
        /// </summary>
        /// <param name="fileToFind">the file to find</param>
        /// <returns>the file location</returns>
        public static string GetFilePath(string fileToFind)
        {
            if (fileToFind.Length > 0) return RootPath + "\\" + fileToFind;
            return RootPath;
        }

        /// <summary>
        /// //initilize the class
        /// </summary>
        public static void Init()
        {
            GetRootPath();//get root text folder path
            GetRootPathParent();//parent root folder
        }

        /// <summary>
        /// Get the source path
        /// </summary>
        private static void GetRootPathParent()
        {
            var par = new DirectoryInfo(RootPath);//get full path of current directory
            while (!par.ToString().EndsWith("\\Winds-Path"))//get base directory
            {
                par = par.Parent;
            }
            ParentRootPath = par.ToString();
            RootPath = ParentRootPath + "\\Source\\Private\\Text";//concat the text path
        }

        /// <summary>
        /// 
        /// </summary>
        private static void GetRootPath()
        {
            var relativeTxtPath = Path.GetRelativePath(//get txt path using dummy paths
            @"C:\Program Files\Dummy Folder\Winds-Path",
            @"C:\Program Files\Dummy Folder\Winds-Path\Source\Private\Text");
            string path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);//get txt relative path

            var par = new DirectoryInfo(path);//get full path of current directory
            RootPath = par.ToString() + "\\" + relativeTxtPath;//full path
        }

        /// <summary>
        /// Add file to game
        /// </summary>
        /// <param name="file"></param>
        /// <param name="fileType"> Type 1: Story <br></br>Type 2: Dialogue <br></br>Type 3: Database<br></br>Type 4: Title<br></br>Type 5: Art</param>
        public static void AddGitFile(string file, UInt16 fileType)
        {
            switch (fileType)
            {
                case 1:
                    GetFileFromGit("Story", file);
                    break;
                case 2:
                    GetFileFromGit("Dialogue", file);
                    break;
                case 3:
                    GetFileFromGit("Database", file);
                    break;
                case 4:
                    GetFileFromGit("Title", file);
                    break;
                case 5:
                    GetFileFromGit("Art", file);
                    break;
            }
        }

        /// <summary>
        /// Check if user is connected to inte
        /// </summary>
        /// <param name="timeoutMs">time till timeout</param>
        /// <param name="url">url to connect to site</param>
        /// <returns>if connected to internet</returns>
        public static bool CheckConnection(int timeoutMs = 10000, string url = null)
        {
            try
            {
                //check connection to internet
                url ??= CultureInfo.InstalledUICulture switch//check connection
                {
                    { Name: var n } when n.StartsWith("en-CA") =>//get culture name
                        "http://www.google.ca/",
                    { Name: var n } when n.StartsWith("en-US") =>
                        "http://www.blank.org/",
                    { Name: var n } when n.StartsWith("en-CA") =>
                        "https://twitter.com/",
                    { Name: var n } when n.StartsWith("en-US") =>
                        "https://www.facebook.com/",
                    _ =>
                        "http://www.gstatic.com/generate_204",
                };

                var request = (HttpWebRequest)WebRequest.Create(url);
                request.KeepAlive = false;
                request.Timeout = timeoutMs;
                using (var response = (HttpWebResponse)request.GetResponse())
                    return true;
            }
            catch
            {//if connections fail ping websites
                string[] hosts = { "google.com", "facbook.com", "amazon.com" };
                UInt16 good = 0;
                for (UInt16 i = 0; i < hosts.Length; ++i)
                {
                    if (FinalConnectionTest(hosts[i])) ++good;
                }
                if (good >= 2) return true;
                else return false;
            }
        }

        /// <summary>
        /// Final test to see if connected to internet
        /// </summary>
        /// <param name="host">domain to ping</param>
        /// <returns>if connection was estabished</returns>
        private static bool FinalConnectionTest(string host)
        {
            try
            {
                Ping myPing = new Ping();
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);//see if connected to internet
                return (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Get file from repositry
        /// </summary>
        /// <param name="subfolder">subfolder where the file is located</param>
        /// <param name="fileName">name of file to find</param>
        public static void GetFileFromGit(string subfolder, string fileName)
        {
            var wc = new WebClient();
            if (!File.Exists(GetFilePath("")))
            {
                if(CheckConnection())
                    wc.DownloadFile("https://raw.githubusercontent.com/Charles-Ay/Winds-Path-Files/main/" + subfolder + "/" + fileName, GetFilePath(fileName));//get file form github
            }
        }

        /// <summary>
        /// Read file from repo
        /// </summary>
        /// <param name="subfolder">subfolder where the file is located</param>
        /// <param name="fileName">name of file to find</param>
        /// <returns>a string containing the file text</returns>
        public static string ReadFileFromGIT(string subfolder, string fileName)
        {
            var wc = new WebClient();
            if (CheckConnection())
            {
                Stream myStream = wc.OpenRead("https://raw.githubusercontent.com/Charles-Ay/Winds-Path-Files/main/" + subfolder + "/" + fileName);
                StreamReader sr = new StreamReader(myStream);
                string temp = sr.ReadToEnd();
                sr.Close();//house keeping
                return temp;
                // Console.WriteLine( "Reading GIT File: " + sr.ReadToEnd());
            }
            return "";
        }
        /// <summary>
        /// delete file in directory
        /// </summary>
        /// <param name="fileName">file to delete</param>
        public static void RemoveFile(string fileName)
        {
            string[] fileList = System.IO.Directory.GetFiles(RootPath, fileName);
            foreach (string file in fileList)
            {
                System.IO.File.Delete(file);
            }
        }

/*        public static void test()
        {
            Console.WriteLine(RootPath);
            Console.WriteLine(ParentRootPath);
            GetFileFromGit("Story", "Intro.txt");
        }*/

    }
}