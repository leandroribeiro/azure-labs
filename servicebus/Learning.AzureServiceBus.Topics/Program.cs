using Microsoft.Azure;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.AzureServiceBus.Topics
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateTopic();

            // Create a "MatchAll" subscription
            //string connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");
            string connectionString = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"].ToString();

            var namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);

            if (!namespaceManager.SubscriptionExists(GetTopicName(), "AllMessages"))
            {
                namespaceManager.CreateSubscription(GetTopicName(), "AllMessages");
            }

            // Create a "HighMessages" filtered subscription.
            SqlFilter highMessagesFilter =
               new SqlFilter("MessageNumber > 3");

            namespaceManager.CreateSubscription(GetTopicName(),
               "HighMessages",
               highMessagesFilter);


            // Create a "LowMessages" filtered subscription.
            SqlFilter lowMessagesFilter =
               new SqlFilter("MessageNumber <= 3");

            namespaceManager.CreateSubscription(GetTopicName(),
               "LowMessages",
               lowMessagesFilter);

        }

        private static string GetTopicName()
        {
            //return "TestTopic";
            return "testtopic1";
        }


        private static void CreateTopic()
        {
            // Configure Topic Settings.
            TopicDescription td = new TopicDescription(GetTopicName());
            td.MaxSizeInMegabytes = 5120;
            td.DefaultMessageTimeToLive = new TimeSpan(0, 1, 0);

            // Create a new Topic with custom settings.
            //string connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");
            string connectionString = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"].ToString();

            var namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);

            if (!namespaceManager.TopicExists(GetTopicName()))
            {
                namespaceManager.CreateTopic(td);
            }
        }
    }
}
