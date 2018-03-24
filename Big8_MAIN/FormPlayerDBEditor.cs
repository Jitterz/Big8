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
    public partial class FormPlayerDBEditor : Form
    {
        public FormPlayerDBEditor()
        {
            InitializeComponent();

            this.playersDataGridView.DataError += this.DataGridView_DataError;
            label1.Text = "The database for the Seasons is split into three because they are so large. They are split bewtween weeks 1-5 then weeks 6-10 and then weeks 11-17.\n If you want to change the name of a season here, you must make the same change for all three.\n Just the actual SeasonName. The box with weeks 1-5 also contains the max picks data for ALL weeks.";
        }

        void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            MessageBox.Show("There was an error.\n \n Most Likely wrong input entered. You cannot enter letters where numbers belong MOM. \n \n Error Details (This is what I need to see to help): \n \n" + e.Exception.InnerException);
        }

        private void playersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.playersBindingSource.EndEdit();
            this.seasons1_5BindingSource.EndEdit();
            this.seasons6_10BindingSource.EndEdit();
            this.seasons11_17BindingSource.EndEdit();
            this.seasons1_5TableAdapter.Update(this.seasonsDBDataSet.Seasons1_5);
            this.seasons6_10TableAdapter.Update(this.seasonsDBDataSet.Seasons6_10);
            this.seasons11_17TableAdapter.Update(this.seasonsDBDataSet.Seasons11_17);
            this.tableAdapterManager.UpdateAll(this.playersDBDataSet);

        }

        private void FormPlayerDBEditor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'seasonsDBDataSet.Seasons11_17' table. You can move, or remove it, as needed.
            this.seasons11_17TableAdapter.Fill(this.seasonsDBDataSet.Seasons11_17);
            // TODO: This line of code loads data into the 'seasonsDBDataSet.Seasons6_10' table. You can move, or remove it, as needed.
            this.seasons6_10TableAdapter.Fill(this.seasonsDBDataSet.Seasons6_10);
            // TODO: This line of code loads data into the 'seasonsDBDataSet.Seasons1_5' table. You can move, or remove it, as needed.
            this.seasons1_5TableAdapter.Fill(this.seasonsDBDataSet.Seasons1_5);
            // TODO: This line of code loads data into the 'playersDBDataSet.Players' table. You can move, or remove it, as needed.
            this.playersTableAdapter.Fill(this.playersDBDataSet.Players);

        }
    }
}
