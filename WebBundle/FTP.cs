using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebBundle
{
    public class FTP
    {
        private string FTP_Server = string.Empty;
        private string FTP_Username = string.Empty;
        private string FTP_Password = string.Empty;
        private string remoteVendorDirectory = string.Empty;

        public FTP(string server_name, string user_name, string password, string directory = null)
        {
            this.FTP_Server = server_name;
            this.FTP_Username = user_name;
            this.FTP_Password = password;
            this.remoteVendorDirectory = directory;
        }

        /// <summary>
        /// This is a method that returns list of all files in FTP server
        /// </summary>
        /// <param name="ob">FTP class object</param>
        /// <returns>List&#60;string&#62;</returns>
        public static List<string> getListOfFiles(FTP ob)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ob.FTP_Server);
                request.Method = WebRequestMethods.Ftp.ListDirectory;

                request.Credentials = new NetworkCredential(ob.FTP_Username, ob.FTP_Password);
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string names = reader.ReadToEnd();
                reader.Close();
                response.Close();

                return names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            catch (Exception exp)
            {
                Console.WriteLine("Server Exception:\n" + exp.Message.ToString());
                return new List<string>();
            }
        }

        /// <summary>
        /// This is a recursive method that returns list of all files in FTP server using URL
        /// </summary>
        /// <param name="ob">FTP class object</param>
        /// <param name="url">URL of FTP server</param>
        /// <param name="fileList">Reference of List&#60;string&#62;</param>
        public static void getListOfFiles(FTP ob, string url, ref List<string> fileList)
        {
            try
            {
                WebRequest listRequest = WebRequest.Create(url);
                listRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                NetworkCredential credentials = new NetworkCredential(ob.FTP_Username, ob.FTP_Password);
                listRequest.Credentials = credentials;
                List<string> lines = new List<string>();
                using (WebResponse listResponse = listRequest.GetResponse())
                using (Stream listStream = listResponse.GetResponseStream())
                using (StreamReader listReader = new StreamReader(listStream))
                {
                    while (!listReader.EndOfStream)
                    {
                        string line = listReader.ReadLine();
                        lines.Add(line);
                    }
                }
                foreach (string line in lines)
                {
                    string[] tokens = line.Split(new[] { ' ' }, 9, StringSplitOptions.RemoveEmptyEntries);
                    string name = tokens[8];
                    string permissions = tokens[0];
                    if (permissions[0] == 'd')
                    {
                        string fileUrl = url + name;
                        getListOfFiles(ob,fileUrl + "/", ref fileList);
                    }
                    else
                    {
                        fileList.Add(url + name);
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine($"Exception {exp.StackTrace}");
            }
        }


        /// <summary>
        /// This method download files from FTP server to local machine
        /// </summary>
        /// <param name="ob">FTP class object</param>
        /// <param name="ftpFilePath">FTP server file path</param>
        /// <param name="localFilePath">Local machine file path</param>
        /// <returns>true if file download successfully, else false</returns>
        public static bool downloadFileFromServer(FTP ob, string ftpFilePath, string localFilePath)
        {
            try
            {
                WebClient client = new WebClient();
                client.Credentials = new NetworkCredential(ob.FTP_Username, ob.FTP_Password);
                client.DownloadFile(ftpFilePath, localFilePath);
                return true;
            }
            catch (Exception exp)
            {
                Console.WriteLine($"Exception {exp.StackTrace}");
                return false;
            }
        }

    }
}
