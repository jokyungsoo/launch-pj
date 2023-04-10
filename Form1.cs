using System;
using System.Windows.Forms;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.IO.Compression;

namespace Launcher
{

   

        
            
    public partial class Form1 : Form
    {
        string version;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void DownloadVersion()
        {
            WebClient Client = new WebClient();
            Client.DownloadFile("https://drive.google.com/file/d/1Qdudlng_6TzY6JAjzaYYcWB4zmAUGgeb/view?usp=sharing", @"C:\Weus\version.json");

        }
        private void DownloadGame()
        {
            WebClient Client = new WebClient();
            Client.DownloadFile("https://drive.google.com/file/d/1-9CVl4KyAzcY40fRIjaWMMIECVYrqL4E/view?usp=sharing", @"C:\Weus\Game.zip");
        }
        
        public static bool UnzipFile(string zipPath, string unzipPath)
        {

            try
            {
                if (Directory.Exists(unzipPath))
                {
                    Directory.Delete(unzipPath);
                }

                ZipFile.ExtractToDirectory(zipPath, unzipPath);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            string zipPath = @"C:\Weus\Game.zip";
            string unzipPath = @"C:\Weus\gamefile";
            DirectoryInfo Di = new DirectoryInfo(@"C:\Weus");

            if(Di.Exists == false)
            {
                Di.Create();
                DownloadVersion();
                DownloadGame();
                UnzipFile(zipPath, unzipPath);
            }
            else
            {
                DownloadVersion();
                DownloadGame();
                UnzipFile(zipPath, unzipPath);
            }
        }
    }
}
