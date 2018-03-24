using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Microsoft.SqlServer.Server;

namespace Big8_MAIN
{
    public partial class FormMainMenu : Form
    {

        //var empty = String.Empty;
        //transaction.Notes = empty;             
        
        // sql stuff
        private SqlConnection conn;
        private SqlCommand command;
        //string sql = "";
        string connectionString = "";
        string sql = "";
        //string addColumn = "";///////////////////////////////////////////////////////////////////////////////

        public FormMainMenu()
        {
            InitializeComponent();
            this.seasons1_5TableAdapter.Fill(this.seasonsDBDataSet.Seasons1_5);
            this.seasons6_10TableAdapter.Fill(this.seasonsDBDataSet.Seasons6_10);
            this.seasons11_17TableAdapter.Fill(this.seasonsDBDataSet.Seasons11_17);          
            this.Activated += FormMainMenu_Activated;

            

            if (File.Exists("PublicVariablesSave.bin"))
            {
                //Serialization logic
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("PublicVariablesSave.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                SavedPublicVariables savedPublicVariables = (SavedPublicVariables)formatter.Deserialize(stream);
                stream.Close();
                PublicVariables.GetDefaultSeason = savedPublicVariables.GetDefaultSeason;
                PublicVariables.GetDefaultWeek = savedPublicVariables.GetDefaultWeek;
            }

            UpdateForm();
            TotalPlayers();
            GetSeasons();
        }

        private void GetSeasons()
        {
            comboBoxSelectSeason.Items.Clear();

            this.seasons1_5TableAdapter.Fill(this.seasonsDBDataSet.Seasons1_5);
            this.seasons6_10TableAdapter.Fill(this.seasonsDBDataSet.Seasons6_10);
            this.seasons11_17TableAdapter.Fill(this.seasonsDBDataSet.Seasons11_17);

            foreach (SeasonsDBDataSet.Seasons1_5Row seasons in seasonsDBDataSet.Seasons1_5)
            {
                comboBoxSelectSeason.Items.Add(seasons.SeasonName);
            }
        }

        private void FormMainMenu_Activated(object sender, EventArgs e)
        {
            UpdateForm();
            TotalPlayers();
            GetSeasons();          
        }

        private void TotalPlayers()
        {
            int totalPlayers = 0;

            foreach (PlayersDBDataSet.PlayersRow players in playersDBDataSet.Players)
            {
                if (players.IsActive == true)
                {
                    totalPlayers++;
                }
            }

            labelTotalPlayers.Text = totalPlayers.ToString();
        }

        private void buttonSaveDataMain_Click(object sender, EventArgs e)
        {
            Cursor defaultCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            // accounting backup
            try
            {
                connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Big8\Accounting.mdf;Integrated Security=True;Connect Timeout=30";
                //Data Source=(LocalDB)\v11.0;AttachDbFilename="C:\Users\OUTLOOK OFFICE\Documents\Visual Studio 2012\Projects\Big8_alpha_9.93\Big8_MAIN\PlayersDB.mdf";Integrated Security=True
                //CREATE USER [jittz] FOR LOGIN [jittz]; EXEC sp_addrolemember 'db_owner', [jittz]; 
                conn = new SqlConnection(connectionString);
                conn.Open();
                command = new SqlCommand(@"Backup DATABASE [C:\Big8\ACCOUNTING.MDF] to DISK='c:\Big8\Backups\AccountingBackup_" + DateTime.Now.ToFileTime() + "_.bak'", conn);
                command.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                Cursor.Current = defaultCursor;
                MessageBox.Show(ex.Message);
            }

            // seasons backup
            try
            {
                connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Big8\SeasonsDB.mdf;Integrated Security=True;Connect Timeout=30";
                conn = new SqlConnection(connectionString);
                conn.Open();
                command = new SqlCommand(@"Backup DATABASE [C:\Big8\SEASONSDB.MDF] to DISK='c:\Big8\Backups\SeasonsDBBackup_" + DateTime.Now.ToFileTime() + "_.bak'", conn);
                command.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                Cursor.Current = defaultCursor;
                MessageBox.Show(ex.Message);
            }

            // players backup
            try
            {
                connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Big8\PlayersDB.mdf;Integrated Security=True;Connect Timeout=30";
                conn = new SqlConnection(connectionString);
                conn.Open();
                command = new SqlCommand(@"Backup DATABASE [C:\Big8\PlayersDB.MDF] to DISK='c:\Big8\Backups\PlayersDBBackup_" + DateTime.Now.ToFileTime() + "_.bak'", conn);
                command.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
                Cursor.Current = defaultCursor;
                MessageBox.Show("Databases Backed Up Successfully!");
            }
            catch (Exception ex)
            {
                Cursor.Current = defaultCursor;
                MessageBox.Show(ex.Message);
            }

            // transactions backup
            try
            {
                connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Big8\TransactionsDB.mdf;Integrated Security=True;Connect Timeout=30";
                conn = new SqlConnection(connectionString);
                conn.Open();
                command = new SqlCommand(@"Backup DATABASE [C:\Big8\TransactionsDB.MDF] to DISK='c:\Big8\Backups\TransactionsDBBackup_" + DateTime.Now.ToFileTime() + "_.bak'", conn);
                command.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                Cursor.Current = defaultCursor;
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonLoadDataMain_Click(object sender, EventArgs e)
        {
            string backupFileName = "";

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Backup Files(*.bak)|*.bak";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                backupFileName = openFile.FileName;

                // find out which file to backup based on the selected file name...
                // ACCOUNTING
                Cursor defaultCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                if (backupFileName.Contains("Accounting"))
                {
                    try
                    {
                        connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Big8\Accounting.mdf;Integrated Security=True;Connect Timeout=30";

                        //sql = @"Grant Alter On Database C:\Big8\PLAYERSDB.MDF TO jitterz;";
                        sql += @"Use master;Alter DATABASE [C:\Big8\Accounting.mdf] set SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                        sql += @"Restore DATABASE [C:\Big8\Accounting.mdf] from DISK='" + backupFileName + "' with REPLACE;";
                        sql += @"Alter DATABASE [C:\Big8\Accounting.mdf] set MULTI_USER;";

                        conn = new SqlConnection(connectionString);
                        conn.Open();
                        command = new SqlCommand(sql, conn);
                        command.ExecuteNonQuery();
                        conn.Close();
                        conn.Dispose();
                        Cursor.Current = defaultCursor;
                        MessageBox.Show("Accounting Database Sucessfully Restored");

                        this.Validate();
                        this.accountingBindingSource.EndEdit();
                        this.tableAdapterManager2.UpdateAll(this.accountingDataSet);
                        this.accountingTableAdapter.Fill(this.accountingDataSet.Accounting);
                    }
                    catch (Exception ex)
                    {
                        Cursor.Current = defaultCursor;
                        MessageBox.Show(ex.Message);
                    }                   
                }

                // SEASONS
                if (backupFileName.Contains("Seasons"))
                {
                    try
                    {
                        connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Big8\SeasonsDB.mdf;Integrated Security=True;Connect Timeout=30";

                        //sql = @"Grant Alter On Database C:\Big8\PLAYERSDB.MDF TO jitterz;";
                        sql += @"Use master;Alter DATABASE [C:\Big8\SeasonsDB.mdf] set SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                        sql += @"Restore DATABASE [C:\Big8\SeasonsDB.mdf] from DISK='" + backupFileName + "' with REPLACE;";
                        sql += @"Alter DATABASE [C:\Big8\SeasonsDB.mdf] set MULTI_USER;";

                        conn = new SqlConnection(connectionString);
                        conn.Open();
                        command = new SqlCommand(sql, conn);
                        command.ExecuteNonQuery();
                        conn.Close();
                        conn.Dispose();
                        Cursor.Current = defaultCursor;
                        MessageBox.Show("Seasons Database Sucessfully Restored");

                        this.Validate();
                        this.seasons1_5BindingSource.EndEdit();
                        this.seasons6_10BindingSource.EndEdit();
                        this.seasons11_17BindingSource.EndEdit();
                        this.seasons1_5TableAdapter.Update(this.seasonsDBDataSet.Seasons1_5);
                        this.seasons6_10TableAdapter.Update(this.seasonsDBDataSet.Seasons6_10);
                        this.seasons11_17TableAdapter.Update(this.seasonsDBDataSet.Seasons11_17);
                    }
                    catch (Exception ex)
                    {
                        Cursor.Current = defaultCursor;
                        MessageBox.Show(ex.Message);
                    }
                }

                // PLAYERS
                if (backupFileName.Contains("Players"))
                {
                    try
                    {
                        connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Big8\PlayersDB.mdf;Integrated Security=True;Connect Timeout=30";//     (localDB)\v11.0

                        //sql = @"Grant Alter On Database C:\Big8\PLAYERSDB.MDF TO jitterz;";
                        sql += @"Use master;Alter DATABASE [C:\Big8\PlayersDB.mdf] set SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                        sql += @"Restore DATABASE [C:\Big8\PlayersDB.mdf] from DISK='" + backupFileName + "' with REPLACE;";
                        sql += @"Alter DATABASE [C:\Big8\PlayersDB.mdf] set MULTI_USER;";

                        //addColumn += @"Alter TABLE Players DROP COLUMN IsGroupLeader;";////////////////////////////////////////////////////
                        //addColumn += @"Alter TABLE Players ADD IsGroupLeader BIT NOT NULL DEFAULT 0;";/////////////////////////////////////////

                        conn = new SqlConnection(connectionString);
                        conn.Open();
                        command = new SqlCommand(sql, conn);
                        //command = new SqlCommand(addColumn, conn);////////////////////////////////////////////////////////////////////////

                        command.ExecuteNonQuery();
                        conn.Close();
                        conn.Dispose();
                        Cursor.Current = defaultCursor;
                        MessageBox.Show("Players Database Sucessfully Restored");

                        this.Validate();
                        this.playersBindingSource.EndEdit();
                        this.tableAdapterManager.UpdateAll(this.playersDBDataSet);
                        this.playersTableAdapter.Fill(this.playersDBDataSet.Players);
                    }
                    catch (Exception ex)
                    {
                        Cursor.Current = defaultCursor;
                        MessageBox.Show(ex.Message);
                    }                    
                }

                // TRANSACTIONS
                if (backupFileName.Contains("Transactions"))
                {
                    try
                    {
                        connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Big8\TransactionsDB.mdf;Integrated Security=True;Connect Timeout=30";//     (localDB)\v11.0

                        //sql = @"Grant Alter On Database C:\Big8\PLAYERSDB.MDF TO jitterz;";
                        sql += @"Use master;Alter DATABASE [C:\Big8\TransactionsDB.mdf] set SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                        sql += @"Restore DATABASE [C:\Big8\TransactionsDB.mdf] from DISK='" + backupFileName + "' with REPLACE;";
                        sql += @"Alter DATABASE [C:\Big8\TransactionsDB.mdf] set MULTI_USER;";

                        conn = new SqlConnection(connectionString);
                        conn.Open();
                        command = new SqlCommand(sql, conn);

                        command.ExecuteNonQuery();
                        conn.Close();
                        conn.Dispose();
                        Cursor.Current = defaultCursor;
                        MessageBox.Show("Transactions Database Sucessfully Restored");

                        this.Validate();
                        this.transactionsBindingSource.EndEdit();
                        this.tableAdapterManager3.UpdateAll(this.transactionsDBDataSet);
                        this.transactionsTableAdapter.Fill(this.transactionsDBDataSet.Transactions);
                    }
                    catch (Exception ex)
                    {
                        Cursor.Current = defaultCursor;
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void buttonPlayersMain_Click(object sender, EventArgs e)
        {
            if (PublicVariables.GetDefaultSeason == null)
            {
                MessageBox.Show("Select a Season first.");
                return;
            }

            // check to see if the form is open
            if ((Application.OpenForms["FormPlayers"] as FormPlayers) != null)
            {
                // if it is then select the right form
                foreach (Form form in Application.OpenForms)
                {
                    if (form.Name == "FormPlayers")
                    {
                        // activate it
                        form.Activate();
                        if (form.WindowState == FormWindowState.Minimized)
                        {
                            form.WindowState = FormWindowState.Normal;
                        }
                    }
                }
            }
            else
            {
                // otherwise create a new instance of the form and show it
                FormPlayers formPlayers = new FormPlayers();
                formPlayers.Show();
            }
        }

        private void buttonEnterPicksMain_Click(object sender, EventArgs e)
        {
            if (PublicVariables.GetDefaultSeason == null)
            {
                MessageBox.Show("Select a Season first.");
                return;
            }
            // check to see if the form is open
            if ((Application.OpenForms["FormEnterPicks"] as FormEnterPicks) != null)
            {
                // if it is then select the right form
                foreach (Form form in Application.OpenForms)
                {
                    if (form.Name == "FormEnterPicks")
                    {
                        // activate it
                        form.Activate();
                        if (form.WindowState == FormWindowState.Minimized)
                        {
                            form.WindowState = FormWindowState.Normal;
                        }
                    }
                }
            }
            else
            {
                // otherwise create a new instance of the form and show it
                FormEnterPicks formEnterPicks = new FormEnterPicks();
                formEnterPicks.Show();
            }
        }

        private void buttonLiveWindowMain_Click(object sender, EventArgs e)
        {
            if (PublicVariables.GetDefaultSeason == null)
            {
                MessageBox.Show("Select a Season first.");
                return;
            }
            // check to see if the form is open
            if ((Application.OpenForms["FormLiveWindow"] as FormLiveWindow) != null)
            {
                // if it is then select the right form
                foreach (Form form in Application.OpenForms)
                {
                    if (form.Name == "FormLiveWindow")
                    {
                        // activate it
                        form.Activate();
                        if (form.WindowState == FormWindowState.Minimized)
                        {
                            form.WindowState = FormWindowState.Normal;
                        }
                    }
                }
            }
            else
            {
                // otherwise create a new instance of the form and show it
                FormLiveWindow formLiveWindow = new FormLiveWindow();
                formLiveWindow.Show();
            }
        }

        private void buttonSetSeasonMain_Click(object sender, EventArgs e)
        {
            
            // check to see if the form is open
            if ((Application.OpenForms["FormSetUpSeason"] as FormSetUpSeason) != null)
            {
                // if it is then select the right form
                foreach (Form form in Application.OpenForms)
                {
                    if (form.Name == "FormSetUpSeason")
                    {
                        // activate it
                        form.Activate();
                        if (form.WindowState == FormWindowState.Minimized)
                        {
                            form.WindowState = FormWindowState.Normal;
                        }
                    }
                }
            }
            else
            {
                // otherwise create a new instance of the form and show it
                FormSetUpSeason formSetUpSeason = new FormSetUpSeason();
                formSetUpSeason.Show();
            }
        }

        private void buttonAccountingMain_Click(object sender, EventArgs e)
        {
            if (PublicVariables.GetDefaultSeason == null)
            {
                MessageBox.Show("Select a Season first.");
                return;
            }
            // check to see if the form is open
            if ((Application.OpenForms["FormAccounting"] as FormAccounting) != null)
            {
                // if it is then select the right form
                foreach (Form form in Application.OpenForms)
                {
                    if (form.Name == "FormAccounting")
                    {
                        // activate it
                        form.Activate();
                        if (form.WindowState == FormWindowState.Minimized)
                        {
                            form.WindowState = FormWindowState.Normal;
                        }
                    }
                }
            }
            else
            {
                // otherwise create a new instance of the form and show it
                FormAccounting formAccounting = new FormAccounting();
                formAccounting.Show();
            }
        }
        
        private void buttonMasterSheetMain_Click(object sender, EventArgs e)
        {
            if (PublicVariables.GetDefaultSeason == null)
            {
                MessageBox.Show("Select a Season first.");
                return;
            }
            // check to see if the form is open
            if ((Application.OpenForms["FormPlayerDBEditor"] as FormPlayerDBEditor) != null)
            {
                // if it is then select the right form
                foreach (Form form in Application.OpenForms)
                {
                    if (form.Name == "FormPlayerDBEditor")
                    {
                        // activate it
                        form.Activate();
                        if (form.WindowState == FormWindowState.Minimized)
                        {
                            form.WindowState = FormWindowState.Normal;
                        }
                    }
                }
            }
            else
            {
                // otherwise create a new instance of the form and show it
                FormPlayerDBEditor formPlayerDBEditor = new FormPlayerDBEditor();
                formPlayerDBEditor.Show();
            }
        }

        /*
        private void playersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.playersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.playersDBDataSet);

        }
         * */

        private void FormMainMenu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'transactionsDBDataSet.Transactions' table. You can move, or remove it, as needed.
            this.transactionsTableAdapter.Fill(this.transactionsDBDataSet.Transactions);
            // TODO: This line of code loads data into the 'accountingDataSet.Accounting' table. You can move, or remove it, as needed.
            this.accountingTableAdapter.Fill(this.accountingDataSet.Accounting);
            // TODO: This line of code loads data into the 'seasonsDBDataSet.Seasons6_10' table. You can move, or remove it, as needed.
            this.seasons6_10TableAdapter.Fill(this.seasonsDBDataSet.Seasons6_10);
            // TODO: This line of code loads data into the 'seasonsDBDataSet.Seasons11_17' table. You can move, or remove it, as needed.
            this.seasons11_17TableAdapter.Fill(this.seasonsDBDataSet.Seasons11_17);
            // TODO: This line of code loads data into the 'seasonsDBDataSet.Seasons1_5' table. You can move, or remove it, as needed.
            this.seasons1_5TableAdapter.Fill(this.seasonsDBDataSet.Seasons1_5);
            // TODO: This line of code loads data into the 'seasonsDBDataSet.Seasons' table. You can move, or remove it, as needed.
            this.seasons1_5TableAdapter.Fill(this.seasonsDBDataSet.Seasons1_5);
            this.seasons6_10TableAdapter.Fill(this.seasonsDBDataSet.Seasons6_10);
            this.seasons11_17TableAdapter.Fill(this.seasonsDBDataSet.Seasons11_17);
            // TODO: This line of code loads data into the 'playersDBDataSet.Players' table. You can move, or remove it, as needed.
            this.playersTableAdapter.Fill(this.playersDBDataSet.Players);
            //comboBoxDefaultWeek.SelectedItem = "Week 01";
        }

        private void UpdateForm()
        {
            if (PublicVariables.GetDefaultSeason != null)
            {
                textBoxCurrentSeason.Text = PublicVariables.GetDefaultSeason;
            }
            if (PublicVariables.GetDefaultWeek != null)
            {
                comboBoxDefaultWeek.Text = PublicVariables.GetDefaultWeek;
            }

            CalculateTopFive();
        }

        private void CalculateTopFive()
        {
            // update the database
            this.playersTableAdapter.Fill(this.playersDBDataSet.Players);

            // build label list
            List<Label> labelListPlayerName = new List<Label>();
            labelListPlayerName.Add(labelTop10Name_1);
            labelListPlayerName.Add(labelTop10Name_2);
            labelListPlayerName.Add(labelTop10Name_3);
            labelListPlayerName.Add(labelTop10Name_4);
            labelListPlayerName.Add(labelTop10Name_5);
            labelListPlayerName.Add(labelTop10Name_6);
            labelListPlayerName.Add(labelTop10Name_7);
            labelListPlayerName.Add(labelTop10Name_8);
            labelListPlayerName.Add(labelTop10Name_9);
            labelListPlayerName.Add(labelTop10Name_10);

            List<Label> labelListPlayerScore = new List<Label>();
            labelListPlayerScore.Add(labelTop10Wins_1);
            labelListPlayerScore.Add(labelTop10Wins_2);
            labelListPlayerScore.Add(labelTop10Wins_3);
            labelListPlayerScore.Add(labelTop10Wins_4);
            labelListPlayerScore.Add(labelTop10Wins_5);
            labelListPlayerScore.Add(labelTop10Wins_6);
            labelListPlayerScore.Add(labelTop10Wins_7);
            labelListPlayerScore.Add(labelTop10Wins_8);
            labelListPlayerScore.Add(labelTop10Wins_9);
            labelListPlayerScore.Add(labelTop10Wins_10);


            // make sure there is atleast 5 players
            if (playersDBDataSet.Players.Rows.Count >= 10)
            {
                // create a datatable and make it an exact copy of my players table
                DataTable tableCopy = playersDBDataSet.Players.Clone();

                // sort the players table
                playersDBDataSet.Players.DefaultView.Sort = "PlayerTotalWins DESC";

                // populate the new table with the new sorted players table
                tableCopy = playersDBDataSet.Players.DefaultView.ToTable();

                // no need to resort the players table it is alphabetical by default. The new table is encapsulated no need to remove it.

                // add the top five to the labels.
                for (int i = 0; i <= 9; i++)
                {
                    labelListPlayerScore[i].Text = tableCopy.Rows[i]["PlayerTotalWins"].ToString();
                    labelListPlayerName[i].Text = tableCopy.Rows[i]["PlayerPoolName"].ToString();
                }
            }
        }

        private void comboBoxDefaultWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            PublicVariables.GetDefaultWeek = comboBoxDefaultWeek.Text;

            SavedPublicVariables savePublicVariables = new SavedPublicVariables();
            savePublicVariables.GetDefaultSeason = PublicVariables.GetDefaultSeason;
            savePublicVariables.GetDefaultWeek = PublicVariables.GetDefaultWeek;

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("PublicVariablesSave.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, savePublicVariables);
            stream.Close();
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            // check to see if the form is open
            if ((Application.OpenForms["FormAbout"] as FormAbout) != null)
            {
                // if it is then select the right form
                foreach (Form form in Application.OpenForms)
                {
                    if (form.Name == "FormAbout")
                    {
                        // activate it
                        form.Activate();
                        if (form.WindowState == FormWindowState.Minimized)
                        {
                            form.WindowState = FormWindowState.Normal;
                        }
                    }
                }
            }
            else
            {
                // otherwise create a new instance of the form and show it
                FormAbout formAbout = new FormAbout();
                formAbout.Show();
            }
        }

        private void buttonBugReporter_Click(object sender, EventArgs e)
        {
            // check to see if the form is open
            if ((Application.OpenForms["FormCommentsBugs"] as FormCommentsBugs) != null)
            {
                // if it is then select the right form
                foreach (Form form in Application.OpenForms)
                {
                    if (form.Name == "FormCommentsBugs")
                    {
                        // activate it
                        form.Activate();
                        if (form.WindowState == FormWindowState.Minimized)
                        {
                            form.WindowState = FormWindowState.Normal;
                        }
                    }
                }
            }
            else
            {
                // otherwise create a new instance of the form and show it
                FormCommentsBugs formCommentsBugs = new FormCommentsBugs();
                formCommentsBugs.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // check to see if the form is open
            if ((Application.OpenForms["FormExcelSheets"] as FormExcelSheets) != null)
            {
                // if it is then select the right form
                foreach (Form form in Application.OpenForms)
                {
                    if (form.Name == "FormExcelSheets")
                    {
                        // activate it
                        form.Activate();
                        if (form.WindowState == FormWindowState.Minimized)
                        {
                            form.WindowState = FormWindowState.Normal;
                        }
                    }
                }
            }
            else
            {
                // otherwise create a new instance of the form and show it
                FormExcelSheets formExcelSheets = new FormExcelSheets();
                formExcelSheets.Show();
            }
        }

        private void comboBoxSelectSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            PublicVariables.GetDefaultSeason = comboBoxSelectSeason.Text;
            textBoxCurrentSeason.Text = PublicVariables.GetDefaultSeason;

            SavedPublicVariables savePublicVariables = new SavedPublicVariables();
            savePublicVariables.GetDefaultSeason = PublicVariables.GetDefaultSeason;
            savePublicVariables.GetDefaultWeek = PublicVariables.GetDefaultWeek;

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("PublicVariablesSave.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, savePublicVariables);
            stream.Close();
        }

        private void buttonAlterDatabases_Click(object sender, EventArgs e)
        {            
            try
            {
                connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Big8\PlayersDB.mdf;Integrated Security=True;Connect Timeout=30";//     (localDB)\v11.0

                //sql = @"Grant Alter On Database C:\Big8\PLAYERSDB.MDF TO jitterz;";
                //sql += @"Use master;Alter DATABASE [C:\Big8\PlayersDB.mdf] set SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                //sql += @"Alter DATABASE [C:\Big8\PlayersDB.mdf] set MULTI_USER;";

                //addColumn += @"Alter TABLE Players DROP COLUMN IsGroupLeader;";////////////////////////////////////////////////////
                sql += @"Alter TABLE Players ADD PlayerNotes VARCHAR(500) DEFAULT '';";/////////////////////////////////////////

                conn = new SqlConnection(connectionString);
                conn.Open();
                command = new SqlCommand(sql, conn);
                //command = new SqlCommand(addColumn, conn);////////////////////////////////////////////////////////////////////////

                command.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
                MessageBox.Show("Players Notes Column Added Successfully");

                this.Validate();
                this.playersBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.playersDBDataSet);
                this.playersTableAdapter.Fill(this.playersDBDataSet.Players);
            }
            catch (Exception ex)
            {               
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAddPlayers_Click(object sender, EventArgs e)
        {
            // check to see if the form is open
            if ((Application.OpenForms["FormAddEditPlayers"] as FormAddEditPlayers) != null)
            {
                // if it is then select the right form
                foreach (Form form in Application.OpenForms)
                {
                    if (form.Name == "FormAddEditPlayers")
                    {
                        // activate it
                        form.Activate();
                        if (form.WindowState == FormWindowState.Minimized)
                        {
                            form.WindowState = FormWindowState.Normal;
                        }
                    }
                }
            }
            else
            {
                // otherwise create a new instance of the form and show it
                FormAddEditPlayers formAddEditPlayers = new FormAddEditPlayers();
                formAddEditPlayers.Show();
            }
        }

        private void buttoResetPicks_Click(object sender, EventArgs e)
        {
            foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
            {

                player.Pick01 = "0";
                player.Pick02 = "0";
                player.Pick03 = "0";
                player.Pick04 = "0";
                player.Pick05 = "0";
                player.Pick06 = "0";
                player.Pick07 = "0";
                player.Pick08 = "0";
                player.Pick09 = "0";
                player.Pick10 = "0";
                player.Pick11 = "0";
                player.Pick12 = "0";
                player.Pick13 = "0";
                player.Pick14 = "0";
                player.Pick15 = "0";
                player.Pick16 = "0";
                player.Pick17 = "0";
                player.Pick18 = "0";
                player.Pick19 = "0";
                player.Pick20 = "0";

            }
        }
    }
}
