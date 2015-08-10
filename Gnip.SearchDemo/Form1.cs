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
        {
            request = new Request(tbAccountName.Text, tbUsername.Text, tbPassword.Text, tbStreamName.Text);
        }

        private void btnGetResults_Click(object sender, EventArgs e)
        {
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
            InitalizeRequest();
        }

        private void btnGetCounts_Click(object sender, EventArgs e)
        {
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
                tbResults.Text = "Account: " + currentUsage.account + Environment.NewLine;
                tbResults.Text += "Status:" + currentUsage.account.status + Environment.NewLine;
                tbResults.Text += "Bucket:" + currentUsage.bucket + Environment.NewLine;
                foreach (var publisher in currentUsage.publishers)
                {
                    tbResults.Text += "  Publisher:" + publisher.name + Environment.NewLine;
                    tbResults.Text += "  Projected Activities" + publisher.projected.activities + Environment.NewLine; ;
                    foreach (var product in publisher.products)
                    {
                        tbResults.Text += "    Product:" + product.name + Environment.NewLine;
                        tbResults.Text += "    Projected Activities" + product.projected.activities + Environment.NewLine; ;
                        
                    }
                    foreach (var used in publisher.used)
                    {
                        tbResults.Text += "    Days used from :" + used.fromDate + " to " + used.toDate + ": " + used.days + Environment.NewLine;
                        tbResults.Text += "    Activities Used" + used.activities + Environment.NewLine;

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
    }
}

