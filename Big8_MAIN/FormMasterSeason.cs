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
    public partial class FormMasterSeason : Form
    {
        public FormMasterSeason()
        {
            InitializeComponent();
        }

        private void seasons1_5BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.seasons1_5BindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.seasonsDBDataSet);

        }

        private void FormMasterSeason_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'seasonsDBDataSet.Seasons11_17' table. You can move, or remove it, as needed.
            this.seasons11_17TableAdapter.Fill(this.seasonsDBDataSet.Seasons11_17);
            // TODO: This line of code loads data into the 'seasonsDBDataSet.Seasons6_10' table. You can move, or remove it, as needed.
            this.seasons6_10TableAdapter.Fill(this.seasonsDBDataSet.Seasons6_10);
            // TODO: This line of code loads data into the 'seasonsDBDataSet.Seasons1_5' table. You can move, or remove it, as needed.
            this.seasons1_5TableAdapter.Fill(this.seasonsDBDataSet.Seasons1_5);

        }

        private void buttonExportWeeks1_5_Click(object sender, EventArgs e)
        {
            //season database weeks 1-5
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = @"C:\Big8";
            saveFileDialog.Title = "Export Master Season 1-5 to Excel";
            saveFileDialog.FileName = "Master_Season_1_5";
            saveFileDialog.Filter = "Excel Files(2003) | *.xls|Excel Files(2007) | *.xlsx";
            string fileName = saveFileDialog.FileName;

            if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Application.Workbooks.Add(Type.Missing);

                // storing the headers in excel
                for (int i = 1; i < seasons1_5DataGridView.Columns.Count + 1; i++)
                {
                    excelApp.Cells[1, i] = seasons1_5DataGridView.Columns[i - 1].HeaderText;
                }

                // storing each row and column value
                for (int i = 0; i < seasons1_5DataGridView.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < seasons1_5DataGridView.Columns.Count; j++)
                    {
                        excelApp.Cells[i + 2, j + 1] = seasons1_5DataGridView.Rows[i].Cells[j].Value.ToString();
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

        private void buttonExportWeeks6_10_Click(object sender, EventArgs e)
        {
            //season database weeks 6-10
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = @"C:\Big8";
            saveFileDialog.Title = "Export Master Season 1-5 to Excel";
            saveFileDialog.FileName = "Master_Season_6_10";
            saveFileDialog.Filter = "Excel Files(2003) | *.xls|Excel Files(2007) | *.xlsx";
            string fileName = saveFileDialog.FileName;

            if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Application.Workbooks.Add(Type.Missing);

                // storing the headers in excel
                for (int i = 1; i < seasons6_10DataGridView.Columns.Count + 1; i++)
                {
                    excelApp.Cells[1, i] = seasons6_10DataGridView.Columns[i - 1].HeaderText;
                }

                // storing each row and column value
                for (int i = 0; i < seasons6_10DataGridView.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < seasons6_10DataGridView.Columns.Count; j++)
                    {
                        excelApp.Cells[i + 2, j + 1] = seasons6_10DataGridView.Rows[i].Cells[j].Value.ToString();
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

        private void buttonExportWeeks11_17_Click(object sender, EventArgs e)
        {
            //season database weeks 11-17
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = @"C:\Big8";
            saveFileDialog.Title = "Export Master Season 11-17 to Excel";
            saveFileDialog.FileName = "Master_Season_11_17";
            saveFileDialog.Filter = "Excel Files(2003) | *.xls|Excel Files(2007) | *.xlsx";
            string fileName = saveFileDialog.FileName;

            if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Application.Workbooks.Add(Type.Missing);

                // storing the headers in excel
                for (int i = 1; i < seasons11_17DataGridView.Columns.Count + 1; i++)
                {
                    excelApp.Cells[1, i] = seasons11_17DataGridView.Columns[i - 1].HeaderText;
                }

                // storing each row and column value
                for (int i = 0; i < seasons11_17DataGridView.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < seasons11_17DataGridView.Columns.Count; j++)
                    {
                        excelApp.Cells[i + 2, j + 1] = seasons11_17DataGridView.Rows[i].Cells[j].Value.ToString();
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
