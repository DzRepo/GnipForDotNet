using System;
using System.Threading;
using Gnip.Powertrack;
using Gnip.Utilities.JsonClasses;

namespace StreamTest
{
    class Program
    {
        const string UserName = "USERNAME";
        const string Password = "PASSWORD";
        const string AccountName = "ACCOUNTNAME";
        const string StreamLabel = "STREAMNAME";

        private static GnipStreamReader streamReader;
        static void Main()
        {
            streamReader = new GnipStreamReader();
            streamReader.OnActivityReceived += streamReader_OnActivityReceived;
            streamReader.OnReaderExeception += streamReader_OnReaderException;
            streamReader.OnDisconnect += streamReader_OnDisconnect;
            streamReader.Connect(AccountName, UserName, Password, StreamLabel);
            
            while (true)
            {
                    Thread.Sleep(5000);
            }
        }

        static void streamReader_OnJsonReceived(object sender, string activityJson)
        {
            Console.WriteLine(streamReader.ActivityCount() + "  JSON: " + activityJson.Substring(0,80));
        }

        private static void streamReader_OnDisconnect(object sender)
        {
            Console.WriteLine("Disconnect detected - reconnecting!!!!");
            streamReader = (GnipStreamReader) sender;
            streamReader.Connect(AccountName, UserName, Password, StreamLabel);
        }

        static void streamReader_OnReaderException(object sender, ApplicationException ex)
        {
           Console.WriteLine(" Error: " + ex.Message);
        }

        static void streamReader_OnActivityReceived(object sender, Activity activity)
        {
            Console.WriteLine("Activity received: " + streamReader.ActivityCount() +  " id: " + activity.id);
            if (activity.activityObject != null)
            {
                Console.WriteLine(" Object Tweet ID:" + activity.activityObject.id);
            }
        }
    }
}
