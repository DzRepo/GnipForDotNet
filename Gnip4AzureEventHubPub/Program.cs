using System;
using System.Text;
using System.Threading;
using Gnip.Powertrack;
using Gnip.Utilities.JsonClasses;
using Microsoft.ServiceBus.Messaging;

namespace Gnip4AzureEventHub
{
    class Program
    {
        private static GnipStreamReader streamReader;
        private static EventHubClient ehClient;

        const string UserName = "USERNAME";
        const string Password = "PASSWORD";
        const string AccountName = "ACCOUNTNAME";
        const string StreamLabel = "STREAMNAME";

        private const string sbConnectionStr =
            "Endpoint=sb://gnip4azure.servicebus.windows.net/;SharedAccessKeyName=Sender;SharedAccessKey=pdCyoVfMy+YIyRvIGshJvUd91dAa93HMn+OmHCvtD3o=;EntityPath=powertrack";

        static void Main()
        {
            try
            {
                // Initialize connection to service bus
                
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error initializing EventHub:" + ex.Message);
                throw ex;
            }

            streamReader = new GnipStreamReader();
            streamReader.OnActivityReceived += streamReader_OnActivityReceived;
            streamReader.OnReaderExeception += streamReader_OnReaderException;
            streamReader.OnDisconnect += streamReader_OnDisconnect;
            streamReader.Connect(AccountName, UserName, Password, StreamLabel);
            streamReader.OnJsonReceived += streamReader_OnJsonReceived;
            
            while (true)
            {
                Thread.Sleep(5000);
            }
        }

        static void streamReader_OnJsonReceived(object sender, string activityJson)
        {
            try
            {
                ehClient = EventHubClient.CreateFromConnectionString(sbConnectionStr);
                // Console.WriteLine(streamReader.ActivityCount() + 
                // "  " + activityJson.Substring(0, 80));
                if (ehClient != null)
                {
                    ehClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(activityJson)));
                    Console.Write(".");
                }
                else
                {
                    Console.Write("x");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in OnJsonReceived:" + ex.Message);
            }
        }

        private static void streamReader_OnDisconnect(object sender)
        {
            Console.WriteLine("Disconnect detected - reconnecting!!!!");
            streamReader = (GnipStreamReader)sender;
            streamReader.Connect(AccountName, UserName, Password, StreamLabel);
        }

        static void streamReader_OnReaderException(object sender, ApplicationException ex)
        {
            Console.WriteLine(" Error: " + ex.Message);
        }

        static void streamReader_OnActivityReceived(object sender, Activity activity)
        {
            Console.WriteLine("message received: " + streamReader.ActivityCount() + " id: " + activity.id);
            if (activity.twitter_entities.media != null)
                Console.WriteLine(" Media:" + activity.twitter_entities.media[0].expanded_url);
        }
    }
}
