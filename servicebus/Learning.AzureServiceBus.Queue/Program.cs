using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;


namespace Learning.AzureServiceBus.Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Endpoint=sb://nstest2017.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=KTWZTIUNX8kiGkO+IjEn972sJtaR2IuZ4YraC9HjPIs=";
            var queueName = "queuetest2017";

            var client = QueueClient.CreateFromConnectionString(connectionString, queueName);
            var message = new BrokeredMessage("This is a test message!");
            client.Send(message);
        }
    }
}
