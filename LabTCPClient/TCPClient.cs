using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LabTCPClient
{
    public class TCPClient
    {
        private const int BUFFER_SIZE = 1024;
        private const int PORT_NUMBER = 9999;

        private static ASCIIEncoding encoding = new ASCIIEncoding();

        public static void Run()
        {
            try
            {
                TcpClient client = new TcpClient();

                // 1. Connect
                client.Connect("127.0.0.1", PORT_NUMBER);
                Stream stream = client.GetStream();

                Console.WriteLine("Connected to TCP Server");

                Console.WriteLine("Enter your name: ");

                string str = Console.ReadLine();

                // 2. Send
                byte[] data = encoding.GetBytes(str);
                stream.Write(data, 0, data.Length);

                // 3. Receiver
                data = new byte[BUFFER_SIZE];
                stream.Read(data, 0, BUFFER_SIZE);

                Console.WriteLine(encoding.GetString(data));

                // 4. Close
                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }

            Console.Read();
        }
    }
}
