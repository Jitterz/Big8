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
    public partial class FormGroups : Form
    {
        public FormGroups()
        {
            InitializeComponent();

            // get the current season
            if (PublicVariables.GetDefaultSeason != null)
            {
                textBoxSelectedSeason.Text = PublicVariables.GetDefaultSeason;
            }

            if (PublicVariables.GetDefaultWeek != null)
            {
                comboBoxSelectWeek.Text = PublicVariables.GetDefaultWeek;
            }

        }

        private void FormGroups_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'transactionsDBDataSet.Transactions' table. You can move, or remove it, as needed.
            this.transactionsTableAdapter.Fill(this.transactionsDBDataSet.Transactions);
            // TODO: This line of code loads data into the 'seasonsDBDataSet.Seasons6_10' table. You can move, or remove it, as needed.
            this.seasons6_10TableAdapter.Fill(this.seasonsDBDataSet.Seasons6_10);
            // TODO: This line of code loads data into the 'seasonsDBDataSet.Seasons11_17' table. You can move, or remove it, as needed.
            this.seasons11_17TableAdapter.Fill(this.seasonsDBDataSet.Seasons11_17);
            // TODO: This line of code loads data into the 'seasonsDBDataSet.Seasons1_5' table. You can move, or remove it, as needed.
            this.seasons1_5TableAdapter.Fill(this.seasonsDBDataSet.Seasons1_5);
            // TODO: This line of code loads data into the 'playersDBDataSet.Players' table. You can move, or remove it, as needed.
            this.playersTableAdapter.Fill(this.playersDBDataSet.Players);
            // TODO: This line of code loads data into the 'accountingDataSet.Accounting' table. You can move, or remove it, as needed.
            this.accountingTableAdapter.Fill(this.accountingDataSet.Accounting);

            // Load the groups into the list box
            LoadGroups();
        }

        private void LoadGroups()
        {
            bool isAlreadyListed = false;

            // find each player
            foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
            {
                // if player notes is not blank
                if (player.Notes != "")
                {
                    // search the list box for the matching group
                    int index = listBoxGroupNames.FindString(player.Notes);

                    // if it finds nothing index will be -1
                    if (index != -1)
                    {
                        // if it found one then it is already listed
                        isAlreadyListed = true;
                    }
                    else
                    {
                        // otherwise it is not listed yet
                        isAlreadyListed = false;
                    }
                }              

                // if the group name is not in the box and the group name is not empty then add it
                if (!isAlreadyListed && player.Notes != "")
                {
                    listBoxGroupNames.Items.Add(player.Notes);
                }
            }
        }

        private void LoadPlayersInGroup(string selectedGroup)
        {
            foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
            {
                // if the players group matches the selected group from groups listbox
                if (player.Notes == selectedGroup)
                {
                    // add that player to the player list box
                    listBoxPlayerNames.Items.Add(player.PlayerPoolName);
                }
            }
        }

        private void UpdateLabels(string selectedGroup)
        {
            decimal weOweThemTotal = 0;
            decimal theyOweUsTotal = 0;

            foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
            {
                // add the leader info
                if (player.Notes == selectedGroup && player.IsGroupLeader == true)
                {
                    labelGroupLeaderName.Text = player.PlayerPoolName;
                    labelPayMethod.Text = player.PlayerPayoutMethod;
                }

                // total the owe us and owe them labels
                if (player.Notes == selectedGroup)
                {
                    weOweThemTotal += player.WeOWePlayer;
                    theyOweUsTotal += player.PlayerOwes;
                }
            }

            // display the labels
            labelTotalWeOweGroup.Text = weOweThemTotal.ToString();
            labelTotalGroupOwes.Text = theyOweUsTotal.ToString();
        }
         

        private void accountingBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.accountingBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.accountingDataSet);

        }

        private void listBoxPlayerNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listBoxGroupNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxPlayerNames.Items.Clear();
            LoadPlayersInGroup(listBoxGroupNames.SelectedItem.ToString());
            UpdateLabels(listBoxGroupNames.SelectedItem.ToString());
        }

        private void buttonPayGroup_Click(object sender, EventArgs e)
        {
            if (comboBoxSelectWeek.Text == "")
            {
                MessageBox.Show("No week selected.");
                return;
            }

            string groupPayOutReport = "";
            int accountingTotal = 0;

            // if there is a group selected
            if (listBoxGroupNames.SelectedIndex != -1)
            {
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    // and the players notes 'group name' matches the selected one in the list box
                    if (player.Notes == listBoxGroupNames.SelectedItem.ToString() && player.WeOWePlayer != 0)
                    {
                        // this is to total all of the transactions to apply to accounting below
                        accountingTotal += (int)player.WeOWePlayer;

                        // then pay them whatever we owe them
                        player.PlayerTotalWinnings += player.WeOWePlayer;
                        // pay out by the week. keep track of winnings each week.
                        TotalWeekWinnings(comboBoxSelectWeek.Text, player);

                        // create the transaction
                        NewTransaction(player);

                        // create string a report of what was paid to whom
                        groupPayOutReport += player.PlayerPoolName + " " + "Received: " + player.WeOWePlayer + " for " + comboBoxSelectWeek.Text + Environment.NewLine;
                        player.WeOWePlayer = 0;
                    }
                }

                foreach (AccountingDataSet.AccountingRow accounting in accountingDataSet.Accounting)
                {
                    if (accounting.SeasonName == textBoxSelectedSeason.Text)
                    {
                        accounting.TotalPayedOut += accountingTotal;
                        accounting.TotalFunds -= accountingTotal;
                        accounting.TotalWeOweOut -= accountingTotal;
                    }
                }

                // update the databases
                this.Validate();
                this.accountingBindingSource.EndEdit();
                this.playersBindingSource.EndEdit();
                this.tableAdapterManager1.UpdateAll(this.playersDBDataSet);
                this.tableAdapterManager.UpdateAll(this.accountingDataSet);

                groupPayOutReport += "Total Payed Out: " + accountingTotal.ToString();
                MessageBox.Show(groupPayOutReport);
            }
            else
            {
                MessageBox.Show("You must select a group first.");
                return;
            }
        }

        private void NewTransaction(PlayersDBDataSet.PlayersRow selectedPlayer)
        {
            // create a new row
            TransactionsDBDataSet.TransactionsRow newTransaction = transactionsDBDataSet.Transactions.NewTransactionsRow();

            // add the data to that row
            newTransaction.PlayerName = selectedPlayer.PlayerPoolName;
            newTransaction.SeasonName = textBoxSelectedSeason.Text;
            newTransaction.Type = "Pay Out";
            newTransaction.Method = comboBoxPayMethod.Text;
            newTransaction.Amount = (double)selectedPlayer.WeOWePlayer;
            newTransaction.Week = comboBoxSelectWeek.Text;
            newTransaction.Date = DateTime.Now.ToString();
            newTransaction.Notes = "Group Pay Out";

            if (comboBoxPayMethod.Text == "Check")
            {
                if (textBoxCheckNumber.Text == "")
                {
                    MessageBox.Show("Enter a check number.");
                    return;
                }

                newTransaction.CheckNumber = textBoxCheckNumber.Text;
            }

            transactionsDBDataSet.Transactions.Rows.Add(newTransaction);

            this.Validate();
            this.transactionsBindingSource.EndEdit();
            this.tableAdapterManager3.UpdateAll(this.transactionsDBDataSet);
        }

        private void TotalWeekWinnings(string selectedWeek, PlayersDBDataSet.PlayersRow selectedPlayer)
        {
            if (selectedWeek == "Week 01")
            {
                selectedPlayer.PlayerWinningsWeek01 += (int)selectedPlayer.WeOWePlayer;
            }
            if (selectedWeek == "Week 02")
            {
                selectedPlayer.PlayerWinningsWeek02 += (int)selectedPlayer.WeOWePlayer;
            }
            if (selectedWeek == "Week 03")
            {
                selectedPlayer.PlayerWinningsWeek03 += (int)selectedPlayer.WeOWePlayer;
            }
            if (selectedWeek == "Week 04")
            {
                selectedPlayer.PlayerWinningsWeek04 += (int)selectedPlayer.WeOWePlayer;
            }
            if (selectedWeek == "Week 05")
            {
                selectedPlayer.PlayerWinningsWeek05 += (int)selectedPlayer.WeOWePlayer;
            }
            if (selectedWeek == "Week 06")
            {
                selectedPlayer.PlayerWinningsWeek06 += (int)selectedPlayer.WeOWePlayer;
            }
            if (selectedWeek == "Week 07")
            {
                selectedPlayer.PlayerWinningsWeek07 += (int)selectedPlayer.WeOWePlayer;
            }
            if (selectedWeek == "Week 08")
            {
                selectedPlayer.PlayerWinningsWeek08 += (int)selectedPlayer.WeOWePlayer;
            }
            if (selectedWeek == "Week 09")
            {
                selectedPlayer.PlayerWinningsWeek09 += (int)selectedPlayer.WeOWePlayer;
            }
            if (selectedWeek == "Week 10")
            {
                selectedPlayer.PlayerWinningsWeek10 += (int)selectedPlayer.WeOWePlayer;
            }
            if (selectedWeek == "Week 11")
            {
                selectedPlayer.PlayerWinningsWeek11 += (int)selectedPlayer.WeOWePlayer;
            }
            if (selectedWeek == "Week 12")
            {
                selectedPlayer.PlayerWinningsWeek12 += (int)selectedPlayer.WeOWePlayer;
            }
            if (selectedWeek == "Week 13")
            {
                selectedPlayer.PlayerWinningsWeek13 += (int)selectedPlayer.WeOWePlayer;
            }
            if (selectedWeek == "Week 14")
            {
                selectedPlayer.PlayerWinningsWeek14 += (int)selectedPlayer.WeOWePlayer;
            }
            if (selectedWeek == "Week 15")
            {
                selectedPlayer.PlayerWinningsWeek15 += (int)selectedPlayer.WeOWePlayer;
            }
            if (selectedWeek == "Week 16")
            {
                selectedPlayer.PlayerWinningsWeek16 += (int)selectedPlayer.WeOWePlayer;
            }
            if (selectedWeek == "Week 17")
            {
                selectedPlayer.PlayerWinningsWeek17 += (int)selectedPlayer.WeOWePlayer;
            }
        }

        private void comboBoxPayMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPayMethod.SelectedText == "Check")
            {
                textBoxCheckNumber.Visible = true;
                labelCheckNumber.Visible = true;
            }
            else
            {
                textBoxCheckNumber.Visible = false;
                labelCheckNumber.Visible = false;
            }
        }
    }
}
