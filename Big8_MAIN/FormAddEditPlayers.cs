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
    public partial class FormAddEditPlayers : Form
    {
        public FormAddEditPlayers()
        {
            InitializeComponent();

            //this.FormClosing += FormAddEditPlayers_FormClosing;

            // get the current season
            if (PublicVariables.GetDefaultSeason != null)
            {
                textBoxSelectedSeason.Text = PublicVariables.GetDefaultSeason;
            }

            upDownBuyInAmount.Enter += upDownBuyInAmount_Enter;
            upDownWins.Enter += upDownWins_Enter;
            upDownCurrentWinnings.Enter += upDownCurrentWinnings_Enter;
            this.KeyDown += new KeyEventHandler(FormAddEditPlayers_KeyDown);
        }

        // if enter is pressed it will go to the next box
        private void FormAddEditPlayers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void upDownBuyInAmount_Enter(object sender, EventArgs e)
        {
            upDownBuyInAmount.Select(0, upDownBuyInAmount.Text.Length);
        }

        private void upDownWins_Enter(object sender, EventArgs e)
        {
            upDownWins.Select(0, upDownWins.Text.Length);
        }

        private void upDownCurrentWinnings_Enter(object sender, EventArgs e)
        {
            upDownCurrentWinnings.Select(0, upDownCurrentWinnings.Text.Length);
        }

        // button to add the player. Makes sure mom enters a name first.
        private void buttonAddCurrentPlayerAdd_Click(object sender, EventArgs e)
        {
            if (textBoxPoolNameAdd.Text == "")
            {
                MessageBox.Show("You must enter a Pool Name MOM!");
                return;
            }
            else if (checkBoxReceivePayment.Checked && comboBoxPayMethod.Text == "")
            {
                MessageBox.Show("Select a payment method MOM!");
                return;
            }
            else if (checkBoxReceivePayment.Checked && comboBoxPayMethod.Text == "Check" && textBoxCheckNumber.Text == "")
            {
                MessageBox.Show("Enter a check number MOM!");
                return;
            }
            else
            {
                PostAccounting(textBoxPoolNameAdd.Text);
                AddPlayer();
                UpdatePlayerList();
                ClearForm();
                textBoxPoolNameAdd.Focus();
            }
        }

        /*
        private void FormAddEditPlayers_FormClosing(object sender, EventArgs e)
        {
            // check to see if the form is open
            if ((Application.OpenForms["FormPlayers"] as FormPlayers) != null)
            {
                // if it is then select the right form
                foreach (Form form in Application.OpenForms)
                {
                    if (form.Name == "FormPlayers")
                    {
                        // activate it
                        FormPlayers formPlayers = new FormPlayers();
                        formPlayers = form as FormPlayers;
                        formPlayers.UpdatePlayerList();
                        formPlayers.Activate();
                    }
                }
            }
            else
            {
                // otherwise create a new instance of the form and show it
                FormPlayers formPlayers = new FormPlayers();
                formPlayers.UpdatePlayerList();
                formPlayers.Show();
            }
        }
        */

        private void FormAddEditPlayers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'transactionsDBDataSet.Transactions' table. You can move, or remove it, as needed.
            this.transactionsTableAdapter.Fill(this.transactionsDBDataSet.Transactions);
            // TODO: This line of code loads data into the 'accountingDataSet.Accounting' table. You can move, or remove it, as needed.
            this.accountingTableAdapter.Fill(this.accountingDataSet.Accounting);
            // TODO: This line of code loads data into the 'playersDBDataSet.Players' table. You can move, or remove it, as needed.
            this.playersTableAdapter.Fill(this.playersDBDataSet.Players);
            UpdatePlayerList();

            // this is going to cause problems later on I need to clear the public player somehwere.
            if (PublicVariables.PublicPlayer != null)
            {
                UpdateForm(PublicVariables.PublicPlayer);
                PublicVariables.PublicPlayer = null;
            }
        }

        private void PostAccounting(string playerName)
        {
            // if there is a buy in amount entered the charge it
            if (upDownBuyInAmount.Value > 0)
            {
                TransactionsDBDataSet.TransactionsRow newTransaction = transactionsDBDataSet.Transactions.NewTransactionsRow();

                newTransaction.PlayerName = playerName;
                newTransaction.SeasonName = PublicVariables.GetDefaultSeason;
                newTransaction.Type = "Charge";
                newTransaction.Method = "Buy in Charge";
                newTransaction.Amount = (double)upDownBuyInAmount.Value;
                if (PublicVariables.GetDefaultWeek != null)
                {
                    newTransaction.Week = PublicVariables.GetDefaultWeek;
                }
                newTransaction.Date = DateTime.Now.ToString();
                newTransaction.Notes = "Charge created when adding player";

                transactionsDBDataSet.Transactions.Rows.Add(newTransaction);

            }

            // if there is a receive payment amount
            if (upDownReceiveAmount.Value > 0)
            {

                TransactionsDBDataSet.TransactionsRow newTransaction2 = transactionsDBDataSet.Transactions.NewTransactionsRow();
                TransactionsDBDataSet.TransactionsRow newTransaction3 = transactionsDBDataSet.Transactions.NewTransactionsRow();

                newTransaction2.PlayerName = playerName;
                
                newTransaction2.SeasonName = PublicVariables.GetDefaultSeason;
                newTransaction2.Type = "Receive Payment";
                newTransaction2.Method = comboBoxPayMethod.Text;
                if (comboBoxPayMethod.Text == "Check")
                {
                    newTransaction2.CheckNumber = textBoxCheckNumber.Text;
                }
                newTransaction2.Amount = -(double)upDownReceiveAmount.Value;
                if (PublicVariables.GetDefaultWeek != null)
                {
                    newTransaction2.Week = PublicVariables.GetDefaultWeek;
                }
                newTransaction2.Date = DateTime.Now.ToString();
                newTransaction2.Notes = "Receipt created when adding player";

               
                newTransaction3.PlayerName = "House";
                newTransaction3.SeasonName = textBoxSelectedSeason.Text;
                newTransaction3.Type = "Interest";
                newTransaction3.Method = comboBoxPayMethod.Text;
                newTransaction3.Interest = 3;
                if (PublicVariables.GetDefaultWeek != null)
                {
                    newTransaction3.Week = PublicVariables.GetDefaultWeek;
                }
                newTransaction3.Date = DateTime.Now.ToString();
                newTransaction3.Notes = playerName;

                transactionsDBDataSet.Transactions.Rows.Add(newTransaction2);
                transactionsDBDataSet.Transactions.Rows.Add(newTransaction3);

            }

            this.Validate();
            this.transactionsBindingSource.EndEdit();
            this.tableAdapterManager2.UpdateAll(this.transactionsDBDataSet);
        }

        private void AddPlayer()
        {
            // make sure a season is created before adding players.
            if (accountingDataSet.Accounting.Rows.Count == 0)
            {
                MessageBox.Show("Please create a Season before adding players.");
                return;
            }

            // try to create the new player
            try
            {
                PlayersDBDataSet.PlayersRow newPlayersDBRow = playersDBDataSet.Players.NewPlayersRow();

                // this is where the error will occur if there is a duplicate name.
                newPlayersDBRow.PlayerPoolName = textBoxPoolNameAdd.Text;

                newPlayersDBRow.PlayerBuyIn = upDownBuyInAmount.Value;
                newPlayersDBRow.PlayerTotalWins = upDownWins.Value;
                newPlayersDBRow.PlayerTotalWinnings = upDownCurrentWinnings.Value;

                if (checkBoxIsActive.Checked)
                {
                    newPlayersDBRow.IsActive = true;
                }
                else
                {
                    newPlayersDBRow.IsActive = false;
                }

                newPlayersDBRow.PlayerPersonalName = textBoxNameAdd.Text;
                newPlayersDBRow.PlayerAddress = textBoxAddressAdd.Text;
                newPlayersDBRow.PlayerEmail = textBoxEmailAdd.Text;
                newPlayersDBRow.PlayerPhone = textBoxPhoneAdd.Text;
                newPlayersDBRow.PlayerContactMethod = textBoxPreferContactAdd.Text;
                newPlayersDBRow.PlayerPayoutMethod = textBoxPreferPayoutAdd.Text;
                newPlayersDBRow.Notes = textBoxGroupName.Text;
                newPlayersDBRow.PlayerNotes = textBoxPlayerNotes.Text;

                // if group leader is checked then make them the group leader////////////////////////////*****
                if (checkBoxIsGroupLeader.Checked)
                {
                    newPlayersDBRow.IsGroupLeader = true;
                }
                else
                {
                    newPlayersDBRow.IsGroupLeader = false;
                }

                // Add the new row to the database
                playersDBDataSet.Players.Rows.Add(newPlayersDBRow);

                MessageBox.Show("Player " + newPlayersDBRow.PlayerPoolName + " has been added sucessfully.");
            }

            // this will catch the error above if the unique pool name is already in use.
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                textBoxPoolNameAdd.Enabled = true;
            }

            // save changes to the database
            this.Validate();
            this.playersBindingSource.EndEdit();
            this.accountingBindingSource.EndEdit();
            this.tableAdapterManager1.UpdateAll(this.accountingDataSet);
            this.tableAdapterManager.UpdateAll(this.playersDBDataSet);
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

        // just to clear the form after adding a player so you can add another quickly
        private void ClearForm()
        {
            textBoxPoolNameAdd.Clear();
            upDownBuyInAmount.Value = 0;
            upDownWins.Value = 0;
            upDownCurrentWinnings.Value = 0;
            textBoxNameAdd.Clear();
            textBoxAddressAdd.Clear();
            textBoxPhoneAdd.Clear();
            textBoxEmailAdd.Clear();
            textBoxPreferContactAdd.Clear();
            textBoxPreferPayoutAdd.Clear();
            textBoxGroupName.Clear();
            checkBoxIsGroupLeader.Checked = false;
            checkBoxIsActive.Checked = false;
            textBoxPlayerNotes.Clear();
            upDownReceiveAmount.Value = 0;
            comboBoxPayMethod.SelectedIndex = -1;
            textBoxCheckNumber.Text = "";
            checkBoxReceivePayment.Checked = false;
        }

        // update the form based on the player selected.
        private void listBoxPlayersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // as long as there is a selected player
            if (listBoxPlayersList.SelectedIndex != -1)
            {                
                // update the form based on the selected player. Goes off thier pool name.
                foreach (PlayersDBDataSet.PlayersRow selectedRow in playersDBDataSet.Players)
                {
                    if (this.listBoxPlayersList.SelectedItem.ToString() == selectedRow.PlayerPoolName)
                    {
                        UpdateForm(selectedRow);
                    }
                }
            }
            else
            {
                return;
            }
        }

        // update all of the labels on the form based on the selected player.
        private void UpdateForm(PlayersDBDataSet.PlayersRow selectedPlayer)
        {
            textBoxPoolNameAdd.Text = selectedPlayer.PlayerPoolName;
            upDownBuyInAmount.Value = selectedPlayer.PlayerBuyIn;
            upDownCurrentWinnings.Value = selectedPlayer.PlayerTotalWinnings;
            upDownWins.Value = selectedPlayer.PlayerTotalWins;
            textBoxNameAdd.Text = selectedPlayer.PlayerPersonalName;
            textBoxAddressAdd.Text = selectedPlayer.PlayerAddress;
            textBoxPhoneAdd.Text = selectedPlayer.PlayerPhone;
            textBoxEmailAdd.Text = selectedPlayer.PlayerEmail;
            textBoxPreferContactAdd.Text = selectedPlayer.PlayerContactMethod;
            textBoxPreferPayoutAdd.Text = selectedPlayer.PlayerPayoutMethod;
            textBoxGroupName.Text = selectedPlayer.Notes;
            textBoxPlayerNotes.Text = selectedPlayer.PlayerNotes;

            if (selectedPlayer.IsActive == true)
            {
                checkBoxIsActive.Checked = true;
            }
            else
            {
                checkBoxIsActive.Checked = false;
            }

            // if group leader is checked then make them the group leader///////////////////////*********
            
            if (selectedPlayer.IsGroupLeader == true)
            {
                checkBoxIsGroupLeader.Checked = true;
            }
            else
            {
                checkBoxIsGroupLeader.Checked = false;
            }
            

            // it kept filling the text boxes with empty strings. This was my solution. I hate it.
            textBoxPoolNameAdd.Text = textBoxPoolNameAdd.Text.Trim();
            textBoxNameAdd.Text = textBoxNameAdd.Text.Trim();
            textBoxPhoneAdd.Text = textBoxPhoneAdd.Text.Trim();
            textBoxEmailAdd.Text = textBoxEmailAdd.Text.Trim();
            textBoxPreferContactAdd.Text = textBoxPreferContactAdd.Text.Trim();
            textBoxPreferPayoutAdd.Text = textBoxPreferPayoutAdd.Text.Trim();
            textBoxAddressAdd.Text = textBoxAddressAdd.Text.Trim();
            textBoxGroupName.Text = textBoxGroupName.Text.Trim();
        }

        // clear the form and allow user to add a new player.
        private void buttonNewPlayer_Click(object sender, EventArgs e)
        {
            ClearForm();
            textBoxPoolNameAdd.Focus();
        }

        // changes the selected player
        private void buttonEditPlayerAdd_Click(object sender, EventArgs e)
        {
            EditPlayer();
            textBoxSearchPlayer.Clear();
            textBoxSearchPlayer.Focus();
        }

        // think i am just using the button to do the work.
        private void EditPlayer()
        {
            PlayersDBDataSet.PlayersRow selectedPlayer;

            if (listBoxPlayersList.SelectedItem == null)
            {
                MessageBox.Show("No player selected.");
                return;
            }
            foreach (PlayersDBDataSet.PlayersRow deleteRow in playersDBDataSet.Players.Rows)
            {
                // find the selected player
                if (deleteRow.PlayerPoolName == listBoxPlayersList.SelectedItem.ToString())
                {
                    try
                    {
                        // transfer that player to editPlayer so no garbage collection goes on.
                        PlayersDBDataSet.PlayersRow editPlayersDBRow = deleteRow;                        

                        if (editPlayersDBRow.PlayerPoolName != textBoxPoolNameAdd.Text)
                        {
                            foreach (TransactionsDBDataSet.TransactionsRow transaction in transactionsDBDataSet.Transactions)
                            {
                                if (editPlayersDBRow.PlayerPoolName == transaction.PlayerName)
                                {
                                    transaction.PlayerName = textBoxPoolNameAdd.Text;
                                }
                            }

                            this.Validate();
                            this.transactionsBindingSource.EndEdit();
                            this.tableAdapterManager2.UpdateAll(this.transactionsDBDataSet);
                        }

                        // this is where the error will occur if there is a duplicate name.
                        editPlayersDBRow.PlayerPoolName = textBoxPoolNameAdd.Text;
                        editPlayersDBRow.PlayerBuyIn = upDownBuyInAmount.Value;
                        editPlayersDBRow.PlayerTotalWins = upDownWins.Value;
                        editPlayersDBRow.PlayerTotalWinnings = upDownCurrentWinnings.Value;
                        editPlayersDBRow.PlayerPersonalName = textBoxNameAdd.Text;
                        editPlayersDBRow.PlayerAddress = textBoxAddressAdd.Text;
                        editPlayersDBRow.PlayerEmail = textBoxEmailAdd.Text;
                        editPlayersDBRow.PlayerPhone = textBoxPhoneAdd.Text;
                        editPlayersDBRow.PlayerContactMethod = textBoxPreferContactAdd.Text;
                        editPlayersDBRow.PlayerPayoutMethod = textBoxPreferPayoutAdd.Text;
                        editPlayersDBRow.Notes = textBoxGroupName.Text;

                        // if group leader is checked then make them the group leader/////////////////******
                        
                        if (checkBoxIsGroupLeader.Checked)
                        {
                            editPlayersDBRow.IsGroupLeader = true;
                        }
                        else
                        {
                            editPlayersDBRow.IsGroupLeader = false;
                        }

                        // check if they are active or not
                        if (checkBoxIsActive.Checked)
                        {
                            editPlayersDBRow.IsActive = true;
                        }
                        else
                        {
                            editPlayersDBRow.IsActive = false;
                        }

                        editPlayersDBRow.PlayerNotes = textBoxPlayerNotes.Text;

                        // this is in case during an edit a name gets changed. I can update the player list then reselect this player
                        selectedPlayer = editPlayersDBRow;

                        // save changes to the database
                        this.Validate();
                        this.playersBindingSource.EndEdit();
                        this.tableAdapterManager.UpdateAll(this.playersDBDataSet);
                        this.tableAdapterManager1.UpdateAll(this.accountingDataSet);
                        // update the list incase name got changed
                        UpdatePlayerList();

                        foreach (string items in listBoxPlayersList.SelectedItems)
                        {                         
                            if (items == selectedPlayer.PlayerPoolName)
                            {
                                listBoxPlayersList.SelectedItem = items;
                            }
                        }

                        // Add the new row to the database
                        // playersDBDataSet.Players.AcceptChanges();

                        MessageBox.Show("Player " + editPlayersDBRow.PlayerPoolName + " changes made sucessfully.");
                    }

            // this will catch the error above if the unique pool name is already in use.
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }                                     
                    //ClearForm(); << she did not want to clear the form after editing
                    // have to break because listboxSelectedItem goes null.
                    break;
                }
            }
        }

        private void DeletePlayer()
        {
            // make sure a player is selected
            if (listBoxPlayersList.SelectedItem == null)
            {
                MessageBox.Show("No player selected.");
                return;
            }

            // find the player to delete
            foreach (PlayersDBDataSet.PlayersRow deletePlayer in playersDBDataSet.Players)
            {
                // Just find them by matching pool name and selected player
                if (deletePlayer.PlayerPoolName == listBoxPlayersList.SelectedItem.ToString())
                {
                    deletePlayer.Delete();

                    this.Validate();
                    this.playersBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.playersDBDataSet);

                    // update list after deleting and clear the form
                    UpdatePlayerList();
                    ClearForm();
                    break;
                }
            }
        }

        private void buttonDeletePlayer_Click(object sender, EventArgs e)
        {
            // confirmation to delete the player
            var confirmDelete = MessageBox.Show("Are you sure you want to delete this player?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirmDelete == DialogResult.Yes)
            {
                DeletePlayer();
                MessageBox.Show("Player Deleted");
            }
            else
            {
                MessageBox.Show("Delete Player Canceled");
            }

            textBoxSearchPlayer.Focus();
        }

        private void textBoxSearchPlayer_TextChanged(object sender, EventArgs e)
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

        private void checkBoxReceivePayment_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxReceivePayment.Checked == true)
            {
                labelReceiveAmount.Visible = true;
                labelPaymentMethod.Visible = true;
                upDownReceiveAmount.Visible = true;
                comboBoxPayMethod.Visible = true;
            }
            else
            {
                labelReceiveAmount.Visible = false;
                labelPaymentMethod.Visible = false;
                upDownReceiveAmount.Visible = false;
                comboBoxPayMethod.Visible = false;
            }
        }

        private void comboBoxPayMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPayMethod.Text == "Check")
            {
                labelCheckNumber.Visible = true;
                textBoxCheckNumber.Visible = true;
            }
            else
            {
                labelCheckNumber.Visible = false;
                textBoxCheckNumber.Visible = false;
            }
        }
    }
}
