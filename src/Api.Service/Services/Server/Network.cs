using System.Net.Sockets;
using System;
using System.Net.NetworkInformation;
using System.Net;

namespace Api.Service.Services.Server
{
    public class Network
    {
        private static IPAddress hostname;
        private static int port; //<--- This is port value
        private static bool isAvailable;
        public Network(int Port, IPAddress Hostname)
        {
            isAvailable = false;

            if (Port <= 1000 || Port >= 65000)
            {
                newport();
            }
            else
            {
                port = Port;
            }

            hostname = Hostname;

        }

        public int scan_openports()
        {

            while (isAvailable != true)
            {
                IPAddress ipAddress = Dns.GetHostEntry(hostname).AddressList[0];
                TcpListener tcp = new TcpListener(hostname, port);
                tcp.Start();
                if (tcp.ExclusiveAddressUse == true)
                {
                    isAvailable = true;
                }
                else
                {
                    isAvailable = false;
                    newport();
                }
            }
            return port;

        }

        private static int newport()
        {

            Random numAleatorio = new Random();
            return port = numAleatorio.Next(1000, 64999);

        }
    }
}




