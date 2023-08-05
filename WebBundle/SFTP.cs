using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Renci.SshNet;

namespace WebBundle
{
    /*
    1.Go to the solution explorer of your source code.Right click on the project name and go the properties.
    2.go to the Build tab if you are using c# and select the check box Xml documentation file.
    3.When you build your source code the Xml file will be generated in the location where your dll is present.
    4.while copy your dll to the solution copy the xml file and paste into the bin of your destination solution.

    Just as a reminder, there are separate settings for Debug and Release! 
    You can check/uncheck "Xml documentation file" for both of them separately in your project settings.
    */
    public class SFTP
    {
        /// <summary>
        /// class members/instance variables
        /// </summary>
        private string server = null;
        private string username = null;
        private string password = null;
        private int port = 0;
        private string serverPath = null;

        /// <summary>
        /// Parameterize Constructor of SFTP class
        /// </summary>
        /// <param name="server">A string input</param>
        /// <param name="username">A string input</param>
        /// <param name="password">A string input</param>
        /// <param name="port">A string input</param>
        /// <param name="serverPath">A string input</param>
        public SFTP(string server, string username, string password, string port, string serverPath)
        {
            this.server = server;
            this.username = username;
            this.password = password;
            this.port = Convert.ToInt32(port);
            this.serverPath = serverPath+@"\";
        }
        
        /// <summary>
        /// This method is to upload the local file to SFTP server path that passes through SFTP object. 
        /// </summary>
        /// <param name="ob">An object of SFTP class</param>
        /// <param name="fileLocalPath">Pass full path of local file as a string input</param>
        /// <exception cref="Exception"></exception>
        public static void uploadFileToServer(SFTP ob, string fileLocalPath)
        {
            try
            {
                string server = ob.server;
                string username = ob.username;
                string password = ob.password;
                int intPort = ob.port;
                string serverPath = ob.serverPath;
                string Filename = Path.GetFileName(fileLocalPath);
                using (SftpClient sftp = new SftpClient(server, intPort, username, password))
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    sftp.Connect();
                    using (FileStream filestream = File.OpenRead(fileLocalPath))
                    {
                        sftp.UploadFile(filestream, serverPath + Filename, null);
                        sftp.Disconnect();
                        sftp.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("SFTP File Upload Failure: " + ex.StackTrace);
            }
        }

        /// <summary>
        /// This method is to get list of files in SFTP server path.
        /// </summary>
        /// <param name="ob">An object of SFTP class</param>
        /// <returns>Dictionary&#60;string, Renci.SshNet.Sftp.SftpFile&#62;</returns>
        /// <exception cref="Exception"></exception>
        public static Dictionary<string, Renci.SshNet.Sftp.SftpFile> getListFromServer(SFTP ob)
        {
            Dictionary<string, Renci.SshNet.Sftp.SftpFile> fileDict = null;
            try
            {
                string server = ob.server;
                string username = ob.username;
                string password = ob.password;
                int intPort = ob.port;
                string serverPath = ob.serverPath;                              
                using (SftpClient sftp = new SftpClient(server, intPort, username, password))
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    sftp.Connect();
                    IEnumerable<Renci.SshNet.Sftp.SftpFile> sftpFileList = null;
                    sftpFileList = sftp.ListDirectory(serverPath).Where(f => !f.IsDirectory);
                    fileDict = new Dictionary<string, Renci.SshNet.Sftp.SftpFile>();
                    foreach (var file in sftpFileList)
                    {
                        string fileName = file.Name.ToString();
                        Renci.SshNet.Sftp.SftpFile sftpFileObject = file;
                        fileDict.Add(fileName,sftpFileObject);
                    }
                    sftp.Disconnect();
                    sftp.Dispose();                
                }
            }
            catch (Exception ex)
            {
                throw new Exception("SFTP Get File List Failure: " + ex.StackTrace);
            }
            return fileDict;
        }

        /// <summary>
        /// This method is to download target file from SFTP server path to local path.
        /// </summary>
        /// <param name="ob">An object of SFTP class</param>
        /// <param name="targetFileName">Target file full name of SFTP server path</param>
        /// <param name="localPath">Local path where the target file to be downloaded</param>
        /// <exception cref="Exception"></exception>
        public static void downloadFileFromServer(SFTP ob, string targetFileName, string localPath)
        {   
            try
            {
                string server = ob.server;
                string username = ob.username;
                string password = ob.password;
                int intPort = ob.port;                
                using (SftpClient sftp = new SftpClient(server, intPort, username, password))
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                    sftp.Connect();
                    string localFilePath = $"{localPath}/{targetFileName}";
                    using (FileStream fileStream = File.OpenWrite(localFilePath))
                    {
                        string serverTargetFilePath = ob.serverPath + targetFileName;
                        sftp.DownloadFile(serverTargetFilePath, fileStream);
                    }
                    sftp.Disconnect();
                    sftp.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("SFTP File Download Failure: " + ex.StackTrace);
            }
        }
    }
}