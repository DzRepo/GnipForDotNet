using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gnip.Powertrack.Historical;
using Gnip.Utilities;
using Gnip.Utilities.JsonClasses;

namespace HistoricalPowerTrack
{
    public partial class frmHPTMainForm : Form
    {

        private HptJob hptJob;

        private DataTable dtJobs = new DataTable();
        public frmHPTMainForm()
        {
            InitializeComponent();
            hptJob = new HptJob();
            InitializeTable();
            hptJob.DownloadComplete += hptJob_DownloadComplete;
        }

        void hptJob_DownloadComplete(object sender, string fileName)
        {
            Invoke((MethodInvoker)delegate
            {
                tsMessage.Text = "File " + fileName + " Downloaded";
            });
        }

        private DataColumn makeNewDataColumn(string fieldName, Type dataType, string caption)
        {
            DataColumn dc = new DataColumn(fieldName, dataType);
            dc.Caption = caption;
            return dc;
        }
        private void InitializeTable()
        {
            dtJobs.Columns.Clear();
            dtJobs.Columns.Add(new DataColumn("Action", typeof(string)) {Caption = "Action"});
            dtJobs.Columns.Add(new DataColumn("title", typeof(string)) { Caption = "Title" });
            dtJobs.Columns.Add(new DataColumn("estimatedActivityCount", typeof(UInt64)) { Caption = "# of Activities" });
            dtJobs.Columns.Add(new DataColumn("estimatedDurationHours", typeof(Single)) { Caption = "Job Time" });
            dtJobs.Columns.Add(new DataColumn("estimatedFileSizeMb", typeof(Single)) { Caption = "Job File Size" });
            dtJobs.Columns.Add(new DataColumn("status", typeof(string)) { Caption = "Status" });
            dtJobs.Columns.Add(new DataColumn("statusMessage", typeof(string)) { Caption = "Message" });
            dtJobs.Columns.Add(new DataColumn("fileCount", typeof(int)) {Caption = "# of Files"});
            dtJobs.Columns.Add(new DataColumn("expiresAt", typeof(string)) {Caption = "Expires on"});
            dtJobs.Columns.Add(new DataColumn("percentComplete", typeof(int)) {Caption = "% Complete"});
            dtJobs.Columns.Add(new DataColumn("uuid", typeof(string)) {Caption = "ID"});
        }

        private void GetJobs()  
        {
            if (tbAccountName.Text != "" && tbUsername.Text != "" && tbPassword.Text != "")
            {
                tsMessage.Text = "Retrieving Job Status...";
                Refresh();
                hptJob.AccountName = tbAccountName.Text;
                hptJob.Username = tbUsername.Text;
                hptJob.Password = tbPassword.Text;

                var JobResults = hptJob.GetJobs();
                if (!hptJob.ErrorState)
                {
                    dtJobs.Rows.Clear();
                    dgvHPTJobs.DataSource = null;
                    dgvHPTJobs.Columns.Clear();
                    dgvHPTJobs.AutoGenerateColumns = true;
                    foreach (var jobInfo in JobResults)
                    {
                        var Action = ""; // for open or running - no action.
                        if (jobInfo.status == "delivered") Action = "Download";
                        else if (jobInfo.status == "quoted") Action = "Accept/Reject";

                        if (jobInfo.status == "quoted")
                        {
                            dtJobs.Rows.Add(
                                Action,
                                jobInfo.title,
                                jobInfo.quote.estimatedActivityCount,
                                jobInfo.quote.estimatedDurationHours,
                                jobInfo.quote.estimatedFileSizeMb,
                                jobInfo.status,
                                jobInfo.statusMessage,
                                jobInfo.fileCount,
                                jobInfo.expiresAt,
                                jobInfo.percentComplete,
                                jobInfo.uuid
                                );
                        }
                        else if (jobInfo.status == "delivered")
                        {
                            dtJobs.Rows.Add(
                                  Action,
                                  jobInfo.title,
                                  jobInfo.results.activityCount,
                                  null,
                                  jobInfo.results.fileSizeMb,
                                  jobInfo.status,
                                  jobInfo.statusMessage,
                                  jobInfo.results.fileCount,
                                  jobInfo.expiresAt,
                                  jobInfo.percentComplete,
                                  jobInfo.uuid
                                  );
                        }
                        else if (jobInfo.status == "rejected")
                        {
                            dtJobs.Rows.Add(
                                  Action,
                                  jobInfo.title,
                                  null,
                                  null,
                                  null,
                                  jobInfo.status,
                                  jobInfo.statusMessage,
                                  null,
                                  jobInfo.expiresAt,
                                  null,
                                  jobInfo.uuid
                                  );
                        }
                        else 
                        {
                            dtJobs.Rows.Add(
                                  Action,
                                  jobInfo.title,
                                  null,
                                  null,
                                  null,
                                  jobInfo.status,
                                  jobInfo.statusMessage,
                                  jobInfo.fileCount,
                                  jobInfo.expiresAt,
                                  jobInfo.percentComplete,
                                  jobInfo.uuid
                                  );
                        }
                }
                    dgvHPTJobs.DataSource = dtJobs;

                    // format grid columns
                    foreach (DataGridViewColumn column in dgvHPTJobs.Columns)
                    {
                        column.HeaderText = dtJobs.Columns[column.DataPropertyName].Caption;
                        // format the "Estimated" columns as numbers
                        if (column.HeaderText.StartsWith("Job") || 
                            column.HeaderText.StartsWith("#") || 
                            column.HeaderText.StartsWith("%"))
                        {
                            column.DefaultCellStyle.Format = "N0";  // numeric, commas
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                    }

                    dgvHPTJobs.Columns.RemoveAt(0); // Remove text column...

                    dgvHPTJobs.AutoGenerateColumns = false;
                    var dgvLink = new DataGridViewLinkColumn();
                    dgvLink.DataPropertyName = "Action";
                    dgvLink.UseColumnTextForLinkValue = true;
                    dgvLink.UseColumnTextForLinkValue = false;
                    
                    // dgvLink.Form
                    dgvHPTJobs.Columns.Insert(0, dgvLink);
                    dgvHPTJobs.Columns[0].Width = 100;
                    dgvHPTJobs.Columns[0].HeaderText = "Action";
                    dgvHPTJobs.Columns[0].MinimumWidth = 100;
                    // dgvHPTJobs.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvHPTJobs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    tsMessage.Text = "Job Status retrieved";
                }
                else
                {
                    tsMessage.Text = hptJob.ErrorMessage;
                }
            }           
        }
        private void btnGetJobs_Click(object sender, EventArgs e)
        {
            GetJobs();
        }

        private void UpdateJob(string uuid, int RowId, string toStatus)
        {
            Debug.WriteLine("uuid:" + uuid);
            tsMessage.Text = "Updating Job " + dgvHPTJobs.Rows[RowId].Cells["title"].Value;
            HptJobInfo jobInfo = null;
            if (toStatus == "Accept")
                jobInfo = hptJob.Accept(uuid);
            else
                jobInfo = hptJob.Reject(uuid);
        
            if (jobInfo == null)
            {
                if (hptJob.ErrorState)
                {
                    MessageBox.Show(
                        hptJob.ErrorMessage,
                        this.Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Job updated: " + jobInfo.statusMessage,
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                GetJobs();
            }
            
        }
        private void AcceptOrRejectJob(int RowId)
        {
            {
                var UpdateForm = new frmUpdateStatus();
                UpdateForm.tbJobInfo.Text =
                    "ID: " + dgvHPTJobs.Rows[RowId].Cells["uuid"].Value + Environment.NewLine + Environment.NewLine +
                    "Title: " + dgvHPTJobs.Rows[RowId].Cells["title"].Value + Environment.NewLine + 
                    "Estimated Activity Count: " + ((UInt64)dgvHPTJobs.Rows[RowId].Cells["estimatedActivityCount"].Value).ToString("N0") + Environment.NewLine +
                    "Estimated Job time: " + ((Single)dgvHPTJobs.Rows[RowId].Cells["estimatedDurationHours"].Value).ToString("N0") + " hours" + Environment.NewLine +
                    "Estimated Filesize: " + ((Single)dgvHPTJobs.Rows[RowId].Cells["estimatedFileSizeMb"].Value).ToString("N0") + " MB" + Environment.NewLine;
                var response = UpdateForm.ShowDialog();
                string uuid = dgvHPTJobs.Rows[RowId].Cells["uuid"].Value.ToString();

                if (response == DialogResult.Yes)
                    UpdateJob(uuid, RowId, "Accept");
                else if (response == DialogResult.No)
                    UpdateJob(uuid,RowId, "Reject");
            }
        }
        private void dgvHPTJobs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)  // It's the button column and not the column header
            {
                var buttonText = dgvHPTJobs[0, e.RowIndex].Value.ToString();

                if (buttonText == "Accept/Reject")
                   AcceptOrRejectJob(e.RowIndex); 
                else
                {
                    if (buttonText == "Download")
                    {
                        DownloadJob(e.RowIndex);
                    }
                }
            }
        }

        private void DownloadJob(int RowId)
        {
            tsMessage.Text = "Starting Download";
            this.Refresh();
            string uuid = dgvHPTJobs.Rows[RowId].Cells["uuid"].Value.ToString();
            hptJob.StartDownload(uuid, Application.StartupPath);
            tsMessage.Text = "Download Finished.";
        }


    }
}
