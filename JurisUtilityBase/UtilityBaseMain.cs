using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Globalization;
using Gizmox.Controls;
using JDataEngine;
using JurisAuthenticator;
using JurisUtilityBase.Properties;

namespace JurisUtilityBase
{
    public partial class UtilityBaseMain : Form
    {
        #region Private  members

        private JurisUtility _jurisUtility;

        #endregion

        #region Public properties

        public string CompanyCode { get; set; }

        public string JurisDbName { get; set; }

        public string JBillsDbName { get; set; }

        public int FldClient { get; set; }

        public int FldMatter { get; set; }

        public string fromFeeSched = "";

        public string toFeeSched = "";

        public string matPractClass = "";

        public string cliPractClass = "";

        #endregion

        #region Constructor

        public UtilityBaseMain()
        {
            InitializeComponent();
            _jurisUtility = new JurisUtility();
        }

        #endregion

        #region Public methods

        public void LoadCompanies()
        {
            var companies = _jurisUtility.Companies.Cast<object>().Cast<Instance>().ToList();
//            listBoxCompanies.SelectedIndexChanged -= listBoxCompanies_SelectedIndexChanged;
            listBoxCompanies.ValueMember = "Code";
            listBoxCompanies.DisplayMember = "Key";
            listBoxCompanies.DataSource = companies;
//            listBoxCompanies.SelectedIndexChanged += listBoxCompanies_SelectedIndexChanged;
            var defaultCompany = companies.FirstOrDefault(c => c.Default == Instance.JurisDefaultCompany.jdcJuris);
            if (companies.Count > 0)
            {
                listBoxCompanies.SelectedItem = defaultCompany ?? companies[0];
            }
        }

        #endregion

        #region MainForm events

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void listBoxCompanies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_jurisUtility.DbOpen)
            {
                _jurisUtility.CloseDatabase();
            }
            CompanyCode = "Company" + listBoxCompanies.SelectedValue;
            _jurisUtility.SetInstance(CompanyCode);
            JurisDbName = _jurisUtility.Company.DatabaseName;
            JBillsDbName = "JBills" + _jurisUtility.Company.Code;
            _jurisUtility.OpenDatabase();
            if (_jurisUtility.DbOpen)
            {
                ///GetFieldLengths();
            }

            populateCBFrom();
            populateCBTo();
            populatePG();
            matPractClass = " ";
            cliPractClass = " ";
            this.cbPG.SelectedIndex = 0;
        }



        #endregion

        #region Private methods

        private void DoDaFix()
        {
            // Enter your SQL code here
            // To run a T-SQL statement with no results, int RecordsAffected = _jurisUtility.ExecuteNonQueryCommand(0, SQL);
            // To get an DataSet, DataSet myRS = _jurisUtility.RecordsetFromSQL(SQL);


            if ((string.IsNullOrEmpty(toFeeSched) || string.IsNullOrEmpty(fromFeeSched)) && fromFeeSched.Equals(toFeeSched))
            { MessageBox.Show("Please select a fee schedule from both drop downs and ensure they are different before continuing."); }
            else
            {


                string CM2 = "";

                if (rbCM.Checked)
                { CM2 = "Fee Schedules for Clients and Matters will be changed from "; }
                if (rbClient.Checked)
                { CM2 = "Fee Schedules for Clients will be changed from "; }
                if (rbMatter.Checked)
                { CM2 = "Fee Schedules for Matters will be changed from "; }

                CM2 = CM2 + fromFeeSched + " to " + toFeeSched;
                if (rbFSopen.Checked)
                    CM2 = CM2 + ". Only open matters will be changed based on the selection criteria.";
                else if (rbFSClosed.Checked)
                    CM2 = CM2 + ". Only closed matters will be changed based on the selection criteria.";
                else
                    CM2 = CM2 + ". Both open and closed matters will be changed based on the selection criteria.";

                DialogResult rsBoth = MessageBox.Show(CM2 + " Do you wish to continue?", "Fee Schedule Assignment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rsBoth == DialogResult.Yes)
                {

                    if (rbCM.Checked)
                    {


                        string CM = "";

                        string MO = "";

                        string SQLCM = "select cast(count(clifeesch) as varchar(10)) as CO from client where clifeesch='" + fromFeeSched.ToString() + "' " + cliPractClass;
                        DataSet myRSCM = _jurisUtility.RecordsetFromSQL(SQLCM);
                        if (myRSCM.Tables[0].Rows.Count == 0)
                        { CM = "0"; }
                        else
                        { CM = myRSCM.Tables[0].Rows[0]["CO"].ToString(); }


                        if (rbFSopen.Checked)
                        {
                            string SQLMO = "select cast(count(matfeesch) as varchar(10)) as CO from matter where matstatusflag='O' and  matfeesch='" + fromFeeSched.ToString() + "' " + matPractClass;
                            DataSet myRSMO = _jurisUtility.RecordsetFromSQL(SQLMO);
                            if (myRSMO.Tables[0].Rows.Count == 0)
                            { MO = "0"; }
                            else
                            { MO = myRSMO.Tables[0].Rows[0]["CO"].ToString(); }
                        }


                        if (rbFSClosed.Checked)
                        {
                            string SQL2MO = "select cast(count(matfeesch) as varchar(10)) as CO from matter where matstatusflag='C' and  matfeesch='" + fromFeeSched.ToString() + "' " + matPractClass;
                            DataSet my2RSMO = _jurisUtility.RecordsetFromSQL(SQL2MO);
                            if (my2RSMO.Tables[0].Rows.Count == 0)
                            { MO = "0"; }
                            else
                            { MO = my2RSMO.Tables[0].Rows[0]["CO"].ToString(); }
                        }

                        if (rbFSAll.Checked)
                        {
                            string SQL3MO = "select cast(count(matfeesch) as varchar(10)) as CO from matter where  matfeesch='" + fromFeeSched.ToString() + "' " + matPractClass;
                            DataSet my3RSMO = _jurisUtility.RecordsetFromSQL(SQL3MO);
                            if (my3RSMO.Tables[0].Rows.Count == 0)
                            { MO = "0"; }
                            else
                            { MO = my3RSMO.Tables[0].Rows[0]["CO"].ToString(); }
                        }


                        updateClients();

                        updateMatters();



                        Cursor.Current = Cursors.Default;
                        Application.DoEvents();
                        toolStripStatusLabel.Text = "Fee Schedules Updated: Client Fee Schedules " + CM.ToString() + "; Matter Fee Schedules " + MO.ToString();
                        statusStrip.Refresh();

                    }

                    if (rbClient.Checked)
                    {
                        string CM = "";


                        string SQLCM = "select cast(count(clifeesch) as varchar(10)) as CO from client where clifeesch='" + fromFeeSched.ToString() + "' " + cliPractClass;
                        DataSet myRSCM = _jurisUtility.RecordsetFromSQL(SQLCM);
                        if (myRSCM.Tables[0].Rows.Count == 0)
                        { CM = "0"; }
                        else
                        { CM = myRSCM.Tables[0].Rows[0]["CO"].ToString(); }




                        updateClients();



                        Cursor.Current = Cursors.Default;
                        Application.DoEvents();
                        toolStripStatusLabel.Text = "Fee Schedules Updated: Client Fee Schedule " + CM.ToString();
                        statusStrip.Refresh();

                    }

                    if (rbMatter.Checked)
                    {
                        string MO = "";




                        if (rbFSopen.Checked)
                        {
                            string SQLMO = "select cast(count(matfeesch) as varchar(10)) as CO from matter where matstatusflag='O' and  matfeesch='" + fromFeeSched.ToString() + "' " + matPractClass;
                            DataSet myRSMO = _jurisUtility.RecordsetFromSQL(SQLMO);
                            if (myRSMO.Tables[0].Rows.Count == 0)
                            { MO = "0"; }
                            else
                            { MO = myRSMO.Tables[0].Rows[0]["CO"].ToString(); }
                        }


                        if (rbFSClosed.Checked)
                        {
                            string SQL2MO = "select cast(count(matfeesch) as varchar(10)) as CO from matter where matstatusflag='C' and  matfeesch='" + fromFeeSched.ToString() + "' " + matPractClass;
                            DataSet my2RSMO = _jurisUtility.RecordsetFromSQL(SQL2MO);
                            if (my2RSMO.Tables[0].Rows.Count == 0)
                            { MO = "0"; }
                            else
                            { MO = my2RSMO.Tables[0].Rows[0]["CO"].ToString(); }
                        }

                        if (rbFSAll.Checked)
                        {
                            string SQL3MO = "select cast(count(matfeesch) as varchar(10)) as CO from matter where  matfeesch='" + fromFeeSched.ToString() + "' " + matPractClass;
                            DataSet my3RSMO = _jurisUtility.RecordsetFromSQL(SQL3MO);
                            if (my3RSMO.Tables[0].Rows.Count == 0)
                            { MO = "0"; }
                            else
                            { MO = my3RSMO.Tables[0].Rows[0]["CO"].ToString(); }
                        }


                        updateMatters();



                        Cursor.Current = Cursors.Default;
                        Application.DoEvents();
                        toolStripStatusLabel.Text = "Fee Schedules Updated: Matter Fee Schedule " +  MO.ToString();
                        statusStrip.Refresh();

                    }
                    if ((this.cbPG.GetItemText(this.cbPG.SelectedItem).Split(' ')[0].Equals("*") || this.cbPG.GetItemText(this.cbPG.SelectedItem).Split(' ')[0].Equals("-")) && rbFSAll.Checked && rbCM.Checked)
                    {
                        DialogResult rsAll;
                        rsAll = MessageBox.Show("Fee Schedules Updated for all client matters.  Do you wish to delete fee schedule?", "Fee Schedule Assignment", MessageBoxButtons.YesNo);
                        if (rsAll == DialogResult.Yes)
                            deletePrompt();
                    }

                    
                    UpdateStatus("Fee Schedule Update Complete", 5, 5);
                    string LogNote = "Fee Schedule Assignment - " + fromFeeSched.ToString().Trim() + " to " + toFeeSched.ToString().Trim();
                    WriteLog(LogNote.ToString());
                    MessageBox.Show("Fee Schedules Updated.");
                    fromFeeSched = "";
                    toFeeSched = "";
                    matPractClass = " ";
                    cliPractClass = " ";
                    cbFrom.SelectedIndex = -1;
                    cbTo.SelectedIndex = -1;
                    cbPG.SelectedIndex = 0;
                    populateCBFrom();
                    populateCBTo();
                    populatePG();
                }



            }


       }

        private void deletePrompt()
        {

            
                string UT = "update unbilledtime set utfeesched='" + toFeeSched.ToString() + "' where utfeesched='" + fromFeeSched.ToString() + "'";
                _jurisUtility.ExecuteNonQueryCommand(0, UT);

                UpdateStatus("Matter  Fee Schedules", 7, 10);

                string BT = "update billedtime set btfeesched='" + toFeeSched.ToString() + "' where btfeesched='" + fromFeeSched.ToString() + "'";
                _jurisUtility.ExecuteNonQueryCommand(0, BT);

                UpdateStatus("Matter  Fee Schedules", 8, 10);

                string TBD = "update timebatchdetail set tbdfeesched='" + toFeeSched.ToString() + "' where tbdfeesched='" + fromFeeSched.ToString() + "'";
                _jurisUtility.ExecuteNonQueryCommand(0, TBD);



                string TE = "update timeentry set feeschedulecode='" + toFeeSched.ToString() + "' where feeschedulecode='" + fromFeeSched.ToString() + "'";
                _jurisUtility.ExecuteNonQueryCommand(0, TE);

                UpdateStatus("Matter  Fee Schedules", 9, 10);
                string TR = "delete from  tkprrate  where tkrfeesch='" + fromFeeSched.ToString() + "'";
                _jurisUtility.ExecuteNonQueryCommand(0, TR);

                string PR = "delete from  perstyprate  where ptrfeesch='" + fromFeeSched.ToString() + "'";
                _jurisUtility.ExecuteNonQueryCommand(0, PR);

                PR = "delete from  TaskCodeRate  where TCRFeeSch='" + fromFeeSched.ToString() + "'";
                _jurisUtility.ExecuteNonQueryCommand(0, PR);

                string FSC = "delete from  feeschedule  where feeschcode='" + fromFeeSched.ToString() + "'";
                _jurisUtility.ExecuteNonQueryCommand(0, FSC);

                string DT = "delete from  documenttree   where dtparentid=17 and dtkeyt='" + fromFeeSched.ToString() + "'";
                _jurisUtility.ExecuteNonQueryCommand(0, DT);
            
        }


        
        private void updateClients()
        {  
            Cursor.Current = Cursors.WaitCursor;
            Application.DoEvents();
            toolStripStatusLabel.Text = "Updating Client Fee Schedules....";
            statusStrip.Refresh();
            UpdateStatus("Client Fee Schedules", 2, 5);



            string CC2 = "update client set clifeesch ='" + toFeeSched.ToString() + "'  where clifeesch='" + fromFeeSched.ToString() + "' " + cliPractClass;
            _jurisUtility.ExecuteNonQueryCommand(0, CC2);
                 
        }

        private void updateMatters()
        {

            Cursor.Current = Cursors.WaitCursor;
            Application.DoEvents();
            toolStripStatusLabel.Text = "Updating Matter  Fee Schedules....";
            statusStrip.Refresh();
            UpdateStatus("Matter  Fee Schedules", 3, 5);

            if (rbFSopen.Checked)
            {
                string MOpen = "update matter set matfeesch='" + toFeeSched.ToString() + "' where matfeesch='" + fromFeeSched.ToString() + "' " + matPractClass + " and matstatusflag='O'";
                _jurisUtility.ExecuteNonQueryCommand(0, MOpen);
            }

            if (rbFSClosed.Checked)
            {
                string MOpen = "update matter set matfeesch='" + toFeeSched.ToString() + "' where matfeesch='" + fromFeeSched.ToString() + "' " + matPractClass + " and matstatusflag='C'";
                _jurisUtility.ExecuteNonQueryCommand(0, MOpen);
            }


            if (rbFSAll.Checked)
            {
                string MOpen = "update matter set matfeesch='" + toFeeSched.ToString() + "' where matfeesch='" + fromFeeSched.ToString() + "' " + matPractClass;
                _jurisUtility.ExecuteNonQueryCommand(0, MOpen);

            }
        }



        private void populateCBFrom()
        {
            string FSIndex;
            cbFrom.ClearItems();
            string SQLFS = "select feeschcode + case when len(feeschcode)=1 then '     ' when len(feeschcode)=2 then '     ' when len(feeschcode)=3 then '   ' else '  ' end +  feeschdesc as FS from feeschedule where feeschactive='Y'   order by feeschcode";
            DataSet myRSFS = _jurisUtility.RecordsetFromSQL(SQLFS);

            if (myRSFS.Tables[0].Rows.Count == 0)
                cbFrom.SelectedIndex = 0;
            else
            {
                foreach (DataRow dr in myRSFS.Tables[0].Rows)
                {
                    FSIndex = dr["FS"].ToString();
                    cbFrom.Items.Add(FSIndex);
                }
            }

        }

        private void populateCBTo()
        {
            string FSIndex2;
            cbTo.ClearItems();
            string SQLFS2 = "select feeschcode + case when len(feeschcode)=1 then '     ' when len(feeschcode)=2 then '     ' when len(feeschcode)=3 then '   ' else '  ' end +  feeschdesc as FS from feeschedule where feeschactive='Y'  order by feeschcode";
            DataSet myRSFS2 = _jurisUtility.RecordsetFromSQL(SQLFS2);

            if (myRSFS2.Tables[0].Rows.Count == 0)
                cbTo.SelectedIndex = 0;
            else
            {
                foreach (DataRow dr in myRSFS2.Tables[0].Rows)
                {
                    FSIndex2 = dr["FS"].ToString();
                    cbTo.Items.Add(FSIndex2);
                }
            }
        }

        private void populatePG()
        {
            string FSIndex2;
            cbPG.ClearItems();
            string SQLFS2 = "select PrctClsCode + case when len(PrctClsCode)=1 then '     ' when len(PrctClsCode)=2 then '     ' when len(PrctClsCode)=3 then '   ' else '  ' end +  PrctClsDesc as FS from PracticeClass order by PrctClsCode";
            DataSet myRSFS2 = _jurisUtility.RecordsetFromSQL(SQLFS2);

            if (myRSFS2.Tables[0].Rows.Count == 0)
                cbPG.SelectedIndex = 0;
            else
            {
                cbPG.Items.Add("-     Do not use Practice Class");
                cbPG.Items.Add("*     All Practice Classes");
                foreach (DataRow dr in myRSFS2.Tables[0].Rows)
                {
                    FSIndex2 = dr["FS"].ToString();
                    cbPG.Items.Add(FSIndex2);
                }
            }
        }

    private bool VerifyFirmName()
        {
            //    Dim SQL     As String
            //    Dim rsDB    As DataSet
            //
            //    SQL = "SELECT CASE WHEN SpTxtValue LIKE '%firm name%' THEN 'Y' ELSE 'N' END AS Firm FROM SysParam WHERE SpName = 'FirmName'"
            //    Cmd.CommandText = SQL
            //    Set rsDB = Cmd.Execute
            //
            //    If rsDB!Firm = "Y" Then
            return true;
            //    Else
            //        VerifyFirmName = False
            //    End If

        }

    private bool FieldExistsInRS(DataSet ds, string fieldName)
    {

        foreach (DataColumn column in ds.Tables[0].Columns)
        {
            if (column.ColumnName.Equals(fieldName, StringComparison.OrdinalIgnoreCase))
                return true;
        }
        return false;
    }


        private static bool IsDate(String date)
        {
            try
            {
                DateTime dt = DateTime.Parse(date);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private static bool IsNumeric(object Expression)
        {
            double retNum;

            bool isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum; 
        }

        private void WriteLog(string comment)
        {
            string sql = "Insert Into UtilityLog(ULTimeStamp,ULWkStaUser,ULComment) Values(convert(datetime,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'),cast('" +  GetComputerAndUser() + "' as varchar(100))," + "cast('" + comment.ToString() + "' as varchar(8000)))";
            _jurisUtility.ExecuteNonQueryCommand(0, sql);
        }

        private string GetComputerAndUser()
        {
            var computerName = Environment.MachineName;
            var windowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent();
            var userName = (windowsIdentity != null) ? windowsIdentity.Name : "Unknown";
            return computerName + "/" + userName;
        }

        /// <summary>
        /// Update status bar (text to display and step number of total completed)
        /// </summary>
        /// <param name="status">status text to display</param>
        /// <param name="step">steps completed</param>
        /// <param name="steps">total steps to be done</param>
        private void UpdateStatus(string status, long step, long steps)
        {
            labelCurrentStatus.Text = status;

            if (steps == 0)
            {
                progressBar.Value = 0;
                labelPercentComplete.Text = string.Empty;
            }
            else
            {
                double pctLong = Math.Round(((double)step/steps)*100.0);
                int percentage = (int)Math.Round(pctLong, 0);
                if ((percentage < 0) || (percentage > 100))
                {
                    progressBar.Value = 0;
                    labelPercentComplete.Text = string.Empty;
                }
                else
                {
                    progressBar.Value = percentage;
                    labelPercentComplete.Text = string.Format("{0} percent complete", percentage);
                }
            }
        }
        private void DeleteLog()
        {
            string AppDir = Path.GetDirectoryName(Application.ExecutablePath);
            string filePathName = Path.Combine(AppDir, "VoucherImportLog.txt");
            if (File.Exists(filePathName + ".ark5"))
            {
                File.Delete(filePathName + ".ark5");
            }
            if (File.Exists(filePathName + ".ark4"))
            {
                File.Copy(filePathName + ".ark4", filePathName + ".ark5");
                File.Delete(filePathName + ".ark4");
            }
            if (File.Exists(filePathName + ".ark3"))
            {
                File.Copy(filePathName + ".ark3", filePathName + ".ark4");
                File.Delete(filePathName + ".ark3");
            }
            if (File.Exists(filePathName + ".ark2"))
            {
                File.Copy(filePathName + ".ark2", filePathName + ".ark3");
                File.Delete(filePathName + ".ark2");
            }
            if (File.Exists(filePathName + ".ark1"))
            {
                File.Copy(filePathName + ".ark1", filePathName + ".ark2");
                File.Delete(filePathName + ".ark1");
            }
            if (File.Exists(filePathName ))
            {
                File.Copy(filePathName, filePathName + ".ark1");
                File.Delete(filePathName);
            }

        }

            

        private void LogFile(string LogLine)
        {
            string AppDir = Path.GetDirectoryName(Application.ExecutablePath);
            string filePathName = Path.Combine(AppDir, "VoucherImportLog.txt");
            using (StreamWriter sw = File.AppendText(filePathName))
            {
                sw.WriteLine(LogLine);
            }	
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            DoDaFix();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cbFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            fromFeeSched = this.cbFrom.GetItemText(this.cbFrom.SelectedItem).Split(' ')[0];
        }

        private void cbTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            toFeeSched = this.cbTo.GetItemText(this.cbTo.SelectedItem).Split(' ')[0];
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(toFeeSched) || string.IsNullOrEmpty(fromFeeSched))
                MessageBox.Show("Please select from both Fee Schedule drop downs", "Selection Error");
            else
            {
                //generates output of the report for before and after the change will be made to client
                string SQLTkpr = getReportSQL();

                DataSet ds = _jurisUtility.RecordsetFromSQL(SQLTkpr);

                ReportDisplay rpds = new ReportDisplay(ds);
                rpds.Show();

            }
        }

        private string getReportSQL()
        {
            string reportSQL = "";
            string matterStatus = " ";
            if (rbFSopen.Checked)
                matterStatus = " and matstatusflag='O'";
            else if (rbFSClosed.Checked)
                matterStatus = " and matstatusflag='C'";
            //if client
            if (rbClient.Checked)
                reportSQL = "select dbo.jfn_formatclientcode(clicode) as ClientCode, clireportingname as ClientName, cliPracticeClass as ClientPractClass, clifeesch as OldFeeSchedule, '" + toFeeSched + "' as NewFeeSchedule from client" +
                        " where clifeesch='" + fromFeeSched + "' " + cliPractClass  + " order by CliCode";

            //if matter
            else if (rbMatter.Checked)
                reportSQL = "select dbo.jfn_formatclientcode(clicode) as ClientCode, dbo.jfn_formatmattercode(matcode) as MatterCode, matreportingname as MatterName,MatPracticeClass as MatPractClass, matfeesch as OldFeeSchedule, '" + toFeeSched + "' as NewFeeSchedule from matter inner join client on clisysnbr = matclinbr " +
                        " where matfeesch='" + fromFeeSched + "' " + matPractClass + matterStatus + " order by clicode, matcode";


            //if both
            else if (rbCM.Checked)
                reportSQL = "select dbo.jfn_formatclientcode(clicode) as ClientCode, clireportingname as ClientName, cliPracticeClass as ClientPractClass, '' as MatterCode, '' as MatterName, ''  as MatPractClass, clifeesch as OldClientFeeSchedule, '' as OldMatterFeeSchedule, '" + toFeeSched + "' as NewFeeSchedule, 'Client Change' as [Type] from client" +
                                        " where clifeesch='" + fromFeeSched + "' " + cliPractClass +
                                        " UNION ALL " +
                                        " select dbo.jfn_formatclientcode(clicode) as ClientCode, clireportingname as ClientName, '' as ClientPractClass, dbo.jfn_formatmattercode(matcode) as MatterCode, matreportingname as MatterName, MatPracticeClass as MatPractClass, '' as OldClientFeeSchedule,matfeesch as OldMatterFeeSchedule, '" + toFeeSched + "' as NewFeeSchedule, 'Matter Change' as [Type] from matter" +
                                        " inner join client on CliSysNbr = MatCliNbr " +
                                        " where matfeesch='" + fromFeeSched + "' " + matPractClass + matterStatus + " order by [type], dbo.jfn_formatclientcode(clicode)";


            return reportSQL;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbPG_SelectedIndexChanged(object sender, EventArgs e)
        {
            matPractClass = this.cbPG.GetItemText(this.cbPG.SelectedItem).Split(' ')[0];
            if (matPractClass.Equals("*"))
            {
                matPractClass = " and MatPracticeClass in (select PrctClsCode from PracticeClass) ";
                cliPractClass = " and CliPracticeClass in (select PrctClsCode from PracticeClass) ";
            }
            else if (matPractClass.Equals("-"))
            {
                matPractClass = " ";
                cliPractClass = " ";
            }
            else
            {
                matPractClass = " and MatPracticeClass in ('" + this.cbPG.GetItemText(this.cbPG.SelectedItem).Split(' ')[0] + "') ";
                cliPractClass = " and CliPracticeClass in ('" + this.cbPG.GetItemText(this.cbPG.SelectedItem).Split(' ')[0] + "') ";

            }
        }

    }
}
