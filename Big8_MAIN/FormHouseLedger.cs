using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.Office.Interop.Excel;

namespace Big8_MAIN
{
    public partial class FormHouseLedger : Form
    {
        public FormHouseLedger()
        {
            InitializeComponent();
        }

        private void transactionsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.transactionsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.transactionsDBDataSet);

        }

        private void FormHouseLedger_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'transactionsDBDataSet.Transactions' table. You can move, or remove it, as needed.
            this.transactionsTableAdapter.Fill(this.transactionsDBDataSet.Transactions);
            PopulateLedger();
        }

        private void PopulateLedger()
        {
            double balance = 0;
            listViewHouseLedger.Items.Clear();

            foreach (TransactionsDBDataSet.TransactionsRow transaction in transactionsDBDataSet.Transactions)
            {
                if (transaction.SeasonName == PublicVariables.GetDefaultSeason)
                {
                    if (transaction.Type == "Pay Out" || transaction.Type == "Receive Payment" || transaction.Type == "Initial Payment")
                    {
                        ListViewItem newRow = new ListViewItem();

                        // the first column is different than the sub items
                        // newRow.Text will fill the first column
                        newRow.Text = transaction.Date;
                        newRow.SubItems.Add(transaction.Id.ToString());
                        newRow.SubItems.Add(transaction.PlayerName);
                        newRow.SubItems.Add(transaction.Type);
                        newRow.SubItems.Add(transaction.Method);
                        transaction.Amount *= -1;
                        newRow.SubItems.Add(transaction.Amount.ToString());
                        balance += transaction.Amount;
                        newRow.SubItems.Add(balance.ToString());

                        listViewHouseLedger.Items.Add(newRow);
                    }
                }

                listViewHouseLedger.Sort();
            }
        }

        private void ExportToExcel()
        {
            string filename = "House_Ledger";

            // create the excel application
            Microsoft.Office.Interop.Excel.Application MyExcel = new Microsoft.Office.Interop.Excel.Application();
            // create the workbook
            Microsoft.Office.Interop.Excel.Workbook MyWorkbook = MyExcel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            // create the worksheets
            Microsoft.Office.Interop.Excel.Worksheet MyWorksheetWeek01;

            // create the cells
            Microsoft.Office.Interop.Excel.Range MyCells;

            MyExcel.StandardFont = "Arial";
            MyExcel.StandardFontSize = 12;

            // access the week 1 worksheet
            MyWorksheetWeek01 = MyExcel.Worksheets.Item[1];
            // name it for the tab at the bottom
            MyWorksheetWeek01.Name = "House Ledger";
            // set the column widths to match moms
            MyWorksheetWeek01.Columns["A"].ColumnWidth = 16;
            MyWorksheetWeek01.Columns["B"].ColumnWidth = 9;
            MyWorksheetWeek01.Columns["C"].ColumnWidth = 26;
            MyWorksheetWeek01.Columns["D"].ColumnWidth = 23;
            MyWorksheetWeek01.Columns["E"].ColumnWidth = 23;
            MyWorksheetWeek01.Columns["F"].ColumnWidth = 12;
            MyWorksheetWeek01.Columns["G"].ColumnWidth = 12;

            // access the cells
            MyCells = MyWorksheetWeek01.Cells;

            // create the column headers
            MyCells.Item[1, "A"].Value = "Date";
            MyCells.Item[1, "B"].Value = "Id";
            MyCells.Item[1, "C"].Value = "Player Name";
            MyCells.Item[1, "D"].Value = "Transaction Type";
            MyCells.Item[1, "E"].Value = "Transaction Method";
            MyCells.Item[1, "F"].Value = "Amount";
            MyCells.Item[1, "G"].Value = "Balance";

            // add the auto filter maybe
            Range oRng = MyWorksheetWeek01.get_Range("A1", "G1");
            oRng.AutoFilter(1, Type.Missing, XlAutoFilterOperator.xlAnd, Type.Missing, true);

            progressBarExport.Maximum = listViewHouseLedger.Items.Count;

            for (int i = 0; i < listViewHouseLedger.Items.Count; i++)
            {
                MyCells.Item[(i) + 2, "A"].Value = listViewHouseLedger.Items[i].Text;
                MyCells.Item[(i) + 2, "B"].Value = listViewHouseLedger.Items[i].SubItems[1].Text;
                MyCells.Item[(i) + 2, "C"].Value = listViewHouseLedger.Items[i].SubItems[2].Text;
                MyCells.Item[(i) + 2, "D"].Value = listViewHouseLedger.Items[i].SubItems[3].Text;
                MyCells.Item[(i) + 2, "E"].Value = listViewHouseLedger.Items[i].SubItems[4].Text;
                MyCells.Item[(i) + 2, "F"].Value = listViewHouseLedger.Items[i].SubItems[5].Text;
                MyCells.Item[(i) + 2, "G"].Value = listViewHouseLedger.Items[i].SubItems[6].Text;
                progressBarExport.PerformStep();
            }

            // --------------------------------------------------- END SAVE THE EXCEL FILE ----------------------------------------///
            MyWorkbook.SaveAs(@"C:\Big8\" + filename + ".xls");

            MessageBox.Show("File Created at: C:\\Big8" + Environment.NewLine + "Filename: " + filename);

            MyExcel.Visible = true;
        }

        private void buttonExportExcel_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            progressBarExport.Visible = true;
            ExportToExcel();
            progressBarExport.Visible = false;
            Cursor.Current = Cursors.Default;
        }
    }
}
