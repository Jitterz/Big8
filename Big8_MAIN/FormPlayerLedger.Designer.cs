namespace Big8_MAIN
{
    partial class FormPlayerLedger
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
            this.textBoxPlayerInformation = new System.Windows.Forms.TextBox();
            this.playersDBDataSet = new Big8_MAIN.PlayersDBDataSet();
            this.playersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.playersTableAdapter = new Big8_MAIN.PlayersDBDataSetTableAdapters.PlayersTableAdapter();
            this.tableAdapterManager = new Big8_MAIN.PlayersDBDataSetTableAdapters.TableAdapterManager();
            this.transactionsDBDataSet = new Big8_MAIN.TransactionsDBDataSet();
            this.transactionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transactionsTableAdapter = new Big8_MAIN.TransactionsDBDataSetTableAdapters.TransactionsTableAdapter();
            this.tableAdapterManager1 = new Big8_MAIN.TransactionsDBDataSetTableAdapters.TableAdapterManager();
            this.textBoxPlayerContactInfo = new System.Windows.Forms.TextBox();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.labelAccountingText = new System.Windows.Forms.Label();
            this.listViewLedgerBox = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.playersDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxPlayerInformation
            // 
            this.textBoxPlayerInformation.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPlayerInformation.Location = new System.Drawing.Point(9, 11);
            this.textBoxPlayerInformation.Multiline = true;
            this.textBoxPlayerInformation.Name = "textBoxPlayerInformation";
            this.textBoxPlayerInformation.Size = new System.Drawing.Size(260, 119);
            this.textBoxPlayerInformation.TabIndex = 1;
            // 
            // playersDBDataSet
            // 
            this.playersDBDataSet.DataSetName = "PlayersDBDataSet";
            this.playersDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // playersBindingSource
            // 
            this.playersBindingSource.DataMember = "Players";
            this.playersBindingSource.DataSource = this.playersDBDataSet;
            // 
            // playersTableAdapter
            // 
            this.playersTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.PlayersTableAdapter = this.playersTableAdapter;
            this.tableAdapterManager.UpdateOrder = Big8_MAIN.PlayersDBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
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
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.TransactionsTableAdapter = this.transactionsTableAdapter;
            this.tableAdapterManager1.UpdateOrder = Big8_MAIN.TransactionsDBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // textBoxPlayerContactInfo
            // 
            this.textBoxPlayerContactInfo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPlayerContactInfo.Location = new System.Drawing.Point(292, 11);
            this.textBoxPlayerContactInfo.Multiline = true;
            this.textBoxPlayerContactInfo.Name = "textBoxPlayerContactInfo";
            this.textBoxPlayerContactInfo.Size = new System.Drawing.Size(251, 119);
            this.textBoxPlayerContactInfo.TabIndex = 2;
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(705, 585);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(75, 23);
            this.buttonPrint.TabIndex = 3;
            this.buttonPrint.Text = "Print";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // labelAccountingText
            // 
            this.labelAccountingText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAccountingText.AutoSize = true;
            this.labelAccountingText.Font = new System.Drawing.Font("Blue Highway Condensed", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAccountingText.ForeColor = System.Drawing.SystemColors.Control;
            this.labelAccountingText.Location = new System.Drawing.Point(607, 47);
            this.labelAccountingText.Name = "labelAccountingText";
            this.labelAccountingText.Size = new System.Drawing.Size(127, 62);
            this.labelAccountingText.TabIndex = 4;
            this.labelAccountingText.Text = "Ledger";
            // 
            // listViewLedgerBox
            // 
            this.listViewLedgerBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader3,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader1});
            this.listViewLedgerBox.FullRowSelect = true;
            this.listViewLedgerBox.HideSelection = false;
            this.listViewLedgerBox.Location = new System.Drawing.Point(12, 163);
            this.listViewLedgerBox.MultiSelect = false;
            this.listViewLedgerBox.Name = "listViewLedgerBox";
            this.listViewLedgerBox.Size = new System.Drawing.Size(771, 416);
            this.listViewLedgerBox.TabIndex = 9;
            this.listViewLedgerBox.UseCompatibleStateImageBehavior = false;
            this.listViewLedgerBox.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "ID";
            this.columnHeader6.Width = 42;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Transaction Date";
            this.columnHeader7.Width = 190;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Transaction Type";
            this.columnHeader8.Width = 142;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Transaction Method";
            this.columnHeader9.Width = 121;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Transaction Amount";
            this.columnHeader10.Width = 121;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Balance";
            this.columnHeader1.Width = 71;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Season Name";
            this.columnHeader3.Width = 79;
            // 
            // FormPlayerLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(792, 620);
            this.Controls.Add(this.listViewLedgerBox);
            this.Controls.Add(this.labelAccountingText);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.textBoxPlayerContactInfo);
            this.Controls.Add(this.textBoxPlayerInformation);
            this.Name = "FormPlayerLedger";
            this.Text = "Player Ledger";
            this.Load += new System.EventHandler(this.FormPlayerLedger_Load);
            ((System.ComponentModel.ISupportInitialize)(this.playersDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPlayerInformation;
        private PlayersDBDataSet playersDBDataSet;
        private System.Windows.Forms.BindingSource playersBindingSource;
        private PlayersDBDataSetTableAdapters.PlayersTableAdapter playersTableAdapter;
        private PlayersDBDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private TransactionsDBDataSet transactionsDBDataSet;
        private System.Windows.Forms.BindingSource transactionsBindingSource;
        private TransactionsDBDataSetTableAdapters.TransactionsTableAdapter transactionsTableAdapter;
        private TransactionsDBDataSetTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.TextBox textBoxPlayerContactInfo;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Label labelAccountingText;
        private System.Windows.Forms.ListView listViewLedgerBox;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}