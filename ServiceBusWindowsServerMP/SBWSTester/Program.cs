using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Microsoft.WindowsAzure;

namespace SBWSTester
{
    class Program
    {

        static int SBWSHttpPort = 9355;
        static int SBWSTcpPort = 9354;
        static string QueueName = "ServiceBusMPQueueSample";
        static string TopicName = "ServiceBusMPTopicSample";
        static string SubName = "ServiceBusMPSubSample";

        static void Main(string[] args)
        {
            var connBuilder = new ServiceBusConnectionStringBuilder();
            connBuilder.ManagementPort = SBWSHttpPort;
            connBuilder.RuntimePort = SBWSTcpPort;
            connBuilder.Endpoints.Add(new UriBuilder() { Scheme = "sb", Host = "ERIMATBUS.redmond.corp.microsoft.com", Path = "ERIMATTEST" }.Uri);
            connBuilder.StsEndpoints.Add(new UriBuilder() { Scheme = "https", Host = "ERIMATBUS.redmond.corp.microsoft.com", Port = SBWSHttpPort, Path = "ERIMATTEST" }.Uri);
            //connBuilder.Endpoints.Add(new UriBuilder() { Scheme = "sb", Host = "TK3ECITXSWEB304.parttest.extranettest.microsoft.com", Path = "NGVL-DIT" }.Uri);
            //connBuilder.StsEndpoints.Add(new UriBuilder() { Scheme = "https", Host = "TK3ECITXSWEB304.parttest.extranettest.microsoft.com", Port = SBWSHttpPort, Path = "NGVL-DIT" }.Uri);
            
            Test(NamespaceManager.CreateFromConnectionString(connBuilder.ToString()), MessagingFactory.CreateFromConnectionString(connBuilder.ToString()));
        }

        static void Test(NamespaceManager namespaceManager, MessagingFactory messageFactory)
        {

            var q = namespaceManager.GetQueue(QueueName);
            var t = namespaceManager.GetTopic(TopicName);

            var gf = namespaceManager.GetTopics();

            if (!namespaceManager.QueueExists(QueueName))
            {
                namespaceManager.CreateQueue(QueueName);
            }
            

            QueueClient myQueueClient = messageFactory.CreateQueueClient(QueueName);

            try
            {
                BrokeredMessage sendMessage = new BrokeredMessage("Hello World !");
                myQueueClient.Send(sendMessage);

                //// Receive the message from the queue
                //BrokeredMessage receivedMessage = myQueueClient.Receive(TimeSpan.FromSeconds(5));

                //if (receivedMessage != null)
                //{
                //    Console.WriteLine(string.Format("Message received: {0}", receivedMessage.GetBody<string>()));
                //    receivedMessage.Complete();
                //}

                //Check for messages that are older than they should be
                int minutesOld = 1;
                DateTime oldest = DateTime.UtcNow.AddMinutes(-minutesOld);

                int oldMessageCount = 0;
                List<BrokeredMessage> messages = new List<BrokeredMessage>(myQueueClient.PeekBatch(1000));

                foreach (BrokeredMessage b in messages)
                {

                    if (b.EnqueuedTimeUtc < oldest)
                    {
                        oldMessageCount++;
                    }
                }

                BrokeredMessage bd = myQueueClient.Receive();
                bd.DeadLetter();

                //check for dead letter messages            
                QueueClient dlClient = messageFactory.CreateQueueClient(QueueClient.FormatDeadLetterPath(QueueName));

                List<BrokeredMessage> dlMessages = new List<BrokeredMessage>(dlClient.PeekBatch(1000));
                int i = dlMessages.Count;

                //b.DeadLetter();


                if (!namespaceManager.TopicExists(TopicName))
                {
                    namespaceManager.CreateTopic(TopicName);
                }
                

                if (!namespaceManager.SubscriptionExists(TopicName, SubName))
                {
                    namespaceManager.CreateSubscription(TopicName, SubName);
                }
                


                TopicClient topicClient = messageFactory.CreateTopicClient(TopicName);

                topicClient.Send(new BrokeredMessage("Message"));

                SubscriptionDescription s = namespaceManager.GetSubscription(TopicName, SubName);

                SubscriptionClient subClient = messageFactory.CreateSubscriptionClient(TopicName, SubName);

                List<BrokeredMessage> subMessages = new List<BrokeredMessage>(subClient.PeekBatch(1000));
                BrokeredMessage bms = subClient.Receive();
                bms.DeadLetter();

                foreach (BrokeredMessage b in messages)
                {

                    if (b.EnqueuedTimeUtc < oldest)
                    {
                        oldMessageCount++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception {0}", e.ToString());
                throw;
            }
            finally
            {
                if (messageFactory != null)
                    messageFactory.Close();
            }
            //Send Message




        }

    }
}