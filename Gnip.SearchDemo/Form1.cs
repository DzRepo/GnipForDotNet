using System;
using System.Linq;
using System.Windows.Forms;
using Gnip.SearchAPI;
using Gnip.Utilities.JsonClasses;

namespace Gnip.SearchDemo
{
    public partial class Form1 : Form
    {

        private Request request;
        public Form1()
        {
            InitializeComponent();
            request = new Request();
            request.StreamName = "STREAMNAME";
            request.Username = "USERNAME";
            request.Password = "PASSWORD";
            request.AccountName = "ACCOUNTNAME";
            // request.MaxResults = 10;
        }

        private void btnGetResults_Click(object sender, EventArgs e)
        {
            btnGetResults.Enabled = false;
            btnGetResults.Refresh();
            request.Query = tbQuery.Text;
            var response = request.GetResults();
            if (response != null)
            {
                response.ForEach(Print);
                if (request.hasMore)
                {
                    btnGetResults.Text = "Get More...";
                }
                else
                {
                    btnGetResults.Text = "Get Results";
                }
            }
            else
            {
                if (request.ErrorState)
                    tbResults.Text += request.ErrorMessage;
            }
            btnGetResults.Enabled = true;
            btnGetResults.Refresh();
        }

        private void Print(Activity activity)
        {
            tbResults.Text += activity.postedTime.ToShortDateString() + " " +   activity.body + Environment.NewLine;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbResults.Clear();
            request.Reset();
        }

        private void btnGetCounts_Click(object sender, EventArgs e)
        {
            btnGetCounts.Enabled = false;
            btnGetCounts.Refresh();
            tbResults.Clear();
            request.Query = tbQuery.Text;
            var response = request.GetCounts();
            if (response != null)
            {
                foreach (var x in response.results.Where(a => a.count > 0 ))
                    tbResults.Text += x.timePeriod + ": " + x.count + Environment.NewLine;
            }
            else
            {
                if (request.ErrorState)
                    tbResults.Text += request.ErrorMessage;
            }
            btnGetCounts.Enabled = true;
        }
    }
}

