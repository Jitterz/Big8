using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Big8_MAIN
{
    // TODO: 
    //       
    //       
    //       
    public partial class FormSetUpSeason : Form
    {
        private List<TextBox> TeamNameList = new List<TextBox>();
        FormNewSeason formNewSeason = new FormNewSeason();
        private static SeasonsDBDataSet.Seasons1_5Row selectedSeason1;
        private static SeasonsDBDataSet.Seasons6_10Row selectedSeason2;
        private static SeasonsDBDataSet.Seasons11_17Row selectedSeason3;

        // to get a list of the actual text to test against what my mom typed in
        List<string> textBoxList = new List<string>();
        List<string> fullTeamsList = new List<string>();

        bool isEnter;
        
        // Need to add some kind of safe gaurd so changes dont get lost on accident.
        //private bool isSeasonSaved = false;

        public FormSetUpSeason()
        {
            InitializeComponent();

            this.Activated += FormSetUpSeason_Activated;
            comboBoxSelectWeekSeason.Click += comboBoxSelectWeekSeason_Click;
            UpdateSeasonList();
            BuildTextBoxList();

            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }

        // this is for the enter and tab dilema if tab is pressed it will go to the top right box
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Tab && isEnter == false)
            {
                textBoxTeamName02.Focus();
                return true;
            }
            else
            {
                isEnter = false;
                return false;
            }
        }

        // if enter is pressed it will go to the next box
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                // the bool is so when this command sends Tab it doesnt trigger the code above
                isEnter = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void FormSetUpSeason_Activated(object sender, EventArgs e)
        {
            UpdateSeasonList();
            if (textBoxCurrentSeason.Text == "")
            {
                upDownPicksLimit.Enabled = false;
            }
            else
            {
                upDownPicksLimit.Enabled = true;
            }

            if (selectedSeason1 != null)
            {
                UpdateTeamNames();
            }
        }

        private void seasonsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            // So have 3 seasons DB now. Need to do this three times or make sure I am changing the correct one.
           // this.Validate();
            //this.seasons1_5BindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.seasonsDBDataSet);

        }

        private void FormSetUpSeason_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'playersDBDataSet.Players' table. You can move, or remove it, as needed.
            this.playersTableAdapter.Fill(this.playersDBDataSet.Players);
            this.seasons1_5TableAdapter.Fill(this.seasonsDBDataSet.Seasons1_5);
            this.seasons6_10TableAdapter.Fill(this.seasonsDBDataSet.Seasons6_10);
            this.seasons11_17TableAdapter.Fill(this.seasonsDBDataSet.Seasons11_17);

            //BuildTextBoxList();
            comboBoxSelectWeekSeason.SelectedItem = PublicVariables.GetDefaultWeek;
            if (comboBoxSelectWeekSeason.SelectedIndex != -1)
            {
                labelWeekDisplaySeason.Text = comboBoxSelectWeekSeason.SelectedItem.ToString();
            }
            labelSeasonNameLarge.Text = textBoxCurrentSeason.Text;

            if (selectedSeason1 != null)
            {
                textBoxCurrentSeason.Text = selectedSeason1.SeasonName;
            }

            button2.FlatAppearance.BorderColor = Color.RoyalBlue;
        }

        public void UpdateSeasonList()
        {
            // clear the list then repopulate it
            listBoxSavedSeasons.Items.Clear();
            // find the selected player in the database 
            foreach (SeasonsDBDataSet.Seasons1_5Row rows in seasonsDBDataSet.Seasons1_5)
            {
                listBoxSavedSeasons.Items.Add(rows.SeasonName);
            }

            // try to make it so after a new season is created it is automatically selected.
            foreach (string seasonList in listBoxSavedSeasons.Items)
            {
                if (seasonList == textBoxCurrentSeason.Text)
                {
                    listBoxSavedSeasons.SelectedItem = seasonList;
                    break;
                }
            }
        }

        public void UpdateForm()
        {
            textBoxCurrentSeason.Text = selectedSeason1.SeasonName;
            if (comboBoxSelectWeekSeason.SelectedIndex != -1)
            {
                labelWeekDisplaySeason.Text = comboBoxSelectWeekSeason.SelectedItem.ToString();
            }
            labelSeasonNameLarge.Text = textBoxCurrentSeason.Text;
            this.seasons1_5TableAdapter.Fill(this.seasonsDBDataSet.Seasons1_5);
            this.seasons6_10TableAdapter.Fill(this.seasonsDBDataSet.Seasons6_10);
            this.seasons11_17TableAdapter.Fill(this.seasonsDBDataSet.Seasons11_17);
        }

        public static void SetSelectedSeason(SeasonsDBDataSet.Seasons1_5Row newSelectedSeason1,
            SeasonsDBDataSet.Seasons6_10Row newSelectedSeason2, SeasonsDBDataSet.Seasons11_17Row newSelectedSeason3)
        {
            selectedSeason1 = newSelectedSeason1;
            selectedSeason2 = newSelectedSeason2;
            selectedSeason3 = newSelectedSeason3;
            PublicVariables.GetDefaultSeason = selectedSeason1.SeasonName;
        }

        public void SetSeason(SeasonsDBDataSet.Seasons1_5Row season)
        {
            textBoxCurrentSeason.Text = season.SeasonName;
        }


        private void buttonNewSeason_Click(object sender, EventArgs e)
        {
            formNewSeason.ShowDialog();
        }

        private void CreateSeason()
        {
            if (listBoxSavedSeasons.SelectedIndex == -1)
            {
                MessageBox.Show("No Season selected to save.");
                return;
            }

            if (comboBoxSelectWeekSeason.Text == "")
            {
                MessageBox.Show("Week box is blank, please select week to save.");
                return;
            }

            try
            {
                AddTeamNames(selectedSeason1, selectedSeason2, selectedSeason3);
                if (upDownPicksLimit.Value <= 7)
                {
                    MessageBox.Show("WARNING: " + comboBoxSelectWeekSeason.Text + " picks limit might be incorrect. It is currently " + upDownPicksLimit.Value.ToString() + ". Normally 8 is the minimum. You can change it and then save again.");
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
            this.seasons1_5TableAdapter.Update(this.seasonsDBDataSet.Seasons1_5);
            this.seasons6_10TableAdapter.Update(this.seasonsDBDataSet.Seasons6_10);
            this.seasons11_17TableAdapter.Update(this.seasonsDBDataSet.Seasons11_17);
            if (selectedSeason1 != null)
            {
                MessageBox.Show("New Season " + selectedSeason1.SeasonName + " added sucessfully!");
            }
        }

        private void DeleteSeason()
        {
            // make sure a player is selected
            if (listBoxSavedSeasons.SelectedItem == null)
            {
                MessageBox.Show("No Season selected.");
                return;
            }

            // find the player to delete
            foreach (SeasonsDBDataSet.Seasons1_5Row deleteSeason1 in seasonsDBDataSet.Seasons1_5)
            {
                // Just find them by matching pool name and selected player
                if (deleteSeason1.SeasonName == listBoxSavedSeasons.SelectedItem.ToString())
                {
                    deleteSeason1.Delete();

                    foreach (SeasonsDBDataSet.Seasons6_10Row deleteSeason2 in seasonsDBDataSet.Seasons6_10)
                    {
                        if (deleteSeason2.SeasonName == listBoxSavedSeasons.SelectedItem.ToString())
                        {
                            deleteSeason2.Delete();
                            break;
                        }
                    }

                    foreach (SeasonsDBDataSet.Seasons11_17Row deleteSeason3 in seasonsDBDataSet.Seasons11_17)
                    {
                        if (deleteSeason3.SeasonName == listBoxSavedSeasons.SelectedItem.ToString())
                        {
                            deleteSeason3.Delete();
                            break;
                        }
                    }

                    this.Validate();
                    //this.seasons1_5TableAdapter.Update(this.seasonsDBDataSet);
                    //this.seasons6_10TableAdapter.Update(this.seasonsDBDataSet);
                    //this.seasons11_17TableAdapter.Update(this.seasonsDBDataSet);
                    this.seasons1_5BindingSource.EndEdit();
                    this.seasons6_10BindingSource.EndEdit();
                    this.seasons11_17BindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.seasonsDBDataSet);

                    // update list after deleting and clear the form
                    UpdateSeasonList();
                    ClearForm();
                    selectedSeason1 = null;
                    selectedSeason2 = null;
                    selectedSeason3 = null;
                    labelSeasonNameLarge.Text = "";
                    textBoxCurrentSeason.Text = "";
                    break;
                }
            }

        }

        private void BuildTextBoxList()
        {
            TeamNameList.Add(textBoxTeamName01);
            TeamNameList.Add(textBoxTeamName02);
            TeamNameList.Add(textBoxTeamName03);
            TeamNameList.Add(textBoxTeamName04);
            TeamNameList.Add(textBoxTeamName05);
            TeamNameList.Add(textBoxTeamName06);
            TeamNameList.Add(textBoxTeamName07);
            TeamNameList.Add(textBoxTeamName08);
            TeamNameList.Add(textBoxTeamName09);
            TeamNameList.Add(textBoxTeamName10);
            TeamNameList.Add(textBoxTeamName11);
            TeamNameList.Add(textBoxTeamName12);
            TeamNameList.Add(textBoxTeamName13);
            TeamNameList.Add(textBoxTeamName14);
            TeamNameList.Add(textBoxTeamName15);
            TeamNameList.Add(textBoxTeamName16);
            TeamNameList.Add(textBoxTeamName17);
            TeamNameList.Add(textBoxTeamName18);
            TeamNameList.Add(textBoxTeamName19);
            TeamNameList.Add(textBoxTeamName20);
            TeamNameList.Add(textBoxTeamName21);
            TeamNameList.Add(textBoxTeamName22);
            TeamNameList.Add(textBoxTeamName23);
            TeamNameList.Add(textBoxTeamName24);
            TeamNameList.Add(textBoxTeamName25);
            TeamNameList.Add(textBoxTeamName26);
            TeamNameList.Add(textBoxTeamName27);
            TeamNameList.Add(textBoxTeamName28);
            TeamNameList.Add(textBoxTeamName29);
            TeamNameList.Add(textBoxTeamName30);
            TeamNameList.Add(textBoxTeamName31);
            TeamNameList.Add(textBoxTeamName32);
            TeamNameList.Add(textBoxTeamName33);
            TeamNameList.Add(textBoxTeamName34);
            TeamNameList.Add(textBoxTeamName35);
            TeamNameList.Add(textBoxTeamName36);
            TeamNameList.Add(textBoxTeamName37);
            TeamNameList.Add(textBoxTeamName38);
            TeamNameList.Add(textBoxTeamName39);
            TeamNameList.Add(textBoxTeamName40);
            TeamNameList.Add(textBoxTeamName41);
            TeamNameList.Add(textBoxTeamName42);
            TeamNameList.Add(textBoxTeamName43);
            TeamNameList.Add(textBoxTeamName44);
        }

        // fill the season based on which week it is
        private void AddTeamNames(SeasonsDBDataSet.Seasons1_5Row addItemsByWeek1, 
            SeasonsDBDataSet.Seasons6_10Row addItemsByWeek2, SeasonsDBDataSet.Seasons11_17Row addItemsByWeek3)
        {
            // figure out which week is selected
            foreach (var weekBox in comboBoxSelectWeekSeason.Items)
            {
                // if the week matched the selected week
                if (weekBox.ToString() == comboBoxSelectWeekSeason.SelectedItem.ToString())
                {
                    // ------------------------------------Week 01 --------------------------------------- //
                    if (weekBox.ToString() == "Week 01")
                    {
                        // the int to count for numbers i add to each team based on their possition that week
                        int teamsCount = 1;

                        //database starts at 1 but changes all the way up to 220 the teamnameslist is a list of text boxes and its index always starts at 0 ends at 44
                        // teams count is the number i will add before the team name so it saves in the database as 1 RAIDERS so the autocomplete still works and the
                        // rest of the program still works. This is all for the autocomplete changes
                        // addItemsByWeek is the season database and I access the index based on where I need to be so it goes from 1 - 308
                        // TeamNameList is a list of the 44 text boxes so it goes from 0 - 43 always
                        for (int i = 1; i <= 44; i++)
                        {
                            if (TeamNameList[i - 1].Text != "")
                            {
                                addItemsByWeek1[i] = teamsCount.ToString() + " " + TeamNameList[i - 1].Text;
                                teamsCount++;
                            }
                            else
                            {
                                teamsCount++;
                            }
                        }
                        addItemsByWeek1.MaxPicksWeek01 = (int)upDownPicksLimit.Value;
                    }
                    // ------------------------------------Week 02 --------------------------------------- //
                    if (weekBox.ToString() == "Week 02")
                    {

                        int teamsCount = 1;

                        for (int i = 45; i <= 88; i++)
                        {
                            if (TeamNameList[i - 45].Text != "")
                            {
                                addItemsByWeek1[i] = teamsCount.ToString() + " " + TeamNameList[i - 45].Text;
                                teamsCount++;
                            }
                            else
                            {
                                teamsCount++;
                            }
                        }
                        addItemsByWeek1.MaxPicksWeek02 = (int)upDownPicksLimit.Value;
                    }
                    // ------------------------------------Week 03 --------------------------------------- //
                    if (weekBox.ToString() == "Week 03")
                    {

                        int teamsCount = 1;

                        for (int i = 89; i <= 132; i++)
                        {
                            if (TeamNameList[i - 89].Text != "")
                            {
                                addItemsByWeek1[i] = teamsCount.ToString() + " " + TeamNameList[i - 89].Text;
                                teamsCount++;
                            }
                            else
                            {
                                teamsCount++;
                            }
                        }
                        addItemsByWeek1.MaxPicksWeek03 = (int)upDownPicksLimit.Value;
                    }
                    // ------------------------------------Week 04 --------------------------------------- //
                    if (weekBox.ToString() == "Week 04")
                    {

                        int teamsCount = 1;

                        for (int i = 133; i <= 176; i++)
                        {
                            if (TeamNameList[i - 133].Text != "")
                            {
                                addItemsByWeek1[i] = teamsCount.ToString() + " " + TeamNameList[i - 133].Text;
                                teamsCount++;
                            }
                            else
                            {
                                teamsCount++;
                            }
                        }
                        addItemsByWeek1.MaxPicksWeek04 = (int)upDownPicksLimit.Value;
                    }
                    // ------------------------------------Week 05 --------------------------------------- //
                    if (weekBox.ToString() == "Week 05")
                    {

                        int teamsCount = 1;

                        for (int i = 177; i <= 220; i++)
                        {
                            if (TeamNameList[i - 177].Text != "")
                            {
                                addItemsByWeek1[i] = teamsCount.ToString() + " " + TeamNameList[i - 177].Text;
                                teamsCount++;
                            }
                            else
                            {
                                teamsCount++;
                            }
                        }
                        addItemsByWeek1.MaxPicksWeek05 = (int)upDownPicksLimit.Value;
                    }
                    // ------------------------------------Week 06 --------------------------------------- //
                    if (weekBox.ToString() == "Week 06")
                    {

                        int teamsCount = 1;

                        for (int i = 1; i <= 44; i++)
                        {
                            if (TeamNameList[i - 1].Text != "")
                            {
                                addItemsByWeek2[i] = teamsCount.ToString() + " " + TeamNameList[i - 1].Text;
                                teamsCount++;
                            }
                            else
                            {
                                teamsCount++;
                            }
                        }
                        addItemsByWeek1.MaxPicksWeek06 = (int)upDownPicksLimit.Value;
                    }
                    // ------------------------------------Week 07 --------------------------------------- //
                    if (weekBox.ToString() == "Week 07")
                    {

                        int teamsCount = 1;

                        for (int i = 45; i <= 88; i++)
                        {
                            if (TeamNameList[i - 45].Text != "")
                            {
                                addItemsByWeek2[i] = teamsCount.ToString() + " " + TeamNameList[i - 45].Text;
                                teamsCount++;
                            }
                            else
                            {
                                teamsCount++;
                            }
                        }
                        addItemsByWeek1.MaxPicksWeek07 = (int)upDownPicksLimit.Value;
                    }
                    // ------------------------------------Week 08 --------------------------------------- //
                    if (weekBox.ToString() == "Week 08")
                    {

                        int teamsCount = 1;

                        for (int i = 89; i <= 132; i++)
                        {
                            if (TeamNameList[i - 89].Text != "")
                            {
                                addItemsByWeek2[i] = teamsCount.ToString() + " " + TeamNameList[i - 89].Text;
                                teamsCount++;
                            }
                            else
                            {
                                teamsCount++;
                            }
                        }
                        addItemsByWeek1.MaxPicksWeek08 = (int)upDownPicksLimit.Value;
                    }
                    // ------------------------------------Week 09 --------------------------------------- //
                    if (weekBox.ToString() == "Week 09")
                    {

                        int teamsCount = 1;

                        for (int i = 133; i <= 176; i++)
                        {
                            if (TeamNameList[i - 133].Text != "")
                            {
                                addItemsByWeek2[i] = teamsCount.ToString() + " " + TeamNameList[i - 133].Text;
                                teamsCount++;
                            }
                            else
                            {
                                teamsCount++;
                            }
                        }
                        addItemsByWeek1.MaxPicksWeek09 = (int)upDownPicksLimit.Value;
                    }
                    // ------------------------------------Week 10 --------------------------------------- //
                    if (weekBox.ToString() == "Week 10")
                    {

                        int teamsCount = 1;

                        for (int i = 177; i <= 220; i++)
                        {
                            if (TeamNameList[i - 177].Text != "")
                            {
                                addItemsByWeek2[i] = teamsCount.ToString() + " " + TeamNameList[i - 177].Text;
                                teamsCount++;
                            }
                            else
                            {
                                teamsCount++;
                            }
                        }
                        addItemsByWeek1.MaxPicksWeek10 = (int)upDownPicksLimit.Value;
                    }
                    // ------------------------------------Week 11 --------------------------------------- //
                    if (weekBox.ToString() == "Week 11")
                    {

                        int teamsCount = 1;

                        for (int i = 1; i <= 44; i++)
                        {
                            if (TeamNameList[i - 1].Text != "")
                            {
                                addItemsByWeek3[i] = teamsCount.ToString() + " " + TeamNameList[i - 1].Text;
                                teamsCount++;
                            }
                            else
                            {
                                teamsCount++;
                            }
                        }
                        addItemsByWeek1.MaxPicksWeek11 = (int)upDownPicksLimit.Value;
                    }
                    // ------------------------------------Week 12 --------------------------------------- //
                    if (weekBox.ToString() == "Week 12")
                    {

                        int teamsCount = 1;

                        for (int i = 45; i <= 88; i++)
                        {
                            if (TeamNameList[i - 45].Text != "")
                            {
                                addItemsByWeek3[i] = teamsCount.ToString() + " " + TeamNameList[i - 45].Text;
                                teamsCount++;
                            }
                            else
                            {
                                teamsCount++;
                            }
                        }
                        addItemsByWeek1.MaxPicksWeek12 = (int)upDownPicksLimit.Value;
                    }
                    // ------------------------------------Week 13 --------------------------------------- //
                    if (weekBox.ToString() == "Week 13")
                    {

                        int teamsCount = 1;

                        for (int i = 89; i <= 132; i++)
                        {
                            if (TeamNameList[i - 89].Text != "")
                            {
                                addItemsByWeek3[i] = teamsCount.ToString() + " " + TeamNameList[i - 89].Text;
                                teamsCount++;
                            }
                            else
                            {
                                teamsCount++;
                            }
                        }
                        addItemsByWeek1.MaxPicksWeek13 = (int)upDownPicksLimit.Value;
                    }
                    // ------------------------------------Week 14 --------------------------------------- //
                    if (weekBox.ToString() == "Week 14")
                    {

                        int teamsCount = 1;

                        for (int i = 133; i <= 176; i++)
                        {
                            if (TeamNameList[i - 133].Text != "")
                            {
                                addItemsByWeek3[i] = teamsCount.ToString() + " " + TeamNameList[i - 133].Text;
                                teamsCount++;
                            }
                            else
                            {
                                teamsCount++;
                            }
                        }
                        addItemsByWeek1.MaxPicksWeek14 = (int)upDownPicksLimit.Value;
                    }
                    // ------------------------------------Week 15 --------------------------------------- //
                    if (weekBox.ToString() == "Week 15")
                    {

                        int teamsCount = 1;

                        for (int i = 177; i <= 220; i++)
                        {
                            if (TeamNameList[i - 177].Text != "")
                            {
                                addItemsByWeek3[i] = teamsCount.ToString() + " " + TeamNameList[i - 177].Text;
                                teamsCount++;
                            }
                            else
                            {
                                teamsCount++;
                            }
                        }
                        addItemsByWeek1.MaxPicksWeek15 = (int)upDownPicksLimit.Value;
                    }
                    // ------------------------------------Week 16 --------------------------------------- //
                    if (weekBox.ToString() == "Week 16")
                    {

                        int teamsCount = 1;

                        for (int i = 221; i <= 264; i++)
                        {
                            if (TeamNameList[i - 221].Text != "")
                            {
                                addItemsByWeek3[i] = teamsCount.ToString() + " " + TeamNameList[i - 221].Text;
                                teamsCount++;
                            }
                            else
                            {
                                teamsCount++;
                            }
                        }
                        addItemsByWeek1.MaxPicksWeek16 = (int)upDownPicksLimit.Value;
                    }
                    // ------------------------------------Week 17 --------------------------------------- //
                    if (weekBox.ToString() == "Week 17")
                    {

                        int teamsCount = 1;

                        for (int i = 265; i <= 308; i++)
                        {
                            if (TeamNameList[i - 265].Text != "")
                            {
                                addItemsByWeek3[i] = teamsCount.ToString() + " " + TeamNameList[i - 265].Text;
                                teamsCount++;
                            }
                            else
                            {
                                teamsCount++;
                            }
                        }
                        addItemsByWeek1.MaxPicksWeek17 = (int)upDownPicksLimit.Value;
                    }
                }
            }
        }

        private void UpdateTeamNames()
        {
            if (selectedSeason1 != null)
            {
                if (selectedSeason1.SeasonName == textBoxCurrentSeason.Text)
                {
                    // ------------------- WEEK 01 -------------------------
                    if (comboBoxSelectWeekSeason.Text == "Week 01" && selectedSeason1.Week01Team01 != "")
                    {
                        for (int i = 1; i <= 44; i++)
                        {
                            // textbox list index starts at 0 and the database index starts at 1 and changes based on where i am accessing it. [i-1] brings the list index down to zero while the
                            // database index will continue from 1-220. Checks if the string is also null because of the substring which removes the numbers i hardcoded into the
                            // database for each team each week so the rest of the program still works and so the autocomplete in setupseason also still works.
                            TeamNameList[i - 1].Text = (String.IsNullOrEmpty(selectedSeason1[i].ToString()) ? selectedSeason1[i].ToString() : selectedSeason1[i].ToString().Substring(2).Trim());
                        }
                       
                        // max picks is all stored in seasondb1_5 all 17 weeks
                        upDownPicksLimit.Value = selectedSeason1.MaxPicksWeek01;
                    }
                    // ------------------- WEEK 02 -------------------------
                    if (comboBoxSelectWeekSeason.Text == "Week 02" && selectedSeason1.Week02Team01 != "")
                    {
                        for (int i = 45; i <= 88; i++)
                        {
                            TeamNameList[i - 45].Text = (String.IsNullOrEmpty(selectedSeason1[i].ToString()) ? selectedSeason1[i].ToString() : selectedSeason1[i].ToString().Substring(2).Trim());
                        }

                        upDownPicksLimit.Value = selectedSeason1.MaxPicksWeek02;
                    }
                    // ------------------- WEEK 03 -------------------------
                    if (comboBoxSelectWeekSeason.Text == "Week 03" && selectedSeason1.Week03Team01 != "")
                    {
                        for (int i = 89; i <= 132; i++)
                        {
                            TeamNameList[i - 89].Text = (String.IsNullOrEmpty(selectedSeason1[i].ToString()) ? selectedSeason1[i].ToString() : selectedSeason1[i].ToString().Substring(2).Trim());
                        }

                        upDownPicksLimit.Value = selectedSeason1.MaxPicksWeek03;
                    }
                    // ------------------- WEEK 04 -------------------------
                    if (comboBoxSelectWeekSeason.Text == "Week 04" && selectedSeason1.Week04Team01 != "")
                    {
                        for (int i = 133; i <= 176; i++)
                        {
                            TeamNameList[i - 133].Text = (String.IsNullOrEmpty(selectedSeason1[i].ToString()) ? selectedSeason1[i].ToString() : selectedSeason1[i].ToString().Substring(2).Trim());
                        }

                        upDownPicksLimit.Value = selectedSeason1.MaxPicksWeek04;
                    }
                    // ------------------- WEEK 05 -------------------------
                    if (comboBoxSelectWeekSeason.Text == "Week 05" && selectedSeason1.Week05Team01 != "")
                    {
                        for (int i = 177; i <= 220; i++)
                        {
                            TeamNameList[i - 177].Text = (String.IsNullOrEmpty(selectedSeason1[i].ToString()) ? selectedSeason1[i].ToString() : selectedSeason1[i].ToString().Substring(2).Trim());
                        }

                        upDownPicksLimit.Value = selectedSeason1.MaxPicksWeek05;
                    }
                    // ------------------- WEEK 06 -------------------------
                    if (comboBoxSelectWeekSeason.Text == "Week 06" && selectedSeason2.Week06Team01 != "")
                    {
                        for (int i = 1; i <= 44; i++)
                        {
                            TeamNameList[i - 1].Text = (String.IsNullOrEmpty(selectedSeason2[i].ToString()) ? selectedSeason2[i].ToString() : selectedSeason2[i].ToString().Substring(2).Trim());
                        }

                        upDownPicksLimit.Value = selectedSeason1.MaxPicksWeek06;
                    }
                    // ------------------- WEEK 07 -------------------------
                    if (comboBoxSelectWeekSeason.Text == "Week 07" && selectedSeason2.Week07Team01 != "")
                    {
                        for (int i = 45; i <= 88; i++)
                        {
                            TeamNameList[i - 45].Text = (String.IsNullOrEmpty(selectedSeason2[i].ToString()) ? selectedSeason2[i].ToString() : selectedSeason2[i].ToString().Substring(2).Trim());
                        }

                        upDownPicksLimit.Value = selectedSeason1.MaxPicksWeek07;
                    }
                    // ------------------- WEEK 08 -------------------------
                    if (comboBoxSelectWeekSeason.Text == "Week 08" && selectedSeason2.Week08Team01 != "")
                    {
                        for (int i = 89; i <= 132; i++)
                        {
                            TeamNameList[i - 89].Text = (String.IsNullOrEmpty(selectedSeason2[i].ToString()) ? selectedSeason2[i].ToString() : selectedSeason2[i].ToString().Substring(2).Trim());
                        }

                        upDownPicksLimit.Value = selectedSeason1.MaxPicksWeek08;
                    }
                    // ------------------- WEEK 09 -------------------------
                    if (comboBoxSelectWeekSeason.Text == "Week 09" && selectedSeason2.Week09Team01 != "")
                    {
                        for (int i = 133; i <= 176; i++)
                        {
                            TeamNameList[i - 133].Text = (String.IsNullOrEmpty(selectedSeason2[i].ToString()) ? selectedSeason2[i].ToString() : selectedSeason2[i].ToString().Substring(2).Trim());
                        }

                        upDownPicksLimit.Value = selectedSeason1.MaxPicksWeek09;
                    }
                    // ------------------- WEEK 10 -------------------------
                    if (comboBoxSelectWeekSeason.Text == "Week 10" && selectedSeason2.Week10Team01 != "")
                    {
                        for (int i = 177; i <= 220; i++)
                        {
                            TeamNameList[i - 177].Text = (String.IsNullOrEmpty(selectedSeason2[i].ToString()) ? selectedSeason2[i].ToString() : selectedSeason2[i].ToString().Substring(2).Trim());
                        }

                        upDownPicksLimit.Value = selectedSeason1.MaxPicksWeek10;
                    }
                    // ------------------- WEEK 11 -------------------------
                    if (comboBoxSelectWeekSeason.Text == "Week 11" && selectedSeason3.Week11Team01 != "")
                    {
                        for (int i = 1; i <= 44; i++)
                        {
                            TeamNameList[i - 1].Text = (String.IsNullOrEmpty(selectedSeason3[i].ToString()) ? selectedSeason3[i].ToString() : selectedSeason3[i].ToString().Substring(2).Trim());
                        }

                        upDownPicksLimit.Value = selectedSeason1.MaxPicksWeek11;
                    }
                    // ------------------- WEEK 12 -------------------------
                    if (comboBoxSelectWeekSeason.Text == "Week 12" && selectedSeason3.Week12Team01 != "")
                    {
                        for (int i = 45; i <= 88; i++)
                        {
                            TeamNameList[i - 45].Text = (String.IsNullOrEmpty(selectedSeason3[i].ToString()) ? selectedSeason3[i].ToString() : selectedSeason3[i].ToString().Substring(2).Trim());
                        }

                        upDownPicksLimit.Value = selectedSeason1.MaxPicksWeek12;
                    }
                    // ------------------- WEEK 13 -------------------------
                    if (comboBoxSelectWeekSeason.Text == "Week 13" && selectedSeason3.Week13Team01 != "")
                    {
                        for (int i = 89; i <= 132; i++)
                        {
                            TeamNameList[i - 89].Text = (String.IsNullOrEmpty(selectedSeason3[i].ToString()) ? selectedSeason3[i].ToString() : selectedSeason3[i].ToString().Substring(2).Trim());
                        }

                        upDownPicksLimit.Value = selectedSeason1.MaxPicksWeek13;
                    }
                    // ------------------- WEEK 14 -------------------------
                    if (comboBoxSelectWeekSeason.Text == "Week 14" && selectedSeason3.Week14Team01 != "")
                    {
                        for (int i = 133; i <= 176; i++)
                        {
                            TeamNameList[i - 133].Text = (String.IsNullOrEmpty(selectedSeason3[i].ToString()) ? selectedSeason3[i].ToString() : selectedSeason3[i].ToString().Substring(2).Trim());
                        }

                        upDownPicksLimit.Value = selectedSeason1.MaxPicksWeek14;
                    }
                    // ------------------- WEEK 15 -------------------------
                    if (comboBoxSelectWeekSeason.Text == "Week 15" && selectedSeason3.Week15Team01 != "")
                    {
                        for (int i = 177; i <= 220; i++)
                        {
                            TeamNameList[i - 177].Text = (String.IsNullOrEmpty(selectedSeason3[i].ToString()) ? selectedSeason3[i].ToString() : selectedSeason3[i].ToString().Substring(2).Trim());
                        }

                        upDownPicksLimit.Value = selectedSeason1.MaxPicksWeek15;
                    }
                    // ------------------- WEEK 16 -------------------------
                    if (comboBoxSelectWeekSeason.Text == "Week 16" && selectedSeason3.Week16Team01 != "")
                    {
                        for (int i = 221; i <= 264; i++)
                        {
                            TeamNameList[i - 221].Text = (String.IsNullOrEmpty(selectedSeason3[i].ToString()) ? selectedSeason3[i].ToString() : selectedSeason3[i].ToString().Substring(2).Trim());
                        }

                        upDownPicksLimit.Value = selectedSeason1.MaxPicksWeek16;
                    }
                    // ------------------- WEEK 17 -------------------------
                    if (comboBoxSelectWeekSeason.Text == "Week 17" && selectedSeason3.Week17Team01 != "")
                    {
                        for (int i = 265; i <= 308; i++)
                        {
                            TeamNameList[i - 265].Text = (String.IsNullOrEmpty(selectedSeason3[i].ToString()) ? selectedSeason3[i].ToString() : selectedSeason3[i].ToString().Substring(2).Trim());
                        }

                        upDownPicksLimit.Value = selectedSeason1.MaxPicksWeek17;
                    }                   
                }
            }
        }

        public void ClearForm()
        {
            foreach (TextBox textBoxes in TeamNameList)
            {
                textBoxes.Text = "";
            }
            upDownPicksLimit.Value = 0;
        }

        private void comboBoxSelectWeekSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelWeekDisplaySeason.Text = comboBoxSelectWeekSeason.SelectedItem.ToString();
            upDownPicksLimit.Value = 0;
            ClearForm();
            UpdateTeamNames();
        }

        private void comboBoxSelectWeekSeason_Click(object sender, EventArgs e)
        {
            if (selectedSeason1 == null)
            {
                MessageBox.Show("No Season is selected. Please select a season first.");
                return;
            }
        }

        private void buttonSaveSeason_Click(object sender, EventArgs e)
        {
            if (CheckTeamNamesMatch())
            {
                CreateSeason();
            }
        }

        private void listBoxSavedSeasons_SelectedIndexChanged(object sender, EventArgs e)
        {          
            if (listBoxSavedSeasons.SelectedIndex != -1)
            {
                foreach (SeasonsDBDataSet.Seasons1_5Row newSeason1 in seasonsDBDataSet.Seasons1_5)
                {
                    foreach (SeasonsDBDataSet.Seasons6_10Row newSeason2 in seasonsDBDataSet.Seasons6_10)
                    {
                        foreach (SeasonsDBDataSet.Seasons11_17Row newSeason3 in seasonsDBDataSet.Seasons11_17)
                        {
                            if (newSeason1.SeasonName == listBoxSavedSeasons.SelectedItem.ToString())
                            {
                                selectedSeason1 = newSeason1;
                                selectedSeason2 = newSeason2;
                                selectedSeason3 = newSeason3;
                                textBoxCurrentSeason.Text = selectedSeason1.SeasonName;
                                PublicVariables.GetDefaultSeason = listBoxSavedSeasons.SelectedItem.ToString();

                                SavedPublicVariables savePublicVariables = new SavedPublicVariables();
                                savePublicVariables.GetDefaultSeason = PublicVariables.GetDefaultSeason;

                                IFormatter formatter = new BinaryFormatter();
                                Stream stream = new FileStream("PublicVariablesSave.bin", FileMode.Create, FileAccess.Write, FileShare.None);
                                formatter.Serialize(stream, savePublicVariables);
                                stream.Close();

                                UpdateTeamNames();
                            }
                        }
                    }
                }
            }
            else
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteSeason();
        }

        private void seasons1_5BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.seasons1_5BindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.seasonsDBDataSet);

        }

        private void CreateTextBoxList()
        {
            textBoxList.Clear();

            textBoxList.Add(textBoxTeamName01.Text);
            textBoxList.Add(textBoxTeamName02.Text);
            textBoxList.Add(textBoxTeamName03.Text);
            textBoxList.Add(textBoxTeamName04.Text);
            textBoxList.Add(textBoxTeamName05.Text);
            textBoxList.Add(textBoxTeamName06.Text);
            textBoxList.Add(textBoxTeamName07.Text);
            textBoxList.Add(textBoxTeamName08.Text);
            textBoxList.Add(textBoxTeamName09.Text);
            textBoxList.Add(textBoxTeamName10.Text);
            textBoxList.Add(textBoxTeamName11.Text);
            textBoxList.Add(textBoxTeamName12.Text);
            textBoxList.Add(textBoxTeamName13.Text);
            textBoxList.Add(textBoxTeamName14.Text);
            textBoxList.Add(textBoxTeamName15.Text);
            textBoxList.Add(textBoxTeamName16.Text);
            textBoxList.Add(textBoxTeamName17.Text);
            textBoxList.Add(textBoxTeamName18.Text);
            textBoxList.Add(textBoxTeamName19.Text);
            textBoxList.Add(textBoxTeamName20.Text);
            textBoxList.Add(textBoxTeamName21.Text);
            textBoxList.Add(textBoxTeamName22.Text);
            textBoxList.Add(textBoxTeamName23.Text);
            textBoxList.Add(textBoxTeamName24.Text);
            textBoxList.Add(textBoxTeamName25.Text);
            textBoxList.Add(textBoxTeamName26.Text);
            textBoxList.Add(textBoxTeamName27.Text);
            textBoxList.Add(textBoxTeamName28.Text);
            textBoxList.Add(textBoxTeamName29.Text);
            textBoxList.Add(textBoxTeamName30.Text);
            textBoxList.Add(textBoxTeamName31.Text);
            textBoxList.Add(textBoxTeamName32.Text);
            textBoxList.Add(textBoxTeamName33.Text);
            textBoxList.Add(textBoxTeamName34.Text);
            textBoxList.Add(textBoxTeamName35.Text);
            textBoxList.Add(textBoxTeamName36.Text);
            textBoxList.Add(textBoxTeamName37.Text);
            textBoxList.Add(textBoxTeamName38.Text);
            textBoxList.Add(textBoxTeamName39.Text);
            textBoxList.Add(textBoxTeamName40.Text);
            textBoxList.Add(textBoxTeamName41.Text);
            textBoxList.Add(textBoxTeamName42.Text);
            textBoxList.Add(textBoxTeamName43.Text);
            textBoxList.Add(textBoxTeamName44.Text);
        }
        private void CreateFullTeamsList()
        {
            fullTeamsList.Add("PACKERS");
            fullTeamsList.Add("LIONS");
            fullTeamsList.Add("JETS");
            fullTeamsList.Add("GIANTS");
            fullTeamsList.Add("TEXANS");
            fullTeamsList.Add("BILLS");
            fullTeamsList.Add("CARDINALS");
            fullTeamsList.Add("RAMS");
            fullTeamsList.Add("FALCONS");
            fullTeamsList.Add("BUCCANEERS");
            fullTeamsList.Add("PANTHERS");
            fullTeamsList.Add("SAINTS");
            fullTeamsList.Add("SEAHAWKS");
            fullTeamsList.Add("VIKINGS");
            fullTeamsList.Add("RAVENS");
            fullTeamsList.Add("DOLPHINS");
            fullTeamsList.Add("BENGALS");
            fullTeamsList.Add("BROWNS");
            fullTeamsList.Add("JAGUARS");
            fullTeamsList.Add("TITANS");
            fullTeamsList.Add("49ERS");
            fullTeamsList.Add("BEARS");
            fullTeamsList.Add("BRONCOS");
            fullTeamsList.Add("CHARGERS");
            fullTeamsList.Add("CHIEFS");
            fullTeamsList.Add("RAIDERS");
            fullTeamsList.Add("EAGLES");
            fullTeamsList.Add("PATRIOTS");
            fullTeamsList.Add("COLTS");
            fullTeamsList.Add("STEELERS");
            fullTeamsList.Add("COWBOYS");
            fullTeamsList.Add("REDSKINS");
            fullTeamsList.Add("ABILENE CHRISTIAN");
            fullTeamsList.Add("AIR FORCE");
            fullTeamsList.Add("AKRON");
            fullTeamsList.Add("ALABAMA");
            fullTeamsList.Add("ALABAMA A&M");
            fullTeamsList.Add("ALABAMA STATE");
            fullTeamsList.Add("ALBANY");
            fullTeamsList.Add("ALCORN STATE");
            fullTeamsList.Add("APPALACHIAN STATE");
            fullTeamsList.Add("ARIZONA");
            fullTeamsList.Add("ARIZONA STATE");
            fullTeamsList.Add("ARKANSAS");
            fullTeamsList.Add("ARKANSAS STATE");
            fullTeamsList.Add("ARKANSAS-PINE BLUFF");
            fullTeamsList.Add("ARMY");
            fullTeamsList.Add("AUBURN");
            fullTeamsList.Add("AUSTIN PEAY");
            fullTeamsList.Add("BALL STATE");
            fullTeamsList.Add("BAYLOR");
            fullTeamsList.Add("BETHUNE-COOKMAN");
            fullTeamsList.Add("BOISE STATE");
            fullTeamsList.Add("BOSTON COLLEGE");
            fullTeamsList.Add("BOWLING GREEN");
            fullTeamsList.Add("BROWN");
            fullTeamsList.Add("BRYANT");
            fullTeamsList.Add("BUCKNELL");
            fullTeamsList.Add("BUFFALO");
            fullTeamsList.Add("BUTLER");
            fullTeamsList.Add("BYU");
            fullTeamsList.Add("CAL POLY");
            fullTeamsList.Add("CALIFORNIA");
            fullTeamsList.Add("CAMPBELL");
            fullTeamsList.Add("CENTRAL ARKANSAS");
            fullTeamsList.Add("CENTRAL CONNECTICUT");
            fullTeamsList.Add("CENTRAL MICHIGAN");
            fullTeamsList.Add("CHARLESTON SOUTHERN");
            fullTeamsList.Add("CHARLOTTE");
            fullTeamsList.Add("CHATTANOOGA");
            fullTeamsList.Add("CINCINNATI");
            fullTeamsList.Add("CLEMSON");
            fullTeamsList.Add("COASTAL CAROLINA");
            fullTeamsList.Add("COLGATE");
            fullTeamsList.Add("COLORADO");
            fullTeamsList.Add("COLORADO STATE");
            fullTeamsList.Add("COLUMBIA");
            fullTeamsList.Add("CONNECTICUT");
            fullTeamsList.Add("CORNELL");
            fullTeamsList.Add("DARTMOUTH");
            fullTeamsList.Add("DAVIDSON");
            fullTeamsList.Add("DAYTON");
            fullTeamsList.Add("DELAWARE");
            fullTeamsList.Add("DELAWARE STATE");
            fullTeamsList.Add("DRAKE");
            fullTeamsList.Add("DUKE");
            fullTeamsList.Add("DUQUESNE");
            fullTeamsList.Add("EAST CAROLINA");
            fullTeamsList.Add("EAST TENNESSEE STATE");
            fullTeamsList.Add("EASTERN ILLINOIS");
            fullTeamsList.Add("EASTERN KENTUCKY");
            fullTeamsList.Add("EASTERN MICHIGAN");
            fullTeamsList.Add("EASTERN WASHINGTON");
            fullTeamsList.Add("ELON");
            fullTeamsList.Add("FLORIDA");
            fullTeamsList.Add("FLORIDA A&M");
            fullTeamsList.Add("FLORIDA ATLANTIC");
            fullTeamsList.Add("FLORIDA INTL");
            fullTeamsList.Add("FLORIDA STATE");
            fullTeamsList.Add("FORDHAM");
            fullTeamsList.Add("FRESNO STATE");
            fullTeamsList.Add("FURMAN");
            fullTeamsList.Add("GARDNER-WEBB");
            fullTeamsList.Add("GEORGETOWN");
            fullTeamsList.Add("GEORGIA");
            fullTeamsList.Add("GEORGIA SOUTHERN");
            fullTeamsList.Add("GEORGIA STATE");
            fullTeamsList.Add("GEORGIA TECH");
            fullTeamsList.Add("GRAMBLING");
            fullTeamsList.Add("HAMPTON");
            fullTeamsList.Add("HARVARD");
            fullTeamsList.Add("HAWAI'I");
            fullTeamsList.Add("HOLY CROSS");
            fullTeamsList.Add("HOUSTON");
            fullTeamsList.Add("HOUSTON BAPTIST");
            fullTeamsList.Add("HOWARD");
            fullTeamsList.Add("IDAHO");
            fullTeamsList.Add("IDAHO STATE");
            fullTeamsList.Add("ILLINOIS");
            fullTeamsList.Add("ILLINOIS STATE");
            fullTeamsList.Add("INCARNATE WORD");
            fullTeamsList.Add("INDIANA");
            fullTeamsList.Add("INDIANA STATE");
            fullTeamsList.Add("IOWA");
            fullTeamsList.Add("IOWA STATE");
            fullTeamsList.Add("JACKSON STATE");
            fullTeamsList.Add("JACKSONVILLE");
            fullTeamsList.Add("JACKSONVILLE STATE");
            fullTeamsList.Add("JAMES MADISON");
            fullTeamsList.Add("KANSAS");
            fullTeamsList.Add("KANSAS STATE");
            fullTeamsList.Add("KENNESAW STATE");
            fullTeamsList.Add("KENT STATE");
            fullTeamsList.Add("KENTUCKY");
            fullTeamsList.Add("LAFAYETTE");
            fullTeamsList.Add("LAMAR");
            fullTeamsList.Add("LEHIGH");
            fullTeamsList.Add("LIBERTY");
            fullTeamsList.Add("LOUISIANA MONROE");
            fullTeamsList.Add("LOUISIANA TECH");
            fullTeamsList.Add("LOUISVILLE");
            fullTeamsList.Add("LSU");
            fullTeamsList.Add("MAINE");
            fullTeamsList.Add("MARIST");
            fullTeamsList.Add("MARSHALL");
            fullTeamsList.Add("MARYLAND");
            fullTeamsList.Add("MASSACHUSETTS");
            fullTeamsList.Add("MCNEESE");
            fullTeamsList.Add("MEMPHIS");
            fullTeamsList.Add("MERCER");
            fullTeamsList.Add("MIAMI");
            fullTeamsList.Add("MIAMI (OH)");
            fullTeamsList.Add("MICHIGAN");
            fullTeamsList.Add("MICHIGAN STATE");
            fullTeamsList.Add("MIDDLE TENNESSEE");
            fullTeamsList.Add("MINNESOTA");
            fullTeamsList.Add("MISSISSIPPI STATE");
            fullTeamsList.Add("MISSISSIPPI VALLEY STATE");
            fullTeamsList.Add("MISSOURI");
            fullTeamsList.Add("MISSOURI STATE");
            fullTeamsList.Add("MONMOUTH");
            fullTeamsList.Add("MONTANA");
            fullTeamsList.Add("MONTANA STATE");
            fullTeamsList.Add("MOREHEAD STATE");
            fullTeamsList.Add("MORGAN STATE");
            fullTeamsList.Add("MURRAY STATE");
            fullTeamsList.Add("NAVY");
            fullTeamsList.Add("NC STATE");
            fullTeamsList.Add("NEBRASKA");
            fullTeamsList.Add("NEVADA");
            fullTeamsList.Add("NEW HAMPSHIRE");
            fullTeamsList.Add("NEW MEXICO");
            fullTeamsList.Add("NEW MEXICO STATE");
            fullTeamsList.Add("NICHOLLS");
            fullTeamsList.Add("NORFOLK STATE");
            fullTeamsList.Add("NORTH CAROLINA");
            fullTeamsList.Add("NORTH CAROLINA A&T");
            fullTeamsList.Add("NORTH CAROLINA CENTRAL");
            fullTeamsList.Add("NORTH DAKOTA");
            fullTeamsList.Add("NORTH DAKOTA STATE");
            fullTeamsList.Add("NORTH TEXAS");
            fullTeamsList.Add("NORTHERN ARIZONA");
            fullTeamsList.Add("NORTHERN COLORADO");
            fullTeamsList.Add("NORTHERN ILLINOIS");
            fullTeamsList.Add("NORTHERN IOWA");
            fullTeamsList.Add("NORTHWESTERN");
            fullTeamsList.Add("NORTHWESTERN STATE");
            fullTeamsList.Add("NOTRE DAME");
            fullTeamsList.Add("OHIO");
            fullTeamsList.Add("OHIO STATE");
            fullTeamsList.Add("OKLAHOMA");
            fullTeamsList.Add("OKLAHOMA STATE");
            fullTeamsList.Add("OLD DOMINION");
            fullTeamsList.Add("OLE MISS");
            fullTeamsList.Add("OREGON");
            fullTeamsList.Add("OREGON STATE");
            fullTeamsList.Add("PENN STATE");
            fullTeamsList.Add("PENNSYLVANIA");
            fullTeamsList.Add("PITTSBURGH");
            fullTeamsList.Add("PORTLAND STATE");
            fullTeamsList.Add("PRAIRIE VIEW");
            fullTeamsList.Add("PRESBYTERIAN COLLEGE");
            fullTeamsList.Add("PRINCETON");
            fullTeamsList.Add("PURDUE");
            fullTeamsList.Add("RHODE ISLAND");
            fullTeamsList.Add("RICE");
            fullTeamsList.Add("RICHMOND");
            fullTeamsList.Add("ROBERT MORRIS");
            fullTeamsList.Add("RUTGERS");
            fullTeamsList.Add("SACRAMENTO STATE");
            fullTeamsList.Add("SACRED HEART");
            fullTeamsList.Add("SAM HOUSTON STATE");
            fullTeamsList.Add("SAMFORD");
            fullTeamsList.Add("SAN DIEGO");
            fullTeamsList.Add("SAN DIEGO STATE");
            fullTeamsList.Add("SAN JOSÉ STATE");
            fullTeamsList.Add("SAVANNAH STATE");
            fullTeamsList.Add("SMU");
            fullTeamsList.Add("SOUTH ALABAMA");
            fullTeamsList.Add("SOUTH CAROLINA");
            fullTeamsList.Add("SOUTH CAROLINA STATE");
            fullTeamsList.Add("SOUTH DAKOTA");
            fullTeamsList.Add("SOUTH DAKOTA STATE");
            fullTeamsList.Add("SOUTH FLORIDA");
            fullTeamsList.Add("SOUTHEAST MISSOURI STATE");
            fullTeamsList.Add("SOUTHEASTERN LOUISIANA");
            fullTeamsList.Add("SOUTHERN ILLINOIS");
            fullTeamsList.Add("SOUTHERN MISSISSIPPI");
            fullTeamsList.Add("SOUTHERN UTAH");
            fullTeamsList.Add("SOUTHLAND");
            fullTeamsList.Add("ST FRANCIS (PA)");
            fullTeamsList.Add("STANFORD");
            fullTeamsList.Add("STEPHEN F. AUSTIN");
            fullTeamsList.Add("STETSON");
            fullTeamsList.Add("STONY BROOK");
            fullTeamsList.Add("SYRACUSE");
            fullTeamsList.Add("TCU");
            fullTeamsList.Add("TEMPLE");
            fullTeamsList.Add("TENNESSEE");
            fullTeamsList.Add("TENNESSEE STATE");
            fullTeamsList.Add("TENNESSEE TECH");
            fullTeamsList.Add("TEXAS");
            fullTeamsList.Add("TEXAS A&M");
            fullTeamsList.Add("TEXAS SOUTHERN");
            fullTeamsList.Add("TEXAS STATE");
            fullTeamsList.Add("TEXAS TECH");
            fullTeamsList.Add("THE CITADEL");
            fullTeamsList.Add("TOLEDO");
            fullTeamsList.Add("TOWSON");
            fullTeamsList.Add("TROY");
            fullTeamsList.Add("TULANE");
            fullTeamsList.Add("TULSA");
            fullTeamsList.Add("UAB");
            fullTeamsList.Add("UC DAVIS");
            fullTeamsList.Add("UCF");
            fullTeamsList.Add("UCLA");
            fullTeamsList.Add("UL LAFAYETTE");
            fullTeamsList.Add("UNLV");
            fullTeamsList.Add("USC");
            fullTeamsList.Add("UT MARTIN");
            fullTeamsList.Add("UT SAN ANTONIO");
            fullTeamsList.Add("UTAH");
            fullTeamsList.Add("UTAH STATE");
            fullTeamsList.Add("UTEP");
            fullTeamsList.Add("VALPARAISO");
            fullTeamsList.Add("VANDERBILT");
            fullTeamsList.Add("VILLANOVA");
            fullTeamsList.Add("VIRGINIA");
            fullTeamsList.Add("VIRGINIA TECH");
            fullTeamsList.Add("VMI");
            fullTeamsList.Add("WAGNER");
            fullTeamsList.Add("WAKE FOREST");
            fullTeamsList.Add("WASHINGTON");
            fullTeamsList.Add("WASHINGTON STATE");
            fullTeamsList.Add("WEBER STATE");
            fullTeamsList.Add("WEST VIRGINIA");
            fullTeamsList.Add("WESTERN CAROLINA");
            fullTeamsList.Add("WESTERN ILLINOIS");
            fullTeamsList.Add("WESTERN KENTUCKY");
            fullTeamsList.Add("WESTERN MICHIGAN");
            fullTeamsList.Add("WILLIAM & MARY");
            fullTeamsList.Add("WISCONSIN");
            fullTeamsList.Add("WOFFORD");
            fullTeamsList.Add("WYOMING");
            fullTeamsList.Add("YALE");
            fullTeamsList.Add("YOUNGSTOWN STATE");
        }

        private bool CheckTeamNamesMatch()
        {
            textBoxList.Clear();
            fullTeamsList.Clear();

            CreateTextBoxList();
            CreateFullTeamsList();

            for (int i = 0; i < textBoxList.Count; i++)
            {
                if (!fullTeamsList.Contains(textBoxList[i]) && textBoxList[i] != "")
                {
                    MessageBox.Show("Team Name " + textBoxList[i] + " does not match any team names please fix it.");
                    return false;
                }
            }
            return true;
        }

        private void OldCodeAddTeamNames()
        {
            /*
                        addItemsByWeek1.Week01Team01 = "1 " + textBoxTeamName01.Text;
                        addItemsByWeek1.Week01Team02 = "2 " + textBoxTeamName02.Text;
                        addItemsByWeek1.Week01Team03 = textBoxTeamName03.Text;
                        addItemsByWeek1.Week01Team04 = textBoxTeamName04.Text;
                        addItemsByWeek1.Week01Team05 = textBoxTeamName05.Text;
                        addItemsByWeek1.Week01Team06 = textBoxTeamName06.Text;
                        addItemsByWeek1.Week01Team07 = textBoxTeamName07.Text;
                        addItemsByWeek1.Week01Team08 = textBoxTeamName08.Text;
                        addItemsByWeek1.Week01Team09 = textBoxTeamName09.Text;
                        addItemsByWeek1.Week01Team10 = textBoxTeamName10.Text;
                        addItemsByWeek1.Week01Team11 = textBoxTeamName11.Text;
                        addItemsByWeek1.Week01Team12 = textBoxTeamName12.Text;
                        addItemsByWeek1.Week01Team13 = textBoxTeamName13.Text;
                        addItemsByWeek1.Week01Team14 = textBoxTeamName14.Text;
                        addItemsByWeek1.Week01Team15 = textBoxTeamName15.Text;
                        addItemsByWeek1.Week01Team16 = textBoxTeamName16.Text;
                        addItemsByWeek1.Week01Team17 = textBoxTeamName17.Text;
                        addItemsByWeek1.Week01Team18 = textBoxTeamName18.Text;
                        addItemsByWeek1.Week01Team19 = textBoxTeamName19.Text;
                        addItemsByWeek1.Week01Team20 = textBoxTeamName20.Text;
                        addItemsByWeek1.Week01Team21 = textBoxTeamName21.Text;
                        addItemsByWeek1.Week01Team22 = textBoxTeamName22.Text;
                        addItemsByWeek1.Week01Team23 = textBoxTeamName23.Text;
                        addItemsByWeek1.Week01Team24 = textBoxTeamName24.Text;
                        addItemsByWeek1.Week01Team25 = textBoxTeamName25.Text;
                        addItemsByWeek1.Week01Team26 = textBoxTeamName26.Text;
                        addItemsByWeek1.Week01Team27 = textBoxTeamName27.Text;
                        addItemsByWeek1.Week01Team28 = textBoxTeamName28.Text;
                        addItemsByWeek1.Week01Team29 = textBoxTeamName29.Text;
                        addItemsByWeek1.Week01Team30 = textBoxTeamName30.Text;
                        addItemsByWeek1.Week01Team31 = textBoxTeamName31.Text;
                        addItemsByWeek1.Week01Team32 = textBoxTeamName32.Text;
                        addItemsByWeek1.Week01Team33 = textBoxTeamName33.Text;
                        addItemsByWeek1.Week01Team34 = textBoxTeamName34.Text;
                        addItemsByWeek1.Week01Team35 = textBoxTeamName35.Text;
                        addItemsByWeek1.Week01Team36 = textBoxTeamName36.Text;
                        addItemsByWeek1.Week01Team37 = textBoxTeamName37.Text;
                        addItemsByWeek1.Week01Team38 = textBoxTeamName38.Text;
                        addItemsByWeek1.Week01Team39 = textBoxTeamName39.Text;
                        addItemsByWeek1.Week01Team40 = textBoxTeamName40.Text;
                        addItemsByWeek1.Week01Team41 = textBoxTeamName41.Text;
                        addItemsByWeek1.Week01Team42 = textBoxTeamName42.Text;
                        addItemsByWeek1.Week01Team43 = textBoxTeamName43.Text;
                        addItemsByWeek1.Week01Team44 = textBoxTeamName44.Text;
                        
                        
                    }
                    // ------------- WEEK 02 --------------------------------------------------
                    else if (weekBox.ToString() == "Week 02")
                    {
                        addItemsByWeek1.Week02Team01 = textBoxTeamName01.Text;
                        addItemsByWeek1.Week02Team02 = textBoxTeamName02.Text;
                        addItemsByWeek1.Week02Team03 = textBoxTeamName03.Text;
                        addItemsByWeek1.Week02Team04 = textBoxTeamName04.Text;
                        addItemsByWeek1.Week02Team05 = textBoxTeamName05.Text;
                        addItemsByWeek1.Week02Team06 = textBoxTeamName06.Text;
                        addItemsByWeek1.Week02Team07 = textBoxTeamName07.Text;
                        addItemsByWeek1.Week02Team08 = textBoxTeamName08.Text;
                        addItemsByWeek1.Week02Team09 = textBoxTeamName09.Text;
                        addItemsByWeek1.Week02Team10 = textBoxTeamName10.Text;
                        addItemsByWeek1.Week02Team11 = textBoxTeamName11.Text;
                        addItemsByWeek1.Week02Team12 = textBoxTeamName12.Text;
                        addItemsByWeek1.Week02Team13 = textBoxTeamName13.Text;
                        addItemsByWeek1.Week02Team14 = textBoxTeamName14.Text;
                        addItemsByWeek1.Week02Team15 = textBoxTeamName15.Text;
                        addItemsByWeek1.Week02Team16 = textBoxTeamName16.Text;
                        addItemsByWeek1.Week02Team17 = textBoxTeamName17.Text;
                        addItemsByWeek1.Week02Team18 = textBoxTeamName18.Text;
                        addItemsByWeek1.Week02Team19 = textBoxTeamName19.Text;
                        addItemsByWeek1.Week02Team20 = textBoxTeamName20.Text;
                        addItemsByWeek1.Week02Team21 = textBoxTeamName21.Text;
                        addItemsByWeek1.Week02Team22 = textBoxTeamName22.Text;
                        addItemsByWeek1.Week02Team23 = textBoxTeamName23.Text;
                        addItemsByWeek1.Week02Team24 = textBoxTeamName24.Text;
                        addItemsByWeek1.Week02Team25 = textBoxTeamName25.Text;
                        addItemsByWeek1.Week02Team26 = textBoxTeamName26.Text;
                        addItemsByWeek1.Week02Team27 = textBoxTeamName27.Text;
                        addItemsByWeek1.Week02Team28 = textBoxTeamName28.Text;
                        addItemsByWeek1.Week02Team29 = textBoxTeamName29.Text;
                        addItemsByWeek1.Week02Team30 = textBoxTeamName30.Text;
                        addItemsByWeek1.Week02Team31 = textBoxTeamName31.Text;
                        addItemsByWeek1.Week02Team32 = textBoxTeamName32.Text;
                        addItemsByWeek1.Week02Team33 = textBoxTeamName33.Text;
                        addItemsByWeek1.Week02Team34 = textBoxTeamName34.Text;
                        addItemsByWeek1.Week02Team35 = textBoxTeamName35.Text;
                        addItemsByWeek1.Week02Team36 = textBoxTeamName36.Text;
                        addItemsByWeek1.Week02Team37 = textBoxTeamName37.Text;
                        addItemsByWeek1.Week02Team38 = textBoxTeamName38.Text;
                        addItemsByWeek1.Week02Team39 = textBoxTeamName39.Text;
                        addItemsByWeek1.Week02Team40 = textBoxTeamName40.Text;
                        addItemsByWeek1.Week02Team41 = textBoxTeamName41.Text;
                        addItemsByWeek1.Week02Team42 = textBoxTeamName42.Text;
                        addItemsByWeek1.Week02Team43 = textBoxTeamName43.Text;
                        addItemsByWeek1.Week02Team44 = textBoxTeamName44.Text;
                        addItemsByWeek1.MaxPicksWeek02 = (int)upDownPicksLimit.Value;

                    }
                    // -------------- WEEK 03 --------------------------------------
                    else if (weekBox.ToString() == "Week 03")
                    {
                        addItemsByWeek1.Week03Team01 = textBoxTeamName01.Text;
                        addItemsByWeek1.Week03Team02 = textBoxTeamName02.Text;
                        addItemsByWeek1.Week03Team03 = textBoxTeamName03.Text;
                        addItemsByWeek1.Week03Team04 = textBoxTeamName04.Text;
                        addItemsByWeek1.Week03Team05 = textBoxTeamName05.Text;
                        addItemsByWeek1.Week03Team06 = textBoxTeamName06.Text;
                        addItemsByWeek1.Week03Team07 = textBoxTeamName07.Text;
                        addItemsByWeek1.Week03Team08 = textBoxTeamName08.Text;
                        addItemsByWeek1.Week03Team09 = textBoxTeamName09.Text;
                        addItemsByWeek1.Week03Team10 = textBoxTeamName10.Text;
                        addItemsByWeek1.Week03Team11 = textBoxTeamName11.Text;
                        addItemsByWeek1.Week03Team12 = textBoxTeamName12.Text;
                        addItemsByWeek1.Week03Team13 = textBoxTeamName13.Text;
                        addItemsByWeek1.Week03Team14 = textBoxTeamName14.Text;
                        addItemsByWeek1.Week03Team15 = textBoxTeamName15.Text;
                        addItemsByWeek1.Week03Team16 = textBoxTeamName16.Text;
                        addItemsByWeek1.Week03Team17 = textBoxTeamName17.Text;
                        addItemsByWeek1.Week03Team18 = textBoxTeamName18.Text;
                        addItemsByWeek1.Week03Team19 = textBoxTeamName19.Text;
                        addItemsByWeek1.Week03Team20 = textBoxTeamName20.Text;
                        addItemsByWeek1.Week03Team21 = textBoxTeamName21.Text;
                        addItemsByWeek1.Week03Team22 = textBoxTeamName22.Text;
                        addItemsByWeek1.Week03Team23 = textBoxTeamName23.Text;
                        addItemsByWeek1.Week03Team24 = textBoxTeamName24.Text;
                        addItemsByWeek1.Week03Team25 = textBoxTeamName25.Text;
                        addItemsByWeek1.Week03Team26 = textBoxTeamName26.Text;
                        addItemsByWeek1.Week03Team27 = textBoxTeamName27.Text;
                        addItemsByWeek1.Week03Team28 = textBoxTeamName28.Text;
                        addItemsByWeek1.Week03Team29 = textBoxTeamName29.Text;
                        addItemsByWeek1.Week03Team30 = textBoxTeamName30.Text;
                        addItemsByWeek1.Week03Team31 = textBoxTeamName31.Text;
                        addItemsByWeek1.Week03Team32 = textBoxTeamName32.Text;
                        addItemsByWeek1.Week03Team33 = textBoxTeamName33.Text;
                        addItemsByWeek1.Week03Team34 = textBoxTeamName34.Text;
                        addItemsByWeek1.Week03Team35 = textBoxTeamName35.Text;
                        addItemsByWeek1.Week03Team36 = textBoxTeamName36.Text;
                        addItemsByWeek1.Week03Team37 = textBoxTeamName37.Text;
                        addItemsByWeek1.Week03Team38 = textBoxTeamName38.Text;
                        addItemsByWeek1.Week03Team39 = textBoxTeamName39.Text;
                        addItemsByWeek1.Week03Team40 = textBoxTeamName40.Text;
                        addItemsByWeek1.Week03Team41 = textBoxTeamName41.Text;
                        addItemsByWeek1.Week03Team42 = textBoxTeamName42.Text;
                        addItemsByWeek1.Week03Team43 = textBoxTeamName43.Text;
                        addItemsByWeek1.Week03Team44 = textBoxTeamName44.Text;
                        addItemsByWeek1.MaxPicksWeek03 = (int)upDownPicksLimit.Value;
                    }
                    // ------------ WEEK 04 -------------------------------------------
                    else if (weekBox.ToString() == "Week 04")
                    {
                        addItemsByWeek1.Week04Team01 = textBoxTeamName01.Text;
                        addItemsByWeek1.Week04Team02 = textBoxTeamName02.Text;
                        addItemsByWeek1.Week04Team03 = textBoxTeamName03.Text;
                        addItemsByWeek1.Week04Team04 = textBoxTeamName04.Text;
                        addItemsByWeek1.Week04Team05 = textBoxTeamName05.Text;
                        addItemsByWeek1.Week04Team06 = textBoxTeamName06.Text;
                        addItemsByWeek1.Week04Team07 = textBoxTeamName07.Text;
                        addItemsByWeek1.Week04Team08 = textBoxTeamName08.Text;
                        addItemsByWeek1.Week04Team09 = textBoxTeamName09.Text;
                        addItemsByWeek1.Week04Team10 = textBoxTeamName10.Text;
                        addItemsByWeek1.Week04Team11 = textBoxTeamName11.Text;
                        addItemsByWeek1.Week04Team12 = textBoxTeamName12.Text;
                        addItemsByWeek1.Week04Team13 = textBoxTeamName13.Text;
                        addItemsByWeek1.Week04Team14 = textBoxTeamName14.Text;
                        addItemsByWeek1.Week04Team15 = textBoxTeamName15.Text;
                        addItemsByWeek1.Week04Team16 = textBoxTeamName16.Text;
                        addItemsByWeek1.Week04Team17 = textBoxTeamName17.Text;
                        addItemsByWeek1.Week04Team18 = textBoxTeamName18.Text;
                        addItemsByWeek1.Week04Team19 = textBoxTeamName19.Text;
                        addItemsByWeek1.Week04Team20 = textBoxTeamName20.Text;
                        addItemsByWeek1.Week04Team21 = textBoxTeamName21.Text;
                        addItemsByWeek1.Week04Team22 = textBoxTeamName22.Text;
                        addItemsByWeek1.Week04Team23 = textBoxTeamName23.Text;
                        addItemsByWeek1.Week04Team24 = textBoxTeamName24.Text;
                        addItemsByWeek1.Week04Team25 = textBoxTeamName25.Text;
                        addItemsByWeek1.Week04Team26 = textBoxTeamName26.Text;
                        addItemsByWeek1.Week04Team27 = textBoxTeamName27.Text;
                        addItemsByWeek1.Week04Team28 = textBoxTeamName28.Text;
                        addItemsByWeek1.Week04Team29 = textBoxTeamName29.Text;
                        addItemsByWeek1.Week04Team30 = textBoxTeamName30.Text;
                        addItemsByWeek1.Week04Team31 = textBoxTeamName31.Text;
                        addItemsByWeek1.Week04Team32 = textBoxTeamName32.Text;
                        addItemsByWeek1.Week04Team33 = textBoxTeamName33.Text;
                        addItemsByWeek1.Week04Team34 = textBoxTeamName34.Text;
                        addItemsByWeek1.Week04Team35 = textBoxTeamName35.Text;
                        addItemsByWeek1.Week04Team36 = textBoxTeamName36.Text;
                        addItemsByWeek1.Week04Team37 = textBoxTeamName37.Text;
                        addItemsByWeek1.Week04Team38 = textBoxTeamName38.Text;
                        addItemsByWeek1.Week04Team39 = textBoxTeamName39.Text;
                        addItemsByWeek1.Week04Team40 = textBoxTeamName40.Text;
                        addItemsByWeek1.Week04Team41 = textBoxTeamName41.Text;
                        addItemsByWeek1.Week04Team42 = textBoxTeamName42.Text;
                        addItemsByWeek1.Week04Team43 = textBoxTeamName43.Text;
                        addItemsByWeek1.Week04Team44 = textBoxTeamName44.Text;
                        addItemsByWeek1.MaxPicksWeek04 = (int)upDownPicksLimit.Value;
                    }
                    // -------------- WEEK 05 -----------------------------------------
                    else if (weekBox.ToString() == "Week 05")
                    {
                        addItemsByWeek1.Week05Team01 = textBoxTeamName01.Text;
                        addItemsByWeek1.Week05Team02 = textBoxTeamName02.Text;
                        addItemsByWeek1.Week05Team03 = textBoxTeamName03.Text;
                        addItemsByWeek1.Week05Team04 = textBoxTeamName04.Text;
                        addItemsByWeek1.Week05Team05 = textBoxTeamName05.Text;
                        addItemsByWeek1.Week05Team06 = textBoxTeamName06.Text;
                        addItemsByWeek1.Week05Team07 = textBoxTeamName07.Text;
                        addItemsByWeek1.Week05Team08 = textBoxTeamName08.Text;
                        addItemsByWeek1.Week05Team09 = textBoxTeamName09.Text;
                        addItemsByWeek1.Week05Team10 = textBoxTeamName10.Text;
                        addItemsByWeek1.Week05Team11 = textBoxTeamName11.Text;
                        addItemsByWeek1.Week05Team12 = textBoxTeamName12.Text;
                        addItemsByWeek1.Week05Team13 = textBoxTeamName13.Text;
                        addItemsByWeek1.Week05Team14 = textBoxTeamName14.Text;
                        addItemsByWeek1.Week05Team15 = textBoxTeamName15.Text;
                        addItemsByWeek1.Week05Team16 = textBoxTeamName16.Text;
                        addItemsByWeek1.Week05Team17 = textBoxTeamName17.Text;
                        addItemsByWeek1.Week05Team18 = textBoxTeamName18.Text;
                        addItemsByWeek1.Week05Team19 = textBoxTeamName19.Text;
                        addItemsByWeek1.Week05Team20 = textBoxTeamName20.Text;
                        addItemsByWeek1.Week05Team21 = textBoxTeamName21.Text;
                        addItemsByWeek1.Week05Team22 = textBoxTeamName22.Text;
                        addItemsByWeek1.Week05Team23 = textBoxTeamName23.Text;
                        addItemsByWeek1.Week05Team24 = textBoxTeamName24.Text;
                        addItemsByWeek1.Week05Team25 = textBoxTeamName25.Text;
                        addItemsByWeek1.Week05Team26 = textBoxTeamName26.Text;
                        addItemsByWeek1.Week05Team27 = textBoxTeamName27.Text;
                        addItemsByWeek1.Week05Team28 = textBoxTeamName28.Text;
                        addItemsByWeek1.Week05Team29 = textBoxTeamName29.Text;
                        addItemsByWeek1.Week05Team30 = textBoxTeamName30.Text;
                        addItemsByWeek1.Week05Team31 = textBoxTeamName31.Text;
                        addItemsByWeek1.Week05Team32 = textBoxTeamName32.Text;
                        addItemsByWeek1.Week05Team33 = textBoxTeamName33.Text;
                        addItemsByWeek1.Week05Team34 = textBoxTeamName34.Text;
                        addItemsByWeek1.Week05Team35 = textBoxTeamName35.Text;
                        addItemsByWeek1.Week05Team36 = textBoxTeamName36.Text;
                        addItemsByWeek1.Week05Team37 = textBoxTeamName37.Text;
                        addItemsByWeek1.Week05Team38 = textBoxTeamName38.Text;
                        addItemsByWeek1.Week05Team39 = textBoxTeamName39.Text;
                        addItemsByWeek1.Week05Team40 = textBoxTeamName40.Text;
                        addItemsByWeek1.Week05Team41 = textBoxTeamName41.Text;
                        addItemsByWeek1.Week05Team42 = textBoxTeamName42.Text;
                        addItemsByWeek1.Week05Team43 = textBoxTeamName43.Text;
                        addItemsByWeek1.Week05Team44 = textBoxTeamName44.Text;
                        addItemsByWeek1.MaxPicksWeek05 = (int)upDownPicksLimit.Value;
                    }
                    // ----------- WEEK 06 ------------------------------------------
                        /// Need to do other DB 6_10 here
                    else if (weekBox.ToString() == "Week 06")
                    {
                        addItemsByWeek2.Week06Team01 = textBoxTeamName01.Text;
                        addItemsByWeek2.Week06Team02 = textBoxTeamName02.Text;
                        addItemsByWeek2.Week06Team03 = textBoxTeamName03.Text;
                        addItemsByWeek2.Week06Team04 = textBoxTeamName04.Text;
                        addItemsByWeek2.Week06Team05 = textBoxTeamName05.Text;
                        addItemsByWeek2.Week06Team06 = textBoxTeamName06.Text;
                        addItemsByWeek2.Week06Team07 = textBoxTeamName07.Text;
                        addItemsByWeek2.Week06Team08 = textBoxTeamName08.Text;
                        addItemsByWeek2.Week06Team09 = textBoxTeamName09.Text;
                        addItemsByWeek2.Week06Team10 = textBoxTeamName10.Text;
                        addItemsByWeek2.Week06Team11 = textBoxTeamName11.Text;
                        addItemsByWeek2.Week06Team12 = textBoxTeamName12.Text;
                        addItemsByWeek2.Week06Team13 = textBoxTeamName13.Text;
                        addItemsByWeek2.Week06Team14 = textBoxTeamName14.Text;
                        addItemsByWeek2.Week06Team15 = textBoxTeamName15.Text;
                        addItemsByWeek2.Week06Team16 = textBoxTeamName16.Text;
                        addItemsByWeek2.Week06Team17 = textBoxTeamName17.Text;
                        addItemsByWeek2.Week06Team18 = textBoxTeamName18.Text;
                        addItemsByWeek2.Week06Team19 = textBoxTeamName19.Text;
                        addItemsByWeek2.Week06Team20 = textBoxTeamName20.Text;
                        addItemsByWeek2.Week06Team21 = textBoxTeamName21.Text;
                        addItemsByWeek2.Week06Team22 = textBoxTeamName22.Text;
                        addItemsByWeek2.Week06Team23 = textBoxTeamName23.Text;
                        addItemsByWeek2.Week06Team24 = textBoxTeamName24.Text;
                        addItemsByWeek2.Week06Team25 = textBoxTeamName25.Text;
                        addItemsByWeek2.Week06Team26 = textBoxTeamName26.Text;
                        addItemsByWeek2.Week06Team27 = textBoxTeamName27.Text;
                        addItemsByWeek2.Week06Team28 = textBoxTeamName28.Text;
                        addItemsByWeek2.Week06Team29 = textBoxTeamName29.Text;
                        addItemsByWeek2.Week06Team30 = textBoxTeamName30.Text;
                        addItemsByWeek2.Week06Team31 = textBoxTeamName31.Text;
                        addItemsByWeek2.Week06Team32 = textBoxTeamName32.Text;
                        addItemsByWeek2.Week06Team33 = textBoxTeamName33.Text;
                        addItemsByWeek2.Week06Team34 = textBoxTeamName34.Text;
                        addItemsByWeek2.Week06Team35 = textBoxTeamName35.Text;
                        addItemsByWeek2.Week06Team36 = textBoxTeamName36.Text;
                        addItemsByWeek2.Week06Team37 = textBoxTeamName37.Text;
                        addItemsByWeek2.Week06Team38 = textBoxTeamName38.Text;
                        addItemsByWeek2.Week06Team39 = textBoxTeamName39.Text;
                        addItemsByWeek2.Week06Team40 = textBoxTeamName40.Text;
                        addItemsByWeek2.Week06Team41 = textBoxTeamName41.Text;
                        addItemsByWeek2.Week06Team42 = textBoxTeamName42.Text;
                        addItemsByWeek2.Week06Team43 = textBoxTeamName43.Text;
                        addItemsByWeek2.Week06Team44 = textBoxTeamName44.Text;
                        addItemsByWeek1.MaxPicksWeek06 = (int)upDownPicksLimit.Value;
                    }
                    // --------- WEEK 07 -------------------------------------------
                    else if (weekBox.ToString() == "Week 07")
                    {
                        addItemsByWeek2.Week07Team01 = textBoxTeamName01.Text;
                        addItemsByWeek2.Week07Team02 = textBoxTeamName02.Text;
                        addItemsByWeek2.Week07Team03 = textBoxTeamName03.Text;
                        addItemsByWeek2.Week07Team04 = textBoxTeamName04.Text;
                        addItemsByWeek2.Week07Team05 = textBoxTeamName05.Text;
                        addItemsByWeek2.Week07Team06 = textBoxTeamName06.Text;
                        addItemsByWeek2.Week07Team07 = textBoxTeamName07.Text;
                        addItemsByWeek2.Week07Team08 = textBoxTeamName08.Text;
                        addItemsByWeek2.Week07Team09 = textBoxTeamName09.Text;
                        addItemsByWeek2.Week07Team10 = textBoxTeamName10.Text;
                        addItemsByWeek2.Week07Team11 = textBoxTeamName11.Text;
                        addItemsByWeek2.Week07Team12 = textBoxTeamName12.Text;
                        addItemsByWeek2.Week07Team13 = textBoxTeamName13.Text;
                        addItemsByWeek2.Week07Team14 = textBoxTeamName14.Text;
                        addItemsByWeek2.Week07Team15 = textBoxTeamName15.Text;
                        addItemsByWeek2.Week07Team16 = textBoxTeamName16.Text;
                        addItemsByWeek2.Week07Team17 = textBoxTeamName17.Text;
                        addItemsByWeek2.Week07Team18 = textBoxTeamName18.Text;
                        addItemsByWeek2.Week07Team19 = textBoxTeamName19.Text;
                        addItemsByWeek2.Week07Team20 = textBoxTeamName20.Text;
                        addItemsByWeek2.Week07Team21 = textBoxTeamName21.Text;
                        addItemsByWeek2.Week07Team22 = textBoxTeamName22.Text;
                        addItemsByWeek2.Week07Team23 = textBoxTeamName23.Text;
                        addItemsByWeek2.Week07Team24 = textBoxTeamName24.Text;
                        addItemsByWeek2.Week07Team25 = textBoxTeamName25.Text;
                        addItemsByWeek2.Week07Team26 = textBoxTeamName26.Text;
                        addItemsByWeek2.Week07Team27 = textBoxTeamName27.Text;
                        addItemsByWeek2.Week07Team28 = textBoxTeamName28.Text;
                        addItemsByWeek2.Week07Team29 = textBoxTeamName29.Text;
                        addItemsByWeek2.Week07Team30 = textBoxTeamName30.Text;
                        addItemsByWeek2.Week07Team31 = textBoxTeamName31.Text;
                        addItemsByWeek2.Week07Team32 = textBoxTeamName32.Text;
                        addItemsByWeek2.Week07Team33 = textBoxTeamName33.Text;
                        addItemsByWeek2.Week07Team34 = textBoxTeamName34.Text;
                        addItemsByWeek2.Week07Team35 = textBoxTeamName35.Text;
                        addItemsByWeek2.Week07Team36 = textBoxTeamName36.Text;
                        addItemsByWeek2.Week07Team37 = textBoxTeamName37.Text;
                        addItemsByWeek2.Week07Team38 = textBoxTeamName38.Text;
                        addItemsByWeek2.Week07Team39 = textBoxTeamName39.Text;
                        addItemsByWeek2.Week07Team40 = textBoxTeamName40.Text;
                        addItemsByWeek2.Week07Team41 = textBoxTeamName41.Text;
                        addItemsByWeek2.Week07Team42 = textBoxTeamName42.Text;
                        addItemsByWeek2.Week07Team43 = textBoxTeamName43.Text;
                        addItemsByWeek2.Week07Team44 = textBoxTeamName44.Text;
                        addItemsByWeek1.MaxPicksWeek07 = (int)upDownPicksLimit.Value;

                    }
                    // --------- WEEK 08 ---------------------------------------
                    else if (weekBox.ToString() == "Week 08")
                    {
                        addItemsByWeek2.Week08Team01 = textBoxTeamName01.Text;
                        addItemsByWeek2.Week08Team02 = textBoxTeamName02.Text;
                        addItemsByWeek2.Week08Team03 = textBoxTeamName03.Text;
                        addItemsByWeek2.Week08Team04 = textBoxTeamName04.Text;
                        addItemsByWeek2.Week08Team05 = textBoxTeamName05.Text;
                        addItemsByWeek2.Week08Team06 = textBoxTeamName06.Text;
                        addItemsByWeek2.Week08Team07 = textBoxTeamName07.Text;
                        addItemsByWeek2.Week08Team08 = textBoxTeamName08.Text;
                        addItemsByWeek2.Week08Team09 = textBoxTeamName09.Text;
                        addItemsByWeek2.Week08Team10 = textBoxTeamName10.Text;
                        addItemsByWeek2.Week08Team11 = textBoxTeamName11.Text;
                        addItemsByWeek2.Week08Team12 = textBoxTeamName12.Text;
                        addItemsByWeek2.Week08Team13 = textBoxTeamName13.Text;
                        addItemsByWeek2.Week08Team14 = textBoxTeamName14.Text;
                        addItemsByWeek2.Week08Team15 = textBoxTeamName15.Text;
                        addItemsByWeek2.Week08Team16 = textBoxTeamName16.Text;
                        addItemsByWeek2.Week08Team17 = textBoxTeamName17.Text;
                        addItemsByWeek2.Week08Team18 = textBoxTeamName18.Text;
                        addItemsByWeek2.Week08Team19 = textBoxTeamName19.Text;
                        addItemsByWeek2.Week08Team20 = textBoxTeamName20.Text;
                        addItemsByWeek2.Week08Team21 = textBoxTeamName21.Text;
                        addItemsByWeek2.Week08Team22 = textBoxTeamName22.Text;
                        addItemsByWeek2.Week08Team23 = textBoxTeamName23.Text;
                        addItemsByWeek2.Week08Team24 = textBoxTeamName24.Text;
                        addItemsByWeek2.Week08Team25 = textBoxTeamName25.Text;
                        addItemsByWeek2.Week08Team26 = textBoxTeamName26.Text;
                        addItemsByWeek2.Week08Team27 = textBoxTeamName27.Text;
                        addItemsByWeek2.Week08Team28 = textBoxTeamName28.Text;
                        addItemsByWeek2.Week08Team29 = textBoxTeamName29.Text;
                        addItemsByWeek2.Week08Team30 = textBoxTeamName30.Text;
                        addItemsByWeek2.Week08Team31 = textBoxTeamName31.Text;
                        addItemsByWeek2.Week08Team32 = textBoxTeamName32.Text;
                        addItemsByWeek2.Week08Team33 = textBoxTeamName33.Text;
                        addItemsByWeek2.Week08Team34 = textBoxTeamName34.Text;
                        addItemsByWeek2.Week08Team35 = textBoxTeamName35.Text;
                        addItemsByWeek2.Week08Team36 = textBoxTeamName36.Text;
                        addItemsByWeek2.Week08Team37 = textBoxTeamName37.Text;
                        addItemsByWeek2.Week08Team38 = textBoxTeamName38.Text;
                        addItemsByWeek2.Week08Team39 = textBoxTeamName39.Text;
                        addItemsByWeek2.Week08Team40 = textBoxTeamName40.Text;
                        addItemsByWeek2.Week08Team41 = textBoxTeamName41.Text;
                        addItemsByWeek2.Week08Team42 = textBoxTeamName42.Text;
                        addItemsByWeek2.Week08Team43 = textBoxTeamName43.Text;
                        addItemsByWeek2.Week08Team44 = textBoxTeamName44.Text;
                        addItemsByWeek1.MaxPicksWeek08 = (int)upDownPicksLimit.Value;

                    }
                    // --------- WEEK 09 -----------------------------------------------
                    else if (weekBox.ToString() == "Week 09")
                    {
                        addItemsByWeek2.Week09Team01 = textBoxTeamName01.Text;
                        addItemsByWeek2.Week09Team02 = textBoxTeamName02.Text;
                        addItemsByWeek2.Week09Team03 = textBoxTeamName03.Text;
                        addItemsByWeek2.Week09Team04 = textBoxTeamName04.Text;
                        addItemsByWeek2.Week09Team05 = textBoxTeamName05.Text;
                        addItemsByWeek2.Week09Team06 = textBoxTeamName06.Text;
                        addItemsByWeek2.Week09Team07 = textBoxTeamName07.Text;
                        addItemsByWeek2.Week09Team08 = textBoxTeamName08.Text;
                        addItemsByWeek2.Week09Team09 = textBoxTeamName09.Text;
                        addItemsByWeek2.Week09Team10 = textBoxTeamName10.Text;
                        addItemsByWeek2.Week09Team11 = textBoxTeamName11.Text;
                        addItemsByWeek2.Week09Team12 = textBoxTeamName12.Text;
                        addItemsByWeek2.Week09Team13 = textBoxTeamName13.Text;
                        addItemsByWeek2.Week09Team14 = textBoxTeamName14.Text;
                        addItemsByWeek2.Week09Team15 = textBoxTeamName15.Text;
                        addItemsByWeek2.Week09Team16 = textBoxTeamName16.Text;
                        addItemsByWeek2.Week09Team17 = textBoxTeamName17.Text;
                        addItemsByWeek2.Week09Team18 = textBoxTeamName18.Text;
                        addItemsByWeek2.Week09Team19 = textBoxTeamName19.Text;
                        addItemsByWeek2.Week09Team20 = textBoxTeamName20.Text;
                        addItemsByWeek2.Week09Team21 = textBoxTeamName21.Text;
                        addItemsByWeek2.Week09Team22 = textBoxTeamName22.Text;
                        addItemsByWeek2.Week09Team23 = textBoxTeamName23.Text;
                        addItemsByWeek2.Week09Team24 = textBoxTeamName24.Text;
                        addItemsByWeek2.Week09Team25 = textBoxTeamName25.Text;
                        addItemsByWeek2.Week09Team26 = textBoxTeamName26.Text;
                        addItemsByWeek2.Week09Team27 = textBoxTeamName27.Text;
                        addItemsByWeek2.Week09Team28 = textBoxTeamName28.Text;
                        addItemsByWeek2.Week09Team29 = textBoxTeamName29.Text;
                        addItemsByWeek2.Week09Team30 = textBoxTeamName30.Text;
                        addItemsByWeek2.Week09Team31 = textBoxTeamName31.Text;
                        addItemsByWeek2.Week09Team32 = textBoxTeamName32.Text;
                        addItemsByWeek2.Week09Team33 = textBoxTeamName33.Text;
                        addItemsByWeek2.Week09Team34 = textBoxTeamName34.Text;
                        addItemsByWeek2.Week09Team35 = textBoxTeamName35.Text;
                        addItemsByWeek2.Week09Team36 = textBoxTeamName36.Text;
                        addItemsByWeek2.Week09Team37 = textBoxTeamName37.Text;
                        addItemsByWeek2.Week09Team38 = textBoxTeamName38.Text;
                        addItemsByWeek2.Week09Team39 = textBoxTeamName39.Text;
                        addItemsByWeek2.Week09Team40 = textBoxTeamName40.Text;
                        addItemsByWeek2.Week09Team41 = textBoxTeamName41.Text;
                        addItemsByWeek2.Week09Team42 = textBoxTeamName42.Text;
                        addItemsByWeek2.Week09Team43 = textBoxTeamName43.Text;
                        addItemsByWeek2.Week09Team44 = textBoxTeamName44.Text;
                        addItemsByWeek1.MaxPicksWeek09 = (int)upDownPicksLimit.Value;
                    }
                    // ------------ WEEK 10 ------------------------------------------------
                    else if (weekBox.ToString() == "Week 10")
                    {
                        addItemsByWeek2.Week10Team01 = textBoxTeamName01.Text;
                        addItemsByWeek2.Week10Team02 = textBoxTeamName02.Text;
                        addItemsByWeek2.Week10Team03 = textBoxTeamName03.Text;
                        addItemsByWeek2.Week10Team04 = textBoxTeamName04.Text;
                        addItemsByWeek2.Week10Team05 = textBoxTeamName05.Text;
                        addItemsByWeek2.Week10Team06 = textBoxTeamName06.Text;
                        addItemsByWeek2.Week10Team07 = textBoxTeamName07.Text;
                        addItemsByWeek2.Week10Team08 = textBoxTeamName08.Text;
                        addItemsByWeek2.Week10Team09 = textBoxTeamName09.Text;
                        addItemsByWeek2.Week10Team10 = textBoxTeamName10.Text;
                        addItemsByWeek2.Week10Team11 = textBoxTeamName11.Text;
                        addItemsByWeek2.Week10Team12 = textBoxTeamName12.Text;
                        addItemsByWeek2.Week10Team13 = textBoxTeamName13.Text;
                        addItemsByWeek2.Week10Team14 = textBoxTeamName14.Text;
                        addItemsByWeek2.Week10Team15 = textBoxTeamName15.Text;
                        addItemsByWeek2.Week10Team16 = textBoxTeamName16.Text;
                        addItemsByWeek2.Week10Team17 = textBoxTeamName17.Text;
                        addItemsByWeek2.Week10Team18 = textBoxTeamName18.Text;
                        addItemsByWeek2.Week10Team19 = textBoxTeamName19.Text;
                        addItemsByWeek2.Week10Team20 = textBoxTeamName20.Text;
                        addItemsByWeek2.Week10Team21 = textBoxTeamName21.Text;
                        addItemsByWeek2.Week10Team22 = textBoxTeamName22.Text;
                        addItemsByWeek2.Week10Team23 = textBoxTeamName23.Text;
                        addItemsByWeek2.Week10Team24 = textBoxTeamName24.Text;
                        addItemsByWeek2.Week10Team25 = textBoxTeamName25.Text;
                        addItemsByWeek2.Week10Team26 = textBoxTeamName26.Text;
                        addItemsByWeek2.Week10Team27 = textBoxTeamName27.Text;
                        addItemsByWeek2.Week10Team28 = textBoxTeamName28.Text;
                        addItemsByWeek2.Week10Team29 = textBoxTeamName29.Text;
                        addItemsByWeek2.Week10Team30 = textBoxTeamName30.Text;
                        addItemsByWeek2.Week10Team31 = textBoxTeamName31.Text;
                        addItemsByWeek2.Week10Team32 = textBoxTeamName32.Text;
                        addItemsByWeek2.Week10Team33 = textBoxTeamName33.Text;
                        addItemsByWeek2.Week10Team34 = textBoxTeamName34.Text;
                        addItemsByWeek2.Week10Team35 = textBoxTeamName35.Text;
                        addItemsByWeek2.Week10Team36 = textBoxTeamName36.Text;
                        addItemsByWeek2.Week10Team37 = textBoxTeamName37.Text;
                        addItemsByWeek2.Week10Team38 = textBoxTeamName38.Text;
                        addItemsByWeek2.Week10Team39 = textBoxTeamName39.Text;
                        addItemsByWeek2.Week10Team40 = textBoxTeamName40.Text;
                        addItemsByWeek2.Week10Team41 = textBoxTeamName41.Text;
                        addItemsByWeek2.Week10Team42 = textBoxTeamName42.Text;
                        addItemsByWeek2.Week10Team43 = textBoxTeamName43.Text;
                        addItemsByWeek2.Week10Team44 = textBoxTeamName44.Text;
                        addItemsByWeek1.MaxPicksWeek10 = (int)upDownPicksLimit.Value;
                    }
                    // ---------------- WEEK 11 -------------------------------------------
                    /// need to do 11_17 here
                    else if (weekBox.ToString() == "Week 11")
                    {
                        addItemsByWeek3.Week11Team01 = textBoxTeamName01.Text;
                        addItemsByWeek3.Week11Team02 = textBoxTeamName02.Text;
                        addItemsByWeek3.Week11Team03 = textBoxTeamName03.Text;
                        addItemsByWeek3.Week11Team04 = textBoxTeamName04.Text;
                        addItemsByWeek3.Week11Team05 = textBoxTeamName05.Text;
                        addItemsByWeek3.Week11Team06 = textBoxTeamName06.Text;
                        addItemsByWeek3.Week11Team07 = textBoxTeamName07.Text;
                        addItemsByWeek3.Week11Team08 = textBoxTeamName08.Text;
                        addItemsByWeek3.Week11Team09 = textBoxTeamName09.Text;
                        addItemsByWeek3.Week11Team10 = textBoxTeamName10.Text;
                        addItemsByWeek3.Week11Team11 = textBoxTeamName11.Text;
                        addItemsByWeek3.Week11Team12 = textBoxTeamName12.Text;
                        addItemsByWeek3.Week11Team13 = textBoxTeamName13.Text;
                        addItemsByWeek3.Week11Team14 = textBoxTeamName14.Text;
                        addItemsByWeek3.Week11Team15 = textBoxTeamName15.Text;
                        addItemsByWeek3.Week11Team16 = textBoxTeamName16.Text;
                        addItemsByWeek3.Week11Team17 = textBoxTeamName17.Text;
                        addItemsByWeek3.Week11Team18 = textBoxTeamName18.Text;
                        addItemsByWeek3.Week11Team19 = textBoxTeamName19.Text;
                        addItemsByWeek3.Week11Team20 = textBoxTeamName20.Text;
                        addItemsByWeek3.Week11Team21 = textBoxTeamName21.Text;
                        addItemsByWeek3.Week11Team22 = textBoxTeamName22.Text;
                        addItemsByWeek3.Week11Team23 = textBoxTeamName23.Text;
                        addItemsByWeek3.Week11Team24 = textBoxTeamName24.Text;
                        addItemsByWeek3.Week11Team25 = textBoxTeamName25.Text;
                        addItemsByWeek3.Week11Team26 = textBoxTeamName26.Text;
                        addItemsByWeek3.Week11Team27 = textBoxTeamName27.Text;
                        addItemsByWeek3.Week11Team28 = textBoxTeamName28.Text;
                        addItemsByWeek3.Week11Team29 = textBoxTeamName29.Text;
                        addItemsByWeek3.Week11Team30 = textBoxTeamName30.Text;
                        addItemsByWeek3.Week11Team31 = textBoxTeamName31.Text;
                        addItemsByWeek3.Week11Team32 = textBoxTeamName32.Text;
                        addItemsByWeek3.Week11Team33 = textBoxTeamName33.Text;
                        addItemsByWeek3.Week11Team34 = textBoxTeamName34.Text;
                        addItemsByWeek3.Week11Team35 = textBoxTeamName35.Text;
                        addItemsByWeek3.Week11Team36 = textBoxTeamName36.Text;
                        addItemsByWeek3.Week11Team37 = textBoxTeamName37.Text;
                        addItemsByWeek3.Week11Team38 = textBoxTeamName38.Text;
                        addItemsByWeek3.Week11Team39 = textBoxTeamName39.Text;
                        addItemsByWeek3.Week11Team40 = textBoxTeamName40.Text;
                        addItemsByWeek3.Week11Team41 = textBoxTeamName41.Text;
                        addItemsByWeek3.Week11Team42 = textBoxTeamName42.Text;
                        addItemsByWeek3.Week11Team43 = textBoxTeamName43.Text;
                        addItemsByWeek3.Week11Team44 = textBoxTeamName44.Text;
                        addItemsByWeek1.MaxPicksWeek11 = (int)upDownPicksLimit.Value;

                    }
                    // ---------- WEEK 12 ---------------------------------------------
                    else if (weekBox.ToString() == "Week 12")
                    {
                        addItemsByWeek3.Week12Team01 = textBoxTeamName01.Text;
                        addItemsByWeek3.Week12Team02 = textBoxTeamName02.Text;
                        addItemsByWeek3.Week12Team03 = textBoxTeamName03.Text;
                        addItemsByWeek3.Week12Team04 = textBoxTeamName04.Text;
                        addItemsByWeek3.Week12Team05 = textBoxTeamName05.Text;
                        addItemsByWeek3.Week12Team06 = textBoxTeamName06.Text;
                        addItemsByWeek3.Week12Team07 = textBoxTeamName07.Text;
                        addItemsByWeek3.Week12Team08 = textBoxTeamName08.Text;
                        addItemsByWeek3.Week12Team09 = textBoxTeamName09.Text;
                        addItemsByWeek3.Week12Team10 = textBoxTeamName10.Text;
                        addItemsByWeek3.Week12Team11 = textBoxTeamName11.Text;
                        addItemsByWeek3.Week12Team12 = textBoxTeamName12.Text;
                        addItemsByWeek3.Week12Team13 = textBoxTeamName13.Text;
                        addItemsByWeek3.Week12Team14 = textBoxTeamName14.Text;
                        addItemsByWeek3.Week12Team15 = textBoxTeamName15.Text;
                        addItemsByWeek3.Week12Team16 = textBoxTeamName16.Text;
                        addItemsByWeek3.Week12Team17 = textBoxTeamName17.Text;
                        addItemsByWeek3.Week12Team18 = textBoxTeamName18.Text;
                        addItemsByWeek3.Week12Team19 = textBoxTeamName19.Text;
                        addItemsByWeek3.Week12Team20 = textBoxTeamName20.Text;
                        addItemsByWeek3.Week12Team21 = textBoxTeamName21.Text;
                        addItemsByWeek3.Week12Team22 = textBoxTeamName22.Text;
                        addItemsByWeek3.Week12Team23 = textBoxTeamName23.Text;
                        addItemsByWeek3.Week12Team24 = textBoxTeamName24.Text;
                        addItemsByWeek3.Week12Team25 = textBoxTeamName25.Text;
                        addItemsByWeek3.Week12Team26 = textBoxTeamName26.Text;
                        addItemsByWeek3.Week12Team27 = textBoxTeamName27.Text;
                        addItemsByWeek3.Week12Team28 = textBoxTeamName28.Text;
                        addItemsByWeek3.Week12Team29 = textBoxTeamName29.Text;
                        addItemsByWeek3.Week12Team30 = textBoxTeamName30.Text;
                        addItemsByWeek3.Week12Team31 = textBoxTeamName31.Text;
                        addItemsByWeek3.Week12Team32 = textBoxTeamName32.Text;
                        addItemsByWeek3.Week12Team33 = textBoxTeamName33.Text;
                        addItemsByWeek3.Week12Team34 = textBoxTeamName34.Text;
                        addItemsByWeek3.Week12Team35 = textBoxTeamName35.Text;
                        addItemsByWeek3.Week12Team36 = textBoxTeamName36.Text;
                        addItemsByWeek3.Week12Team37 = textBoxTeamName37.Text;
                        addItemsByWeek3.Week12Team38 = textBoxTeamName38.Text;
                        addItemsByWeek3.Week12Team39 = textBoxTeamName39.Text;
                        addItemsByWeek3.Week12Team40 = textBoxTeamName40.Text;
                        addItemsByWeek3.Week12Team41 = textBoxTeamName41.Text;
                        addItemsByWeek3.Week12Team42 = textBoxTeamName42.Text;
                        addItemsByWeek3.Week12Team43 = textBoxTeamName43.Text;
                        addItemsByWeek3.Week12Team44 = textBoxTeamName44.Text;
                        addItemsByWeek1.MaxPicksWeek12 = (int)upDownPicksLimit.Value;

                    }
                    // ------------ WEEK 13 -------------------------------------------
                    else if (weekBox.ToString() == "Week 13")
                    {
                        addItemsByWeek3.Week13Team01 = textBoxTeamName01.Text;
                        addItemsByWeek3.Week13Team02 = textBoxTeamName02.Text;
                        addItemsByWeek3.Week13Team03 = textBoxTeamName03.Text;
                        addItemsByWeek3.Week13Team04 = textBoxTeamName04.Text;
                        addItemsByWeek3.Week13Team05 = textBoxTeamName05.Text;
                        addItemsByWeek3.Week13Team06 = textBoxTeamName06.Text;
                        addItemsByWeek3.Week13Team07 = textBoxTeamName07.Text;
                        addItemsByWeek3.Week13Team08 = textBoxTeamName08.Text;
                        addItemsByWeek3.Week13Team09 = textBoxTeamName09.Text;
                        addItemsByWeek3.Week13Team10 = textBoxTeamName10.Text;
                        addItemsByWeek3.Week13Team11 = textBoxTeamName11.Text;
                        addItemsByWeek3.Week13Team12 = textBoxTeamName12.Text;
                        addItemsByWeek3.Week13Team13 = textBoxTeamName13.Text;
                        addItemsByWeek3.Week13Team14 = textBoxTeamName14.Text;
                        addItemsByWeek3.Week13Team15 = textBoxTeamName15.Text;
                        addItemsByWeek3.Week13Team16 = textBoxTeamName16.Text;
                        addItemsByWeek3.Week13Team17 = textBoxTeamName17.Text;
                        addItemsByWeek3.Week13Team18 = textBoxTeamName18.Text;
                        addItemsByWeek3.Week13Team19 = textBoxTeamName19.Text;
                        addItemsByWeek3.Week13Team20 = textBoxTeamName20.Text;
                        addItemsByWeek3.Week13Team21 = textBoxTeamName21.Text;
                        addItemsByWeek3.Week13Team22 = textBoxTeamName22.Text;
                        addItemsByWeek3.Week13Team23 = textBoxTeamName23.Text;
                        addItemsByWeek3.Week13Team24 = textBoxTeamName24.Text;
                        addItemsByWeek3.Week13Team25 = textBoxTeamName25.Text;
                        addItemsByWeek3.Week13Team26 = textBoxTeamName26.Text;
                        addItemsByWeek3.Week13Team27 = textBoxTeamName27.Text;
                        addItemsByWeek3.Week13Team28 = textBoxTeamName28.Text;
                        addItemsByWeek3.Week13Team29 = textBoxTeamName29.Text;
                        addItemsByWeek3.Week13Team30 = textBoxTeamName30.Text;
                        addItemsByWeek3.Week13Team31 = textBoxTeamName31.Text;
                        addItemsByWeek3.Week13Team32 = textBoxTeamName32.Text;
                        addItemsByWeek3.Week13Team33 = textBoxTeamName33.Text;
                        addItemsByWeek3.Week13Team34 = textBoxTeamName34.Text;
                        addItemsByWeek3.Week13Team35 = textBoxTeamName35.Text;
                        addItemsByWeek3.Week13Team36 = textBoxTeamName36.Text;
                        addItemsByWeek3.Week13Team37 = textBoxTeamName37.Text;
                        addItemsByWeek3.Week13Team38 = textBoxTeamName38.Text;
                        addItemsByWeek3.Week13Team39 = textBoxTeamName39.Text;
                        addItemsByWeek3.Week13Team40 = textBoxTeamName40.Text;
                        addItemsByWeek3.Week13Team41 = textBoxTeamName41.Text;
                        addItemsByWeek3.Week13Team42 = textBoxTeamName42.Text;
                        addItemsByWeek3.Week13Team43 = textBoxTeamName43.Text;
                        addItemsByWeek3.Week13Team44 = textBoxTeamName44.Text;
                        addItemsByWeek1.MaxPicksWeek13 = (int)upDownPicksLimit.Value;

                    }
                    // ------------ WEEK 14 -----------------------------------------
                    else if (weekBox.ToString() == "Week 14")
                    {
                        addItemsByWeek3.Week14Team01 = textBoxTeamName01.Text;
                        addItemsByWeek3.Week14Team02 = textBoxTeamName02.Text;
                        addItemsByWeek3.Week14Team03 = textBoxTeamName03.Text;
                        addItemsByWeek3.Week14Team04 = textBoxTeamName04.Text;
                        addItemsByWeek3.Week14Team05 = textBoxTeamName05.Text;
                        addItemsByWeek3.Week14Team06 = textBoxTeamName06.Text;
                        addItemsByWeek3.Week14Team07 = textBoxTeamName07.Text;
                        addItemsByWeek3.Week14Team08 = textBoxTeamName08.Text;
                        addItemsByWeek3.Week14Team09 = textBoxTeamName09.Text;
                        addItemsByWeek3.Week14Team10 = textBoxTeamName10.Text;
                        addItemsByWeek3.Week14Team11 = textBoxTeamName11.Text;
                        addItemsByWeek3.Week14Team12 = textBoxTeamName12.Text;
                        addItemsByWeek3.Week14Team13 = textBoxTeamName13.Text;
                        addItemsByWeek3.Week14Team14 = textBoxTeamName14.Text;
                        addItemsByWeek3.Week14Team15 = textBoxTeamName15.Text;
                        addItemsByWeek3.Week14Team16 = textBoxTeamName16.Text;
                        addItemsByWeek3.Week14Team17 = textBoxTeamName17.Text;
                        addItemsByWeek3.Week14Team18 = textBoxTeamName18.Text;
                        addItemsByWeek3.Week14Team19 = textBoxTeamName19.Text;
                        addItemsByWeek3.Week14Team20 = textBoxTeamName20.Text;
                        addItemsByWeek3.Week14Team21 = textBoxTeamName21.Text;
                        addItemsByWeek3.Week14Team22 = textBoxTeamName22.Text;
                        addItemsByWeek3.Week14Team23 = textBoxTeamName23.Text;
                        addItemsByWeek3.Week14Team24 = textBoxTeamName24.Text;
                        addItemsByWeek3.Week14Team25 = textBoxTeamName25.Text;
                        addItemsByWeek3.Week14Team26 = textBoxTeamName26.Text;
                        addItemsByWeek3.Week14Team27 = textBoxTeamName27.Text;
                        addItemsByWeek3.Week14Team28 = textBoxTeamName28.Text;
                        addItemsByWeek3.Week14Team29 = textBoxTeamName29.Text;
                        addItemsByWeek3.Week14Team30 = textBoxTeamName30.Text;
                        addItemsByWeek3.Week14Team31 = textBoxTeamName31.Text;
                        addItemsByWeek3.Week14Team32 = textBoxTeamName32.Text;
                        addItemsByWeek3.Week14Team33 = textBoxTeamName33.Text;
                        addItemsByWeek3.Week14Team34 = textBoxTeamName34.Text;
                        addItemsByWeek3.Week14Team35 = textBoxTeamName35.Text;
                        addItemsByWeek3.Week14Team36 = textBoxTeamName36.Text;
                        addItemsByWeek3.Week14Team37 = textBoxTeamName37.Text;
                        addItemsByWeek3.Week14Team38 = textBoxTeamName38.Text;
                        addItemsByWeek3.Week14Team39 = textBoxTeamName39.Text;
                        addItemsByWeek3.Week14Team40 = textBoxTeamName40.Text;
                        addItemsByWeek3.Week14Team41 = textBoxTeamName41.Text;
                        addItemsByWeek3.Week14Team42 = textBoxTeamName42.Text;
                        addItemsByWeek3.Week14Team43 = textBoxTeamName43.Text;
                        addItemsByWeek3.Week14Team44 = textBoxTeamName44.Text;
                        addItemsByWeek1.MaxPicksWeek14 = (int)upDownPicksLimit.Value;

                    }
                    // ------------- WEEK 15 -------------------------------------------
                    else if (weekBox.ToString() == "Week 15")
                    {
                        addItemsByWeek3.Week15Team01 = textBoxTeamName01.Text;
                        addItemsByWeek3.Week15Team02 = textBoxTeamName02.Text;
                        addItemsByWeek3.Week15Team03 = textBoxTeamName03.Text;
                        addItemsByWeek3.Week15Team04 = textBoxTeamName04.Text;
                        addItemsByWeek3.Week15Team05 = textBoxTeamName05.Text;
                        addItemsByWeek3.Week15Team06 = textBoxTeamName06.Text;
                        addItemsByWeek3.Week15Team07 = textBoxTeamName07.Text;
                        addItemsByWeek3.Week15Team08 = textBoxTeamName08.Text;
                        addItemsByWeek3.Week15Team09 = textBoxTeamName09.Text;
                        addItemsByWeek3.Week15Team10 = textBoxTeamName10.Text;
                        addItemsByWeek3.Week15Team11 = textBoxTeamName11.Text;
                        addItemsByWeek3.Week15Team12 = textBoxTeamName12.Text;
                        addItemsByWeek3.Week15Team13 = textBoxTeamName13.Text;
                        addItemsByWeek3.Week15Team14 = textBoxTeamName14.Text;
                        addItemsByWeek3.Week15Team15 = textBoxTeamName15.Text;
                        addItemsByWeek3.Week15Team16 = textBoxTeamName16.Text;
                        addItemsByWeek3.Week15Team17 = textBoxTeamName17.Text;
                        addItemsByWeek3.Week15Team18 = textBoxTeamName18.Text;
                        addItemsByWeek3.Week15Team19 = textBoxTeamName19.Text;
                        addItemsByWeek3.Week15Team20 = textBoxTeamName20.Text;
                        addItemsByWeek3.Week15Team21 = textBoxTeamName21.Text;
                        addItemsByWeek3.Week15Team22 = textBoxTeamName22.Text;
                        addItemsByWeek3.Week15Team23 = textBoxTeamName23.Text;
                        addItemsByWeek3.Week15Team24 = textBoxTeamName24.Text;
                        addItemsByWeek3.Week15Team25 = textBoxTeamName25.Text;
                        addItemsByWeek3.Week15Team26 = textBoxTeamName26.Text;
                        addItemsByWeek3.Week15Team27 = textBoxTeamName27.Text;
                        addItemsByWeek3.Week15Team28 = textBoxTeamName28.Text;
                        addItemsByWeek3.Week15Team29 = textBoxTeamName29.Text;
                        addItemsByWeek3.Week15Team30 = textBoxTeamName30.Text;
                        addItemsByWeek3.Week15Team31 = textBoxTeamName31.Text;
                        addItemsByWeek3.Week15Team32 = textBoxTeamName32.Text;
                        addItemsByWeek3.Week15Team33 = textBoxTeamName33.Text;
                        addItemsByWeek3.Week15Team34 = textBoxTeamName34.Text;
                        addItemsByWeek3.Week15Team35 = textBoxTeamName35.Text;
                        addItemsByWeek3.Week15Team36 = textBoxTeamName36.Text;
                        addItemsByWeek3.Week15Team37 = textBoxTeamName37.Text;
                        addItemsByWeek3.Week15Team38 = textBoxTeamName38.Text;
                        addItemsByWeek3.Week15Team39 = textBoxTeamName39.Text;
                        addItemsByWeek3.Week15Team40 = textBoxTeamName40.Text;
                        addItemsByWeek3.Week15Team41 = textBoxTeamName41.Text;
                        addItemsByWeek3.Week15Team42 = textBoxTeamName42.Text;
                        addItemsByWeek3.Week15Team43 = textBoxTeamName43.Text;
                        addItemsByWeek3.Week15Team44 = textBoxTeamName44.Text;
                        addItemsByWeek1.MaxPicksWeek15 = (int)upDownPicksLimit.Value;

                    }
                    // ----------- WEEK 16 -----------------------------------------
                    else if (weekBox.ToString() == "Week 16")
                    {
                        addItemsByWeek3.Week16Team01 = textBoxTeamName01.Text;
                        addItemsByWeek3.Week16Team02 = textBoxTeamName02.Text;
                        addItemsByWeek3.Week16Team03 = textBoxTeamName03.Text;
                        addItemsByWeek3.Week16Team04 = textBoxTeamName04.Text;
                        addItemsByWeek3.Week16Team05 = textBoxTeamName05.Text;
                        addItemsByWeek3.Week16Team06 = textBoxTeamName06.Text;
                        addItemsByWeek3.Week16Team07 = textBoxTeamName07.Text;
                        addItemsByWeek3.Week16Team08 = textBoxTeamName08.Text;
                        addItemsByWeek3.Week16Team09 = textBoxTeamName09.Text;
                        addItemsByWeek3.Week16Team10 = textBoxTeamName10.Text;
                        addItemsByWeek3.Week16Team11 = textBoxTeamName11.Text;
                        addItemsByWeek3.Week16Team12 = textBoxTeamName12.Text;
                        addItemsByWeek3.Week16Team13 = textBoxTeamName13.Text;
                        addItemsByWeek3.Week16Team14 = textBoxTeamName14.Text;
                        addItemsByWeek3.Week16Team15 = textBoxTeamName15.Text;
                        addItemsByWeek3.Week16Team16 = textBoxTeamName16.Text;
                        addItemsByWeek3.Week16Team17 = textBoxTeamName17.Text;
                        addItemsByWeek3.Week16Team18 = textBoxTeamName18.Text;
                        addItemsByWeek3.Week16Team19 = textBoxTeamName19.Text;
                        addItemsByWeek3.Week16Team20 = textBoxTeamName20.Text;
                        addItemsByWeek3.Week16Team21 = textBoxTeamName21.Text;
                        addItemsByWeek3.Week16Team22 = textBoxTeamName22.Text;
                        addItemsByWeek3.Week16Team23 = textBoxTeamName23.Text;
                        addItemsByWeek3.Week16Team24 = textBoxTeamName24.Text;
                        addItemsByWeek3.Week16Team25 = textBoxTeamName25.Text;
                        addItemsByWeek3.Week16Team26 = textBoxTeamName26.Text;
                        addItemsByWeek3.Week16Team27 = textBoxTeamName27.Text;
                        addItemsByWeek3.Week16Team28 = textBoxTeamName28.Text;
                        addItemsByWeek3.Week16Team29 = textBoxTeamName29.Text;
                        addItemsByWeek3.Week16Team30 = textBoxTeamName30.Text;
                        addItemsByWeek3.Week16Team31 = textBoxTeamName31.Text;
                        addItemsByWeek3.Week16Team32 = textBoxTeamName32.Text;
                        addItemsByWeek3.Week16Team33 = textBoxTeamName33.Text;
                        addItemsByWeek3.Week16Team34 = textBoxTeamName34.Text;
                        addItemsByWeek3.Week16Team35 = textBoxTeamName35.Text;
                        addItemsByWeek3.Week16Team36 = textBoxTeamName36.Text;
                        addItemsByWeek3.Week16Team37 = textBoxTeamName37.Text;
                        addItemsByWeek3.Week16Team38 = textBoxTeamName38.Text;
                        addItemsByWeek3.Week16Team39 = textBoxTeamName39.Text;
                        addItemsByWeek3.Week16Team40 = textBoxTeamName40.Text;
                        addItemsByWeek3.Week16Team41 = textBoxTeamName41.Text;
                        addItemsByWeek3.Week16Team42 = textBoxTeamName42.Text;
                        addItemsByWeek3.Week16Team43 = textBoxTeamName43.Text;
                        addItemsByWeek3.Week16Team44 = textBoxTeamName44.Text;
                        addItemsByWeek1.MaxPicksWeek16 = (int)upDownPicksLimit.Value;

                    }
                    // ---------------- WEEK 17 --------------------------------------------
                    else if (weekBox.ToString() == "Week 17")
                    {
                        addItemsByWeek3.Week17Team01 = textBoxTeamName01.Text;
                        addItemsByWeek3.Week17Team02 = textBoxTeamName02.Text;
                        addItemsByWeek3.Week17Team03 = textBoxTeamName03.Text;
                        addItemsByWeek3.Week17Team04 = textBoxTeamName04.Text;
                        addItemsByWeek3.Week17Team05 = textBoxTeamName05.Text;
                        addItemsByWeek3.Week17Team06 = textBoxTeamName06.Text;
                        addItemsByWeek3.Week17Team07 = textBoxTeamName07.Text;
                        addItemsByWeek3.Week17Team08 = textBoxTeamName08.Text;
                        addItemsByWeek3.Week17Team09 = textBoxTeamName09.Text;
                        addItemsByWeek3.Week17Team10 = textBoxTeamName10.Text;
                        addItemsByWeek3.Week17Team11 = textBoxTeamName11.Text;
                        addItemsByWeek3.Week17Team12 = textBoxTeamName12.Text;
                        addItemsByWeek3.Week17Team13 = textBoxTeamName13.Text;
                        addItemsByWeek3.Week17Team14 = textBoxTeamName14.Text;
                        addItemsByWeek3.Week17Team15 = textBoxTeamName15.Text;
                        addItemsByWeek3.Week17Team16 = textBoxTeamName16.Text;
                        addItemsByWeek3.Week17Team17 = textBoxTeamName17.Text;
                        addItemsByWeek3.Week17Team18 = textBoxTeamName18.Text;
                        addItemsByWeek3.Week17Team19 = textBoxTeamName19.Text;
                        addItemsByWeek3.Week17Team20 = textBoxTeamName20.Text;
                        addItemsByWeek3.Week17Team21 = textBoxTeamName21.Text;
                        addItemsByWeek3.Week17Team22 = textBoxTeamName22.Text;
                        addItemsByWeek3.Week17Team23 = textBoxTeamName23.Text;
                        addItemsByWeek3.Week17Team24 = textBoxTeamName24.Text;
                        addItemsByWeek3.Week17Team25 = textBoxTeamName25.Text;
                        addItemsByWeek3.Week17Team26 = textBoxTeamName26.Text;
                        addItemsByWeek3.Week17Team27 = textBoxTeamName27.Text;
                        addItemsByWeek3.Week17Team28 = textBoxTeamName28.Text;
                        addItemsByWeek3.Week17Team29 = textBoxTeamName29.Text;
                        addItemsByWeek3.Week17Team30 = textBoxTeamName30.Text;
                        addItemsByWeek3.Week17Team31 = textBoxTeamName31.Text;
                        addItemsByWeek3.Week17Team32 = textBoxTeamName32.Text;
                        addItemsByWeek3.Week17Team33 = textBoxTeamName33.Text;
                        addItemsByWeek3.Week17Team34 = textBoxTeamName34.Text;
                        addItemsByWeek3.Week17Team35 = textBoxTeamName35.Text;
                        addItemsByWeek3.Week17Team36 = textBoxTeamName36.Text;
                        addItemsByWeek3.Week17Team37 = textBoxTeamName37.Text;
                        addItemsByWeek3.Week17Team38 = textBoxTeamName38.Text;
                        addItemsByWeek3.Week17Team39 = textBoxTeamName39.Text;
                        addItemsByWeek3.Week17Team40 = textBoxTeamName40.Text;
                        addItemsByWeek3.Week17Team41 = textBoxTeamName41.Text;
                        addItemsByWeek3.Week17Team42 = textBoxTeamName42.Text;
                        addItemsByWeek3.Week17Team43 = textBoxTeamName43.Text;
                        addItemsByWeek3.Week17Team44 = textBoxTeamName44.Text;
                        addItemsByWeek1.MaxPicksWeek17 = (int)upDownPicksLimit.Value;
                        */
        }
        private void OldCodeUpdateTextBoxes()
        {
            /* OLD CODE GOOD LORD
                    textBoxTeamName01.Text = (String.IsNullOrEmpty(selectedSeason1.Week01Team01)) ? selectedSeason1.Week01Team01 : selectedSeason1.Week01Team01.Substring(2).Trim();
                    textBoxTeamName02.Text = (String.IsNullOrEmpty(selectedSeason1.Week01Team02)) ? selectedSeason1.Week01Team02 : selectedSeason1.Week01Team02.Substring(2).Trim();
                    textBoxTeamName03.Text = (String.IsNullOrEmpty(selectedSeason1.Week01Team03)) ? selectedSeason1.Week01Team03 : selectedSeason1.Week01Team03.Substring(2).Trim();
                    textBoxTeamName04.Text = (String.IsNullOrEmpty(selectedSeason1.Week01Team04)) ? selectedSeason1.Week01Team04 : selectedSeason1.Week01Team04.Substring(2).Trim();
                    textBoxTeamName05.Text = (String.IsNullOrEmpty(selectedSeason1.Week01Team05)) ? selectedSeason1.Week01Team05 : selectedSeason1.Week01Team05.Substring(2).Trim();
                    textBoxTeamName06.Text = (String.IsNullOrEmpty(selectedSeason1.Week01Team06)) ? selectedSeason1.Week01Team06 : selectedSeason1.Week01Team06.Substring(2).Trim();
                    textBoxTeamName07.Text = (String.IsNullOrEmpty(selectedSeason1.Week01Team07)) ? selectedSeason1.Week01Team07 : selectedSeason1.Week01Team07.Substring(2).Trim();
                    textBoxTeamName08.Text = (String.IsNullOrEmpty(selectedSeason1.Week01Team08)) ? selectedSeason1.Week01Team08 : selectedSeason1.Week01Team08.Substring(2).Trim();
                    textBoxTeamName09.Text = (String.IsNullOrEmpty(selectedSeason1.Week01Team09)) ? selectedSeason1.Week01Team09 : selectedSeason1.Week01Team09.Substring(2).Trim();
                    textBoxTeamName10.Text = (String.IsNullOrEmpty(selectedSeason1.Week01Team10)) ? selectedSeason1.Week01Team10 : selectedSeason1.Week01Team10.Substring(2).Trim();
                    textBoxTeamName11.Text = (String.IsNullOrEmpty(selectedSeason1.Week01Team11)) ? selectedSeason1.Week01Team11 : selectedSeason1.Week01Team11.Substring(2).Trim();
                    textBoxTeamName12.Text = (String.IsNullOrEmpty(selectedSeason1.Week01Team12)) ? selectedSeason1.Week01Team12 : selectedSeason1.Week01Team12.Substring(2).Trim();
                    textBoxTeamName13.Text = (String.IsNullOrEmpty(selectedSeason1.Week01Team13)) ? selectedSeason1.Week01Team13 : selectedSeason1.Week01Team13.Substring(2).Trim();
                    textBoxTeamName14.Text = (String.IsNullOrEmpty(selectedSeason1.Week01Team14)) ? selectedSeason1.Week01Team14 : selectedSeason1.Week01Team14.Substring(2).Trim();
                    textBoxTeamName15.Text = (String.IsNullOrEmpty(selectedSeason1.Week01Team15)) ? selectedSeason1.Week01Team15 : selectedSeason1.Week01Team15.Substring(2).Trim();
                    textBoxTeamName16.Text = (String.IsNullOrEmpty(selectedSeason1.Week01Team16)) ? selectedSeason1.Week01Team16 : selectedSeason1.Week01Team16.Substring(2).Trim();
                    textBoxTeamName17.Text = (String.IsNullOrEmpty(selectedSeason1.Week01Team17)) ? selectedSeason1.Week01Team17 : selectedSeason1.Week01Team17.Substring(2).Trim();
                    textBoxTeamName18.Text = (String.IsNullOrEmpty(selectedSeason1.Week01Team18)) ? selectedSeason1.Week01Team18 : selectedSeason1.Week01Team18.Substring(2).Trim();
                    textBoxTeamName19.Text = (String.IsNullOrEmpty(selectedSeason1.Week01Team19)) ? selectedSeason1.Week01Team19 : selectedSeason1.Week01Team19.Substring(2).Trim();
                    textBoxTeamName20.Text = (String.IsNullOrEmpty(selectedSeason1.Week01Team20)) ? selectedSeason1.Week01Team20 : selectedSeason1.Week01Team20.Substring(2).Trim();
                    textBoxTeamName21.Text = (String.IsNullOrEmpty(selectedSeason1.Week01Team21)) ? selectedSeason1.Week01Team21 : selectedSeason1.Week01Team21.Substring(2).Trim();
                    textBoxTeamName22.Text = (String.IsNullOrEmpty(selectedSeason1.Week01Team22)) ? selectedSeason1.Week01Team22 : selectedSeason1.Week01Team22.Substring(2).Trim();
                    textBoxTeamName23.Text = (String.IsNullOrEmpty(selectedSeason1.Week01Team23)) ? selectedSeason1.Week01Team23 : selectedSeason1.Week01Team23.Substring(2).Trim();
                    textBoxTeamName24.Text = (String.IsNullOrEmpty(selectedSeason1.Week01Team24)) ? selectedSeason1.Week01Team24 : selectedSeason1.Week01Team24.Substring(2).Trim();
                    textBoxTeamName25.Text = (String.IsNullOrEmpty(selectedSeason1.Week01Team25)) ? selectedSeason1.Week01Team25 : selectedSeason1.Week01Team25.Substring(2).Trim();
                    textBoxTeamName26.Text = (String.IsNullOrEmpty(selectedSeason1.Week01Team26)) ? selectedSeason1.Week01Team26 : selectedSeason1.Week01Team26.Substring(2).Trim();
                    textBoxTeamName27.Text = (String.IsNullOrEmpty(selectedSeason1.Week01Team27)) ? selectedSeason1.Week01Team27 : selectedSeason1.Week01Team27.Substring(2).Trim();
                    textBoxTeamName28.Text = (String.IsNullOrEmpty(selectedSeason1.Week01Team28)) ? selectedSeason1.Week01Team28 : selectedSeason1.Week01Team28.Substring(2).Trim();
                    textBoxTeamName29.Text = (String.IsNullOrEmpty(selectedSeason1.Week01Team29)) ? selectedSeason1.Week01Team29 : selectedSeason1.Week01Team29.Substring(2).Trim();
                    textBoxTeamName30.Text = (String.IsNullOrEmpty(selectedSeason1.Week01Team30)) ? selectedSeason1.Week01Team30 : selectedSeason1.Week01Team30.Substring(2).Trim();
                    textBoxTeamName31.Text = selectedSeason1.Week01Team31.Substring(2).Trim();
                    textBoxTeamName32.Text = selectedSeason1.Week01Team32.Substring(2).Trim();
                    textBoxTeamName33.Text = selectedSeason1.Week01Team33.Substring(2).Trim();
                    textBoxTeamName34.Text = selectedSeason1.Week01Team34.Substring(2).Trim();
                    textBoxTeamName35.Text = selectedSeason1.Week01Team35.Substring(2).Trim();
                    textBoxTeamName36.Text = selectedSeason1.Week01Team36.Substring(2).Trim();
                    textBoxTeamName37.Text = selectedSeason1.Week01Team37.Substring(2).Trim();
                    textBoxTeamName38.Text = selectedSeason1.Week01Team38.Substring(2).Trim();
                    textBoxTeamName39.Text = selectedSeason1.Week01Team39.Substring(2).Trim();
                    textBoxTeamName40.Text = selectedSeason1.Week01Team40.Substring(2).Trim();
                    textBoxTeamName41.Text = selectedSeason1.Week01Team41.Substring(2).Trim();
                    textBoxTeamName42.Text = selectedSeason1.Week01Team42.Substring(2).Trim();
                    textBoxTeamName43.Text = selectedSeason1.Week01Team43.Substring(2).Trim();
                    textBoxTeamName44.Text = selectedSeason1.Week01Team44.Substring(2).Trim();
                    

                    // ------------------- WEEK 02 -------------------------
                    if (comboBoxSelectWeekSeason.Text == "Week 02" && selectedSeason1.Week02Team01 != "")
                    {
                        textBoxTeamName01.Text = selectedSeason1.Week02Team01.Substring(2).Trim();
                        textBoxTeamName02.Text = selectedSeason1.Week02Team02.Substring(2).Trim();
                        textBoxTeamName03.Text = selectedSeason1.Week02Team03.Substring(2).Trim();
                        textBoxTeamName04.Text = selectedSeason1.Week02Team04.Substring(2).Trim();
                        textBoxTeamName05.Text = selectedSeason1.Week02Team05.Substring(2).Trim();
                        textBoxTeamName06.Text = selectedSeason1.Week02Team06.Substring(2).Trim();
                        textBoxTeamName07.Text = selectedSeason1.Week02Team07.Substring(2).Trim();
                        textBoxTeamName08.Text = selectedSeason1.Week02Team08.Substring(2).Trim();
                        textBoxTeamName09.Text = selectedSeason1.Week02Team09.Substring(2).Trim();
                        textBoxTeamName10.Text = selectedSeason1.Week02Team10.Substring(2).Trim();
                        textBoxTeamName11.Text = selectedSeason1.Week02Team11.Substring(2).Trim();
                        textBoxTeamName12.Text = selectedSeason1.Week02Team12.Substring(2).Trim();
                        textBoxTeamName13.Text = selectedSeason1.Week02Team13.Substring(2).Trim();
                        textBoxTeamName14.Text = selectedSeason1.Week02Team14.Substring(2).Trim();
                        textBoxTeamName15.Text = selectedSeason1.Week02Team15.Substring(2).Trim();
                        textBoxTeamName16.Text = selectedSeason1.Week02Team16.Substring(2).Trim();
                        textBoxTeamName17.Text = selectedSeason1.Week02Team17.Substring(2).Trim();
                        textBoxTeamName18.Text = selectedSeason1.Week02Team18.Substring(2).Trim();
                        textBoxTeamName19.Text = selectedSeason1.Week02Team19.Substring(2).Trim();
                        textBoxTeamName20.Text = selectedSeason1.Week02Team20.Substring(2).Trim();
                        textBoxTeamName21.Text = selectedSeason1.Week02Team21.Substring(2).Trim();
                        textBoxTeamName22.Text = selectedSeason1.Week02Team22.Substring(2).Trim();
                        textBoxTeamName23.Text = selectedSeason1.Week02Team23.Substring(2).Trim();
                        textBoxTeamName24.Text = selectedSeason1.Week02Team24.Substring(2).Trim();
                        textBoxTeamName25.Text = selectedSeason1.Week02Team25.Substring(2).Trim();
                        textBoxTeamName26.Text = selectedSeason1.Week02Team26.Substring(2).Trim();
                        textBoxTeamName27.Text = selectedSeason1.Week02Team27.Substring(2).Trim();
                        textBoxTeamName28.Text = selectedSeason1.Week02Team28.Substring(2).Trim();
                        textBoxTeamName29.Text = selectedSeason1.Week02Team29.Substring(2).Trim();
                        textBoxTeamName30.Text = selectedSeason1.Week02Team30.Substring(2).Trim();
                        textBoxTeamName31.Text = selectedSeason1.Week02Team31.Substring(2).Trim();
                        textBoxTeamName32.Text = selectedSeason1.Week02Team32.Substring(2).Trim();
                        textBoxTeamName33.Text = selectedSeason1.Week02Team33.Substring(2).Trim();
                        textBoxTeamName34.Text = selectedSeason1.Week02Team34.Substring(2).Trim();
                        textBoxTeamName35.Text = selectedSeason1.Week02Team35.Substring(2).Trim();
                        textBoxTeamName36.Text = selectedSeason1.Week02Team36.Substring(2).Trim();
                        textBoxTeamName37.Text = selectedSeason1.Week02Team37.Substring(2).Trim();
                        textBoxTeamName38.Text = selectedSeason1.Week02Team38.Substring(2).Trim();
                        textBoxTeamName39.Text = selectedSeason1.Week02Team39.Substring(2).Trim();
                        textBoxTeamName40.Text = selectedSeason1.Week02Team40.Substring(2).Trim();
                        textBoxTeamName41.Text = selectedSeason1.Week02Team41.Substring(2).Trim();
                        textBoxTeamName42.Text = selectedSeason1.Week02Team42.Substring(2).Trim();
                        textBoxTeamName43.Text = selectedSeason1.Week02Team43.Substring(2).Trim();
                        textBoxTeamName44.Text = selectedSeason1.Week02Team44.Substring(2).Trim();
                        upDownPicksLimit.Value = selectedSeason1.MaxPicksWeek02;
                    }
                    

                    // ------------------- WEEK 03 -------------------------
                    if (comboBoxSelectWeekSeason.Text == "Week 03" && selectedSeason1.Week03Team01 != "")
                    {
                        textBoxTeamName01.Text = selectedSeason1.Week03Team01.Substring(2).Trim();
                        textBoxTeamName02.Text = selectedSeason1.Week03Team02.Substring(2).Trim();
                        textBoxTeamName03.Text = selectedSeason1.Week03Team03.Substring(2).Trim();
                        textBoxTeamName04.Text = selectedSeason1.Week03Team04.Substring(2).Trim();
                        textBoxTeamName05.Text = selectedSeason1.Week03Team05.Substring(2).Trim();
                        textBoxTeamName06.Text = selectedSeason1.Week03Team06.Substring(2).Trim();
                        textBoxTeamName07.Text = selectedSeason1.Week03Team07.Substring(2).Trim();
                        textBoxTeamName08.Text = selectedSeason1.Week03Team08.Substring(2).Trim();
                        textBoxTeamName09.Text = selectedSeason1.Week03Team09.Substring(2).Trim();
                        textBoxTeamName10.Text = selectedSeason1.Week03Team10.Substring(2).Trim();
                        textBoxTeamName11.Text = selectedSeason1.Week03Team11.Substring(2).Trim();
                        textBoxTeamName12.Text = selectedSeason1.Week03Team12.Substring(2).Trim();
                        textBoxTeamName13.Text = selectedSeason1.Week03Team13.Substring(2).Trim();
                        textBoxTeamName14.Text = selectedSeason1.Week03Team14.Substring(2).Trim();
                        textBoxTeamName15.Text = selectedSeason1.Week03Team15.Substring(2).Trim();
                        textBoxTeamName16.Text = selectedSeason1.Week03Team16.Substring(2).Trim();
                        textBoxTeamName17.Text = selectedSeason1.Week03Team17.Substring(2).Trim();
                        textBoxTeamName18.Text = selectedSeason1.Week03Team18.Substring(2).Trim();
                        textBoxTeamName19.Text = selectedSeason1.Week03Team19.Substring(2).Trim();
                        textBoxTeamName20.Text = selectedSeason1.Week03Team20.Substring(2).Trim();
                        textBoxTeamName21.Text = selectedSeason1.Week03Team21.Substring(2).Trim();
                        textBoxTeamName22.Text = selectedSeason1.Week03Team22.Substring(2).Trim();
                        textBoxTeamName23.Text = selectedSeason1.Week03Team23.Substring(2).Trim();
                        textBoxTeamName24.Text = selectedSeason1.Week03Team24.Substring(2).Trim();
                        textBoxTeamName25.Text = selectedSeason1.Week03Team25.Substring(2).Trim();
                        textBoxTeamName26.Text = selectedSeason1.Week03Team26.Substring(2).Trim();
                        textBoxTeamName27.Text = selectedSeason1.Week03Team27.Substring(2).Trim();
                        textBoxTeamName28.Text = selectedSeason1.Week03Team28.Substring(2).Trim();
                        textBoxTeamName29.Text = selectedSeason1.Week03Team29.Substring(2).Trim();
                        textBoxTeamName30.Text = selectedSeason1.Week03Team30.Substring(2).Trim();
                        textBoxTeamName31.Text = selectedSeason1.Week03Team31.Substring(2).Trim();
                        textBoxTeamName32.Text = selectedSeason1.Week03Team32.Substring(2).Trim();
                        textBoxTeamName33.Text = selectedSeason1.Week03Team33.Substring(2).Trim();
                        textBoxTeamName34.Text = selectedSeason1.Week03Team34.Substring(2).Trim();
                        textBoxTeamName35.Text = selectedSeason1.Week03Team35.Substring(2).Trim();
                        textBoxTeamName36.Text = selectedSeason1.Week03Team36.Substring(2).Trim();
                        textBoxTeamName37.Text = selectedSeason1.Week03Team37.Substring(2).Trim();
                        textBoxTeamName38.Text = selectedSeason1.Week03Team38.Substring(2).Trim();
                        textBoxTeamName39.Text = selectedSeason1.Week03Team39.Substring(2).Trim();
                        textBoxTeamName40.Text = selectedSeason1.Week03Team40.Substring(2).Trim();
                        textBoxTeamName41.Text = selectedSeason1.Week03Team41.Substring(2).Trim();
                        textBoxTeamName42.Text = selectedSeason1.Week03Team42.Substring(2).Trim();
                        textBoxTeamName43.Text = selectedSeason1.Week03Team43.Substring(2).Trim();
                        textBoxTeamName44.Text = selectedSeason1.Week03Team44.Substring(2).Trim();
                        upDownPicksLimit.Value = selectedSeason1.MaxPicksWeek03;
                    }

                    // ------------------- WEEK 04 -------------------------
                    if (comboBoxSelectWeekSeason.Text == "Week 04" && selectedSeason1.Week04Team01 != "")
                    {
                        textBoxTeamName01.Text = selectedSeason1.Week04Team01.Substring(2).Trim();
                        textBoxTeamName02.Text = selectedSeason1.Week04Team02.Substring(2).Trim();
                        textBoxTeamName03.Text = selectedSeason1.Week04Team03.Substring(2).Trim();
                        textBoxTeamName04.Text = selectedSeason1.Week04Team04.Substring(2).Trim();
                        textBoxTeamName05.Text = selectedSeason1.Week04Team05.Substring(2).Trim();
                        textBoxTeamName06.Text = selectedSeason1.Week04Team06.Substring(2).Trim();
                        textBoxTeamName07.Text = selectedSeason1.Week04Team07.Substring(2).Trim();
                        textBoxTeamName08.Text = selectedSeason1.Week04Team08.Substring(2).Trim();
                        textBoxTeamName09.Text = selectedSeason1.Week04Team09.Substring(2).Trim();
                        textBoxTeamName10.Text = selectedSeason1.Week04Team10.Substring(2).Trim();
                        textBoxTeamName11.Text = selectedSeason1.Week04Team11.Substring(2).Trim();
                        textBoxTeamName12.Text = selectedSeason1.Week04Team12.Substring(2).Trim();
                        textBoxTeamName13.Text = selectedSeason1.Week04Team13.Substring(2).Trim();
                        textBoxTeamName14.Text = selectedSeason1.Week04Team14.Substring(2).Trim();
                        textBoxTeamName15.Text = selectedSeason1.Week04Team15.Substring(2).Trim();
                        textBoxTeamName16.Text = selectedSeason1.Week04Team16.Substring(2).Trim();
                        textBoxTeamName17.Text = selectedSeason1.Week04Team17.Substring(2).Trim();
                        textBoxTeamName18.Text = selectedSeason1.Week04Team18.Substring(2).Trim();
                        textBoxTeamName19.Text = selectedSeason1.Week04Team19.Substring(2).Trim();
                        textBoxTeamName20.Text = selectedSeason1.Week04Team20.Substring(2).Trim();
                        textBoxTeamName21.Text = selectedSeason1.Week04Team21.Substring(2).Trim();
                        textBoxTeamName22.Text = selectedSeason1.Week04Team22.Substring(2).Trim();
                        textBoxTeamName23.Text = selectedSeason1.Week04Team23.Substring(2).Trim();
                        textBoxTeamName24.Text = selectedSeason1.Week04Team24.Substring(2).Trim();
                        textBoxTeamName25.Text = selectedSeason1.Week04Team25.Substring(2).Trim();
                        textBoxTeamName26.Text = selectedSeason1.Week04Team26.Substring(2).Trim();
                        textBoxTeamName27.Text = selectedSeason1.Week04Team27.Substring(2).Trim();
                        textBoxTeamName28.Text = selectedSeason1.Week04Team28.Substring(2).Trim();
                        textBoxTeamName29.Text = selectedSeason1.Week04Team29.Substring(2).Trim();
                        textBoxTeamName30.Text = selectedSeason1.Week04Team30.Substring(2).Trim();
                        textBoxTeamName31.Text = selectedSeason1.Week04Team31.Substring(2).Trim();
                        textBoxTeamName32.Text = selectedSeason1.Week04Team32.Substring(2).Trim();
                        textBoxTeamName33.Text = selectedSeason1.Week04Team33.Substring(2).Trim();
                        textBoxTeamName34.Text = selectedSeason1.Week04Team34.Substring(2).Trim();
                        textBoxTeamName35.Text = selectedSeason1.Week04Team35.Substring(2).Trim();
                        textBoxTeamName36.Text = selectedSeason1.Week04Team36.Substring(2).Trim();
                        textBoxTeamName37.Text = selectedSeason1.Week04Team37.Substring(2).Trim();
                        textBoxTeamName38.Text = selectedSeason1.Week04Team38.Substring(2).Trim();
                        textBoxTeamName39.Text = selectedSeason1.Week04Team39.Substring(2).Trim();
                        textBoxTeamName40.Text = selectedSeason1.Week04Team40.Substring(2).Trim();
                        textBoxTeamName41.Text = selectedSeason1.Week04Team41.Substring(2).Trim();
                        textBoxTeamName42.Text = selectedSeason1.Week04Team42.Substring(2).Trim();
                        textBoxTeamName43.Text = selectedSeason1.Week04Team43.Substring(2).Trim();
                        textBoxTeamName44.Text = selectedSeason1.Week04Team44.Substring(2).Trim();
                        upDownPicksLimit.Value = selectedSeason1.MaxPicksWeek04;
                    }

                    // ------------------- WEEK 05 -------------------------
                    if (comboBoxSelectWeekSeason.Text == "Week 05" && selectedSeason1.Week05Team01 != "")
                    {
                        textBoxTeamName01.Text = selectedSeason1.Week05Team01.Substring(2).Trim();
                        textBoxTeamName02.Text = selectedSeason1.Week05Team02.Substring(2).Trim();
                        textBoxTeamName03.Text = selectedSeason1.Week05Team03.Substring(2).Trim();
                        textBoxTeamName04.Text = selectedSeason1.Week05Team04.Substring(2).Trim();
                        textBoxTeamName05.Text = selectedSeason1.Week05Team05.Substring(2).Trim();
                        textBoxTeamName06.Text = selectedSeason1.Week05Team06.Substring(2).Trim();
                        textBoxTeamName07.Text = selectedSeason1.Week05Team07.Substring(2).Trim();
                        textBoxTeamName08.Text = selectedSeason1.Week05Team08.Substring(2).Trim();
                        textBoxTeamName09.Text = selectedSeason1.Week05Team09.Substring(2).Trim();
                        textBoxTeamName10.Text = selectedSeason1.Week05Team10.Substring(2).Trim();
                        textBoxTeamName11.Text = selectedSeason1.Week05Team11.Substring(2).Trim();
                        textBoxTeamName12.Text = selectedSeason1.Week05Team12.Substring(2).Trim();
                        textBoxTeamName13.Text = selectedSeason1.Week05Team13.Substring(2).Trim();
                        textBoxTeamName14.Text = selectedSeason1.Week05Team14.Substring(2).Trim();
                        textBoxTeamName15.Text = selectedSeason1.Week05Team15.Substring(2).Trim();
                        textBoxTeamName16.Text = selectedSeason1.Week05Team16.Substring(2).Trim();
                        textBoxTeamName17.Text = selectedSeason1.Week05Team17.Substring(2).Trim();
                        textBoxTeamName18.Text = selectedSeason1.Week05Team18.Substring(2).Trim();
                        textBoxTeamName19.Text = selectedSeason1.Week05Team19.Substring(2).Trim();
                        textBoxTeamName20.Text = selectedSeason1.Week05Team20.Substring(2).Trim();
                        textBoxTeamName21.Text = selectedSeason1.Week05Team21.Substring(2).Trim();
                        textBoxTeamName22.Text = selectedSeason1.Week05Team22.Substring(2).Trim();
                        textBoxTeamName23.Text = selectedSeason1.Week05Team23.Substring(2).Trim();
                        textBoxTeamName24.Text = selectedSeason1.Week05Team24.Substring(2).Trim();
                        textBoxTeamName25.Text = selectedSeason1.Week05Team25.Substring(2).Trim();
                        textBoxTeamName26.Text = selectedSeason1.Week05Team26.Substring(2).Trim();
                        textBoxTeamName27.Text = selectedSeason1.Week05Team27.Substring(2).Trim();
                        textBoxTeamName28.Text = selectedSeason1.Week05Team28.Substring(2).Trim();
                        textBoxTeamName29.Text = selectedSeason1.Week05Team29.Substring(2).Trim();
                        textBoxTeamName30.Text = selectedSeason1.Week05Team30.Substring(2).Trim();
                        textBoxTeamName31.Text = selectedSeason1.Week05Team31.Substring(2).Trim();
                        textBoxTeamName32.Text = selectedSeason1.Week05Team32.Substring(2).Trim();
                        textBoxTeamName33.Text = selectedSeason1.Week05Team33.Substring(2).Trim();
                        textBoxTeamName34.Text = selectedSeason1.Week05Team34.Substring(2).Trim();
                        textBoxTeamName35.Text = selectedSeason1.Week05Team35.Substring(2).Trim();
                        textBoxTeamName36.Text = selectedSeason1.Week05Team36.Substring(2).Trim();
                        textBoxTeamName37.Text = selectedSeason1.Week05Team37.Substring(2).Trim();
                        textBoxTeamName38.Text = selectedSeason1.Week05Team38.Substring(2).Trim();
                        textBoxTeamName39.Text = selectedSeason1.Week05Team39.Substring(2).Trim();
                        textBoxTeamName40.Text = selectedSeason1.Week05Team40.Substring(2).Trim();
                        textBoxTeamName41.Text = selectedSeason1.Week05Team41.Substring(2).Trim();
                        textBoxTeamName42.Text = selectedSeason1.Week05Team42.Substring(2).Trim();
                        textBoxTeamName43.Text = selectedSeason1.Week05Team43.Substring(2).Trim();
                        textBoxTeamName44.Text = selectedSeason1.Week05Team44.Substring(2).Trim();
                        upDownPicksLimit.Value = selectedSeason1.MaxPicksWeek05;
                    }
                }
            }

            if (selectedSeason2 != null)
            {
                if (selectedSeason2.SeasonName == textBoxCurrentSeason.Text)
                {
                    // ------------------- WEEK 06 -------------------------
                    if (comboBoxSelectWeekSeason.Text == "Week 06" && selectedSeason2.Week06Team01 != "")
                    {
                        textBoxTeamName01.Text = selectedSeason2.Week06Team01.Substring(2).Trim();
                        textBoxTeamName02.Text = selectedSeason2.Week06Team02.Substring(2).Trim();
                        textBoxTeamName03.Text = selectedSeason2.Week06Team03.Substring(2).Trim();
                        textBoxTeamName04.Text = selectedSeason2.Week06Team04.Substring(2).Trim();
                        textBoxTeamName05.Text = selectedSeason2.Week06Team05.Substring(2).Trim();
                        textBoxTeamName06.Text = selectedSeason2.Week06Team06.Substring(2).Trim();
                        textBoxTeamName07.Text = selectedSeason2.Week06Team07.Substring(2).Trim();
                        textBoxTeamName08.Text = selectedSeason2.Week06Team08.Substring(2).Trim();
                        textBoxTeamName09.Text = selectedSeason2.Week06Team09.Substring(2).Trim();
                        textBoxTeamName10.Text = selectedSeason2.Week06Team10.Substring(2).Trim();
                        textBoxTeamName11.Text = selectedSeason2.Week06Team11.Substring(2).Trim();
                        textBoxTeamName12.Text = selectedSeason2.Week06Team12.Substring(2).Trim();
                        textBoxTeamName13.Text = selectedSeason2.Week06Team13.Substring(2).Trim();
                        textBoxTeamName14.Text = selectedSeason2.Week06Team14.Substring(2).Trim();
                        textBoxTeamName15.Text = selectedSeason2.Week06Team15.Substring(2).Trim();
                        textBoxTeamName16.Text = selectedSeason2.Week06Team16.Substring(2).Trim();
                        textBoxTeamName17.Text = selectedSeason2.Week06Team17.Substring(2).Trim();
                        textBoxTeamName18.Text = selectedSeason2.Week06Team18.Substring(2).Trim();
                        textBoxTeamName19.Text = selectedSeason2.Week06Team19.Substring(2).Trim();
                        textBoxTeamName20.Text = selectedSeason2.Week06Team20.Substring(2).Trim();
                        textBoxTeamName21.Text = selectedSeason2.Week06Team21.Substring(2).Trim();
                        textBoxTeamName22.Text = selectedSeason2.Week06Team22.Substring(2).Trim();
                        textBoxTeamName23.Text = selectedSeason2.Week06Team23.Substring(2).Trim();
                        textBoxTeamName24.Text = selectedSeason2.Week06Team24.Substring(2).Trim();
                        textBoxTeamName25.Text = selectedSeason2.Week06Team25.Substring(2).Trim();
                        textBoxTeamName26.Text = selectedSeason2.Week06Team26.Substring(2).Trim();
                        textBoxTeamName27.Text = selectedSeason2.Week06Team27.Substring(2).Trim();
                        textBoxTeamName28.Text = selectedSeason2.Week06Team28.Substring(2).Trim();
                        textBoxTeamName29.Text = selectedSeason2.Week06Team29.Substring(2).Trim();
                        textBoxTeamName30.Text = selectedSeason2.Week06Team30.Substring(2).Trim();
                        textBoxTeamName31.Text = selectedSeason2.Week06Team31.Substring(2).Trim();
                        textBoxTeamName32.Text = selectedSeason2.Week06Team32.Substring(2).Trim();
                        textBoxTeamName33.Text = selectedSeason2.Week06Team33.Substring(2).Trim();
                        textBoxTeamName34.Text = selectedSeason2.Week06Team34.Substring(2).Trim();
                        textBoxTeamName35.Text = selectedSeason2.Week06Team35.Substring(2).Trim();
                        textBoxTeamName36.Text = selectedSeason2.Week06Team36.Substring(2).Trim();
                        textBoxTeamName37.Text = selectedSeason2.Week06Team37.Substring(2).Trim();
                        textBoxTeamName38.Text = selectedSeason2.Week06Team38.Substring(2).Trim();
                        textBoxTeamName39.Text = selectedSeason2.Week06Team39.Substring(2).Trim();
                        textBoxTeamName40.Text = selectedSeason2.Week06Team40.Substring(2).Trim();
                        textBoxTeamName41.Text = selectedSeason2.Week06Team41.Substring(2).Trim();
                        textBoxTeamName42.Text = selectedSeason2.Week06Team42.Substring(2).Trim();
                        textBoxTeamName43.Text = selectedSeason2.Week06Team43.Substring(2).Trim();
                        textBoxTeamName44.Text = selectedSeason2.Week06Team44.Substring(2).Trim();
                        upDownPicksLimit.Value = selectedSeason1.MaxPicksWeek06;

                    }

                    // ------------------- WEEK 07 -------------------------
                    if (comboBoxSelectWeekSeason.Text == "Week 07" && selectedSeason2.Week07Team01 != "")
                    {
                        textBoxTeamName01.Text = selectedSeason2.Week07Team01.Substring(2).Trim();
                        textBoxTeamName02.Text = selectedSeason2.Week07Team02.Substring(2).Trim();
                        textBoxTeamName03.Text = selectedSeason2.Week07Team03.Substring(2).Trim();
                        textBoxTeamName04.Text = selectedSeason2.Week07Team04.Substring(2).Trim();
                        textBoxTeamName05.Text = selectedSeason2.Week07Team05.Substring(2).Trim();
                        textBoxTeamName06.Text = selectedSeason2.Week07Team06.Substring(2).Trim();
                        textBoxTeamName07.Text = selectedSeason2.Week07Team07.Substring(2).Trim();
                        textBoxTeamName08.Text = selectedSeason2.Week07Team08.Substring(2).Trim();
                        textBoxTeamName09.Text = selectedSeason2.Week07Team09.Substring(2).Trim();
                        textBoxTeamName10.Text = selectedSeason2.Week07Team10.Substring(2).Trim();
                        textBoxTeamName11.Text = selectedSeason2.Week07Team11.Substring(2).Trim();
                        textBoxTeamName12.Text = selectedSeason2.Week07Team12.Substring(2).Trim();
                        textBoxTeamName13.Text = selectedSeason2.Week07Team13.Substring(2).Trim();
                        textBoxTeamName14.Text = selectedSeason2.Week07Team14.Substring(2).Trim();
                        textBoxTeamName15.Text = selectedSeason2.Week07Team15.Substring(2).Trim();
                        textBoxTeamName16.Text = selectedSeason2.Week07Team16.Substring(2).Trim();
                        textBoxTeamName17.Text = selectedSeason2.Week07Team17.Substring(2).Trim();
                        textBoxTeamName18.Text = selectedSeason2.Week07Team18.Substring(2).Trim();
                        textBoxTeamName19.Text = selectedSeason2.Week07Team19.Substring(2).Trim();
                        textBoxTeamName20.Text = selectedSeason2.Week07Team20.Substring(2).Trim();
                        textBoxTeamName21.Text = selectedSeason2.Week07Team21.Substring(2).Trim();
                        textBoxTeamName22.Text = selectedSeason2.Week07Team22.Substring(2).Trim();
                        textBoxTeamName23.Text = selectedSeason2.Week07Team23.Substring(2).Trim();
                        textBoxTeamName24.Text = selectedSeason2.Week07Team24.Substring(2).Trim();
                        textBoxTeamName25.Text = selectedSeason2.Week07Team25.Substring(2).Trim();
                        textBoxTeamName26.Text = selectedSeason2.Week07Team26.Substring(2).Trim();
                        textBoxTeamName27.Text = selectedSeason2.Week07Team27.Substring(2).Trim();
                        textBoxTeamName28.Text = selectedSeason2.Week07Team28.Substring(2).Trim();
                        textBoxTeamName29.Text = selectedSeason2.Week07Team29.Substring(2).Trim();
                        textBoxTeamName30.Text = selectedSeason2.Week07Team30.Substring(2).Trim();
                        textBoxTeamName31.Text = selectedSeason2.Week07Team31.Substring(2).Trim();
                        textBoxTeamName32.Text = selectedSeason2.Week07Team32.Substring(2).Trim();
                        textBoxTeamName33.Text = selectedSeason2.Week07Team33.Substring(2).Trim();
                        textBoxTeamName34.Text = selectedSeason2.Week07Team34.Substring(2).Trim();
                        textBoxTeamName35.Text = selectedSeason2.Week07Team35.Substring(2).Trim();
                        textBoxTeamName36.Text = selectedSeason2.Week07Team36.Substring(2).Trim();
                        textBoxTeamName37.Text = selectedSeason2.Week07Team37.Substring(2).Trim();
                        textBoxTeamName38.Text = selectedSeason2.Week07Team38.Substring(2).Trim();
                        textBoxTeamName39.Text = selectedSeason2.Week07Team39.Substring(2).Trim();
                        textBoxTeamName40.Text = selectedSeason2.Week07Team40.Substring(2).Trim();
                        textBoxTeamName41.Text = selectedSeason2.Week07Team41.Substring(2).Trim();
                        textBoxTeamName42.Text = selectedSeason2.Week07Team42.Substring(2).Trim();
                        textBoxTeamName43.Text = selectedSeason2.Week07Team43.Substring(2).Trim();
                        textBoxTeamName44.Text = selectedSeason2.Week07Team44.Substring(2).Trim();
                        upDownPicksLimit.Value = selectedSeason1.MaxPicksWeek07;

                    }

                    // ------------------- WEEK 08 -------------------------
                    if (comboBoxSelectWeekSeason.Text == "Week 08" && selectedSeason2.Week08Team01 != "")
                    {
                        textBoxTeamName01.Text = selectedSeason2.Week08Team01.Substring(2).Trim();
                        textBoxTeamName02.Text = selectedSeason2.Week08Team02.Substring(2).Trim();
                        textBoxTeamName03.Text = selectedSeason2.Week08Team03.Substring(2).Trim();
                        textBoxTeamName04.Text = selectedSeason2.Week08Team04.Substring(2).Trim();
                        textBoxTeamName05.Text = selectedSeason2.Week08Team05.Substring(2).Trim();
                        textBoxTeamName06.Text = selectedSeason2.Week08Team06.Substring(2).Trim();
                        textBoxTeamName07.Text = selectedSeason2.Week08Team07.Substring(2).Trim();
                        textBoxTeamName08.Text = selectedSeason2.Week08Team08.Substring(2).Trim();
                        textBoxTeamName09.Text = selectedSeason2.Week08Team09.Substring(2).Trim();
                        textBoxTeamName10.Text = selectedSeason2.Week08Team10.Substring(2).Trim();
                        textBoxTeamName11.Text = selectedSeason2.Week08Team11.Substring(2).Trim();
                        textBoxTeamName12.Text = selectedSeason2.Week08Team12.Substring(2).Trim();
                        textBoxTeamName13.Text = selectedSeason2.Week08Team13.Substring(2).Trim();
                        textBoxTeamName14.Text = selectedSeason2.Week08Team14.Substring(2).Trim();
                        textBoxTeamName15.Text = selectedSeason2.Week08Team15.Substring(2).Trim();
                        textBoxTeamName16.Text = selectedSeason2.Week08Team16.Substring(2).Trim();
                        textBoxTeamName17.Text = selectedSeason2.Week08Team17.Substring(2).Trim();
                        textBoxTeamName18.Text = selectedSeason2.Week08Team18.Substring(2).Trim();
                        textBoxTeamName19.Text = selectedSeason2.Week08Team19.Substring(2).Trim();
                        textBoxTeamName20.Text = selectedSeason2.Week08Team20.Substring(2).Trim();
                        textBoxTeamName21.Text = selectedSeason2.Week08Team21.Substring(2).Trim();
                        textBoxTeamName22.Text = selectedSeason2.Week08Team22.Substring(2).Trim();
                        textBoxTeamName23.Text = selectedSeason2.Week08Team23.Substring(2).Trim();
                        textBoxTeamName24.Text = selectedSeason2.Week08Team24.Substring(2).Trim();
                        textBoxTeamName25.Text = selectedSeason2.Week08Team25.Substring(2).Trim();
                        textBoxTeamName26.Text = selectedSeason2.Week08Team26.Substring(2).Trim();
                        textBoxTeamName27.Text = selectedSeason2.Week08Team27.Substring(2).Trim();
                        textBoxTeamName28.Text = selectedSeason2.Week08Team28.Substring(2).Trim();
                        textBoxTeamName29.Text = selectedSeason2.Week08Team29.Substring(2).Trim();
                        textBoxTeamName30.Text = selectedSeason2.Week08Team30.Substring(2).Trim();
                        textBoxTeamName31.Text = selectedSeason2.Week08Team31.Substring(2).Trim();
                        textBoxTeamName32.Text = selectedSeason2.Week08Team32.Substring(2).Trim();
                        textBoxTeamName33.Text = selectedSeason2.Week08Team33.Substring(2).Trim();
                        textBoxTeamName34.Text = selectedSeason2.Week08Team34.Substring(2).Trim();
                        textBoxTeamName35.Text = selectedSeason2.Week08Team35.Substring(2).Trim();
                        textBoxTeamName36.Text = selectedSeason2.Week08Team36.Substring(2).Trim();
                        textBoxTeamName37.Text = selectedSeason2.Week08Team37.Substring(2).Trim();
                        textBoxTeamName38.Text = selectedSeason2.Week08Team38.Substring(2).Trim();
                        textBoxTeamName39.Text = selectedSeason2.Week08Team39.Substring(2).Trim();
                        textBoxTeamName40.Text = selectedSeason2.Week08Team40.Substring(2).Trim();
                        textBoxTeamName41.Text = selectedSeason2.Week08Team41.Substring(2).Trim();
                        textBoxTeamName42.Text = selectedSeason2.Week08Team42.Substring(2).Trim();
                        textBoxTeamName43.Text = selectedSeason2.Week08Team43.Substring(2).Trim();
                        textBoxTeamName44.Text = selectedSeason2.Week08Team44.Substring(2).Trim();
                        upDownPicksLimit.Value = selectedSeason1.MaxPicksWeek08;

                    }

                    // ------------------- WEEK 09 -------------------------
                    if (comboBoxSelectWeekSeason.Text == "Week 09" && selectedSeason2.Week09Team01 != "")
                    {
                        textBoxTeamName01.Text = selectedSeason2.Week09Team01.Substring(2).Trim();
                        textBoxTeamName02.Text = selectedSeason2.Week09Team02.Substring(2).Trim();
                        textBoxTeamName03.Text = selectedSeason2.Week09Team03.Substring(2).Trim();
                        textBoxTeamName04.Text = selectedSeason2.Week09Team04.Substring(2).Trim();
                        textBoxTeamName05.Text = selectedSeason2.Week09Team05.Substring(2).Trim();
                        textBoxTeamName06.Text = selectedSeason2.Week09Team06.Substring(2).Trim();
                        textBoxTeamName07.Text = selectedSeason2.Week09Team07.Substring(2).Trim();
                        textBoxTeamName08.Text = selectedSeason2.Week09Team08.Substring(2).Trim();
                        textBoxTeamName09.Text = selectedSeason2.Week09Team09.Substring(2).Trim();
                        textBoxTeamName10.Text = selectedSeason2.Week09Team10.Substring(2).Trim();
                        textBoxTeamName11.Text = selectedSeason2.Week09Team11.Substring(2).Trim();
                        textBoxTeamName12.Text = selectedSeason2.Week09Team12.Substring(2).Trim();
                        textBoxTeamName13.Text = selectedSeason2.Week09Team13.Substring(2).Trim();
                        textBoxTeamName14.Text = selectedSeason2.Week09Team14.Substring(2).Trim();
                        textBoxTeamName15.Text = selectedSeason2.Week09Team15.Substring(2).Trim();
                        textBoxTeamName16.Text = selectedSeason2.Week09Team16.Substring(2).Trim();
                        textBoxTeamName17.Text = selectedSeason2.Week09Team17.Substring(2).Trim();
                        textBoxTeamName18.Text = selectedSeason2.Week09Team18.Substring(2).Trim();
                        textBoxTeamName19.Text = selectedSeason2.Week09Team19.Substring(2).Trim();
                        textBoxTeamName20.Text = selectedSeason2.Week09Team20.Substring(2).Trim();
                        textBoxTeamName21.Text = selectedSeason2.Week09Team21.Substring(2).Trim();
                        textBoxTeamName22.Text = selectedSeason2.Week09Team22.Substring(2).Trim();
                        textBoxTeamName23.Text = selectedSeason2.Week09Team23.Substring(2).Trim();
                        textBoxTeamName24.Text = selectedSeason2.Week09Team24.Substring(2).Trim();
                        textBoxTeamName25.Text = selectedSeason2.Week09Team25.Substring(2).Trim();
                        textBoxTeamName26.Text = selectedSeason2.Week09Team26.Substring(2).Trim();
                        textBoxTeamName27.Text = selectedSeason2.Week09Team27.Substring(2).Trim();
                        textBoxTeamName28.Text = selectedSeason2.Week09Team28.Substring(2).Trim();
                        textBoxTeamName29.Text = selectedSeason2.Week09Team29.Substring(2).Trim();
                        textBoxTeamName30.Text = selectedSeason2.Week09Team30.Substring(2).Trim();
                        textBoxTeamName31.Text = selectedSeason2.Week09Team31.Substring(2).Trim();
                        textBoxTeamName32.Text = selectedSeason2.Week09Team32.Substring(2).Trim();
                        textBoxTeamName33.Text = selectedSeason2.Week09Team33.Substring(2).Trim();
                        textBoxTeamName34.Text = selectedSeason2.Week09Team34.Substring(2).Trim();
                        textBoxTeamName35.Text = selectedSeason2.Week09Team35.Substring(2).Trim();
                        textBoxTeamName36.Text = selectedSeason2.Week09Team36.Substring(2).Trim();
                        textBoxTeamName37.Text = selectedSeason2.Week09Team37.Substring(2).Trim();
                        textBoxTeamName38.Text = selectedSeason2.Week09Team38.Substring(2).Trim();
                        textBoxTeamName39.Text = selectedSeason2.Week09Team39.Substring(2).Trim();
                        textBoxTeamName40.Text = selectedSeason2.Week09Team40.Substring(2).Trim();
                        textBoxTeamName41.Text = selectedSeason2.Week09Team41.Substring(2).Trim();
                        textBoxTeamName42.Text = selectedSeason2.Week09Team42.Substring(2).Trim();
                        textBoxTeamName43.Text = selectedSeason2.Week09Team43.Substring(2).Trim();
                        textBoxTeamName44.Text = selectedSeason2.Week09Team44.Substring(2).Trim();
                        upDownPicksLimit.Value = selectedSeason1.MaxPicksWeek09;
                        
                    }

                    // ------------------- WEEK 10 -------------------------
                    if (comboBoxSelectWeekSeason.Text == "Week 10" && selectedSeason2.Week10Team01 != "")
                    {
                        textBoxTeamName01.Text = selectedSeason2.Week10Team01.Substring(2).Trim();
                        textBoxTeamName02.Text = selectedSeason2.Week10Team02.Substring(2).Trim();
                        textBoxTeamName03.Text = selectedSeason2.Week10Team03.Substring(2).Trim();
                        textBoxTeamName04.Text = selectedSeason2.Week10Team04.Substring(2).Trim();
                        textBoxTeamName05.Text = selectedSeason2.Week10Team05.Substring(2).Trim();
                        textBoxTeamName06.Text = selectedSeason2.Week10Team06.Substring(2).Trim();
                        textBoxTeamName07.Text = selectedSeason2.Week10Team07.Substring(2).Trim();
                        textBoxTeamName08.Text = selectedSeason2.Week10Team08.Substring(2).Trim();
                        textBoxTeamName09.Text = selectedSeason2.Week10Team09.Substring(2).Trim();
                        textBoxTeamName10.Text = selectedSeason2.Week10Team10.Substring(2).Trim();
                        textBoxTeamName11.Text = selectedSeason2.Week10Team11.Substring(2).Trim();
                        textBoxTeamName12.Text = selectedSeason2.Week10Team12.Substring(2).Trim();
                        textBoxTeamName13.Text = selectedSeason2.Week10Team13.Substring(2).Trim();
                        textBoxTeamName14.Text = selectedSeason2.Week10Team14.Substring(2).Trim();
                        textBoxTeamName15.Text = selectedSeason2.Week10Team15.Substring(2).Trim();
                        textBoxTeamName16.Text = selectedSeason2.Week10Team16.Substring(2).Trim();
                        textBoxTeamName17.Text = selectedSeason2.Week10Team17.Substring(2).Trim();
                        textBoxTeamName18.Text = selectedSeason2.Week10Team18.Substring(2).Trim();
                        textBoxTeamName19.Text = selectedSeason2.Week10Team19.Substring(2).Trim();
                        textBoxTeamName20.Text = selectedSeason2.Week10Team20.Substring(2).Trim();
                        textBoxTeamName21.Text = selectedSeason2.Week10Team21.Substring(2).Trim();
                        textBoxTeamName22.Text = selectedSeason2.Week10Team22.Substring(2).Trim();
                        textBoxTeamName23.Text = selectedSeason2.Week10Team23.Substring(2).Trim();
                        textBoxTeamName24.Text = selectedSeason2.Week10Team24.Substring(2).Trim();
                        textBoxTeamName25.Text = selectedSeason2.Week10Team25.Substring(2).Trim();
                        textBoxTeamName26.Text = selectedSeason2.Week10Team26.Substring(2).Trim();
                        textBoxTeamName27.Text = selectedSeason2.Week10Team27.Substring(2).Trim();
                        textBoxTeamName28.Text = selectedSeason2.Week10Team28.Substring(2).Trim();
                        textBoxTeamName29.Text = selectedSeason2.Week10Team29.Substring(2).Trim();
                        textBoxTeamName30.Text = selectedSeason2.Week10Team30.Substring(2).Trim();
                        textBoxTeamName31.Text = selectedSeason2.Week10Team31.Substring(2).Trim();
                        textBoxTeamName32.Text = selectedSeason2.Week10Team32.Substring(2).Trim();
                        textBoxTeamName33.Text = selectedSeason2.Week10Team33.Substring(2).Trim();
                        textBoxTeamName34.Text = selectedSeason2.Week10Team34.Substring(2).Trim();
                        textBoxTeamName35.Text = selectedSeason2.Week10Team35.Substring(2).Trim();
                        textBoxTeamName36.Text = selectedSeason2.Week10Team36.Substring(2).Trim();
                        textBoxTeamName37.Text = selectedSeason2.Week10Team37.Substring(2).Trim();
                        textBoxTeamName38.Text = selectedSeason2.Week10Team38.Substring(2).Trim();
                        textBoxTeamName39.Text = selectedSeason2.Week10Team39.Substring(2).Trim();
                        textBoxTeamName40.Text = selectedSeason2.Week10Team40.Substring(2).Trim();
                        textBoxTeamName41.Text = selectedSeason2.Week10Team41.Substring(2).Trim();
                        textBoxTeamName42.Text = selectedSeason2.Week10Team42.Substring(2).Trim();
                        textBoxTeamName43.Text = selectedSeason2.Week10Team43.Substring(2).Trim();
                        textBoxTeamName44.Text = selectedSeason2.Week10Team44.Substring(2).Trim();
                        upDownPicksLimit.Value = selectedSeason1.MaxPicksWeek10;

                    }
                }
            }

            if (selectedSeason3 != null)
            {
                if (selectedSeason3.SeasonName == textBoxCurrentSeason.Text)
                {
                    // ------------------- WEEK 11 -------------------------
                    if (comboBoxSelectWeekSeason.Text == "Week 11" && selectedSeason3.Week11Team01 != "")
                    {
                        textBoxTeamName01.Text = selectedSeason3.Week11Team01.Substring(2).Trim();
                        textBoxTeamName02.Text = selectedSeason3.Week11Team02.Substring(2).Trim();
                        textBoxTeamName03.Text = selectedSeason3.Week11Team03.Substring(2).Trim();
                        textBoxTeamName04.Text = selectedSeason3.Week11Team04.Substring(2).Trim();
                        textBoxTeamName05.Text = selectedSeason3.Week11Team05.Substring(2).Trim();
                        textBoxTeamName06.Text = selectedSeason3.Week11Team06.Substring(2).Trim();
                        textBoxTeamName07.Text = selectedSeason3.Week11Team07.Substring(2).Trim();
                        textBoxTeamName08.Text = selectedSeason3.Week11Team08.Substring(2).Trim();
                        textBoxTeamName09.Text = selectedSeason3.Week11Team09.Substring(2).Trim();
                        textBoxTeamName10.Text = selectedSeason3.Week11Team10.Substring(2).Trim();
                        textBoxTeamName11.Text = selectedSeason3.Week11Team11.Substring(2).Trim();
                        textBoxTeamName12.Text = selectedSeason3.Week11Team12.Substring(2).Trim();
                        textBoxTeamName13.Text = selectedSeason3.Week11Team13.Substring(2).Trim();
                        textBoxTeamName14.Text = selectedSeason3.Week11Team14.Substring(2).Trim();
                        textBoxTeamName15.Text = selectedSeason3.Week11Team15.Substring(2).Trim();
                        textBoxTeamName16.Text = selectedSeason3.Week11Team16.Substring(2).Trim();
                        textBoxTeamName17.Text = selectedSeason3.Week11Team17.Substring(2).Trim();
                        textBoxTeamName18.Text = selectedSeason3.Week11Team18.Substring(2).Trim();
                        textBoxTeamName19.Text = selectedSeason3.Week11Team19.Substring(2).Trim();
                        textBoxTeamName20.Text = selectedSeason3.Week11Team20.Substring(2).Trim();
                        textBoxTeamName21.Text = selectedSeason3.Week11Team21.Substring(2).Trim();
                        textBoxTeamName22.Text = selectedSeason3.Week11Team22.Substring(2).Trim();
                        textBoxTeamName23.Text = selectedSeason3.Week11Team23.Substring(2).Trim();
                        textBoxTeamName24.Text = selectedSeason3.Week11Team24.Substring(2).Trim();
                        textBoxTeamName25.Text = selectedSeason3.Week11Team25.Substring(2).Trim();
                        textBoxTeamName26.Text = selectedSeason3.Week11Team26.Substring(2).Trim();
                        textBoxTeamName27.Text = selectedSeason3.Week11Team27.Substring(2).Trim();
                        textBoxTeamName28.Text = selectedSeason3.Week11Team28.Substring(2).Trim();
                        textBoxTeamName29.Text = selectedSeason3.Week11Team29.Substring(2).Trim();
                        textBoxTeamName30.Text = selectedSeason3.Week11Team30.Substring(2).Trim();
                        textBoxTeamName31.Text = selectedSeason3.Week11Team31.Substring(2).Trim();
                        textBoxTeamName32.Text = selectedSeason3.Week11Team32.Substring(2).Trim();
                        textBoxTeamName33.Text = selectedSeason3.Week11Team33.Substring(2).Trim();
                        textBoxTeamName34.Text = selectedSeason3.Week11Team34.Substring(2).Trim();
                        textBoxTeamName35.Text = selectedSeason3.Week11Team35.Substring(2).Trim();
                        textBoxTeamName36.Text = selectedSeason3.Week11Team36.Substring(2).Trim();
                        textBoxTeamName37.Text = selectedSeason3.Week11Team37.Substring(2).Trim();
                        textBoxTeamName38.Text = selectedSeason3.Week11Team38.Substring(2).Trim();
                        textBoxTeamName39.Text = selectedSeason3.Week11Team39.Substring(2).Trim();
                        textBoxTeamName40.Text = selectedSeason3.Week11Team40.Substring(2).Trim();
                        textBoxTeamName41.Text = selectedSeason3.Week11Team41.Substring(2).Trim();
                        textBoxTeamName42.Text = selectedSeason3.Week11Team42.Substring(2).Trim();
                        textBoxTeamName43.Text = selectedSeason3.Week11Team43.Substring(2).Trim();
                        textBoxTeamName44.Text = selectedSeason3.Week11Team44.Substring(2).Trim();
                        upDownPicksLimit.Value = selectedSeason1.MaxPicksWeek11;

                    }

                    // ------------------- WEEK 12 -------------------------
                    if (comboBoxSelectWeekSeason.Text == "Week 12" && selectedSeason3.Week12Team01 != "")
                    {
                        textBoxTeamName01.Text = selectedSeason3.Week12Team01.Substring(2).Trim();
                        textBoxTeamName02.Text = selectedSeason3.Week12Team02.Substring(2).Trim();
                        textBoxTeamName03.Text = selectedSeason3.Week12Team03.Substring(2).Trim();
                        textBoxTeamName04.Text = selectedSeason3.Week12Team04.Substring(2).Trim();
                        textBoxTeamName05.Text = selectedSeason3.Week12Team05.Substring(2).Trim();
                        textBoxTeamName06.Text = selectedSeason3.Week12Team06.Substring(2).Trim();
                        textBoxTeamName07.Text = selectedSeason3.Week12Team07.Substring(2).Trim();
                        textBoxTeamName08.Text = selectedSeason3.Week12Team08.Substring(2).Trim();
                        textBoxTeamName09.Text = selectedSeason3.Week12Team09.Substring(2).Trim();
                        textBoxTeamName10.Text = selectedSeason3.Week12Team10.Substring(2).Trim();
                        textBoxTeamName11.Text = selectedSeason3.Week12Team11.Substring(2).Trim();
                        textBoxTeamName12.Text = selectedSeason3.Week12Team12.Substring(2).Trim();
                        textBoxTeamName13.Text = selectedSeason3.Week12Team13.Substring(2).Trim();
                        textBoxTeamName14.Text = selectedSeason3.Week12Team14.Substring(2).Trim();
                        textBoxTeamName15.Text = selectedSeason3.Week12Team15.Substring(2).Trim();
                        textBoxTeamName16.Text = selectedSeason3.Week12Team16.Substring(2).Trim();
                        textBoxTeamName17.Text = selectedSeason3.Week12Team17.Substring(2).Trim();
                        textBoxTeamName18.Text = selectedSeason3.Week12Team18.Substring(2).Trim();
                        textBoxTeamName19.Text = selectedSeason3.Week12Team19.Substring(2).Trim();
                        textBoxTeamName20.Text = selectedSeason3.Week12Team20.Substring(2).Trim();
                        textBoxTeamName21.Text = selectedSeason3.Week12Team21.Substring(2).Trim();
                        textBoxTeamName22.Text = selectedSeason3.Week12Team22.Substring(2).Trim();
                        textBoxTeamName23.Text = selectedSeason3.Week12Team23.Substring(2).Trim();
                        textBoxTeamName24.Text = selectedSeason3.Week12Team24.Substring(2).Trim();
                        textBoxTeamName25.Text = selectedSeason3.Week12Team25.Substring(2).Trim();
                        textBoxTeamName26.Text = selectedSeason3.Week12Team26.Substring(2).Trim();
                        textBoxTeamName27.Text = selectedSeason3.Week12Team27.Substring(2).Trim();
                        textBoxTeamName28.Text = selectedSeason3.Week12Team28.Substring(2).Trim();
                        textBoxTeamName29.Text = selectedSeason3.Week12Team29.Substring(2).Trim();
                        textBoxTeamName30.Text = selectedSeason3.Week12Team30.Substring(2).Trim();
                        textBoxTeamName31.Text = selectedSeason3.Week12Team31.Substring(2).Trim();
                        textBoxTeamName32.Text = selectedSeason3.Week12Team32.Substring(2).Trim();
                        textBoxTeamName33.Text = selectedSeason3.Week12Team33.Substring(2).Trim();
                        textBoxTeamName34.Text = selectedSeason3.Week12Team34.Substring(2).Trim();
                        textBoxTeamName35.Text = selectedSeason3.Week12Team35.Substring(2).Trim();
                        textBoxTeamName36.Text = selectedSeason3.Week12Team36.Substring(2).Trim();
                        textBoxTeamName37.Text = selectedSeason3.Week12Team37.Substring(2).Trim();
                        textBoxTeamName38.Text = selectedSeason3.Week12Team38.Substring(2).Trim();
                        textBoxTeamName39.Text = selectedSeason3.Week12Team39.Substring(2).Trim();
                        textBoxTeamName40.Text = selectedSeason3.Week12Team40.Substring(2).Trim();
                        textBoxTeamName41.Text = selectedSeason3.Week12Team41.Substring(2).Trim();
                        textBoxTeamName42.Text = selectedSeason3.Week12Team42.Substring(2).Trim();
                        textBoxTeamName43.Text = selectedSeason3.Week12Team43.Substring(2).Trim();
                        textBoxTeamName44.Text = selectedSeason3.Week12Team44.Substring(2).Trim();
                        upDownPicksLimit.Value = selectedSeason1.MaxPicksWeek12;

                    }

                    // ------------------- WEEK 13 -------------------------
                    if (comboBoxSelectWeekSeason.Text == "Week 13" && selectedSeason3.Week13Team01 != "")
                    {
                        textBoxTeamName01.Text = selectedSeason3.Week13Team01.Substring(2).Trim();
                        textBoxTeamName02.Text = selectedSeason3.Week13Team02.Substring(2).Trim();
                        textBoxTeamName03.Text = selectedSeason3.Week13Team03.Substring(2).Trim();
                        textBoxTeamName04.Text = selectedSeason3.Week13Team04.Substring(2).Trim();
                        textBoxTeamName05.Text = selectedSeason3.Week13Team05.Substring(2).Trim();
                        textBoxTeamName06.Text = selectedSeason3.Week13Team06.Substring(2).Trim();
                        textBoxTeamName07.Text = selectedSeason3.Week13Team07.Substring(2).Trim();
                        textBoxTeamName08.Text = selectedSeason3.Week13Team08.Substring(2).Trim();
                        textBoxTeamName09.Text = selectedSeason3.Week13Team09.Substring(2).Trim();
                        textBoxTeamName10.Text = selectedSeason3.Week13Team10.Substring(2).Trim();
                        textBoxTeamName11.Text = selectedSeason3.Week13Team11.Substring(2).Trim();
                        textBoxTeamName12.Text = selectedSeason3.Week13Team12.Substring(2).Trim();
                        textBoxTeamName13.Text = selectedSeason3.Week13Team13.Substring(2).Trim();
                        textBoxTeamName14.Text = selectedSeason3.Week13Team14.Substring(2).Trim();
                        textBoxTeamName15.Text = selectedSeason3.Week13Team15.Substring(2).Trim();
                        textBoxTeamName16.Text = selectedSeason3.Week13Team16.Substring(2).Trim();
                        textBoxTeamName17.Text = selectedSeason3.Week13Team17.Substring(2).Trim();
                        textBoxTeamName18.Text = selectedSeason3.Week13Team18.Substring(2).Trim();
                        textBoxTeamName19.Text = selectedSeason3.Week13Team19.Substring(2).Trim();
                        textBoxTeamName20.Text = selectedSeason3.Week13Team20.Substring(2).Trim();
                        textBoxTeamName21.Text = selectedSeason3.Week13Team21.Substring(2).Trim();
                        textBoxTeamName22.Text = selectedSeason3.Week13Team22.Substring(2).Trim();
                        textBoxTeamName23.Text = selectedSeason3.Week13Team23.Substring(2).Trim();
                        textBoxTeamName24.Text = selectedSeason3.Week13Team24.Substring(2).Trim();
                        textBoxTeamName25.Text = selectedSeason3.Week13Team25.Substring(2).Trim();
                        textBoxTeamName26.Text = selectedSeason3.Week13Team26.Substring(2).Trim();
                        textBoxTeamName27.Text = selectedSeason3.Week13Team27.Substring(2).Trim();
                        textBoxTeamName28.Text = selectedSeason3.Week13Team28.Substring(2).Trim();
                        textBoxTeamName29.Text = selectedSeason3.Week13Team29.Substring(2).Trim();
                        textBoxTeamName30.Text = selectedSeason3.Week13Team30.Substring(2).Trim();
                        textBoxTeamName31.Text = selectedSeason3.Week13Team31.Substring(2).Trim();
                        textBoxTeamName32.Text = selectedSeason3.Week13Team32.Substring(2).Trim();
                        textBoxTeamName33.Text = selectedSeason3.Week13Team33.Substring(2).Trim();
                        textBoxTeamName34.Text = selectedSeason3.Week13Team34.Substring(2).Trim();
                        textBoxTeamName35.Text = selectedSeason3.Week13Team35.Substring(2).Trim();
                        textBoxTeamName36.Text = selectedSeason3.Week13Team36.Substring(2).Trim();
                        textBoxTeamName37.Text = selectedSeason3.Week13Team37.Substring(2).Trim();
                        textBoxTeamName38.Text = selectedSeason3.Week13Team38.Substring(2).Trim();
                        textBoxTeamName39.Text = selectedSeason3.Week13Team39.Substring(2).Trim();
                        textBoxTeamName40.Text = selectedSeason3.Week13Team40.Substring(2).Trim();
                        textBoxTeamName41.Text = selectedSeason3.Week13Team41.Substring(2).Trim();
                        textBoxTeamName42.Text = selectedSeason3.Week13Team42.Substring(2).Trim();
                        textBoxTeamName43.Text = selectedSeason3.Week13Team43.Substring(2).Trim();
                        textBoxTeamName44.Text = selectedSeason3.Week13Team44.Substring(2).Trim();
                        upDownPicksLimit.Value = selectedSeason1.MaxPicksWeek13;

                    }

                    // ------------------- WEEK 14 -------------------------
                    if (comboBoxSelectWeekSeason.Text == "Week 14" && selectedSeason3.Week14Team01 != "")
                    {
                        textBoxTeamName01.Text = selectedSeason3.Week14Team01.Substring(2).Trim();
                        textBoxTeamName02.Text = selectedSeason3.Week14Team02.Substring(2).Trim();
                        textBoxTeamName03.Text = selectedSeason3.Week14Team03.Substring(2).Trim();
                        textBoxTeamName04.Text = selectedSeason3.Week14Team04.Substring(2).Trim();
                        textBoxTeamName05.Text = selectedSeason3.Week14Team05.Substring(2).Trim();
                        textBoxTeamName06.Text = selectedSeason3.Week14Team06.Substring(2).Trim();
                        textBoxTeamName07.Text = selectedSeason3.Week14Team07.Substring(2).Trim();
                        textBoxTeamName08.Text = selectedSeason3.Week14Team08.Substring(2).Trim();
                        textBoxTeamName09.Text = selectedSeason3.Week14Team09.Substring(2).Trim();
                        textBoxTeamName10.Text = selectedSeason3.Week14Team10.Substring(2).Trim();
                        textBoxTeamName11.Text = selectedSeason3.Week14Team11.Substring(2).Trim();
                        textBoxTeamName12.Text = selectedSeason3.Week14Team12.Substring(2).Trim();
                        textBoxTeamName13.Text = selectedSeason3.Week14Team13.Substring(2).Trim();
                        textBoxTeamName14.Text = selectedSeason3.Week14Team14.Substring(2).Trim();
                        textBoxTeamName15.Text = selectedSeason3.Week14Team15.Substring(2).Trim();
                        textBoxTeamName16.Text = selectedSeason3.Week14Team16.Substring(2).Trim();
                        textBoxTeamName17.Text = selectedSeason3.Week14Team17.Substring(2).Trim();
                        textBoxTeamName18.Text = selectedSeason3.Week14Team18.Substring(2).Trim();
                        textBoxTeamName19.Text = selectedSeason3.Week14Team19.Substring(2).Trim();
                        textBoxTeamName20.Text = selectedSeason3.Week14Team20.Substring(2).Trim();
                        textBoxTeamName21.Text = selectedSeason3.Week14Team21.Substring(2).Trim();
                        textBoxTeamName22.Text = selectedSeason3.Week14Team22.Substring(2).Trim();
                        textBoxTeamName23.Text = selectedSeason3.Week14Team23.Substring(2).Trim();
                        textBoxTeamName24.Text = selectedSeason3.Week14Team24.Substring(2).Trim();
                        textBoxTeamName25.Text = selectedSeason3.Week14Team25.Substring(2).Trim();
                        textBoxTeamName26.Text = selectedSeason3.Week14Team26.Substring(2).Trim();
                        textBoxTeamName27.Text = selectedSeason3.Week14Team27.Substring(2).Trim();
                        textBoxTeamName28.Text = selectedSeason3.Week14Team28.Substring(2).Trim();
                        textBoxTeamName29.Text = selectedSeason3.Week14Team29.Substring(2).Trim();
                        textBoxTeamName30.Text = selectedSeason3.Week14Team30.Substring(2).Trim();
                        textBoxTeamName31.Text = selectedSeason3.Week14Team31.Substring(2).Trim();
                        textBoxTeamName32.Text = selectedSeason3.Week14Team32.Substring(2).Trim();
                        textBoxTeamName33.Text = selectedSeason3.Week14Team33.Substring(2).Trim();
                        textBoxTeamName34.Text = selectedSeason3.Week14Team34.Substring(2).Trim();
                        textBoxTeamName35.Text = selectedSeason3.Week14Team35.Substring(2).Trim();
                        textBoxTeamName36.Text = selectedSeason3.Week14Team36.Substring(2).Trim();
                        textBoxTeamName37.Text = selectedSeason3.Week14Team37.Substring(2).Trim();
                        textBoxTeamName38.Text = selectedSeason3.Week14Team38.Substring(2).Trim();
                        textBoxTeamName39.Text = selectedSeason3.Week14Team39.Substring(2).Trim();
                        textBoxTeamName40.Text = selectedSeason3.Week14Team40.Substring(2).Trim();
                        textBoxTeamName41.Text = selectedSeason3.Week14Team41.Substring(2).Trim();
                        textBoxTeamName42.Text = selectedSeason3.Week14Team42.Substring(2).Trim();
                        textBoxTeamName43.Text = selectedSeason3.Week14Team43.Substring(2).Trim();
                        textBoxTeamName44.Text = selectedSeason3.Week14Team44.Substring(2).Trim();
                        upDownPicksLimit.Value = selectedSeason1.MaxPicksWeek14;

                    }

                    // ------------------- WEEK 15 -------------------------
                    if (comboBoxSelectWeekSeason.Text == "Week 15" && selectedSeason3.Week15Team01 != "")
                    {
                        textBoxTeamName01.Text = selectedSeason3.Week15Team01.Substring(2).Trim();
                        textBoxTeamName02.Text = selectedSeason3.Week15Team02.Substring(2).Trim();
                        textBoxTeamName03.Text = selectedSeason3.Week15Team03.Substring(2).Trim();
                        textBoxTeamName04.Text = selectedSeason3.Week15Team04.Substring(2).Trim();
                        textBoxTeamName05.Text = selectedSeason3.Week15Team05.Substring(2).Trim();
                        textBoxTeamName06.Text = selectedSeason3.Week15Team06.Substring(2).Trim();
                        textBoxTeamName07.Text = selectedSeason3.Week15Team07.Substring(2).Trim();
                        textBoxTeamName08.Text = selectedSeason3.Week15Team08.Substring(2).Trim();
                        textBoxTeamName09.Text = selectedSeason3.Week15Team09.Substring(2).Trim();
                        textBoxTeamName10.Text = selectedSeason3.Week15Team10.Substring(2).Trim();
                        textBoxTeamName11.Text = selectedSeason3.Week15Team11.Substring(2).Trim();
                        textBoxTeamName12.Text = selectedSeason3.Week15Team12.Substring(2).Trim();
                        textBoxTeamName13.Text = selectedSeason3.Week15Team13.Substring(2).Trim();
                        textBoxTeamName14.Text = selectedSeason3.Week15Team14.Substring(2).Trim();
                        textBoxTeamName15.Text = selectedSeason3.Week15Team15.Substring(2).Trim();
                        textBoxTeamName16.Text = selectedSeason3.Week15Team16.Substring(2).Trim();
                        textBoxTeamName17.Text = selectedSeason3.Week15Team17.Substring(2).Trim();
                        textBoxTeamName18.Text = selectedSeason3.Week15Team18.Substring(2).Trim();
                        textBoxTeamName19.Text = selectedSeason3.Week15Team19.Substring(2).Trim();
                        textBoxTeamName20.Text = selectedSeason3.Week15Team20.Substring(2).Trim();
                        textBoxTeamName21.Text = selectedSeason3.Week15Team21.Substring(2).Trim();
                        textBoxTeamName22.Text = selectedSeason3.Week15Team22.Substring(2).Trim();
                        textBoxTeamName23.Text = selectedSeason3.Week15Team23.Substring(2).Trim();
                        textBoxTeamName24.Text = selectedSeason3.Week15Team24.Substring(2).Trim();
                        textBoxTeamName25.Text = selectedSeason3.Week15Team25.Substring(2).Trim();
                        textBoxTeamName26.Text = selectedSeason3.Week15Team26.Substring(2).Trim();
                        textBoxTeamName27.Text = selectedSeason3.Week15Team27.Substring(2).Trim();
                        textBoxTeamName28.Text = selectedSeason3.Week15Team28.Substring(2).Trim();
                        textBoxTeamName29.Text = selectedSeason3.Week15Team29.Substring(2).Trim();
                        textBoxTeamName30.Text = selectedSeason3.Week15Team30.Substring(2).Trim();
                        textBoxTeamName31.Text = selectedSeason3.Week15Team31.Substring(2).Trim();
                        textBoxTeamName32.Text = selectedSeason3.Week15Team32.Substring(2).Trim();
                        textBoxTeamName33.Text = selectedSeason3.Week15Team33.Substring(2).Trim();
                        textBoxTeamName34.Text = selectedSeason3.Week15Team34.Substring(2).Trim();
                        textBoxTeamName35.Text = selectedSeason3.Week15Team35.Substring(2).Trim();
                        textBoxTeamName36.Text = selectedSeason3.Week15Team36.Substring(2).Trim();
                        textBoxTeamName37.Text = selectedSeason3.Week15Team37.Substring(2).Trim();
                        textBoxTeamName38.Text = selectedSeason3.Week15Team38.Substring(2).Trim();
                        textBoxTeamName39.Text = selectedSeason3.Week15Team39.Substring(2).Trim();
                        textBoxTeamName40.Text = selectedSeason3.Week15Team40.Substring(2).Trim();
                        textBoxTeamName41.Text = selectedSeason3.Week15Team41.Substring(2).Trim();
                        textBoxTeamName42.Text = selectedSeason3.Week15Team42.Substring(2).Trim();
                        textBoxTeamName43.Text = selectedSeason3.Week15Team43.Substring(2).Trim();
                        textBoxTeamName44.Text = selectedSeason3.Week15Team44.Substring(2).Trim();
                        upDownPicksLimit.Value = selectedSeason1.MaxPicksWeek15;

                    }

                    // ------------------- WEEK 16 -------------------------
                    if (comboBoxSelectWeekSeason.Text == "Week 16" && selectedSeason3.Week16Team01 != "")
                    {
                        textBoxTeamName01.Text = selectedSeason3.Week16Team01.Substring(2).Trim();
                        textBoxTeamName02.Text = selectedSeason3.Week16Team02.Substring(2).Trim();
                        textBoxTeamName03.Text = selectedSeason3.Week16Team03.Substring(2).Trim();
                        textBoxTeamName04.Text = selectedSeason3.Week16Team04.Substring(2).Trim();
                        textBoxTeamName05.Text = selectedSeason3.Week16Team05.Substring(2).Trim();
                        textBoxTeamName06.Text = selectedSeason3.Week16Team06.Substring(2).Trim();
                        textBoxTeamName07.Text = selectedSeason3.Week16Team07.Substring(2).Trim();
                        textBoxTeamName08.Text = selectedSeason3.Week16Team08.Substring(2).Trim();
                        textBoxTeamName09.Text = selectedSeason3.Week16Team09.Substring(2).Trim();
                        textBoxTeamName10.Text = selectedSeason3.Week16Team10.Substring(2).Trim();
                        textBoxTeamName11.Text = selectedSeason3.Week16Team11.Substring(2).Trim();
                        textBoxTeamName12.Text = selectedSeason3.Week16Team12.Substring(2).Trim();
                        textBoxTeamName13.Text = selectedSeason3.Week16Team13.Substring(2).Trim();
                        textBoxTeamName14.Text = selectedSeason3.Week16Team14.Substring(2).Trim();
                        textBoxTeamName15.Text = selectedSeason3.Week16Team15.Substring(2).Trim();
                        textBoxTeamName16.Text = selectedSeason3.Week16Team16.Substring(2).Trim();
                        textBoxTeamName17.Text = selectedSeason3.Week16Team17.Substring(2).Trim();
                        textBoxTeamName18.Text = selectedSeason3.Week16Team18.Substring(2).Trim();
                        textBoxTeamName19.Text = selectedSeason3.Week16Team19.Substring(2).Trim();
                        textBoxTeamName20.Text = selectedSeason3.Week16Team20.Substring(2).Trim();
                        textBoxTeamName21.Text = selectedSeason3.Week16Team21.Substring(2).Trim();
                        textBoxTeamName22.Text = selectedSeason3.Week16Team22.Substring(2).Trim();
                        textBoxTeamName23.Text = selectedSeason3.Week16Team23.Substring(2).Trim();
                        textBoxTeamName24.Text = selectedSeason3.Week16Team24.Substring(2).Trim();
                        textBoxTeamName25.Text = selectedSeason3.Week16Team25.Substring(2).Trim();
                        textBoxTeamName26.Text = selectedSeason3.Week16Team26.Substring(2).Trim();
                        textBoxTeamName27.Text = selectedSeason3.Week16Team27.Substring(2).Trim();
                        textBoxTeamName28.Text = selectedSeason3.Week16Team28.Substring(2).Trim();
                        textBoxTeamName29.Text = selectedSeason3.Week16Team29.Substring(2).Trim();
                        textBoxTeamName30.Text = selectedSeason3.Week16Team30.Substring(2).Trim();
                        textBoxTeamName31.Text = selectedSeason3.Week16Team31.Substring(2).Trim();
                        textBoxTeamName32.Text = selectedSeason3.Week16Team32.Substring(2).Trim();
                        textBoxTeamName33.Text = selectedSeason3.Week16Team33.Substring(2).Trim();
                        textBoxTeamName34.Text = selectedSeason3.Week16Team34.Substring(2).Trim();
                        textBoxTeamName35.Text = selectedSeason3.Week16Team35.Substring(2).Trim();
                        textBoxTeamName36.Text = selectedSeason3.Week16Team36.Substring(2).Trim();
                        textBoxTeamName37.Text = selectedSeason3.Week16Team37.Substring(2).Trim();
                        textBoxTeamName38.Text = selectedSeason3.Week16Team38.Substring(2).Trim();
                        textBoxTeamName39.Text = selectedSeason3.Week16Team39.Substring(2).Trim();
                        textBoxTeamName40.Text = selectedSeason3.Week16Team40.Substring(2).Trim();
                        textBoxTeamName41.Text = selectedSeason3.Week16Team41.Substring(2).Trim();
                        textBoxTeamName42.Text = selectedSeason3.Week16Team42.Substring(2).Trim();
                        textBoxTeamName43.Text = selectedSeason3.Week16Team43.Substring(2).Trim();
                        textBoxTeamName44.Text = selectedSeason3.Week16Team44.Substring(2).Trim();
                        upDownPicksLimit.Value = selectedSeason1.MaxPicksWeek16;

                    }

                    // ------------------- WEEK 17 -------------------------
                    if (comboBoxSelectWeekSeason.Text == "Week 17" && selectedSeason3.Week17Team01 != "")
                    {
                        textBoxTeamName01.Text = selectedSeason3.Week17Team01.Substring(2).Trim();
                        textBoxTeamName02.Text = selectedSeason3.Week17Team02.Substring(2).Trim();
                        textBoxTeamName03.Text = selectedSeason3.Week17Team03.Substring(2).Trim();
                        textBoxTeamName04.Text = selectedSeason3.Week17Team04.Substring(2).Trim();
                        textBoxTeamName05.Text = selectedSeason3.Week17Team05.Substring(2).Trim();
                        textBoxTeamName06.Text = selectedSeason3.Week17Team06.Substring(2).Trim();
                        textBoxTeamName07.Text = selectedSeason3.Week17Team07.Substring(2).Trim();
                        textBoxTeamName08.Text = selectedSeason3.Week17Team08.Substring(2).Trim();
                        textBoxTeamName09.Text = selectedSeason3.Week17Team09.Substring(2).Trim();
                        textBoxTeamName10.Text = selectedSeason3.Week17Team10.Substring(2).Trim();
                        textBoxTeamName11.Text = selectedSeason3.Week17Team11.Substring(2).Trim();
                        textBoxTeamName12.Text = selectedSeason3.Week17Team12.Substring(2).Trim();
                        textBoxTeamName13.Text = selectedSeason3.Week17Team13.Substring(2).Trim();
                        textBoxTeamName14.Text = selectedSeason3.Week17Team14.Substring(2).Trim();
                        textBoxTeamName15.Text = selectedSeason3.Week17Team15.Substring(2).Trim();
                        textBoxTeamName16.Text = selectedSeason3.Week17Team16.Substring(2).Trim();
                        textBoxTeamName17.Text = selectedSeason3.Week17Team17.Substring(2).Trim();
                        textBoxTeamName18.Text = selectedSeason3.Week17Team18.Substring(2).Trim();
                        textBoxTeamName19.Text = selectedSeason3.Week17Team19.Substring(2).Trim();
                        textBoxTeamName20.Text = selectedSeason3.Week17Team20.Substring(2).Trim();
                        textBoxTeamName21.Text = selectedSeason3.Week17Team21.Substring(2).Trim();
                        textBoxTeamName22.Text = selectedSeason3.Week17Team22.Substring(2).Trim();
                        textBoxTeamName23.Text = selectedSeason3.Week17Team23.Substring(2).Trim();
                        textBoxTeamName24.Text = selectedSeason3.Week17Team24.Substring(2).Trim();
                        textBoxTeamName25.Text = selectedSeason3.Week17Team25.Substring(2).Trim();
                        textBoxTeamName26.Text = selectedSeason3.Week17Team26.Substring(2).Trim();
                        textBoxTeamName27.Text = selectedSeason3.Week17Team27.Substring(2).Trim();
                        textBoxTeamName28.Text = selectedSeason3.Week17Team28.Substring(2).Trim();
                        textBoxTeamName29.Text = selectedSeason3.Week17Team29.Substring(2).Trim();
                        textBoxTeamName30.Text = selectedSeason3.Week17Team30.Substring(2).Trim();
                        textBoxTeamName31.Text = selectedSeason3.Week17Team31.Substring(2).Trim();
                        textBoxTeamName32.Text = selectedSeason3.Week17Team32.Substring(2).Trim();
                        textBoxTeamName33.Text = selectedSeason3.Week17Team33.Substring(2).Trim();
                        textBoxTeamName34.Text = selectedSeason3.Week17Team34.Substring(2).Trim();
                        textBoxTeamName35.Text = selectedSeason3.Week17Team35.Substring(2).Trim();
                        textBoxTeamName36.Text = selectedSeason3.Week17Team36.Substring(2).Trim();
                        textBoxTeamName37.Text = selectedSeason3.Week17Team37.Substring(2).Trim();
                        textBoxTeamName38.Text = selectedSeason3.Week17Team38.Substring(2).Trim();
                        textBoxTeamName39.Text = selectedSeason3.Week17Team39.Substring(2).Trim();
                        textBoxTeamName40.Text = selectedSeason3.Week17Team40.Substring(2).Trim();
                        textBoxTeamName41.Text = selectedSeason3.Week17Team41.Substring(2).Trim();
                        textBoxTeamName42.Text = selectedSeason3.Week17Team42.Substring(2).Trim();
                        textBoxTeamName43.Text = selectedSeason3.Week17Team43.Substring(2).Trim();
                        textBoxTeamName44.Text = selectedSeason3.Week17Team44.Substring(2).Trim();
                        upDownPicksLimit.Value = selectedSeason1.MaxPicksWeek17;
                    }
                    */
                    }

        private void buttonResetPlayers_Click(object sender, EventArgs e)
        {
            var confirmSubmitFinal = MessageBox.Show("This will reset all of the players picks and wins in the database. Are you sure?", "Confirm Reset Players", MessageBoxButtons.YesNo);

            if (confirmSubmitFinal == DialogResult.Yes)
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

                    this.Validate();
                    this.playersBindingSource.EndEdit();
                    this.tableAdapterManager1.UpdateAll(this.playersDBDataSet);
                }
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Players have been reset.");

            }
            else
            {
                MessageBox.Show("Reset Players cancelled.");
            }
        }

        private void buttonMakePlayersInactive_Click(object sender, EventArgs e)
        {
            foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
            {
                player.IsActive = false;
            }

            this.Validate();
            this.playersBindingSource.EndEdit();
            this.tableAdapterManager1.UpdateAll(this.playersDBDataSet);

            MessageBox.Show("All players made inactive.");
        }
    }
}
