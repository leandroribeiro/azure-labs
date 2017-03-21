using Microsoft.Azure;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.AzureServiceBus.Topics.Receiver
{
    class Program
    {
        static void Main(string[] args)
        {
            //string connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");
            string connectionString = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];

            SubscriptionClient Client =
                SubscriptionClient.CreateFromConnectionString
                        (connectionString, "TestTopic", "HighMessages");

            // Configure the callback options.
            OnMessageOptions options = new OnMessageOptions();
            options.AutoComplete = false;
            options.AutoRenewTimeout = TimeSpan.FromMinutes(1);

            Client.OnMessage((message) =>
            {
                try
                {
                    // Process message from subscription.
                    Console.WriteLine("\n**High Messages**");
                    Console.WriteLine("Body: " + message.GetBody<string>());
                    Console.WriteLine("MessageID: " + message.MessageId);
                    Console.WriteLine("Message Number: " +
                        message.Properties["MessageNumber"]);

                    // Remove message from subscription.
                    message.Complete();
                }
                catch (Exception)
                {
                    // Indicates a problem, unlock message in subscription.
                    message.Abandon();
                }
            }, options);
        }
    }
}
