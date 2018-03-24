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
using Microsoft.Office.Interop.Excel;

namespace Big8_MAIN
{
    public partial class FormLiveWindow : Form
    {
        private List<System.Windows.Forms.CheckBox> CheckBoxes = new List<System.Windows.Forms.CheckBox>();
        private List<System.Windows.Forms.CheckBox> CheckBoxesSaved = new List<System.Windows.Forms.CheckBox>();
        private SavedCheckBoxesLive checkBoxesLiveWindow = new SavedCheckBoxesLive();

        int totalOut = 0;
        int totalStillIn = 0;
        bool makeFinal;

        int progressiveTotal = 0;
        int weeklyPotTotal = 0;
        int rollOverPot = 0;
        decimal interest = 0;
        double totalPayOut = 0;
        int playerCount = 0;
        int grossPot = 0;

        public FormLiveWindow()
        {
            InitializeComponent();

            // get the current season
            if (PublicVariables.GetDefaultSeason != null)
            {
                textBoxSelectedSeason.Text = PublicVariables.GetDefaultSeason;
            }
            // set default week
            if (PublicVariables.GetDefaultWeek != null)
            {
                comboBoxSelectWeekLive.SelectedItem = PublicVariables.GetDefaultWeek;
            }

            BuildCheckBoxList();
            /*if (File.Exists("CheckBoxesSave.bin") && new FileInfo("CheckBoxesSave.bin").Length != 0)
            {
                //Serialization logic
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("CheckBoxesSave.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                SavedCheckBoxesLive checkBoxesLiveWindow = (SavedCheckBoxesLive)formatter.Deserialize(stream);
                stream.Close();
            }
            BuildSavedCheckBoxesList();
            LoadSavedCheckboxes();
            */
        }

        private void FormLiveWindow_Load(object sender, EventArgs e)
        {
            loserBracket01_1.Checked = Properties.Settings.Default.CheckBox01;
            loserBracket01_2.Checked = Properties.Settings.Default.CheckBox02;
            loserBracket02_1.Checked = Properties.Settings.Default.CheckBox03;
            loserBracket02_2.Checked = Properties.Settings.Default.CheckBox04;
            loserBracket03_1.Checked = Properties.Settings.Default.CheckBox05;
            loserBracket03_2.Checked = Properties.Settings.Default.CheckBox06;
            loserBracket04_1.Checked = Properties.Settings.Default.CheckBox07;
            loserBracket04_2.Checked = Properties.Settings.Default.CheckBox08;
            loserBracket05_1.Checked = Properties.Settings.Default.CheckBox09;
            loserBracket05_2.Checked = Properties.Settings.Default.CheckBox10;
            loserBracket06_1.Checked = Properties.Settings.Default.CheckBox11;
            loserBracket06_2.Checked = Properties.Settings.Default.CheckBox12;
            loserBracket07_1.Checked = Properties.Settings.Default.CheckBox13;
            loserBracket07_2.Checked = Properties.Settings.Default.CheckBox14;
            loserBracket08_1.Checked = Properties.Settings.Default.CheckBox15;
            loserBracket08_2.Checked = Properties.Settings.Default.CheckBox16;
            loserBracket09_1.Checked = Properties.Settings.Default.CheckBox17;
            loserBracket09_2.Checked = Properties.Settings.Default.CheckBox18;
            loserBracket10_1.Checked = Properties.Settings.Default.CheckBox19;
            loserBracket10_2.Checked = Properties.Settings.Default.CheckBox20;
            loserBracket11_1.Checked = Properties.Settings.Default.CheckBox21;
            loserBracket11_2.Checked = Properties.Settings.Default.CheckBox22;
            loserBracket12_1.Checked = Properties.Settings.Default.CheckBox23;
            loserBracket12_2.Checked = Properties.Settings.Default.CheckBox24;
            loserBracket13_1.Checked = Properties.Settings.Default.CheckBox25;
            loserBracket13_2.Checked = Properties.Settings.Default.CheckBox26;
            loserBracket14_1.Checked = Properties.Settings.Default.CheckBox27;
            loserBracket14_2.Checked = Properties.Settings.Default.CheckBox28;
            loserBracket15_1.Checked = Properties.Settings.Default.CheckBox29;
            loserBracket15_2.Checked = Properties.Settings.Default.CheckBox30;
            loserBracket16_1.Checked = Properties.Settings.Default.CheckBox31;
            loserBracket16_2.Checked = Properties.Settings.Default.CheckBox32;
            loserBracket17_1.Checked = Properties.Settings.Default.CheckBox33;
            loserBracket17_2.Checked = Properties.Settings.Default.CheckBox34;
            loserBracket18_1.Checked = Properties.Settings.Default.CheckBox35;
            loserBracket18_2.Checked = Properties.Settings.Default.CheckBox36;
            loserBracket19_1.Checked = Properties.Settings.Default.CheckBox37;
            loserBracket19_2.Checked = Properties.Settings.Default.CheckBox38;
            loserBracket20_1.Checked = Properties.Settings.Default.CheckBox39;
            loserBracket20_2.Checked = Properties.Settings.Default.CheckBox40;

            loserBracket01_1.Checked = Properties.Settings.Default.CheckBox01;
            // TODO: This line of code loads data into the 'transactionsDBDataSet.Transactions' table. You can move, or remove it, as needed.
            this.transactionsTableAdapter.Fill(this.transactionsDBDataSet.Transactions);
            // TODO: This line of code loads data into the 'accountingDataSet.Accounting' table. You can move, or remove it, as needed.
            this.accountingTableAdapter.Fill(this.accountingDataSet.Accounting);
            // fill the seasons DB
            this.seasons6_10TableAdapter.Fill(this.seasonsDBDataSet.Seasons6_10);
            this.seasons11_17TableAdapter.Fill(this.seasonsDBDataSet.Seasons11_17);
            this.seasons1_5TableAdapter.Fill(this.seasonsDBDataSet.Seasons1_5);

            // fill the player DB
            this.playersTableAdapter.Fill(this.playersDBDataSet.Players);

            GetWhosOutAlready();
            GetTotalActivePlayers();
            BuildWinnersLosersBox();
            CalculatePot();
            MakeFinal();
            labelTotalStillInLive.Text = totalStillIn.ToString();
            labelTotalOutLive.Text = totalOut.ToString();
        }

        private void GetTotalActivePlayers()
        {
            int totalActivePlayers = 0;

            // just get total number of active players
            foreach (PlayersDBDataSet.PlayersRow players in playersDBDataSet.Players)
            {
                if (players.IsActive)
                {
                    totalActivePlayers++;
                }
            }

            labelTotalPlayers.Text = totalActivePlayers.ToString();
        }

        // for people who didnt send in picks or did not pick enough teams
        private void GetWhosOutAlready()
        {
            // need to find any people who have no picks or not enough picks and make them out already
            foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
            {
                foreach (SeasonsDBDataSet.Seasons1_5Row season in seasonsDBDataSet.Seasons1_5)
                {
                    if (season.SeasonName == textBoxSelectedSeason.Text)
                    {
                        if (comboBoxSelectWeekLive.Text == "Week 01")
                        {
                            // split thier picks
                            string[] tempStringPlayer = player.PicksWeek01.Split(',');
                            // add split picks to list
                            List<string> tempList = new List<string>(tempStringPlayer);

                            // remove the zeroes
                            for (int i = 0; i < tempList.Count; i++)
                            {
                                if (tempList[i].ToString() == "0")
                                {
                                    tempList.RemoveAt(i);
                                }
                            }

                            // if they dont have any picks or didnt make enough picks
                            if (player.PicksWeek01 == "" || tempList.Count < season.MaxPicksWeek01)
                            {
                                player.IsOut = true;
                            }
                        }
                        if (comboBoxSelectWeekLive.Text == "Week 02")
                        {
                            // split thier picks
                            string[] tempStringPlayer = player.PicksWeek02.Split(',');
                            // add split picks to list
                            List<string> tempList = new List<string>(tempStringPlayer);

                            // remove the zeroes
                            for (int i = 0; i < tempList.Count; i++)
                            {
                                if (tempList[i].ToString() == "0")
                                {
                                    tempList.RemoveAt(i);
                                }
                            }

                            if (player.PicksWeek02 == "" || tempList.Count < season.MaxPicksWeek02)
                            {
                                player.IsOut = true;
                            }
                        }
                        if (comboBoxSelectWeekLive.Text == "Week 03")
                        {
                            // split thier picks
                            string[] tempStringPlayer = player.PicksWeek03.Split(',');
                            // add split picks to list
                            List<string> tempList = new List<string>(tempStringPlayer);

                            // remove the zeroes
                            for (int i = 0; i < tempList.Count; i++)
                            {
                                if (tempList[i].ToString() == "0")
                                {
                                    tempList.RemoveAt(i);
                                }
                            }

                            if (player.PicksWeek03 == "" || tempList.Count < season.MaxPicksWeek03)
                            {
                                player.IsOut = true;
                            }
                        }
                        if (comboBoxSelectWeekLive.Text == "Week 04")
                        {
                            // split thier picks
                            string[] tempStringPlayer = player.PicksWeek04.Split(',');
                            // add split picks to list
                            List<string> tempList = new List<string>(tempStringPlayer);

                            // remove the zeroes
                            for (int i = 0; i < tempList.Count; i++)
                            {
                                if (tempList[i].ToString() == "0")
                                {
                                    tempList.RemoveAt(i);
                                }
                            }

                            if (player.PicksWeek04 == "" || tempList.Count < season.MaxPicksWeek04)
                            {
                                player.IsOut = true;
                            }
                        }
                        if (comboBoxSelectWeekLive.Text == "Week 05")
                        {
                            // split thier picks
                            string[] tempStringPlayer = player.PicksWeek05.Split(',');
                            // add split picks to list
                            List<string> tempList = new List<string>(tempStringPlayer);

                            // remove the zeroes
                            for (int i = 0; i < tempList.Count; i++)
                            {
                                if (tempList[i].ToString() == "0")
                                {
                                    tempList.RemoveAt(i);
                                }
                            }

                            if (player.PicksWeek05 == "" || tempList.Count < season.MaxPicksWeek05)
                            {
                                player.IsOut = true;
                            }
                        }
                        if (comboBoxSelectWeekLive.Text == "Week 06")
                        {
                            // split thier picks
                            string[] tempStringPlayer = player.PicksWeek06.Split(',');
                            // add split picks to list
                            List<string> tempList = new List<string>(tempStringPlayer);

                            // remove the zeroes
                            for (int i = 0; i < tempList.Count; i++)
                            {
                                if (tempList[i].ToString() == "0")
                                {
                                    tempList.RemoveAt(i);
                                }
                            }

                            if (player.PicksWeek06 == "" || tempList.Count < season.MaxPicksWeek06)
                            {
                                player.IsOut = true;
                            }
                        }
                        if (comboBoxSelectWeekLive.Text == "Week 07")
                        {
                            // split thier picks
                            string[] tempStringPlayer = player.PicksWeek07.Split(',');
                            // add split picks to list
                            List<string> tempList = new List<string>(tempStringPlayer);

                            // remove the zeroes
                            for (int i = 0; i < tempList.Count; i++)
                            {
                                if (tempList[i].ToString() == "0")
                                {
                                    tempList.RemoveAt(i);
                                }
                            }

                            if (player.PicksWeek07 == "" || tempList.Count < season.MaxPicksWeek07)
                            {
                                player.IsOut = true;
                            }
                        }
                        if (comboBoxSelectWeekLive.Text == "Week 08")
                        {
                            // split thier picks
                            string[] tempStringPlayer = player.PicksWeek08.Split(',');
                            // add split picks to list
                            List<string> tempList = new List<string>(tempStringPlayer);
                            // remove the zeroes
                            for (int i = 0; i < tempList.Count; i++)
                            {
                                if (tempList[i].ToString() == "0")
                                {
                                    tempList.RemoveAt(i);
                                }
                            }

                            if (player.PicksWeek08 == "" || tempList.Count < season.MaxPicksWeek08)
                            {
                                player.IsOut = true;
                            }
                        }
                        if (comboBoxSelectWeekLive.Text == "Week 09")
                        {
                            // split thier picks
                            string[] tempStringPlayer = player.PicksWeek09.Split(',');
                            // add split picks to list
                            List<string> tempList = new List<string>(tempStringPlayer);
                            // remove the zeroes
                            for (int i = 0; i < tempList.Count; i++)
                            {
                                if (tempList[i].ToString() == "0")
                                {
                                    tempList.RemoveAt(i);
                                }
                            }

                            if (player.PicksWeek09 == "" || tempList.Count < season.MaxPicksWeek09)
                            {
                                player.IsOut = true;
                            }
                        }
                        if (comboBoxSelectWeekLive.Text == "Week 10")
                        {
                            // split thier picks
                            string[] tempStringPlayer = player.PicksWeek10.Split(',');
                            // add split picks to list
                            List<string> tempList = new List<string>(tempStringPlayer);
                            // remove the zeroes
                            for (int i = 0; i < tempList.Count; i++)
                            {
                                if (tempList[i].ToString() == "0")
                                {
                                    tempList.RemoveAt(i);
                                }
                            }

                            if (player.PicksWeek10 == "" || tempList.Count < season.MaxPicksWeek10)
                            {
                                player.IsOut = true;
                            }
                        }
                        if (comboBoxSelectWeekLive.Text == "Week 11")
                        {
                            // split thier picks
                            string[] tempStringPlayer = player.PicksWeek11.Split(',');
                            // add split picks to list
                            List<string> tempList = new List<string>(tempStringPlayer);
                            // remove the zeroes
                            for (int i = 0; i < tempList.Count; i++)
                            {
                                if (tempList[i].ToString() == "0")
                                {
                                    tempList.RemoveAt(i);
                                }
                            }

                            if (player.PicksWeek11 == "" || tempList.Count < season.MaxPicksWeek11)
                            {
                                player.IsOut = true;
                            }
                        }
                        if (comboBoxSelectWeekLive.Text == "Week 12")
                        {
                            // split thier picks
                            string[] tempStringPlayer = player.PicksWeek12.Split(',');
                            // add split picks to list
                            List<string> tempList = new List<string>(tempStringPlayer);
                            // remove the zeroes
                            for (int i = 0; i < tempList.Count; i++)
                            {
                                if (tempList[i].ToString() == "0")
                                {
                                    tempList.RemoveAt(i);
                                }
                            }

                            if (player.PicksWeek12 == "" || tempList.Count < season.MaxPicksWeek12)
                            {
                                player.IsOut = true;
                            }
                        }
                        if (comboBoxSelectWeekLive.Text == "Week 13")
                        {
                            // split thier picks
                            string[] tempStringPlayer = player.PicksWeek13.Split(',');
                            // add split picks to list
                            List<string> tempList = new List<string>(tempStringPlayer);
                            // remove the zeroes
                            for (int i = 0; i < tempList.Count; i++)
                            {
                                if (tempList[i].ToString() == "0")
                                {
                                    tempList.RemoveAt(i);
                                }
                            }

                            if (player.PicksWeek13 == "" || tempList.Count < season.MaxPicksWeek13)
                            {
                                player.IsOut = true;
                            }
                        }
                        if (comboBoxSelectWeekLive.Text == "Week 14")
                        {
                            // split thier picks
                            string[] tempStringPlayer = player.PicksWeek14.Split(',');
                            // add split picks to list
                            List<string> tempList = new List<string>(tempStringPlayer);
                            // remove the zeroes
                            for (int i = 0; i < tempList.Count; i++)
                            {
                                if (tempList[i].ToString() == "0")
                                {
                                    tempList.RemoveAt(i);
                                }
                            }

                            if (player.PicksWeek14 == "" || tempList.Count < season.MaxPicksWeek14)
                            {
                                player.IsOut = true;
                            }
                        }
                        if (comboBoxSelectWeekLive.Text == "Week 15")
                        {
                            // split thier picks
                            string[] tempStringPlayer = player.PicksWeek15.Split(',');
                            // add split picks to list
                            List<string> tempList = new List<string>(tempStringPlayer);
                            // remove the zeroes
                            for (int i = 0; i < tempList.Count; i++)
                            {
                                if (tempList[i].ToString() == "0")
                                {
                                    tempList.RemoveAt(i);
                                }
                            }

                            if (player.PicksWeek15 == "" || tempList.Count < season.MaxPicksWeek15)
                            {
                                player.IsOut = true;
                            }
                        }
                        if (comboBoxSelectWeekLive.Text == "Week 16")
                        {
                            // split thier picks
                            string[] tempStringPlayer = player.PicksWeek16.Split(',');
                            // add split picks to list
                            List<string> tempList = new List<string>(tempStringPlayer);
                            // remove the zeroes
                            for (int i = 0; i < tempList.Count; i++)
                            {
                                if (tempList[i].ToString() == "0")
                                {
                                    tempList.RemoveAt(i);
                                }
                            }

                            if (player.PicksWeek16 == "" || tempList.Count < season.MaxPicksWeek16)
                            {
                                player.IsOut = true;
                            }
                        }

                        /*
                        if (comboBoxSelectWeekLive.Text == "Week 17")
                        {
                            // split thier picks
                            string[] tempStringPlayer = player.PicksWeek17.Split(',');
                            // add split picks to list
                            List<string> tempList = new List<string>(tempStringPlayer);
                            // remove the zeroes
                            for (int i = 0; i < tempList.Count; i++)
                            {
                                if (tempList[i].ToString() == "0")
                                {
                                    tempList.RemoveAt(i);
                                }
                            }

                            if (player.PicksWeek17 == "" || tempList.Count < season.MaxPicksWeek17)
                            {
                                player.IsOut = true;
                            }
                        }
                        */
                    }
                }
            }
        }

        private void BuildWinnersLosersBox()
        {
            listViewStillInLive.Items.Clear();
            listViewOutLive.Items.Clear();

            foreach (PlayersDBDataSet.PlayersRow winningPlayers in playersDBDataSet.Players)
            {
                if (winningPlayers.IsActive == true)
                {
                    if (winningPlayers.IsOut == false)
                    {
                        // add him to the box                  
                        ListViewItem newRow = new ListViewItem();

                        newRow.Text = GetWeekWinsWinnerLoserBox(winningPlayers);
                        newRow.SubItems.Add(winningPlayers.PlayerPoolName);

                        listViewStillInLive.Items.Add(newRow);
                    }

                    if (winningPlayers.IsOut == true)
                    {
                        ListViewItem newRow = new ListViewItem();

                        newRow.Text = GetWeekWinsWinnerLoserBox(winningPlayers);
                        newRow.SubItems.Add(winningPlayers.PlayerPoolName);

                        listViewOutLive.Items.Add(newRow);
                    }
                }
            }

            labelTotalStillInLive.Text = listViewStillInLive.Items.Count.ToString();
            labelTotalOutLive.Text = listViewOutLive.Items.Count.ToString();
        }

        private string GetWeekWinsWinnerLoserBox(PlayersDBDataSet.PlayersRow player)
        {
            if (comboBoxSelectWeekLive.Text == "Week 01")
            {
                return player.WinsWeek01.ToString();
            }
            else if (comboBoxSelectWeekLive.Text == "Week 02")
            {
                return player.WinsWeek02.ToString();
            }
            else if (comboBoxSelectWeekLive.Text == "Week 03")
            {
                return player.WinsWeek03.ToString();
            }
            else if (comboBoxSelectWeekLive.Text == "Week 04")
            {
                return player.WinsWeek04.ToString();
            }
            else if (comboBoxSelectWeekLive.Text == "Week 05")
            {
                return player.WinsWeek05.ToString();
            }
            else if (comboBoxSelectWeekLive.Text == "Week 06")
            {
                return player.WinsWeek06.ToString();
            }
            else if (comboBoxSelectWeekLive.Text == "Week 07")
            {
                return player.WinsWeek07.ToString();
            }
            else if (comboBoxSelectWeekLive.Text == "Week 08")
            {
                return player.WinsWeek08.ToString();
            }
            else if (comboBoxSelectWeekLive.Text == "Week 09")
            {
                return player.WinsWeek09.ToString();
            }
            else if (comboBoxSelectWeekLive.Text == "Week 10")
            {
                return player.WinsWeek10.ToString();
            }
            else if (comboBoxSelectWeekLive.Text == "Week 11")
            {
                return player.WinsWeek11.ToString();
            }
            else if (comboBoxSelectWeekLive.Text == "Week 12")
            {
                return player.WinsWeek12.ToString();
            }
            else if (comboBoxSelectWeekLive.Text == "Week 13")
            {
                return player.WinsWeek13.ToString();
            }
            else if (comboBoxSelectWeekLive.Text == "Week 14")
            {
                return player.WinsWeek14.ToString();
            }
            else if (comboBoxSelectWeekLive.Text == "Week 15")
            {
                return player.WinsWeek15.ToString();
            }
            else if (comboBoxSelectWeekLive.Text == "Week 16")
            {
                return player.WinsWeek16.ToString();
            }
            else
            {
                return player.WinsWeek17.ToString();
            }
        }

        // Just to see what would happen. Does not apply to the database.
        private void ViewResult(bool dontSubmit)
        {
            ResetIsOut();
            GetWhosOutAlready();
            string tempString = "";
            List<string> checkBoxList = new List<string>();
            BuildCheckBoxList(checkBoxList);

            SeasonsDBDataSet.Seasons1_5Row season1_5 = FindSeason1_5();
            SeasonsDBDataSet.Seasons6_10Row season6_10 = FindSeason6_10();
            SeasonsDBDataSet.Seasons11_17Row season11_17 = FindSeason11_17();

            // Week 01
            if (comboBoxSelectWeekLive.Text == "Week 01")
            {
                // reset the player wins week01
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    player.WinsWeek01 = 0;
                }

                // this is to save the choices to reference later when MakeFinal()
                // creates a string using the check boxes with comma seperator
                tempString = string.Join(",", checkBoxList.ToArray());

                // make losersWeek01 comma seperated string
                if (!season1_5.Week01IsFinal)
                {
                    season1_5.LosersWeek01 = tempString;
                }

                // For each check box
                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    // if it is checked
                    if (checkBoxes.Checked == true)
                    {
                        // go through each player
                        foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                        {
                            // if thier week 1 picks are not blank and they are not already out
                            if (player.PicksWeek01 != "")
                            {
                                // split thier picks
                                string[] tempStringPlayer = player.PicksWeek01.Split(',');
                                // add split picks to list
                                List<string> tempList = new List<string>(tempStringPlayer);

                                // if it does contain the checked box they get a win. need to check make sure the check box is not a blank one.
                                if (tempList.Contains(checkBoxes.Text) && checkBoxes.Text != "")
                                {
                                    // check to make sure this bracket is not a tie. both players lose if it is.
                                    if (!CheckTie(checkBoxes.Name))
                                    {
                                        // player gets a win
                                        player.WinsWeek01++;

                                        // if we are actually submitting this
                                        if (dontSubmit == false)
                                        {
                                            // total wins goes up
                                            player.PlayerTotalWins++;
                                        }
                                    }
                                    else
                                    {
                                        if (CheckPlayerLost(checkBoxes.Name, tempList))
                                        {
                                            player.IsOut = true;
                                        }
                                    }
                                }
                                else
                                {
                                    if (CheckPlayerLost(checkBoxes.Name, tempList))
                                    {
                                        player.IsOut = true;
                                    }
                                }
                            }
                        }
                    }
                }

                if (dontSubmit == false)
                {
                    // if we are submitting this then make the week final
                    season1_5.Week01IsFinal = true;
                }
            }

            // Week 02
            else if (comboBoxSelectWeekLive.Text == "Week 02")
            {
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    player.WinsWeek02 = 0;
                }

                tempString = string.Join(",", checkBoxList.ToArray());
                if (!season1_5.Week02IsFinal)
                {
                    season1_5.LosersWeek02 = tempString;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (checkBoxes.Checked == true)
                    {
                        foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                        {
                            if (player.PicksWeek02 != "")
                            {
                                string[] tempStringPlayer = player.PicksWeek02.Split(',');
                                List<string> tempList = new List<string>(tempStringPlayer);
                                if (tempList.Contains(checkBoxes.Text) && checkBoxes.Text != "")
                                {
                                    if (!CheckTie(checkBoxes.Name))
                                    {
                                        player.WinsWeek02++;
                                        if (dontSubmit == false)
                                        {
                                            player.PlayerTotalWins++;
                                        }
                                    }
                                    else
                                    {
                                        if (CheckPlayerLost(checkBoxes.Name, tempList))
                                        {
                                            player.IsOut = true;
                                        }
                                    }
                                }
                                else
                                {
                                    if (CheckPlayerLost(checkBoxes.Name, tempList))
                                    {
                                        player.IsOut = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if (dontSubmit == false)
                {
                    season1_5.Week02IsFinal = true;
                }
            }
            // Week 03
            else if (comboBoxSelectWeekLive.Text == "Week 03")
            {
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    player.WinsWeek03 = 0;
                }

                tempString = string.Join(",", checkBoxList.ToArray());
                if (!season1_5.Week03IsFinal)
                {
                    season1_5.LosersWeek03 = tempString;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (checkBoxes.Checked == true)
                    {
                        foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                        {
                            if (player.PicksWeek03 != "")
                            {
                                string[] tempStringPlayer = player.PicksWeek03.Split(',');
                                List<string> tempList = new List<string>(tempStringPlayer);
                                if (tempList.Contains(checkBoxes.Text) && checkBoxes.Text != "")
                                {
                                    if (!CheckTie(checkBoxes.Name))
                                    {
                                        player.WinsWeek03++;
                                        if (dontSubmit == false)
                                        {
                                            player.PlayerTotalWins++;
                                        }
                                    }
                                    else
                                    {
                                        if (CheckPlayerLost(checkBoxes.Name, tempList))
                                        {
                                            player.IsOut = true;
                                        }
                                    }
                                }
                                else
                                {
                                    if (CheckPlayerLost(checkBoxes.Name, tempList))
                                    {
                                        player.IsOut = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if (dontSubmit == false)
                {
                    season1_5.Week03IsFinal = true;
                }
            }
            // Week 04
            else if (comboBoxSelectWeekLive.Text == "Week 04")
            {
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    player.WinsWeek04 = 0;
                }

                tempString = string.Join(",", checkBoxList.ToArray());
                if (!season1_5.Week04IsFinal)
                {
                    season1_5.LosersWeek04 = tempString;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (checkBoxes.Checked == true)
                    {
                        foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                        {
                            if (player.PicksWeek04 != "")
                            {
                                string[] tempStringPlayer = player.PicksWeek04.Split(',');
                                List<string> tempList = new List<string>(tempStringPlayer);
                                if (tempList.Contains(checkBoxes.Text) && checkBoxes.Text != "")
                                {
                                    if (!CheckTie(checkBoxes.Name))
                                    {
                                        player.WinsWeek04++;
                                        if (dontSubmit == false)
                                        {
                                            player.PlayerTotalWins++;
                                        }
                                    }
                                    else
                                    {
                                        if (CheckPlayerLost(checkBoxes.Name, tempList))
                                        {
                                            player.IsOut = true;
                                        }
                                    }
                                }
                                else
                                {
                                    if (CheckPlayerLost(checkBoxes.Name, tempList))
                                    {
                                        player.IsOut = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if (dontSubmit == false)
                {
                    season1_5.Week04IsFinal = true;
                }
            }
            // Week 05
            else if (comboBoxSelectWeekLive.Text == "Week 05")
            {
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    player.WinsWeek05 = 0;
                }

                tempString = string.Join(",", checkBoxList.ToArray());
                if (!season1_5.Week05IsFinal)
                {
                    season1_5.LosersWeek05 = tempString;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (checkBoxes.Checked == true)
                    {
                        foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                        {
                            if (player.PicksWeek05 != "")
                            {
                                string[] tempStringPlayer = player.PicksWeek05.Split(',');
                                List<string> tempList = new List<string>(tempStringPlayer);
                                if (tempList.Contains(checkBoxes.Text) && checkBoxes.Text != "")
                                {
                                    if (!CheckTie(checkBoxes.Name))
                                    {
                                        player.WinsWeek05++;
                                        if (dontSubmit == false)
                                        {
                                            player.PlayerTotalWins++;
                                        }
                                    }
                                    else
                                    {
                                        if (CheckPlayerLost(checkBoxes.Name, tempList))
                                        {
                                            player.IsOut = true;
                                        }
                                    }
                                }
                                else
                                {
                                    if (CheckPlayerLost(checkBoxes.Name, tempList))
                                    {
                                        player.IsOut = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if (dontSubmit == false)
                {
                    season1_5.Week05IsFinal = true;
                }
            }
            // Week 06
            else if (comboBoxSelectWeekLive.Text == "Week 06")
            {
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    player.WinsWeek06 = 0;
                }

                tempString = string.Join(",", checkBoxList.ToArray());
                if (!season6_10.Week06IsFinal)
                {
                    season6_10.LosersWeek06 = tempString;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (checkBoxes.Checked == true)
                    {
                        foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                        {
                            if (player.PicksWeek06 != "")
                            {
                                string[] tempStringPlayer = player.PicksWeek06.Split(',');
                                List<string> tempList = new List<string>(tempStringPlayer);
                                if (tempList.Contains(checkBoxes.Text) && checkBoxes.Text != "")
                                {
                                    if (!CheckTie(checkBoxes.Name))
                                    {
                                        player.WinsWeek06++;
                                        if (dontSubmit == false)
                                        {
                                            player.PlayerTotalWins++;
                                        }
                                    }
                                    else
                                    {
                                        if (CheckPlayerLost(checkBoxes.Name, tempList))
                                        {
                                            player.IsOut = true;
                                        }
                                    }
                                }
                                else
                                {
                                    if (CheckPlayerLost(checkBoxes.Name, tempList))
                                    {
                                        player.IsOut = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if (dontSubmit == false)
                {
                    season6_10.Week06IsFinal = true;
                }
            }
            // Week 07
            else if (comboBoxSelectWeekLive.Text == "Week 07")
            {
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    player.WinsWeek07 = 0;
                }

                tempString = string.Join(",", checkBoxList.ToArray());
                if (!season6_10.Week07IsFinal)
                {
                    season6_10.LosersWeek07 = tempString;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (checkBoxes.Checked == true)
                    {
                        foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                        {
                            if (player.PicksWeek07 != "")
                            {
                                string[] tempStringPlayer = player.PicksWeek07.Split(',');
                                List<string> tempList = new List<string>(tempStringPlayer);
                                if (tempList.Contains(checkBoxes.Text) && checkBoxes.Text != "")
                                {
                                    if (!CheckTie(checkBoxes.Name))
                                    {
                                        player.WinsWeek07++;
                                        if (dontSubmit == false)
                                        {
                                            player.PlayerTotalWins++;
                                        }
                                    }
                                    else
                                    {
                                        if (CheckPlayerLost(checkBoxes.Name, tempList))
                                        {
                                            player.IsOut = true;
                                        }
                                    }
                                }
                                else
                                {
                                    if (CheckPlayerLost(checkBoxes.Name, tempList))
                                    {
                                        player.IsOut = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if (dontSubmit == false)
                {
                    season6_10.Week07IsFinal = true;
                }
            }
            // Week 08
            else if (comboBoxSelectWeekLive.Text == "Week 08")
            {
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    player.WinsWeek08 = 0;
                }

                tempString = string.Join(",", checkBoxList.ToArray());
                if (!season6_10.Week08IsFinal)
                {
                    season6_10.LosersWeek08 = tempString;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (checkBoxes.Checked == true)
                    {
                        foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                        {
                            if (player.PicksWeek08 != "")
                            {
                                string[] tempStringPlayer = player.PicksWeek08.Split(',');
                                List<string> tempList = new List<string>(tempStringPlayer);
                                if (tempList.Contains(checkBoxes.Text) && checkBoxes.Text != "")
                                {
                                    if (!CheckTie(checkBoxes.Name))
                                    {
                                        player.WinsWeek08++;
                                        if (dontSubmit == false)
                                        {
                                            player.PlayerTotalWins++;
                                        }
                                    }
                                    else
                                    {
                                        if (CheckPlayerLost(checkBoxes.Name, tempList))
                                        {
                                            player.IsOut = true;
                                        }
                                    }
                                }
                                else
                                {
                                    if (CheckPlayerLost(checkBoxes.Name, tempList))
                                    {
                                        player.IsOut = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if (dontSubmit == false)
                {
                    season6_10.Week08IsFinal = true;
                }
            }
            // Week 09
            else if (comboBoxSelectWeekLive.Text == "Week 09")
            {
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    player.WinsWeek09 = 0;
                }

                tempString = string.Join(",", checkBoxList.ToArray());
                if (!season6_10.Week09IsFinal)
                {
                    season6_10.LosersWeek09 = tempString;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (checkBoxes.Checked == true)
                    {
                        foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                        {
                            if (player.PicksWeek09 != "")
                            {
                                string[] tempStringPlayer = player.PicksWeek09.Split(',');
                                List<string> tempList = new List<string>(tempStringPlayer);
                                if (tempList.Contains(checkBoxes.Text) && checkBoxes.Text != "")
                                {
                                    if (!CheckTie(checkBoxes.Name))
                                    {
                                        player.WinsWeek09++;
                                        if (dontSubmit == false)
                                        {
                                            player.PlayerTotalWins++;
                                        }
                                    }
                                    else
                                    {
                                        if (CheckPlayerLost(checkBoxes.Name, tempList))
                                        {
                                            player.IsOut = true;
                                        }
                                    }
                                }
                                else
                                {
                                    if (CheckPlayerLost(checkBoxes.Name, tempList))
                                    {
                                        player.IsOut = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if (dontSubmit == false)
                {
                    season6_10.Week09IsFinal = true;
                }
            }
            // Week 10
            else if (comboBoxSelectWeekLive.Text == "Week 10")
            {
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    player.WinsWeek10 = 0;
                }

                tempString = string.Join(",", checkBoxList.ToArray());
                if (!season6_10.Week10IsFinal)
                {
                    season6_10.LosersWeek10 = tempString;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (checkBoxes.Checked == true)
                    {
                        foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                        {
                            if (player.PicksWeek10 != "")
                            {
                                string[] tempStringPlayer = player.PicksWeek10.Split(',');
                                List<string> tempList = new List<string>(tempStringPlayer);
                                if (tempList.Contains(checkBoxes.Text) && checkBoxes.Text != "")
                                {
                                    if (!CheckTie(checkBoxes.Name))
                                    {
                                        player.WinsWeek10++;
                                        if (dontSubmit == false)
                                        {
                                            player.PlayerTotalWins++;
                                        }
                                    }
                                    else
                                    {
                                        if (CheckPlayerLost(checkBoxes.Name, tempList))
                                        {
                                            player.IsOut = true;
                                        }
                                    }
                                }
                                else
                                {
                                    if (CheckPlayerLost(checkBoxes.Name, tempList))
                                    {
                                        player.IsOut = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if (dontSubmit == false)
                {
                    season6_10.Week10IsFinal = true;
                }
            }
            // Week 11
            else if (comboBoxSelectWeekLive.Text == "Week 11")
            {
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    player.WinsWeek11 = 0;
                }

                tempString = string.Join(",", checkBoxList.ToArray());
                if (!season11_17.Week11IsFinal)
                {
                    season11_17.LosersWeek11 = tempString;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (checkBoxes.Checked == true)
                    {
                        foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                        {
                            if (player.PicksWeek11 != "")
                            {
                                string[] tempStringPlayer = player.PicksWeek11.Split(',');
                                List<string> tempList = new List<string>(tempStringPlayer);
                                if (tempList.Contains(checkBoxes.Text) && checkBoxes.Text != "")
                                {
                                    if (!CheckTie(checkBoxes.Name))
                                    {
                                        player.WinsWeek11++;
                                        if (dontSubmit == false)
                                        {
                                            player.PlayerTotalWins++;
                                        }
                                    }
                                    else
                                    {
                                        if (CheckPlayerLost(checkBoxes.Name, tempList))
                                        {
                                            player.IsOut = true;
                                        }
                                    }
                                }
                                else
                                {
                                    if (CheckPlayerLost(checkBoxes.Name, tempList))
                                    {
                                        player.IsOut = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if (dontSubmit == false)
                {
                    season11_17.Week11IsFinal = true;
                }
            }
            // Week 12
            else if (comboBoxSelectWeekLive.Text == "Week 12")
            {
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    player.WinsWeek12 = 0;
                }

                tempString = string.Join(",", checkBoxList.ToArray());
                if (!season11_17.Week12IsFinal)
                {
                    season11_17.LosersWeek12 = tempString;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (checkBoxes.Checked == true)
                    {
                        foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                        {
                            if (player.PicksWeek12 != "")
                            {
                                string[] tempStringPlayer = player.PicksWeek12.Split(',');
                                List<string> tempList = new List<string>(tempStringPlayer);
                                if (tempList.Contains(checkBoxes.Text) && checkBoxes.Text != "")
                                {
                                    if (!CheckTie(checkBoxes.Name))
                                    {
                                        player.WinsWeek12++;
                                        if (dontSubmit == false)
                                        {
                                            player.PlayerTotalWins++;
                                        }
                                    }
                                    else
                                    {
                                        if (CheckPlayerLost(checkBoxes.Name, tempList))
                                        {
                                            player.IsOut = true;
                                        }
                                    }
                                }
                                else
                                {
                                    if (CheckPlayerLost(checkBoxes.Name, tempList))
                                    {
                                        player.IsOut = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if (dontSubmit == false)
                {
                    season11_17.Week12IsFinal = true;
                }
            }
            // Week 13
            else if (comboBoxSelectWeekLive.Text == "Week 13")
            {
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    player.WinsWeek13 = 0;
                }

                tempString = string.Join(",", checkBoxList.ToArray());
                if (!season11_17.Week13IsFinal)
                {
                    season11_17.LosersWeek13 = tempString;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (checkBoxes.Checked == true)
                    {
                        foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                        {
                            if (player.PicksWeek13 != "")
                            {
                                string[] tempStringPlayer = player.PicksWeek13.Split(',');
                                List<string> tempList = new List<string>(tempStringPlayer);
                                if (tempList.Contains(checkBoxes.Text) && checkBoxes.Text != "")
                                {
                                    if (!CheckTie(checkBoxes.Name))
                                    {
                                        player.WinsWeek13++;
                                        if (dontSubmit == false)
                                        {
                                            player.PlayerTotalWins++;
                                        }
                                    }
                                    else
                                    {
                                        if (CheckPlayerLost(checkBoxes.Name, tempList))
                                        {
                                            player.IsOut = true;
                                        }
                                    }
                                }
                                else
                                {
                                    if (CheckPlayerLost(checkBoxes.Name, tempList))
                                    {
                                        player.IsOut = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if (dontSubmit == false)
                {
                    season11_17.Week13IsFinal = true;
                }
            }
            // Week 14
            else if (comboBoxSelectWeekLive.Text == "Week 14")
            {
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    player.WinsWeek14 = 0;
                }

                tempString = string.Join(",", checkBoxList.ToArray());
                if (!season11_17.Week14IsFinal)
                {
                    season11_17.LosersWeek14 = tempString;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (checkBoxes.Checked == true)
                    {
                        foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                        {
                            if (player.PicksWeek14 != "")
                            {
                                string[] tempStringPlayer = player.PicksWeek14.Split(',');
                                List<string> tempList = new List<string>(tempStringPlayer);
                                if (tempList.Contains(checkBoxes.Text) && checkBoxes.Text != "")
                                {
                                    if (!CheckTie(checkBoxes.Name))
                                    {
                                        player.WinsWeek14++;
                                        if (dontSubmit == false)
                                        {
                                            player.PlayerTotalWins++;
                                        }
                                    }
                                    else
                                    {
                                        if (CheckPlayerLost(checkBoxes.Name, tempList))
                                        {
                                            player.IsOut = true;
                                        }
                                    }
                                }
                                else
                                {
                                    if (CheckPlayerLost(checkBoxes.Name, tempList))
                                    {
                                        player.IsOut = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if (dontSubmit == false)
                {
                    season11_17.Week14IsFinal = true;
                }
            }
            // Week 15
            else if (comboBoxSelectWeekLive.Text == "Week 15")
            {
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    player.WinsWeek15 = 0;
                }

                tempString = string.Join(",", checkBoxList.ToArray());
                if (!season11_17.Week15IsFinal)
                {
                    season11_17.LosersWeek15 = tempString;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (checkBoxes.Checked == true)
                    {
                        foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                        {
                            if (player.PicksWeek15 != "")
                            {
                                string[] tempStringPlayer = player.PicksWeek15.Split(',');
                                List<string> tempList = new List<string>(tempStringPlayer);
                                if (tempList.Contains(checkBoxes.Text) && checkBoxes.Text != "")
                                {
                                    if (!CheckTie(checkBoxes.Name))
                                    {
                                        player.WinsWeek15++;
                                        if (dontSubmit == false)
                                        {
                                            player.PlayerTotalWins++;
                                        }
                                    }
                                    else
                                    {
                                        if (CheckPlayerLost(checkBoxes.Name, tempList))
                                        {
                                            player.IsOut = true;
                                        }
                                    }
                                }
                                else
                                {
                                    if (CheckPlayerLost(checkBoxes.Name, tempList))
                                    {
                                        player.IsOut = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if (dontSubmit == false)
                {
                    season11_17.Week15IsFinal = true;
                }
            }
            // Week 16
            else if (comboBoxSelectWeekLive.Text == "Week 16")
            {
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    player.WinsWeek16 = 0;
                }

                tempString = string.Join(",", checkBoxList.ToArray());
                if (!season11_17.Week16IsFinal)
                {
                    season11_17.LosersWeek16 = tempString;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (checkBoxes.Checked == true)
                    {
                        foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                        {
                            if (player.PicksWeek16 != "")
                            {
                                string[] tempStringPlayer = player.PicksWeek16.Split(',');
                                List<string> tempList = new List<string>(tempStringPlayer);
                                if (tempList.Contains(checkBoxes.Text) && checkBoxes.Text != "")
                                {
                                    if (!CheckTie(checkBoxes.Name))
                                    {
                                        player.WinsWeek16++;
                                        if (dontSubmit == false)
                                        {
                                            player.PlayerTotalWins++;
                                        }
                                    }
                                    else
                                    {
                                        if (CheckPlayerLost(checkBoxes.Name, tempList))
                                        {
                                            player.IsOut = true;
                                        }
                                    }
                                }
                                else
                                {
                                    if (CheckPlayerLost(checkBoxes.Name, tempList))
                                    {
                                        player.IsOut = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if (dontSubmit == false)
                {
                    season11_17.Week16IsFinal = true;
                }
            }
            // Week 17 WEEK 17 IS HIGHEST WINS; CODE IS DIFFERENT FROM OTHERS
            else if (comboBoxSelectWeekLive.Text == "Week 17")
            {
                // reset the player wins week17
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    player.WinsWeek17 = 0;
                }

                tempString = string.Join(",", checkBoxList.ToArray());
                if (!season11_17.Week17IsFinal)
                {
                    season11_17.LosersWeek17 = tempString;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (checkBoxes.Checked == true)
                    {
                        foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                        {
                            if (player.PicksWeek17 != "")
                            {
                                // put the players picks in a string array comma separated
                                string[] tempStringPlayer = player.PicksWeek17.Split(',');
                                // make that array into a list
                                List<string> tempList = new List<string>(tempStringPlayer);
                                // if it does not contain the checked box they get a win. need to check make sure the check box is not a blank one.
                                if (tempList.Contains(checkBoxes.Text) && checkBoxes.Text != "")
                                {
                                    // check to make sure this bracket is not a tie. both players lose if it is.
                                    if (!CheckTie(checkBoxes.Name))
                                    {
                                        player.WinsWeek17++;
                                        if (dontSubmit == false)
                                        {
                                            player.PlayerTotalWins++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                // STILL NEED TO FIGURE THIS OUT. ONLY THE PLAYER WITH THE MOST WINS SHOW UP NOT TOP 3. NEEDS TO BE TOP 3
                // need to compare the players total wins here to see who is highest
                // cycle through the players1 and players2 to compare them
                foreach (PlayersDBDataSet.PlayersRow player1 in playersDBDataSet.Players)
                {
                    // player1 will compare to all of the other players
                    foreach (PlayersDBDataSet.PlayersRow player2 in playersDBDataSet.Players)
                    {
                        // if his week 17 wins are less than any of them he is out
                        if (player1.WinsWeek17 < player2.WinsWeek17 && player1.PlayerPoolName != player2.PlayerPoolName)
                        {
                            player1.IsOut = true;
                        }
                    }
                }
                if (dontSubmit == false)
                {
                    season11_17.Week17IsFinal = true;
                }
            }

            // update the seasons losers so I can save the previously checked boxes.
            this.seasons1_5BindingSource.EndEdit();
            this.seasons6_10BindingSource.EndEdit();
            this.seasons11_17BindingSource.EndEdit();
            this.tableAdapterManager1.UpdateAll(this.seasonsDBDataSet);

            BuildWinnersLosersBox();

            if (upDownWeeksPot.Value != 0)
            {
                CalculatePot();
            }
        }

        private void ResetIsOut()
        {
            foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
            {
                player.IsOut = false;
            }
        }

        // for the checkBoxList to keep track of the teams that lost each week
        private List<string> BuildCheckBoxList(List<string> checkBoxList)
        {
            foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
            {
                if (checkBoxes.Checked == true)
                {
                    checkBoxList.Add(checkBoxes.Text);
                }
            }
            return checkBoxList;
        }
        // maybe when the week changes I can just reset the isOut to false on everyone
        private void SubmitLosers()
        {
            totalStillIn = 0;
            totalOut = 0;
            string tempString = "";
            List<string> checkBoxList = new List<string>();
            BuildCheckBoxList(checkBoxList);

            SeasonsDBDataSet.Seasons1_5Row season1_5 = FindSeason1_5();
            SeasonsDBDataSet.Seasons6_10Row season6_10 = FindSeason6_10();
            SeasonsDBDataSet.Seasons11_17Row season11_17 = FindSeason11_17();

            // need to clear this before the offical submit for the week.
            foreach (PlayersDBDataSet.PlayersRow clearIsOut in playersDBDataSet.Players)
            {
                clearIsOut.IsOut = false;
            }

            GetWhosOutAlready();

            // Week 01
            if (comboBoxSelectWeekLive.Text == "Week 01")
            {
                // this is to save the choices to reference later when MakeFinal()
                // creates a string using the check boxes with comma seperator
                tempString = string.Join(",", checkBoxList.ToArray());

                // make losersWeek01 comma seperated string
                season1_5.LosersWeek01 = tempString;

                // temp list to hold the current losing teams
                string[] tempCheckString = season1_5.LosersWeek01.Split(',');//checkBoxList.ToString().Split(',');

                // cycle through the players
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    // tempstring to store the players picks this week
                    string[] tempStringPlayer = player.PicksWeek01.Split(',');
                    // Make it into a list
                    List<string> tempList = new List<string>(tempStringPlayer);

                    // cycle through the players picks and see if it matches any in the checkbox losers list
                    for (int i = 0; i < tempList.Count; i++)
                    {
                        // if the players pick list matches any in the losers list or if they missed a pick 0
                        if (tempCheckString.Contains(tempList[i].ToString()))
                        {
                            player.WinsWeek01++;
                            player.PlayerTotalWins++;
                        }
                    }
                }
                season1_5.Week01IsFinal = true;

            }

            // Week 02
            else if (comboBoxSelectWeekLive.Text == "Week 02")
            {
                tempString = string.Join(",", checkBoxList.ToArray());
                season1_5.LosersWeek02 = tempString;

                string[] tempCheckString = season1_5.LosersWeek02.Split(',');
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    string[] tempStringPlayer = player.PicksWeek02.Split(',');
                    List<string> tempList = new List<string>(tempStringPlayer);
                    for (int i = 0; i < tempList.Count; i++)
                    {
                        if (tempCheckString.Contains(tempList[i].ToString()) || tempList[i].ToString() == "0")
                        {
                            player.IsOut = true;
                        }
                        else
                        {
                            player.WinsWeek02++;
                            player.PlayerTotalWins++;
                        }
                    }
                }
                season1_5.Week02IsFinal = true;
            }
            // Week 03
            else if (comboBoxSelectWeekLive.Text == "Week 03")
            {
                tempString = string.Join(",", checkBoxList.ToArray());
                season1_5.LosersWeek03 = tempString;

                string[] tempCheckString = season1_5.LosersWeek03.Split(',');
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    string[] tempStringPlayer = player.PicksWeek03.Split(',');
                    List<string> tempList = new List<string>(tempStringPlayer);
                    for (int i = 0; i < tempList.Count; i++)
                    {
                        if (tempCheckString.Contains(tempList[i].ToString()) || tempList[i].ToString() == "0")
                        {
                            player.IsOut = true;
                        }
                        else
                        {
                            player.WinsWeek03++;
                            player.PlayerTotalWins++;
                        }
                    }
                }
                season1_5.Week03IsFinal = true;
            }
            // Week 04
            else if (comboBoxSelectWeekLive.Text == "Week 04")
            {
                tempString = string.Join(",", checkBoxList.ToArray());
                season1_5.LosersWeek04 = tempString;

                string[] tempCheckString = season1_5.LosersWeek04.Split(',');
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    string[] tempStringPlayer = player.PicksWeek04.Split(',');
                    List<string> tempList = new List<string>(tempStringPlayer);
                    for (int i = 0; i < tempList.Count; i++)
                    {
                        if (tempCheckString.Contains(tempList[i].ToString()) || tempList[i].ToString() == "0")
                        {
                            player.IsOut = true;
                        }
                        else
                        {
                            player.WinsWeek04++;
                            player.PlayerTotalWins++;
                        }
                    }
                }
                season1_5.Week04IsFinal = true;
            }
            // Week 05
            else if (comboBoxSelectWeekLive.Text == "Week 05")
            {
                tempString = string.Join(",", checkBoxList.ToArray());
                season1_5.LosersWeek05 = tempString;

                string[] tempCheckString = season1_5.LosersWeek05.Split(',');
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    string[] tempStringPlayer = player.PicksWeek05.Split(',');
                    List<string> tempList = new List<string>(tempStringPlayer);
                    for (int i = 0; i < tempList.Count; i++)
                    {
                        if (tempCheckString.Contains(tempList[i].ToString()) || tempList[i].ToString() == "0")
                        {
                            player.IsOut = true;
                        }
                        else
                        {
                            player.WinsWeek05++;
                            player.PlayerTotalWins++;
                        }
                    }
                }
                season1_5.Week05IsFinal = true;
            }
            // Week 06
            else if (comboBoxSelectWeekLive.Text == "Week 06")
            {
                tempString = string.Join(",", checkBoxList.ToArray());
                season6_10.LosersWeek06 = tempString;

                string[] tempCheckString = season6_10.LosersWeek06.Split(',');
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    string[] tempStringPlayer = player.PicksWeek06.Split(',');
                    List<string> tempList = new List<string>(tempStringPlayer);
                    for (int i = 0; i < tempList.Count; i++)
                    {
                        if (tempCheckString.Contains(tempList[i].ToString()) || tempList[i].ToString() == "0")
                        {
                            player.IsOut = true;
                        }
                        else
                        {
                            player.WinsWeek06++;
                            player.PlayerTotalWins++;
                        }
                    }
                }
                season6_10.Week06IsFinal = true;
            }
            // Week 07
            else if (comboBoxSelectWeekLive.Text == "Week 07")
            {
                tempString = string.Join(",", checkBoxList.ToArray());
                season6_10.LosersWeek07 = tempString;

                string[] tempCheckString = season6_10.LosersWeek07.Split(',');
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    string[] tempStringPlayer = player.PicksWeek07.Split(',');
                    List<string> tempList = new List<string>(tempStringPlayer);
                    for (int i = 0; i < tempList.Count; i++)
                    {
                        if (tempCheckString.Contains(tempList[i].ToString()) || tempList[i].ToString() == "0")
                        {
                            player.IsOut = true;
                        }
                        else
                        {
                            player.WinsWeek07++;
                            player.PlayerTotalWins++;
                        }
                    }
                }
                season6_10.Week07IsFinal = true;
            }
            // Week 08
            else if (comboBoxSelectWeekLive.Text == "Week 08")
            {
                tempString = string.Join(",", checkBoxList.ToArray());
                season6_10.LosersWeek08 = tempString;

                string[] tempCheckString = season6_10.LosersWeek08.Split(',');
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    string[] tempStringPlayer = player.PicksWeek08.Split(',');
                    List<string> tempList = new List<string>(tempStringPlayer);
                    for (int i = 0; i < tempList.Count; i++)
                    {
                        if (tempCheckString.Contains(tempList[i].ToString()) || tempList[i].ToString() == "0")
                        {
                            player.IsOut = true;
                        }
                        else
                        {
                            player.WinsWeek08++;
                            player.PlayerTotalWins++;
                        }
                    }
                }
                season6_10.Week08IsFinal = true;
            }
            // Week 09
            else if (comboBoxSelectWeekLive.Text == "Week 09")
            {
                tempString = string.Join(",", checkBoxList.ToArray());
                season6_10.LosersWeek09 = tempString;

                string[] tempCheckString = season6_10.LosersWeek09.Split(',');
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    string[] tempStringPlayer = player.PicksWeek09.Split(',');
                    List<string> tempList = new List<string>(tempStringPlayer);
                    for (int i = 0; i < tempList.Count; i++)
                    {
                        if (tempCheckString.Contains(tempList[i].ToString()) || tempList[i].ToString() == "0")
                        {
                            player.IsOut = true;
                        }
                        else
                        {
                            player.WinsWeek09++;
                            player.PlayerTotalWins++;
                        }
                    }
                }
                season6_10.Week09IsFinal = true;
            }
            // Week 10
            else if (comboBoxSelectWeekLive.Text == "Week 10")
            {
                tempString = string.Join(",", checkBoxList.ToArray());
                season6_10.LosersWeek10 = tempString;

                string[] tempCheckString = season6_10.LosersWeek10.Split(',');
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    string[] tempStringPlayer = player.PicksWeek10.Split(',');
                    List<string> tempList = new List<string>(tempStringPlayer);
                    for (int i = 0; i < tempList.Count; i++)
                    {
                        if (tempCheckString.Contains(tempList[i].ToString()) || tempList[i].ToString() == "0")
                        {
                            player.IsOut = true;
                        }
                        else
                        {
                            player.WinsWeek10++;
                            player.PlayerTotalWins++;
                        }
                    }
                }
                season6_10.Week10IsFinal = true;
            }
            // Week 11
            else if (comboBoxSelectWeekLive.Text == "Week 11")
            {
                tempString = string.Join(",", checkBoxList.ToArray());
                season11_17.LosersWeek11 = tempString;

                string[] tempCheckString = season11_17.LosersWeek11.Split(',');
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    string[] tempStringPlayer = player.PicksWeek11.Split(',');
                    List<string> tempList = new List<string>(tempStringPlayer);
                    for (int i = 0; i < tempList.Count; i++)
                    {
                        if (tempCheckString.Contains(tempList[i].ToString()) || tempList[i].ToString() == "0")
                        {
                            player.IsOut = true;
                        }
                        else
                        {
                            player.WinsWeek11++;
                            player.PlayerTotalWins++;
                        }
                    }
                }
                season11_17.Week11IsFinal = true;
            }
            // Week 12
            else if (comboBoxSelectWeekLive.Text == "Week 12")
            {
                tempString = string.Join(",", checkBoxList.ToArray());
                season11_17.LosersWeek12 = tempString;

                string[] tempCheckString = season11_17.LosersWeek12.Split(',');
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    string[] tempStringPlayer = player.PicksWeek12.Split(',');
                    List<string> tempList = new List<string>(tempStringPlayer);
                    for (int i = 0; i < tempList.Count; i++)
                    {
                        if (tempCheckString.Contains(tempList[i].ToString()) || tempList[i].ToString() == "0")
                        {
                            player.IsOut = true;
                        }
                        else
                        {
                            player.WinsWeek12++;
                            player.PlayerTotalWins++;
                        }
                    }
                }
                season11_17.Week12IsFinal = true;
            }
            // Week 13
            else if (comboBoxSelectWeekLive.Text == "Week 13")
            {
                tempString = string.Join(",", checkBoxList.ToArray());
                season11_17.LosersWeek13 = tempString;

                string[] tempCheckString = season11_17.LosersWeek13.Split(',');
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    string[] tempStringPlayer = player.PicksWeek13.Split(',');
                    List<string> tempList = new List<string>(tempStringPlayer);
                    for (int i = 0; i < tempList.Count; i++)
                    {
                        if (tempCheckString.Contains(tempList[i].ToString()) || tempList[i].ToString() == "0")
                        {
                            player.IsOut = true;
                        }
                        else
                        {
                            player.WinsWeek13++;
                            player.PlayerTotalWins++;
                        }
                    }
                }
                season11_17.Week13IsFinal = true;
            }
            // Week 14
            else if (comboBoxSelectWeekLive.Text == "Week 14")
            {
                tempString = string.Join(",", checkBoxList.ToArray());
                season11_17.LosersWeek14 = tempString;

                string[] tempCheckString = season11_17.LosersWeek14.Split(',');
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    string[] tempStringPlayer = player.PicksWeek14.Split(',');
                    List<string> tempList = new List<string>(tempStringPlayer);
                    for (int i = 0; i < tempList.Count; i++)
                    {
                        if (tempCheckString.Contains(tempList[i].ToString()) || tempList[i].ToString() == "0")
                        {
                            player.IsOut = true;
                        }
                        else
                        {
                            player.WinsWeek14++;
                            player.PlayerTotalWins++;
                        }
                    }
                }
                season11_17.Week14IsFinal = true;
            }
            // Week 15
            else if (comboBoxSelectWeekLive.Text == "Week 15")
            {
                tempString = string.Join(",", checkBoxList.ToArray());
                season11_17.LosersWeek15 = tempString;

                string[] tempCheckString = season11_17.LosersWeek15.Split(',');
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    string[] tempStringPlayer = player.PicksWeek15.Split(',');
                    List<string> tempList = new List<string>(tempStringPlayer);
                    for (int i = 0; i < tempList.Count; i++)
                    {
                        if (tempCheckString.Contains(tempList[i].ToString()) || tempList[i].ToString() == "0")
                        {
                            player.IsOut = true;
                        }
                        else
                        {
                            player.WinsWeek15++;
                            player.PlayerTotalWins++;
                        }
                    }
                }
                season11_17.Week15IsFinal = true;
            }
            // Week 16
            else if (comboBoxSelectWeekLive.Text == "Week 16")
            {
                tempString = string.Join(",", checkBoxList.ToArray());
                season11_17.LosersWeek16 = tempString;

                string[] tempCheckString = season11_17.LosersWeek16.Split(',');
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    string[] tempStringPlayer = player.PicksWeek16.Split(',');
                    List<string> tempList = new List<string>(tempStringPlayer);
                    for (int i = 0; i < tempList.Count; i++)
                    {
                        if (tempCheckString.Contains(tempList[i].ToString()) || tempList[i].ToString() == "0")
                        {
                            player.IsOut = true;
                        }
                        else
                        {
                            player.WinsWeek16++;
                            player.PlayerTotalWins++;
                        }
                    }
                }
                season11_17.Week16IsFinal = true;
            }
            // Week 17
            else if (comboBoxSelectWeekLive.Text == "Week 17")
            {
                tempString = string.Join(",", checkBoxList.ToArray());
                season11_17.LosersWeek17 = tempString;

                string[] tempCheckString = season11_17.LosersWeek17.Split(',');
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    player.WinsWeek17 = 0;

                    string[] tempStringPlayer = player.PicksWeek17.Split(',');
                    List<string> tempList = new List<string>(tempStringPlayer);
                    for (int i = 0; i < tempList.Count; i++)
                    {
                        if (tempCheckString.Contains(tempList[i].ToString()) || tempList[i].ToString() == "0")
                        {
                            player.IsOut = true;
                        }
                        else
                        {
                            player.WinsWeek17++;
                            player.PlayerTotalWins++;
                        }
                    }
                }
                season11_17.Week17IsFinal = true;
            }
        }

        private void UpdateCheckBoxes()
        {
            if (textBoxSelectedSeason.Text != "")
            {
                if (comboBoxSelectWeekLive.Text == "Week 01")
                {
                    BuildWeek01();
                }
                if (comboBoxSelectWeekLive.Text == "Week 02")
                {
                    BuildWeek02();
                }
                if (comboBoxSelectWeekLive.Text == "Week 03")
                {
                    BuildWeek03();
                }
                if (comboBoxSelectWeekLive.Text == "Week 04")
                {
                    BuildWeek04();
                }
                if (comboBoxSelectWeekLive.Text == "Week 05")
                {
                    BuildWeek05();
                }
                if (comboBoxSelectWeekLive.Text == "Week 06")
                {
                    BuildWeek06();
                }
                if (comboBoxSelectWeekLive.Text == "Week 07")
                {
                    BuildWeek07();
                }
                if (comboBoxSelectWeekLive.Text == "Week 08")
                {
                    BuildWeek08();
                }
                if (comboBoxSelectWeekLive.Text == "Week 09")
                {
                    BuildWeek09();
                }
                if (comboBoxSelectWeekLive.Text == "Week 10")
                {
                    BuildWeek10();
                }
                if (comboBoxSelectWeekLive.Text == "Week 11")
                {
                    BuildWeek11();
                }
                if (comboBoxSelectWeekLive.Text == "Week 12")
                {
                    BuildWeek12();
                }
                if (comboBoxSelectWeekLive.Text == "Week 13")
                {
                    BuildWeek13();
                }
                if (comboBoxSelectWeekLive.Text == "Week 14")
                {
                    BuildWeek14();
                }
                if (comboBoxSelectWeekLive.Text == "Week 15")
                {
                    BuildWeek15();
                }
                if (comboBoxSelectWeekLive.Text == "Week 16")
                {
                    BuildWeek16();
                }
                if (comboBoxSelectWeekLive.Text == "Week 17")
                {
                    BuildWeek17();
                }
            }
        }

        // used to make the player out if they picked the other team
        private bool CheckPlayerLost(string checkBoxName, List<string> playersPicks)
        {
            // ---------------------Teams 1 and 2 ----------------------------------------------
            if (checkBoxName == "loserBracket01_1")
            {
                if (playersPicks.Contains(loserBracket01_2.Text) && loserBracket01_2.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (checkBoxName == "loserBracket01_2")
            {
                if (playersPicks.Contains(loserBracket01_1.Text) && loserBracket01_1.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // ---------------------Teams 3 and 4 ----------------------------------------------
            else if (checkBoxName == "loserBracket02_1")
            {
                if (playersPicks.Contains(loserBracket02_2.Text) && loserBracket02_2.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (checkBoxName == "loserBracket02_2")
            {
                if (playersPicks.Contains(loserBracket02_1.Text) && loserBracket02_1.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // ---------------------Teams 5 and 6 ----------------------------------------------
            else if (checkBoxName == "loserBracket03_1")
            {
                if (playersPicks.Contains(loserBracket03_2.Text) && loserBracket03_2.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (checkBoxName == "loserBracket03_2")
            {
                if (playersPicks.Contains(loserBracket03_1.Text) && loserBracket03_1.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // ---------------------Teams 7 and 8 ----------------------------------------------
            else if (checkBoxName == "loserBracket04_1")
            {
                if (playersPicks.Contains(loserBracket04_2.Text) && loserBracket04_2.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (checkBoxName == "loserBracket04_2")
            {
                if (playersPicks.Contains(loserBracket04_1.Text) && loserBracket04_1.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // ---------------------Teams 9 and 10 ----------------------------------------------
            else if (checkBoxName == "loserBracket05_1")
            {
                if (playersPicks.Contains(loserBracket05_2.Text) && loserBracket05_2.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (checkBoxName == "loserBracket05_2")
            {
                if (playersPicks.Contains(loserBracket05_1.Text) && loserBracket05_1.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // ---------------------Teams 11 and 12 ----------------------------------------------
            else if (checkBoxName == "loserBracket06_1")
            {
                if (playersPicks.Contains(loserBracket06_2.Text) && loserBracket06_2.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (checkBoxName == "loserBracket06_2")
            {
                if (playersPicks.Contains(loserBracket06_1.Text) && loserBracket06_1.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // ---------------------Teams 13 and 14 ----------------------------------------------
            else if (checkBoxName == "loserBracket07_1")
            {
                if (playersPicks.Contains(loserBracket07_2.Text) && loserBracket07_2.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (checkBoxName == "loserBracket07_2")
            {
                if (playersPicks.Contains(loserBracket07_1.Text) && loserBracket07_1.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // ---------------------Teams 15 and 16 ----------------------------------------------
            else if (checkBoxName == "loserBracket08_1")
            {
                if (playersPicks.Contains(loserBracket08_2.Text) && loserBracket08_2.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (checkBoxName == "loserBracket08_2")
            {
                if (playersPicks.Contains(loserBracket08_1.Text) && loserBracket08_1.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // ---------------------Teams 17 and 18 ----------------------------------------------
            else if (checkBoxName == "loserBracket09_1")
            {
                if (playersPicks.Contains(loserBracket09_2.Text) && loserBracket09_2.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (checkBoxName == "loserBracket09_2")
            {
                if (playersPicks.Contains(loserBracket09_1.Text) && loserBracket09_1.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // ---------------------Teams 19 and 20 ----------------------------------------------
            else if (checkBoxName == "loserBracket10_1")
            {
                if (playersPicks.Contains(loserBracket10_2.Text) && loserBracket10_2.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (checkBoxName == "loserBracket10_2")
            {
                if (playersPicks.Contains(loserBracket10_1.Text) && loserBracket10_1.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // ---------------------Teams 21 and 22 ----------------------------------------------
            else if (checkBoxName == "loserBracket11_1")
            {
                if (playersPicks.Contains(loserBracket11_2.Text) && loserBracket11_2.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (checkBoxName == "loserBracket11_2")
            {
                if (playersPicks.Contains(loserBracket11_1.Text) && loserBracket11_1.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // ---------------------Teams 23 and 24 ----------------------------------------------
            else if (checkBoxName == "loserBracket12_1")
            {
                if (playersPicks.Contains(loserBracket12_2.Text) && loserBracket12_2.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (checkBoxName == "loserBracket12_2")
            {
                if (playersPicks.Contains(loserBracket12_1.Text) && loserBracket12_1.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // ---------------------Teams 25 and 26 ----------------------------------------------
            else if (checkBoxName == "loserBracket13_1")
            {
                if (playersPicks.Contains(loserBracket13_2.Text) && loserBracket13_2.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (checkBoxName == "loserBracket13_2")
            {
                if (playersPicks.Contains(loserBracket13_1.Text) && loserBracket13_1.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // ---------------------Teams 27 and 28 ----------------------------------------------
            else if (checkBoxName == "loserBracket14_1")
            {
                if (playersPicks.Contains(loserBracket14_2.Text) && loserBracket14_2.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (checkBoxName == "loserBracket14_2")
            {
                if (playersPicks.Contains(loserBracket14_1.Text) && loserBracket14_1.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // ---------------------Teams 29 and 30 ----------------------------------------------
            else if (checkBoxName == "loserBracket15_1")
            {
                if (playersPicks.Contains(loserBracket15_2.Text) && loserBracket15_2.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (checkBoxName == "loserBracket15_2")
            {
                if (playersPicks.Contains(loserBracket15_1.Text) && loserBracket15_1.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // ---------------------Teams 31 and 32 ----------------------------------------------
            else if (checkBoxName == "loserBracket16_1")
            {
                if (playersPicks.Contains(loserBracket16_2.Text) && loserBracket16_2.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (checkBoxName == "loserBracket16_2")
            {
                if (playersPicks.Contains(loserBracket16_1.Text) && loserBracket16_1.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // ---------------------Teams 33 and 34 ----------------------------------------------
            else if (checkBoxName == "loserBracket17_1")
            {
                if (playersPicks.Contains(loserBracket17_2.Text) && loserBracket17_2.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (checkBoxName == "loserBracket17_2")
            {
                if (playersPicks.Contains(loserBracket17_1.Text) && loserBracket17_1.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // ---------------------Teams 35 and 36 ----------------------------------------------
            else if (checkBoxName == "loserBracket18_1")
            {
                if (playersPicks.Contains(loserBracket18_2.Text) && loserBracket18_2.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (checkBoxName == "loserBracket18_2")
            {
                if (playersPicks.Contains(loserBracket18_1.Text) && loserBracket18_1.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // ---------------------Teams 37 and 38 ----------------------------------------------
            else if (checkBoxName == "loserBracket19_1")
            {
                if (playersPicks.Contains(loserBracket19_2.Text) && loserBracket19_2.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (checkBoxName == "loserBracket19_2")
            {
                if (playersPicks.Contains(loserBracket19_1.Text) && loserBracket19_1.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // ---------------------Teams 39 and 40 ----------------------------------------------
            else if (checkBoxName == "loserBracket20_1")
            {
                if (playersPicks.Contains(loserBracket20_2.Text) && loserBracket20_2.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (checkBoxName == "loserBracket20_2")
            {
                if (playersPicks.Contains(loserBracket20_1.Text) && loserBracket20_1.Text != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        // make sure there is no tie. two check boxes checked in the same bracket
        // this is checked before giving the player a win. if it is a tie both players lose.
        private bool CheckTie(string checkBoxName)
        {
            // default is false
            bool tie = false;

            // if either of these are the checkbox
            if (checkBoxName == "loserBracket01_1" || checkBoxName == "loserBracket01_2")
            {
                // and if they are both checked
                if (loserBracket01_1.Checked == true && loserBracket01_2.Checked == true)
                {
                    // then it is a tie
                    tie = true;
                }
            }
            else if (checkBoxName == "loserBracket02_1" || checkBoxName == "loserBracket02_2")
            {
                if (loserBracket02_1.Checked == true && loserBracket02_2.Checked == true)
                {
                    tie = true;
                }
            }
            else if (checkBoxName == "loserBracket03_1" || checkBoxName == "loserBracket03_2")
            {
                if (loserBracket03_1.Checked == true && loserBracket03_2.Checked == true)
                {
                    tie = true;
                }
            }
            else if (checkBoxName == "loserBracket04_1" || checkBoxName == "loserBracket04_2")
            {
                if (loserBracket04_1.Checked == true && loserBracket04_2.Checked == true)
                {
                    tie = true;
                }
            }
            else if (checkBoxName == "loserBracket05_1" || checkBoxName == "loserBracket05_2")
            {
                if (loserBracket05_1.Checked == true && loserBracket05_2.Checked == true)
                {
                    tie = true;
                }
            }
            else if (checkBoxName == "loserBracket06_1" || checkBoxName == "loserBracket06_2")
            {
                if (loserBracket06_1.Checked == true && loserBracket06_2.Checked == true)
                {
                    tie = true;
                }
            }
            else if (checkBoxName == "loserBracket07_1" || checkBoxName == "loserBracket07_2")
            {
                if (loserBracket07_1.Checked == true && loserBracket07_2.Checked == true)
                {
                    tie = true;
                }
            }
            else if (checkBoxName == "loserBracket08_1" || checkBoxName == "loserBracket08_2")
            {
                if (loserBracket08_1.Checked == true && loserBracket08_2.Checked == true)
                {
                    tie = true;
                }
            }
            else if (checkBoxName == "loserBracket09_1" || checkBoxName == "loserBracket09_2")
            {
                if (loserBracket09_1.Checked == true && loserBracket09_2.Checked == true)
                {
                    tie = true;
                }
            }
            else if (checkBoxName == "loserBracket10_1" || checkBoxName == "loserBracket10_2")
            {
                if (loserBracket10_1.Checked == true && loserBracket10_2.Checked == true)
                {
                    tie = true;
                }
            }
            else if (checkBoxName == "loserBracket11_1" || checkBoxName == "loserBracket11_2")
            {
                if (loserBracket11_1.Checked == true && loserBracket11_2.Checked == true)
                {
                    tie = true;
                }
            }
            else if (checkBoxName == "loserBracket12_1" || checkBoxName == "loserBracket12_2")
            {
                if (loserBracket12_1.Checked == true && loserBracket12_2.Checked == true)
                {
                    tie = true;
                }
            }
            else if (checkBoxName == "loserBracket13_1" || checkBoxName == "loserBracket13_2")
            {
                if (loserBracket13_1.Checked == true && loserBracket13_2.Checked == true)
                {
                    tie = true;
                }
            }
            else if (checkBoxName == "loserBracket14_1" || checkBoxName == "loserBracket14_2")
            {
                if (loserBracket14_1.Checked == true && loserBracket14_2.Checked == true)
                {
                    tie = true;
                }
            }
            else if (checkBoxName == "loserBracket15_1" || checkBoxName == "loserBracket15_2")
            {
                if (loserBracket15_1.Checked == true && loserBracket15_2.Checked == true)
                {
                    tie = true;
                }
            }
            else if (checkBoxName == "loserBracket16_1" || checkBoxName == "loserBracket16_2")
            {
                if (loserBracket16_1.Checked == true && loserBracket16_2.Checked == true)
                {
                    tie = true;
                }
            }
            else if (checkBoxName == "loserBracket17_1" || checkBoxName == "loserBracket17_2")
            {
                if (loserBracket17_1.Checked == true && loserBracket17_2.Checked == true)
                {
                    tie = true;
                }
            }
            else if (checkBoxName == "loserBracket18_1" || checkBoxName == "loserBracket18_2")
            {
                if (loserBracket18_1.Checked == true && loserBracket18_2.Checked == true)
                {
                    tie = true;
                }
            }
            else if (checkBoxName == "loserBracket19_1" || checkBoxName == "loserBracket19_2")
            {
                if (loserBracket19_1.Checked == true && loserBracket19_2.Checked == true)
                {
                    tie = true;
                }
            }
            else if (checkBoxName == "loserBracket20_1" || checkBoxName == "loserBracket20_2")
            {
                if (loserBracket20_1.Checked == true && loserBracket20_2.Checked == true)
                {
                    tie = true;
                }
            }
            else
            {
                tie = false;
            }
            return tie;
        }

        private void BuildCheckBoxList()
        {
            CheckBoxes.Add(loserBracket01_1);
            CheckBoxes.Add(loserBracket01_2);
            CheckBoxes.Add(loserBracket02_1);
            CheckBoxes.Add(loserBracket02_2);
            CheckBoxes.Add(loserBracket03_1);
            CheckBoxes.Add(loserBracket03_2);
            CheckBoxes.Add(loserBracket04_1);
            CheckBoxes.Add(loserBracket04_2);
            CheckBoxes.Add(loserBracket05_1);
            CheckBoxes.Add(loserBracket05_2);
            CheckBoxes.Add(loserBracket06_1);
            CheckBoxes.Add(loserBracket06_2);
            CheckBoxes.Add(loserBracket07_1);
            CheckBoxes.Add(loserBracket07_2);
            CheckBoxes.Add(loserBracket08_1);
            CheckBoxes.Add(loserBracket08_2);
            CheckBoxes.Add(loserBracket09_1);
            CheckBoxes.Add(loserBracket09_2);
            CheckBoxes.Add(loserBracket10_1);
            CheckBoxes.Add(loserBracket10_2);
            CheckBoxes.Add(loserBracket11_1);
            CheckBoxes.Add(loserBracket11_2);
            CheckBoxes.Add(loserBracket12_1);
            CheckBoxes.Add(loserBracket12_2);
            CheckBoxes.Add(loserBracket13_1);
            CheckBoxes.Add(loserBracket13_2);
            CheckBoxes.Add(loserBracket14_1);
            CheckBoxes.Add(loserBracket14_2);
            CheckBoxes.Add(loserBracket15_1);
            CheckBoxes.Add(loserBracket15_2);
            CheckBoxes.Add(loserBracket16_1);
            CheckBoxes.Add(loserBracket16_2);
            CheckBoxes.Add(loserBracket17_1);
            CheckBoxes.Add(loserBracket17_2);
            CheckBoxes.Add(loserBracket18_1);
            CheckBoxes.Add(loserBracket18_2);
            CheckBoxes.Add(loserBracket19_1);
            CheckBoxes.Add(loserBracket19_2);
            CheckBoxes.Add(loserBracket20_1);
            CheckBoxes.Add(loserBracket20_2);
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
                    loserBracket01_1.Text = season.Week01Team01;
                    loserBracket01_2.Text = season.Week01Team02;
                    loserBracket02_1.Text = season.Week01Team03;
                    loserBracket02_2.Text = season.Week01Team04;
                    loserBracket03_1.Text = season.Week01Team05;
                    loserBracket03_2.Text = season.Week01Team06;
                    loserBracket04_1.Text = season.Week01Team07;
                    loserBracket04_2.Text = season.Week01Team08;
                    loserBracket05_1.Text = season.Week01Team09;
                    loserBracket05_2.Text = season.Week01Team10;
                    loserBracket06_1.Text = season.Week01Team11;
                    loserBracket06_2.Text = season.Week01Team12;
                    loserBracket07_1.Text = season.Week01Team13;
                    loserBracket07_2.Text = season.Week01Team14;
                    loserBracket08_1.Text = season.Week01Team15;
                    loserBracket08_2.Text = season.Week01Team16;
                    loserBracket09_1.Text = season.Week01Team17;
                    loserBracket09_2.Text = season.Week01Team18;
                    loserBracket10_1.Text = season.Week01Team19;
                    loserBracket10_2.Text = season.Week01Team20;
                    loserBracket11_1.Text = season.Week01Team21;
                    loserBracket11_2.Text = season.Week01Team22;
                    loserBracket12_1.Text = season.Week01Team23;
                    loserBracket12_2.Text = season.Week01Team24;
                    loserBracket13_1.Text = season.Week01Team25;
                    loserBracket13_2.Text = season.Week01Team26;
                    loserBracket14_1.Text = season.Week01Team27;
                    loserBracket14_2.Text = season.Week01Team28;
                    loserBracket15_1.Text = season.Week01Team29;
                    loserBracket15_2.Text = season.Week01Team30;
                    loserBracket16_1.Text = season.Week01Team31;
                    loserBracket16_2.Text = season.Week01Team32;
                    loserBracket17_1.Text = season.Week01Team33;
                    loserBracket17_2.Text = season.Week01Team34;
                    loserBracket18_1.Text = season.Week01Team35;
                    loserBracket18_2.Text = season.Week01Team36;
                    loserBracket19_1.Text = season.Week01Team37;
                    loserBracket19_2.Text = season.Week01Team38;
                    loserBracket20_1.Text = season.Week01Team39;
                    loserBracket20_2.Text = season.Week01Team40;
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
                    loserBracket01_1.Text = season.Week02Team01;
                    loserBracket01_2.Text = season.Week02Team02;
                    loserBracket02_1.Text = season.Week02Team03;
                    loserBracket02_2.Text = season.Week02Team04;
                    loserBracket03_1.Text = season.Week02Team05;
                    loserBracket03_2.Text = season.Week02Team06;
                    loserBracket04_1.Text = season.Week02Team07;
                    loserBracket04_2.Text = season.Week02Team08;
                    loserBracket05_1.Text = season.Week02Team09;
                    loserBracket05_2.Text = season.Week02Team10;
                    loserBracket06_1.Text = season.Week02Team11;
                    loserBracket06_2.Text = season.Week02Team12;
                    loserBracket07_1.Text = season.Week02Team13;
                    loserBracket07_2.Text = season.Week02Team14;
                    loserBracket08_1.Text = season.Week02Team15;
                    loserBracket08_2.Text = season.Week02Team16;
                    loserBracket09_1.Text = season.Week02Team17;
                    loserBracket09_2.Text = season.Week02Team18;
                    loserBracket10_1.Text = season.Week02Team19;
                    loserBracket10_2.Text = season.Week02Team20;
                    loserBracket11_1.Text = season.Week02Team21;
                    loserBracket11_2.Text = season.Week02Team22;
                    loserBracket12_1.Text = season.Week02Team23;
                    loserBracket12_2.Text = season.Week02Team24;
                    loserBracket13_1.Text = season.Week02Team25;
                    loserBracket13_2.Text = season.Week02Team26;
                    loserBracket14_1.Text = season.Week02Team27;
                    loserBracket14_2.Text = season.Week02Team28;
                    loserBracket15_1.Text = season.Week02Team29;
                    loserBracket15_2.Text = season.Week02Team30;
                    loserBracket16_1.Text = season.Week02Team31;
                    loserBracket16_2.Text = season.Week02Team32;
                    loserBracket17_1.Text = season.Week02Team33;
                    loserBracket17_2.Text = season.Week02Team34;
                    loserBracket18_1.Text = season.Week02Team35;
                    loserBracket18_2.Text = season.Week02Team36;
                    loserBracket19_1.Text = season.Week02Team37;
                    loserBracket19_2.Text = season.Week02Team38;
                    loserBracket20_1.Text = season.Week02Team39;
                    loserBracket20_2.Text = season.Week02Team40;
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
                    loserBracket01_1.Text = season.Week03Team01;
                    loserBracket01_2.Text = season.Week03Team02;
                    loserBracket02_1.Text = season.Week03Team03;
                    loserBracket02_2.Text = season.Week03Team04;
                    loserBracket03_1.Text = season.Week03Team05;
                    loserBracket03_2.Text = season.Week03Team06;
                    loserBracket04_1.Text = season.Week03Team07;
                    loserBracket04_2.Text = season.Week03Team08;
                    loserBracket05_1.Text = season.Week03Team09;
                    loserBracket05_2.Text = season.Week03Team10;
                    loserBracket06_1.Text = season.Week03Team11;
                    loserBracket06_2.Text = season.Week03Team12;
                    loserBracket07_1.Text = season.Week03Team13;
                    loserBracket07_2.Text = season.Week03Team14;
                    loserBracket08_1.Text = season.Week03Team15;
                    loserBracket08_2.Text = season.Week03Team16;
                    loserBracket09_1.Text = season.Week03Team17;
                    loserBracket09_2.Text = season.Week03Team18;
                    loserBracket10_1.Text = season.Week03Team19;
                    loserBracket10_2.Text = season.Week03Team20;
                    loserBracket11_1.Text = season.Week03Team21;
                    loserBracket11_2.Text = season.Week03Team22;
                    loserBracket12_1.Text = season.Week03Team23;
                    loserBracket12_2.Text = season.Week03Team24;
                    loserBracket13_1.Text = season.Week03Team25;
                    loserBracket13_2.Text = season.Week03Team26;
                    loserBracket14_1.Text = season.Week03Team27;
                    loserBracket14_2.Text = season.Week03Team28;
                    loserBracket15_1.Text = season.Week03Team29;
                    loserBracket15_2.Text = season.Week03Team30;
                    loserBracket16_1.Text = season.Week03Team31;
                    loserBracket16_2.Text = season.Week03Team32;
                    loserBracket17_1.Text = season.Week03Team33;
                    loserBracket17_2.Text = season.Week03Team34;
                    loserBracket18_1.Text = season.Week03Team35;
                    loserBracket18_2.Text = season.Week03Team36;
                    loserBracket19_1.Text = season.Week03Team37;
                    loserBracket19_2.Text = season.Week03Team38;
                    loserBracket20_1.Text = season.Week03Team39;
                    loserBracket20_2.Text = season.Week03Team40;
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
                    loserBracket01_1.Text = season.Week04Team01;
                    loserBracket01_2.Text = season.Week04Team02;
                    loserBracket02_1.Text = season.Week04Team03;
                    loserBracket02_2.Text = season.Week04Team04;
                    loserBracket03_1.Text = season.Week04Team05;
                    loserBracket03_2.Text = season.Week04Team06;
                    loserBracket04_1.Text = season.Week04Team07;
                    loserBracket04_2.Text = season.Week04Team08;
                    loserBracket05_1.Text = season.Week04Team09;
                    loserBracket05_2.Text = season.Week04Team10;
                    loserBracket06_1.Text = season.Week04Team11;
                    loserBracket06_2.Text = season.Week04Team12;
                    loserBracket07_1.Text = season.Week04Team13;
                    loserBracket07_2.Text = season.Week04Team14;
                    loserBracket08_1.Text = season.Week04Team15;
                    loserBracket08_2.Text = season.Week04Team16;
                    loserBracket09_1.Text = season.Week04Team17;
                    loserBracket09_2.Text = season.Week04Team18;
                    loserBracket10_1.Text = season.Week04Team19;
                    loserBracket10_2.Text = season.Week04Team20;
                    loserBracket11_1.Text = season.Week04Team21;
                    loserBracket11_2.Text = season.Week04Team22;
                    loserBracket12_1.Text = season.Week04Team23;
                    loserBracket12_2.Text = season.Week04Team24;
                    loserBracket13_1.Text = season.Week04Team25;
                    loserBracket13_2.Text = season.Week04Team26;
                    loserBracket14_1.Text = season.Week04Team27;
                    loserBracket14_2.Text = season.Week04Team28;
                    loserBracket15_1.Text = season.Week04Team29;
                    loserBracket15_2.Text = season.Week04Team30;
                    loserBracket16_1.Text = season.Week04Team31;
                    loserBracket16_2.Text = season.Week04Team32;
                    loserBracket17_1.Text = season.Week04Team33;
                    loserBracket17_2.Text = season.Week04Team34;
                    loserBracket18_1.Text = season.Week04Team35;
                    loserBracket18_2.Text = season.Week04Team36;
                    loserBracket19_1.Text = season.Week04Team37;
                    loserBracket19_2.Text = season.Week04Team38;
                    loserBracket20_1.Text = season.Week04Team39;
                    loserBracket20_2.Text = season.Week04Team40;
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
                    loserBracket01_1.Text = season.Week05Team01;
                    loserBracket01_2.Text = season.Week05Team02;
                    loserBracket02_1.Text = season.Week05Team03;
                    loserBracket02_2.Text = season.Week05Team04;
                    loserBracket03_1.Text = season.Week05Team05;
                    loserBracket03_2.Text = season.Week05Team06;
                    loserBracket04_1.Text = season.Week05Team07;
                    loserBracket04_2.Text = season.Week05Team08;
                    loserBracket05_1.Text = season.Week05Team09;
                    loserBracket05_2.Text = season.Week05Team10;
                    loserBracket06_1.Text = season.Week05Team11;
                    loserBracket06_2.Text = season.Week05Team12;
                    loserBracket07_1.Text = season.Week05Team13;
                    loserBracket07_2.Text = season.Week05Team14;
                    loserBracket08_1.Text = season.Week05Team15;
                    loserBracket08_2.Text = season.Week05Team16;
                    loserBracket09_1.Text = season.Week05Team17;
                    loserBracket09_2.Text = season.Week05Team18;
                    loserBracket10_1.Text = season.Week05Team19;
                    loserBracket10_2.Text = season.Week05Team20;
                    loserBracket11_1.Text = season.Week05Team21;
                    loserBracket11_2.Text = season.Week05Team22;
                    loserBracket12_1.Text = season.Week05Team23;
                    loserBracket12_2.Text = season.Week05Team24;
                    loserBracket13_1.Text = season.Week05Team25;
                    loserBracket13_2.Text = season.Week05Team26;
                    loserBracket14_1.Text = season.Week05Team27;
                    loserBracket14_2.Text = season.Week05Team28;
                    loserBracket15_1.Text = season.Week05Team29;
                    loserBracket15_2.Text = season.Week05Team30;
                    loserBracket16_1.Text = season.Week05Team31;
                    loserBracket16_2.Text = season.Week05Team32;
                    loserBracket17_1.Text = season.Week05Team33;
                    loserBracket17_2.Text = season.Week05Team34;
                    loserBracket18_1.Text = season.Week05Team35;
                    loserBracket18_2.Text = season.Week05Team36;
                    loserBracket19_1.Text = season.Week05Team37;
                    loserBracket19_2.Text = season.Week05Team38;
                    loserBracket20_1.Text = season.Week05Team39;
                    loserBracket20_2.Text = season.Week05Team40;
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
                    loserBracket01_1.Text = season.Week06Team01;
                    loserBracket01_2.Text = season.Week06Team02;
                    loserBracket02_1.Text = season.Week06Team03;
                    loserBracket02_2.Text = season.Week06Team04;
                    loserBracket03_1.Text = season.Week06Team05;
                    loserBracket03_2.Text = season.Week06Team06;
                    loserBracket04_1.Text = season.Week06Team07;
                    loserBracket04_2.Text = season.Week06Team08;
                    loserBracket05_1.Text = season.Week06Team09;
                    loserBracket05_2.Text = season.Week06Team10;
                    loserBracket06_1.Text = season.Week06Team11;
                    loserBracket06_2.Text = season.Week06Team12;
                    loserBracket07_1.Text = season.Week06Team13;
                    loserBracket07_2.Text = season.Week06Team14;
                    loserBracket08_1.Text = season.Week06Team15;
                    loserBracket08_2.Text = season.Week06Team16;
                    loserBracket09_1.Text = season.Week06Team17;
                    loserBracket09_2.Text = season.Week06Team18;
                    loserBracket10_1.Text = season.Week06Team19;
                    loserBracket10_2.Text = season.Week06Team20;
                    loserBracket11_1.Text = season.Week06Team21;
                    loserBracket11_2.Text = season.Week06Team22;
                    loserBracket12_1.Text = season.Week06Team23;
                    loserBracket12_2.Text = season.Week06Team24;
                    loserBracket13_1.Text = season.Week06Team25;
                    loserBracket13_2.Text = season.Week06Team26;
                    loserBracket14_1.Text = season.Week06Team27;
                    loserBracket14_2.Text = season.Week06Team28;
                    loserBracket15_1.Text = season.Week06Team29;
                    loserBracket15_2.Text = season.Week06Team30;
                    loserBracket16_1.Text = season.Week06Team31;
                    loserBracket16_2.Text = season.Week06Team32;
                    loserBracket17_1.Text = season.Week06Team33;
                    loserBracket17_2.Text = season.Week06Team34;
                    loserBracket18_1.Text = season.Week06Team35;
                    loserBracket18_2.Text = season.Week06Team36;
                    loserBracket19_1.Text = season.Week06Team37;
                    loserBracket19_2.Text = season.Week06Team38;
                    loserBracket20_1.Text = season.Week06Team39;
                    loserBracket20_2.Text = season.Week06Team40;
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
                    loserBracket01_1.Text = season.Week07Team01;
                    loserBracket01_2.Text = season.Week07Team02;
                    loserBracket02_1.Text = season.Week07Team03;
                    loserBracket02_2.Text = season.Week07Team04;
                    loserBracket03_1.Text = season.Week07Team05;
                    loserBracket03_2.Text = season.Week07Team06;
                    loserBracket04_1.Text = season.Week07Team07;
                    loserBracket04_2.Text = season.Week07Team08;
                    loserBracket05_1.Text = season.Week07Team09;
                    loserBracket05_2.Text = season.Week07Team10;
                    loserBracket06_1.Text = season.Week07Team11;
                    loserBracket06_2.Text = season.Week07Team12;
                    loserBracket07_1.Text = season.Week07Team13;
                    loserBracket07_2.Text = season.Week07Team14;
                    loserBracket08_1.Text = season.Week07Team15;
                    loserBracket08_2.Text = season.Week07Team16;
                    loserBracket09_1.Text = season.Week07Team17;
                    loserBracket09_2.Text = season.Week07Team18;
                    loserBracket10_1.Text = season.Week07Team19;
                    loserBracket10_2.Text = season.Week07Team20;
                    loserBracket11_1.Text = season.Week07Team21;
                    loserBracket11_2.Text = season.Week07Team22;
                    loserBracket12_1.Text = season.Week07Team23;
                    loserBracket12_2.Text = season.Week07Team24;
                    loserBracket13_1.Text = season.Week07Team25;
                    loserBracket13_2.Text = season.Week07Team26;
                    loserBracket14_1.Text = season.Week07Team27;
                    loserBracket14_2.Text = season.Week07Team28;
                    loserBracket15_1.Text = season.Week07Team29;
                    loserBracket15_2.Text = season.Week07Team30;
                    loserBracket16_1.Text = season.Week07Team31;
                    loserBracket16_2.Text = season.Week07Team32;
                    loserBracket17_1.Text = season.Week07Team33;
                    loserBracket17_2.Text = season.Week07Team34;
                    loserBracket18_1.Text = season.Week07Team35;
                    loserBracket18_2.Text = season.Week07Team36;
                    loserBracket19_1.Text = season.Week07Team37;
                    loserBracket19_2.Text = season.Week07Team38;
                    loserBracket20_1.Text = season.Week07Team39;
                    loserBracket20_2.Text = season.Week07Team40;
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
                    loserBracket01_1.Text = season.Week08Team01;
                    loserBracket01_2.Text = season.Week08Team02;
                    loserBracket02_1.Text = season.Week08Team03;
                    loserBracket02_2.Text = season.Week08Team04;
                    loserBracket03_1.Text = season.Week08Team05;
                    loserBracket03_2.Text = season.Week08Team06;
                    loserBracket04_1.Text = season.Week08Team07;
                    loserBracket04_2.Text = season.Week08Team08;
                    loserBracket05_1.Text = season.Week08Team09;
                    loserBracket05_2.Text = season.Week08Team10;
                    loserBracket06_1.Text = season.Week08Team11;
                    loserBracket06_2.Text = season.Week08Team12;
                    loserBracket07_1.Text = season.Week08Team13;
                    loserBracket07_2.Text = season.Week08Team14;
                    loserBracket08_1.Text = season.Week08Team15;
                    loserBracket08_2.Text = season.Week08Team16;
                    loserBracket09_1.Text = season.Week08Team17;
                    loserBracket09_2.Text = season.Week08Team18;
                    loserBracket10_1.Text = season.Week08Team19;
                    loserBracket10_2.Text = season.Week08Team20;
                    loserBracket11_1.Text = season.Week08Team21;
                    loserBracket11_2.Text = season.Week08Team22;
                    loserBracket12_1.Text = season.Week08Team23;
                    loserBracket12_2.Text = season.Week08Team24;
                    loserBracket13_1.Text = season.Week08Team25;
                    loserBracket13_2.Text = season.Week08Team26;
                    loserBracket14_1.Text = season.Week08Team27;
                    loserBracket14_2.Text = season.Week08Team28;
                    loserBracket15_1.Text = season.Week08Team29;
                    loserBracket15_2.Text = season.Week08Team30;
                    loserBracket16_1.Text = season.Week08Team31;
                    loserBracket16_2.Text = season.Week08Team32;
                    loserBracket17_1.Text = season.Week08Team33;
                    loserBracket17_2.Text = season.Week08Team34;
                    loserBracket18_1.Text = season.Week08Team35;
                    loserBracket18_2.Text = season.Week08Team36;
                    loserBracket19_1.Text = season.Week08Team37;
                    loserBracket19_2.Text = season.Week08Team38;
                    loserBracket20_1.Text = season.Week08Team39;
                    loserBracket20_2.Text = season.Week08Team40;
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
                    loserBracket01_1.Text = season.Week09Team01;
                    loserBracket01_2.Text = season.Week09Team02;
                    loserBracket02_1.Text = season.Week09Team03;
                    loserBracket02_2.Text = season.Week09Team04;
                    loserBracket03_1.Text = season.Week09Team05;
                    loserBracket03_2.Text = season.Week09Team06;
                    loserBracket04_1.Text = season.Week09Team07;
                    loserBracket04_2.Text = season.Week09Team08;
                    loserBracket05_1.Text = season.Week09Team09;
                    loserBracket05_2.Text = season.Week09Team10;
                    loserBracket06_1.Text = season.Week09Team11;
                    loserBracket06_2.Text = season.Week09Team12;
                    loserBracket07_1.Text = season.Week09Team13;
                    loserBracket07_2.Text = season.Week09Team14;
                    loserBracket08_1.Text = season.Week09Team15;
                    loserBracket08_2.Text = season.Week09Team16;
                    loserBracket09_1.Text = season.Week09Team17;
                    loserBracket09_2.Text = season.Week09Team18;
                    loserBracket10_1.Text = season.Week09Team19;
                    loserBracket10_2.Text = season.Week09Team20;
                    loserBracket11_1.Text = season.Week09Team21;
                    loserBracket11_2.Text = season.Week09Team22;
                    loserBracket12_1.Text = season.Week09Team23;
                    loserBracket12_2.Text = season.Week09Team24;
                    loserBracket13_1.Text = season.Week09Team25;
                    loserBracket13_2.Text = season.Week09Team26;
                    loserBracket14_1.Text = season.Week09Team27;
                    loserBracket14_2.Text = season.Week09Team28;
                    loserBracket15_1.Text = season.Week09Team29;
                    loserBracket15_2.Text = season.Week09Team30;
                    loserBracket16_1.Text = season.Week09Team31;
                    loserBracket16_2.Text = season.Week09Team32;
                    loserBracket17_1.Text = season.Week09Team33;
                    loserBracket17_2.Text = season.Week09Team34;
                    loserBracket18_1.Text = season.Week09Team35;
                    loserBracket18_2.Text = season.Week09Team36;
                    loserBracket19_1.Text = season.Week09Team37;
                    loserBracket19_2.Text = season.Week09Team38;
                    loserBracket20_1.Text = season.Week09Team39;
                    loserBracket20_2.Text = season.Week09Team40;
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
                    loserBracket01_1.Text = season.Week10Team01;
                    loserBracket01_2.Text = season.Week10Team02;
                    loserBracket02_1.Text = season.Week10Team03;
                    loserBracket02_2.Text = season.Week10Team04;
                    loserBracket03_1.Text = season.Week10Team05;
                    loserBracket03_2.Text = season.Week10Team06;
                    loserBracket04_1.Text = season.Week10Team07;
                    loserBracket04_2.Text = season.Week10Team08;
                    loserBracket05_1.Text = season.Week10Team09;
                    loserBracket05_2.Text = season.Week10Team10;
                    loserBracket06_1.Text = season.Week10Team11;
                    loserBracket06_2.Text = season.Week10Team12;
                    loserBracket07_1.Text = season.Week10Team13;
                    loserBracket07_2.Text = season.Week10Team14;
                    loserBracket08_1.Text = season.Week10Team15;
                    loserBracket08_2.Text = season.Week10Team16;
                    loserBracket09_1.Text = season.Week10Team17;
                    loserBracket09_2.Text = season.Week10Team18;
                    loserBracket10_1.Text = season.Week10Team19;
                    loserBracket10_2.Text = season.Week10Team20;
                    loserBracket11_1.Text = season.Week10Team21;
                    loserBracket11_2.Text = season.Week10Team22;
                    loserBracket12_1.Text = season.Week10Team23;
                    loserBracket12_2.Text = season.Week10Team24;
                    loserBracket13_1.Text = season.Week10Team25;
                    loserBracket13_2.Text = season.Week10Team26;
                    loserBracket14_1.Text = season.Week10Team27;
                    loserBracket14_2.Text = season.Week10Team28;
                    loserBracket15_1.Text = season.Week10Team29;
                    loserBracket15_2.Text = season.Week10Team30;
                    loserBracket16_1.Text = season.Week10Team31;
                    loserBracket16_2.Text = season.Week10Team32;
                    loserBracket17_1.Text = season.Week10Team33;
                    loserBracket17_2.Text = season.Week10Team34;
                    loserBracket18_1.Text = season.Week10Team35;
                    loserBracket18_2.Text = season.Week10Team36;
                    loserBracket19_1.Text = season.Week10Team37;
                    loserBracket19_2.Text = season.Week10Team38;
                    loserBracket20_1.Text = season.Week10Team39;
                    loserBracket20_2.Text = season.Week10Team40;
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
                    loserBracket01_1.Text = season.Week11Team01;
                    loserBracket01_2.Text = season.Week11Team02;
                    loserBracket02_1.Text = season.Week11Team03;
                    loserBracket02_2.Text = season.Week11Team04;
                    loserBracket03_1.Text = season.Week11Team05;
                    loserBracket03_2.Text = season.Week11Team06;
                    loserBracket04_1.Text = season.Week11Team07;
                    loserBracket04_2.Text = season.Week11Team08;
                    loserBracket05_1.Text = season.Week11Team09;
                    loserBracket05_2.Text = season.Week11Team10;
                    loserBracket06_1.Text = season.Week11Team11;
                    loserBracket06_2.Text = season.Week11Team12;
                    loserBracket07_1.Text = season.Week11Team13;
                    loserBracket07_2.Text = season.Week11Team14;
                    loserBracket08_1.Text = season.Week11Team15;
                    loserBracket08_2.Text = season.Week11Team16;
                    loserBracket09_1.Text = season.Week11Team17;
                    loserBracket09_2.Text = season.Week11Team18;
                    loserBracket10_1.Text = season.Week11Team19;
                    loserBracket10_2.Text = season.Week11Team20;
                    loserBracket11_1.Text = season.Week11Team21;
                    loserBracket11_2.Text = season.Week11Team22;
                    loserBracket12_1.Text = season.Week11Team23;
                    loserBracket12_2.Text = season.Week11Team24;
                    loserBracket13_1.Text = season.Week11Team25;
                    loserBracket13_2.Text = season.Week11Team26;
                    loserBracket14_1.Text = season.Week11Team27;
                    loserBracket14_2.Text = season.Week11Team28;
                    loserBracket15_1.Text = season.Week11Team29;
                    loserBracket15_2.Text = season.Week11Team30;
                    loserBracket16_1.Text = season.Week11Team31;
                    loserBracket16_2.Text = season.Week11Team32;
                    loserBracket17_1.Text = season.Week11Team33;
                    loserBracket17_2.Text = season.Week11Team34;
                    loserBracket18_1.Text = season.Week11Team35;
                    loserBracket18_2.Text = season.Week11Team36;
                    loserBracket19_1.Text = season.Week11Team37;
                    loserBracket19_2.Text = season.Week11Team38;
                    loserBracket20_1.Text = season.Week11Team39;
                    loserBracket20_2.Text = season.Week11Team40;
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
                    loserBracket01_1.Text = season.Week12Team01;
                    loserBracket01_2.Text = season.Week12Team02;
                    loserBracket02_1.Text = season.Week12Team03;
                    loserBracket02_2.Text = season.Week12Team04;
                    loserBracket03_1.Text = season.Week12Team05;
                    loserBracket03_2.Text = season.Week12Team06;
                    loserBracket04_1.Text = season.Week12Team07;
                    loserBracket04_2.Text = season.Week12Team08;
                    loserBracket05_1.Text = season.Week12Team09;
                    loserBracket05_2.Text = season.Week12Team10;
                    loserBracket06_1.Text = season.Week12Team11;
                    loserBracket06_2.Text = season.Week12Team12;
                    loserBracket07_1.Text = season.Week12Team13;
                    loserBracket07_2.Text = season.Week12Team14;
                    loserBracket08_1.Text = season.Week12Team15;
                    loserBracket08_2.Text = season.Week12Team16;
                    loserBracket09_1.Text = season.Week12Team17;
                    loserBracket09_2.Text = season.Week12Team18;
                    loserBracket10_1.Text = season.Week12Team19;
                    loserBracket10_2.Text = season.Week12Team20;
                    loserBracket11_1.Text = season.Week12Team21;
                    loserBracket11_2.Text = season.Week12Team22;
                    loserBracket12_1.Text = season.Week12Team23;
                    loserBracket12_2.Text = season.Week12Team24;
                    loserBracket13_1.Text = season.Week12Team25;
                    loserBracket13_2.Text = season.Week12Team26;
                    loserBracket14_1.Text = season.Week12Team27;
                    loserBracket14_2.Text = season.Week12Team28;
                    loserBracket15_1.Text = season.Week12Team29;
                    loserBracket15_2.Text = season.Week12Team30;
                    loserBracket16_1.Text = season.Week12Team31;
                    loserBracket16_2.Text = season.Week12Team32;
                    loserBracket17_1.Text = season.Week12Team33;
                    loserBracket17_2.Text = season.Week12Team34;
                    loserBracket18_1.Text = season.Week12Team35;
                    loserBracket18_2.Text = season.Week12Team36;
                    loserBracket19_1.Text = season.Week12Team37;
                    loserBracket19_2.Text = season.Week12Team38;
                    loserBracket20_1.Text = season.Week12Team39;
                    loserBracket20_2.Text = season.Week12Team40;
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
                    loserBracket01_1.Text = season.Week13Team01;
                    loserBracket01_2.Text = season.Week13Team02;
                    loserBracket02_1.Text = season.Week13Team03;
                    loserBracket02_2.Text = season.Week13Team04;
                    loserBracket03_1.Text = season.Week13Team05;
                    loserBracket03_2.Text = season.Week13Team06;
                    loserBracket04_1.Text = season.Week13Team07;
                    loserBracket04_2.Text = season.Week13Team08;
                    loserBracket05_1.Text = season.Week13Team09;
                    loserBracket05_2.Text = season.Week13Team10;
                    loserBracket06_1.Text = season.Week13Team11;
                    loserBracket06_2.Text = season.Week13Team12;
                    loserBracket07_1.Text = season.Week13Team13;
                    loserBracket07_2.Text = season.Week13Team14;
                    loserBracket08_1.Text = season.Week13Team15;
                    loserBracket08_2.Text = season.Week13Team16;
                    loserBracket09_1.Text = season.Week13Team17;
                    loserBracket09_2.Text = season.Week13Team18;
                    loserBracket10_1.Text = season.Week13Team19;
                    loserBracket10_2.Text = season.Week13Team20;
                    loserBracket11_1.Text = season.Week13Team21;
                    loserBracket11_2.Text = season.Week13Team22;
                    loserBracket12_1.Text = season.Week13Team23;
                    loserBracket12_2.Text = season.Week13Team24;
                    loserBracket13_1.Text = season.Week13Team25;
                    loserBracket13_2.Text = season.Week13Team26;
                    loserBracket14_1.Text = season.Week13Team27;
                    loserBracket14_2.Text = season.Week13Team28;
                    loserBracket15_1.Text = season.Week13Team29;
                    loserBracket15_2.Text = season.Week13Team30;
                    loserBracket16_1.Text = season.Week13Team31;
                    loserBracket16_2.Text = season.Week13Team32;
                    loserBracket17_1.Text = season.Week13Team33;
                    loserBracket17_2.Text = season.Week13Team34;
                    loserBracket18_1.Text = season.Week13Team35;
                    loserBracket18_2.Text = season.Week13Team36;
                    loserBracket19_1.Text = season.Week13Team37;
                    loserBracket19_2.Text = season.Week13Team38;
                    loserBracket20_1.Text = season.Week13Team39;
                    loserBracket20_2.Text = season.Week13Team40;
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
                    loserBracket01_1.Text = season.Week14Team01;
                    loserBracket01_2.Text = season.Week14Team02;
                    loserBracket02_1.Text = season.Week14Team03;
                    loserBracket02_2.Text = season.Week14Team04;
                    loserBracket03_1.Text = season.Week14Team05;
                    loserBracket03_2.Text = season.Week14Team06;
                    loserBracket04_1.Text = season.Week14Team07;
                    loserBracket04_2.Text = season.Week14Team08;
                    loserBracket05_1.Text = season.Week14Team09;
                    loserBracket05_2.Text = season.Week14Team10;
                    loserBracket06_1.Text = season.Week14Team11;
                    loserBracket06_2.Text = season.Week14Team12;
                    loserBracket07_1.Text = season.Week14Team13;
                    loserBracket07_2.Text = season.Week14Team14;
                    loserBracket08_1.Text = season.Week14Team15;
                    loserBracket08_2.Text = season.Week14Team16;
                    loserBracket09_1.Text = season.Week14Team17;
                    loserBracket09_2.Text = season.Week14Team18;
                    loserBracket10_1.Text = season.Week14Team19;
                    loserBracket10_2.Text = season.Week14Team20;
                    loserBracket11_1.Text = season.Week14Team21;
                    loserBracket11_2.Text = season.Week14Team22;
                    loserBracket12_1.Text = season.Week14Team23;
                    loserBracket12_2.Text = season.Week14Team24;
                    loserBracket13_1.Text = season.Week14Team25;
                    loserBracket13_2.Text = season.Week14Team26;
                    loserBracket14_1.Text = season.Week14Team27;
                    loserBracket14_2.Text = season.Week14Team28;
                    loserBracket15_1.Text = season.Week14Team29;
                    loserBracket15_2.Text = season.Week14Team30;
                    loserBracket16_1.Text = season.Week14Team31;
                    loserBracket16_2.Text = season.Week14Team32;
                    loserBracket17_1.Text = season.Week14Team33;
                    loserBracket17_2.Text = season.Week14Team34;
                    loserBracket18_1.Text = season.Week14Team35;
                    loserBracket18_2.Text = season.Week14Team36;
                    loserBracket19_1.Text = season.Week14Team37;
                    loserBracket19_2.Text = season.Week14Team38;
                    loserBracket20_1.Text = season.Week14Team39;
                    loserBracket20_2.Text = season.Week14Team40;
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
                    loserBracket01_1.Text = season.Week15Team01;
                    loserBracket01_2.Text = season.Week15Team02;
                    loserBracket02_1.Text = season.Week15Team03;
                    loserBracket02_2.Text = season.Week15Team04;
                    loserBracket03_1.Text = season.Week15Team05;
                    loserBracket03_2.Text = season.Week15Team06;
                    loserBracket04_1.Text = season.Week15Team07;
                    loserBracket04_2.Text = season.Week15Team08;
                    loserBracket05_1.Text = season.Week15Team09;
                    loserBracket05_2.Text = season.Week15Team10;
                    loserBracket06_1.Text = season.Week15Team11;
                    loserBracket06_2.Text = season.Week15Team12;
                    loserBracket07_1.Text = season.Week15Team13;
                    loserBracket07_2.Text = season.Week15Team14;
                    loserBracket08_1.Text = season.Week15Team15;
                    loserBracket08_2.Text = season.Week15Team16;
                    loserBracket09_1.Text = season.Week15Team17;
                    loserBracket09_2.Text = season.Week15Team18;
                    loserBracket10_1.Text = season.Week15Team19;
                    loserBracket10_2.Text = season.Week15Team20;
                    loserBracket11_1.Text = season.Week15Team21;
                    loserBracket11_2.Text = season.Week15Team22;
                    loserBracket12_1.Text = season.Week15Team23;
                    loserBracket12_2.Text = season.Week15Team24;
                    loserBracket13_1.Text = season.Week15Team25;
                    loserBracket13_2.Text = season.Week15Team26;
                    loserBracket14_1.Text = season.Week15Team27;
                    loserBracket14_2.Text = season.Week15Team28;
                    loserBracket15_1.Text = season.Week15Team29;
                    loserBracket15_2.Text = season.Week15Team30;
                    loserBracket16_1.Text = season.Week15Team31;
                    loserBracket16_2.Text = season.Week15Team32;
                    loserBracket17_1.Text = season.Week15Team33;
                    loserBracket17_2.Text = season.Week15Team34;
                    loserBracket18_1.Text = season.Week15Team35;
                    loserBracket18_2.Text = season.Week15Team36;
                    loserBracket19_1.Text = season.Week15Team37;
                    loserBracket19_2.Text = season.Week15Team38;
                    loserBracket20_1.Text = season.Week15Team39;
                    loserBracket20_2.Text = season.Week15Team40;
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
                    loserBracket01_1.Text = season.Week16Team01;
                    loserBracket01_2.Text = season.Week16Team02;
                    loserBracket02_1.Text = season.Week16Team03;
                    loserBracket02_2.Text = season.Week16Team04;
                    loserBracket03_1.Text = season.Week16Team05;
                    loserBracket03_2.Text = season.Week16Team06;
                    loserBracket04_1.Text = season.Week16Team07;
                    loserBracket04_2.Text = season.Week16Team08;
                    loserBracket05_1.Text = season.Week16Team09;
                    loserBracket05_2.Text = season.Week16Team10;
                    loserBracket06_1.Text = season.Week16Team11;
                    loserBracket06_2.Text = season.Week16Team12;
                    loserBracket07_1.Text = season.Week16Team13;
                    loserBracket07_2.Text = season.Week16Team14;
                    loserBracket08_1.Text = season.Week16Team15;
                    loserBracket08_2.Text = season.Week16Team16;
                    loserBracket09_1.Text = season.Week16Team17;
                    loserBracket09_2.Text = season.Week16Team18;
                    loserBracket10_1.Text = season.Week16Team19;
                    loserBracket10_2.Text = season.Week16Team20;
                    loserBracket11_1.Text = season.Week16Team21;
                    loserBracket11_2.Text = season.Week16Team22;
                    loserBracket12_1.Text = season.Week16Team23;
                    loserBracket12_2.Text = season.Week16Team24;
                    loserBracket13_1.Text = season.Week16Team25;
                    loserBracket13_2.Text = season.Week16Team26;
                    loserBracket14_1.Text = season.Week16Team27;
                    loserBracket14_2.Text = season.Week16Team28;
                    loserBracket15_1.Text = season.Week16Team29;
                    loserBracket15_2.Text = season.Week16Team30;
                    loserBracket16_1.Text = season.Week16Team31;
                    loserBracket16_2.Text = season.Week16Team32;
                    loserBracket17_1.Text = season.Week16Team33;
                    loserBracket17_2.Text = season.Week16Team34;
                    loserBracket18_1.Text = season.Week16Team35;
                    loserBracket18_2.Text = season.Week16Team36;
                    loserBracket19_1.Text = season.Week16Team37;
                    loserBracket19_2.Text = season.Week16Team38;
                    loserBracket20_1.Text = season.Week16Team39;
                    loserBracket20_2.Text = season.Week16Team40;
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
                    loserBracket01_1.Text = season.Week17Team01;
                    loserBracket01_2.Text = season.Week17Team02;
                    loserBracket02_1.Text = season.Week17Team03;
                    loserBracket02_2.Text = season.Week17Team04;
                    loserBracket03_1.Text = season.Week17Team05;
                    loserBracket03_2.Text = season.Week17Team06;
                    loserBracket04_1.Text = season.Week17Team07;
                    loserBracket04_2.Text = season.Week17Team08;
                    loserBracket05_1.Text = season.Week17Team09;
                    loserBracket05_2.Text = season.Week17Team10;
                    loserBracket06_1.Text = season.Week17Team11;
                    loserBracket06_2.Text = season.Week17Team12;
                    loserBracket07_1.Text = season.Week17Team13;
                    loserBracket07_2.Text = season.Week17Team14;
                    loserBracket08_1.Text = season.Week17Team15;
                    loserBracket08_2.Text = season.Week17Team16;
                    loserBracket09_1.Text = season.Week17Team17;
                    loserBracket09_2.Text = season.Week17Team18;
                    loserBracket10_1.Text = season.Week17Team19;
                    loserBracket10_2.Text = season.Week17Team20;
                    loserBracket11_1.Text = season.Week17Team21;
                    loserBracket11_2.Text = season.Week17Team22;
                    loserBracket12_1.Text = season.Week17Team23;
                    loserBracket12_2.Text = season.Week17Team24;
                    loserBracket13_1.Text = season.Week17Team25;
                    loserBracket13_2.Text = season.Week17Team26;
                    loserBracket14_1.Text = season.Week17Team27;
                    loserBracket14_2.Text = season.Week17Team28;
                    loserBracket15_1.Text = season.Week17Team29;
                    loserBracket15_2.Text = season.Week17Team30;
                    loserBracket16_1.Text = season.Week17Team31;
                    loserBracket16_2.Text = season.Week17Team32;
                    loserBracket17_1.Text = season.Week17Team33;
                    loserBracket17_2.Text = season.Week17Team34;
                    loserBracket18_1.Text = season.Week17Team35;
                    loserBracket18_2.Text = season.Week17Team36;
                    loserBracket19_1.Text = season.Week17Team37;
                    loserBracket19_2.Text = season.Week17Team38;
                    loserBracket20_1.Text = season.Week17Team39;
                    loserBracket20_2.Text = season.Week17Team40;
                }
            }
        }

        // code here for knowing how much to pay out
        private void CalculatePot()
        {
            progressiveTotal = 0;
            weeklyPotTotal = 0;
            interest = 0;
            totalPayOut = 0;
            playerCount = 0;
            grossPot = 0;
            rollOverPot = 0;

            // get the rollover pot if any
            foreach (AccountingDataSet.AccountingRow accounting in accountingDataSet.Accounting)
            {
                if (accounting.SeasonName == textBoxSelectedSeason.Text)
                {
                    rollOverPot = accounting.RollOverPot;
                }
            }

            // go through each player
            foreach (PlayersDBDataSet.PlayersRow players in playersDBDataSet.Players)
            {
                // if they are active the add to the total weekly and progressive pots
                if (players.IsActive)
                {
                    progressiveTotal++;
                    weeklyPotTotal += 6;
                }
            }

            // calculate the interest and get actual pot total
            weeklyPotTotal -= progressiveTotal;
            weeklyPotTotal += rollOverPot;

            grossPot = weeklyPotTotal;

            interest = weeklyPotTotal * 0.05m;
            interest = Math.Ceiling(interest);

            weeklyPotTotal -= (int)interest;


            playerCount = listViewStillInLive.Items.Count;

            // divide the ints together
            totalPayOut = (double)weeklyPotTotal / (double)playerCount;

            if (playerCount != 0)
            {
                // round the number down
                totalPayOut = Math.Floor(totalPayOut);

                // find out how much was removed from rounding and add that to the interest
                if (totalPayOut * playerCount != weeklyPotTotal)
                {
                    double totalWeeklyWinnings = totalPayOut * playerCount;
                    double remainder = weeklyPotTotal - totalWeeklyWinnings;
                    interest += (decimal)remainder;
                }
            }
            else
            {
                totalPayOut = 0;
            }

            // post the total to the label
            labelPossibleWinningsLive.Text = totalPayOut.ToString();
            labelWeeksInterest.Text = interest.ToString();
            labelWeekProgressive.Text = progressiveTotal.ToString();
            labelGrossPot.Text = grossPot.ToString();
            upDownWeeksPot.Value = weeklyPotTotal;
        }

        private void CreditWinners()
        {
            // pay the interest and progressive to accounting
            foreach (AccountingDataSet.AccountingRow accounting in accountingDataSet.Accounting)
            {
                if (accounting.SeasonName == PublicVariables.GetDefaultSeason)
                {
                    accounting.TotalInterest += interest;
                    accounting.TotalFunds -= interest;
                    accounting.RollOverPot = 0;
                }
            }

            // make an interest transaction
            // create a new row
            TransactionsDBDataSet.TransactionsRow newTransaction = transactionsDBDataSet.Transactions.NewTransactionsRow();

            // add the data to that row
            newTransaction.PlayerName = "House";
            newTransaction.SeasonName = textBoxSelectedSeason.Text;
            newTransaction.Type = "Interest";
            newTransaction.Method = "Auto Interest";
            newTransaction.Interest = (Double)interest;
            newTransaction.Week = comboBoxSelectWeekLive.Text;
            newTransaction.Date = DateTime.Now.ToString();
            newTransaction.Notes = "";

            transactionsDBDataSet.Transactions.Rows.Add(newTransaction);

            //credit the players
            foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
            {
                // find each player in the list
                foreach (ListViewItem listItem in listViewStillInLive.Items) ////////////////////////////////////////////////////////////////////////////compare names in listview right column?
                {
                    if (player.PlayerPoolName == listItem.SubItems[1].Text)
                    {
                        player.WeOWePlayer += (decimal)totalPayOut;
                        foreach (AccountingDataSet.AccountingRow accounting in accountingDataSet.Accounting)
                        {
                            if (accounting.SeasonName == PublicVariables.GetDefaultSeason)
                            {
                                accounting.TotalWeOweOut += player.WeOWePlayer;
                            }
                        }

                        // make the transaction here
                        TransactionsDBDataSet.TransactionsRow newWinTransaction = transactionsDBDataSet.Transactions.NewTransactionsRow();
                        // add the data to that row                  
                        newWinTransaction.PlayerName = player.PlayerPoolName;
                        newWinTransaction.SeasonName = textBoxSelectedSeason.Text;
                        newWinTransaction.Type = "Win Credit";
                        newWinTransaction.Method = "Win Credit";
                        newWinTransaction.Amount = -totalPayOut;
                        newWinTransaction.Week = comboBoxSelectWeekLive.Text;
                        newWinTransaction.Date = DateTime.Now.ToString();
                        newWinTransaction.Notes = "";

                        transactionsDBDataSet.Transactions.Rows.Add(newWinTransaction);

                    }
                }
            }

            this.Validate();
            this.playersBindingSource.EndEdit();
            this.accountingBindingSource.EndEdit();
            this.transactionsBindingSource.EndEdit();
            this.tableAdapterManager3.UpdateAll(this.transactionsDBDataSet);
            this.tableAdapterManager2.UpdateAll(this.accountingDataSet);
            this.tableAdapterManager.UpdateAll(this.playersDBDataSet);

        }

        private void comboBoxSelectWeekLive_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelWeekDisplayLive.Text = comboBoxSelectWeekLive.Text;
            UpdateCheckBoxes();

            // Load any boxes that were previously checked and any weeks that are final
            MakeFinal();

            // when the week changes all losers are reset
            ResetIsOut();

            if (comboBoxSelectWeekLive.Text == "Week 17")
            {
                listViewStillInLive.MultiSelect = true;
            }
            else
            {
                listViewStillInLive.MultiSelect = false;
            }
        }

        private void ResetPlayerPicks()
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

        private void SaveDatabases()
        {
            this.Validate();
            this.playersBindingSource.EndEdit();
            this.seasons1_5BindingSource.EndEdit();
            this.seasons6_10BindingSource.EndEdit();
            this.seasons11_17BindingSource.EndEdit();
            this.tableAdapterManager1.UpdateAll(this.seasonsDBDataSet);
            this.tableAdapterManager.UpdateAll(this.playersDBDataSet);
        }

        private void buttonSubmitLossLive_Click(object sender, EventArgs e)
        {
            var confirmSubmitFinal = MessageBox.Show("This will make the week final. No more changes can be made. Make the week final?", "Confirm Make Final", MessageBoxButtons.YesNo);

            if (confirmSubmitFinal == DialogResult.Yes)
            {
                if (upDownWeeksPot.Value <= 0)
                {
                    MessageBox.Show("You must enter an amount for this weeks pot. If no amount because of a roll-over then use the roll-over button.");
                    return;
                }

                if (listViewStillInLive.Items.Count <= 0)
                {
                    MessageBox.Show("There are no winners, you need to use the roll-over button.");
                    return;
                }

                //Submit the teams and picks. Bool false is this is being submitted not viewed; true is just viewing not submitting
                ViewResult(false);
                // reset the temporary player picks holder for the week
                ResetPlayerPicks();
                // make sure the winner and loser boxes are correct
                BuildWinnersLosersBox();
                // make the menu final
                MakeFinal();
                // calculate the pot
                if (upDownWeeksPot.Value != 0)
                {
                    CalculatePot();
                }
                // apply the money
                ApplyProgressiveAndWeeklyPots();
                // credit to the winners
                CreditWinners();
                // save everything
                SaveDatabases();

                MessageBox.Show(comboBoxSelectWeekLive.Text + " has been submitted. Hope there were no mistakes! :P");
                BuildWinnersExcel();
                BuildLabelsExcel();
            }
            else
            {
                MessageBox.Show("Submit Final Cancelled");
            }
        }
        private void ProgressivePotTransaction()
        {
            // make the transaction here
            TransactionsDBDataSet.TransactionsRow newProgressiveTransaction = transactionsDBDataSet.Transactions.NewTransactionsRow();
            // add the data to that row                  
            newProgressiveTransaction.PlayerName = "Progressive Pot";
            newProgressiveTransaction.SeasonName = textBoxSelectedSeason.Text;
            newProgressiveTransaction.Type = "Progressive";
            newProgressiveTransaction.Method = "Auto Progressive";
            newProgressiveTransaction.Amount = progressiveTotal;
            newProgressiveTransaction.Week = comboBoxSelectWeekLive.Text;
            newProgressiveTransaction.Date = DateTime.Now.ToString();
            newProgressiveTransaction.Notes = "";

            transactionsDBDataSet.Transactions.Rows.Add(newProgressiveTransaction);
        }

        private void ApplyProgressiveAndWeeklyPots()
        {

            foreach (AccountingDataSet.AccountingRow accounting in accountingDataSet.Accounting)
            {
                if (accounting.SeasonName == textBoxSelectedSeason.Text)
                {
                    accounting.ProgressivePot += progressiveTotal;
                    accounting.TotalFunds -= progressiveTotal;

                    if (comboBoxSelectWeekLive.Text == "Week 01")
                    {
                        accounting.ProgWeek01 = progressiveTotal;
                        accounting.WeekPot01 = upDownWeeksPot.Value;
                    }
                    if (comboBoxSelectWeekLive.Text == "Week 02")
                    {
                        accounting.ProgWeek02 = progressiveTotal;
                        accounting.WeekPot02 = upDownWeeksPot.Value;
                    }
                    if (comboBoxSelectWeekLive.Text == "Week 03")
                    {
                        accounting.ProgWeek03 = progressiveTotal;
                        accounting.WeekPot03 = upDownWeeksPot.Value;
                    }
                    if (comboBoxSelectWeekLive.Text == "Week 04")
                    {
                        accounting.ProgWeek04 = progressiveTotal;
                        accounting.WeekPot04 = upDownWeeksPot.Value;
                    }
                    if (comboBoxSelectWeekLive.Text == "Week 05")
                    {
                        accounting.ProgWeek05 = progressiveTotal;
                        accounting.WeekPot05 = upDownWeeksPot.Value;
                    }
                    if (comboBoxSelectWeekLive.Text == "Week 06")
                    {
                        accounting.ProgWeek06 = progressiveTotal;
                        accounting.WeekPot06 = upDownWeeksPot.Value;
                    }
                    if (comboBoxSelectWeekLive.Text == "Week 07")
                    {
                        accounting.ProgWeek07 = progressiveTotal;
                        accounting.WeekPot07 = upDownWeeksPot.Value;
                    }
                    if (comboBoxSelectWeekLive.Text == "Week 08")
                    {
                        accounting.ProgWeek08 = progressiveTotal;
                        accounting.WeekPot08 = upDownWeeksPot.Value;
                    }
                    if (comboBoxSelectWeekLive.Text == "Week 09")
                    {
                        accounting.ProgWeek09 = progressiveTotal;
                        accounting.WeekPot09 = upDownWeeksPot.Value;
                    }
                    if (comboBoxSelectWeekLive.Text == "Week 10")
                    {
                        accounting.ProgWeek10 = progressiveTotal;
                        accounting.WeekPot10 = upDownWeeksPot.Value;
                    }
                    if (comboBoxSelectWeekLive.Text == "Week 11")
                    {
                        accounting.ProgWeek11 = progressiveTotal;
                        accounting.WeekPot11 = upDownWeeksPot.Value;
                    }
                    if (comboBoxSelectWeekLive.Text == "Week 12")
                    {
                        accounting.ProgWeek12 = progressiveTotal;
                        accounting.WeekPot12 = upDownWeeksPot.Value;
                    }
                    if (comboBoxSelectWeekLive.Text == "Week 13")
                    {
                        accounting.ProgWeek13 = progressiveTotal;
                        accounting.WeekPot13 = upDownWeeksPot.Value;
                    }
                    if (comboBoxSelectWeekLive.Text == "Week 14")
                    {
                        accounting.ProgWeek14 = progressiveTotal;
                        accounting.WeekPot14 = upDownWeeksPot.Value;
                    }
                    if (comboBoxSelectWeekLive.Text == "Week 15")
                    {
                        accounting.ProgWeek15 = progressiveTotal;
                        accounting.WeekPot15 = upDownWeeksPot.Value;
                    }
                    if (comboBoxSelectWeekLive.Text == "Week 16")
                    {
                        accounting.ProgWeek16 = progressiveTotal;
                        accounting.WeekPot16 = upDownWeeksPot.Value;
                    }
                    if (comboBoxSelectWeekLive.Text == "Week 17")
                    {
                        accounting.ProgWeek17 = progressiveTotal;
                        accounting.WeekPot17 = upDownWeeksPot.Value;
                    }

                    // create the progressive pot transaction here
                    ProgressivePotTransaction();

                    // update the databases
                    this.Validate();
                    this.transactionsBindingSource.EndEdit();
                    this.accountingBindingSource.EndEdit();
                    this.tableAdapterManager2.UpdateAll(this.accountingDataSet);
                    this.tableAdapterManager3.UpdateAll(this.transactionsDBDataSet);
                }
            }
        }

        private void loserBracket01_1_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket01_2.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket01_2_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket01_1.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket02_1_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket02_2.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket02_2_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket02_1.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket03_1_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket03_2.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket03_2_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket03_1.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket04_1_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket04_2.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket04_2_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket04_1.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket05_1_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket05_2.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket05_2_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket05_1.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket06_1_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket06_2.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket06_2_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket06_1.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket07_1_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket07_2.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket07_2_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket07_1.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket08_1_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket08_2.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket08_2_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket08_1.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket09_1_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket09_2.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket09_2_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket09_1.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket10_1_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket10_2.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket10_2_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket10_1.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket11_1_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket11_2.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket11_2_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket11_1.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket12_1_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket12_2.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket12_2_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket12_1.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket13_1_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket13_2.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket13_2_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket13_1.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket14_1_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket14_2.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket14_2_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket14_1.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket15_1_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket15_2.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket15_2_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket15_1.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket16_1_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket16_2.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket16_2_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket16_1.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket17_1_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket17_2.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket17_2_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket17_1.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket18_1_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket18_2.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket18_2_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket18_1.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket19_1_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket19_2.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket19_2_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket19_1.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket20_1_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket20_2.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void loserBracket20_2_CheckedChanged(object sender, EventArgs e)
        {
            //loserBracket20_1.Checked = false;
            if (makeFinal != true)
            {
                ViewResult(true);
            }
        }

        private void MakeFinal()
        {
            if (PublicVariables.GetDefaultSeason == null)
            {
                MessageBox.Show("Need to select or create a season first.");
                return;
            }

            SeasonsDBDataSet.Seasons1_5Row season1_5 = FindSeason1_5();
            SeasonsDBDataSet.Seasons6_10Row season6_10 = FindSeason6_10();
            SeasonsDBDataSet.Seasons11_17Row season11_17 = FindSeason11_17();

            makeFinal = true;
            // for the FINAL
            if (comboBoxSelectWeekLive.Text == "Week 01" && season1_5.Week01IsFinal)
            {
                labelFinal.Visible = true;
                labelFinal.Text = "Week 01 is FINAL";
                buttonSubmitLossLive.Enabled = false;
                buttonRollOver.Enabled = false;
                upDownWeeksPot.Enabled = false;
                buttonResetCheckboxes.Enabled = false;
                /////buttonSaveCheckboxes.Enabled = false;

                // split the losing teams list
                string[] tempString = season1_5.LosersWeek01.Split(',');

                // add split teams to list
                List<string> tempList = new List<string>(tempString);

                // see if the check box text matches any in the losers list
                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    // need to uncheck any checked boxes first
                    checkBoxes.Checked = false;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (tempList.Contains(checkBoxes.Text))
                    {
                        checkBoxes.Checked = true;
                    }
                }

                // disable the check boxes
                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Enabled = false;
                }
            }

            // if not final then load the previous checked boxes if any
            else if (comboBoxSelectWeekLive.Text == "Week 01" && !season1_5.Week01IsFinal)
            {
                labelFinal.Visible = false;
                buttonSubmitLossLive.Enabled = true;
                labelRollOver.Visible = false;
                buttonRollOver.Enabled = true;
                upDownWeeksPot.Enabled = true;
                buttonResetCheckboxes.Enabled = true;
                //buttonSaveCheckboxes.Enabled =true;


                // split the losing teams list
                string[] tempString = season1_5.LosersWeek01.Split(',');

                // add split teams to list
                List<string> tempList = new List<string>(tempString);

                // see if the check box text matches any in the losers list
                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    // need to uncheck any checked boxes first
                    checkBoxes.Enabled = true;
                    checkBoxes.Checked = false;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (tempList.Count != 0 && tempList.Contains(checkBoxes.Text))
                    {
                        checkBoxes.Checked = true;
                    }
                }
            }

            else if (comboBoxSelectWeekLive.Text == "Week 02" && season1_5.Week02IsFinal)
            {
                labelFinal.Visible = true;
                labelFinal.Text = "Week 02 is FINAL";
                buttonSubmitLossLive.Enabled = false;
                buttonRollOver.Enabled = false;
                upDownWeeksPot.Enabled = false;
                buttonResetCheckboxes.Enabled = false;
                ////buttonSaveCheckboxes.Enabled = false;

                string[] tempString = season1_5.LosersWeek02.Split(',');
                List<string> tempList = new List<string>(tempString);

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Checked = false;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (tempList.Contains(checkBoxes.Text))
                    {
                        checkBoxes.Checked = true;
                    }
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Enabled = false;
                }
            }

            else if (comboBoxSelectWeekLive.Text == "Week 02" && !season1_5.Week02IsFinal)
            {
                labelFinal.Visible = false;
                buttonSubmitLossLive.Enabled = true;
                labelRollOver.Visible = false;
                buttonRollOver.Enabled = true;
                upDownWeeksPot.Enabled = true;
                buttonResetCheckboxes.Enabled = true;
                //buttonSaveCheckboxes.Enabled =true;

                string[] tempString = season1_5.LosersWeek02.Split(',');
                List<string> tempList = new List<string>(tempString);

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Enabled = true;
                    checkBoxes.Checked = false;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (tempList.Count != 0 && tempList.Contains(checkBoxes.Text))
                    {
                        checkBoxes.Checked = true;
                    }
                }
            }

            else if (comboBoxSelectWeekLive.Text == "Week 03" && season1_5.Week03IsFinal)
            {
                labelFinal.Visible = true;
                labelFinal.Text = "Week 03 is FINAL";
                buttonSubmitLossLive.Enabled = false;
                buttonRollOver.Enabled = false;
                upDownWeeksPot.Enabled = false;
                buttonResetCheckboxes.Enabled = false;
                ////buttonSaveCheckboxes.Enabled = false;

                string[] tempString = season1_5.LosersWeek03.Split(',');
                List<string> tempList = new List<string>(tempString);

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Checked = false;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (tempList.Contains(checkBoxes.Text))
                    {
                        checkBoxes.Checked = true;
                    }
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Enabled = false;
                }
            }

            else if (comboBoxSelectWeekLive.Text == "Week 03" && !season1_5.Week03IsFinal)
            {
                labelFinal.Visible = false;
                buttonSubmitLossLive.Enabled = true;
                labelRollOver.Visible = false;
                buttonRollOver.Enabled = true;
                upDownWeeksPot.Enabled = true;
                buttonResetCheckboxes.Enabled = true;
                //buttonSaveCheckboxes.Enabled =true;


                string[] tempString = season1_5.LosersWeek03.Split(',');
                List<string> tempList = new List<string>(tempString);

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Enabled = true;
                    checkBoxes.Checked = false;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (tempList.Contains(checkBoxes.Text))
                    {
                        checkBoxes.Checked = true;
                    }
                }
            }

            else if (comboBoxSelectWeekLive.Text == "Week 04" && season1_5.Week04IsFinal)
            {
                labelFinal.Visible = true;
                labelFinal.Text = "Week 04 is FINAL";
                buttonSubmitLossLive.Enabled = false;
                buttonRollOver.Enabled = false;
                upDownWeeksPot.Enabled = false;
                buttonResetCheckboxes.Enabled = false;
                //buttonSaveCheckboxes.Enabled = false;

                string[] tempString = season1_5.LosersWeek04.Split(',');
                List<string> tempList = new List<string>(tempString);

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Checked = false;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (tempList.Contains(checkBoxes.Text))
                    {
                        checkBoxes.Checked = true;
                    }
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Enabled = false;
                }
            }

            else if (comboBoxSelectWeekLive.Text == "Week 04" && !season1_5.Week04IsFinal)
            {
                labelFinal.Visible = false;
                buttonSubmitLossLive.Enabled = true;
                labelRollOver.Visible = false;
                buttonRollOver.Enabled = true;
                upDownWeeksPot.Enabled = true;
                buttonResetCheckboxes.Enabled = true;
                //buttonSaveCheckboxes.Enabled =true;


                string[] tempString = season1_5.LosersWeek04.Split(',');
                List<string> tempList = new List<string>(tempString);

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Enabled = true;
                    checkBoxes.Checked = false;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (tempList.Contains(checkBoxes.Text))
                    {
                        checkBoxes.Checked = true;
                    }
                }
            }

            else if (comboBoxSelectWeekLive.Text == "Week 05" && season1_5.Week05IsFinal)
            {
                labelFinal.Visible = true;
                labelFinal.Text = "Week 05 is FINAL";
                buttonSubmitLossLive.Enabled = false;
                buttonRollOver.Enabled = false;
                upDownWeeksPot.Enabled = false;
                buttonResetCheckboxes.Enabled = false;
                //buttonSaveCheckboxes.Enabled = false;


                string[] tempString = season1_5.LosersWeek05.Split(',');
                List<string> tempList = new List<string>(tempString);

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Checked = false;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (tempList.Contains(checkBoxes.Text))
                    {
                        checkBoxes.Checked = true;
                    }
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Enabled = false;
                }
            }

            else if (comboBoxSelectWeekLive.Text == "Week 05" && !season1_5.Week05IsFinal)
            {
                labelFinal.Visible = false;
                buttonSubmitLossLive.Enabled = true;
                labelRollOver.Visible = false;
                buttonRollOver.Enabled = true;
                upDownWeeksPot.Enabled = true;
                buttonResetCheckboxes.Enabled = true;
                //buttonSaveCheckboxes.Enabled =true;


                string[] tempString = season1_5.LosersWeek05.Split(',');
                List<string> tempList = new List<string>(tempString);

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Enabled = true;
                    checkBoxes.Checked = false;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (tempList.Contains(checkBoxes.Text))
                    {
                        checkBoxes.Checked = true;
                    }
                }
            }

            else if (comboBoxSelectWeekLive.Text == "Week 06" && season6_10.Week06IsFinal)
            {
                labelFinal.Visible = true;
                labelFinal.Text = "Week 06 is FINAL";
                buttonSubmitLossLive.Enabled = false;
                buttonRollOver.Enabled = false;
                upDownWeeksPot.Enabled = false;
                buttonResetCheckboxes.Enabled = false;
                //buttonSaveCheckboxes.Enabled = false;


                string[] tempString = season6_10.LosersWeek06.Split(',');
                List<string> tempList = new List<string>(tempString);

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Checked = false;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (tempList.Contains(checkBoxes.Text))
                    {
                        checkBoxes.Checked = true;
                    }
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Enabled = false;
                }
            }

            else if (comboBoxSelectWeekLive.Text == "Week 06" && !season6_10.Week06IsFinal)
            {
                labelFinal.Visible = false;
                buttonSubmitLossLive.Enabled = true;
                labelRollOver.Visible = false;
                buttonRollOver.Enabled = true;
                upDownWeeksPot.Enabled = true;
                buttonResetCheckboxes.Enabled = true;
                //buttonSaveCheckboxes.Enabled =true;

                string[] tempString = season6_10.LosersWeek06.Split(',');
                List<string> tempList = new List<string>(tempString);

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Enabled = true;
                    checkBoxes.Checked = false;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (tempList.Contains(checkBoxes.Text))
                    {
                        checkBoxes.Checked = true;
                    }
                }
            }

            else if (comboBoxSelectWeekLive.Text == "Week 07" && season6_10.Week07IsFinal)
            {
                labelFinal.Visible = true;
                labelFinal.Text = "Week 07 is FINAL";
                buttonSubmitLossLive.Enabled = false;
                buttonRollOver.Enabled = false;
                upDownWeeksPot.Enabled = false;
                buttonResetCheckboxes.Enabled = false;
                //buttonSaveCheckboxes.Enabled = false;


                string[] tempString = season6_10.LosersWeek07.Split(',');
                List<string> tempList = new List<string>(tempString);

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Checked = false;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (tempList.Contains(checkBoxes.Text))
                    {
                        checkBoxes.Checked = true;
                    }
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Enabled = false;
                }
            }

            else if (comboBoxSelectWeekLive.Text == "Week 07" && !season6_10.Week07IsFinal)
            {
                labelFinal.Visible = false;
                buttonSubmitLossLive.Enabled = true;
                labelRollOver.Visible = false;
                buttonRollOver.Enabled = true;
                upDownWeeksPot.Enabled = true;
                buttonResetCheckboxes.Enabled = true;
                //buttonSaveCheckboxes.Enabled =true;


                string[] tempString = season6_10.LosersWeek07.Split(',');
                List<string> tempList = new List<string>(tempString);

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Enabled = true;
                    checkBoxes.Checked = false;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (tempList.Contains(checkBoxes.Text))
                    {
                        checkBoxes.Checked = true;
                    }
                }
            }

            else if (comboBoxSelectWeekLive.Text == "Week 08" && season6_10.Week08IsFinal)
            {
                labelFinal.Visible = true;
                labelFinal.Text = "Week 08 is FINAL";
                buttonSubmitLossLive.Enabled = false;
                buttonRollOver.Enabled = false;
                upDownWeeksPot.Enabled = false;
                buttonResetCheckboxes.Enabled = false;
                //buttonSaveCheckboxes.Enabled = false;

                string[] tempString = season6_10.LosersWeek08.Split(',');
                List<string> tempList = new List<string>(tempString);

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Checked = false;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (tempList.Contains(checkBoxes.Text))
                    {
                        checkBoxes.Checked = true;
                    }
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Enabled = false;
                }
            }

            else if (comboBoxSelectWeekLive.Text == "Week 08" && !season6_10.Week08IsFinal)
            {
                labelFinal.Visible = false;
                buttonSubmitLossLive.Enabled = true;
                labelRollOver.Visible = false;
                buttonRollOver.Enabled = true;
                upDownWeeksPot.Enabled = true;
                buttonResetCheckboxes.Enabled = true;
                //buttonSaveCheckboxes.Enabled =true;

                string[] tempString = season6_10.LosersWeek08.Split(',');
                List<string> tempList = new List<string>(tempString);

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Enabled = true;
                    checkBoxes.Checked = false;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (tempList.Contains(checkBoxes.Text))
                    {
                        checkBoxes.Checked = true;
                    }
                }
            }

            else if (comboBoxSelectWeekLive.Text == "Week 09" && season6_10.Week09IsFinal)
            {
                labelFinal.Visible = true;
                labelFinal.Text = "Week 09 is FINAL";
                buttonSubmitLossLive.Enabled = false;
                buttonRollOver.Enabled = false;
                upDownWeeksPot.Enabled = false;
                buttonResetCheckboxes.Enabled = false;
                //buttonSaveCheckboxes.Enabled = false;

                string[] tempString = season6_10.LosersWeek09.Split(',');
                List<string> tempList = new List<string>(tempString);

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Checked = false;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (tempList.Contains(checkBoxes.Text))
                    {
                        checkBoxes.Checked = true;
                    }
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Enabled = false;
                }
            }

            else if (comboBoxSelectWeekLive.Text == "Week 09" && !season6_10.Week09IsFinal)
            {
                labelFinal.Visible = false;
                buttonSubmitLossLive.Enabled = true;
                labelRollOver.Visible = false;
                buttonRollOver.Enabled = true;
                upDownWeeksPot.Enabled = true;
                buttonResetCheckboxes.Enabled = true;
                //buttonSaveCheckboxes.Enabled =true;

                string[] tempString = season6_10.LosersWeek09.Split(',');
                List<string> tempList = new List<string>(tempString);

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Enabled = true;
                    checkBoxes.Checked = false;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (tempList.Contains(checkBoxes.Text))
                    {
                        checkBoxes.Checked = true;
                    }
                }
            }

            else if (comboBoxSelectWeekLive.Text == "Week 10" && season6_10.Week10IsFinal)
            {
                labelFinal.Visible = true;
                labelFinal.Text = "Week 10 is FINAL";
                buttonSubmitLossLive.Enabled = false;
                buttonRollOver.Enabled = false;
                upDownWeeksPot.Enabled = false;
                buttonResetCheckboxes.Enabled = false;
                //buttonSaveCheckboxes.Enabled = false;

                string[] tempString = season6_10.LosersWeek10.Split(',');
                List<string> tempList = new List<string>(tempString);

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Checked = false;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (tempList.Contains(checkBoxes.Text))
                    {
                        checkBoxes.Checked = true;
                    }
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Enabled = false;
                }
            }

            else if (comboBoxSelectWeekLive.Text == "Week 10" && !season6_10.Week10IsFinal)
            {
                labelFinal.Visible = false;
                buttonSubmitLossLive.Enabled = true;
                labelRollOver.Visible = false;
                buttonRollOver.Enabled = true;
                upDownWeeksPot.Enabled = true;
                buttonResetCheckboxes.Enabled = true;
                //buttonSaveCheckboxes.Enabled =true;

                string[] tempString = season6_10.LosersWeek10.Split(',');
                List<string> tempList = new List<string>(tempString);

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Enabled = true;
                    checkBoxes.Checked = false;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (tempList.Contains(checkBoxes.Text))
                    {
                        checkBoxes.Checked = true;
                    }
                }
            }

            else if (comboBoxSelectWeekLive.Text == "Week 11" && season11_17.Week11IsFinal)
            {
                labelFinal.Visible = true;
                labelFinal.Text = "Week 11 is FINAL";
                buttonSubmitLossLive.Enabled = false;
                buttonRollOver.Enabled = false;
                upDownWeeksPot.Enabled = false;
                buttonResetCheckboxes.Enabled = false;
                //buttonSaveCheckboxes.Enabled = false;

                string[] tempString = season11_17.LosersWeek11.Split(',');
                List<string> tempList = new List<string>(tempString);

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Checked = false;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (tempList.Contains(checkBoxes.Text))
                    {
                        checkBoxes.Checked = true;
                    }
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Enabled = false;
                }
            }

            else if (comboBoxSelectWeekLive.Text == "Week 11" && !season11_17.Week11IsFinal)
            {
                labelFinal.Visible = false;
                buttonSubmitLossLive.Enabled = true;
                labelRollOver.Visible = false;
                buttonRollOver.Enabled = true;
                upDownWeeksPot.Enabled = true;
                buttonResetCheckboxes.Enabled = true;
                //buttonSaveCheckboxes.Enabled =true;

                string[] tempString = season11_17.LosersWeek11.Split(',');
                List<string> tempList = new List<string>(tempString);

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Enabled = true;
                    checkBoxes.Checked = false;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (tempList.Contains(checkBoxes.Text))
                    {
                        checkBoxes.Checked = true;
                    }
                }
            }

            else if (comboBoxSelectWeekLive.Text == "Week 12" && season11_17.Week12IsFinal)
            {
                labelFinal.Visible = true;
                labelFinal.Text = "Week 12 is FINAL";
                buttonSubmitLossLive.Enabled = false;
                buttonRollOver.Enabled = false;
                upDownWeeksPot.Enabled = false;
                buttonResetCheckboxes.Enabled = false;
                //buttonSaveCheckboxes.Enabled = false;

                string[] tempString = season11_17.LosersWeek12.Split(',');
                List<string> tempList = new List<string>(tempString);

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Checked = false;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (tempList.Contains(checkBoxes.Text))
                    {
                        checkBoxes.Checked = true;
                    }
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Enabled = false;
                }
            }

            else if (comboBoxSelectWeekLive.Text == "Week 12" && !season11_17.Week12IsFinal)
            {
                labelFinal.Visible = false;
                buttonSubmitLossLive.Enabled = true;
                labelRollOver.Visible = false;
                buttonRollOver.Enabled = true;
                upDownWeeksPot.Enabled = true;
                buttonResetCheckboxes.Enabled = true;
                //buttonSaveCheckboxes.Enabled =true;

                string[] tempString = season11_17.LosersWeek12.Split(',');
                List<string> tempList = new List<string>(tempString);

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Enabled = true;
                    checkBoxes.Checked = false;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (tempList.Contains(checkBoxes.Text))
                    {
                        checkBoxes.Checked = true;
                    }
                }
            }

            else if (comboBoxSelectWeekLive.Text == "Week 13" && season11_17.Week13IsFinal)
            {
                labelFinal.Visible = true;
                labelFinal.Text = "Week 13 is FINAL";
                buttonSubmitLossLive.Enabled = false;
                buttonRollOver.Enabled = false;
                upDownWeeksPot.Enabled = false;
                buttonResetCheckboxes.Enabled = false;
                //buttonSaveCheckboxes.Enabled = false;

                string[] tempString = season11_17.LosersWeek13.Split(',');
                List<string> tempList = new List<string>(tempString);

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Checked = false;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (tempList.Contains(checkBoxes.Text))
                    {
                        checkBoxes.Checked = true;
                    }
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Enabled = false;
                }
            }

            else if (comboBoxSelectWeekLive.Text == "Week 13" && !season11_17.Week13IsFinal)
            {
                labelFinal.Visible = false;
                buttonSubmitLossLive.Enabled = true;
                labelRollOver.Visible = false;
                buttonRollOver.Enabled = true;
                upDownWeeksPot.Enabled = true;
                buttonResetCheckboxes.Enabled = true;
                //buttonSaveCheckboxes.Enabled =true;

                string[] tempString = season11_17.LosersWeek13.Split(',');
                List<string> tempList = new List<string>(tempString);

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Enabled = true;
                    checkBoxes.Checked = false;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (tempList.Contains(checkBoxes.Text))
                    {
                        checkBoxes.Checked = true;
                    }
                }
            }

            else if (comboBoxSelectWeekLive.Text == "Week 14" && season11_17.Week14IsFinal)
            {
                labelFinal.Visible = true;
                labelFinal.Text = "Week 14 is FINAL";
                buttonSubmitLossLive.Enabled = false;
                buttonRollOver.Enabled = false;
                upDownWeeksPot.Enabled = false;
                buttonResetCheckboxes.Enabled = false;
                //buttonSaveCheckboxes.Enabled = false;

                string[] tempString = season11_17.LosersWeek14.Split(',');
                List<string> tempList = new List<string>(tempString);

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Checked = false;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (tempList.Contains(checkBoxes.Text))
                    {
                        checkBoxes.Checked = true;
                    }
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Enabled = false;
                }
            }

            else if (comboBoxSelectWeekLive.Text == "Week 14" && !season11_17.Week14IsFinal)
            {
                labelFinal.Visible = false;
                buttonSubmitLossLive.Enabled = true;
                labelRollOver.Visible = false;
                buttonRollOver.Enabled = true;
                upDownWeeksPot.Enabled = true;
                buttonResetCheckboxes.Enabled = true;
                //buttonSaveCheckboxes.Enabled =true;

                string[] tempString = season11_17.LosersWeek14.Split(',');
                List<string> tempList = new List<string>(tempString);

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Enabled = true;
                    checkBoxes.Checked = false;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (tempList.Contains(checkBoxes.Text))
                    {
                        checkBoxes.Checked = true;
                    }
                }
            }

            else if (comboBoxSelectWeekLive.Text == "Week 15" && season11_17.Week15IsFinal)
            {
                labelFinal.Visible = true;
                labelFinal.Text = "Week 15 is FINAL";
                buttonSubmitLossLive.Enabled = false;
                buttonRollOver.Enabled = false;
                upDownWeeksPot.Enabled = false;
                buttonResetCheckboxes.Enabled = false;
                //buttonSaveCheckboxes.Enabled = false;

                string[] tempString = season11_17.LosersWeek15.Split(',');
                List<string> tempList = new List<string>(tempString);

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Checked = false;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (tempList.Contains(checkBoxes.Text))
                    {
                        checkBoxes.Checked = true;
                    }
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Enabled = false;
                }
            }

            else if (comboBoxSelectWeekLive.Text == "Week 15" && !season11_17.Week15IsFinal)
            {
                labelFinal.Visible = false;
                buttonSubmitLossLive.Enabled = true;
                labelRollOver.Visible = false;
                buttonRollOver.Enabled = true;
                upDownWeeksPot.Enabled = true;
                buttonResetCheckboxes.Enabled = true;
                //buttonSaveCheckboxes.Enabled =true;

                string[] tempString = season11_17.LosersWeek15.Split(',');
                List<string> tempList = new List<string>(tempString);

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Enabled = true;
                    checkBoxes.Checked = false;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (tempList.Contains(checkBoxes.Text))
                    {
                        checkBoxes.Checked = true;
                    }
                }
            }

            else if (comboBoxSelectWeekLive.Text == "Week 16" && season11_17.Week16IsFinal)
            {
                labelFinal.Visible = true;
                labelFinal.Text = "Week 16 is FINAL";
                buttonSubmitLossLive.Enabled = false;
                buttonRollOver.Enabled = false;
                upDownWeeksPot.Enabled = false;
                buttonResetCheckboxes.Enabled = false;
                //buttonSaveCheckboxes.Enabled = false;

                string[] tempString = season11_17.LosersWeek16.Split(',');
                List<string> tempList = new List<string>(tempString);

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Checked = false;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (tempList.Contains(checkBoxes.Text))
                    {
                        checkBoxes.Checked = true;
                    }
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Enabled = false;
                }
            }

            else if (comboBoxSelectWeekLive.Text == "Week 16" && !season11_17.Week16IsFinal)
            {
                labelFinal.Visible = false;
                buttonSubmitLossLive.Enabled = true;
                labelRollOver.Visible = false;
                buttonRollOver.Enabled = true;
                upDownWeeksPot.Enabled = true;
                buttonResetCheckboxes.Enabled = true;
                //buttonSaveCheckboxes.Enabled =true;

                string[] tempString = season11_17.LosersWeek16.Split(',');
                List<string> tempList = new List<string>(tempString);

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Enabled = true;
                    checkBoxes.Checked = false;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (tempList.Contains(checkBoxes.Text))
                    {
                        checkBoxes.Checked = true;
                    }
                }
            }

            else if (comboBoxSelectWeekLive.Text == "Week 17" && season11_17.Week17IsFinal)
            {
                labelFinal.Visible = true;
                labelFinal.Text = "Week 17 is FINAL";
                buttonSubmitLossLive.Enabled = false;
                buttonRollOver.Enabled = false;
                upDownWeeksPot.Enabled = false;
                buttonResetCheckboxes.Enabled = false;
                //buttonSaveCheckboxes.Enabled = false;

                string[] tempString = season11_17.LosersWeek17.Split(',');
                List<string> tempList = new List<string>(tempString);

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Checked = false;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (tempList.Contains(checkBoxes.Text))
                    {
                        checkBoxes.Checked = true;
                    }
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Enabled = false;
                }
            }

            else if (comboBoxSelectWeekLive.Text == "Week 17" && !season11_17.Week17IsFinal)
            {
                labelFinal.Visible = false;
                buttonSubmitLossLive.Enabled = true;
                labelRollOver.Visible = false;
                buttonRollOver.Enabled = false;
                upDownWeeksPot.Enabled = true;

                string[] tempString = season11_17.LosersWeek17.Split(',');
                List<string> tempList = new List<string>(tempString);

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    checkBoxes.Enabled = true;
                    checkBoxes.Checked = false;
                }

                foreach (System.Windows.Forms.CheckBox checkBoxes in CheckBoxes)
                {
                    if (tempList.Count != 0 && tempList.Contains(checkBoxes.Text))
                    {
                        checkBoxes.Checked = true;
                    }
                }
            }
            BuildWinnersLosersBox();
            makeFinal = false;
            ViewResult(true);
        }

        private void buttonAccountingMain_Click(object sender, EventArgs e)
        {
            // check to see if the form is open
            if ((System.Windows.Forms.Application.OpenForms["FormAccounting"] as FormAccounting) != null)
            {
                // if it is then select the right form
                foreach (Form form in System.Windows.Forms.Application.OpenForms)
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

        private SeasonsDBDataSet.Seasons1_5Row FindSeason1_5()
        {
            foreach (SeasonsDBDataSet.Seasons1_5Row selectedSeason1_5 in seasonsDBDataSet.Seasons1_5)
            {
                if (selectedSeason1_5.SeasonName == textBoxSelectedSeason.Text)
                {
                    return selectedSeason1_5;
                }
            }
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

        private void buttonRollOver_Click(object sender, EventArgs e)
        {
            var confirmChargeBuyIns = MessageBox.Show("This will Roll Over the week. Changes can no longer be made. Roll Over the week?", "Confirm Roll Over", MessageBoxButtons.YesNo);

            if (confirmChargeBuyIns == DialogResult.Yes)
            {
                foreach (AccountingDataSet.AccountingRow accounting in accountingDataSet.Accounting)
                {
                    if (accounting.SeasonName == textBoxSelectedSeason.Text)
                    {
                        accounting.RollOverPot += grossPot;
                    }
                }
                upDownWeeksPot.Value = 0;
                //Submit the teams and picks. Bool false is this is being submitted not viewed; true is just viewing not submitting
                ViewResult(false);
                // reset the temporary player picks holder for the week
                ResetPlayerPicks();
                // make sure the winner and loser boxes are correct
                BuildWinnersLosersBox();
                // make the menu final
                MakeFinal();
                // apply the money
                ApplyProgressiveAndWeeklyPots();
                // save everything
                SaveDatabases();

                labelRollOver.Visible = true;
            }
            else
            {
                MessageBox.Show("Roll Over Cancelled.");
            }
        }

        private void BuildSavedCheckBoxesList()
        {
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox01);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox02);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox03);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox04);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox05);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox06);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox07);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox08);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox09);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox10);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox11);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox12);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox13);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox14);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox15);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox16);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox17);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox18);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox19);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox20);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox21);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox22);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox23);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox24);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox25);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox26);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox27);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox28);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox29);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox30);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox31);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox32);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox33);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox34);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox35);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox36);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox37);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox38);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox39);
            CheckBoxesSaved.Add(checkBoxesLiveWindow.CheckBox40);
        }

        private void buttonResetCheckboxes_Click(object sender, EventArgs e)
        {
            foreach (System.Windows.Forms.CheckBox checkBox in CheckBoxes)
            {
                checkBox.Checked = false;
            }
        }

        private void buttonSaveCheckboxes_Click(object sender, EventArgs e)
        {
            /*
            SavedCheckBoxesLive savedCheckBoxes = new SavedCheckBoxesLive();

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("CheckBoxesSave.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            for (int i = 0; i <= 39; i++)
            {
                CheckBoxesSaved[i].CheckState = CheckBoxes[i].CheckState;
            }
            formatter.Serialize(stream, checkBoxesLiveWindow);
            stream.Close();
            */
            Properties.Settings.Default.CheckBox01 = loserBracket01_1.Checked;
            Properties.Settings.Default.Save();
        }

        private void LoadSavedCheckboxes()
        {
            SeasonsDBDataSet.Seasons1_5Row season1_5 = FindSeason1_5();
            SeasonsDBDataSet.Seasons6_10Row season6_10 = FindSeason6_10();
            SeasonsDBDataSet.Seasons11_17Row season11_17 = FindSeason11_17();

            if (comboBoxSelectWeekLive.Text == "Week 01" && season1_5.Week01IsFinal == false)
            {
                for (int i = 0; i <= 39; i++)
                {
                    CheckBoxes[i].CheckState = CheckBoxesSaved[i].CheckState;
                }
            }
            if (comboBoxSelectWeekLive.Text == "Week 02" && season1_5.Week02IsFinal == false)
            {
                for (int i = 0; i <= 39; i++)
                {
                    CheckBoxes[i].CheckState = CheckBoxesSaved[i].CheckState;
                }
            }
            if (comboBoxSelectWeekLive.Text == "Week 03" && season1_5.Week03IsFinal == false)
            {
                for (int i = 0; i <= 39; i++)
                {
                    CheckBoxes[i].CheckState = CheckBoxesSaved[i].CheckState;
                }
            }
            if (comboBoxSelectWeekLive.Text == "Week 04" && season1_5.Week04IsFinal == false)
            {
                for (int i = 0; i <= 39; i++)
                {
                    CheckBoxes[i].CheckState = CheckBoxesSaved[i].CheckState;
                }
            }
            if (comboBoxSelectWeekLive.Text == "Week 05" && season1_5.Week05IsFinal == false)
            {
                for (int i = 0; i <= 39; i++)
                {
                    CheckBoxes[i].CheckState = CheckBoxesSaved[i].CheckState;
                }
            }
            if (comboBoxSelectWeekLive.Text == "Week 06" && season6_10.Week06IsFinal == false)
            {
                for (int i = 0; i <= 39; i++)
                {
                    CheckBoxes[i].CheckState = CheckBoxesSaved[i].CheckState;
                }
            }
            if (comboBoxSelectWeekLive.Text == "Week 07" && season6_10.Week07IsFinal == false)
            {
                for (int i = 0; i <= 39; i++)
                {
                    CheckBoxes[i].CheckState = CheckBoxesSaved[i].CheckState;
                }
            }
            if (comboBoxSelectWeekLive.Text == "Week 08" && season6_10.Week08IsFinal == false)
            {
                for (int i = 0; i <= 39; i++)
                {
                    CheckBoxes[i].CheckState = CheckBoxesSaved[i].CheckState;
                }
            }
            if (comboBoxSelectWeekLive.Text == "Week 09" && season6_10.Week09IsFinal == false)
            {
                for (int i = 0; i <= 39; i++)
                {
                    CheckBoxes[i].CheckState = CheckBoxesSaved[i].CheckState;
                }
            }
            if (comboBoxSelectWeekLive.Text == "Week 10" && season6_10.Week10IsFinal == false)
            {
                for (int i = 0; i <= 39; i++)
                {
                    CheckBoxes[i].CheckState = CheckBoxesSaved[i].CheckState;
                }
            }
            if (comboBoxSelectWeekLive.Text == "Week 11" && season11_17.Week11IsFinal == false)
            {
                for (int i = 0; i <= 39; i++)
                {
                    CheckBoxes[i].CheckState = CheckBoxesSaved[i].CheckState;
                }
            }
            if (comboBoxSelectWeekLive.Text == "Week 12" && season11_17.Week12IsFinal == false)
            {
                for (int i = 0; i <= 39; i++)
                {
                    CheckBoxes[i].CheckState = CheckBoxesSaved[i].CheckState;
                }
            }
            if (comboBoxSelectWeekLive.Text == "Week 13" && season11_17.Week13IsFinal == false)
            {
                for (int i = 0; i <= 39; i++)
                {
                    CheckBoxes[i].CheckState = CheckBoxesSaved[i].CheckState;
                }
            }
            if (comboBoxSelectWeekLive.Text == "Week 14" && season11_17.Week14IsFinal == false)
            {
                for (int i = 0; i <= 39; i++)
                {
                    CheckBoxes[i].CheckState = CheckBoxesSaved[i].CheckState;
                }
            }
            if (comboBoxSelectWeekLive.Text == "Week 15" && season11_17.Week15IsFinal == false)
            {
                for (int i = 0; i <= 39; i++)
                {
                    CheckBoxes[i].CheckState = CheckBoxesSaved[i].CheckState;
                }
            }
            if (comboBoxSelectWeekLive.Text == "Week 16" && season11_17.Week16IsFinal == false)
            {
                for (int i = 0; i <= 39; i++)
                {
                    CheckBoxes[i].CheckState = CheckBoxesSaved[i].CheckState;
                }
            }
            if (comboBoxSelectWeekLive.Text == "Week 17" && season11_17.Week17IsFinal == false)
            {
                for (int i = 0; i <= 39; i++)
                {
                    CheckBoxes[i].CheckState = CheckBoxesSaved[i].CheckState;
                }
            }
        }

        private void buttonFixWeek01Final_Click(object sender, EventArgs e)
        {
            SeasonsDBDataSet.Seasons1_5Row season1_5 = FindSeason1_5();

            if (season1_5.SeasonName == textBoxSelectedSeason.Text)
            {
                season1_5.Week01IsFinal = false;
            }

            this.seasons1_5BindingSource.EndEdit();
            this.tableAdapterManager1.UpdateAll(this.seasonsDBDataSet);

            MessageBox.Show("Week 01 is no longer final. Close Live Window and open again to see if it worked.");
        }

        private void FormLiveWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.CheckBox01 = loserBracket01_1.Checked;
            Properties.Settings.Default.CheckBox02 = loserBracket01_2.Checked;
            Properties.Settings.Default.CheckBox03 = loserBracket02_1.Checked;
            Properties.Settings.Default.CheckBox04 = loserBracket02_2.Checked;
            Properties.Settings.Default.CheckBox05 = loserBracket03_1.Checked;
            Properties.Settings.Default.CheckBox06 = loserBracket03_2.Checked;
            Properties.Settings.Default.CheckBox07 = loserBracket04_1.Checked;
            Properties.Settings.Default.CheckBox08 = loserBracket04_2.Checked;
            Properties.Settings.Default.CheckBox09 = loserBracket05_1.Checked;
            Properties.Settings.Default.CheckBox10 = loserBracket05_2.Checked;
            Properties.Settings.Default.CheckBox11 = loserBracket06_1.Checked;
            Properties.Settings.Default.CheckBox12 = loserBracket06_2.Checked;
            Properties.Settings.Default.CheckBox13 = loserBracket07_1.Checked;
            Properties.Settings.Default.CheckBox14 = loserBracket07_2.Checked;
            Properties.Settings.Default.CheckBox15 = loserBracket08_1.Checked;
            Properties.Settings.Default.CheckBox16 = loserBracket08_2.Checked;
            Properties.Settings.Default.CheckBox17 = loserBracket09_1.Checked;
            Properties.Settings.Default.CheckBox18 = loserBracket09_2.Checked;
            Properties.Settings.Default.CheckBox19 = loserBracket10_1.Checked;
            Properties.Settings.Default.CheckBox20 = loserBracket10_2.Checked;
            Properties.Settings.Default.CheckBox21 = loserBracket11_1.Checked;
            Properties.Settings.Default.CheckBox22 = loserBracket11_2.Checked;
            Properties.Settings.Default.CheckBox23 = loserBracket12_1.Checked;
            Properties.Settings.Default.CheckBox24 = loserBracket12_2.Checked;
            Properties.Settings.Default.CheckBox25 = loserBracket13_1.Checked;
            Properties.Settings.Default.CheckBox26 = loserBracket13_2.Checked;
            Properties.Settings.Default.CheckBox27 = loserBracket14_1.Checked;
            Properties.Settings.Default.CheckBox28 = loserBracket14_2.Checked;
            Properties.Settings.Default.CheckBox29 = loserBracket15_1.Checked;
            Properties.Settings.Default.CheckBox30 = loserBracket15_2.Checked;
            Properties.Settings.Default.CheckBox31 = loserBracket16_1.Checked;
            Properties.Settings.Default.CheckBox32 = loserBracket16_2.Checked;
            Properties.Settings.Default.CheckBox33 = loserBracket17_1.Checked;
            Properties.Settings.Default.CheckBox34 = loserBracket17_2.Checked;
            Properties.Settings.Default.CheckBox35 = loserBracket18_1.Checked;
            Properties.Settings.Default.CheckBox36 = loserBracket18_2.Checked;
            Properties.Settings.Default.CheckBox37 = loserBracket19_1.Checked;
            Properties.Settings.Default.CheckBox38 = loserBracket19_2.Checked;
            Properties.Settings.Default.CheckBox39 = loserBracket20_1.Checked;
            Properties.Settings.Default.CheckBox40 = loserBracket20_2.Checked;
            Properties.Settings.Default.Save();
        }

        private void BuildWinnersExcel()
        {
            Cursor defaultCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            string filename = "default_filename";

            // if there is a week selected then create the file name
            if (PublicVariables.GetDefaultWeek != null)
            {
                filename = "Winners_Excel_" + PublicVariables.GetDefaultWeek;
            }

            // create the excel application
            Microsoft.Office.Interop.Excel.Application MyExcel = new Microsoft.Office.Interop.Excel.Application();
            // create the workbook
            Microsoft.Office.Interop.Excel.Workbook MyWorkbook = MyExcel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            // create the worksheet
            Microsoft.Office.Interop.Excel.Worksheet MyWorksheet;
            // create the cells
            Microsoft.Office.Interop.Excel.Range MyCells;

            MyExcel.StandardFont = "Arial";
            MyExcel.StandardFontSize = 12;

            // access the week 1 worksheet
            MyWorksheet = MyExcel.Worksheets.Item[1];
            // name it for the tab at the bottom
            if (PublicVariables.GetDefaultWeek != null)
            {
                MyWorksheet.Name = "Winners " + PublicVariables.GetDefaultWeek;
            }
            else
            {
                MyWorksheet.Name = "Winners";
            }

            // set the column widths to match moms
            MyWorksheet.Rows[41].RowHeight = 45;

            for (int i = 1; i <= 10; i++)
            {
                MyWorksheet.Columns[i].ColumnWidth = 6.57;
            }
            // access the cells
            MyCells = MyWorksheet.Cells;

            MyExcel.Cells[1, 1] = "Pool Name";
            MyExcel.Cells[1, 2] = "Real Name";
            MyExcel.Cells[1, 3] = "Payment Method";
            MyExcel.Cells[1, 4] = "Address";
            MyExcel.Cells[1, 5] = "Email";
            MyExcel.Cells[1, 6] = "Phone";
            MyExcel.Cells[1, 7] = "Notes";

            // storing each row and column value
            for (int i = 0; i < listViewStillInLive.Items.Count; i++)
            {
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    if (player.PlayerPoolName == listViewStillInLive.Items[i].SubItems[1].Text)
                    {
                        MyExcel.Cells[i + 2, 1] = player.PlayerPoolName;
                        MyExcel.Cells[i + 2, 2] = player.PlayerPersonalName;
                        MyExcel.Cells[i + 2, 3] = player.PlayerPayoutMethod;
                        MyExcel.Cells[i + 2, 4] = player.PlayerAddress;
                        MyExcel.Cells[i + 2, 5] = player.PlayerEmail;
                        MyExcel.Cells[i + 2, 6] = player.PlayerPhone;
                        MyExcel.Cells[i + 2, 7] = player.PlayerNotes;
                    }              
                }                
            }

            MyWorkbook.SaveAs(@"C:\Big8\" + filename + ".xls");

            Cursor.Current = defaultCursor;
            MessageBox.Show("File Created at: C:\\Big8" + Environment.NewLine + "Filename: " + filename);
            MyExcel.Visible = true;
        }

        private void BuildLabelsExcel()
        {
            Cursor defaultCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            string filename = "default_filename";

            // if there is a week selected then create the file name
            if (PublicVariables.GetDefaultWeek != null)
            {
                filename = "Labels_Excel_" + PublicVariables.GetDefaultWeek;
            }

            // create the excel application
            Microsoft.Office.Interop.Excel.Application MyExcel = new Microsoft.Office.Interop.Excel.Application();
            // create the workbook
            Microsoft.Office.Interop.Excel.Workbook MyWorkbook = MyExcel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            // create the worksheet
            Microsoft.Office.Interop.Excel.Worksheet MyWorksheet;
            // create the cells
            Microsoft.Office.Interop.Excel.Range MyCells;

            MyExcel.StandardFont = "Arial";
            MyExcel.StandardFontSize = 12;

            // access the week 1 worksheet
            MyWorksheet = MyExcel.Worksheets.Item[1];
            // name it for the tab at the bottom
            if (PublicVariables.GetDefaultWeek != null)
            {
                MyWorksheet.Name = "Winners_Labels_ " + PublicVariables.GetDefaultWeek;
            }
            else
            {
                MyWorksheet.Name = "Winners_Labels";
            }

            // set the rows up
            for (int i = 1; i < 20; i++)
            {
                // make the large row
                MyWorksheet.Rows[i].RowHeight = 67.5f;
                // increase to the next row
                i++;
                // make the smaller row
                MyWorksheet.Rows[i].RowHeight = 22.5f;
            }
            

            for (int i = 1; i <= 26; i++)
            {
                MyWorksheet.Columns[i].ColumnWidth = 34.44f;
            }

            // access the cells
            MyCells = MyWorksheet.Cells;

            // storing each row and column value
            // keep track of the column we are in
            int column = 1;
            int row = 1;

            for (int i = 0; i < listViewStillInLive.Items.Count; i++)
            {
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    if (player.PlayerPoolName == listViewStillInLive.Items[i].SubItems[1].Text)
                    {             
                                                        
                        MyExcel.Cells[row, column] = player.PlayerPoolName + Environment.NewLine + PublicVariables.GetDefaultWeek + " WINNER" + Environment.NewLine + "$" + totalPayOut.ToString();
                        MyExcel.Cells[row, column].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        MyExcel.Cells[row, column].VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                        if (row >= 19)
                        {
                            column++;
                            row = 1;
                        }
                        else
                        {
                            row += 2;
                        }
                    }
                }
            }

            MyWorkbook.SaveAs(@"C:\Big8\" + filename + ".xls");

            Cursor.Current = defaultCursor;
            MessageBox.Show("File Created at: C:\\Big8" + Environment.NewLine + "Filename: " + filename);
            MyExcel.Visible = true;
        }        
    }
}
