using Microsoft.Azure;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.AzureServiceBus.Topics.Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            //string connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");
            string connectionString = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];

            TopicClient Client =
                TopicClient.CreateFromConnectionString(connectionString, "TestTopic");

            for (int i = 0; i < 5; i++)
            {
                // Create message, passing a string message for the body.
                BrokeredMessage message = new BrokeredMessage("Test message " + i);

                // Set additional custom app-specific property.
                message.Properties["MessageId"] = i;

                // Send message to the topic.
                Client.Send(message);
            }
        }
    }
}
