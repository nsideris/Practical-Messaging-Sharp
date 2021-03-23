using System;
using Model;
using Newtonsoft.Json;
using SimpleMessaging;

namespace Sender
{
    class Producer
    {
        static void Main(string[] args)
        {
            using (var channel = new DataTypeChannelProducer<Greeting>(SerializeMessage))
            {
                var greeting = new Greeting();
                greeting.Salutation = "Hello World!";
                channel.Send(greeting);
                Console.WriteLine("Sent message {0}", greeting.Salutation);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }

        private static string SerializeMessage(Greeting greeting)
        {
            return JsonConvert.SerializeObject(greeting);
        }
    }
}