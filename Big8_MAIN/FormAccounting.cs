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
    public partial class FormAccounting : Form
    {
        public FormAccounting()
        {
            InitializeComponent();

            // get the current season
            if (PublicVariables.GetDefaultSeason != null)
            {
                textBoxSelectedSeason.Text = PublicVariables.GetDefaultSeason;
            }
            if (PublicVariables.GetDefaultWeek != null)
            {
                comboBoxSelectWeek.SelectedItem = PublicVariables.GetDefaultWeek;
            }

            upDownAmount.Click += upDownAmount_Click;

            listViewWhoOwesUs.MouseDoubleClick += new MouseEventHandler(listViewWhoOwesUs_DoubleClick);
            listViewWhoWeOwe.MouseDoubleClick += new MouseEventHandler(listViewWhoWeOwe_DoubleClick);
            listViewTransactionWindow.MouseDoubleClick += new MouseEventHandler(listViewTransactionWindow_DoubleClick);

            //this.Activated += FormAccounting_Activated;
        }

        private void accountingBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.accountingBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.accountingDataSet);

        }

        private void listViewTransactionWindow_DoubleClick(object sender, MouseEventArgs e)
        {
            OpenTransactionDetailsWindow();
        }

        private void listViewWhoOwesUs_DoubleClick(object sender, MouseEventArgs e)
        {
            // code to open ledger window. need to find the correct player first
            foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
            {
                // if the selected item that was double clicked contains the players pool name
                if (listViewWhoOwesUs.FocusedItem.Text == player.PlayerPoolName)
                {
                    PublicVariables.PlayerPublicLedger = player;

                    // open the ledger form
                    // check to see if the form is open
                    if ((Application.OpenForms["FormPlayerLedger"] as FormPlayerLedger) != null)
                    {
                        // if it is then select the right form
                        foreach (Form form in Application.OpenForms)
                        {
                            if (form.Name == "FormPlayerLedger")
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
                        FormPlayerLedger formPlayerLedger = new FormPlayerLedger();
                        formPlayerLedger.Show();
                    }
                }
            }
        }

        private void listViewWhoWeOwe_DoubleClick(object sender, MouseEventArgs e)
        {
            // code to open ledger window. need to find the correct player first
            foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
            {
                // if the selected item that was double clicked contains the players pool name
                if (listViewWhoWeOwe.FocusedItem.Text == player.PlayerPoolName)
                {
                    PublicVariables.PlayerPublicLedger = player;

                    // open the ledger form
                    // check to see if the form is open
                    if ((Application.OpenForms["FormPlayerLedger"] as FormPlayerLedger) != null)
                    {
                        // if it is then select the right form
                        foreach (Form form in Application.OpenForms)
                        {
                            if (form.Name == "FormPlayerLedger")
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
                        FormPlayerLedger formPlayerLedger = new FormPlayerLedger();
                        formPlayerLedger.Show();
                    }
                }
            }
        }


        private void upDownAmount_Click(object sender, EventArgs e)
        {
            upDownAmount.Select(0, upDownAmount.Text.Length);
        }

        private void FormAccounting_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'transactionsDBDataSet.Transactions' table. You can move, or remove it, as needed.
            this.transactionsTableAdapter.Fill(this.transactionsDBDataSet.Transactions);
            // TODO: This line of code loads data into the 'seasonsDBDataSet.Seasons11_17' table. You can move, or remove it, as needed.
            this.seasons11_17TableAdapter.Fill(this.seasonsDBDataSet.Seasons11_17);
            // TODO: This line of code loads data into the 'seasonsDBDataSet.Seasons6_10' table. You can move, or remove it, as needed.
            this.seasons6_10TableAdapter.Fill(this.seasonsDBDataSet.Seasons6_10);
            // TODO: This line of code loads data into the 'seasonsDBDataSet.Seasons1_5' table. You can move, or remove it, as needed.
            this.seasons1_5TableAdapter.Fill(this.seasonsDBDataSet.Seasons1_5);
            // TODO: This line of code loads data into the 'playersDBDataSet.Players' table. You can move, or remove it, as needed.
            this.playersTableAdapter.Fill(this.playersDBDataSet.Players);
            // TODO: This line of code loads data into the 'accountingDataSet.Accounting' table. You can move, or remove it, as needed.
            this.accountingTableAdapter.Fill(this.accountingDataSet.Accounting);

            UpdatePlayerList();

            // fill the boxes
            TotalOwingWindows();
            UpdateTotals();

        }

        private void UpdateTotals()
        {
            listViewAccountingTotals.Items.Clear();

            //double charges = 0;
            //double credits = 0;
            double interest = 0;
            double poolFunds = 0;
            double realCash = 0;
            double progressive = 0;

            // total each type of transaction
            // make sure it is the right season
            foreach (TransactionsDBDataSet.TransactionsRow transaction in transactionsDBDataSet.Transactions)
            {
                if (transaction.SeasonName == PublicVariables.GetDefaultSeason)
                {
                    /*if (transaction.Type == "Charge")
                    {
                        charges += transaction.Amount;
                    }
                    */
                    if (transaction.Type == "Receive Payment" || transaction.Type == "Initial Payment")
                    {
                        realCash += transaction.Amount * -1;
                    }
                    if (transaction.Type == "Pay Out")
                    {
                        realCash -= transaction.Amount;
                    }
                    /*if (transaction.Type == "Credit")
                    {
                        credits += transaction.Amount;
                    }
                    */
                    if (transaction.Type == "Interest")
                    {
                        interest += transaction.Interest;
                    }
                    if (transaction.Type == "Progressive")
                    {
                        progressive += transaction.Amount;
                    }
                }
            }

            poolFunds = realCash - (progressive + interest);

            // calculate and display the totals
            ListViewItem newRow = new ListViewItem();

            //newRow.Text = charges.ToString();
            //newRow.SubItems.Add(credits.ToString());
            newRow.Text = interest.ToString();
            //newRow.SubItems.Add(balance.ToString());
            newRow.SubItems.Add(progressive.ToString());
            newRow.SubItems.Add(poolFunds.ToString());
            newRow.SubItems.Add(realCash.ToString());

            listViewAccountingTotals.Items.Add(newRow);
        }

        // need to populate the owing windows.
        private void TotalOwingWindows()
        {
            // clear the boxes
            // need to clear the new list box instead of text box
            listViewWhoWeOwe.Items.Clear();
            listViewWhoOwesUs.Items.Clear();

            double balance = 0;
            double totalOweUs = 0;
            double totalWeOwe = 0;

            foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
            {
                if (player.IsActive == true)
                {
                    // get the players balance
                    balance = CalculatePlayerBalance(player);

                    // as long as it is not 0
                    if (balance != 0)
                    {
                        ListViewItem newRow = new ListViewItem();

                        newRow.Text = player.PlayerPoolName;
                        newRow.SubItems.Add(balance.ToString());

                        // if it is greater than 0 they owe us
                        if (balance > 0)
                        {
                            totalOweUs += balance;
                            listViewWhoOwesUs.Items.Add(newRow);
                        }
                        // less than zero we owe them
                        if (balance < 0)
                        {
                            totalWeOwe += balance;
                            listViewWhoWeOwe.Items.Add(newRow);
                        }
                    }

                    labelTotalWeOwe.Text = totalWeOwe.ToString();
                    labelTotalOwesUs.Text = totalOweUs.ToString();
                }
            }
        }

        private void UpdatePlayerList()
        {
            // clear the list then repopulate it
            listBoxPlayersList.Items.Clear();
            // find the selected player in the database 
            foreach (PlayersDBDataSet.PlayersRow row in playersDBDataSet.Players)
            {
                listBoxPlayersList.Items.Add(row.PlayerPoolName);
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            // make sure a player is selected
            if (listBoxPlayersList.SelectedIndex == -1)
            {
                MessageBox.Show("Mom you gotta select a player.");
            }

            // make sure all of the info needed is entered in. If not tell MOM. Dont need check number unless check is used.
            if (comboBoxSelectPayReceive.Text == "")
            {
                MessageBox.Show("Mom you gotta select whether this is pay or receive money.");
                return;
            }
            else if (upDownAmount.Value <= 0.00m)
            {
                MessageBox.Show("Mom you gotta enter an amount to give or receive.");
                return;
            }
            else if (comboBoxPayMethod.Text == "")
            {
                MessageBox.Show("Mom you gotta select a payment method. I really had to write all of this code in case you use it wrong. COME ON!");
                return;
            }

            // check if check selected and check number entered
            if (textBoxCheckNumber.Visible)
            {
                // if its not give her hell
                if (textBoxCheckNumber.Text == "")
                {
                    MessageBox.Show("Mom you gotta enter a check number. Why have the box if you don't wan't to enter a check number? I had to write like 30 lines of code just to make this work. If you select check but don't enter a check number what happens!!??");
                    return;
                }
            }

            SubmitAccounting(comboBoxSelectPayReceive.Text);
            textBoxSearchPlayer.Clear();
            textBoxSearchPlayer.Focus();
        }

        // the payment method combo box
        private void comboBoxPayMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if she selects check then enable the check number box
            if (comboBoxPayMethod.SelectedItem.ToString() == "Check")
            {
                textBoxCheckNumber.Clear();
                textBoxCheckNumber.Visible = true;
                labelCheckNumber.Visible = true;
            }
            // if not then dont
            else
            {
                textBoxCheckNumber.Visible = false;
                labelCheckNumber.Visible = false;
            }
        }

        private void buttonViewMasterAccounting_Click(object sender, EventArgs e)
        {
            // check to see if the form is open
            if ((Application.OpenForms["FormMasterAccounting"] as FormMasterAccounting) != null)
            {
                // if it is then select the right form
                foreach (Form form in Application.OpenForms)
                {
                    if (form.Name == "FormMasterAccounting")
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
                FormMasterAccounting formMasterAccounting = new FormMasterAccounting();
                formMasterAccounting.Show();
            }
        }

        private void SubmitAccounting(string payReceive)
        {
            this.playersTableAdapter.Fill(this.playersDBDataSet.Players);
            this.transactionsTableAdapter.Fill(this.transactionsDBDataSet.Transactions);
            this.accountingTableAdapter.Fill(this.accountingDataSet.Accounting);

            // make sure a player is selected
            if (listBoxPlayersList.SelectedIndex == -1)
            {
                MessageBox.Show("Mom you gotta select a player first.");
                return;
            }

            // make sure it is the right season
            foreach (AccountingDataSet.AccountingRow accountingSeason in accountingDataSet.Accounting)
            {
                // if it matches the current season then continue
                if (accountingSeason.SeasonName == textBoxSelectedSeason.Text)
                {
                    // lets find the player first
                    foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                    {
                        // if the player name matches the selected player
                        if (player.PlayerPoolName == listBoxPlayersList.SelectedItem.ToString())
                        {
                            // if we are paying
                            if (payReceive == "Pay Out")
                            {
                                // adjust the players database
                                player.PlayerTotalWinnings += upDownAmount.Value;
                                player.WeOWePlayer -= upDownAmount.Value;
                                GetWeekForWinnings(player);

                                // transaction
                                NewTransaction(player);

                                // accounting part
                                accountingSeason.TotalFunds -= upDownAmount.Value;
                                accountingSeason.TotalPayedOut += upDownAmount.Value;
                                accountingSeason.TotalWeOweOut -= upDownAmount.Value;

                                // update the databases
                                this.Validate();
                                this.accountingBindingSource.EndEdit();
                                this.playersBindingSource.EndEdit();
                                this.tableAdapterManager1.UpdateAll(this.playersDBDataSet);
                                this.tableAdapterManager.UpdateAll(this.accountingDataSet);
                            }

                            // if we are receiving
                            if (payReceive == "Receive Payment")
                            {
                                // player first
                                player.PlayerOwes -= upDownAmount.Value;
                                // make them active
                                if (player.IsActive == false)
                                {
                                    player.IsActive = true;
                                }

                                // transaction
                                NewTransaction(player);

                                // accounting
                                accountingSeason.TotalFunds += upDownAmount.Value;
                                accountingSeason.TotalOwedToUs -= upDownAmount.Value;
                                if (accountingSeason.TotalOwedToUs <= 0)
                                {
                                    accountingSeason.TotalOwedToUs = 0;
                                }

                                // update the databases
                                this.Validate();
                                this.accountingBindingSource.EndEdit();
                                this.playersBindingSource.EndEdit();
                                this.tableAdapterManager1.UpdateAll(this.playersDBDataSet);
                                this.tableAdapterManager.UpdateAll(this.accountingDataSet);
                            }

                            // if we are charging a player
                            if (payReceive == "Charge")
                            {
                                // increase the amount player owes us
                                player.PlayerOwes += upDownAmount.Value;

                                // raise the amount owed to us
                                accountingSeason.TotalOwedToUs += upDownAmount.Value;

                                // transaction
                                NewTransaction(player);

                                comboBoxPayMethod.SelectedText = "Generic Charge";

                                // update the databases
                                this.Validate();
                                this.accountingBindingSource.EndEdit();
                                this.playersBindingSource.EndEdit();
                                this.tableAdapterManager1.UpdateAll(this.playersDBDataSet);
                                this.tableAdapterManager.UpdateAll(this.accountingDataSet);
                            }

                            if (payReceive == "Credit")
                            {
                                player.PlayerOwes -= upDownAmount.Value;

                                NewTransaction(player);

                                comboBoxPayMethod.SelectedText = "Generic Credit";

                                // update the databases
                                this.Validate();
                                this.accountingBindingSource.EndEdit();
                                this.playersBindingSource.EndEdit();
                                this.tableAdapterManager1.UpdateAll(this.playersDBDataSet);
                                this.tableAdapterManager.UpdateAll(this.accountingDataSet);
                            }

                            if (payReceive == "Initial Payment")
                            {
                                player.PlayerOwes -= upDownAmount.Value;
                                if (player.IsActive == false)
                                {
                                    player.IsActive = true;
                                }

                                accountingSeason.TotalOwedToUs -= upDownAmount.Value;

                                accountingSeason.TotalFunds += upDownAmount.Value - 3;

                                accountingSeason.TotalInterest += 3;

                                NewTransactionInitialPayment(player);

                                // update the databases
                                this.Validate();
                                this.accountingBindingSource.EndEdit();
                                this.playersBindingSource.EndEdit();
                                this.tableAdapterManager1.UpdateAll(this.playersDBDataSet);
                                this.tableAdapterManager.UpdateAll(this.accountingDataSet);
                            }

                            if (payReceive == "Charge/Receive")
                            {
                                if (player.IsActive == false)
                                {
                                    player.IsActive = true;
                                }

                                NewTransactionChargeReceive(player);

                                this.Validate();
                                this.accountingBindingSource.EndEdit();
                                this.playersBindingSource.EndEdit();
                                this.tableAdapterManager1.UpdateAll(this.playersDBDataSet);
                                this.tableAdapterManager.UpdateAll(this.accountingDataSet);

                            }
                        }
                    }

                    // then update the text boxes
                    TotalOwingWindows();
                    UpdateTotals();

                    MessageBox.Show("Submit Accounting Successful.");
                    listBoxPlayersList.SelectedIndex = -1;
                    textBoxCheckNumber.Text = "";
                }
            }
        }

        private void GetWeekForWinnings(PlayersDBDataSet.PlayersRow player)
        {
            // need to find out which week is selected and select the right weekly winnings for player
            if (comboBoxSelectWeek.Text == "Week 01")
            {
                player.PlayerWinningsWeek01 += (int)upDownAmount.Value;
            }
            if (comboBoxSelectWeek.Text == "Week 02")
            {
                player.PlayerWinningsWeek02 += (int)upDownAmount.Value;
            }
            if (comboBoxSelectWeek.Text == "Week 03")
            {
                player.PlayerWinningsWeek03 += (int)upDownAmount.Value;
            }
            if (comboBoxSelectWeek.Text == "Week 04")
            {
                player.PlayerWinningsWeek04 += (int)upDownAmount.Value;
            }
            if (comboBoxSelectWeek.Text == "Week 05")
            {
                player.PlayerWinningsWeek05 += (int)upDownAmount.Value;
            }
            if (comboBoxSelectWeek.Text == "Week 06")
            {
                player.PlayerWinningsWeek06 += (int)upDownAmount.Value;
            }
            if (comboBoxSelectWeek.Text == "Week 07")
            {
                player.PlayerWinningsWeek07 += (int)upDownAmount.Value;
            }
            if (comboBoxSelectWeek.Text == "Week 08")
            {
                player.PlayerWinningsWeek08 += (int)upDownAmount.Value;
            }
            if (comboBoxSelectWeek.Text == "Week 09")
            {
                player.PlayerWinningsWeek09 += (int)upDownAmount.Value;
            }
            if (comboBoxSelectWeek.Text == "Week 10")
            {
                player.PlayerWinningsWeek10 += (int)upDownAmount.Value;
            }
            if (comboBoxSelectWeek.Text == "Week 11")
            {
                player.PlayerWinningsWeek11 += (int)upDownAmount.Value;
            }
            if (comboBoxSelectWeek.Text == "Week 12")
            {
                player.PlayerWinningsWeek12 += (int)upDownAmount.Value;
            }
            if (comboBoxSelectWeek.Text == "Week 13")
            {
                player.PlayerWinningsWeek13 += (int)upDownAmount.Value;
            }
            if (comboBoxSelectWeek.Text == "Week 14")
            {
                player.PlayerWinningsWeek14 += (int)upDownAmount.Value;
            }
            if (comboBoxSelectWeek.Text == "Week 15")
            {
                player.PlayerWinningsWeek15 += (int)upDownAmount.Value;
            }
            if (comboBoxSelectWeek.Text == "Week 16")
            {
                player.PlayerWinningsWeek16 += (int)upDownAmount.Value;
            }
            if (comboBoxSelectWeek.Text == "Week 17")
            {
                player.PlayerWinningsWeek17 += (int)upDownAmount.Value;
            }
        }

        private void listBoxPlayersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if a different player is selected then find their preferred pay method.

            // to show the player preferred payout method
            if (listBoxPlayersList.SelectedIndex != -1)
            {
                // find the selected player
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    // if it is the selected player
                    if (player.PlayerPoolName == listBoxPlayersList.SelectedItem.ToString())
                    {
                        // show their preferred method
                        textBoxPreferredMethod.Text = player.PlayerPayoutMethod;
                        textBoxPlayerNotes.Text = player.PlayerNotes;

                        PopulateTransactionWindow(player, comboBoxSelectPayReceive.Text);
                    }
                }
            }
        }

        private void comboBoxSelectPayReceive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSelectPayReceive.Text == "Pay Out")
            {
                labelPreferredMethod.Visible = true;
                textBoxPreferredMethod.Visible = true;

                // to show the player preferred payout method
                if (listBoxPlayersList.SelectedIndex != -1)
                {
                    // find the selected player
                    foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                    {
                        // if it is the selected player
                        if (player.PlayerPoolName == listBoxPlayersList.SelectedItem.ToString())
                        {
                            // show their preferred method
                            textBoxPreferredMethod.Text = player.PlayerPayoutMethod;
                        }
                    }
                }
            }

            if (comboBoxSelectPayReceive.Text != "Pay Out")
            {
                labelPreferredMethod.Visible = false;
                textBoxPreferredMethod.Visible = false;
            }

            if (listBoxPlayersList.SelectedIndex != -1)
            {
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    if (player.PlayerPoolName == listBoxPlayersList.SelectedItem.ToString())
                    {
                        PopulateTransactionWindow(player, comboBoxSelectPayReceive.Text);
                    }
                }
            }

            if (comboBoxSelectPayReceive.Text == "Charge/Receive")
            {
                labelAmount.Text = "Charge Amount";
                upDownReceiveAmount.Visible = true;
                labelReceiveAmount.Visible = true;
            }
            else
            {
                labelAmount.Text = "Amount";
                upDownReceiveAmount.Visible = false;
                labelReceiveAmount.Visible = false;
            }
        }

        private void OpenTransactionDetailsWindow()
        {
            foreach (TransactionsDBDataSet.TransactionsRow selectedTransaction in transactionsDBDataSet.Transactions)
            {
                if (selectedTransaction.Id.ToString() == listViewTransactionWindow.FocusedItem.Text)
                {
                    PublicVariables.PublicTransactionId = selectedTransaction.Id;
                }
            }

            // check to see if the form is open
            if ((Application.OpenForms["FormTransactionDetails"] as FormTransactionDetails) != null)
            {
                // if it is then select the right form
                foreach (Form form in Application.OpenForms)
                {
                    if (form.Name == "FormTransactionDetails")
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
                FormTransactionDetails formTransactionDetails = new FormTransactionDetails();
                formTransactionDetails.Show();
            }

        }

        private void textBoxSearchPlayer_TextChanged_1(object sender, EventArgs e)
        {
            // found the Cast<string>.ToArray() basically it creates an array so I can edit it without
            // screwing up the foreach loop. Makes a copy of the list of names in the listbox.
            // then i can remove the name but the listbox items arent really affected.
            foreach (string removeString in listBoxPlayersList.Items.Cast<string>().ToArray())
            {
                // if any of the player names dont match the text then remove them.
                if (!removeString.StartsWith(textBoxSearchPlayer.Text, StringComparison.CurrentCultureIgnoreCase))
                {
                    listBoxPlayersList.Items.Remove(removeString);

                    // if no names match the search text then reset the list and post the message.
                    if (listBoxPlayersList.Items.Count == 0)
                    {
                        UpdatePlayerList();
                        MessageBox.Show("No players found.");
                    }

                    // so if there is only one player left after searching select him
                    if (listBoxPlayersList.Items.Count == 1)
                    {
                        listBoxPlayersList.SelectedIndex = 0;
                    }
                }
                // if it does match then go back and continue the foreach loop. So it removes the ones not matching
                // and doesnt stop.
                else if (removeString.StartsWith(textBoxSearchPlayer.Text, StringComparison.CurrentCultureIgnoreCase))
                {
                    continue;
                }
            }

            // reset the player list if the search box is cleared out.
            if (textBoxSearchPlayer.Text == "")
            {
                UpdatePlayerList();
            }
        }

        private void buttonChargeAllBuyIn_Click(object sender, EventArgs e)
        {
            int chargeCount = 0;
            int chargeTotal = 0;

            var confirmChargeBuyIns = MessageBox.Show("This will charge all players by thier buy in amount. Are you sure?", "Confirm Charge All", MessageBoxButtons.YesNo);

            if (confirmChargeBuyIns == DialogResult.Yes)
            {
                // make sure it is the right season
                foreach (AccountingDataSet.AccountingRow accountingSeason in accountingDataSet.Accounting)
                {
                    // if it matches the current season then continue
                    if (accountingSeason.SeasonName == textBoxSelectedSeason.Text)
                    {
                        // charge buy in amount for each player
                        foreach (PlayersDBDataSet.PlayersRow players in playersDBDataSet.Players)
                        {
                            if (players.PlayerBuyIn != 0)
                            {
                                chargeCount++;
                            }

                            chargeTotal += (int)players.PlayerBuyIn;

                            players.PlayerOwes += players.PlayerBuyIn;

                            // add to accounting
                            accountingSeason.TotalOwedToUs += players.PlayerOwes;

                            // add the transactions                 
                            ChargeAllBuyInsTransaction(players);
                        }
                    }
                    // update labels and windows
                    TotalOwingWindows();
                    UpdateTotals();

                    MessageBox.Show("Total Charges: " + chargeCount.ToString() + Environment.NewLine + "Total Amount Charged: " + chargeTotal.ToString());
                }
            }
            else
            {
                MessageBox.Show("Charge all buy ins cancelled.");
            }

            // update the databases
            this.Validate();
            this.accountingBindingSource.EndEdit();
            this.playersBindingSource.EndEdit();
            this.tableAdapterManager1.UpdateAll(this.playersDBDataSet);
            this.tableAdapterManager.UpdateAll(this.accountingDataSet);
        }

        private void buttonGroups_Click(object sender, EventArgs e)
        {
            // check to see if the form is open
            if ((Application.OpenForms["FormGroups"] as FormGroups) != null)
            {
                // if it is then select the right form
                foreach (Form form in Application.OpenForms)
                {
                    if (form.Name == "FormGroups")
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
                FormGroups formGroups = new FormGroups();
                formGroups.Show();
            }
        }

        private void NewTransaction(PlayersDBDataSet.PlayersRow selectedPlayer)
        {
            // create a new row
            TransactionsDBDataSet.TransactionsRow newTransaction = transactionsDBDataSet.Transactions.NewTransactionsRow();

            // add the data to that row
            newTransaction.PlayerName = selectedPlayer.PlayerPoolName;
            newTransaction.SeasonName = textBoxSelectedSeason.Text;
            newTransaction.Type = comboBoxSelectPayReceive.Text;
            newTransaction.Method = comboBoxPayMethod.Text;
            if (comboBoxSelectPayReceive.Text == "Credit" || comboBoxSelectPayReceive.Text == "Receive Payment")
            {
                newTransaction.Amount = -(double)upDownAmount.Value;
            }
            else
            {
                newTransaction.Amount = (double)upDownAmount.Value;
            }
            newTransaction.Week = comboBoxSelectWeek.Text;
            newTransaction.Date = DateTime.Now.ToString();
            newTransaction.Notes = textBoxTransactionNotes.Text;

            if (comboBoxPayMethod.Text == "Check")
            {
                newTransaction.CheckNumber = textBoxCheckNumber.Text;
            }

            transactionsDBDataSet.Transactions.Rows.Add(newTransaction);

            this.Validate();
            this.transactionsBindingSource.EndEdit();
            this.tableAdapterManager3.UpdateAll(this.transactionsDBDataSet);
        }

        private void PayAllTransaction(PlayersDBDataSet.PlayersRow selectedPlayer, double amount)
        {
            // create a new row
            TransactionsDBDataSet.TransactionsRow newTransaction = transactionsDBDataSet.Transactions.NewTransactionsRow();

            // add the data to that row
            newTransaction.PlayerName = selectedPlayer.PlayerPoolName;
            newTransaction.SeasonName = textBoxSelectedSeason.Text;
            newTransaction.Type = "Pay Out";
            newTransaction.Method = "Winner Pay Out";
            newTransaction.Amount = amount * -1;
            newTransaction.Week = comboBoxSelectWeek.Text;
            newTransaction.Date = DateTime.Now.ToString();
            newTransaction.Notes = "Auto Payed All Winners";

            transactionsDBDataSet.Transactions.Rows.Add(newTransaction);

            this.Validate();
            this.transactionsBindingSource.EndEdit();
            this.tableAdapterManager3.UpdateAll(this.transactionsDBDataSet);
        }

        private void NewTransactionInitialPayment(PlayersDBDataSet.PlayersRow selectedPlayer)
        {
            // create a new row
            TransactionsDBDataSet.TransactionsRow newTransaction1 = transactionsDBDataSet.Transactions.NewTransactionsRow();
            TransactionsDBDataSet.TransactionsRow newTransaction2 = transactionsDBDataSet.Transactions.NewTransactionsRow();

            // add the data to that row
            newTransaction1.PlayerName = selectedPlayer.PlayerPoolName;
            newTransaction1.SeasonName = textBoxSelectedSeason.Text;
            newTransaction1.Type = comboBoxSelectPayReceive.Text;
            newTransaction1.Method = comboBoxPayMethod.Text;
            newTransaction1.Amount = -(double)upDownAmount.Value;
            newTransaction1.Week = comboBoxSelectWeek.Text;
            newTransaction1.Date = DateTime.Now.ToString();
            newTransaction1.Notes = textBoxTransactionNotes.Text;

            newTransaction2.PlayerName = "House";
            newTransaction2.SeasonName = textBoxSelectedSeason.Text;
            newTransaction2.Type = "Interest";
            newTransaction2.Method = comboBoxPayMethod.Text;
            newTransaction2.Interest = 3;
            newTransaction2.Week = comboBoxSelectWeek.Text;
            newTransaction2.Date = DateTime.Now.ToString();
            newTransaction2.Notes = selectedPlayer.PlayerPoolName;

            if (comboBoxPayMethod.Text == "Check")
            {
                newTransaction1.CheckNumber = textBoxCheckNumber.Text;
                newTransaction2.CheckNumber = textBoxCheckNumber.Text;
            }

            transactionsDBDataSet.Transactions.Rows.Add(newTransaction1);
            transactionsDBDataSet.Transactions.Rows.Add(newTransaction2);

            this.Validate();
            this.transactionsBindingSource.EndEdit();
            this.tableAdapterManager3.UpdateAll(this.transactionsDBDataSet);
        }

        private void NewTransactionChargeReceive(PlayersDBDataSet.PlayersRow selectedPlayer)
        {
            // create a new row
            TransactionsDBDataSet.TransactionsRow newTransaction1 = transactionsDBDataSet.Transactions.NewTransactionsRow();
            TransactionsDBDataSet.TransactionsRow newTransaction2 = transactionsDBDataSet.Transactions.NewTransactionsRow();
            TransactionsDBDataSet.TransactionsRow newTransaction3 = transactionsDBDataSet.Transactions.NewTransactionsRow();

            // add the data to that row
            newTransaction1.PlayerName = selectedPlayer.PlayerPoolName;
            newTransaction1.SeasonName = textBoxSelectedSeason.Text;
            newTransaction1.Type = "Initial Payment";
            newTransaction1.Method = comboBoxPayMethod.Text;
            newTransaction1.Amount = -(double)upDownReceiveAmount.Value;
            newTransaction1.Week = comboBoxSelectWeek.Text;
            newTransaction1.Date = DateTime.Now.ToString();
            newTransaction1.Notes = textBoxTransactionNotes.Text;

            newTransaction2.PlayerName = "House";
            newTransaction2.SeasonName = textBoxSelectedSeason.Text;
            newTransaction2.Type = "Interest";
            newTransaction2.Method = comboBoxPayMethod.Text;
            newTransaction2.Interest = 3;
            newTransaction2.Week = comboBoxSelectWeek.Text;
            newTransaction2.Date = DateTime.Now.ToString();
            newTransaction2.Notes = selectedPlayer.PlayerPoolName;

            newTransaction3.PlayerName = selectedPlayer.PlayerPoolName;
            newTransaction3.SeasonName = textBoxSelectedSeason.Text;
            newTransaction3.Type = "Charge";
            newTransaction3.Method = comboBoxPayMethod.Text;
            newTransaction3.Amount = (double)upDownAmount.Value;
            newTransaction3.Week = comboBoxSelectWeek.Text;
            newTransaction3.Date = DateTime.Now.ToString();
            newTransaction3.Notes = textBoxTransactionNotes.Text;

            if (comboBoxPayMethod.Text == "Check")
            {
                newTransaction1.CheckNumber = textBoxCheckNumber.Text;
                newTransaction2.CheckNumber = textBoxCheckNumber.Text;
                newTransaction3.CheckNumber = textBoxCheckNumber.Text;
            }

            transactionsDBDataSet.Transactions.Rows.Add(newTransaction1);
            transactionsDBDataSet.Transactions.Rows.Add(newTransaction2);
            transactionsDBDataSet.Transactions.Rows.Add(newTransaction3);

            this.Validate();
            this.transactionsBindingSource.EndEdit();
            this.tableAdapterManager3.UpdateAll(this.transactionsDBDataSet);
        }

        // special method for charging all of the buy ins. ComboBoxes will not have values in them. Manually entering the values here
        // charge all buy in is a special charge.
        private void ChargeAllBuyInsTransaction(PlayersDBDataSet.PlayersRow player)
        {
            TransactionsDBDataSet.TransactionsRow newTransaction = transactionsDBDataSet.Transactions.NewTransactionsRow();

            newTransaction.PlayerName = player.PlayerPoolName;
            newTransaction.SeasonName = textBoxSelectedSeason.Text;
            newTransaction.Type = "Charge";
            newTransaction.Method = "Buy in Charge";
            newTransaction.Amount = (double)player.PlayerOwes;
            newTransaction.Week = "Week 1";
            newTransaction.CheckNumber = "";
            newTransaction.Date = DateTime.Now.ToString();
            newTransaction.Notes = textBoxTransactionNotes.Text;

            transactionsDBDataSet.Transactions.Rows.Add(newTransaction);

            this.Validate();
            this.transactionsBindingSource.EndEdit();
            this.tableAdapterManager3.UpdateAll(this.transactionsDBDataSet);
        }

        private void buttonViewPlayerLedger_Click(object sender, EventArgs e)
        {
            if (listBoxPlayersList.SelectedIndex == -1)
            {
                MessageBox.Show("No player selected");
                return;
            }

            foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
            {
                if (player.PlayerPoolName == listBoxPlayersList.SelectedItem.ToString())
                {
                    PublicVariables.PlayerPublicLedger = player;

                    // open the ledger form
                    // check to see if the form is open
                    if ((Application.OpenForms["FormPlayerLedger"] as FormPlayerLedger) != null)
                    {
                        // if it is then select the right form
                        foreach (Form form in Application.OpenForms)
                        {
                            if (form.Name == "FormPlayerLedger")
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
                        FormPlayerLedger formPlayerLedger = new FormPlayerLedger();
                        formPlayerLedger.Show();
                    }
                }
            }
        }

        private void PopulateTransactionWindow(PlayersDBDataSet.PlayersRow player, String transactionType)
        {
            // clear the window
            listViewTransactionWindow.Items.Clear();

            foreach (TransactionsDBDataSet.TransactionsRow transaction in transactionsDBDataSet.Transactions)
            {
                if (transaction.SeasonName == textBoxSelectedSeason.Text)
                {
                    if (transaction.Type == "Receive Payment" || transaction.Type == "Initial Payment")
                    {
                        if (transactionType == "Receive Payment" || transactionType == "Initial Payment" || transactionType == "Charge/Receive")
                        {
                            if (transaction.PlayerName == player.PlayerPoolName)
                            {
                                // create and populate a new row
                                ListViewItem newRow1 = new ListViewItem();

                                newRow1.Text = transaction.Id.ToString();
                                newRow1.SubItems.Add(transaction.Type);
                                newRow1.SubItems.Add(transaction.Amount.ToString());

                                listViewTransactionWindow.Items.Add(newRow1);
                            }
                        }
                        // if the transaction matches the player name and is the type of transaction selected
                        else if (transaction.PlayerName == player.PlayerPoolName && transaction.Type == transactionType)
                        {
                            // create and populate a new row
                            ListViewItem newRow = new ListViewItem();

                            newRow.Text = transaction.Id.ToString();
                            newRow.SubItems.Add(transaction.Type);
                            newRow.SubItems.Add(transaction.Amount.ToString());

                            listViewTransactionWindow.Items.Add(newRow);
                        }

                        else
                        {
                            continue;
                        }
                    }
                }
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            this.playersTableAdapter.Fill(this.playersDBDataSet.Players);
            this.accountingTableAdapter.Fill(this.accountingDataSet.Accounting);

            UpdatePlayerList();
            UpdateTotals();
            TotalOwingWindows();
        }

        private double CalculatePlayerBalance(PlayersDBDataSet.PlayersRow player)
        {
            double balance = 0;

            foreach (TransactionsDBDataSet.TransactionsRow transaction in transactionsDBDataSet.Transactions)
            {
                if (transaction.PlayerName == player.PlayerPoolName)
                {
                    if (transaction.Type == "Charge" || transaction.Type == "Pay Out")
                    {
                        balance += transaction.Amount;
                    }
                    if (transaction.Type == "Credit" || transaction.Type == "Receive Payment" || transaction.Type == "Initial Payment" || transaction.Type == "Win Credit")
                    {
                        balance += transaction.Amount;
                    }
                }
            }
            return balance;
        }

        private void buttonPayAll_Click(object sender, EventArgs e)
        {
            string confirmationList = "";
            int totalPlayersPayed = 0;
            int totalAmountPayed = 0;
            double playerBalance = 0;

            // make sure there is anything in the list
            if (listViewWhoWeOwe.Items.Count != 0)
            {
                var confirmPayAll = MessageBox.Show("This will pay out everyone in the list. Confirm?", "Confirm Pay All", MessageBoxButtons.YesNo);
                if (confirmPayAll == DialogResult.Yes)
                {
                    // go through each player
                    foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                    {
                        // compare each player to the players in the list
                        for (int i = 0; i < listViewWhoWeOwe.Items.Count; i++)
                        {
                            // if the player is in the list
                            if (listViewWhoWeOwe.Items[i].Text == player.PlayerPoolName)
                            {
                                // apply to their total winnings
                                playerBalance = CalculatePlayerBalance(player);
                                player.PlayerTotalWinnings += (decimal)playerBalance;

                                // remove from accounting
                                foreach (AccountingDataSet.AccountingRow accounting in accountingDataSet.Accounting)
                                {
                                    if (accounting.SeasonName == textBoxSelectedSeason.Text)
                                    {
                                        accounting.TotalFunds += (decimal)playerBalance;
                                        accounting.TotalWeOweOut += (decimal)playerBalance;
                                        accounting.TotalPayedOut += (decimal)playerBalance;
                                    }
                                }

                                // create message string
                                confirmationList += player.PlayerPoolName + " " + playerBalance + Environment.NewLine;
                                totalPlayersPayed++;
                                totalAmountPayed += (int)playerBalance;

                                PayAllTransaction(player, playerBalance);

                                //no longer owe player
                                player.WeOWePlayer = 0;

                                // update the databases
                                this.Validate();
                                this.accountingBindingSource.EndEdit();
                                this.playersBindingSource.EndEdit();
                                this.tableAdapterManager1.UpdateAll(this.playersDBDataSet);
                                this.tableAdapterManager.UpdateAll(this.accountingDataSet);
                            }
                        }
                    }

                    // refresh labels and windows
                    TotalOwingWindows();
                    UpdateTotals();
                    // display the message
                    MessageBox.Show(confirmationList + Environment.NewLine + "Total Players Paid: " + totalPlayersPayed.ToString() + Environment.NewLine + "Total Amount Paid: " + totalAmountPayed.ToString());
                }
                else
                {
                    // pay all cancelled
                    MessageBox.Show("Pay All cancelled");
                }
            }
            else
            {
                // no players in the list
                MessageBox.Show("No players in the list to pay.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // open the ledger form
            // check to see if the form is open
            if ((Application.OpenForms["FormHouseLedger"] as FormHouseLedger) != null)
            {
                // if it is then select the right form
                foreach (Form form in Application.OpenForms)
                {
                    if (form.Name == "FormHouseLedger")
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
                FormHouseLedger formHouseLedger = new FormHouseLedger();
                formHouseLedger.Show();
            }
        }

        private void buttonFixTransactions_Click(object sender, EventArgs e)
        {
            foreach (TransactionsDBDataSet.TransactionsRow transaction in transactionsDBDataSet.Transactions)
            {
                if (transaction.Type == "Initial Payment" || transaction.Type == "Credit" || transaction.Type == "Receive Payment" || transaction.Type == "Win Credit" || transaction.Type == "Generic Credit")
                {
                    if (transaction.Method != "REVERSED")
                    {
                        if (transaction.Type == "Initial Payment")
                        {
                            transaction.Amount += 3;
                            transaction.Amount *= -1;
                        }
                        else
                        {
                            transaction.Amount *= -1;
                        }
                    }
                    if (transaction.Method == "REVERSED" && transaction.Type == "Charge" || transaction.Type == "Generic Charge" || transaction.Type == "Buy in Charge")
                    {
                        transaction.Amount *= -1;
                    }
                }
            }

            this.Validate();
            this.transactionsBindingSource.EndEdit();
            this.tableAdapterManager3.UpdateAll(this.transactionsDBDataSet);

            MessageBox.Show("Completed. Close accounting window to refresh.");
        }

        private void buttonPayProgressive_Click(object sender, EventArgs e)
        {
            foreach (SeasonsDBDataSet.Seasons11_17Row season17 in seasonsDBDataSet.Seasons11_17)
            {
                if (season17.SeasonName == PublicVariables.GetDefaultSeason)
                {
                    if (season17.Week17IsFinal)
                    {
                        // open the ledger form
                        // check to see if the form is open
                        if ((Application.OpenForms["FormProgressive"] as FormProgressive) != null)
                        {
                            // if it is then select the right form
                            foreach (Form form in Application.OpenForms)
                            {
                                if (form.Name == "FormProgressive")
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
                            FormProgressive formProgressive = new FormProgressive();
                            formProgressive.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Week 17 needs to be final first.");
                    }
                }
            }
        }
    }
}
