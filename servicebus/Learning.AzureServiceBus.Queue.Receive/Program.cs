using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;

namespace Learning.AzureServiceBus.Queue.Receive
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Endpoint=sb://nstest2017.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=KTWZTIUNX8kiGkO+IjEn972sJtaR2IuZ4YraC9HjPIs=";
            var queueName = "queuetest2017";

            var client = QueueClient.CreateFromConnectionString(connectionString, queueName);

            client.OnMessage(message =>
            {
                Console.WriteLine(String.Format("Message body: {0}", message.GetBody<String>()));
                Console.WriteLine(String.Format("Message id: {0}", message.MessageId));
            });

            Console.ReadLine();
        }
    }
}
