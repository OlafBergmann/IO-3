using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;


namespace IOLab3
{
    class TResultDataStructure
    {
        public int A { get; set; }

        public int B { get; set; }
    }

    class Zadanie2
    {
        public bool Z2 { get; set; }

        public Task<Boolean> OperationTask()
        {

            return Task.Run(() =>
            {
                Z2 = false;
                return Z2;
            });

        }
    }


    class Program
    {
        public static Task<TResultDataStructure> OperationTask()
        {
            {
                return Task.Run(() =>
                {
                    return new TResultDataStructure
                    {
                        A = 1,
                        B = 2
                    };
                });
            }
        }

        public static async Task<XmlDocument> Zadanie3(string address)
        {
            WebClient webClient = new WebClient();
            var result = await webClient.DownloadStringTaskAsync(new Uri(address));
            XmlDocument xml = new XmlDocument { InnerXml = result };
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(result);
            return xml;
        }

        static void Main(string[] args)
        {

            Task task = OperationTask();
            var zad2 = new Zadanie2().OperationTask().Result;
            Console.WriteLine(zad2);
            Console.WriteLine(Zadanie3("http://www.feedforall.com/sample.xml").Result.InnerXml);

            Thread.Sleep(100000);
            Console.ReadKey();
        }
    }
}