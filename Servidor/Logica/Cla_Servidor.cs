using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Threading.Tasks;

namespace Servidor
{
    public class Cla_Servidor
    {
        #region Atributos

        private TcpListener tcpListener;
        private Thread listenThread;

        #endregion

        #region Metodos

        public void ServidorTcp()
        {
            tcpListener = new TcpListener(IPAddress.Any, 30000);
            listenThread = new Thread(new ThreadStart(ListenForClients));
            listenThread.Start();
        }

        private void ListenForClients()
        {
            tcpListener.Start();
            while (true)
            {
                //blocks until a client has connected to the server
                TcpClient client = tcpListener.AcceptTcpClient();
                //create a thread to handle communication
                //with connected client
                var clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
            }
        }

        private void HandleClientComm(object client)
        {
            var tcpClient = (TcpClient)client;
            var clientStream = tcpClient.GetStream();
            var encoder = new ASCIIEncoding();

            byte[] buffer = encoder.GetBytes("Connected");
            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();

            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {

                bytesRead = 0;
                try
                {
                    //blocks until a client sends a message
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    //a socket error has occured
                    break;
                }
                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                    break;
                }
                //message has successfully been received
                encoder = new ASCIIEncoding();
                System.Diagnostics.Debug.WriteLine(encoder.GetString(message, 0, bytesRead));
            }
            tcpClient.Close();
        }

        #endregion
    }
}
