using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        IPAddress broadcast;

        if (args[2] == "ip") {
            broadcast = IPAddress.Parse(args[0]);
        }
        else {
            broadcast = Dns.GetHostEntry(args[0]).AddressList[0];
        }
        
        
        Console.WriteLine(broadcast);

        byte[] sendbuf = Encoding.ASCII.GetBytes(args[1]);
        
        IPEndPoint ep = new IPEndPoint(broadcast, 11000);

        s.SendTo(sendbuf, ep);

        Console.WriteLine("Message sent to the broadcast address");
    }
}