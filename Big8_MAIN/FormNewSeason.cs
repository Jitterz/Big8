using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Big8_MAIN
{
    public partial class FormNewSeason : Form
    {

        FormSetUpSeason form;
        public FormNewSeason()
        {
            InitializeComponent();
            this.Activated += FormNewSeason_Activated;
        }

        private void seasonsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
           // this.Validate();
            //this.seasonsBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.seasonsDBDataSet);

        }

        private void FormNewSeason_Activated(object sender, EventArgs e)
        {
            textBoxSeasonNameSeason.Focus();
        }

        private void FormNewSeason_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'playersDBDataSet.Players' table. You can move, or remove it, as needed.
            this.playersTableAdapter.Fill(this.playersDBDataSet.Players);
            // TODO: This line of code loads data into the 'accountingDataSet.Accounting' table. You can move, or remove it, as needed.
            this.accountingTableAdapter.Fill(this.accountingDataSet.Accounting);
            // TODO: This line of code loads data into the 'seasonsDBDataSet.Seasons6_10' table. You can move, or remove it, as needed.
            this.seasons6_10TableAdapter.Fill(this.seasonsDBDataSet.Seasons6_10);
            // TODO: This line of code loads data into the 'seasonsDBDataSet.Seasons11_17' table. You can move, or remove it, as needed.
            this.seasons11_17TableAdapter.Fill(this.seasonsDBDataSet.Seasons11_17);
            // TODO: This line of code loads data into the 'seasonsDBDataSet.Seasons1_5' table. You can move, or remove it, as needed.
            this.seasons1_5TableAdapter.Fill(this.seasonsDBDataSet.Seasons1_5);
            // TODO: This line of code loads data into the 'seasonsDBDataSet.Seasons' table. You can move, or remove it, as needed.
            textBoxSeasonNameSeason.Text = "";
        }

        private void buttonSubmitNewSeason_Click(object sender, EventArgs e)
        {
            if (textBoxSeasonNameSeason.Text == "")
            {
                MessageBox.Show("You must enter a Season Name.");
                return;
            }

            form = new FormSetUpSeason();
                        
            try
            {
                SeasonsDBDataSet.Seasons1_5Row newSeasonRow1 = seasonsDBDataSet.Seasons1_5.NewSeasons1_5Row();
                SeasonsDBDataSet.Seasons6_10Row newSeasonRow2 = seasonsDBDataSet.Seasons6_10.NewSeasons6_10Row();
                SeasonsDBDataSet.Seasons11_17Row newSeasonRow3 = seasonsDBDataSet.Seasons11_17.NewSeasons11_17Row();
                AccountingDataSet.AccountingRow newAccountingRow = accountingDataSet.Accounting.NewAccountingRow();
                newAccountingRow.SeasonName = textBoxSeasonNameSeason.Text;
                newSeasonRow1.SeasonName = textBoxSeasonNameSeason.Text;
                newSeasonRow2.SeasonName = textBoxSeasonNameSeason.Text;
                newSeasonRow3.SeasonName = textBoxSeasonNameSeason.Text;
                FormSetUpSeason.SetSelectedSeason(newSeasonRow1, newSeasonRow2, newSeasonRow3);
                form.SetSeason(newSeasonRow1);
                seasonsDBDataSet.Seasons1_5.Rows.Add(newSeasonRow1);
                seasonsDBDataSet.Seasons6_10.Rows.Add(newSeasonRow2);
                seasonsDBDataSet.Seasons11_17.Rows.Add(newSeasonRow3);
                accountingDataSet.Accounting.Rows.Add(newAccountingRow);

                // make all of the players inactive for the new season if check box is checked
                if (checkBoxMakePlayersInactive.Checked == true)
                {
                    foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                    {
                        player.IsActive = false;
                    }
                }

                // reset all of the players wins, winnings and picks for the new season if check box is checked
                if (checkBoxResetPlayerPicks.Checked == true)
                {
                    Cursor.Current = Cursors.WaitCursor;

                    foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                    {
                        player.PlayerTotalWins = 0;
                        player.PlayerCurrentWins = 0;
                        player.PlayerTotalWinnings = 0;
                        player.WinsWeek01 = 0;
                        player.WinsWeek02 = 0;
                        player.WinsWeek03 = 0;
                        player.WinsWeek04 = 0;
                        player.WinsWeek05 = 0;
                        player.WinsWeek06 = 0;
                        player.WinsWeek07 = 0;
                        player.WinsWeek08 = 0;
                        player.WinsWeek09 = 0;
                        player.WinsWeek10 = 0;
                        player.WinsWeek11 = 0;
                        player.WinsWeek12 = 0;
                        player.WinsWeek13 = 0;
                        player.WinsWeek14 = 0;
                        player.WinsWeek15 = 0;
                        player.WinsWeek16 = 0;
                        player.WinsWeek17 = 0;
                        player.PicksWeek01 = "";
                        player.PicksWeek02 = "";
                        player.PicksWeek03 = "";
                        player.PicksWeek04 = "";
                        player.PicksWeek05 = "";
                        player.PicksWeek06 = "";
                        player.PicksWeek07 = "";
                        player.PicksWeek08 = "";
                        player.PicksWeek09 = "";
                        player.PicksWeek10 = "";
                        player.PicksWeek11 = "";
                        player.PicksWeek12 = "";
                        player.PicksWeek13 = "";
                        player.PicksWeek14 = "";
                        player.PicksWeek15 = "";
                        player.PicksWeek16 = "";
                        player.PicksWeek17 = "";
                        player.PlayerWinningsWeek01 = 0;
                        player.PlayerWinningsWeek02 = 0;
                        player.PlayerWinningsWeek03 = 0;
                        player.PlayerWinningsWeek04 = 0;
                        player.PlayerWinningsWeek05 = 0;
                        player.PlayerWinningsWeek06 = 0;
                        player.PlayerWinningsWeek07 = 0;
                        player.PlayerWinningsWeek08 = 0;
                        player.PlayerWinningsWeek09 = 0;
                        player.PlayerWinningsWeek10 = 0;
                        player.PlayerWinningsWeek11 = 0;
                        player.PlayerWinningsWeek12 = 0;
                        player.PlayerWinningsWeek13 = 0;
                        player.PlayerWinningsWeek14 = 0;
                        player.PlayerWinningsWeek15 = 0;
                        player.PlayerWinningsWeek16 = 0;
                        player.PlayerWinningsWeek17 = 0;
                        player.Pick01 = "";
                        player.Pick02 = "";
                        player.Pick03 = "";
                        player.Pick04 = "";
                        player.Pick05 = "";
                        player.Pick06 = "";
                        player.Pick07 = "";
                        player.Pick08 = "";
                        player.Pick09 = "";
                        player.Pick10 = "";
                        player.Pick11 = "";
                        player.Pick12 = "";
                        player.Pick13 = "";
                        player.Pick14 = "";
                        player.Pick15 = "";
                        player.Pick16 = "";
                        player.Pick17 = "";
                        player.Pick18 = "";
                        player.Pick19 = "";
                        player.Pick20 = "";
                    }

                    Cursor.Current = Cursors.Default;
                }
            }           

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }            

            this.Validate();
            this.seasons1_5BindingSource.EndEdit();
            this.seasons6_10BindingSource.EndEdit();
            this.seasons11_17BindingSource.EndEdit();
            this.playersBindingSource.EndEdit();            
            this.accountingBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.seasonsDBDataSet);
            this.tableAdapterManager1.UpdateAll(this.accountingDataSet);
            this.tableAdapterManager2.UpdateAll(this.playersDBDataSet);

            // new way to get a form that is already open. Time to go replace all of the ShowDiag() code so
            // can have multiple windows open but no duplicates.
            foreach (Form forms in Application.OpenForms)
            {
                if (forms.Name == "FormSetUpSeason")
                {
                    form = forms as FormSetUpSeason;
                    form.ClearForm();
                    form.UpdateForm();
                    form.UpdateSeasonList();
                }
            }

            this.Close();
        }

        private void seasons1_5BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            //this.Validate();
           // this.seasons1_5BindingSource.EndEdit();
          //  this.tableAdapterManager.UpdateAll(this.seasonsDBDataSet);
        }
    }
}
