namespace Big8_MAIN
{
    partial class FormProgressive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProgressive));
            this.labelTotalProgressiveText = new System.Windows.Forms.Label();
            this.labelReceiveAmount = new System.Windows.Forms.Label();
            this.upDownPayAmount = new System.Windows.Forms.NumericUpDown();
            this.listViewProgressiveWinners = new System.Windows.Forms.ListView();
            this.PlayerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Wins = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.playersDBDataSet = new Big8_MAIN.PlayersDBDataSet();
            this.playersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.playersTableAdapter = new Big8_MAIN.PlayersDBDataSetTableAdapters.PlayersTableAdapter();
            this.tableAdapterManager = new Big8_MAIN.PlayersDBDataSetTableAdapters.TableAdapterManager();
            this.accountingDataSet = new Big8_MAIN.AccountingDataSet();
            this.accountingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.accountingTableAdapter = new Big8_MAIN.AccountingDataSetTableAdapters.AccountingTableAdapter();
            this.tableAdapterManager1 = new Big8_MAIN.AccountingDataSetTableAdapters.TableAdapterManager();
            this.transactionsDBDataSet = new Big8_MAIN.TransactionsDBDataSet();
            this.transactionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transactionsTableAdapter = new Big8_MAIN.TransactionsDBDataSetTableAdapters.TransactionsTableAdapter();
            this.tableAdapterManager2 = new Big8_MAIN.TransactionsDBDataSetTableAdapters.TableAdapterManager();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.labelTotalProgressive = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelAccountingText = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSelectedSeason = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.upDownPayAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTotalProgressiveText
            // 
            this.labelTotalProgressiveText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTotalProgressiveText.AutoSize = true;
            this.labelTotalProgressiveText.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalProgressiveText.Location = new System.Drawing.Point(146, 489);
            this.labelTotalProgressiveText.Name = "labelTotalProgressiveText";
            this.labelTotalProgressiveText.Size = new System.Drawing.Size(171, 19);
            this.labelTotalProgressiveText.TabIndex = 215;
            this.labelTotalProgressiveText.Text = "Total Progressive Funds:";
            // 
            // labelReceiveAmount
            // 
            this.labelReceiveAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelReceiveAmount.AutoSize = true;
            this.labelReceiveAmount.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReceiveAmount.Location = new System.Drawing.Point(146, 449);
            this.labelReceiveAmount.Name = "labelReceiveAmount";
            this.labelReceiveAmount.Size = new System.Drawing.Size(147, 19);
            this.labelReceiveAmount.TabIndex = 214;
            this.labelReceiveAmount.Text = "Enter Amount to Pay";
            // 
            // upDownPayAmount
            // 
            this.upDownPayAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.upDownPayAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.upDownPayAmount.Location = new System.Drawing.Point(311, 442);
            this.upDownPayAmount.Maximum = new decimal(new int[] {
            35000,
            0,
            0,
            0});
            this.upDownPayAmount.Minimum = new decimal(new int[] {
            35000,
            0,
            0,
            -2147483648});
            this.upDownPayAmount.Name = "upDownPayAmount";
            this.upDownPayAmount.Size = new System.Drawing.Size(207, 26);
            this.upDownPayAmount.TabIndex = 213;
            // 
            // listViewProgressiveWinners
            // 
            this.listViewProgressiveWinners.AllowColumnReorder = true;
            this.listViewProgressiveWinners.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listViewProgressiveWinners.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PlayerName,
            this.Wins});
            this.listViewProgressiveWinners.FullRowSelect = true;
            this.listViewProgressiveWinners.HideSelection = false;
            this.listViewProgressiveWinners.Location = new System.Drawing.Point(98, 68);
            this.listViewProgressiveWinners.MultiSelect = false;
            this.listViewProgressiveWinners.Name = "listViewProgressiveWinners";
            this.listViewProgressiveWinners.Size = new System.Drawing.Size(461, 353);
            this.listViewProgressiveWinners.TabIndex = 212;
            this.listViewProgressiveWinners.UseCompatibleStateImageBehavior = false;
            this.listViewProgressiveWinners.View = System.Windows.Forms.View.Details;
            // 
            // PlayerName
            // 
            this.PlayerName.Text = "Player Name";
            this.PlayerName.Width = 191;
            // 
            // Wins
            // 
            this.Wins.Text = "Wins";
            this.Wins.Width = 103;
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
            // accountingDataSet
            // 
            this.accountingDataSet.DataSetName = "AccountingDataSet";
            this.accountingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // accountingBindingSource
            // 
            this.accountingBindingSource.DataMember = "Accounting";
            this.accountingBindingSource.DataSource = this.accountingDataSet;
            // 
            // accountingTableAdapter
            // 
            this.accountingTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.AccountingTableAdapter = this.accountingTableAdapter;
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.UpdateOrder = Big8_MAIN.AccountingDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
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
            // tableAdapterManager2
            // 
            this.tableAdapterManager2.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager2.TransactionsTableAdapter = this.transactionsTableAdapter;
            this.tableAdapterManager2.UpdateOrder = Big8_MAIN.TransactionsDBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSubmit.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonSubmit.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubmit.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonSubmit.Location = new System.Drawing.Point(242, 535);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(169, 38);
            this.buttonSubmit.TabIndex = 216;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = false;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click_1);
            // 
            // labelTotalProgressive
            // 
            this.labelTotalProgressive.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTotalProgressive.AutoSize = true;
            this.labelTotalProgressive.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalProgressive.Location = new System.Drawing.Point(323, 489);
            this.labelTotalProgressive.Name = "labelTotalProgressive";
            this.labelTotalProgressive.Size = new System.Drawing.Size(19, 19);
            this.labelTotalProgressive.TabIndex = 217;
            this.labelTotalProgressive.Text = "0";
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel2.Controls.Add(this.labelAccountingText);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textBoxSelectedSeason);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(630, 58);
            this.panel2.TabIndex = 218;
            // 
            // labelAccountingText
            // 
            this.labelAccountingText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAccountingText.AutoSize = true;
            this.labelAccountingText.Font = new System.Drawing.Font("Blue Highway Condensed", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAccountingText.ForeColor = System.Drawing.SystemColors.Control;
            this.labelAccountingText.Location = new System.Drawing.Point(276, -4);
            this.labelAccountingText.Name = "labelAccountingText";
            this.labelAccountingText.Size = new System.Drawing.Size(260, 62);
            this.labelAccountingText.TabIndex = 3;
            this.labelAccountingText.Text = "Pay Progressive";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(51, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 19);
            this.label4.TabIndex = 180;
            this.label4.Text = "Selected Season";
            // 
            // textBoxSelectedSeason
            // 
            this.textBoxSelectedSeason.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxSelectedSeason.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxSelectedSeason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSelectedSeason.Enabled = false;
            this.textBoxSelectedSeason.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxSelectedSeason.Location = new System.Drawing.Point(55, 27);
            this.textBoxSelectedSeason.Name = "textBoxSelectedSeason";
            this.textBoxSelectedSeason.Size = new System.Drawing.Size(190, 26);
            this.textBoxSelectedSeason.TabIndex = 179;
            // 
            // FormProgressive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(630, 594);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.labelTotalProgressive);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.labelTotalProgressiveText);
            this.Controls.Add(this.labelReceiveAmount);
            this.Controls.Add(this.upDownPayAmount);
            this.Controls.Add(this.listViewProgressiveWinners);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormProgressive";
            this.Text = "Pay Progressive";
            this.Load += new System.EventHandler(this.FormProgressive_Load);
            ((System.ComponentModel.ISupportInitialize)(this.upDownPayAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTotalProgressiveText;
        private System.Windows.Forms.Label labelReceiveAmount;
        private System.Windows.Forms.NumericUpDown upDownPayAmount;
        private System.Windows.Forms.ListView listViewProgressiveWinners;
        private System.Windows.Forms.ColumnHeader PlayerName;
        private System.Windows.Forms.ColumnHeader Wins;
        private PlayersDBDataSet playersDBDataSet;
        private System.Windows.Forms.BindingSource playersBindingSource;
        private PlayersDBDataSetTableAdapters.PlayersTableAdapter playersTableAdapter;
        private PlayersDBDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private AccountingDataSet accountingDataSet;
        private System.Windows.Forms.BindingSource accountingBindingSource;
        private AccountingDataSetTableAdapters.AccountingTableAdapter accountingTableAdapter;
        private AccountingDataSetTableAdapters.TableAdapterManager tableAdapterManager1;
        private TransactionsDBDataSet transactionsDBDataSet;
        private System.Windows.Forms.BindingSource transactionsBindingSource;
        private TransactionsDBDataSetTableAdapters.TransactionsTableAdapter transactionsTableAdapter;
        private TransactionsDBDataSetTableAdapters.TableAdapterManager tableAdapterManager2;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Label labelTotalProgressive;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelAccountingText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSelectedSeason;
    }
}