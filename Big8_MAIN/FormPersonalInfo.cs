using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Big8_MAIN
{
    public partial class FormPersonalInfo : Form
    {
        public FormPersonalInfo()
        {
            InitializeComponent();
        }

        private void playersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.playersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.playersDBDataSet);

        }

        private void FormPersonalInfo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'playersDBDataSet.Players' table. You can move, or remove it, as needed.
            this.playersTableAdapter.Fill(this.playersDBDataSet.Players);

            UpdatePlayerList();
        }

        private void buttonExportPersonalInfo_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = @"C:\Big8";
            saveFileDialog.Title = "Export Personal Info to Excel";
            saveFileDialog.FileName = "Personal_Info";
            saveFileDialog.Filter = "Excel Files(2003) | *.xls|Excel Files(2007) | *.xlsx";
            string fileName = saveFileDialog.FileName;

            if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Application.Workbooks.Add(Type.Missing);

                // storing the headers in excel
                for (int i = 1; i < playersDataGridView.Columns.Count + 1; i++)
                {
                    excelApp.Cells[1, i] = playersDataGridView.Columns[i - 1].HeaderText;
                }

                // storing each row and column value
                for (int i = 0; i < playersDataGridView.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < playersDataGridView.Columns.Count; j++)
                    {
                        excelApp.Cells[i + 2, j + 1] = playersDataGridView.Rows[i].Cells[j].Value.ToString();
                    }
                }

                // save the excel file
                Cursor defaultCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                excelApp.ActiveWorkbook.SaveCopyAs(saveFileDialog.FileName.ToString());
                excelApp.ActiveWorkbook.Saved = true;
                excelApp.Quit();
                Cursor.Current = defaultCursor;
                MessageBox.Show(fileName + " saved sucessfully!");

                Process.Start(saveFileDialog.FileName);
            }
        }

        private void listBoxSelectPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxSelectPlayer.SelectedIndex != -1)
            {
                foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                {
                    if (listBoxSelectPlayer.SelectedItem.ToString() == player.PlayerPersonalName)
                    {
                        labelPlayerPoolName.Text = player.PlayerPoolName;
                    }
                }
            }
        }

        private void textBoxSearchPlayer_TextChanged(object sender, EventArgs e)
        {
            // found the Cast<string>.ToArray() basically it creates an array so I can edit it without
            // screwing up the foreach loop. Makes a copy of the list of names in the listbox.
            // then i can remove the name but the listbox items arent really affected.
            foreach (string removeString in listBoxSelectPlayer.Items.Cast<string>().ToArray())
            {
                // if any of the player names dont match the text then remove them.
                if (!removeString.StartsWith(textBoxSearchPlayer.Text, StringComparison.CurrentCultureIgnoreCase))
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

        private void UpdatePlayerList()
        {
            listBoxSelectPlayer.Items.Clear();

            foreach (PlayersDBDataSet.PlayersRow players in playersDBDataSet.Players)
            {
                listBoxSelectPlayer.Items.Add(players.PlayerPersonalName);
            }
        }
    }
}
