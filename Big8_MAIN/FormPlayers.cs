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
    public partial class FormPlayers : Form
    {
        public FormPlayers()
        {
            InitializeComponent();

            comboBoxSelectWeek.Text = PublicVariables.GetDefaultWeek;
        }

        private void buttonAddPlayer_Click(object sender, EventArgs e)
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

        //Not using this but saving for reference if i need it later.
        /*private void playersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.playersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.playersDBDataSet);

        }*/

        private void FormPlayers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'playersDBDataSet.Players' table. You can move, or remove it, as needed.
            this.playersTableAdapter.Fill(this.playersDBDataSet.Players);
            UpdatePlayerList();
            labelPlayerCurrentWinsLarge.Text = "0";
            labelPlayerNameLarge.Text = "";
            labelPlayerCurrentWinsLarge.Text = "0";
        }

        public void UpdatePlayerList()
        {
            // Clear the box and then repopulate it
            listBoxSelectPlayer.Items.Clear();

            // need to fill this forms database with the main database
            this.playersTableAdapter.Fill(this.playersDBDataSet.Players);

            // Add each player to the list
            foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
            {
                if (player.IsActive == true)
                {
                    listBoxSelectPlayer.Items.Add(player.PlayerPoolName);
                }
            }
        }

        private void UpdateForm(PlayersDBDataSet.PlayersRow selectedPlayer)
        {
           
            // update labels based on the selected player
            labelPlayerNameLarge.Text = selectedPlayer.PlayerPoolName;
            labelPlayerWinsLarge.Text = selectedPlayer.PlayerTotalWins.ToString();
            labelOweUsAmountPlayers.Text = selectedPlayer.PlayerOwes.ToString();
            labelOweThemAmountPlayers.Text = selectedPlayer.WeOWePlayer.ToString();

            BuildPicksListBox(selectedPlayer);

            // this finds the current wins based on which week it is
            WeeklyWins();

             
            //This will turn label red if that player is out green if they still in it.
            if (selectedPlayer.IsOut)
            {
                labelPlayerCurrentWinsLarge.BackColor = Color.Red;
            }
            else
            {
                labelPlayerCurrentWinsLarge.BackColor = Color.Green;
            }           
        }


        private void listBoxSelectPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if a player is slected
            if (listBoxSelectPlayer.SelectedIndex != -1)
            {
                // find that player in the database
                foreach (PlayersDBDataSet.PlayersRow selectedRow in playersDBDataSet.Players)
                {
                    if (this.listBoxSelectPlayer.SelectedItem.ToString() == selectedRow.PlayerPoolName)
                    {
                        // call the update form method to populate the form with the selected players info
                        UpdateForm(selectedRow);                       
                    }
                }
            }
            else
            {
                return;
            }
        }

        
        // could use in the future to update the entire form? Weekly wins and picks and such if i need too.
        private void buttonRefreshForm_Click(object sender, EventArgs e)
        {
            UpdatePlayerList();
        }

        // bring up the edit player window WITH the selected players info included
        private void buttonEditThisPlayer_Click(object sender, EventArgs e)
        {
            if (listBoxSelectPlayer.SelectedIndex != -1)
            {
                foreach (PlayersDBDataSet.PlayersRow selectedPlayer in playersDBDataSet.Players)
                {
                    if (this.listBoxSelectPlayer.SelectedItem.ToString() == selectedPlayer.PlayerPoolName)
                    {
                        PublicVariables.PublicPlayer = selectedPlayer;
                    }
                }
            }
            else
            {
                MessageBox.Show("No player was selected.");
                return;
            }

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

        private void GetPersonalInfo()
        {
            // make sure someone is selected
            if (listBoxSelectPlayer.SelectedItem == null)
            {
                MessageBox.Show("No player selected.");
                UpdatePlayerList();
                return;
            }

            // just for the personal info button so far.
            foreach (PlayersDBDataSet.PlayersRow getPersonalInfo in playersDBDataSet.Players)
            {
                // if the name matches then call DisplayInfo()
                if (listBoxSelectPlayer.SelectedItem.ToString() == getPersonalInfo.PlayerPoolName)
                {
                    DisplayInfo(getPersonalInfo);
                }
            }
        }

        // incase i need this somewhere else I wont have to type it again. Displays a players personal info.
        private void DisplayInfo(PlayersDBDataSet.PlayersRow playerInfo)
        {
            // wont always be a message box I need to export something useful to excel / word for use.
            MessageBox.Show("Player Pool Name: " + playerInfo.PlayerPoolName + "\n" + "Personal Name: " + playerInfo.PlayerPersonalName + "\n" + "Address: " + playerInfo.PlayerAddress +
                "\n" + "Phone: " + playerInfo.PlayerPhone + "\n" + "Email: " + playerInfo.PlayerEmail + "\n" + "Main Contact Method: " + playerInfo.PlayerContactMethod + "\n" + "Main Payout Method: " + playerInfo.PlayerPayoutMethod);
        }

        private void buttonMyPersonalInfo_Click(object sender, EventArgs e)
        {
            GetPersonalInfo();
        }

        // get this weeks wins to display on form
        private void WeeklyWins()
        {
            foreach (PlayersDBDataSet.PlayersRow selectedPlayer in playersDBDataSet.Players)
            {
                if (selectedPlayer.PlayerPoolName == listBoxSelectPlayer.SelectedItem.ToString())
                {
                    // this is for the large selected weeks label
                    if (comboBoxSelectWeek.Text == "Week 01")
                    {
                        labelPlayerCurrentWinsLarge.Text = selectedPlayer.WinsWeek01.ToString();
                    }
                    if (comboBoxSelectWeek.Text == "Week 02")
                    {
                        labelPlayerCurrentWinsLarge.Text = selectedPlayer.WinsWeek02.ToString();
                    }
                    if (comboBoxSelectWeek.Text == "Week 03")
                    {
                        labelPlayerCurrentWinsLarge.Text = selectedPlayer.WinsWeek03.ToString();
                    }
                    if (comboBoxSelectWeek.Text == "Week 04")
                    {
                        labelPlayerCurrentWinsLarge.Text = selectedPlayer.WinsWeek04.ToString();
                    }
                    if (comboBoxSelectWeek.Text == "Week 05")
                    {
                        labelPlayerCurrentWinsLarge.Text = selectedPlayer.WinsWeek05.ToString();
                    }
                    if (comboBoxSelectWeek.Text == "Week 06")
                    {
                        labelPlayerCurrentWinsLarge.Text = selectedPlayer.WinsWeek06.ToString();
                    }
                    if (comboBoxSelectWeek.Text == "Week 07")
                    {
                        labelPlayerCurrentWinsLarge.Text = selectedPlayer.WinsWeek07.ToString();
                    }
                    if (comboBoxSelectWeek.Text == "Week 08")
                    {
                        labelPlayerCurrentWinsLarge.Text = selectedPlayer.WinsWeek08.ToString();
                    }
                    if (comboBoxSelectWeek.Text == "Week 09")
                    {
                        labelPlayerCurrentWinsLarge.Text = selectedPlayer.WinsWeek09.ToString();
                    }
                    if (comboBoxSelectWeek.Text == "Week 10")
                    {
                        labelPlayerCurrentWinsLarge.Text = selectedPlayer.WinsWeek10.ToString();
                    }
                    if (comboBoxSelectWeek.Text == "Week 11")
                    {
                        labelPlayerCurrentWinsLarge.Text = selectedPlayer.WinsWeek11.ToString();
                    }
                    if (comboBoxSelectWeek.Text == "Week 12")
                    {
                        labelPlayerCurrentWinsLarge.Text = selectedPlayer.WinsWeek12.ToString();
                    }
                    if (comboBoxSelectWeek.Text == "Week 13")
                    {
                        labelPlayerCurrentWinsLarge.Text = selectedPlayer.WinsWeek13.ToString();
                    }
                    if (comboBoxSelectWeek.Text == "Week 14")
                    {
                        labelPlayerCurrentWinsLarge.Text = selectedPlayer.WinsWeek14.ToString();
                    }
                    if (comboBoxSelectWeek.Text == "Week 15")
                    {
                        labelPlayerCurrentWinsLarge.Text = selectedPlayer.WinsWeek15.ToString();
                    }
                    if (comboBoxSelectWeek.Text == "Week 16")
                    {
                        labelPlayerCurrentWinsLarge.Text = selectedPlayer.WinsWeek16.ToString();
                    }
                    if (comboBoxSelectWeek.Text == "Week 17")
                    {
                        labelPlayerCurrentWinsLarge.Text = selectedPlayer.WinsWeek17.ToString();
                    }

                    // this is for how many wins they have each week listed on bottom left
                    labelPlayerWinsWeek01Players.Text = "W" + selectedPlayer.WinsWeek01.ToString();
                    labelPlayerWinsWeek02Players.Text = "W" + selectedPlayer.WinsWeek02.ToString();
                    labelPlayerWinsWeek03Players.Text = "W" + selectedPlayer.WinsWeek03.ToString();
                    labelPlayerWinsWeek04Players.Text = "W" + selectedPlayer.WinsWeek04.ToString();
                    labelPlayerWinsWeek05Players.Text = "W" + selectedPlayer.WinsWeek05.ToString();
                    labelPlayerWinsWeek06Players.Text = "W" + selectedPlayer.WinsWeek06.ToString();
                    labelPlayerWinsWeek07Players.Text = "W" + selectedPlayer.WinsWeek07.ToString();
                    labelPlayerWinsWeek08Players.Text = "W" + selectedPlayer.WinsWeek08.ToString();
                    labelPlayerWinsWeek09Players.Text = "W" + selectedPlayer.WinsWeek09.ToString();
                    labelPlayerWinsWeek10Players.Text = "W" + selectedPlayer.WinsWeek10.ToString();
                    labelPlayerWinsWeek11Players.Text = "W" + selectedPlayer.WinsWeek11.ToString();
                    labelPlayerWinsWeek12Players.Text = "W" + selectedPlayer.WinsWeek12.ToString();
                    labelPlayerWinsWeek13Players.Text = "W" + selectedPlayer.WinsWeek13.ToString();
                    labelPlayerWinsWeek14Players.Text = "W" + selectedPlayer.WinsWeek14.ToString();
                    labelPlayerWinsWeek15Players.Text = "W" + selectedPlayer.WinsWeek15.ToString();
                    labelPlayerWinsWeek16Players.Text = "W" + selectedPlayer.WinsWeek16.ToString();
                    labelPlayerWinsWeek17Players.Text = "W" + selectedPlayer.WinsWeek17.ToString();

                    labelMoneyWeek01Players.Text = "$" + selectedPlayer.PlayerWinningsWeek01.ToString();
                    labelMoneyWeek02Players.Text = "$" + selectedPlayer.PlayerWinningsWeek02.ToString();
                    labelMoneyWeek03Players.Text = "$" + selectedPlayer.PlayerWinningsWeek03.ToString();
                    labelMoneyWeek04Players.Text = "$" + selectedPlayer.PlayerWinningsWeek04.ToString();
                    labelMoneyWeek05Players.Text = "$" + selectedPlayer.PlayerWinningsWeek05.ToString();
                    labelMoneyWeek06Players.Text = "$" + selectedPlayer.PlayerWinningsWeek06.ToString();
                    labelMoneyWeek07Players.Text = "$" + selectedPlayer.PlayerWinningsWeek07.ToString();
                    labelMoneyWeek08Players.Text = "$" + selectedPlayer.PlayerWinningsWeek08.ToString();
                    labelMoneyWeek09Players.Text = "$" + selectedPlayer.PlayerWinningsWeek09.ToString();
                    labelMoneyWeek10Players.Text = "$" + selectedPlayer.PlayerWinningsWeek10.ToString();
                    labelMoneyWeek11Players.Text = "$" + selectedPlayer.PlayerWinningsWeek11.ToString();
                    labelMoneyWeek12Players.Text = "$" + selectedPlayer.PlayerWinningsWeek12.ToString();
                    labelMoneyWeek13Players.Text = "$" + selectedPlayer.PlayerWinningsWeek13.ToString();
                    labelMoneyWeek14Players.Text = "$" + selectedPlayer.PlayerWinningsWeek14.ToString();
                    labelMoneyWeek15Players.Text = "$" + selectedPlayer.PlayerWinningsWeek15.ToString();
                    labelMoneyWeek16Players.Text = "$" + selectedPlayer.PlayerWinningsWeek16.ToString();
                    labelMoneyWeek17Players.Text = "$" + selectedPlayer.PlayerWinningsWeek17.ToString();
                }
            }
        }

        private void textBoxSearchPlayerPlayers_TextChanged(object sender, EventArgs e)
        {
            // found the Cast<string>.ToArray() basically it creates an array so I can edit it without
            // screwing up the foreach loop. Makes a copy of the list of names in the listbox.
            // then i can remove the name but the listbox items arent really affected.
            foreach (string removeString in listBoxSelectPlayer.Items.Cast<string>().ToArray())
            {
                // if any of the player names dont match the text then remove them.
                if (!removeString.StartsWith(textBoxSearchPlayerPlayers.Text, StringComparison.CurrentCultureIgnoreCase))
                {
                    listBoxSelectPlayer.Items.Remove(removeString);

                    // if no names match the search text then reset the list and post the message.
                    if (listBoxSelectPlayer.Items.Count == 0)
                    {
                        UpdatePlayerList();
                        MessageBox.Show("No players found.");
                    }

                    // so if there is only one player left after searching select him
                    if (listBoxSelectPlayer.Items.Count == 1)
                    {
                        listBoxSelectPlayer.SelectedIndex = 0;
                    }
                }
                // if it does match then go back and continue the foreach loop. So it removes the ones not matching
                // and doesnt stop.
                else if (removeString.StartsWith(textBoxSearchPlayerPlayers.Text, StringComparison.CurrentCultureIgnoreCase))
                {
                    continue;
                }
            }

            // reset the player list if the search box is cleared out.
            if (textBoxSearchPlayerPlayers.Text == "")
            {
                UpdatePlayerList();
            }
        }

        private void comboBoxSelectWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (PlayersDBDataSet.PlayersRow selectedPlayer in playersDBDataSet.Players)
            {
                if (listBoxSelectPlayer.SelectedIndex != -1)
                {
                    if (selectedPlayer.PlayerPoolName == listBoxSelectPlayer.SelectedItem.ToString())
                    {
                        BuildPicksListBox(selectedPlayer);
                        UpdateForm(selectedPlayer);
                    }
                }
            }
        }

        private void BuildPicksListBox(PlayersDBDataSet.PlayersRow selectedPlayer)
        {
            //http://www.dotnetperls.com/convert-list-string

            listBoxMyPicksPlayers.Items.Clear();

            if (selectedPlayer.PicksWeek01 != "" && comboBoxSelectWeek.Text == "Week 01")
            {
                // split the PicksWeek01 string
                string[] tempString = selectedPlayer.PicksWeek01.Split(',');

                // create temp list for those split strings
                List<string> tempList = new List<string>(tempString);

                // add each string to the listBox
                foreach (string item in tempList)
                {
                    listBoxMyPicksPlayers.Items.Add(item);
                }              
            }

            if (selectedPlayer.PicksWeek02 != "" && comboBoxSelectWeek.Text == "Week 02")
            {
                // split the PicksWeek01 string
                string[] tempString = selectedPlayer.PicksWeek02.Split(',');

                // create temp list for those split strings
                List<string> tempList = new List<string>(tempString);

                // add each string to the listBox
                foreach (string item in tempList)
                {
                    listBoxMyPicksPlayers.Items.Add(item);
                }
            }

            if (selectedPlayer.PicksWeek03 != "" && comboBoxSelectWeek.Text == "Week 03")
            {
                // split the PicksWeek01 string
                string[] tempString = selectedPlayer.PicksWeek03.Split(',');

                // create temp list for those split strings
                List<string> tempList = new List<string>(tempString);

                // add each string to the listBox
                foreach (string item in tempList)
                {
                    listBoxMyPicksPlayers.Items.Add(item);
                }
            }

            if (selectedPlayer.PicksWeek04 != "" && comboBoxSelectWeek.Text == "Week 04")
            {
                // split the PicksWeek01 string
                string[] tempString = selectedPlayer.PicksWeek04.Split(',');

                // create temp list for those split strings
                List<string> tempList = new List<string>(tempString);

                // add each string to the listBox
                foreach (string item in tempList)
                {
                    listBoxMyPicksPlayers.Items.Add(item);
                }
            }

            if (selectedPlayer.PicksWeek05 != "" && comboBoxSelectWeek.Text == "Week 05")
            {
                // split the PicksWeek01 string
                string[] tempString = selectedPlayer.PicksWeek05.Split(',');

                // create temp list for those split strings
                List<string> tempList = new List<string>(tempString);

                // add each string to the listBox
                foreach (string item in tempList)
                {
                    listBoxMyPicksPlayers.Items.Add(item);
                }
            }

            if (selectedPlayer.PicksWeek06 != "" && comboBoxSelectWeek.Text == "Week 06")
            {
                // split the PicksWeek01 string
                string[] tempString = selectedPlayer.PicksWeek06.Split(',');

                // create temp list for those split strings
                List<string> tempList = new List<string>(tempString);

                // add each string to the listBox
                foreach (string item in tempList)
                {
                    listBoxMyPicksPlayers.Items.Add(item);
                }
            }

            if (selectedPlayer.PicksWeek07 != "" && comboBoxSelectWeek.Text == "Week 07")
            {
                // split the PicksWeek01 string
                string[] tempString = selectedPlayer.PicksWeek07.Split(',');

                // create temp list for those split strings
                List<string> tempList = new List<string>(tempString);

                // add each string to the listBox
                foreach (string item in tempList)
                {
                    listBoxMyPicksPlayers.Items.Add(item);
                }
            }

            if (selectedPlayer.PicksWeek08 != "" && comboBoxSelectWeek.Text == "Week 08")
            {
                // split the PicksWeek01 string
                string[] tempString = selectedPlayer.PicksWeek08.Split(',');

                // create temp list for those split strings
                List<string> tempList = new List<string>(tempString);

                // add each string to the listBox
                foreach (string item in tempList)
                {
                    listBoxMyPicksPlayers.Items.Add(item);
                }
            }

            if (selectedPlayer.PicksWeek09 != "" && comboBoxSelectWeek.Text == "Week 09")
            {
                // split the PicksWeek01 string
                string[] tempString = selectedPlayer.PicksWeek09.Split(',');

                // create temp list for those split strings
                List<string> tempList = new List<string>(tempString);

                // add each string to the listBox
                foreach (string item in tempList)
                {
                    listBoxMyPicksPlayers.Items.Add(item);
                }
            }

            if (selectedPlayer.PicksWeek10 != "" && comboBoxSelectWeek.Text == "Week 10")
            {
                // split the PicksWeek01 string
                string[] tempString = selectedPlayer.PicksWeek10.Split(',');

                // create temp list for those split strings
                List<string> tempList = new List<string>(tempString);

                // add each string to the listBox
                foreach (string item in tempList)
                {
                    listBoxMyPicksPlayers.Items.Add(item);
                }
            }

            if (selectedPlayer.PicksWeek11 != "" && comboBoxSelectWeek.Text == "Week 11")
            {
                // split the PicksWeek01 string
                string[] tempString = selectedPlayer.PicksWeek11.Split(',');

                // create temp list for those split strings
                List<string> tempList = new List<string>(tempString);

                // add each string to the listBox
                foreach (string item in tempList)
                {
                    listBoxMyPicksPlayers.Items.Add(item);
                }
            }

            if (selectedPlayer.PicksWeek12 != "" && comboBoxSelectWeek.Text == "Week 12")
            {
                // split the PicksWeek01 string
                string[] tempString = selectedPlayer.PicksWeek12.Split(',');

                // create temp list for those split strings
                List<string> tempList = new List<string>(tempString);

                // add each string to the listBox
                foreach (string item in tempList)
                {
                    listBoxMyPicksPlayers.Items.Add(item);
                }
            }

            if (selectedPlayer.PicksWeek13 != "" && comboBoxSelectWeek.Text == "Week 13")
            {
                // split the PicksWeek01 string
                string[] tempString = selectedPlayer.PicksWeek13.Split(',');

                // create temp list for those split strings
                List<string> tempList = new List<string>(tempString);

                // add each string to the listBox
                foreach (string item in tempList)
                {
                    listBoxMyPicksPlayers.Items.Add(item);
                }
            }

            if (selectedPlayer.PicksWeek14 != "" && comboBoxSelectWeek.Text == "Week 14")
            {
                // split the PicksWeek01 string
                string[] tempString = selectedPlayer.PicksWeek14.Split(',');

                // create temp list for those split strings
                List<string> tempList = new List<string>(tempString);

                // add each string to the listBox
                foreach (string item in tempList)
                {
                    listBoxMyPicksPlayers.Items.Add(item);
                }
            }

            if (selectedPlayer.PicksWeek15 != "" && comboBoxSelectWeek.Text == "Week 15")
            {
                // split the PicksWeek01 string
                string[] tempString = selectedPlayer.PicksWeek15.Split(',');

                // create temp list for those split strings
                List<string> tempList = new List<string>(tempString);

                // add each string to the listBox
                foreach (string item in tempList)
                {
                    listBoxMyPicksPlayers.Items.Add(item);
                }
            }

            if (selectedPlayer.PicksWeek16 != "" && comboBoxSelectWeek.Text == "Week 16")
            {
                // split the PicksWeek01 string
                string[] tempString = selectedPlayer.PicksWeek16.Split(',');

                // create temp list for those split strings
                List<string> tempList = new List<string>(tempString);

                // add each string to the listBox
                foreach (string item in tempList)
                {
                    listBoxMyPicksPlayers.Items.Add(item);
                }
            }

            if (selectedPlayer.PicksWeek17 != "" && comboBoxSelectWeek.Text == "Week 17")
            {
                // split the PicksWeek01 string
                string[] tempString = selectedPlayer.PicksWeek17.Split(',');

                // create temp list for those split strings
                List<string> tempList = new List<string>(tempString);

                // add each string to the listBox
                foreach (string item in tempList)
                {
                    listBoxMyPicksPlayers.Items.Add(item);
                }
            }
        }

        private void buttonListPersonalInfo_Click(object sender, EventArgs e)
        {
            // check to see if the form is open
            if ((Application.OpenForms["FormPersonalInfo"] as FormPersonalInfo) != null)
            {
                // if it is then select the right form
                foreach (Form form in Application.OpenForms)
                {
                    if (form.Name == "FormPersonalInfo")
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
                FormPersonalInfo formPersonalInfo = new FormPersonalInfo();
                formPersonalInfo.Show();
            }
        }

        private void labelSearchPlayerText_Click(object sender, EventArgs e)
        {

        }
    }
}
