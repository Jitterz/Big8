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
    public partial class FormMasterSheet : Form
    {
        public FormMasterSheet()
        {
            InitializeComponent();
        }

        private void playersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.playersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.playersDBDataSet);

        }

        private void FormMasterSheet_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'seasonsDBDataSet.Seasons6_10' table. You can move, or remove it, as needed.
            this.seasons6_10TableAdapter.Fill(this.seasonsDBDataSet.Seasons6_10);
            // TODO: This line of code loads data into the 'seasonsDBDataSet.Seasons11_17' table. You can move, or remove it, as needed.
            this.seasons11_17TableAdapter.Fill(this.seasonsDBDataSet.Seasons11_17);
            // TODO: This line of code loads data into the 'seasonsDBDataSet.Seasons1_5' table. You can move, or remove it, as needed.
            this.seasons1_5TableAdapter.Fill(this.seasonsDBDataSet.Seasons1_5);
            // TODO: This line of code loads data into the 'playersDBDataSet.Players' table. You can move, or remove it, as needed.
            this.playersTableAdapter.Fill(this.playersDBDataSet.Players);
            //playersDataGridView.Sort(playersDataGridView.Columns[0], ListSortDirection.Descending);
        }

        private void buttonExportMasterSheet_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = @"C:\Big8";
            saveFileDialog.Title = "Export Master Sheet to Excel";
            saveFileDialog.FileName = "Master_Sheet";
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
                    if (Convert.ToBoolean(playersDataGridView.Rows[i].Cells["IsActive"].Value) == true)
                    {
                        for (int j = 0; j < playersDataGridView.Columns.Count; j++)
                        {
                            excelApp.Cells[i + 2, j + 1] = playersDataGridView.Rows[i].Cells[j].Value.ToString();
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
