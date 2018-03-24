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
    public partial class FormTransactionDetails : Form
    {
        public FormTransactionDetails()
        {
            InitializeComponent();           
        }

        private void transactionsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.transactionsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.transactionsDBDataSet);

        }

        private void FormTransactionDetails_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'accountingDataSet.Accounting' table. You can move, or remove it, as needed.
            this.accountingTableAdapter.Fill(this.accountingDataSet.Accounting);
            // TODO: This line of code loads data into the 'playersDBDataSet.Players' table. You can move, or remove it, as needed.
            this.playersTableAdapter.Fill(this.playersDBDataSet.Players);
            // TODO: This line of code loads data into the 'transactionsDBDataSet.Transactions' table. You can move, or remove it, as needed.
            this.transactionsTableAdapter.Fill(this.transactionsDBDataSet.Transactions);

            if (PublicVariables.GetDefaultSeason != null)
            {
                textBoxSelectedSeason.Text = PublicVariables.GetDefaultSeason;
            }

            PopulateForm();

        }

        private void PopulateForm()
        {
            foreach (TransactionsDBDataSet.TransactionsRow transaction in transactionsDBDataSet.Transactions)
            {
                if (transaction.Id == PublicVariables.PublicTransactionId)
                {
                    upDownAmount.Value = (decimal)transaction.Amount;
                    textBoxTransactionId.Text = transaction.Id.ToString();
                    textBoxPlayerName.Text = transaction.PlayerName;
                    textBoxDateTime.Text = transaction.Date;
                    comboBoxPayMethod.Text = transaction.Method;
                    textBoxType.Text = transaction.Type;
                    comboBoxSelectWeek.Text = transaction.Week;                  
                    upDownInterest.Value = (decimal)transaction.Interest;
                    textBoxCheckNumber.Text = transaction.CheckNumber;
                    textBoxTransactionNotes.Text = transaction.Notes;

                    PopulateReversedTransaction(transaction);
                }               
            }
        }

        private void ReverseTransaction()
        {
            // transaction inside the loop was causing problems changing data while looping through
            TransactionsDBDataSet.TransactionsRow newTransaction = null;
            PlayersDBDataSet.PlayersRow transactionPlayer = null;

            // find the correct transaction
            foreach (TransactionsDBDataSet.TransactionsRow currentTransaction in transactionsDBDataSet.Transactions)
            {
                if (currentTransaction.Id.ToString() == textBoxTransactionId.Text)
                {
                    // determine the type of transaction eg Pay, Receive or Charge
                    // if it is pay
                    if (textBoxType.Text == "Pay Out")
                    {
                        // find the player
                        foreach (PlayersDBDataSet.PlayersRow selectedPlayer in playersDBDataSet.Players)
                        {
                            if (selectedPlayer.PlayerPoolName == currentTransaction.PlayerName)
                            {
                                // subtract the amount from their total winnings
                                selectedPlayer.PlayerTotalWinnings -= upDownAmount.Value;
                                selectedPlayer.WeOWePlayer += upDownAmount.Value;
                                // subtract the amount from that weeks winnings
                                GetWeekForWinnings(selectedPlayer);

                                foreach (AccountingDataSet.AccountingRow accounting in accountingDataSet.Accounting)
                                {
                                    if (accounting.SeasonName == textBoxSelectedSeason.Text)
                                    {
                                        // subtract accounting total payed out
                                        // add accounting total funds
                                        accounting.TotalPayedOut -= upDownAmount.Value;
                                        accounting.TotalFunds += upDownAmount.Value;

                                        // pop up window reversing a pay out. does the player now owe us this amount? was the player actually paid?
                                        var confirmChargePlayer = MessageBox.Show("Do you also want to charge the player this amount? Were they physically paid and now need to pay you back?", "Confirm Charge Player", MessageBoxButtons.YesNo);
                                        // if yes then charge the player that amount
                                        if (confirmChargePlayer == DialogResult.Yes)
                                        {
                                            // need a transaction if we charge the player
                                            // create a new row
                                            newTransaction = transactionsDBDataSet.Transactions.NewTransactionsRow();
                                            transactionPlayer = selectedPlayer;
                                            // increase the player owes us
                                            selectedPlayer.PlayerOwes += upDownAmount.Value;
                                            // increase accounting total owed to us
                                            accounting.TotalOwedToUs += upDownAmount.Value;
                                            // if no then leave it alone
                                        }
                                    }
                                }
                            }
                        }
                    }
                    // if it is receive payment
                    if (textBoxType.Text == "Receive Payment" || textBoxType.Text == "Initial Payment")
                    {
                        // find the player
                        foreach (PlayersDBDataSet.PlayersRow selectedPlayer in playersDBDataSet.Players)
                        {
                            if (selectedPlayer.PlayerPoolName == currentTransaction.PlayerName)
                            {
                                // increase players player owes us
                                selectedPlayer.PlayerOwes += upDownAmount.Value;

                                foreach (AccountingDataSet.AccountingRow accounting in accountingDataSet.Accounting)
                                {
                                    if (accounting.SeasonName == textBoxSelectedSeason.Text)
                                    {
                                        // accounting subtract total funds
                                        accounting.TotalFunds -= upDownAmount.Value;
                                        // accounting increase total owed to us
                                        accounting.TotalOwedToUs += upDownAmount.Value;
                                    }
                                }
                            }
                        }
                    }
                    // if it is charge
                    if (textBoxType.Text == "Charge")
                    {
                        // find the player
                        foreach (PlayersDBDataSet.PlayersRow selectedPlayer in playersDBDataSet.Players)
                        {
                            if (selectedPlayer.PlayerPoolName == currentTransaction.PlayerName)
                            {
                                // player subtract player owes
                                selectedPlayer.PlayerOwes -= upDownAmount.Value;

                                foreach (AccountingDataSet.AccountingRow accounting in accountingDataSet.Accounting)
                                {
                                    if (accounting.SeasonName == textBoxSelectedSeason.Text)
                                    {
                                        // accounting subtract total owed to us
                                        accounting.TotalOwedToUs -= upDownAmount.Value;

                                        // no point in having a negative amount owed to us
                                        if (accounting.TotalOwedToUs <= 0)
                                        {
                                            accounting.TotalOwedToUs = 0;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // if it is credit
                    if (textBoxType.Text == "Credit")
                    {
                        // find the player
                        foreach (PlayersDBDataSet.PlayersRow selectedPlayer in playersDBDataSet.Players)
                        {
                            // player subtract player owes
                            selectedPlayer.PlayerOwes += upDownAmount.Value;
                        }
                    }

                    // if it is charge
                    if (textBoxType.Text == "Interest")
                    {

                        foreach (AccountingDataSet.AccountingRow accounting in accountingDataSet.Accounting)
                        {
                            if (accounting.SeasonName == textBoxSelectedSeason.Text)
                            {
                                // accounting subtract total owed to us
                                //accounting.TotalFunds += upDownInterest.Value;
                                accounting.TotalInterest -= upDownInterest.Value;
                            }
                        }
                    }

                    // make the transaction pay method say REVERSED
                    currentTransaction.Method = "REVERSED";
                    PopulateReversedTransaction(currentTransaction);
                }
            }

            // if a new transaction was created above by charging the player then do it here.
            if (newTransaction != null)
            {
                newTransaction.PlayerName = transactionPlayer.PlayerPoolName;
                newTransaction.SeasonName = textBoxSelectedSeason.Text;
                newTransaction.Type = "Generic Charge";
                newTransaction.Method = comboBoxPayMethod.Text;
                newTransaction.Amount = (double)upDownAmount.Value;
                newTransaction.Week = comboBoxSelectWeek.Text;
                newTransaction.Date = DateTime.Now.ToString();
                newTransaction.Notes = textBoxTransactionNotes.Text;

                if (comboBoxPayMethod.Text == "Check")
                {
                    newTransaction.CheckNumber = textBoxCheckNumber.Text;
                }

                transactionsDBDataSet.Transactions.Rows.Add(newTransaction);
            }

            // update and save transaction database     
            // update and save players database
            // update and save accounting database
            this.Validate();
            this.transactionsBindingSource.EndEdit();
            this.playersBindingSource.EndEdit();
            this.accountingBindingSource.EndEdit();
            this.tableAdapterManager1.UpdateAll(this.playersDBDataSet);
            this.tableAdapterManager2.UpdateAll(this.accountingDataSet);
            this.tableAdapterManager.UpdateAll(this.transactionsDBDataSet);           
        }

        private void SaveChanges()
        {
            double newAmount = 0;

            // get accounting
            foreach (AccountingDataSet.AccountingRow accounting in accountingDataSet.Accounting)
            {
                if (accounting.SeasonName == textBoxSelectedSeason.Text)
                {
                    // find this transaction
                    foreach (TransactionsDBDataSet.TransactionsRow currentTransaction in transactionsDBDataSet.Transactions)
                    {
                        if (currentTransaction.Id.ToString() == textBoxTransactionId.Text)
                        {
                            // find the player
                            foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                            {
                                if (player.PlayerPoolName == currentTransaction.PlayerName || currentTransaction.PlayerName == "House")
                                {
                                    // if the type is payout
                                    if (currentTransaction.Type == "Pay Out")
                                    {                                       
                                        // if the amount is not the same
                                        if (currentTransaction.Amount != (double)upDownAmount.Value)
                                        {
                                            // if the original amount is more than the new amount
                                            if (currentTransaction.Amount > (double)upDownAmount.Value)
                                            {
                                                // subtract the original amount from the new amount
                                                newAmount = currentTransaction.Amount - (double)upDownAmount.Value;
                                                // remove the difference from accounting
                                                accounting.TotalPayedOut -= (decimal)newAmount;
                                                accounting.TotalFunds += (decimal)newAmount;
                                                // decrease total winnings because they received less now
                                                player.PlayerTotalWinnings -= (decimal)newAmount;
                                                GetWeekForWinnings(player, (decimal)newAmount, true);
                                            }
                                            // if the original amount is less than the new amount
                                            if (currentTransaction.Amount < (double)upDownAmount.Value)
                                            {
                                                // subtract the new amount from the original amount
                                                newAmount = (double)upDownAmount.Value - currentTransaction.Amount;
                                                // increase accounting by the difference
                                                accounting.TotalPayedOut += (decimal)newAmount;
                                                accounting.TotalFunds -= (decimal)newAmount;
                                                // increase player total winnings because they received more money
                                                player.PlayerTotalWinnings += (decimal)newAmount;
                                                GetWeekForWinnings(player, (decimal)newAmount, false);
                                            }
                                        }                                       
                                    }
                                    // if it is Receive Payment
                                    if (currentTransaction.Type == "Receive Payment" || currentTransaction.Type == "Initial Payment")
                                    {
                                        if (currentTransaction.Amount > (double)upDownAmount.Value)
                                        {
                                            newAmount = currentTransaction.Amount - (double)upDownAmount.Value;
                                            accounting.TotalFunds -= (decimal)newAmount;
                                            player.PlayerOwes += (decimal)newAmount;
                                            accounting.TotalOwedToUs += (decimal)newAmount;                          
                                        }
                                        if (currentTransaction.Amount < (double)upDownAmount.Value)
                                        {
                                            newAmount = (double)upDownAmount.Value - currentTransaction.Amount;
                                            accounting.TotalFunds += (decimal)newAmount;
                                            player.PlayerOwes -= (decimal)newAmount;
                                            accounting.TotalOwedToUs -= (decimal)newAmount;
                                            if(accounting.TotalOwedToUs < 0)
                                            {
                                                accounting.TotalOwedToUs = 0;
                                            }
                                        }
                                    }
                                    if (currentTransaction.Type == "Charge")
                                    {
                                        if (currentTransaction.Amount > (double)upDownAmount.Value)
                                        {
                                            newAmount = currentTransaction.Amount - (double)upDownAmount.Value;
                                            player.PlayerOwes -= (decimal)newAmount;
                                            accounting.TotalOwedToUs -= (decimal)newAmount;
                                            if (accounting.TotalOwedToUs < 0)
                                            {
                                                accounting.TotalOwedToUs = 0;
                                            }
                                        }
                                        if (currentTransaction.Amount < (double)upDownAmount.Value)
                                        {
                                            newAmount = (double)upDownAmount.Value - currentTransaction.Amount;
                                            player.PlayerOwes += (decimal)newAmount;
                                            accounting.TotalOwedToUs += (decimal)newAmount;
                                        }
                                    }

                                    // actually make the transaction changes here
                                    // change the actual transaction amount
                                    currentTransaction.Amount = (double)upDownAmount.Value;

                                    // if it was a check then save the check number
                                    if (currentTransaction.Method == "Check")
                                    {
                                        // if the check number entered is different then change it
                                        if (currentTransaction.CheckNumber != textBoxCheckNumber.Text)
                                        {
                                            currentTransaction.CheckNumber = textBoxCheckNumber.Text;
                                        }
                                    }
                                    //method
                                    if (currentTransaction.Method != comboBoxPayMethod.Text)
                                    {
                                        currentTransaction.Method = comboBoxPayMethod.Text;
                                    }
                                    //week
                                    if (currentTransaction.Week != comboBoxSelectWeek.Text)
                                    {
                                        currentTransaction.Week = comboBoxSelectWeek.Text;
                                    }
                                    //interest
                                    if (currentTransaction.Interest != (double)upDownInterest.Value)
                                    {
                                        currentTransaction.Interest = (double)upDownInterest.Value;
                                    }

                                    currentTransaction.Notes = textBoxTransactionNotes.Text;

                                    // update databases here

                                    // update and save transaction database     
                                    // update and save players database
                                    // update and save accounting database
                                    this.Validate();
                                    this.transactionsBindingSource.EndEdit();
                                    this.playersBindingSource.EndEdit();
                                    this.accountingBindingSource.EndEdit();
                                    this.tableAdapterManager1.UpdateAll(this.playersDBDataSet);
                                    this.tableAdapterManager2.UpdateAll(this.accountingDataSet);
                                    this.tableAdapterManager.UpdateAll(this.transactionsDBDataSet);

                                }
                            }
                            
                        }
                    }
                }
            }           
        }

        private void comboBoxPayMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPayMethod.Text == "Check")
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

        private void GetWeekForWinnings(PlayersDBDataSet.PlayersRow player)
        {
            // need to find out which week is selected and select the right weekly winnings for player
            if (comboBoxSelectWeek.Text == "Week 01")
            {
                player.PlayerWinningsWeek01 -= (int)upDownAmount.Value;
            }
            if (comboBoxSelectWeek.Text == "Week 02")
            {
                player.PlayerWinningsWeek02 -= (int)upDownAmount.Value;
            }
            if (comboBoxSelectWeek.Text == "Week 03")
            {
                player.PlayerWinningsWeek03 -= (int)upDownAmount.Value;
            }
            if (comboBoxSelectWeek.Text == "Week 04")
            {
                player.PlayerWinningsWeek04 -= (int)upDownAmount.Value;
            }
            if (comboBoxSelectWeek.Text == "Week 05")
            {
                player.PlayerWinningsWeek05 -= (int)upDownAmount.Value;
            }
            if (comboBoxSelectWeek.Text == "Week 06")
            {
                player.PlayerWinningsWeek06 -= (int)upDownAmount.Value;
            }
            if (comboBoxSelectWeek.Text == "Week 07")
            {
                player.PlayerWinningsWeek07 -= (int)upDownAmount.Value;
            }
            if (comboBoxSelectWeek.Text == "Week 08")
            {
                player.PlayerWinningsWeek08 -= (int)upDownAmount.Value;
            }
            if (comboBoxSelectWeek.Text == "Week 09")
            {
                player.PlayerWinningsWeek09 -= (int)upDownAmount.Value;
            }
            if (comboBoxSelectWeek.Text == "Week 10")
            {
                player.PlayerWinningsWeek10 -= (int)upDownAmount.Value;
            }
            if (comboBoxSelectWeek.Text == "Week 11")
            {
                player.PlayerWinningsWeek11 -= (int)upDownAmount.Value;
            }
            if (comboBoxSelectWeek.Text == "Week 12")
            {
                player.PlayerWinningsWeek12 -= (int)upDownAmount.Value;
            }
            if (comboBoxSelectWeek.Text == "Week 13")
            {
                player.PlayerWinningsWeek13 -= (int)upDownAmount.Value;
            }
            if (comboBoxSelectWeek.Text == "Week 14")
            {
                player.PlayerWinningsWeek14 -= (int)upDownAmount.Value;
            }
            if (comboBoxSelectWeek.Text == "Week 15")
            {
                player.PlayerWinningsWeek15 -= (int)upDownAmount.Value;
            }
            if (comboBoxSelectWeek.Text == "Week 16")
            {
                player.PlayerWinningsWeek16 -= (int)upDownAmount.Value;
            }
            if (comboBoxSelectWeek.Text == "Week 17")
            {
                player.PlayerWinningsWeek17 -= (int)upDownAmount.Value;
            }
        }

        private void GetWeekForWinnings(PlayersDBDataSet.PlayersRow player, decimal amount, bool isLess)
        {
            if (isLess)
            {
                // need to find out which week is selected and select the right weekly winnings for player
                if (comboBoxSelectWeek.Text == "Week 01")
                {
                    player.PlayerWinningsWeek01 -= (int)amount;
                }
                if (comboBoxSelectWeek.Text == "Week 02")
                {
                    player.PlayerWinningsWeek02 -= (int)amount;
                }
                if (comboBoxSelectWeek.Text == "Week 03")
                {
                    player.PlayerWinningsWeek03 -= (int)amount;
                }
                if (comboBoxSelectWeek.Text == "Week 04")
                {
                    player.PlayerWinningsWeek04 -= (int)amount;
                }
                if (comboBoxSelectWeek.Text == "Week 05")
                {
                    player.PlayerWinningsWeek05 -= (int)amount;
                }
                if (comboBoxSelectWeek.Text == "Week 06")
                {
                    player.PlayerWinningsWeek06 -= (int)amount;
                }
                if (comboBoxSelectWeek.Text == "Week 07")
                {
                    player.PlayerWinningsWeek07 -= (int)amount;
                }
                if (comboBoxSelectWeek.Text == "Week 08")
                {
                    player.PlayerWinningsWeek08 -= (int)amount;
                }
                if (comboBoxSelectWeek.Text == "Week 09")
                {
                    player.PlayerWinningsWeek09 -= (int)amount;
                }
                if (comboBoxSelectWeek.Text == "Week 10")
                {
                    player.PlayerWinningsWeek10 -= (int)amount;
                }
                if (comboBoxSelectWeek.Text == "Week 11")
                {
                    player.PlayerWinningsWeek11 -= (int)amount;
                }
                if (comboBoxSelectWeek.Text == "Week 12")
                {
                    player.PlayerWinningsWeek12 -= (int)amount;
                }
                if (comboBoxSelectWeek.Text == "Week 13")
                {
                    player.PlayerWinningsWeek13 -= (int)amount;
                }
                if (comboBoxSelectWeek.Text == "Week 14")
                {
                    player.PlayerWinningsWeek14 -= (int)amount;
                }
                if (comboBoxSelectWeek.Text == "Week 15")
                {
                    player.PlayerWinningsWeek15 -= (int)amount;
                }
                if (comboBoxSelectWeek.Text == "Week 16")
                {
                    player.PlayerWinningsWeek16 -= (int)amount;
                }
                if (comboBoxSelectWeek.Text == "Week 17")
                {
                    player.PlayerWinningsWeek17 -= (int)amount;
                }
            }
            if (!isLess)
            {
                if (comboBoxSelectWeek.Text == "Week 01")
                {
                    player.PlayerWinningsWeek01 += (int)amount;
                }
                if (comboBoxSelectWeek.Text == "Week 02")
                {
                    player.PlayerWinningsWeek02 += (int)amount;
                }
                if (comboBoxSelectWeek.Text == "Week 03")
                {
                    player.PlayerWinningsWeek03 += (int)amount;
                }
                if (comboBoxSelectWeek.Text == "Week 04")
                {
                    player.PlayerWinningsWeek04 += (int)amount;
                }
                if (comboBoxSelectWeek.Text == "Week 05")
                {
                    player.PlayerWinningsWeek05 += (int)amount;
                }
                if (comboBoxSelectWeek.Text == "Week 06")
                {
                    player.PlayerWinningsWeek06 += (int)amount;
                }
                if (comboBoxSelectWeek.Text == "Week 07")
                {
                    player.PlayerWinningsWeek07 += (int)amount;
                }
                if (comboBoxSelectWeek.Text == "Week 08")
                {
                    player.PlayerWinningsWeek08 += (int)amount;
                }
                if (comboBoxSelectWeek.Text == "Week 09")
                {
                    player.PlayerWinningsWeek09 += (int)amount;
                }
                if (comboBoxSelectWeek.Text == "Week 10")
                {
                    player.PlayerWinningsWeek10 += (int)amount;
                }
                if (comboBoxSelectWeek.Text == "Week 11")
                {
                    player.PlayerWinningsWeek11 += (int)amount;
                }
                if (comboBoxSelectWeek.Text == "Week 12")
                {
                    player.PlayerWinningsWeek12 += (int)amount;
                }
                if (comboBoxSelectWeek.Text == "Week 13")
                {
                    player.PlayerWinningsWeek13 += (int)amount;
                }
                if (comboBoxSelectWeek.Text == "Week 14")
                {
                    player.PlayerWinningsWeek14 += (int)amount;
                }
                if (comboBoxSelectWeek.Text == "Week 15")
                {
                    player.PlayerWinningsWeek15 += (int)amount;
                }
                if (comboBoxSelectWeek.Text == "Week 16")
                {
                    player.PlayerWinningsWeek16 += (int)amount;
                }
                if (comboBoxSelectWeek.Text == "Week 17")
                {
                    player.PlayerWinningsWeek17 += (int)amount;
                }
            }
        }

        private void buttonReverseTransaction_Click(object sender, EventArgs e)
        {
            ReverseTransaction();
        }

        private void PopulateReversedTransaction(TransactionsDBDataSet.TransactionsRow transaction)
        {
            // if the transaction has been reversed then disable everything
            if (transaction.Method == "REVERSED")
            {
                MessageBox.Show("This transaction has been reversed. Changes can no longer be made to it. Go to accounting and create a new transaction.");
                textBoxType.Enabled = false;
                comboBoxPayMethod.Enabled = false;
                comboBoxSelectWeek.Enabled = false;
                upDownAmount.Enabled = false;
                upDownInterest.Enabled = false;
                textBoxDateTime.Enabled = false;
                textBoxCheckNumber.Enabled = false;
                buttonReverseTransaction.Visible = false;
                buttonSaveChanges.Visible = false;
                textBoxTransactionNotes.Enabled = false;
            }
            else
            {
                textBoxType.Enabled = true;
                comboBoxPayMethod.Enabled = true;
                comboBoxSelectWeek.Enabled = true;
                upDownAmount.Enabled = true;
                upDownInterest.Enabled = true;
                textBoxDateTime.Enabled = true;
                textBoxCheckNumber.Enabled = true;
                buttonReverseTransaction.Visible = true;
                buttonSaveChanges.Visible = true;
                textBoxTransactionNotes.Enabled = true;
            }
        }

        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            SaveChanges();
            MessageBox.Show("Changes saved.");
        }
    }
}
