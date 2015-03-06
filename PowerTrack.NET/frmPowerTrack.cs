using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Gnip.Powertrack.Rules;
using Gnip.Utilities.JsonClasses;
using Gnip.PowerTrack.Stream;


namespace PowerTrack.NET
{
    public partial class frmPowerTrack : Form
    {

        #region Property Declarations
        private DataSet dsRules = new DataSet();
        private DataSet dsStream = new DataSet();

        private List<Gnip.Utilities.JsonClasses.Rule> ruleData;
        private BindingSource bindableRuleData = new BindingSource();
        private bool DataLoading;
        private bool StreamRunning;

        private static int ROWS = 40;

        private ActivityStream activityStream;
        private RuleManager rm = new RuleManager();
        static Timer myTimer = new Timer();
        private int countDown = 10;

        #endregion

        #region Initializers
        public frmPowerTrack()
        {
            InitializeComponent();
            IntitalizeRules();
            IntitalizeStream();
            myTimer.Tick += myTimer_Tick;
            tabRules.Enabled = tabStream.Enabled = tabFieldChooser.Enabled = false;
        }
        private void IntitalizeStream()
        {
            dsStream.Tables.Add(new DataTable("Stream"));
            activityStream = new ActivityStream();
            activityStream.Received += activityStream_Received;
            activityStream.ActitivityEx += activityStream_ActitivityEx;
            activityStream.ForcedDisconnectEvent += activityStream_ForcedDisconnectEvent;
        }
        private void IntitalizeRules()
        {
            bindableRuleData.ListChanged += bindableRuleData_ListChanged;
            dsRules.Tables.Add("Rules");
            var column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                AllowDBNull = false,
                Caption = "Tag(s)",
                ColumnName = "tag"
            };
            column.AllowDBNull = true;

            dsRules.Tables["Rules"].Columns.Add(column);

            column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                AllowDBNull = false,
                Caption = "Value",
                ColumnName = "value"
            };

            dsRules.Tables["Rules"].Columns.Add(column);

            dgRules.Columns.Clear();
            dgRules.AutoGenerateColumns = false;

            var makeColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "tag",
                HeaderText = "Tag(s)",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                MinimumWidth = 100
            };

            dgRules.Columns.Add(makeColumn);

            makeColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "value",
                HeaderText = "Rule",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dgRules.Columns.Add(makeColumn);

            dgRules.DataSource = dsRules;
            dgRules.DataMember = "Rules";
        }
        #endregion

        #region Non UI Event Handlers
        void activityStream_ForcedDisconnectEvent(object sender)
        {
            Debug.WriteLine("Force Disconnect message recieved");
            myTimer.Interval = 1000;
            myTimer.Enabled = true;
            myTimer.Start();
            countDown = 10;
            tsMessage.Text = "Stream Disconnect initiated.  Pausing.";
            StopStream();
        }

        private void activityStream_ActitivityEx(object sender, Exception ex)
        {
            Invoke((MethodInvoker) delegate
            {
                tsMessage.ForeColor = Color.Red;
                tsMessage.Text = ex.Message;
            });
        }

        private void activityStream_Received(object sender, Activity activity)
        {
            // Debug.WriteLine(activity.body);
            var newRow = dsStream.Tables["Stream"].NewRow();
            foreach (var fieldName in from DataGridViewColumn column in dgvStream.Columns select column.Tag.ToString())
            {
                switch (fieldName)
                {
                    #region activity fields
                    case "activity.id":
                    {
                        newRow[fieldName] = activity.id;
                        break;
                    }
                    case "activity.verb":
                    {
                        newRow[fieldName] = activity.verb;
                        break;
                    }
                    case "activity.link":
                    {
                        newRow[fieldName] = activity.link;
                        break;
                    }
                    case "activity.body":
                    {
                        newRow[fieldName] = activity.body;
                        break;
                    }
                    case "activity.postedTime":
                    {
                        newRow[fieldName] = activity.postedTime.ToLocalTime();
                        break;
                    }
                    case "activity.favoritesCount":
                    {
                        newRow[fieldName] = activity.favoritesCount;
                        break;
                    }
                    case "activity.twitter_filter_level":
                    {
                        newRow[fieldName] = activity.twitter_filter_level;
                        break;
                    }
                    case "activity.twitter_lang":
                    {
                        newRow[fieldName] = activity.twitter_lang;
                        break;
                    }
                    case "activity.object":
                    {
                        newRow[fieldName] = activity.activityObject;
                        break;
                    }
                    #endregion
                    #region actor fields
                    case "actor.id":
                    {
                        newRow[fieldName] = activity.actor.id;
                        break;
                    }
                    case "actor.link":
                    {
                        newRow[fieldName] = activity.actor.link;
                        break;
                    }
                    case "actor.displayName":
                    {
                        newRow[fieldName] = activity.actor.displayName;
                        break;
                    }
                    case "actor.postedTime":
                    {
                        newRow[fieldName] = activity.actor.postedTime;
                        break;
                    }
                    case "actor.objectType":
                    {
                        newRow[fieldName] = activity.actor.objectType;
                        break;
                    }
                    #endregion
                    #region generator fields
                    case "generator.displayName":
                    {
                        newRow[fieldName] = activity.generator.displayName;
                        break;
                    }
                    case "generator.link":
                    {
                        newRow[fieldName] = activity.generator.link;
                        break;
                    }
                    #endregion
                    #region gnip fields
                    case "gnip.matching_rules":
                    {
                        newRow[fieldName] = activity.gnip.Matching_Rules();
                        break;
                    }
                    case "gnip.language":
                    {
                        newRow[fieldName] = activity.gnip.language;
                        break;
                    }
                    #endregion
                    #region twitter entities
                    case "twitter_entities.hashtags":
                    {
                        newRow[fieldName] = activity.twitter_entities.Hashtags();
                        break;
                    }
                    case "twitter_entities.user_mentions":
                    {
                        newRow[fieldName] = activity.twitter_entities.User_Mentions();
                        break;
                    }
                    case "twitter_entities.urls":
                    {
                        newRow[fieldName] = activity.twitter_entities.Urls();
                        break;
                    }
                    #endregion
                }
                // show number of tweets received
                Invoke((MethodInvoker) delegate { tsStatus.Text = activityStream.ActivityCount.ToString(); } );
            }

            Invoke((MethodInvoker)delegate
            {
                dsStream.Tables["Stream"].Rows.Add(newRow);
                
                if (dsStream.Tables["Stream"].Rows.Count > ROWS)
                    dsStream.Tables["Stream"].Rows[0].Delete();

                dgvStream.Refresh(); // runs on UI thread
            });
        }

        void myTimer_Tick(object sender, EventArgs e)
        {
            if (countDown == 0)
            {
                tsMessage.Text = "Stream Reconnect initiated";
                // used to restart stream after force disconnect
                myTimer.Stop();
                myTimer.Enabled = false;
                StartStream();
            }
            else
            {
                tsMessage.Text = "Stream Reconnect initiating in " + countDown + " seconds";
                countDown--;
            }
        }
        #endregion

        #region Rule Methods

        private void RefreshRules()
        {
            tsMessage.Text = "Loading rules...";
            Application.DoEvents();

            if (tbAccountName.Text != null)
            {
                rm.Url = UrlBuilder.RuleUrl(tbAccountName.Text, tbStreamName.Text);
                rm.Username = tbUsername.Text;
                rm.Password = tbPassword.Text;

                DataLoading = true;
                ruleData = rm.GetRules();
                if (ruleData == null)
                    tsMessage.Text = "Error loading rules: " + rm.ErrorMessage;
                else
                {
                    dsRules.Tables["Rules"].Clear();
                    foreach (var r in ruleData)
                    {
                        var nr = dsRules.Tables["Rules"].NewRow();
                        nr["tag"] = r.tag;
                        nr["value"] = r.value;

                        dsRules.Tables["Rules"].Rows.Add(nr);
                    }

                    dsRules.AcceptChanges();

                    // dgRules.Show();
                    tsMessage.Text = "Rules loaded.";
                }
                DataLoading = false;
            }
            else
            {
                tsMessage.ForeColor = Color.Red;
                tsMessage.Text = "No Rules URL set.  Check settings.";
            }

        }
        private void UpdateRules()
        {
            var updateError = false;

            tsMessage.Text = "Committing changes...";
            Application.DoEvents();

            if (tbAccountName.Text != null)
            {

                var dataTable = dsRules.Tables["Rules"].GetChanges();
                if (dataTable != null)
                {

                    rm.Url = UrlBuilder.RuleUrl(tbAccountName.Text, tbStreamName.Text);
                    rm.Username = tbUsername.Text;
                    rm.Password = tbPassword.Text;

                    var deleteRules = new List<Gnip.Utilities.JsonClasses.Rule>();
                    var addRules = new List<Gnip.Utilities.JsonClasses.Rule>();


                    var deletedRows = dataTable.GetChanges(DataRowState.Deleted);

                    if (deletedRows != null)
                        deleteRules.AddRange(from DataRow dRow in deletedRows.Rows
                                             select new Gnip.Utilities.JsonClasses.Rule()
                                             {
                                                 value = dRow["value", DataRowVersion.Original].ToString(),
                                                 tag = dRow["tag", DataRowVersion.Original].ToString()
                                             });

                    var addedRows = dataTable.GetChanges(DataRowState.Added);

                    if (addedRows != null)
                        addRules.AddRange(from DataRow dRow in addedRows.Rows
                                          select new Gnip.Utilities.JsonClasses.Rule()
                                          {
                                              value = dRow["value"].ToString(),
                                              tag = dRow["tag"].ToString()
                                          });

                    var modifiedRows = dataTable.GetChanges(DataRowState.Modified);
                    if (modifiedRows != null)
                    {
                        deleteRules.AddRange(from DataRow dRow in modifiedRows.Rows
                                             select new Gnip.Utilities.JsonClasses.Rule()
                                             {
                                                 value = dRow["value", DataRowVersion.Original].ToString(),
                                                 tag = dRow["tag", DataRowVersion.Original].ToString()
                                             });

                        addRules.AddRange(from DataRow dRow in modifiedRows.Rows
                                          select new Gnip.Utilities.JsonClasses.Rule()
                                          {
                                              value = dRow["value"].ToString(),
                                              tag = dRow["tag"].ToString()
                                          });
                    }

                    if (deleteRules.Count > 0)
                    {
                        if (rm.DeleteRules(deleteRules))
                            tsMessage.Text = "Rules Deleted";
                        else
                        {
                            tsMessage.Text = rm.ErrorMessage;
                            updateError = true;
                        }
                    }

                    if (addRules.Count > 0)
                    {
                        if (rm.AddRules(addRules))
                            tsMessage.Text += " Rules Deleted";
                        else
                        {
                            tsMessage.Text = rm.ErrorMessage;
                            updateError = true;
                        }
                    }

                } // dataTable.GetChanges

                if (!updateError) tsMessage.Text = "Rule changes commited";

                dsRules.AcceptChanges();

                DataLoading = false;
                // dgRules.Show();
                tsMessage.Text = "Rules loaded.";
            }
            else
            {
                tsMessage.ForeColor = Color.Red;
                tsMessage.Text = "No Rules URL set.  Check settings.";
            }
        }
  
        #endregion

        #region UI Event Handlers
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tabContainer_TabIndexChanged(object sender, EventArgs e)
        {
            TabControl tabC = (TabControl) sender;
            if (tabC.SelectedTab.Name == "tabRules")
            {
               // RefreshRules();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshRules();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateRules();
           
        }

        private void dgRules_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridView dg = (DataGridView) sender;
            if (dg.CurrentCell != null)
                Debug.WriteLine("in dgRules_CurrentCell Changed - CurrentCell.Value is " + dg.CurrentCell.Value);
        }

        private void bindableRuleData_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (!DataLoading)
            {
                BindingSource bSource = (BindingSource) sender;
                Debug.WriteLine("in bindableRuleData_ListChanged, ChangeType is " + e.ListChangedType);
                // skip initial loading / refreshing
                if (bSource.List.Count > 0)
                    MessageBox.Show(
                        "Detected change to row " + e.NewIndex + " new data is " +
                        ((Gnip.Utilities.JsonClasses.Rule) bSource.List[e.NewIndex]).value, "Changed detected",
                        MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnConfirmFieldChooser_Click(object sender, EventArgs e)
        {
            tsMessage.Text = "Processing Column Changes";
            StopStream();
            // reset grid and dataset columns
            dgvStream.Columns.Clear();
            dsStream.Tables["Stream"].Columns.Clear();

            foreach (string checkedItem in cblActivity.CheckedItems)
                CreateStreamColumn("activity", checkedItem);
            
            foreach (string checkedItem in cblActor.CheckedItems)
                CreateStreamColumn("actor", checkedItem);
            
            foreach (string checkedItem in clbGenerator.CheckedItems)
                CreateStreamColumn("generator", checkedItem);

            foreach (string checkedItem in clbGnip.CheckedItems)
                CreateStreamColumn("gnip", checkedItem);

            foreach (string checkedItem in clbTwitterEntities.CheckedItems)
                CreateStreamColumn("twitter_entities", checkedItem);
            

            dgvStream.AutoGenerateColumns = false;
            dgvStream.DataSource = dsStream;
            dgvStream.DataMember = "Stream";

        }

        private void CreateStreamColumn(string objectName, string propertyName)
        {
            var fieldName = objectName + "." + propertyName;
            DataGridViewColumn newCol = new DataGridViewColumn
            {
                DataPropertyName = fieldName,
                CellTemplate = new DataGridViewTextBoxCell(),
                Tag = fieldName,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                HeaderText = fieldName,
                Resizable = DataGridViewTriState.True,
                MinimumWidth = 100
            };
            dgvStream.Columns.Add(newCol);

            var column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                AllowDBNull = false,
                Caption = fieldName,
                ColumnName = fieldName
            };
            dsStream.Tables["Stream"].Columns.Add(column);
        }

        private void btnStreamToggle_Click(object sender, EventArgs e)
        {
            if (StreamRunning) StopStream();
            else StartStream();
        }
        private void dgvStream_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Debug.WriteLine("Data Error on Stream DataGrid View");
            //((DataGridView) sender).Rows.Clear();
        }
        #endregion

        #region Stream Methods
        private void StartStream()
        {
            if (dgvStream.Columns.Count == 0)
            {
                MessageBox.Show("No data selected.  Choose columns to display first.", "Stream Display Tab",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
               
            }
            else
            {

                dsStream.Tables["Stream"].Rows.Clear();
              
                activityStream.StreamName = tbStreamName.Text;
                activityStream.Username = tbUsername.Text;
                activityStream.Password = tbPassword.Text;
                activityStream.AccountName = tbAccountName.Text;

                dsStream.Tables["Stream"].Rows.Clear();
                
                activityStream.Connect();

                Invoke((MethodInvoker) delegate
                {
                    btnStreamToggle.Text = "Stop";
                    StreamRunning = true;
                    tsMessage.Text = "Streaming Started";
                });
            }
        }

        private void StopStream()
        {
            if (StreamRunning)
            {
                activityStream.Disconnect();
                Invoke((MethodInvoker) delegate
                {
                    btnStreamToggle.Text = "Start";
                    StreamRunning = false;
                    tsMessage.Text = "Stream Stopping... (may take a a moment)";
                });
            }
        }
        #endregion

        private void tbSettingTextBox_TextChanged(object sender, EventArgs e)
        {
            tabContainer.TabPages[1].Enabled =
                tabContainer.TabPages[2].Enabled =
                    tabContainer.TabPages[3].Enabled = (tbUsername.Text.Length > 0 &&
                                                        tbPassword.Text.Length > 0 &&
                                                        tbAccountName.Text.Length > 0 &&
                                                        tbStreamName.Text.Length > 0);
        }
    }
}
