namespace Big8_MAIN
{
    partial class FormHouseLedger
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelAccountingText = new System.Windows.Forms.Label();
            this.listViewHouseLedger = new System.Windows.Forms.ListView();
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PlayerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TransType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Balance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.transactionsDBDataSet = new Big8_MAIN.TransactionsDBDataSet();
            this.transactionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transactionsTableAdapter = new Big8_MAIN.TransactionsDBDataSetTableAdapters.TransactionsTableAdapter();
            this.tableAdapterManager = new Big8_MAIN.TransactionsDBDataSetTableAdapters.TableAdapterManager();
            this.buttonExportExcel = new System.Windows.Forms.Button();
            this.progressBarExport = new System.Windows.Forms.ProgressBar();
            this.TransMethod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.transactionsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAccountingText
            // 
            this.labelAccountingText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAccountingText.AutoSize = true;
            this.labelAccountingText.Font = new System.Drawing.Font("Blue Highway Condensed", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAccountingText.ForeColor = System.Drawing.SystemColors.Control;
            this.labelAccountingText.Location = new System.Drawing.Point(297, 2);
            this.labelAccountingText.Name = "labelAccountingText";
            this.labelAccountingText.Size = new System.Drawing.Size(226, 62);
            this.labelAccountingText.TabIndex = 5;
            this.labelAccountingText.Text = "House Ledger";
            // 
            // listViewHouseLedger
            // 
            this.listViewHouseLedger.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewHouseLedger.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listViewHouseLedger.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Date,
            this.ID,
            this.PlayerName,
            this.TransType,
            this.TransMethod,
            this.Amount,
            this.Balance});
            this.listViewHouseLedger.Location = new System.Drawing.Point(12, 67);
            this.listViewHouseLedger.Name = "listViewHouseLedger";
            this.listViewHouseLedger.Size = new System.Drawing.Size(801, 446);
            this.listViewHouseLedger.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewHouseLedger.TabIndex = 6;
            this.listViewHouseLedger.UseCompatibleStateImageBehavior = false;
            this.listViewHouseLedger.View = System.Windows.Forms.View.Details;
            // 
            // Date
            // 
            this.Date.Text = "Date";
            this.Date.Width = 123;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 51;
            // 
            // PlayerName
            // 
            this.PlayerName.Text = "Player Name";
            this.PlayerName.Width = 186;
            // 
            // TransType
            // 
            this.TransType.Text = "Transaction Type";
            this.TransType.Width = 146;
            // 
            // Amount
            // 
            this.Amount.Text = "Amount";
            this.Amount.Width = 85;
            // 
            // Balance
            // 
            this.Balance.Text = "Balance";
            this.Balance.Width = 101;
            // 
            // transactionsDBDataSet
            // 
            this.transactionsDBDataSet.DataSetName = "TransactionsDBDataSet";
            this.transactionsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // transactionsBindingSource
            // 
            this.transactionsBindingSource.DataMember = "Transactions";
            this.transactionsBindingSource.DataSource = this.transactionsDBDataSet;
            // 
            // transactionsTableAdapter
            // 
            this.transactionsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.TransactionsTableAdapter = this.transactionsTableAdapter;
            this.tableAdapterManager.UpdateOrder = Big8_MAIN.TransactionsDBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // buttonExportExcel
            // 
            this.buttonExportExcel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonExportExcel.BackColor = System.Drawing.Color.DarkBlue;
            this.buttonExportExcel.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold);
            this.buttonExportExcel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonExportExcel.Location = new System.Drawing.Point(684, 529);
            this.buttonExportExcel.Name = "buttonExportExcel";
            this.buttonExportExcel.Size = new System.Drawing.Size(129, 29);
            this.buttonExportExcel.TabIndex = 20;
            this.buttonExportExcel.Text = "Export to Excel";
            this.buttonExportExcel.UseVisualStyleBackColor = false;
            this.buttonExportExcel.Click += new System.EventHandler(this.buttonExportExcel_Click);
            // 
            // progressBarExport
            // 
            this.progressBarExport.BackColor = System.Drawing.Color.White;
            this.progressBarExport.ForeColor = System.Drawing.Color.Lime;
            this.progressBarExport.Location = new System.Drawing.Point(498, 529);
            this.progressBarExport.Maximum = 10000;
            this.progressBarExport.Name = "progressBarExport";
            this.progressBarExport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.progressBarExport.RightToLeftLayout = true;
            this.progressBarExport.Size = new System.Drawing.Size(180, 29);
            this.progressBarExport.Step = 1;
            this.progressBarExport.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarExport.TabIndex = 21;
            this.progressBarExport.Visible = false;
            // 
            // TransMethod
            // 
            this.TransMethod.Text = "Transaction Method";
            this.TransMethod.Width = 125;
            // 
            // FormHouseLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(825, 570);
            this.Controls.Add(this.progressBarExport);
            this.Controls.Add(this.buttonExportExcel);
            this.Controls.Add(this.listViewHouseLedger);
            this.Controls.Add(this.labelAccountingText);
            this.Name = "FormHouseLedger";
            this.Text = "House Ledger";
            this.Load += new System.EventHandler(this.FormHouseLedger_Load);
            ((System.ComponentModel.ISupportInitialize)(this.transactionsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAccountingText;
        private System.Windows.Forms.ListView listViewHouseLedger;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader PlayerName;
        private System.Windows.Forms.ColumnHeader TransType;
        private System.Windows.Forms.ColumnHeader Amount;
        private System.Windows.Forms.ColumnHeader Balance;
        private TransactionsDBDataSet transactionsDBDataSet;
        private System.Windows.Forms.BindingSource transactionsBindingSource;
        private TransactionsDBDataSetTableAdapters.TransactionsTableAdapter transactionsTableAdapter;
        private TransactionsDBDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.Button buttonExportExcel;
        private System.Windows.Forms.ProgressBar progressBarExport;
        private System.Windows.Forms.ColumnHeader TransMethod;
    }
}