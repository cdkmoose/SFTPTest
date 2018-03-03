using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Renci.SshNet;

namespace SFTPConsoleTest
{
    class Program
    {
        private static void ListFiles()
        {
            string host = @"centosnote";
            string username = "sftpuser";
            string password = @"sftpuser";

            string remoteDirectory = "/home/sftpuser/ftproot";

            using (SftpClient sftp = new SftpClient(host, username, password))
            {
                try
                {
                    sftp.Connect();

                    var files = sftp.ListDirectory(remoteDirectory);

                    foreach (var file in files)
                    {
                        if (file.IsDirectory)
                            Console.WriteLine("Directory -> " + file.Name);
                        else if (file.IsRegularFile)
                            Console.WriteLine("File -> " + file.Name);
                        else
                            Console.WriteLine("Other -> " + file.Name);
                    }

                    sftp.DeleteDirectory("/home/sftpuser/ftproot/spanish/P456456");
                    sftp.Disconnect();
                }
                catch (Exception e)
                {
                    Console.WriteLine("An exception has been caught " + e.ToString());
                }
            }
        }

        static void Main(string[] args)
        {
            ListFiles();

            Console.ReadLine();
        }
    }
}
