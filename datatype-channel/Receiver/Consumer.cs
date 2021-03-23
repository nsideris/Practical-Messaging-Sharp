﻿using System;
using Model;
using Newtonsoft.Json;
using SimpleMessaging;

namespace Sender
{
    class Consumer
    {
        static void Main(string[] args)
        {
            using (var channel = new DataTypeChannelConsumer<Greeting>(DeserializeMessage))
            {
                var greeting = channel.Receive();
                if (greeting != null)
                    Console.WriteLine("Received message {0}", greeting.Salutation);
                else
                    Console.WriteLine("Did not receive message");
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }

        private static Greeting DeserializeMessage(string messageBody)
        {
            return JsonConvert.DeserializeObject<Greeting>(messageBody);
        }
    }
}