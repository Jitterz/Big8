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
    public partial class FormProgressive : Form
    {
        private double progressiveTotal;

        public FormProgressive()
        {
            InitializeComponent();

            //listViewProgressiveWinners.View = View.Details;
        }

        private void PopulateProgressiveBox()
        {
            listViewProgressiveWinners.Items.Clear();

            foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
            {
                if (player.IsActive)
                {
                    ListViewItem newRow = new ListViewItem();

                    newRow.Text = player.PlayerPoolName;
                    newRow.SubItems.Add(player.PlayerTotalWins.ToString());

                    listViewProgressiveWinners.Items.Add(newRow);
                }
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {

        }

        private void CalculateProgressiveTotal()
        {
            progressiveTotal = 0;

            foreach (TransactionsDBDataSet.TransactionsRow trans in transactionsDBDataSet.Transactions)
            {
                if (trans.Type == "Progressive" && trans.SeasonName == PublicVariables.GetDefaultSeason)
                {
                    progressiveTotal += trans.Amount;
                }
            }
        }

        private void UpdateForm()
        {
            //listViewProgressiveWinners.SelectedIndices.Clear();
            upDownPayAmount.Value = 0;
            labelTotalProgressive.Text = progressiveTotal.ToString();
        }

        private void CreatePlayerTransaction(PlayersDBDataSet.PlayersRow player)
        {
            // make the transaction here
            TransactionsDBDataSet.TransactionsRow newWinTransaction = transactionsDBDataSet.Transactions.NewTransactionsRow();
            
            // add the data to that row                  
            newWinTransaction.PlayerName = player.PlayerPoolName;
            newWinTransaction.SeasonName = PublicVariables.GetDefaultSeason;
            newWinTransaction.Type = "Win Credit";
            newWinTransaction.Method = "Win Credit Progressive";
            newWinTransaction.Amount = -(double)upDownPayAmount.Value;
            newWinTransaction.Week = "Week 17";
            newWinTransaction.Date = DateTime.Now.ToString();
            newWinTransaction.Notes = "Progressive Win Credit";            

            transactionsDBDataSet.Transactions.Rows.Add(newWinTransaction);

            TransactionsDBDataSet.TransactionsRow newWinTransaction2 = transactionsDBDataSet.Transactions.NewTransactionsRow();

            newWinTransaction2.PlayerName = player.PlayerPoolName;
            newWinTransaction2.SeasonName = PublicVariables.GetDefaultSeason;
            newWinTransaction2.Type = "Pay Out";
            newWinTransaction2.Method = "Pay Out Progressive";
            newWinTransaction2.Amount = (double)upDownPayAmount.Value;
            newWinTransaction2.Week = "Week 17";
            newWinTransaction2.Date = DateTime.Now.ToString();
            newWinTransaction2.Notes = "Progressive Pay Out";

            transactionsDBDataSet.Transactions.Rows.Add(newWinTransaction2);
        }

        private void CreateProgressiveTransaction()
        {
            // make the transaction here
            TransactionsDBDataSet.TransactionsRow newProgressiveTransaction = transactionsDBDataSet.Transactions.NewTransactionsRow();
            // add the data to that row                  
            newProgressiveTransaction.PlayerName = "Progressive Pot";
            newProgressiveTransaction.SeasonName = PublicVariables.GetDefaultSeason;
            newProgressiveTransaction.Type = "Progressive";
            newProgressiveTransaction.Method = "Auto Progressive";
            newProgressiveTransaction.Amount = -(double)upDownPayAmount.Value;
            newProgressiveTransaction.Week = "Week 17";
            newProgressiveTransaction.Date = DateTime.Now.ToString();
            newProgressiveTransaction.Notes = "Remove Progressive Amount";

            transactionsDBDataSet.Transactions.Rows.Add(newProgressiveTransaction);

            foreach (AccountingDataSet.AccountingRow accounting in accountingDataSet.Accounting)
            {
                if (accounting.SeasonName == PublicVariables.GetDefaultSeason)
                {
                    accounting.ProgressivePot -= upDownPayAmount.Value;
                }
            }
        }

        private void playersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.playersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.playersDBDataSet);

        }

        private void FormProgressive_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'transactionsDBDataSet.Transactions' table. You can move, or remove it, as needed.
            this.transactionsTableAdapter.Fill(this.transactionsDBDataSet.Transactions);
            // TODO: This line of code loads data into the 'accountingDataSet.Accounting' table. You can move, or remove it, as needed.
            this.accountingTableAdapter.Fill(this.accountingDataSet.Accounting);
            // TODO: This line of code loads data into the 'playersDBDataSet.Players' table. You can move, or remove it, as needed.
            this.playersTableAdapter.Fill(this.playersDBDataSet.Players);


            PopulateProgressiveBox();
            CalculateProgressiveTotal();
            UpdateForm();
        }

        private void buttonSubmit_Click_1(object sender, EventArgs e)
        {
            if (listViewProgressiveWinners.SelectedItems[0] != null)
            {
                string selectedPlayer = listViewProgressiveWinners.SelectedItems[0].Text;

                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    if (player.PlayerPoolName == selectedPlayer)
                    {
                        if (upDownPayAmount.Value > 0)
                        {
                            player.PlayerTotalWinnings += upDownPayAmount.Value;
                            CreatePlayerTransaction(player);
                            CreateProgressiveTransaction();

                            // update the databases
                            this.Validate();
                            this.accountingBindingSource.EndEdit();
                            this.playersBindingSource.EndEdit();
                            this.transactionsBindingSource.EndEdit();
                            this.tableAdapterManager.UpdateAll(this.playersDBDataSet);
                            this.tableAdapterManager1.UpdateAll(this.accountingDataSet);
                            this.tableAdapterManager2.UpdateAll(this.transactionsDBDataSet);

                            CalculateProgressiveTotal();                            
                            MessageBox.Show("Player: " + player.PlayerPoolName + " received credit of " + upDownPayAmount.Value.ToString());
                            UpdateForm();
                        }
                        else
                        {
                            MessageBox.Show("You must enter an amount.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("You must select a player from the list.");
            }
        }
    }
}


