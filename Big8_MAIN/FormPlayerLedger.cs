using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Big8_MAIN
{
    public partial class FormPlayerLedger : Form
    {
        Bitmap memoryImage;
        private PrintDocument printDocument1 = new PrintDocument();

        public FormPlayerLedger()
        {
            InitializeComponent();

            listViewLedgerBox.MouseDoubleClick += new MouseEventHandler(listViewLedgerBox_DoubleClick);
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
        }

        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }

        private void printDocument1_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }


        private void playersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.playersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.playersDBDataSet);

        }

        private void listViewLedgerBox_DoubleClick(object sender, MouseEventArgs e)
        {
            OpenTransactionDetailsWindow();
        }

        private void FormPlayerLedger_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'transactionsDBDataSet.Transactions' table. You can move, or remove it, as needed.
            this.transactionsTableAdapter.Fill(this.transactionsDBDataSet.Transactions);
            // TODO: This line of code loads data into the 'playersDBDataSet.Players' table. You can move, or remove it, as needed.
            this.playersTableAdapter.Fill(this.playersDBDataSet.Players);

            PopulateLedgerBox(PublicVariables.PlayerPublicLedger);
            PopulatePersonalInfoBoxes(PublicVariables.PlayerPublicLedger);
        }

        private void PopulateLedgerBox(PlayersDBDataSet.PlayersRow player)
        {
            // clear the box
            listViewLedgerBox.Items.Clear();
            double balance = 0;

            foreach (TransactionsDBDataSet.TransactionsRow transactions in transactionsDBDataSet.Transactions)
            {
                if (transactions.PlayerName == player.PlayerPoolName)
                {
                    ListViewItem newRow = new ListViewItem();

                    // the first column is different than the sub items
                    // newRow.Text will fill the first column
                    newRow.Text = transactions.Id.ToString();
                    newRow.SubItems.Add(transactions.SeasonName);
                    newRow.SubItems.Add(transactions.Date);
                    newRow.SubItems.Add(transactions.Type);
                    newRow.SubItems.Add(transactions.Method);
                    newRow.SubItems.Add(transactions.Amount.ToString());
                    balance += transactions.Amount;
                    newRow.SubItems.Add(balance.ToString());

                    listViewLedgerBox.Items.Add(newRow);
                }
            }      
        }

        private void PopulatePersonalInfoBoxes(PlayersDBDataSet.PlayersRow player)
        {
            textBoxPlayerInformation.Text = player.PlayerPoolName + Environment.NewLine + player.PlayerPersonalName + Environment.NewLine + player.PlayerAddress;

            textBoxPlayerContactInfo.Text = "PH: " + player.PlayerPhone + Environment.NewLine + "Email: " + player.PlayerEmail + Environment.NewLine + "Prefered Contact: " + player.PlayerContactMethod;
        }

        private void OpenTransactionDetailsWindow()
        {
            foreach (TransactionsDBDataSet.TransactionsRow selectedTransaction in transactionsDBDataSet.Transactions)
            {
                if (selectedTransaction.Id.ToString() == listViewLedgerBox.FocusedItem.Text)
                {
                    PublicVariables.PublicTransactionId = selectedTransaction.Id;
                }
            }

            // check to see if the form is open
            if ((Application.OpenForms["FormTransactionDetails"] as FormTransactionDetails) != null)
            {
                // if it is then select the right form
                foreach (Form form in Application.OpenForms)
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

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            printDocument1.Print();
        }
    }
}
