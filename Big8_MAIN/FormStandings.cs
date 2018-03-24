using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Big8_MAIN
{
    public partial class FormStandings : Form
    {
        public FormStandings()
        {
            InitializeComponent();
        }

        private void playersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.playersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.playersDBDataSet);

        }

        private void FormStandings_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'playersDBDataSet.Players' table. You can move, or remove it, as needed.
            this.playersTableAdapter.Fill(this.playersDBDataSet.Players);
            playersDataGridView.Sort(playersDataGridView.Columns[0], ListSortDirection.Descending);
        }

        private void buttonExportStandings_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = @"C:\Big8";
            saveFileDialog.Title = "Export Player Standings to Excel";
            saveFileDialog.FileName = "Player_Standings";
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
                        foreach (PlayersDBDataSet.PlayersRow player in playersDBDataSet.Players)
                        {
                            if (player.PlayerPoolName == playersDataGridView.Rows[i].Cells[1].Value.ToString() && player.IsActive == true)
                            {
                                excelApp.Cells[i + 2, j + 1] = playersDataGridView.Rows[i].Cells[j].Value.ToString();
                            }
                        }                        
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
    }
}
