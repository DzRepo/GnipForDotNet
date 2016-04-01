using System;
using System.Linq;
using System.Windows.Forms;
using Gnip.SearchAPI;
using Gnip.Utilities.JsonClasses;
using Gnip.UsageAPI;

namespace Gnip.SearchDemo
{
    public partial class frmSearchAndUsageDemo : Form
    {

        private Request request;
        public frmSearchAndUsageDemo()
        {
            InitializeComponent();
       }

        private void InitalizeRequest()
        {}

        private void btnGetResults_Click(object sender, EventArgs e)
        {
            CreateRequest();
            btnGetResults.Enabled = false;
            btnGetResults.Refresh();
            if (request == null) InitalizeRequest();
            DateTime? fromDate = null;
            DateTime? toDate = null;

            if (cbFromDate.Checked) fromDate = dtpFromDate.Value;
            if (cbToDate.Checked) toDate = dtpToDate.Value;

            var response = request.GetResults(tbQuery.Text, fromDate, toDate, Int32.Parse(tbMaxResults.Text));
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

        private void CreateRequest()
        {
            // use GroupBox enabled as a state flag (cough / #hack)
            if (gbSearchEndPoint.Enabled)
            {
                gbSearchEndPoint.Enabled = false;
                if (rbFAS.Checked)
                    request = new Request(tbAccountName.Text, tbUsername.Text, tbPassword.Text, tbStreamName.Text,
                        Search_Type.SearchFullArchive);
                else
                    request = new Request(tbAccountName.Text, tbUsername.Text, tbPassword.Text, tbStreamName.Text);
            }
        }

        private void Print(Activity activity)
        {
            tbResults.Text += activity.postedTime.ToShortDateString() + " " +   activity.body + Environment.NewLine;

            tbResults.SelectionStart = tbResults.Text.Length;
            tbResults.ScrollToCaret();
            tbResults.Refresh();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbResults.Clear();
            request.Reset();
            btnGetResults.Text = "Get Results";
            gbSearchEndPoint.Enabled = true;
        }

        private void btnGetCounts_Click(object sender, EventArgs e)
        {
            CreateRequest();
            btnGetCounts.Enabled = false;
            btnGetCounts.Refresh();
            tbResults.Clear();

            DateTime? fromDate = null;
            DateTime? toDate = null;

            if (cbFromDate.Checked) fromDate = dtpFromDate.Value;
            if (cbToDate.Checked) toDate = dtpToDate.Value;

            if (request == null) InitalizeRequest();
            var response = request.GetCounts(tbQuery.Text, cbBucket.SelectedItem.ToString(), fromDate, toDate);
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

        private void btnGetUsage_Click(object sender, EventArgs e)
        {
            btnGetUsage.Enabled = false;
            btnGetUsage.Refresh();
            tbResults.Clear();
            
            var currentUsage = Usage.GetUsage(
                tbAccountName.Text,
                tbUsername.Text, 
                tbPassword.Text);

            if (currentUsage.hasError)
            {
                tbResults.Text = "Error: " + currentUsage.ErrorMessage;
            }
            else
            {
                tbResults.Text = "Account: " + currentUsage.account.name + Environment.NewLine;
                tbResults.Text += "Bucket: " + currentUsage.bucket + Environment.NewLine;
                if (currentUsage.fromDate != null)
                    tbResults.Text += "From Date: " + currentUsage.fromDate + Environment.NewLine;
                if (currentUsage.toDate != null)
                    tbResults.Text += "  To Date: " + currentUsage.toDate + Environment.NewLine;

                tbResults.Text += "  By Publisher Info" + Environment.NewLine;
                foreach (var publisher in currentUsage.publishers)
                {
                    tbResults.Text += "  ** Publisher: " + publisher.type + Environment.NewLine;
                    if (publisher.projected != null)
                        tbResults.Text += "  Projected Activities: " + publisher.projected.activities + Environment.NewLine; ;
                    tbResults.Text += "    *** Product Usage *" + Environment.NewLine;
                    foreach (var product in publisher.products)
                    {
                        tbResults.Text += "     **** Product: " + product.type + Environment.NewLine;
                        if (product.endpoints != null)
                            foreach (var endpoint in product.endpoints)
                            {
                                tbResults.Text += "       ***** Type: " + endpoint.type + Environment.NewLine;
                                if (endpoint.projected != null)
                                {
                                    tbResults.Text += "        activities: " + endpoint.projected.activities + Environment.NewLine;
                                    tbResults.Text += "        timeperiod: " + endpoint.projected.timePeriod + Environment.NewLine;
                                }
                            }
                        if (publisher.used != null)
                        {
                            tbResults.Text += "   **** Per Publisher Usage" + Environment.NewLine;
                            foreach (var use in publisher.used)
                            {
                                tbResults.Text += "        activities: " + use.activities + Environment.NewLine;
                                tbResults.Text += "        timeperiod: " + use.timePeriod + Environment.NewLine;
                                if (use.days > 0)
                                    tbResults.Text += "        days used: " + use.days + Environment.NewLine;
                                if (use.jobs > 0)
                                    tbResults.Text += "        jobs created: " + use.jobs + Environment.NewLine;

                            }
                        }

                    }
                    tbResults.Text += "  ** Aggregate Publisher Usage" + Environment.NewLine;
                        
                    foreach (var used in publisher.used)
                    {
                        tbResults.Text += "    Time Period: " + used.timePeriod + Environment.NewLine;
                        if (used.activities > 0)
                            tbResults.Text += "      Activities Used: " + used.activities + Environment.NewLine;
                        if (used.historicalPowertrackDays > 0)
                            tbResults.Text += "      HPT Days Used: " + used.historicalPowertrackDays + Environment.NewLine;
                        if (used.historicalPowertrackJobs > 0)
                            tbResults.Text += "      HPT Jobs Used: " + used.historicalPowertrackJobs + Environment.NewLine;
                        if (used.searchRequests30Day > 0)
                            tbResults.Text += "      Search 30 Day Requests Used: " + used.searchRequests30Day + Environment.NewLine;
                        if (used.searchRequestsFullArchive > 0)
                            tbResults.Text += "      Search FAS Requests Used: " + used.searchRequestsFullArchive + Environment.NewLine;
                    }    

                }
            }

            btnGetUsage.Enabled = true;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbQuery_TextChanged(object sender, EventArgs e)
        {
            // if the query text changes, revert the button to get results
            if (btnGetResults.Text == "Get More...") btnGetResults.Text = "Get Results";
        }

        private void cbFromDate_CheckedChanged(object sender, EventArgs e)
        {
            lbFromDate.Enabled = dtpFromDate.Enabled = cbFromDate.Checked;
        }

        private void cbToDate_CheckedChanged(object sender, EventArgs e)
        {
            lbToDate.Enabled = dtpToDate.Enabled = cbToDate.Checked;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void cbBucket_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnShowJson_Click(object sender, EventArgs e)
        {
            if (request != null)
                if (request.QueryJson.Length > 0)
                    MessageBox.Show(request.QueryJson, "Request Json", MessageBoxButtons.OK, MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

