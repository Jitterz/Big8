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
    public partial class FormEnterPicks : Form
    {
        private List<CheckBox> CheckBoxes = new List<CheckBox>();
        private List<TextBox> TextBoxes = new List<TextBox>();

        public FormEnterPicks()
        {
            InitializeComponent();

            BuildCheckBoxList();
            BuildTextBoxList();
            UpdateCheckBoxes();
            this.seasons1_5TableAdapter.Fill(this.seasonsDBDataSet.Seasons1_5);
            this.seasons6_10TableAdapter.Fill(this.seasonsDBDataSet.Seasons6_10);
            this.seasons11_17TableAdapter.Fill(this.seasonsDBDataSet.Seasons11_17);
            BuildLostFocus();
            if (PublicVariables.GetDefaultSeason != null)
            {
                textBoxSelectedSeason.Text = PublicVariables.GetDefaultSeason;
            }
            if (textBoxSelectedSeason.Text != "")
            {
                CalculateTextBoxes();
            }

            // key down calls for moms picky way of entering shit enter in search box will go to pick box one
            // then enter after that will tab to next box when it gets to the submit picks button enter again will submit 
            // the picks and return to the search box
            textBoxSearchPlayerPicks.KeyDown += textSearchPlayerPicks_KeyDown;
            buttonConfirmPicksPicks.KeyDown += buttonConfirmPicksPicks_KeyDown;

            textBoxTypePicks01.KeyDown += textBoxTypePicks01_KeyDown;
            textBoxTypePicks02.KeyDown += textBoxTypePicks01_KeyDown;
            textBoxTypePicks03.KeyDown += textBoxTypePicks01_KeyDown;
            textBoxTypePicks04.KeyDown += textBoxTypePicks01_KeyDown;
            textBoxTypePicks05.KeyDown += textBoxTypePicks01_KeyDown;
            textBoxTypePicks06.KeyDown += textBoxTypePicks01_KeyDown;
            textBoxTypePicks07.KeyDown += textBoxTypePicks01_KeyDown;
            textBoxTypePicks08.KeyDown += textBoxTypePicks01_KeyDown;
            textBoxTypePicks09.KeyDown += textBoxTypePicks01_KeyDown;
            textBoxTypePicks10.KeyDown += textBoxTypePicks01_KeyDown;
            textBoxTypePicks11.KeyDown += textBoxTypePicks01_KeyDown;
            textBoxTypePicks12.KeyDown += textBoxTypePicks01_KeyDown;
            textBoxTypePicks13.KeyDown += textBoxTypePicks01_KeyDown;
            textBoxTypePicks14.KeyDown += textBoxTypePicks01_KeyDown;
            textBoxTypePicks15.KeyDown += textBoxTypePicks01_KeyDown;
            textBoxTypePicks16.KeyDown += textBoxTypePicks01_KeyDown;
            textBoxTypePicks17.KeyDown += textBoxTypePicks01_KeyDown;
            textBoxTypePicks18.KeyDown += textBoxTypePicks01_KeyDown;
            textBoxTypePicks19.KeyDown += textBoxTypePicks01_KeyDown;
            textBoxTypePicks20.KeyDown += textBoxTypePicks01_KeyDown;
        }

        private void textSearchPlayerPicks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                textBoxTypePicks01.Focus();
            }
        }

        private void buttonConfirmPicksPicks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                ApplyPicks();
                textBoxSearchPlayerPicks.Clear();
                textBoxSearchPlayerPicks.Focus();
            }
        }

        private void textBoxTypePicks01_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void UpdatePlayerList()
        {
            // clear the list then repopulate it
            listBoxPlayerListPicks.Items.Clear();
            // find the selected player in the database 
            foreach (PlayersDBDataSet.PlayersRow row in playersDBDataSet.Players)
            {
                if (row.IsActive == true)
                {
                    listBoxPlayerListPicks.Items.Add(row.PlayerPoolName);
                }
            }
        }

        private void FormEnterPicks_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'seasonsDBDataSet.Seasons6_10' table. You can move, or remove it, as needed.
            this.seasons6_10TableAdapter.Fill(this.seasonsDBDataSet.Seasons6_10);
            // TODO: This line of code loads data into the 'seasonsDBDataSet.Seasons11_17' table. You can move, or remove it, as needed.
            this.seasons11_17TableAdapter.Fill(this.seasonsDBDataSet.Seasons11_17);
            // TODO: This line of code loads data into the 'seasonsDBDataSet.Seasons1_5' table. You can move, or remove it, as needed.
            this.seasons1_5TableAdapter.Fill(this.seasonsDBDataSet.Seasons1_5);
            // TODO: This line of code loads data into the 'seasonsDBDataSet.Seasons' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'playersDBDataSet.Players' table. You can move, or remove it, as needed.
            this.playersTableAdapter.Fill(this.playersDBDataSet.Players);
            UpdatePlayerList();
            // set the selected week box to the default week
            comboBoxSelectWeekPicks.SelectedItem = PublicVariables.GetDefaultWeek;
            labelWeekDisplayPicks.Text = comboBoxSelectWeekPicks.Text;
            
        }

        private void textBoxSearchPlayerPicks_TextChanged(object sender, EventArgs e)
        {
            // found the Cast<string>.ToArray() basically it creates an array so I can edit it without
            // screwing up the foreach loop. Makes a copy of the list of names in the listbox.
            // then i can remove the name but the listbox items arent really affected.
            foreach (string removeString in listBoxPlayerListPicks.Items.Cast<string>().ToArray())
            {
                // if any of the player names dont match the text then remove them.
                if (!removeString.StartsWith(textBoxSearchPlayerPicks.Text, StringComparison.CurrentCultureIgnoreCase))
                {
                    listBoxPlayerListPicks.Items.Remove(removeString);

                    // if no names match the search text then reset the list and post the message.
                    if (listBoxPlayerListPicks.Items.Count == 0)
                    {
                        UpdatePlayerList();
                        MessageBox.Show("No players found.");
                    }

                    // so if there is only one player left after searching select him
                    if (listBoxPlayerListPicks.Items.Count == 1)
                    {
                        listBoxPlayerListPicks.SelectedIndex = 0;
                    }
                }
                // if it does match then go back and continue the foreach loop. So it removes the ones not matching
                // and doesnt stop.
                else if (removeString.StartsWith(textBoxSearchPlayerPicks.Text, StringComparison.CurrentCultureIgnoreCase))
                {
                    continue;
                }
            }

            // reset the player list if the search box is cleared out.
            if (textBoxSearchPlayerPicks.Text == "")
            {
                UpdatePlayerList();
            }
        }

        private void comboBoxSelectWeekPicks_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelWeekDisplayPicks.Text = comboBoxSelectWeekPicks.Text;
            UpdateCheckBoxes();
            LoadPlayerPicks();
            CalculateTextBoxes();
        }

        /*
        private void SelectPick(CheckBox checkedPick)
        {
            // make sure a player is selected
            if (listBoxPlayerListPicks.SelectedIndex == -1)
            {
                MessageBox.Show("No player selected.");
                ResetCheckBoxes();
                return;
            }
            // assign the pick and deselect the other box
            foreach (PlayersDBDataSet.PlayersRow selectedPlayer in playersDBDataSet.Players)
            {
                // if it is the selected player
                if (selectedPlayer.PlayerPoolName == listBoxPlayerListPicks.SelectedItem.ToString())
                {
                    // Bracket 01
                    if (checkedPick.Name == "picksBracket01_1")
                    {
                        selectedPlayer.Pick01 = checkedPick.Text;
                    }
                    else if (checkedPick.Name == "picksBracket01_2")
                    {
                        selectedPlayer.Pick01 = checkedPick.Text;
                    }
                    //---------------------------------------------

                    // Bracket 02
                    else if (checkedPick.Name == "picksBracket02_1")
                    {
                        selectedPlayer.Pick02 = checkedPick.Text;
                    }
                    else if (checkedPick.Name == "picksBracket02_2")
                    {
                        selectedPlayer.Pick02 = checkedPick.Text;
                    }
                    //---------------------------------------------

                    //Bracket 03
                    else if (checkedPick.Name == "picksBracket03_1")
                    {
                        selectedPlayer.Pick03 = checkedPick.Text;
                    }
                    else if (checkedPick.Name == "picksBracket03_2")
                    {
                        selectedPlayer.Pick03 = checkedPick.Text;
                    }
                    //---------------------------------------------

                    // Bracket 04
                    else if (checkedPick.Name == "picksBracket04_1")
                    {
                        selectedPlayer.Pick04 = checkedPick.Text;
                    }
                    else if (checkedPick.Name == "picksBracket04_2")
                    {
                        selectedPlayer.Pick04 = checkedPick.Text;
                    }
                    //---------------------------------------------

                        // Bracket 05
                    else if (checkedPick.Name == "picksBracket05_1")
                    {
                        selectedPlayer.Pick05 = checkedPick.Text;
                    }
                    else if (checkedPick.Name == "picksBracket05_2")
                    {
                        selectedPlayer.Pick05 = checkedPick.Text;
                    }
                    //---------------------------------------------

                        // Bracket 6
                    else if (checkedPick.Name == "picksBracket06_1")
                    {
                        selectedPlayer.Pick06 = checkedPick.Text;
                    }
                    else if (checkedPick.Name == "picksBracket06_2")
                    {
                        selectedPlayer.Pick06 = checkedPick.Text;
                    }
                    //---------------------------------------------

                        // Bracket 7
                    else if (checkedPick.Name == "picksBracket07_1")
                    {
                        selectedPlayer.Pick07 = checkedPick.Text;
                    }
                    else if (checkedPick.Name == "picksBracket07_2")
                    {
                        selectedPlayer.Pick07 = checkedPick.Text;
                    }
                    //---------------------------------------------

                        // Bracket 8
                    else if (checkedPick.Name == "picksBracket08_1")
                    {
                        selectedPlayer.Pick08 = checkedPick.Text;
                    }
                    else if (checkedPick.Name == "picksBracket08_2")
                    {
                        selectedPlayer.Pick08 = checkedPick.Text;
                    }
                    //---------------------------------------------
                        // Bracket 9
                    else if (checkedPick.Name == "picksBracket09_1")
                    {
                        selectedPlayer.Pick09 = checkedPick.Text;
                    }
                    else if (checkedPick.Name == "picksBracket09_2")
                    {
                        selectedPlayer.Pick09 = checkedPick.Text;
                    }
                    //---------------------------------------------

                        // Bracket 10
                    else if (checkedPick.Name == "picksBracket10_1")
                    {
                        selectedPlayer.Pick10 = checkedPick.Text;
                    }
                    else if (checkedPick.Name == "picksBracket10_2")
                    {
                        selectedPlayer.Pick10 = checkedPick.Text;
                    }
                    //---------------------------------------------

                    // Bracket 11
                    else if (checkedPick.Name == "picksBracket11_1")
                    {
                        selectedPlayer.Pick11 = checkedPick.Text;
                    }
                    else if (checkedPick.Name == "picksBracket11_2")
                    {
                        selectedPlayer.Pick11 = checkedPick.Text;
                    }
                    //---------------------------------------------

                    // Bracket 12
                    else if (checkedPick.Name == "picksBracket12_1")
                    {
                        selectedPlayer.Pick12 = checkedPick.Text;
                    }
                    else if (checkedPick.Name == "picksBracket12_2")
                    {
                        selectedPlayer.Pick12 = checkedPick.Text;
                    }
                    //---------------------------------------------

                    //Bracket 13
                    else if (checkedPick.Name == "picksBracket13_1")
                    {
                        selectedPlayer.Pick13 = checkedPick.Text;
                    }
                    else if (checkedPick.Name == "picksBracket13_2")
                    {
                        selectedPlayer.Pick13 = checkedPick.Text;
                    }
                    //---------------------------------------------
                    // Bracket 14
                    else if (checkedPick.Name == "picksBracket14_1")
                    {
                        selectedPlayer.Pick14 = checkedPick.Text;
                    }
                    else if (checkedPick.Name == "picksBracket14_2")
                    {
                        selectedPlayer.Pick14 = checkedPick.Text;
                    }
                    //---------------------------------------------

                    // Bracket 15
                    else if (checkedPick.Name == "picksBracket15_1")
                    {
                        selectedPlayer.Pick15 = checkedPick.Text;
                    }
                    else if (checkedPick.Name == "picksBracket15_2")
                    {
                        selectedPlayer.Pick15 = checkedPick.Text;
                    }
                    //---------------------------------------------

                    // Bracket 16
                    else if (checkedPick.Name == "picksBracket16_1")
                    {
                        selectedPlayer.Pick16 = checkedPick.Text;
                    }
                    else if (checkedPick.Name == "picksBracket16_2")
                    {
                        selectedPlayer.Pick16 = checkedPick.Text;
                    }
                    //---------------------------------------------

                    // Bracket 17
                    else if (checkedPick.Name == "picksBracket17_1")
                    {
                        selectedPlayer.Pick17 = checkedPick.Text;
                    }
                    else if (checkedPick.Name == "picksBracket17_2")
                    {
                        selectedPlayer.Pick17 = checkedPick.Text;
                    }
                    //---------------------------------------------

                    // Bracket 18
                    else if (checkedPick.Name == "picksBracket18_1")
                    {
                        selectedPlayer.Pick18 = checkedPick.Text;
                    }
                    else if (checkedPick.Name == "picksBracket18_2")
                    {
                        selectedPlayer.Pick18 = checkedPick.Text;
                    }
                    //---------------------------------------------

                    // Bracket 19
                    else if (checkedPick.Name == "picksBracket19_1")
                    {
                        selectedPlayer.Pick19 = checkedPick.Text;
                    }
                    else if (checkedPick.Name == "picksBracket19_2")
                    {
                        selectedPlayer.Pick19 = checkedPick.Text;
                    }
                    //---------------------------------------------

                    // Bracket 20
                    else if (checkedPick.Name == "picksBracket20_1")
                    {
                        selectedPlayer.Pick20 = checkedPick.Text;
                    }
                    else if (checkedPick.Name == "picksBracket20_2")
                    {
                        selectedPlayer.Pick20 = checkedPick.Text;
                    }
                    //---------------------------------------------
                }
                FillTextBox(checkedPick);
            }
        }
         * */

        // put the 40 checkboxes in a list make it easier later
        private void BuildCheckBoxList()
        {
            CheckBoxes.Add(picksBracket01_1);
            CheckBoxes.Add(picksBracket01_2);
            CheckBoxes.Add(picksBracket02_1);
            CheckBoxes.Add(picksBracket02_2);
            CheckBoxes.Add(picksBracket03_1);
            CheckBoxes.Add(picksBracket03_2);
            CheckBoxes.Add(picksBracket04_1);
            CheckBoxes.Add(picksBracket04_2);
            CheckBoxes.Add(picksBracket05_1);
            CheckBoxes.Add(picksBracket05_2);
            CheckBoxes.Add(picksBracket06_1);
            CheckBoxes.Add(picksBracket06_2);
            CheckBoxes.Add(picksBracket07_1);
            CheckBoxes.Add(picksBracket07_2);
            CheckBoxes.Add(picksBracket08_1);
            CheckBoxes.Add(picksBracket08_2);
            CheckBoxes.Add(picksBracket09_1);
            CheckBoxes.Add(picksBracket09_2);
            CheckBoxes.Add(picksBracket10_1);
            CheckBoxes.Add(picksBracket10_2);
            CheckBoxes.Add(picksBracket11_1);
            CheckBoxes.Add(picksBracket11_2);
            CheckBoxes.Add(picksBracket12_1);
            CheckBoxes.Add(picksBracket12_2);
            CheckBoxes.Add(picksBracket13_1);
            CheckBoxes.Add(picksBracket13_2);
            CheckBoxes.Add(picksBracket14_1);
            CheckBoxes.Add(picksBracket14_2);
            CheckBoxes.Add(picksBracket15_1);
            CheckBoxes.Add(picksBracket15_2);
            CheckBoxes.Add(picksBracket16_1);
            CheckBoxes.Add(picksBracket16_2);
            CheckBoxes.Add(picksBracket17_1);
            CheckBoxes.Add(picksBracket17_2);
            CheckBoxes.Add(picksBracket18_1);
            CheckBoxes.Add(picksBracket18_2);
            CheckBoxes.Add(picksBracket19_1);
            CheckBoxes.Add(picksBracket19_2);
            CheckBoxes.Add(picksBracket20_1);
            CheckBoxes.Add(picksBracket20_2);
        }

        // reset all the check boxes
        private void ResetCheckBoxes()
        {
            foreach (CheckBox allBoxes in CheckBoxes)
            {
                allBoxes.Checked = false;
            }
        }

        private void BuildTextBoxList()
        {
            TextBoxes.Add(textBoxTypePicks01);
            TextBoxes.Add(textBoxTypePicks02);
            TextBoxes.Add(textBoxTypePicks03);
            TextBoxes.Add(textBoxTypePicks04);
            TextBoxes.Add(textBoxTypePicks05);
            TextBoxes.Add(textBoxTypePicks06);
            TextBoxes.Add(textBoxTypePicks07);
            TextBoxes.Add(textBoxTypePicks08);
            TextBoxes.Add(textBoxTypePicks09);
            TextBoxes.Add(textBoxTypePicks10);
            TextBoxes.Add(textBoxTypePicks11);
            TextBoxes.Add(textBoxTypePicks12);
            TextBoxes.Add(textBoxTypePicks13);
            TextBoxes.Add(textBoxTypePicks14);
            TextBoxes.Add(textBoxTypePicks15);
            TextBoxes.Add(textBoxTypePicks16);
            TextBoxes.Add(textBoxTypePicks17);
            TextBoxes.Add(textBoxTypePicks18);
            TextBoxes.Add(textBoxTypePicks19);
            TextBoxes.Add(textBoxTypePicks20);
        }

        // fill the text boxes as the check boxes are checked
        
        private void FillTextBox()
        {
            //clear the text boxes
            foreach (TextBox textBoxes in TextBoxes)
            {
                textBoxes.Text = "";
            }

            // each checkbox that is checked fill in a text box
            foreach (CheckBox checkBoxes in CheckBoxes)
            {
                if (checkBoxes.Checked == true)
                {
                    foreach (TextBox textBoxes in TextBoxes)
                    {
                        if (textBoxes.Text == "")
                        {
                            textBoxes.Text = checkBoxes.Tag.ToString();
                            break;
                        }
                    }
                }
            }
        }        

        private void TypedPick(TextBox textBox)
        {
           
            bool isChecked = false;

            foreach (CheckBox boxes in CheckBoxes)
            {
                if (boxes.Tag.ToString() == textBox.Text)
                {
                    boxes.Checked = true;
                    isChecked = true;
                }
            }
            if (!isChecked && textBox.Text != "")
            {
                MessageBox.Show("No Matches");
                return;
            }
        }

        private void BuildLostFocus()
        {
            textBoxTypePicks01.LostFocus += textBoxTypePicks01_LostFocus;
            textBoxTypePicks02.LostFocus += textBoxTypePicks02_LostFocus;
            textBoxTypePicks03.LostFocus += textBoxTypePicks03_LostFocus;
            textBoxTypePicks04.LostFocus += textBoxTypePicks04_LostFocus;
            textBoxTypePicks05.LostFocus += textBoxTypePicks05_LostFocus;
            textBoxTypePicks06.LostFocus += textBoxTypePicks06_LostFocus;
            textBoxTypePicks07.LostFocus += textBoxTypePicks07_LostFocus;
            textBoxTypePicks08.LostFocus += textBoxTypePicks08_LostFocus;
            textBoxTypePicks09.LostFocus += textBoxTypePicks09_LostFocus;
            textBoxTypePicks10.LostFocus += textBoxTypePicks10_LostFocus;
            textBoxTypePicks11.LostFocus += textBoxTypePicks11_LostFocus;
            textBoxTypePicks12.LostFocus += textBoxTypePicks12_LostFocus;
            textBoxTypePicks13.LostFocus += textBoxTypePicks13_LostFocus;
            textBoxTypePicks14.LostFocus += textBoxTypePicks14_LostFocus;
            textBoxTypePicks15.LostFocus += textBoxTypePicks15_LostFocus;
            textBoxTypePicks16.LostFocus += textBoxTypePicks16_LostFocus;
            textBoxTypePicks17.LostFocus += textBoxTypePicks17_LostFocus;
            textBoxTypePicks18.LostFocus += textBoxTypePicks18_LostFocus;
            textBoxTypePicks19.LostFocus += textBoxTypePicks19_LostFocus;
            textBoxTypePicks20.LostFocus += textBoxTypePicks20_LostFocus;
        }

        // when a pick is entered need to make sure it is not the same bracket. This with remove text should do it
        // this also checks the boxes as they are entered. Long if statement here we go.
        // FIND invalid entry at the very end of these IFs.
        private void CheckTheBox(TextBox textBox)
        {
            if (listBoxPlayerListPicks.SelectedIndex == -1 && textBox.Text != "")
            {
                MessageBox.Show("No Player selected. Please select a player first Mom!");
                textBox.Text = "";
                return;
            }

            string invalidEntry = textBox.Text;

            // -------------  1   ---------------------------
            if (textBox.Text == "1")
            {              
                picksBracket01_1.Checked = true;
                picksBracket01_2.Checked = false;               
                RemoveText(picksBracket01_2);
                CheckDuplicates(textBox);
            }
            else if (textBox.Text == "2")
            {
                picksBracket01_2.Checked = true;
                picksBracket01_1.Checked = false;
                RemoveText(picksBracket01_1);
                CheckDuplicates(textBox);
            }

            // -------------  2   ---------------------------
            else if (textBox.Text == "3")
            {
                picksBracket02_1.Checked = true;
                picksBracket02_2.Checked = false;
                RemoveText(picksBracket02_2);
                CheckDuplicates(textBox);
            }
            else if (textBox.Text == "4")
            {
                picksBracket02_2.Checked = true;
                picksBracket02_1.Checked = false;
                RemoveText(picksBracket02_1);
                CheckDuplicates(textBox);
            }

            // -------------  3   ---------------------------
            else if (textBox.Text == "5")
            {
                picksBracket03_1.Checked = true;
                picksBracket03_2.Checked = false;
                RemoveText(picksBracket03_2);
                CheckDuplicates(textBox);
            }
            else if (textBox.Text == "6")
            {
                picksBracket03_2.Checked = true;
                picksBracket03_1.Checked = false;
                RemoveText(picksBracket03_1);
                CheckDuplicates(textBox);
            }

            // -------------  4   ---------------------------
            else if (textBox.Text == "7")
            {
                picksBracket04_1.Checked = true;
                picksBracket04_2.Checked = false;
                RemoveText(picksBracket04_2);
                CheckDuplicates(textBox);
            }
            else if (textBox.Text == "8")
            {
                picksBracket04_2.Checked = true;
                picksBracket04_1.Checked = false;
                RemoveText(picksBracket04_1);
                CheckDuplicates(textBox);
            }

            // -------------  5   ---------------------------
            else if (textBox.Text == "9")
            {
                picksBracket05_1.Checked = true;
                picksBracket05_2.Checked = false;
                RemoveText(picksBracket05_2);
                CheckDuplicates(textBox);
            }
            else if (textBox.Text == "10")
            {
                picksBracket05_2.Checked = true;
                picksBracket05_1.Checked = false;
                RemoveText(picksBracket05_1);
                CheckDuplicates(textBox);
            }

            // -------------  6   ---------------------------
            else if (textBox.Text == "11")
            {
                picksBracket06_1.Checked = true;
                picksBracket06_2.Checked = false;
                RemoveText(picksBracket06_2);
                CheckDuplicates(textBox);
            }
            else if (textBox.Text == "12")
            {
                picksBracket06_2.Checked = true;
                picksBracket06_1.Checked = false;
                RemoveText(picksBracket06_1);
                CheckDuplicates(textBox);
            }

            // -------------  7   ---------------------------
            else if (textBox.Text == "13")
            {
                picksBracket07_1.Checked = true;
                picksBracket07_2.Checked = false;
                RemoveText(picksBracket07_2);
                CheckDuplicates(textBox);
            }
            else if (textBox.Text == "14")
            {
                picksBracket07_2.Checked = true;
                picksBracket07_1.Checked = false;
                RemoveText(picksBracket07_1);
                CheckDuplicates(textBox);
            }

            // -------------  8   ---------------------------
            else if (textBox.Text == "15")
            {
                picksBracket08_1.Checked = true;
                picksBracket08_2.Checked = false;
                RemoveText(picksBracket08_2);
                CheckDuplicates(textBox);
            }
            else if (textBox.Text == "16")
            {
                picksBracket08_2.Checked = true;
                picksBracket08_1.Checked = false;
                RemoveText(picksBracket08_1);
                CheckDuplicates(textBox);
            }

            // -------------  9   ---------------------------
            else if (textBox.Text == "17")
            {
                picksBracket09_1.Checked = true;
                picksBracket09_2.Checked = false;
                RemoveText(picksBracket09_2);
                CheckDuplicates(textBox);
            }
            else if (textBox.Text == "18")
            {
                picksBracket09_2.Checked = true;
                picksBracket09_1.Checked = false;
                RemoveText(picksBracket09_1);
                CheckDuplicates(textBox);
            }

            // -------------  10   ---------------------------
            else if (textBox.Text == "19")
            {
                picksBracket10_1.Checked = true;
                picksBracket10_2.Checked = false;
                RemoveText(picksBracket10_2);
                CheckDuplicates(textBox);
            }
            else if (textBox.Text == "20")
            {
                picksBracket10_2.Checked = true;
                picksBracket10_1.Checked = false;
                RemoveText(picksBracket10_1);
                CheckDuplicates(textBox);
            }

            // -------------  11   ---------------------------
            else if (textBox.Text == "21")
            {
                picksBracket11_1.Checked = true;
                picksBracket11_2.Checked = false;
                RemoveText(picksBracket11_2);
                CheckDuplicates(textBox);
            }
            else if (textBox.Text == "22")
            {
                picksBracket11_2.Checked = true;
                picksBracket11_1.Checked = false;
                RemoveText(picksBracket11_1);
                CheckDuplicates(textBox);
            }

            // -------------  12   ---------------------------
            else if (textBox.Text == "23")
            {
                picksBracket12_1.Checked = true;
                picksBracket12_2.Checked = false;
                RemoveText(picksBracket12_2);
                CheckDuplicates(textBox);
            }
            else if (textBox.Text == "24")
            {
                picksBracket12_2.Checked = true;
                picksBracket12_1.Checked = false;
                RemoveText(picksBracket12_1);
                CheckDuplicates(textBox);
            }

            // -------------  13   ---------------------------
            else if (textBox.Text == "25")
            {
                picksBracket13_1.Checked = true;
                picksBracket13_2.Checked = false;
                RemoveText(picksBracket13_2);
                CheckDuplicates(textBox);
            }
            else if (textBox.Text == "26")
            {
                picksBracket13_2.Checked = true;
                picksBracket13_1.Checked = false;
                RemoveText(picksBracket13_1);
                CheckDuplicates(textBox);
            }

            // -------------  14   ---------------------------
            else if (textBox.Text == "27")
            {
                picksBracket14_1.Checked = true;
                picksBracket14_2.Checked = false;
                RemoveText(picksBracket14_2);
                CheckDuplicates(textBox);
            }
            else if (textBox.Text == "28")
            {
                picksBracket14_2.Checked = true;
                picksBracket14_1.Checked = false;
                RemoveText(picksBracket14_1);
                CheckDuplicates(textBox);
            }

            // -------------  15   ---------------------------
            else if (textBox.Text == "29")
            {
                picksBracket15_1.Checked = true;
                picksBracket15_2.Checked = false;
                RemoveText(picksBracket15_2);
                CheckDuplicates(textBox);
            }
            else if (textBox.Text == "30")
            {
                picksBracket15_2.Checked = true;
                picksBracket15_1.Checked = false;
                RemoveText(picksBracket15_1);
                CheckDuplicates(textBox);
            }

            // -------------  16   ---------------------------
            else if (textBox.Text == "31")
            {
                picksBracket16_1.Checked = true;
                picksBracket16_2.Checked = false;
                RemoveText(picksBracket16_2);
                CheckDuplicates(textBox);
            }
            else if (textBox.Text == "32")
            {
                picksBracket16_2.Checked = true;
                picksBracket16_1.Checked = false;
                RemoveText(picksBracket16_1);
                CheckDuplicates(textBox);
            }

            // -------------  17   ---------------------------
            else if (textBox.Text == "33")
            {
                picksBracket17_1.Checked = true;
                picksBracket17_2.Checked = false;
                RemoveText(picksBracket17_2);
                CheckDuplicates(textBox);
            }
            else if (textBox.Text == "34")
            {
                picksBracket17_2.Checked = true;
                picksBracket17_1.Checked = false;
                RemoveText(picksBracket17_1);
                CheckDuplicates(textBox);
            }

            // -------------  18   ---------------------------
            else if (textBox.Text == "35")
            {
                picksBracket18_1.Checked = true;
                picksBracket18_2.Checked = false;
                RemoveText(picksBracket18_2);
                CheckDuplicates(textBox);
            }
            else if (textBox.Text == "36")
            {
                picksBracket18_2.Checked = true;
                picksBracket18_1.Checked = false;
                RemoveText(picksBracket18_1);
                CheckDuplicates(textBox);
            }

            // -------------  19   ---------------------------
            else if (textBox.Text == "37")
            {
                picksBracket19_1.Checked = true;
                picksBracket19_2.Checked = false;
                RemoveText(picksBracket19_2);
                CheckDuplicates(textBox);
            }
            else if (textBox.Text == "38")
            {
                picksBracket19_2.Checked = true;
                picksBracket19_1.Checked = false;
                RemoveText(picksBracket19_1);
                CheckDuplicates(textBox);
            }

            // -------------  20   ---------------------------
            else if (textBox.Text == "39")
            {
                picksBracket20_1.Checked = true;
                picksBracket20_2.Checked = false;
                RemoveText(picksBracket20_2);
                CheckDuplicates(textBox);
            }
            else if (textBox.Text == "40")
            {
                picksBracket20_2.Checked = true;
                picksBracket20_1.Checked = false;
                RemoveText(picksBracket20_1);
                CheckDuplicates(textBox);
            }
            else
            {
                if (textBox.Text != "")
                {
                    textBox.Text = "";
                    MessageBox.Show("Invalid entry detected. " + invalidEntry + " is not a valid entry mom!");
                }
            }
            UncheckBoxes();
        }

        // so I can remove the text from the textbox that is invalid. Player can't pick 1 and 2.
        private void RemoveText(CheckBox checkBox)
        {
            foreach (TextBox textBox in TextBoxes)
            {
                if (checkBox.Tag.ToString() == textBox.Text)
                {
                    textBox.Text = "";
                    MessageBox.Show("Text removed from textbox. You cannot have two teams selected from the same bracket.");
                }
            }
        }

        private void CheckDuplicates(TextBox textBox)
        {
            string clearedBox = textBox.Text;

            // check for the invalid entry e.g. from same bracket.
            foreach (TextBox newBox in TextBoxes)
            {
                if (textBox.Text == newBox.Text && textBox.Tag != newBox.Tag && newBox.Text != "")
                {
                    textBox.Text = "";
                    MessageBox.Show("Duplicate Entry Detected.");
                }
            }

            // if the box is cleared we need to clear the checkbox as well.
            if (textBox.Text == "")
            {
                foreach (CheckBox checkBox in CheckBoxes)
                {
                    if (checkBox.Tag.ToString() == clearedBox)
                    {
                        checkBox.Checked = false;
                    }
                }
            }
        }

        // need to uncheck a box if the text entry is removed.
        private void UncheckBoxes()
        {
            foreach (CheckBox checkBoxes in CheckBoxes)
            {
                foreach (TextBox textBox in TextBoxes)
                {
                    if (checkBoxes.Tag.ToString() == textBox.Text)
                    {
                        checkBoxes.Checked = true;
                        break;
                    }
                    else
                    {
                        checkBoxes.Checked = false;
                    }
                }
            }
        }

        private void UpdateCheckBoxes()
        {
            if (textBoxSelectedSeason.Text != "")
            {
                if (comboBoxSelectWeekPicks.Text == "Week 01")
                {
                    BuildWeek01();
                }
                if (comboBoxSelectWeekPicks.Text == "Week 02")
                {
                    BuildWeek02();
                }
                if (comboBoxSelectWeekPicks.Text == "Week 03")
                {
                    BuildWeek03();
                }
                if (comboBoxSelectWeekPicks.Text == "Week 04")
                {
                    BuildWeek04();
                }
                if (comboBoxSelectWeekPicks.Text == "Week 05")
                {
                    BuildWeek05();
                }
                if (comboBoxSelectWeekPicks.Text == "Week 06")
                {
                    BuildWeek06();
                }
                if (comboBoxSelectWeekPicks.Text == "Week 07")
                {
                    BuildWeek07();
                }
                if (comboBoxSelectWeekPicks.Text == "Week 08")
                {
                    BuildWeek08();
                }
                if (comboBoxSelectWeekPicks.Text == "Week 09")
                {
                    BuildWeek09();
                }
                if (comboBoxSelectWeekPicks.Text == "Week 10")
                {
                    BuildWeek10();
                }
                if (comboBoxSelectWeekPicks.Text == "Week 11")
                {
                    BuildWeek11();
                }
                if (comboBoxSelectWeekPicks.Text == "Week 12")
                {
                    BuildWeek12();
                }
                if (comboBoxSelectWeekPicks.Text == "Week 13")
                {
                    BuildWeek13();
                }
                if (comboBoxSelectWeekPicks.Text == "Week 14")
                {
                    BuildWeek14();
                }
                if (comboBoxSelectWeekPicks.Text == "Week 15")
                {
                    BuildWeek15();
                }
                if (comboBoxSelectWeekPicks.Text == "Week 16")
                {
                    BuildWeek16();
                }
                if (comboBoxSelectWeekPicks.Text == "Week 17")
                {
                    BuildWeek17();
                }
            }
        }
        

        private void textBoxTypePicks01_LostFocus(object sender, EventArgs e)
        {
            CheckTheBox(textBoxTypePicks01);
        }

        private void textBoxTypePicks02_LostFocus(object sender, EventArgs e)
        {
           CheckTheBox(textBoxTypePicks02);
        }

        private void textBoxTypePicks03_LostFocus(object sender, EventArgs e)
        {
            CheckTheBox(textBoxTypePicks03);
        }

        private void textBoxTypePicks04_LostFocus(object sender, EventArgs e)
        {
            CheckTheBox(textBoxTypePicks04);
        }

        private void textBoxTypePicks05_LostFocus(object sender, EventArgs e)
        {
            CheckTheBox(textBoxTypePicks05);
        }

        private void textBoxTypePicks06_LostFocus(object sender, EventArgs e)
        {
            CheckTheBox(textBoxTypePicks06);
        }

        private void textBoxTypePicks07_LostFocus(object sender, EventArgs e)
        {
            CheckTheBox(textBoxTypePicks07);
        }

        private void textBoxTypePicks08_LostFocus(object sender, EventArgs e)
        {
            CheckTheBox(textBoxTypePicks08);
        }

        private void textBoxTypePicks09_LostFocus(object sender, EventArgs e)
        {
            CheckTheBox(textBoxTypePicks09);
        }

        private void textBoxTypePicks10_LostFocus(object sender, EventArgs e)
        {
            CheckTheBox(textBoxTypePicks10);
        }

        private void textBoxTypePicks11_LostFocus(object sender, EventArgs e)
        {
            CheckTheBox(textBoxTypePicks11);
        }

        private void textBoxTypePicks12_LostFocus(object sender, EventArgs e)
        {
            CheckTheBox(textBoxTypePicks12);
        }

        private void textBoxTypePicks13_LostFocus(object sender, EventArgs e)
        {
            CheckTheBox(textBoxTypePicks13);
        }

        private void textBoxTypePicks14_LostFocus(object sender, EventArgs e)
        {
            CheckTheBox(textBoxTypePicks14);
        }

        private void textBoxTypePicks15_LostFocus(object sender, EventArgs e)
        {
            CheckTheBox(textBoxTypePicks15);
        }

        private void textBoxTypePicks16_LostFocus(object sender, EventArgs e)
        {
            CheckTheBox(textBoxTypePicks16);
        }

        private void textBoxTypePicks17_LostFocus(object sender, EventArgs e)
        {
            CheckTheBox(textBoxTypePicks17);
        }

        private void textBoxTypePicks18_LostFocus(object sender, EventArgs e)
        {
            CheckTheBox(textBoxTypePicks18);
        }

        private void textBoxTypePicks19_LostFocus(object sender, EventArgs e)
        {
            CheckTheBox(textBoxTypePicks19);
        }

        private void textBoxTypePicks20_LostFocus(object sender, EventArgs e)
        {
            CheckTheBox(textBoxTypePicks20);
        }

        private void BuildWeek01()
        {
            this.seasons1_5TableAdapter.Fill(this.seasonsDBDataSet.Seasons1_5);
            this.seasons6_10TableAdapter.Fill(this.seasonsDBDataSet.Seasons6_10);
            this.seasons11_17TableAdapter.Fill(this.seasonsDBDataSet.Seasons11_17);
            foreach (SeasonsDBDataSet.Seasons1_5Row season in seasonsDBDataSet.Seasons1_5)
            {
                if (season.SeasonName == textBoxSelectedSeason.Text)
                {
                    picksBracket01_1.Text = season.Week01Team01;
                    picksBracket01_2.Text = season.Week01Team02;
                    picksBracket02_1.Text = season.Week01Team03;
                    picksBracket02_2.Text = season.Week01Team04;
                    picksBracket03_1.Text = season.Week01Team05;
                    picksBracket03_2.Text = season.Week01Team06;
                    picksBracket04_1.Text = season.Week01Team07;
                    picksBracket04_2.Text = season.Week01Team08;
                    picksBracket05_1.Text = season.Week01Team09;
                    picksBracket05_2.Text = season.Week01Team10;
                    picksBracket06_1.Text = season.Week01Team11;
                    picksBracket06_2.Text = season.Week01Team12;
                    picksBracket07_1.Text = season.Week01Team13;
                    picksBracket07_2.Text = season.Week01Team14;
                    picksBracket08_1.Text = season.Week01Team15;
                    picksBracket08_2.Text = season.Week01Team16;
                    picksBracket09_1.Text = season.Week01Team17;
                    picksBracket09_2.Text = season.Week01Team18;
                    picksBracket10_1.Text = season.Week01Team19;
                    picksBracket10_2.Text = season.Week01Team20;
                    picksBracket11_1.Text = season.Week01Team21;
                    picksBracket11_2.Text = season.Week01Team22;
                    picksBracket12_1.Text = season.Week01Team23;
                    picksBracket12_2.Text = season.Week01Team24;
                    picksBracket13_1.Text = season.Week01Team25;
                    picksBracket13_2.Text = season.Week01Team26;
                    picksBracket14_1.Text = season.Week01Team27;
                    picksBracket14_2.Text = season.Week01Team28;
                    picksBracket15_1.Text = season.Week01Team29;
                    picksBracket15_2.Text = season.Week01Team30;
                    picksBracket16_1.Text = season.Week01Team31;
                    picksBracket16_2.Text = season.Week01Team32;
                    picksBracket17_1.Text = season.Week01Team33;
                    picksBracket17_2.Text = season.Week01Team34;
                    picksBracket18_1.Text = season.Week01Team35;
                    picksBracket18_2.Text = season.Week01Team36;
                    picksBracket19_1.Text = season.Week01Team37;
                    picksBracket19_2.Text = season.Week01Team38;
                    picksBracket20_1.Text = season.Week01Team39;
                    picksBracket20_2.Text = season.Week01Team40;
                }
            }
        }
        private void BuildWeek02()
        {
            this.seasons1_5TableAdapter.Fill(this.seasonsDBDataSet.Seasons1_5);
            this.seasons6_10TableAdapter.Fill(this.seasonsDBDataSet.Seasons6_10);
            this.seasons11_17TableAdapter.Fill(this.seasonsDBDataSet.Seasons11_17);
            foreach (SeasonsDBDataSet.Seasons1_5Row season in seasonsDBDataSet.Seasons1_5)
            {
                if (season.SeasonName == textBoxSelectedSeason.Text)
                {
                    picksBracket01_1.Text = season.Week02Team01;
                    picksBracket01_2.Text = season.Week02Team02;
                    picksBracket02_1.Text = season.Week02Team03;
                    picksBracket02_2.Text = season.Week02Team04;
                    picksBracket03_1.Text = season.Week02Team05;
                    picksBracket03_2.Text = season.Week02Team06;
                    picksBracket04_1.Text = season.Week02Team07;
                    picksBracket04_2.Text = season.Week02Team08;
                    picksBracket05_1.Text = season.Week02Team09;
                    picksBracket05_2.Text = season.Week02Team10;
                    picksBracket06_1.Text = season.Week02Team11;
                    picksBracket06_2.Text = season.Week02Team12;
                    picksBracket07_1.Text = season.Week02Team13;
                    picksBracket07_2.Text = season.Week02Team14;
                    picksBracket08_1.Text = season.Week02Team15;
                    picksBracket08_2.Text = season.Week02Team16;
                    picksBracket09_1.Text = season.Week02Team17;
                    picksBracket09_2.Text = season.Week02Team18;
                    picksBracket10_1.Text = season.Week02Team19;
                    picksBracket10_2.Text = season.Week02Team20;
                    picksBracket11_1.Text = season.Week02Team21;
                    picksBracket11_2.Text = season.Week02Team22;
                    picksBracket12_1.Text = season.Week02Team23;
                    picksBracket12_2.Text = season.Week02Team24;
                    picksBracket13_1.Text = season.Week02Team25;
                    picksBracket13_2.Text = season.Week02Team26;
                    picksBracket14_1.Text = season.Week02Team27;
                    picksBracket14_2.Text = season.Week02Team28;
                    picksBracket15_1.Text = season.Week02Team29;
                    picksBracket15_2.Text = season.Week02Team30;
                    picksBracket16_1.Text = season.Week02Team31;
                    picksBracket16_2.Text = season.Week02Team32;
                    picksBracket17_1.Text = season.Week02Team33;
                    picksBracket17_2.Text = season.Week02Team34;
                    picksBracket18_1.Text = season.Week02Team35;
                    picksBracket18_2.Text = season.Week02Team36;
                    picksBracket19_1.Text = season.Week02Team37;
                    picksBracket19_2.Text = season.Week02Team38;
                    picksBracket20_1.Text = season.Week02Team39;
                    picksBracket20_2.Text = season.Week02Team40;
                }
            }
        }
        private void BuildWeek03()
        {
            this.seasons1_5TableAdapter.Fill(this.seasonsDBDataSet.Seasons1_5);
            this.seasons6_10TableAdapter.Fill(this.seasonsDBDataSet.Seasons6_10);
            this.seasons11_17TableAdapter.Fill(this.seasonsDBDataSet.Seasons11_17);
            foreach (SeasonsDBDataSet.Seasons1_5Row season in seasonsDBDataSet.Seasons1_5)
            {
                if (season.SeasonName == textBoxSelectedSeason.Text)
                {
                    picksBracket01_1.Text = season.Week03Team01;
                    picksBracket01_2.Text = season.Week03Team02;
                    picksBracket02_1.Text = season.Week03Team03;
                    picksBracket02_2.Text = season.Week03Team04;
                    picksBracket03_1.Text = season.Week03Team05;
                    picksBracket03_2.Text = season.Week03Team06;
                    picksBracket04_1.Text = season.Week03Team07;
                    picksBracket04_2.Text = season.Week03Team08;
                    picksBracket05_1.Text = season.Week03Team09;
                    picksBracket05_2.Text = season.Week03Team10;
                    picksBracket06_1.Text = season.Week03Team11;
                    picksBracket06_2.Text = season.Week03Team12;
                    picksBracket07_1.Text = season.Week03Team13;
                    picksBracket07_2.Text = season.Week03Team14;
                    picksBracket08_1.Text = season.Week03Team15;
                    picksBracket08_2.Text = season.Week03Team16;
                    picksBracket09_1.Text = season.Week03Team17;
                    picksBracket09_2.Text = season.Week03Team18;
                    picksBracket10_1.Text = season.Week03Team19;
                    picksBracket10_2.Text = season.Week03Team20;
                    picksBracket11_1.Text = season.Week03Team21;
                    picksBracket11_2.Text = season.Week03Team22;
                    picksBracket12_1.Text = season.Week03Team23;
                    picksBracket12_2.Text = season.Week03Team24;
                    picksBracket13_1.Text = season.Week03Team25;
                    picksBracket13_2.Text = season.Week03Team26;
                    picksBracket14_1.Text = season.Week03Team27;
                    picksBracket14_2.Text = season.Week03Team28;
                    picksBracket15_1.Text = season.Week03Team29;
                    picksBracket15_2.Text = season.Week03Team30;
                    picksBracket16_1.Text = season.Week03Team31;
                    picksBracket16_2.Text = season.Week03Team32;
                    picksBracket17_1.Text = season.Week03Team33;
                    picksBracket17_2.Text = season.Week03Team34;
                    picksBracket18_1.Text = season.Week03Team35;
                    picksBracket18_2.Text = season.Week03Team36;
                    picksBracket19_1.Text = season.Week03Team37;
                    picksBracket19_2.Text = season.Week03Team38;
                    picksBracket20_1.Text = season.Week03Team39;
                    picksBracket20_2.Text = season.Week03Team40;
                }
            }
        }
        private void BuildWeek04()
        {
            this.seasons1_5TableAdapter.Fill(this.seasonsDBDataSet.Seasons1_5);
            this.seasons6_10TableAdapter.Fill(this.seasonsDBDataSet.Seasons6_10);
            this.seasons11_17TableAdapter.Fill(this.seasonsDBDataSet.Seasons11_17);
            foreach (SeasonsDBDataSet.Seasons1_5Row season in seasonsDBDataSet.Seasons1_5)
            {
                if (season.SeasonName == textBoxSelectedSeason.Text)
                {
                    picksBracket01_1.Text = season.Week04Team01;
                    picksBracket01_2.Text = season.Week04Team02;
                    picksBracket02_1.Text = season.Week04Team03;
                    picksBracket02_2.Text = season.Week04Team04;
                    picksBracket03_1.Text = season.Week04Team05;
                    picksBracket03_2.Text = season.Week04Team06;
                    picksBracket04_1.Text = season.Week04Team07;
                    picksBracket04_2.Text = season.Week04Team08;
                    picksBracket05_1.Text = season.Week04Team09;
                    picksBracket05_2.Text = season.Week04Team10;
                    picksBracket06_1.Text = season.Week04Team11;
                    picksBracket06_2.Text = season.Week04Team12;
                    picksBracket07_1.Text = season.Week04Team13;
                    picksBracket07_2.Text = season.Week04Team14;
                    picksBracket08_1.Text = season.Week04Team15;
                    picksBracket08_2.Text = season.Week04Team16;
                    picksBracket09_1.Text = season.Week04Team17;
                    picksBracket09_2.Text = season.Week04Team18;
                    picksBracket10_1.Text = season.Week04Team19;
                    picksBracket10_2.Text = season.Week04Team20;
                    picksBracket11_1.Text = season.Week04Team21;
                    picksBracket11_2.Text = season.Week04Team22;
                    picksBracket12_1.Text = season.Week04Team23;
                    picksBracket12_2.Text = season.Week04Team24;
                    picksBracket13_1.Text = season.Week04Team25;
                    picksBracket13_2.Text = season.Week04Team26;
                    picksBracket14_1.Text = season.Week04Team27;
                    picksBracket14_2.Text = season.Week04Team28;
                    picksBracket15_1.Text = season.Week04Team29;
                    picksBracket15_2.Text = season.Week04Team30;
                    picksBracket16_1.Text = season.Week04Team31;
                    picksBracket16_2.Text = season.Week04Team32;
                    picksBracket17_1.Text = season.Week04Team33;
                    picksBracket17_2.Text = season.Week04Team34;
                    picksBracket18_1.Text = season.Week04Team35;
                    picksBracket18_2.Text = season.Week04Team36;
                    picksBracket19_1.Text = season.Week04Team37;
                    picksBracket19_2.Text = season.Week04Team38;
                    picksBracket20_1.Text = season.Week04Team39;
                    picksBracket20_2.Text = season.Week04Team40;
                }
            }
        }
        private void BuildWeek05()
        {
            this.seasons1_5TableAdapter.Fill(this.seasonsDBDataSet.Seasons1_5);
            this.seasons6_10TableAdapter.Fill(this.seasonsDBDataSet.Seasons6_10);
            this.seasons11_17TableAdapter.Fill(this.seasonsDBDataSet.Seasons11_17);
            foreach (SeasonsDBDataSet.Seasons1_5Row season in seasonsDBDataSet.Seasons1_5)
            {
                if (season.SeasonName == textBoxSelectedSeason.Text)
                {
                    picksBracket01_1.Text = season.Week05Team01;
                    picksBracket01_2.Text = season.Week05Team02;
                    picksBracket02_1.Text = season.Week05Team03;
                    picksBracket02_2.Text = season.Week05Team04;
                    picksBracket03_1.Text = season.Week05Team05;
                    picksBracket03_2.Text = season.Week05Team06;
                    picksBracket04_1.Text = season.Week05Team07;
                    picksBracket04_2.Text = season.Week05Team08;
                    picksBracket05_1.Text = season.Week05Team09;
                    picksBracket05_2.Text = season.Week05Team10;
                    picksBracket06_1.Text = season.Week05Team11;
                    picksBracket06_2.Text = season.Week05Team12;
                    picksBracket07_1.Text = season.Week05Team13;
                    picksBracket07_2.Text = season.Week05Team14;
                    picksBracket08_1.Text = season.Week05Team15;
                    picksBracket08_2.Text = season.Week05Team16;
                    picksBracket09_1.Text = season.Week05Team17;
                    picksBracket09_2.Text = season.Week05Team18;
                    picksBracket10_1.Text = season.Week05Team19;
                    picksBracket10_2.Text = season.Week05Team20;
                    picksBracket11_1.Text = season.Week05Team21;
                    picksBracket11_2.Text = season.Week05Team22;
                    picksBracket12_1.Text = season.Week05Team23;
                    picksBracket12_2.Text = season.Week05Team24;
                    picksBracket13_1.Text = season.Week05Team25;
                    picksBracket13_2.Text = season.Week05Team26;
                    picksBracket14_1.Text = season.Week05Team27;
                    picksBracket14_2.Text = season.Week05Team28;
                    picksBracket15_1.Text = season.Week05Team29;
                    picksBracket15_2.Text = season.Week05Team30;
                    picksBracket16_1.Text = season.Week05Team31;
                    picksBracket16_2.Text = season.Week05Team32;
                    picksBracket17_1.Text = season.Week05Team33;
                    picksBracket17_2.Text = season.Week05Team34;
                    picksBracket18_1.Text = season.Week05Team35;
                    picksBracket18_2.Text = season.Week05Team36;
                    picksBracket19_1.Text = season.Week05Team37;
                    picksBracket19_2.Text = season.Week05Team38;
                    picksBracket20_1.Text = season.Week05Team39;
                    picksBracket20_2.Text = season.Week05Team40;
                }
            }
        }
        private void BuildWeek06()
        {
            this.seasons1_5TableAdapter.Fill(this.seasonsDBDataSet.Seasons1_5);
            this.seasons6_10TableAdapter.Fill(this.seasonsDBDataSet.Seasons6_10);
            this.seasons11_17TableAdapter.Fill(this.seasonsDBDataSet.Seasons11_17);
            foreach (SeasonsDBDataSet.Seasons6_10Row season in seasonsDBDataSet.Seasons6_10)
            {
                if (season.SeasonName == textBoxSelectedSeason.Text)
                {
                    picksBracket01_1.Text = season.Week06Team01;
                    picksBracket01_2.Text = season.Week06Team02;
                    picksBracket02_1.Text = season.Week06Team03;
                    picksBracket02_2.Text = season.Week06Team04;
                    picksBracket03_1.Text = season.Week06Team05;
                    picksBracket03_2.Text = season.Week06Team06;
                    picksBracket04_1.Text = season.Week06Team07;
                    picksBracket04_2.Text = season.Week06Team08;
                    picksBracket05_1.Text = season.Week06Team09;
                    picksBracket05_2.Text = season.Week06Team10;
                    picksBracket06_1.Text = season.Week06Team11;
                    picksBracket06_2.Text = season.Week06Team12;
                    picksBracket07_1.Text = season.Week06Team13;
                    picksBracket07_2.Text = season.Week06Team14;
                    picksBracket08_1.Text = season.Week06Team15;
                    picksBracket08_2.Text = season.Week06Team16;
                    picksBracket09_1.Text = season.Week06Team17;
                    picksBracket09_2.Text = season.Week06Team18;
                    picksBracket10_1.Text = season.Week06Team19;
                    picksBracket10_2.Text = season.Week06Team20;
                    picksBracket11_1.Text = season.Week06Team21;
                    picksBracket11_2.Text = season.Week06Team22;
                    picksBracket12_1.Text = season.Week06Team23;
                    picksBracket12_2.Text = season.Week06Team24;
                    picksBracket13_1.Text = season.Week06Team25;
                    picksBracket13_2.Text = season.Week06Team26;
                    picksBracket14_1.Text = season.Week06Team27;
                    picksBracket14_2.Text = season.Week06Team28;
                    picksBracket15_1.Text = season.Week06Team29;
                    picksBracket15_2.Text = season.Week06Team30;
                    picksBracket16_1.Text = season.Week06Team31;
                    picksBracket16_2.Text = season.Week06Team32;
                    picksBracket17_1.Text = season.Week06Team33;
                    picksBracket17_2.Text = season.Week06Team34;
                    picksBracket18_1.Text = season.Week06Team35;
                    picksBracket18_2.Text = season.Week06Team36;
                    picksBracket19_1.Text = season.Week06Team37;
                    picksBracket19_2.Text = season.Week06Team38;
                    picksBracket20_1.Text = season.Week06Team39;
                    picksBracket20_2.Text = season.Week06Team40;
                }
            }
        }
        private void BuildWeek07()
        {
            this.seasons1_5TableAdapter.Fill(this.seasonsDBDataSet.Seasons1_5);
            this.seasons6_10TableAdapter.Fill(this.seasonsDBDataSet.Seasons6_10);
            this.seasons11_17TableAdapter.Fill(this.seasonsDBDataSet.Seasons11_17);
            foreach (SeasonsDBDataSet.Seasons6_10Row season in seasonsDBDataSet.Seasons6_10)
            {
                if (season.SeasonName == textBoxSelectedSeason.Text)
                {
                    picksBracket01_1.Text = season.Week07Team01;
                    picksBracket01_2.Text = season.Week07Team02;
                    picksBracket02_1.Text = season.Week07Team03;
                    picksBracket02_2.Text = season.Week07Team04;
                    picksBracket03_1.Text = season.Week07Team05;
                    picksBracket03_2.Text = season.Week07Team06;
                    picksBracket04_1.Text = season.Week07Team07;
                    picksBracket04_2.Text = season.Week07Team08;
                    picksBracket05_1.Text = season.Week07Team09;
                    picksBracket05_2.Text = season.Week07Team10;
                    picksBracket06_1.Text = season.Week07Team11;
                    picksBracket06_2.Text = season.Week07Team12;
                    picksBracket07_1.Text = season.Week07Team13;
                    picksBracket07_2.Text = season.Week07Team14;
                    picksBracket08_1.Text = season.Week07Team15;
                    picksBracket08_2.Text = season.Week07Team16;
                    picksBracket09_1.Text = season.Week07Team17;
                    picksBracket09_2.Text = season.Week07Team18;
                    picksBracket10_1.Text = season.Week07Team19;
                    picksBracket10_2.Text = season.Week07Team20;
                    picksBracket11_1.Text = season.Week07Team21;
                    picksBracket11_2.Text = season.Week07Team22;
                    picksBracket12_1.Text = season.Week07Team23;
                    picksBracket12_2.Text = season.Week07Team24;
                    picksBracket13_1.Text = season.Week07Team25;
                    picksBracket13_2.Text = season.Week07Team26;
                    picksBracket14_1.Text = season.Week07Team27;
                    picksBracket14_2.Text = season.Week07Team28;
                    picksBracket15_1.Text = season.Week07Team29;
                    picksBracket15_2.Text = season.Week07Team30;
                    picksBracket16_1.Text = season.Week07Team31;
                    picksBracket16_2.Text = season.Week07Team32;
                    picksBracket17_1.Text = season.Week07Team33;
                    picksBracket17_2.Text = season.Week07Team34;
                    picksBracket18_1.Text = season.Week07Team35;
                    picksBracket18_2.Text = season.Week07Team36;
                    picksBracket19_1.Text = season.Week07Team37;
                    picksBracket19_2.Text = season.Week07Team38;
                    picksBracket20_1.Text = season.Week07Team39;
                    picksBracket20_2.Text = season.Week07Team40;
                }
            }
        }
        private void BuildWeek08()
        {
            this.seasons1_5TableAdapter.Fill(this.seasonsDBDataSet.Seasons1_5);
            this.seasons6_10TableAdapter.Fill(this.seasonsDBDataSet.Seasons6_10);
            this.seasons11_17TableAdapter.Fill(this.seasonsDBDataSet.Seasons11_17);
            foreach (SeasonsDBDataSet.Seasons6_10Row season in seasonsDBDataSet.Seasons6_10)
            {
                if (season.SeasonName == textBoxSelectedSeason.Text)
                {
                    picksBracket01_1.Text = season.Week08Team01;
                    picksBracket01_2.Text = season.Week08Team02;
                    picksBracket02_1.Text = season.Week08Team03;
                    picksBracket02_2.Text = season.Week08Team04;
                    picksBracket03_1.Text = season.Week08Team05;
                    picksBracket03_2.Text = season.Week08Team06;
                    picksBracket04_1.Text = season.Week08Team07;
                    picksBracket04_2.Text = season.Week08Team08;
                    picksBracket05_1.Text = season.Week08Team09;
                    picksBracket05_2.Text = season.Week08Team10;
                    picksBracket06_1.Text = season.Week08Team11;
                    picksBracket06_2.Text = season.Week08Team12;
                    picksBracket07_1.Text = season.Week08Team13;
                    picksBracket07_2.Text = season.Week08Team14;
                    picksBracket08_1.Text = season.Week08Team15;
                    picksBracket08_2.Text = season.Week08Team16;
                    picksBracket09_1.Text = season.Week08Team17;
                    picksBracket09_2.Text = season.Week08Team18;
                    picksBracket10_1.Text = season.Week08Team19;
                    picksBracket10_2.Text = season.Week08Team20;
                    picksBracket11_1.Text = season.Week08Team21;
                    picksBracket11_2.Text = season.Week08Team22;
                    picksBracket12_1.Text = season.Week08Team23;
                    picksBracket12_2.Text = season.Week08Team24;
                    picksBracket13_1.Text = season.Week08Team25;
                    picksBracket13_2.Text = season.Week08Team26;
                    picksBracket14_1.Text = season.Week08Team27;
                    picksBracket14_2.Text = season.Week08Team28;
                    picksBracket15_1.Text = season.Week08Team29;
                    picksBracket15_2.Text = season.Week08Team30;
                    picksBracket16_1.Text = season.Week08Team31;
                    picksBracket16_2.Text = season.Week08Team32;
                    picksBracket17_1.Text = season.Week08Team33;
                    picksBracket17_2.Text = season.Week08Team34;
                    picksBracket18_1.Text = season.Week08Team35;
                    picksBracket18_2.Text = season.Week08Team36;
                    picksBracket19_1.Text = season.Week08Team37;
                    picksBracket19_2.Text = season.Week08Team38;
                    picksBracket20_1.Text = season.Week08Team39;
                    picksBracket20_2.Text = season.Week08Team40;
                }
            }
        }
        private void BuildWeek09()
        {
            this.seasons1_5TableAdapter.Fill(this.seasonsDBDataSet.Seasons1_5);
            this.seasons6_10TableAdapter.Fill(this.seasonsDBDataSet.Seasons6_10);
            this.seasons11_17TableAdapter.Fill(this.seasonsDBDataSet.Seasons11_17);
            foreach (SeasonsDBDataSet.Seasons6_10Row season in seasonsDBDataSet.Seasons6_10)
            {
                if (season.SeasonName == textBoxSelectedSeason.Text)
                {
                    picksBracket01_1.Text = season.Week09Team01;
                    picksBracket01_2.Text = season.Week09Team02;
                    picksBracket02_1.Text = season.Week09Team03;
                    picksBracket02_2.Text = season.Week09Team04;
                    picksBracket03_1.Text = season.Week09Team05;
                    picksBracket03_2.Text = season.Week09Team06;
                    picksBracket04_1.Text = season.Week09Team07;
                    picksBracket04_2.Text = season.Week09Team08;
                    picksBracket05_1.Text = season.Week09Team09;
                    picksBracket05_2.Text = season.Week09Team10;
                    picksBracket06_1.Text = season.Week09Team11;
                    picksBracket06_2.Text = season.Week09Team12;
                    picksBracket07_1.Text = season.Week09Team13;
                    picksBracket07_2.Text = season.Week09Team14;
                    picksBracket08_1.Text = season.Week09Team15;
                    picksBracket08_2.Text = season.Week09Team16;
                    picksBracket09_1.Text = season.Week09Team17;
                    picksBracket09_2.Text = season.Week09Team18;
                    picksBracket10_1.Text = season.Week09Team19;
                    picksBracket10_2.Text = season.Week09Team20;
                    picksBracket11_1.Text = season.Week09Team21;
                    picksBracket11_2.Text = season.Week09Team22;
                    picksBracket12_1.Text = season.Week09Team23;
                    picksBracket12_2.Text = season.Week09Team24;
                    picksBracket13_1.Text = season.Week09Team25;
                    picksBracket13_2.Text = season.Week09Team26;
                    picksBracket14_1.Text = season.Week09Team27;
                    picksBracket14_2.Text = season.Week09Team28;
                    picksBracket15_1.Text = season.Week09Team29;
                    picksBracket15_2.Text = season.Week09Team30;
                    picksBracket16_1.Text = season.Week09Team31;
                    picksBracket16_2.Text = season.Week09Team32;
                    picksBracket17_1.Text = season.Week09Team33;
                    picksBracket17_2.Text = season.Week09Team34;
                    picksBracket18_1.Text = season.Week09Team35;
                    picksBracket18_2.Text = season.Week09Team36;
                    picksBracket19_1.Text = season.Week09Team37;
                    picksBracket19_2.Text = season.Week09Team38;
                    picksBracket20_1.Text = season.Week09Team39;
                    picksBracket20_2.Text = season.Week09Team40;
                }
            }
        }
        private void BuildWeek10()
        {
            this.seasons1_5TableAdapter.Fill(this.seasonsDBDataSet.Seasons1_5);
            this.seasons6_10TableAdapter.Fill(this.seasonsDBDataSet.Seasons6_10);
            this.seasons11_17TableAdapter.Fill(this.seasonsDBDataSet.Seasons11_17);
            foreach (SeasonsDBDataSet.Seasons6_10Row season in seasonsDBDataSet.Seasons6_10)
            {
                if (season.SeasonName == textBoxSelectedSeason.Text)
                {
                    picksBracket01_1.Text = season.Week10Team01;
                    picksBracket01_2.Text = season.Week10Team02;
                    picksBracket02_1.Text = season.Week10Team03;
                    picksBracket02_2.Text = season.Week10Team04;
                    picksBracket03_1.Text = season.Week10Team05;
                    picksBracket03_2.Text = season.Week10Team06;
                    picksBracket04_1.Text = season.Week10Team07;
                    picksBracket04_2.Text = season.Week10Team08;
                    picksBracket05_1.Text = season.Week10Team09;
                    picksBracket05_2.Text = season.Week10Team10;
                    picksBracket06_1.Text = season.Week10Team11;
                    picksBracket06_2.Text = season.Week10Team12;
                    picksBracket07_1.Text = season.Week10Team13;
                    picksBracket07_2.Text = season.Week10Team14;
                    picksBracket08_1.Text = season.Week10Team15;
                    picksBracket08_2.Text = season.Week10Team16;
                    picksBracket09_1.Text = season.Week10Team17;
                    picksBracket09_2.Text = season.Week10Team18;
                    picksBracket10_1.Text = season.Week10Team19;
                    picksBracket10_2.Text = season.Week10Team20;
                    picksBracket11_1.Text = season.Week10Team21;
                    picksBracket11_2.Text = season.Week10Team22;
                    picksBracket12_1.Text = season.Week10Team23;
                    picksBracket12_2.Text = season.Week10Team24;
                    picksBracket13_1.Text = season.Week10Team25;
                    picksBracket13_2.Text = season.Week10Team26;
                    picksBracket14_1.Text = season.Week10Team27;
                    picksBracket14_2.Text = season.Week10Team28;
                    picksBracket15_1.Text = season.Week10Team29;
                    picksBracket15_2.Text = season.Week10Team30;
                    picksBracket16_1.Text = season.Week10Team31;
                    picksBracket16_2.Text = season.Week10Team32;
                    picksBracket17_1.Text = season.Week10Team33;
                    picksBracket17_2.Text = season.Week10Team34;
                    picksBracket18_1.Text = season.Week10Team35;
                    picksBracket18_2.Text = season.Week10Team36;
                    picksBracket19_1.Text = season.Week10Team37;
                    picksBracket19_2.Text = season.Week10Team38;
                    picksBracket20_1.Text = season.Week10Team39;
                    picksBracket20_2.Text = season.Week10Team40;
                }
            }
        }
        private void BuildWeek11()
        {
            this.seasons1_5TableAdapter.Fill(this.seasonsDBDataSet.Seasons1_5);
            this.seasons6_10TableAdapter.Fill(this.seasonsDBDataSet.Seasons6_10);
            this.seasons11_17TableAdapter.Fill(this.seasonsDBDataSet.Seasons11_17);
            foreach (SeasonsDBDataSet.Seasons11_17Row season in seasonsDBDataSet.Seasons11_17)
            {
                if (season.SeasonName == textBoxSelectedSeason.Text)
                {
                    picksBracket01_1.Text = season.Week11Team01;
                    picksBracket01_2.Text = season.Week11Team02;
                    picksBracket02_1.Text = season.Week11Team03;
                    picksBracket02_2.Text = season.Week11Team04;
                    picksBracket03_1.Text = season.Week11Team05;
                    picksBracket03_2.Text = season.Week11Team06;
                    picksBracket04_1.Text = season.Week11Team07;
                    picksBracket04_2.Text = season.Week11Team08;
                    picksBracket05_1.Text = season.Week11Team09;
                    picksBracket05_2.Text = season.Week11Team10;
                    picksBracket06_1.Text = season.Week11Team11;
                    picksBracket06_2.Text = season.Week11Team12;
                    picksBracket07_1.Text = season.Week11Team13;
                    picksBracket07_2.Text = season.Week11Team14;
                    picksBracket08_1.Text = season.Week11Team15;
                    picksBracket08_2.Text = season.Week11Team16;
                    picksBracket09_1.Text = season.Week11Team17;
                    picksBracket09_2.Text = season.Week11Team18;
                    picksBracket10_1.Text = season.Week11Team19;
                    picksBracket10_2.Text = season.Week11Team20;
                    picksBracket11_1.Text = season.Week11Team21;
                    picksBracket11_2.Text = season.Week11Team22;
                    picksBracket12_1.Text = season.Week11Team23;
                    picksBracket12_2.Text = season.Week11Team24;
                    picksBracket13_1.Text = season.Week11Team25;
                    picksBracket13_2.Text = season.Week11Team26;
                    picksBracket14_1.Text = season.Week11Team27;
                    picksBracket14_2.Text = season.Week11Team28;
                    picksBracket15_1.Text = season.Week11Team29;
                    picksBracket15_2.Text = season.Week11Team30;
                    picksBracket16_1.Text = season.Week11Team31;
                    picksBracket16_2.Text = season.Week11Team32;
                    picksBracket17_1.Text = season.Week11Team33;
                    picksBracket17_2.Text = season.Week11Team34;
                    picksBracket18_1.Text = season.Week11Team35;
                    picksBracket18_2.Text = season.Week11Team36;
                    picksBracket19_1.Text = season.Week11Team37;
                    picksBracket19_2.Text = season.Week11Team38;
                    picksBracket20_1.Text = season.Week11Team39;
                    picksBracket20_2.Text = season.Week11Team40;
                }
            }
        }
        private void BuildWeek12()
        {
            this.seasons1_5TableAdapter.Fill(this.seasonsDBDataSet.Seasons1_5);
            this.seasons6_10TableAdapter.Fill(this.seasonsDBDataSet.Seasons6_10);
            this.seasons11_17TableAdapter.Fill(this.seasonsDBDataSet.Seasons11_17);
            foreach (SeasonsDBDataSet.Seasons11_17Row season in seasonsDBDataSet.Seasons11_17)
            {
                if (season.SeasonName == textBoxSelectedSeason.Text)
                {
                    picksBracket01_1.Text = season.Week12Team01;
                    picksBracket01_2.Text = season.Week12Team02;
                    picksBracket02_1.Text = season.Week12Team03;
                    picksBracket02_2.Text = season.Week12Team04;
                    picksBracket03_1.Text = season.Week12Team05;
                    picksBracket03_2.Text = season.Week12Team06;
                    picksBracket04_1.Text = season.Week12Team07;
                    picksBracket04_2.Text = season.Week12Team08;
                    picksBracket05_1.Text = season.Week12Team09;
                    picksBracket05_2.Text = season.Week12Team10;
                    picksBracket06_1.Text = season.Week12Team11;
                    picksBracket06_2.Text = season.Week12Team12;
                    picksBracket07_1.Text = season.Week12Team13;
                    picksBracket07_2.Text = season.Week12Team14;
                    picksBracket08_1.Text = season.Week12Team15;
                    picksBracket08_2.Text = season.Week12Team16;
                    picksBracket09_1.Text = season.Week12Team17;
                    picksBracket09_2.Text = season.Week12Team18;
                    picksBracket10_1.Text = season.Week12Team19;
                    picksBracket10_2.Text = season.Week12Team20;
                    picksBracket11_1.Text = season.Week12Team21;
                    picksBracket11_2.Text = season.Week12Team22;
                    picksBracket12_1.Text = season.Week12Team23;
                    picksBracket12_2.Text = season.Week12Team24;
                    picksBracket13_1.Text = season.Week12Team25;
                    picksBracket13_2.Text = season.Week12Team26;
                    picksBracket14_1.Text = season.Week12Team27;
                    picksBracket14_2.Text = season.Week12Team28;
                    picksBracket15_1.Text = season.Week12Team29;
                    picksBracket15_2.Text = season.Week12Team30;
                    picksBracket16_1.Text = season.Week12Team31;
                    picksBracket16_2.Text = season.Week12Team32;
                    picksBracket17_1.Text = season.Week12Team33;
                    picksBracket17_2.Text = season.Week12Team34;
                    picksBracket18_1.Text = season.Week12Team35;
                    picksBracket18_2.Text = season.Week12Team36;
                    picksBracket19_1.Text = season.Week12Team37;
                    picksBracket19_2.Text = season.Week12Team38;
                    picksBracket20_1.Text = season.Week12Team39;
                    picksBracket20_2.Text = season.Week12Team40;
                }
            }
        }
        private void BuildWeek13()
        {
            this.seasons1_5TableAdapter.Fill(this.seasonsDBDataSet.Seasons1_5);
            this.seasons6_10TableAdapter.Fill(this.seasonsDBDataSet.Seasons6_10);
            this.seasons11_17TableAdapter.Fill(this.seasonsDBDataSet.Seasons11_17);
            foreach (SeasonsDBDataSet.Seasons11_17Row season in seasonsDBDataSet.Seasons11_17)
            {
                if (season.SeasonName == textBoxSelectedSeason.Text)
                {
                    picksBracket01_1.Text = season.Week13Team01;
                    picksBracket01_2.Text = season.Week13Team02;
                    picksBracket02_1.Text = season.Week13Team03;
                    picksBracket02_2.Text = season.Week13Team04;
                    picksBracket03_1.Text = season.Week13Team05;
                    picksBracket03_2.Text = season.Week13Team06;
                    picksBracket04_1.Text = season.Week13Team07;
                    picksBracket04_2.Text = season.Week13Team08;
                    picksBracket05_1.Text = season.Week13Team09;
                    picksBracket05_2.Text = season.Week13Team10;
                    picksBracket06_1.Text = season.Week13Team11;
                    picksBracket06_2.Text = season.Week13Team12;
                    picksBracket07_1.Text = season.Week13Team13;
                    picksBracket07_2.Text = season.Week13Team14;
                    picksBracket08_1.Text = season.Week13Team15;
                    picksBracket08_2.Text = season.Week13Team16;
                    picksBracket09_1.Text = season.Week13Team17;
                    picksBracket09_2.Text = season.Week13Team18;
                    picksBracket10_1.Text = season.Week13Team19;
                    picksBracket10_2.Text = season.Week13Team20;
                    picksBracket11_1.Text = season.Week13Team21;
                    picksBracket11_2.Text = season.Week13Team22;
                    picksBracket12_1.Text = season.Week13Team23;
                    picksBracket12_2.Text = season.Week13Team24;
                    picksBracket13_1.Text = season.Week13Team25;
                    picksBracket13_2.Text = season.Week13Team26;
                    picksBracket14_1.Text = season.Week13Team27;
                    picksBracket14_2.Text = season.Week13Team28;
                    picksBracket15_1.Text = season.Week13Team29;
                    picksBracket15_2.Text = season.Week13Team30;
                    picksBracket16_1.Text = season.Week13Team31;
                    picksBracket16_2.Text = season.Week13Team32;
                    picksBracket17_1.Text = season.Week13Team33;
                    picksBracket17_2.Text = season.Week13Team34;
                    picksBracket18_1.Text = season.Week13Team35;
                    picksBracket18_2.Text = season.Week13Team36;
                    picksBracket19_1.Text = season.Week13Team37;
                    picksBracket19_2.Text = season.Week13Team38;
                    picksBracket20_1.Text = season.Week13Team39;
                    picksBracket20_2.Text = season.Week13Team40;
                }
            }
        }
        private void BuildWeek14()
        {
            this.seasons1_5TableAdapter.Fill(this.seasonsDBDataSet.Seasons1_5);
            this.seasons6_10TableAdapter.Fill(this.seasonsDBDataSet.Seasons6_10);
            this.seasons11_17TableAdapter.Fill(this.seasonsDBDataSet.Seasons11_17);
            foreach (SeasonsDBDataSet.Seasons11_17Row season in seasonsDBDataSet.Seasons11_17)
            {
                if (season.SeasonName == textBoxSelectedSeason.Text)
                {
                    picksBracket01_1.Text = season.Week14Team01;
                    picksBracket01_2.Text = season.Week14Team02;
                    picksBracket02_1.Text = season.Week14Team03;
                    picksBracket02_2.Text = season.Week14Team04;
                    picksBracket03_1.Text = season.Week14Team05;
                    picksBracket03_2.Text = season.Week14Team06;
                    picksBracket04_1.Text = season.Week14Team07;
                    picksBracket04_2.Text = season.Week14Team08;
                    picksBracket05_1.Text = season.Week14Team09;
                    picksBracket05_2.Text = season.Week14Team10;
                    picksBracket06_1.Text = season.Week14Team11;
                    picksBracket06_2.Text = season.Week14Team12;
                    picksBracket07_1.Text = season.Week14Team13;
                    picksBracket07_2.Text = season.Week14Team14;
                    picksBracket08_1.Text = season.Week14Team15;
                    picksBracket08_2.Text = season.Week14Team16;
                    picksBracket09_1.Text = season.Week14Team17;
                    picksBracket09_2.Text = season.Week14Team18;
                    picksBracket10_1.Text = season.Week14Team19;
                    picksBracket10_2.Text = season.Week14Team20;
                    picksBracket11_1.Text = season.Week14Team21;
                    picksBracket11_2.Text = season.Week14Team22;
                    picksBracket12_1.Text = season.Week14Team23;
                    picksBracket12_2.Text = season.Week14Team24;
                    picksBracket13_1.Text = season.Week14Team25;
                    picksBracket13_2.Text = season.Week14Team26;
                    picksBracket14_1.Text = season.Week14Team27;
                    picksBracket14_2.Text = season.Week14Team28;
                    picksBracket15_1.Text = season.Week14Team29;
                    picksBracket15_2.Text = season.Week14Team30;
                    picksBracket16_1.Text = season.Week14Team31;
                    picksBracket16_2.Text = season.Week14Team32;
                    picksBracket17_1.Text = season.Week14Team33;
                    picksBracket17_2.Text = season.Week14Team34;
                    picksBracket18_1.Text = season.Week14Team35;
                    picksBracket18_2.Text = season.Week14Team36;
                    picksBracket19_1.Text = season.Week14Team37;
                    picksBracket19_2.Text = season.Week14Team38;
                    picksBracket20_1.Text = season.Week14Team39;
                    picksBracket20_2.Text = season.Week14Team40;
                }
            }
        }
        private void BuildWeek15()
        {
            this.seasons1_5TableAdapter.Fill(this.seasonsDBDataSet.Seasons1_5);
            this.seasons6_10TableAdapter.Fill(this.seasonsDBDataSet.Seasons6_10);
            this.seasons11_17TableAdapter.Fill(this.seasonsDBDataSet.Seasons11_17);
            foreach (SeasonsDBDataSet.Seasons11_17Row season in seasonsDBDataSet.Seasons11_17)
            {
                if (season.SeasonName == textBoxSelectedSeason.Text)
                {
                    picksBracket01_1.Text = season.Week15Team01;
                    picksBracket01_2.Text = season.Week15Team02;
                    picksBracket02_1.Text = season.Week15Team03;
                    picksBracket02_2.Text = season.Week15Team04;
                    picksBracket03_1.Text = season.Week15Team05;
                    picksBracket03_2.Text = season.Week15Team06;
                    picksBracket04_1.Text = season.Week15Team07;
                    picksBracket04_2.Text = season.Week15Team08;
                    picksBracket05_1.Text = season.Week15Team09;
                    picksBracket05_2.Text = season.Week15Team10;
                    picksBracket06_1.Text = season.Week15Team11;
                    picksBracket06_2.Text = season.Week15Team12;
                    picksBracket07_1.Text = season.Week15Team13;
                    picksBracket07_2.Text = season.Week15Team14;
                    picksBracket08_1.Text = season.Week15Team15;
                    picksBracket08_2.Text = season.Week15Team16;
                    picksBracket09_1.Text = season.Week15Team17;
                    picksBracket09_2.Text = season.Week15Team18;
                    picksBracket10_1.Text = season.Week15Team19;
                    picksBracket10_2.Text = season.Week15Team20;
                    picksBracket11_1.Text = season.Week15Team21;
                    picksBracket11_2.Text = season.Week15Team22;
                    picksBracket12_1.Text = season.Week15Team23;
                    picksBracket12_2.Text = season.Week15Team24;
                    picksBracket13_1.Text = season.Week15Team25;
                    picksBracket13_2.Text = season.Week15Team26;
                    picksBracket14_1.Text = season.Week15Team27;
                    picksBracket14_2.Text = season.Week15Team28;
                    picksBracket15_1.Text = season.Week15Team29;
                    picksBracket15_2.Text = season.Week15Team30;
                    picksBracket16_1.Text = season.Week15Team31;
                    picksBracket16_2.Text = season.Week15Team32;
                    picksBracket17_1.Text = season.Week15Team33;
                    picksBracket17_2.Text = season.Week15Team34;
                    picksBracket18_1.Text = season.Week15Team35;
                    picksBracket18_2.Text = season.Week15Team36;
                    picksBracket19_1.Text = season.Week15Team37;
                    picksBracket19_2.Text = season.Week15Team38;
                    picksBracket20_1.Text = season.Week15Team39;
                    picksBracket20_2.Text = season.Week15Team40;
                }
            }
        }
        private void BuildWeek16()
        {
            this.seasons1_5TableAdapter.Fill(this.seasonsDBDataSet.Seasons1_5);
            this.seasons6_10TableAdapter.Fill(this.seasonsDBDataSet.Seasons6_10);
            this.seasons11_17TableAdapter.Fill(this.seasonsDBDataSet.Seasons11_17);
            foreach (SeasonsDBDataSet.Seasons11_17Row season in seasonsDBDataSet.Seasons11_17)
            {
                if (season.SeasonName == textBoxSelectedSeason.Text)
                {
                    picksBracket01_1.Text = season.Week16Team01;
                    picksBracket01_2.Text = season.Week16Team02;
                    picksBracket02_1.Text = season.Week16Team03;
                    picksBracket02_2.Text = season.Week16Team04;
                    picksBracket03_1.Text = season.Week16Team05;
                    picksBracket03_2.Text = season.Week16Team06;
                    picksBracket04_1.Text = season.Week16Team07;
                    picksBracket04_2.Text = season.Week16Team08;
                    picksBracket05_1.Text = season.Week16Team09;
                    picksBracket05_2.Text = season.Week16Team10;
                    picksBracket06_1.Text = season.Week16Team11;
                    picksBracket06_2.Text = season.Week16Team12;
                    picksBracket07_1.Text = season.Week16Team13;
                    picksBracket07_2.Text = season.Week16Team14;
                    picksBracket08_1.Text = season.Week16Team15;
                    picksBracket08_2.Text = season.Week16Team16;
                    picksBracket09_1.Text = season.Week16Team17;
                    picksBracket09_2.Text = season.Week16Team18;
                    picksBracket10_1.Text = season.Week16Team19;
                    picksBracket10_2.Text = season.Week16Team20;
                    picksBracket11_1.Text = season.Week16Team21;
                    picksBracket11_2.Text = season.Week16Team22;
                    picksBracket12_1.Text = season.Week16Team23;
                    picksBracket12_2.Text = season.Week16Team24;
                    picksBracket13_1.Text = season.Week16Team25;
                    picksBracket13_2.Text = season.Week16Team26;
                    picksBracket14_1.Text = season.Week16Team27;
                    picksBracket14_2.Text = season.Week16Team28;
                    picksBracket15_1.Text = season.Week16Team29;
                    picksBracket15_2.Text = season.Week16Team30;
                    picksBracket16_1.Text = season.Week16Team31;
                    picksBracket16_2.Text = season.Week16Team32;
                    picksBracket17_1.Text = season.Week16Team33;
                    picksBracket17_2.Text = season.Week16Team34;
                    picksBracket18_1.Text = season.Week16Team35;
                    picksBracket18_2.Text = season.Week16Team36;
                    picksBracket19_1.Text = season.Week16Team37;
                    picksBracket19_2.Text = season.Week16Team38;
                    picksBracket20_1.Text = season.Week16Team39;
                    picksBracket20_2.Text = season.Week16Team40;
                }
            }
        }
        private void BuildWeek17()
        {
            this.seasons1_5TableAdapter.Fill(this.seasonsDBDataSet.Seasons1_5);
            this.seasons6_10TableAdapter.Fill(this.seasonsDBDataSet.Seasons6_10);
            this.seasons11_17TableAdapter.Fill(this.seasonsDBDataSet.Seasons11_17);
            foreach (SeasonsDBDataSet.Seasons11_17Row season in seasonsDBDataSet.Seasons11_17)
            {
                if (season.SeasonName == textBoxSelectedSeason.Text)
                {
                    picksBracket01_1.Text = season.Week17Team01;
                    picksBracket01_2.Text = season.Week17Team02;
                    picksBracket02_1.Text = season.Week17Team03;
                    picksBracket02_2.Text = season.Week17Team04;
                    picksBracket03_1.Text = season.Week17Team05;
                    picksBracket03_2.Text = season.Week17Team06;
                    picksBracket04_1.Text = season.Week17Team07;
                    picksBracket04_2.Text = season.Week17Team08;
                    picksBracket05_1.Text = season.Week17Team09;
                    picksBracket05_2.Text = season.Week17Team10;
                    picksBracket06_1.Text = season.Week17Team11;
                    picksBracket06_2.Text = season.Week17Team12;
                    picksBracket07_1.Text = season.Week17Team13;
                    picksBracket07_2.Text = season.Week17Team14;
                    picksBracket08_1.Text = season.Week17Team15;
                    picksBracket08_2.Text = season.Week17Team16;
                    picksBracket09_1.Text = season.Week17Team17;
                    picksBracket09_2.Text = season.Week17Team18;
                    picksBracket10_1.Text = season.Week17Team19;
                    picksBracket10_2.Text = season.Week17Team20;
                    picksBracket11_1.Text = season.Week17Team21;
                    picksBracket11_2.Text = season.Week17Team22;
                    picksBracket12_1.Text = season.Week17Team23;
                    picksBracket12_2.Text = season.Week17Team24;
                    picksBracket13_1.Text = season.Week17Team25;
                    picksBracket13_2.Text = season.Week17Team26;
                    picksBracket14_1.Text = season.Week17Team27;
                    picksBracket14_2.Text = season.Week17Team28;
                    picksBracket15_1.Text = season.Week17Team29;
                    picksBracket15_2.Text = season.Week17Team30;
                    picksBracket16_1.Text = season.Week17Team31;
                    picksBracket16_2.Text = season.Week17Team32;
                    picksBracket17_1.Text = season.Week17Team33;
                    picksBracket17_2.Text = season.Week17Team34;
                    picksBracket18_1.Text = season.Week17Team35;
                    picksBracket18_2.Text = season.Week17Team36;
                    picksBracket19_1.Text = season.Week17Team37;
                    picksBracket19_2.Text = season.Week17Team38;
                    picksBracket20_1.Text = season.Week17Team39;
                    picksBracket20_2.Text = season.Week17Team40;
                }
            }
        }

        private void listBoxPlayerListPicks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPlayerListPicks.SelectedIndex != -1)
            {
                labelPlayerNameLargePicks.Text = listBoxPlayerListPicks.SelectedItem.ToString();
                LoadPlayerPicks();
            }
            // need to fill text boxes based on the saved picks for each player each week.
            // Maybe build loadPlayer() method to find the player in the database and load his picks.
            // LoadPlayer(selectedPlayer);
        }

        private void ApplyPicks()
        {
            List<String> checkBoxList = new List<String>();
            List<String> pickNumbers = new List<string>();
            string tempString;

            // make sure a player is selected
            if (listBoxPlayerListPicks.SelectedIndex != -1)
            {
                // find the selected player in the database
                foreach (PlayersDBDataSet.PlayersRow selectedPlayer in playersDBDataSet.Players)
                {
                    // if the player matches then apply the picks
                    if (selectedPlayer.PlayerPoolName == listBoxPlayerListPicks.SelectedItem.ToString())
                    {
                        foreach (CheckBox checkBox in CheckBoxes)
                        {
                            if (checkBox.Checked)
                            {
                                checkBoxList.Add(checkBox.Text);
                                // need to make a non pick a 0
                                foreach (TextBox textBox in TextBoxes)
                                {
                                    if (textBox.Visible == true && textBox.Text == "")
                                    {
                                        checkBoxList.Add("0");
                                    }
                                }
                                pickNumbers.Add(checkBox.Tag.ToString());
                            }
                        }

                        if (comboBoxSelectWeekPicks.Text == "Week 01")
                        {
                            // creates a string using the check boxes with comma seperator
                            tempString = string.Join(",", checkBoxList.ToArray());
                            // make PicksWeek01 the now comma seperated string
                            selectedPlayer.PicksWeek01 = tempString;                          
                            tempString = "";
                        }
                        if (comboBoxSelectWeekPicks.Text == "Week 02")
                        {
                            // creates a string using the check boxes with comma seperator
                            tempString = string.Join(",", checkBoxList.ToArray());
                            // make PicksWeek01 the now comma seperated string
                            selectedPlayer.PicksWeek02 = tempString;
                            tempString = "";
                        }
                        if (comboBoxSelectWeekPicks.Text == "Week 03")
                        {
                            // creates a string using the check boxes with comma seperator
                            tempString = string.Join(",", checkBoxList.ToArray());
                            // make PicksWeek01 the now comma seperated string
                            selectedPlayer.PicksWeek03 = tempString;
                            tempString = "";
                        }
                        if (comboBoxSelectWeekPicks.Text == "Week 04")
                        {
                            // creates a string using the check boxes with comma seperator
                            tempString = string.Join(",", checkBoxList.ToArray());
                            // make PicksWeek01 the now comma seperated string
                            selectedPlayer.PicksWeek04 = tempString;
                            tempString = "";
                        }
                        if (comboBoxSelectWeekPicks.Text == "Week 05")
                        {
                            // creates a string using the check boxes with comma seperator
                            tempString = string.Join(",", checkBoxList.ToArray());
                            // make PicksWeek01 the now comma seperated string
                            selectedPlayer.PicksWeek05 = tempString;
                            tempString = "";
                        }
                        if (comboBoxSelectWeekPicks.Text == "Week 06")
                        {
                            // creates a string using the check boxes with comma seperator
                            tempString = string.Join(",", checkBoxList.ToArray());
                            // make PicksWeek01 the now comma seperated string
                            selectedPlayer.PicksWeek06 = tempString;
                            tempString = "";
                        }
                        if (comboBoxSelectWeekPicks.Text == "Week 07")
                        {
                            // creates a string using the check boxes with comma seperator
                            tempString = string.Join(",", checkBoxList.ToArray());
                            // make PicksWeek01 the now comma seperated string
                            selectedPlayer.PicksWeek07 = tempString;
                            tempString = "";
                        }
                        if (comboBoxSelectWeekPicks.Text == "Week 08")
                        {
                            // creates a string using the check boxes with comma seperator
                            tempString = string.Join(",", checkBoxList.ToArray());
                            // make PicksWeek01 the now comma seperated string
                            selectedPlayer.PicksWeek08 = tempString;
                            tempString = "";
                        }
                        if (comboBoxSelectWeekPicks.Text == "Week 09")
                        {
                            // creates a string using the check boxes with comma seperator
                            tempString = string.Join(",", checkBoxList.ToArray());
                            // make PicksWeek01 the now comma seperated string
                            selectedPlayer.PicksWeek09 = tempString;
                            tempString = "";
                        }
                        if (comboBoxSelectWeekPicks.Text == "Week 10")
                        {
                            // creates a string using the check boxes with comma seperator
                            tempString = string.Join(",", checkBoxList.ToArray());
                            // make PicksWeek01 the now comma seperated string
                            selectedPlayer.PicksWeek10 = tempString;
                            tempString = "";
                        }
                        if (comboBoxSelectWeekPicks.Text == "Week 11")
                        {
                            // creates a string using the check boxes with comma seperator
                            tempString = string.Join(",", checkBoxList.ToArray());
                            // make PicksWeek01 the now comma seperated string
                            selectedPlayer.PicksWeek11 = tempString;
                            tempString = "";
                        }
                        if (comboBoxSelectWeekPicks.Text == "Week 12")
                        {
                            // creates a string using the check boxes with comma seperator
                            tempString = string.Join(",", checkBoxList.ToArray());
                            // make PicksWeek01 the now comma seperated string
                            selectedPlayer.PicksWeek12 = tempString;
                            tempString = "";
                        }
                        if (comboBoxSelectWeekPicks.Text == "Week 13")
                        {
                            // creates a string using the check boxes with comma seperator
                            tempString = string.Join(",", checkBoxList.ToArray());
                            // make PicksWeek01 the now comma seperated string
                            selectedPlayer.PicksWeek13 = tempString;
                            tempString = "";
                        }
                        if (comboBoxSelectWeekPicks.Text == "Week 14")
                        {
                            // creates a string using the check boxes with comma seperator
                            tempString = string.Join(",", checkBoxList.ToArray());
                            // make PicksWeek01 the now comma seperated string
                            selectedPlayer.PicksWeek14 = tempString;
                        }
                        if (comboBoxSelectWeekPicks.Text == "Week 15")
                        {
                            // creates a string using the check boxes with comma seperator
                            tempString = string.Join(",", checkBoxList.ToArray());
                            // make PicksWeek01 the now comma seperated string
                            selectedPlayer.PicksWeek15 = tempString;
                            tempString = "";
                        }
                        if (comboBoxSelectWeekPicks.Text == "Week 16")
                        {
                            // creates a string using the check boxes with comma seperator
                            tempString = string.Join(",", checkBoxList.ToArray());
                            // make PicksWeek01 the now comma seperated string
                            selectedPlayer.PicksWeek16 = tempString;
                            tempString = "";
                        }
                        if (comboBoxSelectWeekPicks.Text == "Week 17")
                        {
                            // creates a string using the check boxes with comma seperator
                            tempString = string.Join(",", checkBoxList.ToArray());
                            // make PicksWeek01 the now comma seperated string
                            selectedPlayer.PicksWeek17 = tempString;
                            tempString = "";
                        }

                        // adding the actual number of the pick to database so i can populate the master sheet later
                        if (pickNumbers.Count >= 1)
                        {
                            selectedPlayer.Pick01 = pickNumbers[0];
                        }
                        if (pickNumbers.Count >= 2)
                        {
                            selectedPlayer.Pick02 = pickNumbers[1];
                        }
                        if (pickNumbers.Count >= 3)
                        {
                            selectedPlayer.Pick03 = pickNumbers[2];
                        }
                        if (pickNumbers.Count >= 4)
                        {
                            selectedPlayer.Pick04 = pickNumbers[3];
                        }
                        if (pickNumbers.Count >= 5)
                        {
                            selectedPlayer.Pick05 = pickNumbers[4];
                        }
                        if (pickNumbers.Count >= 6)
                        {
                            selectedPlayer.Pick06 = pickNumbers[5];
                        }
                        if (pickNumbers.Count >= 7)
                        {
                            selectedPlayer.Pick07 = pickNumbers[6];
                        }
                        if (pickNumbers.Count >= 8)
                        {
                            selectedPlayer.Pick08 = pickNumbers[7];
                        }
                        if (pickNumbers.Count >= 9)
                        {
                            selectedPlayer.Pick09 = pickNumbers[8];
                        }
                        if (pickNumbers.Count >= 10)
                        {
                            selectedPlayer.Pick10 = pickNumbers[9];
                        }
                        if (pickNumbers.Count >= 11)
                        {
                            selectedPlayer.Pick11 = pickNumbers[10];
                        }
                        if (pickNumbers.Count >= 12)
                        {
                            selectedPlayer.Pick12 = pickNumbers[11];
                        }
                        if (pickNumbers.Count >= 13)
                        {
                            selectedPlayer.Pick13 = pickNumbers[12];
                        }
                        if (pickNumbers.Count >= 14)
                        {
                            selectedPlayer.Pick14 = pickNumbers[13];
                        }
                        if (pickNumbers.Count >= 15)
                        {
                            selectedPlayer.Pick15 = pickNumbers[14];
                        }
                        if (pickNumbers.Count >= 16)
                        {
                            selectedPlayer.Pick16 = pickNumbers[15];
                        }
                        if (pickNumbers.Count >= 17)
                        {
                            selectedPlayer.Pick17 = pickNumbers[16];
                        }
                        if (pickNumbers.Count >= 18)
                        {
                            selectedPlayer.Pick18 = pickNumbers[17];
                        }
                        if (pickNumbers.Count >= 19)
                        {
                            selectedPlayer.Pick19 = pickNumbers[18];
                        }
                        if (pickNumbers.Count >= 20)
                        {
                            selectedPlayer.Pick20 = pickNumbers[19];
                        }

                        // update database
                        this.Validate();
                        this.playersBindingSource.EndEdit();
                        this.tableAdapterManager.UpdateAll(this.playersDBDataSet);
                        return;
                    }           
                }
            }
        }

        private void buttonConfirmPicksPicks_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            ApplyPicks();

            if (listBoxPlayerListPicks.SelectedIndex != -1)
            {
                foreach (PlayersDBDataSet.PlayersRow selectedPlayer in playersDBDataSet.Players)
                {
                    if (selectedPlayer.PlayerPoolName == listBoxPlayerListPicks.SelectedItem.ToString())
                    {
                        textBoxConfirmation.Text = selectedPlayer.PlayerPoolName + " " + comboBoxSelectWeekPicks.Text + " picks have been entered.";
                        break;
                    }
                }

                textBoxSearchPlayerPicks.Clear();
                textBoxSearchPlayerPicks.Focus();
            }
        }

        private void LoadPlayerPicks()
        {
            //if the player has saved picks for that week then need to check the boxes and fill the text boxes.
            // if not then need to uncheck the boxes and empty the text boxes
            // need to convert the Player.Picks to a list so I can find each pick for the week.
            // it is seperated by commas.

            SeasonsDBDataSet.Seasons1_5Row tempSeason1_5 = FindSeason1_5();
            SeasonsDBDataSet.Seasons6_10Row tempSeason6_10 = FindSeason6_10();
            SeasonsDBDataSet.Seasons11_17Row tempSeason11_17 = FindSeason11_17();

            foreach (PlayersDBDataSet.PlayersRow selectedPlayer in playersDBDataSet.Players)
            {
                if (listBoxPlayerListPicks.SelectedIndex != -1)
                {
                    if (selectedPlayer.PlayerPoolName == listBoxPlayerListPicks.SelectedItem.ToString())
                    {
                        // need to build the picks list and check boxes if there are picks
                        if (comboBoxSelectWeekPicks.Text == "Week 01" && selectedPlayer.PicksWeek01 != "")
                        {
                            // split the PicksWeek01 string
                            string[] playerPicks = selectedPlayer.PicksWeek01.Split(',');

                            // create temp list for those split strings
                            List<string> tempList = new List<string>(playerPicks);

                            foreach (CheckBox checkBoxes in CheckBoxes)
                            {
                                if (tempList.Contains(checkBoxes.Text))
                                {
                                    checkBoxes.Checked = true;
                                }
                                else
                                {
                                    checkBoxes.Checked = false;
                                }
                            }
                        }
                        else if (comboBoxSelectWeekPicks.Text == "Week 02" && selectedPlayer.PicksWeek02 != "")
                        {
                            // split the PicksWeek01 string
                            string[] playerPicks = selectedPlayer.PicksWeek02.Split(',');

                            // create temp list for those split strings
                            List<string> tempList = new List<string>(playerPicks);

                            foreach (CheckBox checkBoxes in CheckBoxes)
                            {
                                if (tempList.Contains(checkBoxes.Text))
                                {
                                    checkBoxes.Checked = true;
                                }
                                else
                                {
                                    checkBoxes.Checked = false;
                                }
                            }
                        }
                        else if (comboBoxSelectWeekPicks.Text == "Week 03" && selectedPlayer.PicksWeek03 != "")
                        {
                            // split the PicksWeek01 string
                            string[] playerPicks = selectedPlayer.PicksWeek03.Split(',');

                            // create temp list for those split strings
                            List<string> tempList = new List<string>(playerPicks);

                            foreach (CheckBox checkBoxes in CheckBoxes)
                            {
                                if (tempList.Contains(checkBoxes.Text))
                                {
                                    checkBoxes.Checked = true;
                                }
                                else
                                {
                                    checkBoxes.Checked = false;
                                }
                            }
                        }
                        else if (comboBoxSelectWeekPicks.Text == "Week 04" && selectedPlayer.PicksWeek04 != "")
                        {
                            // split the PicksWeek01 string
                            string[] playerPicks = selectedPlayer.PicksWeek04.Split(',');

                            // create temp list for those split strings
                            List<string> tempList = new List<string>(playerPicks);

                            foreach (CheckBox checkBoxes in CheckBoxes)
                            {
                                if (tempList.Contains(checkBoxes.Text))
                                {
                                    checkBoxes.Checked = true;
                                }
                                else
                                {
                                    checkBoxes.Checked = false;
                                }
                            }
                        }
                        else if (comboBoxSelectWeekPicks.Text == "Week 05" && selectedPlayer.PicksWeek05 != "")
                        {
                            // split the PicksWeek01 string
                            string[] playerPicks = selectedPlayer.PicksWeek05.Split(',');

                            // create temp list for those split strings
                            List<string> tempList = new List<string>(playerPicks);

                            foreach (CheckBox checkBoxes in CheckBoxes)
                            {
                                if (tempList.Contains(checkBoxes.Text))
                                {
                                    checkBoxes.Checked = true;
                                }
                                else
                                {
                                    checkBoxes.Checked = false;
                                }
                            }
                        }
                        else if (comboBoxSelectWeekPicks.Text == "Week 06" && selectedPlayer.PicksWeek06 != "")
                        {
                            // split the PicksWeek01 string
                            string[] playerPicks = selectedPlayer.PicksWeek06.Split(',');

                            // create temp list for those split strings
                            List<string> tempList = new List<string>(playerPicks);

                            foreach (CheckBox checkBoxes in CheckBoxes)
                            {
                                if (tempList.Contains(checkBoxes.Text))
                                {
                                    checkBoxes.Checked = true;
                                }
                                else
                                {
                                    checkBoxes.Checked = false;
                                }
                            }
                        }
                        else if (comboBoxSelectWeekPicks.Text == "Week 07" && selectedPlayer.PicksWeek07 != "")
                        {
                            // split the PicksWeek01 string
                            string[] playerPicks = selectedPlayer.PicksWeek07.Split(',');

                            // create temp list for those split strings
                            List<string> tempList = new List<string>(playerPicks);

                            foreach (CheckBox checkBoxes in CheckBoxes)
                            {
                                if (tempList.Contains(checkBoxes.Text))
                                {
                                    checkBoxes.Checked = true;
                                }
                                else
                                {
                                    checkBoxes.Checked = false;
                                }
                            }
                        }
                        else if (comboBoxSelectWeekPicks.Text == "Week 08" && selectedPlayer.PicksWeek08 != "")
                        {
                            // split the PicksWeek01 string
                            string[] playerPicks = selectedPlayer.PicksWeek08.Split(',');

                            // create temp list for those split strings
                            List<string> tempList = new List<string>(playerPicks);

                            foreach (CheckBox checkBoxes in CheckBoxes)
                            {
                                if (tempList.Contains(checkBoxes.Text))
                                {
                                    checkBoxes.Checked = true;
                                }
                                else
                                {
                                    checkBoxes.Checked = false;
                                }
                            }
                        }
                        else if (comboBoxSelectWeekPicks.Text == "Week 09" && selectedPlayer.PicksWeek09 != "")
                        {
                            // split the PicksWeek01 string
                            string[] playerPicks = selectedPlayer.PicksWeek09.Split(',');

                            // create temp list for those split strings
                            List<string> tempList = new List<string>(playerPicks);

                            foreach (CheckBox checkBoxes in CheckBoxes)
                            {
                                if (tempList.Contains(checkBoxes.Text))
                                {
                                    checkBoxes.Checked = true;
                                }
                                else
                                {
                                    checkBoxes.Checked = false;
                                }
                            }
                        }
                        else if (comboBoxSelectWeekPicks.Text == "Week 10" && selectedPlayer.PicksWeek10 != "")
                        {
                            // split the PicksWeek01 string
                            string[] playerPicks = selectedPlayer.PicksWeek10.Split(',');

                            // create temp list for those split strings
                            List<string> tempList = new List<string>(playerPicks);

                            foreach (CheckBox checkBoxes in CheckBoxes)
                            {
                                if (tempList.Contains(checkBoxes.Text))
                                {
                                    checkBoxes.Checked = true;
                                }
                                else
                                {
                                    checkBoxes.Checked = false;
                                }
                            }
                        }
                        else if (comboBoxSelectWeekPicks.Text == "Week 11" && selectedPlayer.PicksWeek11 != "")
                        {
                            // split the PicksWeek01 string
                            string[] playerPicks = selectedPlayer.PicksWeek11.Split(',');

                            // create temp list for those split strings
                            List<string> tempList = new List<string>(playerPicks);

                            foreach (CheckBox checkBoxes in CheckBoxes)
                            {
                                if (tempList.Contains(checkBoxes.Text))
                                {
                                    checkBoxes.Checked = true;
                                }
                                else
                                {
                                    checkBoxes.Checked = false;
                                }
                            }
                        }
                        else if (comboBoxSelectWeekPicks.Text == "Week 12" && selectedPlayer.PicksWeek12 != "")
                        {
                            // split the PicksWeek01 string
                            string[] playerPicks = selectedPlayer.PicksWeek12.Split(',');

                            // create temp list for those split strings
                            List<string> tempList = new List<string>(playerPicks);

                            foreach (CheckBox checkBoxes in CheckBoxes)
                            {
                                if (tempList.Contains(checkBoxes.Text))
                                {
                                    checkBoxes.Checked = true;
                                }
                                else
                                {
                                    checkBoxes.Checked = false;
                                }
                            }
                        }
                        else if (comboBoxSelectWeekPicks.Text == "Week 13" && selectedPlayer.PicksWeek13 != "")
                        {
                            // split the PicksWeek01 string
                            string[] playerPicks = selectedPlayer.PicksWeek13.Split(',');

                            // create temp list for those split strings
                            List<string> tempList = new List<string>(playerPicks);

                            foreach (CheckBox checkBoxes in CheckBoxes)
                            {
                                if (tempList.Contains(checkBoxes.Text))
                                {
                                    checkBoxes.Checked = true;
                                }
                                else
                                {
                                    checkBoxes.Checked = false;
                                }
                            }
                        }
                        else if (comboBoxSelectWeekPicks.Text == "Week 14" && selectedPlayer.PicksWeek14 != "")
                        {
                            // split the PicksWeek01 string
                            string[] playerPicks = selectedPlayer.PicksWeek14.Split(',');

                            // create temp list for those split strings
                            List<string> tempList = new List<string>(playerPicks);

                            foreach (CheckBox checkBoxes in CheckBoxes)
                            {
                                if (tempList.Contains(checkBoxes.Text))
                                {
                                    checkBoxes.Checked = true;
                                }
                                else
                                {
                                    checkBoxes.Checked = false;
                                }
                            }
                        }
                        else if (comboBoxSelectWeekPicks.Text == "Week 15" && selectedPlayer.PicksWeek15 != "")
                        {
                            // split the PicksWeek01 string
                            string[] playerPicks = selectedPlayer.PicksWeek15.Split(',');

                            // create temp list for those split strings
                            List<string> tempList = new List<string>(playerPicks);

                            foreach (CheckBox checkBoxes in CheckBoxes)
                            {
                                if (tempList.Contains(checkBoxes.Text))
                                {
                                    checkBoxes.Checked = true;
                                }
                                else
                                {
                                    checkBoxes.Checked = false;
                                }
                            }
                        }
                        else if (comboBoxSelectWeekPicks.Text == "Week 16" && selectedPlayer.PicksWeek16 != "")
                        {
                            // split the PicksWeek01 string
                            string[] playerPicks = selectedPlayer.PicksWeek16.Split(',');

                            // create temp list for those split strings
                            List<string> tempList = new List<string>(playerPicks);

                            foreach (CheckBox checkBoxes in CheckBoxes)
                            {
                                if (tempList.Contains(checkBoxes.Text))
                                {
                                    checkBoxes.Checked = true;
                                }
                                else
                                {
                                    checkBoxes.Checked = false;
                                }
                            }
                        }
                        else if (comboBoxSelectWeekPicks.Text == "Week 17" && selectedPlayer.PicksWeek17 != "")
                        {
                            // split the PicksWeek01 string
                            string[] playerPicks = selectedPlayer.PicksWeek17.Split(',');

                            // create temp list for those split strings
                            List<string> tempList = new List<string>(playerPicks);

                            foreach (CheckBox checkBoxes in CheckBoxes)
                            {
                                if (tempList.Contains(checkBoxes.Text))
                                {
                                    checkBoxes.Checked = true;
                                }
                                else
                                {
                                    checkBoxes.Checked = false;
                                }
                            }
                        }
                        else
                        {
                            ClearBoxes();
                        }
                    }
                }
            }
            FillTextBox();
        }

        private void ClearBoxes()
        {
            foreach (CheckBox checkBoxes in CheckBoxes)
            {
                checkBoxes.Checked = false;
            }

            foreach (TextBox textBoxes in TextBoxes)
            {
                textBoxes.Clear();
            }
        }


        // I dont think I need this haha whoops. So messy.
        private void FindAndClearPicks()
        {
            // clear the check boxes and text boxes if player has no picks saved that week.
            foreach (PlayersDBDataSet.PlayersRow selectedPlayer in playersDBDataSet.Players)
            {
                // find the selected player
                if (selectedPlayer.PlayerPoolName == listBoxPlayerListPicks.SelectedItem.ToString())
                {
                    // check each week to see if the picks are there
                    if (comboBoxSelectWeekPicks.Text == "Week 01" && selectedPlayer.PicksWeek01 == "")
                    {
                        // clear text and check boxes
                        ClearBoxes();
                    }
                    if (comboBoxSelectWeekPicks.Text == "Week 02" && selectedPlayer.PicksWeek02 == "")
                    {
                        ClearBoxes();
                    }
                    if (comboBoxSelectWeekPicks.Text == "Week 03" && selectedPlayer.PicksWeek03 == "")
                    {
                        ClearBoxes();
                    }
                    if (comboBoxSelectWeekPicks.Text == "Week 04" && selectedPlayer.PicksWeek04 == "")
                    {
                        ClearBoxes();
                    }
                    if (comboBoxSelectWeekPicks.Text == "Week 05" && selectedPlayer.PicksWeek05 == "")
                    {
                        ClearBoxes();
                    }
                    if (comboBoxSelectWeekPicks.Text == "Week 06" && selectedPlayer.PicksWeek06 == "")
                    {
                        ClearBoxes();
                    }
                    if (comboBoxSelectWeekPicks.Text == "Week 07" && selectedPlayer.PicksWeek07 == "")
                    {
                        ClearBoxes();
                    }
                    if (comboBoxSelectWeekPicks.Text == "Week 08" && selectedPlayer.PicksWeek08 == "")
                    {
                        ClearBoxes();
                    }
                    if (comboBoxSelectWeekPicks.Text == "Week 09" && selectedPlayer.PicksWeek09 == "")
                    {
                        ClearBoxes();
                    }
                    if (comboBoxSelectWeekPicks.Text == "Week 10" && selectedPlayer.PicksWeek10 == "")
                    {
                        ClearBoxes();
                    }
                    if (comboBoxSelectWeekPicks.Text == "Week 11" && selectedPlayer.PicksWeek11 == "")
                    {
                        ClearBoxes();
                    }
                    if (comboBoxSelectWeekPicks.Text == "Week 12" && selectedPlayer.PicksWeek12 == "")
                    {
                        ClearBoxes();
                    }
                    if (comboBoxSelectWeekPicks.Text == "Week 13" && selectedPlayer.PicksWeek13 == "")
                    {
                        ClearBoxes();
                    }
                    if (comboBoxSelectWeekPicks.Text == "Week 14" && selectedPlayer.PicksWeek14 == "")
                    {
                        ClearBoxes();
                    }
                    if (comboBoxSelectWeekPicks.Text == "Week 15" && selectedPlayer.PicksWeek15 == "")
                    {
                        ClearBoxes();
                    }
                    if (comboBoxSelectWeekPicks.Text == "Week 16" && selectedPlayer.PicksWeek16 == "")
                    {
                        ClearBoxes();
                    }
                    if (comboBoxSelectWeekPicks.Text == "Week 17" && selectedPlayer.PicksWeek17 == "")
                    {
                        ClearBoxes();
                    }
                }
            }
        }

        private void CalculateTextBoxes()
        {
            // disable all the textboxes
            foreach (TextBox textBoxes in TextBoxes)
            {
                textBoxes.Visible = false;
            }

            // then enable them matching the MaxPicks
            foreach (SeasonsDBDataSet.Seasons1_5Row selectedSeason in seasonsDBDataSet.Seasons1_5)
            {
                if (selectedSeason.SeasonName == textBoxSelectedSeason.Text)
                {
                    if (comboBoxSelectWeekPicks.Text == "Week 01")
                    {
                        for (int i = 0; i < selectedSeason.MaxPicksWeek01; i++)
                        {
                            TextBoxes[i].Visible = true;
                        }
                    }
                    if (comboBoxSelectWeekPicks.Text == "Week 02")
                    {
                        for (int i = 0; i < selectedSeason.MaxPicksWeek02; i++)
                        {
                            TextBoxes[i].Visible = true;
                        }
                    }
                    if (comboBoxSelectWeekPicks.Text == "Week 03")
                    {
                        for (int i = 0; i < selectedSeason.MaxPicksWeek03; i++)
                        {
                            TextBoxes[i].Visible = true;
                        }
                    }
                    if (comboBoxSelectWeekPicks.Text == "Week 04")
                    {
                        for (int i = 0; i < selectedSeason.MaxPicksWeek04; i++)
                        {
                            TextBoxes[i].Visible = true;
                        }
                    }
                    if (comboBoxSelectWeekPicks.Text == "Week 05")
                    {
                        for (int i = 0; i < selectedSeason.MaxPicksWeek05; i++)
                        {
                            TextBoxes[i].Visible = true;
                        }
                    }
                    if (comboBoxSelectWeekPicks.Text == "Week 06")
                    {
                        for (int i = 0; i < selectedSeason.MaxPicksWeek06; i++)
                        {
                            TextBoxes[i].Visible = true;
                        }
                    }
                    if (comboBoxSelectWeekPicks.Text == "Week 07")
                    {
                        for (int i = 0; i < selectedSeason.MaxPicksWeek07; i++)
                        {
                            TextBoxes[i].Visible = true;
                        }
                    }
                    if (comboBoxSelectWeekPicks.Text == "Week 08")
                    {
                        for (int i = 0; i < selectedSeason.MaxPicksWeek08; i++)
                        {
                            TextBoxes[i].Visible = true;
                        }
                    }
                    if (comboBoxSelectWeekPicks.Text == "Week 09")
                    {
                        for (int i = 0; i < selectedSeason.MaxPicksWeek09; i++)
                        {
                            TextBoxes[i].Visible = true;
                        }
                    }
                    if (comboBoxSelectWeekPicks.Text == "Week 10")
                    {
                        for (int i = 0; i < selectedSeason.MaxPicksWeek10; i++)
                        {
                            TextBoxes[i].Visible = true;
                        }
                    }
                    if (comboBoxSelectWeekPicks.Text == "Week 11")
                    {
                        for (int i = 0; i < selectedSeason.MaxPicksWeek11; i++)
                        {
                            TextBoxes[i].Visible = true;
                        }
                    }
                    if (comboBoxSelectWeekPicks.Text == "Week 12")
                    {
                        for (int i = 0; i < selectedSeason.MaxPicksWeek12; i++)
                        {
                            TextBoxes[i].Visible = true;
                        }
                    }
                    if (comboBoxSelectWeekPicks.Text == "Week 13")
                    {
                        for (int i = 0; i < selectedSeason.MaxPicksWeek13; i++)
                        {
                            TextBoxes[i].Visible = true;
                        }
                    }
                    if (comboBoxSelectWeekPicks.Text == "Week 14")
                    {
                        for (int i = 0; i < selectedSeason.MaxPicksWeek14; i++)
                        {
                            TextBoxes[i].Visible = true;
                        }
                    }
                    if (comboBoxSelectWeekPicks.Text == "Week 15")
                    {
                        for (int i = 0; i < selectedSeason.MaxPicksWeek15; i++)
                        {
                            TextBoxes[i].Visible = true;
                        }
                    }
                    if (comboBoxSelectWeekPicks.Text == "Week 16")
                    {
                        for (int i = 0; i < selectedSeason.MaxPicksWeek16; i++)
                        {
                            TextBoxes[i].Visible = true;
                        }
                    }
                    if (comboBoxSelectWeekPicks.Text == "Week 17")
                    {
                        for (int i = 0; i < selectedSeason.MaxPicksWeek17; i++)
                        {
                            TextBoxes[i].Visible = true;
                        }
                    }

                }
            }
        }

        private SeasonsDBDataSet.Seasons1_5Row FindSeason1_5()
        {
            foreach (SeasonsDBDataSet.Seasons1_5Row selectedSeason1_5 in seasonsDBDataSet.Seasons1_5)
            {
                if (selectedSeason1_5.SeasonName == textBoxSelectedSeason.Text)
                {
                    return selectedSeason1_5;
                }
            }
            MessageBox.Show("No Season Selected.");
            return null;
        }

        private SeasonsDBDataSet.Seasons6_10Row FindSeason6_10()
        {
            foreach (SeasonsDBDataSet.Seasons6_10Row selectedSeason6_10 in seasonsDBDataSet.Seasons6_10)
            {
                if (selectedSeason6_10.SeasonName == textBoxSelectedSeason.Text)
                {
                    return selectedSeason6_10;
                }
            }
            return null;
        }

        private SeasonsDBDataSet.Seasons11_17Row FindSeason11_17()
        {
            foreach (SeasonsDBDataSet.Seasons11_17Row selectedSeason11_17 in seasonsDBDataSet.Seasons11_17)
            {
                if (selectedSeason11_17.SeasonName == textBoxSelectedSeason.Text)
                {
                    return selectedSeason11_17;
                }
            }
            return null;
        }
    }
}
