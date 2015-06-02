using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using AzureEventHubProxy.Properties;
using Gnip.Powertrack;
using Gnip.Utilities.JsonClasses;
using Microsoft.ServiceBus.Messaging;

namespace AzureEventHubProxy
{
    public partial class EventHubProxy : Form
    {

        private GnipStreamReader streamReader;
        private EventHubClient ehClient;

        private long _activitiesReceived = 0;
        private long _eventsSent = 0;

        //private const string UserName = "USERNAME";
        //private const string Password = "PASSWORD";
        //private const string AccountName = "ACCOUNTNAME";
        //private const string StreamLabel = "STREAMNAME";

        //private const string sbConnectionStr =
        //    "Endpoint=sb://gnip4azure.servicebus.windows.net/;SharedAccessKeyName=Sender;SharedAccessKey=pdCyoVfMy+YIyRvIGshJvUd91dAa93HMn+OmHCvtD3o=;EntityPath=powertrack";


        public EventHubProxy()
        {
            InitializeComponent();
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (btnStartStop.Text == "Start")
            {
                Connect();
                btnStartStop.Text = "Stop";
            }
            else
            {
                streamReader.Disconnect();
                btnStartStop.Text = "Start";
            }
        }

        private void Connect()
        {
            try
            {
                streamReader = new GnipStreamReader();

                streamReader.OnReaderExeception += streamReader_OnReaderException;
                streamReader.OnDisconnect += streamReader_OnDisconnect;
                streamReader.OnJsonReceived += streamReader_OnJsonReceived;

                streamReader.Connect(
                    Settings.Default.AccountName,
                    Settings.Default.Username,
                    Settings.Default.Password,
                    Settings.Default.StreamLabel);
            }
            catch (Exception ex)
            {
                LogMessage("Connect Error:" + ex.Message);
            }
        }

        private void streamReader_OnJsonReceived(object sender, string activityJson)
        {
            IncrementReceived();
            try
            {
                ehClient = EventHubClient.CreateFromConnectionString(Settings.Default.EventHubConnectionString);
                if (ehClient != null)
                {
                    ehClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(activityJson)));
                    IncrementSent();
                }
            }
            catch (Exception ex)
            {
                LogMessage("OnJsonReceived Error:" + ex.Message);
            }
        }

        private void IncrementSent()
        {
            _eventsSent++;
            Invoke((MethodInvoker)delegate
            {
                lblEventsSent.Text =
                    _eventsSent.ToString("##,###");

                lblThreadCount.Text = Process.GetCurrentProcess().Threads.Count.ToString("##,###");
                lblHandles.Text = Process.GetCurrentProcess().HandleCount.ToString("##,###");
            });
        }

        private void IncrementReceived()
        {
            _activitiesReceived++;
            Invoke((MethodInvoker) delegate
            {
                lblActivitiesReceived.Text =
                    _activitiesReceived.ToString("##,###");
            });
        }

        private void streamReader_OnDisconnect(object sender)
        {
            LogMessage("Stream disconnect - Reconnecting");
            Connect();
        }

        private void streamReader_OnReaderException(object sender, ApplicationException ex)
        {
            LogMessage("ReaderError: " + ex.Message);
        }

        private void LogMessage(string Message)
        {
            Invoke((MethodInvoker)delegate
            {
                tbMessages.Text += Message + Environment.NewLine;
                tbMessages.ScrollToCaret();
            });
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}

