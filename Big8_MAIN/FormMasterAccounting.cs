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
    public partial class FormMasterAccounting : Form
    {
        public FormMasterAccounting()
        {
            InitializeComponent();

            this.Activated += FormMasterAccounting_Activated;

            listViewLedger.MouseDoubleClick += new MouseEventHandler(listViewLedger_DoubleClick);
            listViewTransactionWeek.MouseDoubleClick += new MouseEventHandler(listViewTransactionWeek_DoubleClick);
        }

        private void accountingBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.accountingBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.accountingDataSet);

        }

        private void listViewLedger_DoubleClick(object sender, MouseEventArgs e)
        {
            OpenTransactionDetailsWindow("MainLedger");
        }

        private void listViewTransactionWeek_DoubleClick(object sender, MouseEventArgs e)
        {
            OpenTransactionDetailsWindow("WeekLedger");
        }

        private void FormMasterAccounting_Activated(object sender, EventArgs e)
        {

        }

        private void FormMasterAccounting_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'transactionsDBDataSet.Transactions' table. You can move, or remove it, as needed.
            this.transactionsTableAdapter.Fill(this.transactionsDBDataSet.Transactions);
            // TODO: This line of code loads data into the 'accountingDataSet.Accounting' table. You can move, or remove it, as needed.
            this.accountingTableAdapter.Fill(this.accountingDataSet.Accounting);
        }

        private void GetLedgers(string selectedType)
        {
            // cycle each transaction
            foreach (TransactionsDBDataSet.TransactionsRow transaction in transactionsDBDataSet.Transactions)
            {
                CreateTransactionRow(transaction, selectedType);
            }
        }

        private void GetTransactionWeek(string selectedWeek)
        {
            foreach (TransactionsDBDataSet.TransactionsRow transaction in transactionsDBDataSet.Transactions)
            {
                CreateTransactionWeekRow(transaction, selectedWeek);
            }
        }

        private void CreateTransactionWeekRow(TransactionsDBDataSet.TransactionsRow transaction, string selectedWeek)
        {
            ListViewItem newRow = new ListViewItem();

            if (PublicVariables.GetDefaultSeason != null)
            {
                if (transaction.SeasonName == PublicVariables.GetDefaultSeason)
                {
                    newRow.Text = transaction.Id.ToString();
                    newRow.SubItems.Add(transaction.PlayerName);
                    newRow.SubItems.Add(transaction.Method);

                    if (transaction.Type == "Interest")
                    {
                        newRow.SubItems.Add(transaction.Interest.ToString());
                    }
                    else
                    {
                        newRow.SubItems.Add(transaction.Amount.ToString());
                    }

                    if (transaction.Week != "")
                    {
                        if (transaction.Week == "Week 01" && selectedWeek == "Week 01")
                        {
                            listViewTransactionWeek.Items.Add(newRow);
                        }
                        if (transaction.Week == "Week 02" && selectedWeek == "Week 02")
                        {
                            listViewTransactionWeek.Items.Add(newRow);
                        }
                        if (transaction.Week == "Week 03" && selectedWeek == "Week 03")
                        {
                            listViewTransactionWeek.Items.Add(newRow);
                        }
                        if (transaction.Week == "Week 04" && selectedWeek == "Week 04")
                        {
                            listViewTransactionWeek.Items.Add(newRow);
                        }
                        if (transaction.Week == "Week 05" && selectedWeek == "Week 05")
                        {
                            listViewTransactionWeek.Items.Add(newRow);
                        }
                        if (transaction.Week == "Week 06" && selectedWeek == "Week 06")
                        {
                            listViewTransactionWeek.Items.Add(newRow);
                        }
                        if (transaction.Week == "Week 07" && selectedWeek == "Week 07")
                        {
                            listViewTransactionWeek.Items.Add(newRow);
                        }
                        if (transaction.Week == "Week 08" && selectedWeek == "Week 08")
                        {
                            listViewTransactionWeek.Items.Add(newRow);
                        }
                        if (transaction.Week == "Week 09" && selectedWeek == "Week 09")
                        {
                            listViewTransactionWeek.Items.Add(newRow);
                        }
                        if (transaction.Week == "Week 10" && selectedWeek == "Week 10")
                        {
                            listViewTransactionWeek.Items.Add(newRow);
                        }
                        if (transaction.Week == "Week 11" && selectedWeek == "Week 11")
                        {
                            listViewTransactionWeek.Items.Add(newRow);
                        }
                        if (transaction.Week == "Week 12" && selectedWeek == "Week 12")
                        {
                            listViewTransactionWeek.Items.Add(newRow);
                        }
                        if (transaction.Week == "Week 13" && selectedWeek == "Week 13")
                        {
                            listViewTransactionWeek.Items.Add(newRow);
                        }
                        if (transaction.Week == "Week 14" && selectedWeek == "Week 14")
                        {
                            listViewTransactionWeek.Items.Add(newRow);
                        }
                        if (transaction.Week == "Week 15" && selectedWeek == "Week 15")
                        {
                            listViewTransactionWeek.Items.Add(newRow);
                        }
                        if (transaction.Week == "Week 16" && selectedWeek == "Week 16")
                        {
                            listViewTransactionWeek.Items.Add(newRow);
                        }
                        if (transaction.Week == "Week 17" && selectedWeek == "Week 17")
                        {
                            listViewTransactionWeek.Items.Add(newRow);
                        }
                    }
                }
            }
        }

        private void CreateTransactionRow(TransactionsDBDataSet.TransactionsRow transaction, string selectedType)
        {
            ListViewItem newRow = new ListViewItem();

            if (PublicVariables.GetDefaultSeason != null)
            {
                if (transaction.SeasonName == PublicVariables.GetDefaultSeason)
                {
                    newRow.Text = transaction.Id.ToString();
                    newRow.SubItems.Add(transaction.PlayerName);
                    newRow.SubItems.Add(transaction.Method);
                    if (transaction.Type == "Interest")
                    {
                        newRow.SubItems.Add(transaction.Interest.ToString());
                    }
                    else
                    {
                        newRow.SubItems.Add(transaction.Amount.ToString());
                    }

                    if (transaction.Type == "Receive Payment" && selectedType == "Receive Payment" || transaction.Type == "Initial Payment" && selectedType == "Receive Payment")
                    {
                        listViewLedger.Items.Add(newRow);
                    }
                    if (transaction.Type == "Pay Out" && selectedType == "Pay Out")
                    {
                        listViewLedger.Items.Add(newRow);
                    }
                    if (transaction.Type == "Charge" && selectedType == "Charge")
                    {
                        listViewLedger.Items.Add(newRow);
                    }
                    if (transaction.Type == "Interest" && selectedType == "Interest")
                    {
                        listViewLedger.Items.Add(newRow);
                    }
                    if (transaction.Type == "Win Credit" && selectedType == "Win Credit")
                    {
                        listViewLedger.Items.Add(newRow);
                    }
                }
            }
        }

        private void OpenTransactionDetailsWindow(string whichLedgerWindow)
        {
            foreach (TransactionsDBDataSet.TransactionsRow selectedTransaction in transactionsDBDataSet.Transactions)
            {
                if (whichLedgerWindow == "MainLedger")
                {
                    if (selectedTransaction.Id.ToString() == listViewLedger.FocusedItem.Text)
                    {
                        PublicVariables.PublicTransactionId = selectedTransaction.Id;
                    }
                }
                if (whichLedgerWindow == "WeekLedger")
                {
                    if (selectedTransaction.Id.ToString() == listViewTransactionWeek.FocusedItem.Text)
                    {
                        PublicVariables.PublicTransactionId = selectedTransaction.Id;
                    }
                }
            }

            // check to see if the form is open
            if ((System.Windows.Forms.Application.OpenForms["FormTransactionDetails"] as FormTransactionDetails) != null)
            {
                // if it is then select the right form
                foreach (Form form in System.Windows.Forms.Application.OpenForms)
                {
                    if (form.Name == "FormTransactionDetails")
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
                FormTransactionDetails formTransactionDetails = new FormTransactionDetails();
                formTransactionDetails.Show();
            }

        }

        private void comboBoxSelectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewLedger.Items.Clear();
            GetLedgers(comboBoxSelectType.Text);
        }

        private void comboBoxTransactionWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewTransactionWeek.Items.Clear();
            GetTransactionWeek(comboBoxTransactionWeek.Text);
        }
    }
}
