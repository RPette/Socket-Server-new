using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Socket_Server
{
    internal class Prodotto
    {
        public string Nome = "Corda";
        public int Quantita = 1347;
        public int Prezzo = 5;
    }

    internal class Stringa
    {
        public int IndiceFineStringa(string s)
        {
            int indice = -1;
            bool finito = false;
            int trovate = 3;
            int i = 0;
            while (!finito)
            {
                if (s[i] == ';')
                {
                    trovate--;
                }
                if (trovate == 0)
                {
                    finito = true;
                    indice = i;
                }
                i++;
            }
            return indice;
        }

    }

    internal class Program
    { 
        public static string url = "http://127.0.0.1:80/";
        public static string path = @"C:\Users\ricca\source\repos\Socket-Server\Socket-Server\comuni.txt";
        public static string Indirizzo = "";

        static void Main(string[] args)
        {
            int porta_nota = 8000;
            Console.WriteLine("Starting Server (Listening on port " + porta_nota + ")");
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, porta_nota);

            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localEndPoint); //associamo il socket TCP alla coppia <ip, porta_nota>

            Console.WriteLine("Waiting for a connection...");

            listener.Listen(100);// Server in ascolto in attesa di connessioni

            Socket handler = listener.Accept();

            Console.WriteLine("New incoming connection!");
            

            handler.Shutdown(SocketShutdown.Both);
            handler.Close();

            //127.0.0.1:80/Comuni

            /*Stringa s = new Stringa();
            List<string> listaTesto = File.ReadAllLines(path).ToList<string>();
            List<string> provvisorio = new List<string>();
            foreach (string str in listaTesto)
            {
                provvisorio.Add(str.Substring(0, s.IndiceFineStringa(str)));
            }
            Prodotto p = new Prodotto();
            var file = JsonConvert.SerializeObject(p, Formatting.Indented);
            Console.WriteLine(file);
            Console.ReadLine();



            byte[] data = Encoding.UTF8.GetBytes(file);


            }*/
        }
    }
}
