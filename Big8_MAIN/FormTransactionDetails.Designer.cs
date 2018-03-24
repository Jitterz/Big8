namespace Big8_MAIN
{
    partial class FormTransactionDetails
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
            this.playersDBDataSet = new Big8_MAIN.PlayersDBDataSet();
            this.playersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.playersTableAdapter = new Big8_MAIN.PlayersDBDataSetTableAdapters.PlayersTableAdapter();
            this.tableAdapterManager1 = new Big8_MAIN.PlayersDBDataSetTableAdapters.TableAdapterManager();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxTransactionId = new System.Windows.Forms.TextBox();
            this.textBoxPlayerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.upDownAmount = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxCheckNumber = new System.Windows.Forms.TextBox();
            this.labelCheckNumber = new System.Windows.Forms.Label();
            this.textBoxDateTime = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.upDownInterest = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelAccountingText = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxSelectedSeason = new System.Windows.Forms.TextBox();
            this.buttonSaveChanges = new System.Windows.Forms.Button();
            this.buttonReverseTransaction = new System.Windows.Forms.Button();
            this.transactionsDBDataSet = new Big8_MAIN.TransactionsDBDataSet();
            this.transactionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transactionsTableAdapter = new Big8_MAIN.TransactionsDBDataSetTableAdapters.TransactionsTableAdapter();
            this.tableAdapterManager = new Big8_MAIN.TransactionsDBDataSetTableAdapters.TableAdapterManager();
            this.comboBoxPayMethod = new System.Windows.Forms.ComboBox();
            this.accountingDataSet = new Big8_MAIN.AccountingDataSet();
            this.accountingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.accountingTableAdapter = new Big8_MAIN.AccountingDataSetTableAdapters.AccountingTableAdapter();
            this.tableAdapterManager2 = new Big8_MAIN.AccountingDataSetTableAdapters.TableAdapterManager();
            this.comboBoxSelectWeek = new System.Windows.Forms.ComboBox();
            this.textBoxType = new System.Windows.Forms.TextBox();
            this.textBoxTransactionNotes = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.playersDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownInterest)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingBindingSource)).BeginInit();
            this.SuspendLayout();
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
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.PlayersTableAdapter = this.playersTableAdapter;
            this.tableAdapterManager1.UpdateOrder = Big8_MAIN.PlayersDBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(17, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Transaction ID";
            // 
            // textBoxTransactionId
            // 
            this.textBoxTransactionId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxTransactionId.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTransactionId.Location = new System.Drawing.Point(21, 149);
            this.textBoxTransactionId.Name = "textBoxTransactionId";
            this.textBoxTransactionId.ReadOnly = true;
            this.textBoxTransactionId.Size = new System.Drawing.Size(104, 29);
            this.textBoxTransactionId.TabIndex = 1;
            // 
            // textBoxPlayerName
            // 
            this.textBoxPlayerName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPlayerName.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPlayerName.Location = new System.Drawing.Point(21, 219);
            this.textBoxPlayerName.Name = "textBoxPlayerName";
            this.textBoxPlayerName.ReadOnly = true;
            this.textBoxPlayerName.Size = new System.Drawing.Size(270, 29);
            this.textBoxPlayerName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(17, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Player Name";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(17, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Transaction Type";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(17, 343);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Transaction Method";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(17, 464);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Transaction Amount";
            // 
            // upDownAmount
            // 
            this.upDownAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.upDownAmount.Font = new System.Drawing.Font("Arial", 14.25F);
            this.upDownAmount.Location = new System.Drawing.Point(21, 486);
            this.upDownAmount.Maximum = new decimal(new int[] {
            35000,
            0,
            0,
            0});
            this.upDownAmount.Minimum = new decimal(new int[] {
            35000,
            0,
            0,
            -2147483648});
            this.upDownAmount.Name = "upDownAmount";
            this.upDownAmount.Size = new System.Drawing.Size(149, 29);
            this.upDownAmount.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(329, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "Week of Transaction";
            // 
            // textBoxCheckNumber
            // 
            this.textBoxCheckNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxCheckNumber.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCheckNumber.Location = new System.Drawing.Point(333, 365);
            this.textBoxCheckNumber.Name = "textBoxCheckNumber";
            this.textBoxCheckNumber.Size = new System.Drawing.Size(270, 29);
            this.textBoxCheckNumber.TabIndex = 13;
            // 
            // labelCheckNumber
            // 
            this.labelCheckNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCheckNumber.AutoSize = true;
            this.labelCheckNumber.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCheckNumber.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelCheckNumber.Location = new System.Drawing.Point(329, 343);
            this.labelCheckNumber.Name = "labelCheckNumber";
            this.labelCheckNumber.Size = new System.Drawing.Size(105, 19);
            this.labelCheckNumber.TabIndex = 12;
            this.labelCheckNumber.Text = "Check Number";
            // 
            // textBoxDateTime
            // 
            this.textBoxDateTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxDateTime.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDateTime.Location = new System.Drawing.Point(333, 301);
            this.textBoxDateTime.Name = "textBoxDateTime";
            this.textBoxDateTime.ReadOnly = true;
            this.textBoxDateTime.Size = new System.Drawing.Size(270, 29);
            this.textBoxDateTime.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(329, 279);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 19);
            this.label8.TabIndex = 14;
            this.label8.Text = "Date and Time";
            // 
            // upDownInterest
            // 
            this.upDownInterest.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.upDownInterest.Font = new System.Drawing.Font("Arial", 14.25F);
            this.upDownInterest.Location = new System.Drawing.Point(176, 486);
            this.upDownInterest.Maximum = new decimal(new int[] {
            35000,
            0,
            0,
            0});
            this.upDownInterest.Minimum = new decimal(new int[] {
            35000,
            0,
            0,
            -2147483648});
            this.upDownInterest.Name = "upDownInterest";
            this.upDownInterest.Size = new System.Drawing.Size(149, 29);
            this.upDownInterest.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(172, 464);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 19);
            this.label9.TabIndex = 16;
            this.label9.Text = "Transaction Interest";
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel2.Controls.Add(this.labelAccountingText);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.textBoxSelectedSeason);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(633, 85);
            this.panel2.TabIndex = 188;
            // 
            // labelAccountingText
            // 
            this.labelAccountingText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAccountingText.AutoSize = true;
            this.labelAccountingText.Font = new System.Drawing.Font("Blue Highway Condensed", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAccountingText.ForeColor = System.Drawing.SystemColors.Control;
            this.labelAccountingText.Location = new System.Drawing.Point(292, 20);
            this.labelAccountingText.Name = "labelAccountingText";
            this.labelAccountingText.Size = new System.Drawing.Size(311, 62);
            this.labelAccountingText.TabIndex = 3;
            this.labelAccountingText.Text = "Transaction Details";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.Control;
            this.label10.Location = new System.Drawing.Point(17, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 19);
            this.label10.TabIndex = 180;
            this.label10.Text = "Selected Season";
            // 
            // textBoxSelectedSeason
            // 
            this.textBoxSelectedSeason.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxSelectedSeason.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxSelectedSeason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSelectedSeason.Enabled = false;
            this.textBoxSelectedSeason.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxSelectedSeason.Location = new System.Drawing.Point(20, 56);
            this.textBoxSelectedSeason.Name = "textBoxSelectedSeason";
            this.textBoxSelectedSeason.Size = new System.Drawing.Size(190, 26);
            this.textBoxSelectedSeason.TabIndex = 179;
            // 
            // buttonSaveChanges
            // 
            this.buttonSaveChanges.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSaveChanges.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonSaveChanges.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveChanges.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonSaveChanges.Location = new System.Drawing.Point(434, 409);
            this.buttonSaveChanges.Name = "buttonSaveChanges";
            this.buttonSaveChanges.Size = new System.Drawing.Size(169, 54);
            this.buttonSaveChanges.TabIndex = 189;
            this.buttonSaveChanges.Text = "Save Changes";
            this.buttonSaveChanges.UseVisualStyleBackColor = false;
            this.buttonSaveChanges.Click += new System.EventHandler(this.buttonSaveChanges_Click);
            // 
            // buttonReverseTransaction
            // 
            this.buttonReverseTransaction.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonReverseTransaction.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonReverseTransaction.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReverseTransaction.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonReverseTransaction.Location = new System.Drawing.Point(434, 469);
            this.buttonReverseTransaction.Name = "buttonReverseTransaction";
            this.buttonReverseTransaction.Size = new System.Drawing.Size(169, 31);
            this.buttonReverseTransaction.TabIndex = 190;
            this.buttonReverseTransaction.Text = "Reverse Transaction";
            this.buttonReverseTransaction.UseVisualStyleBackColor = false;
            this.buttonReverseTransaction.Click += new System.EventHandler(this.buttonReverseTransaction_Click);
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
            // comboBoxPayMethod
            // 
            this.comboBoxPayMethod.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxPayMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPayMethod.Font = new System.Drawing.Font("Arial", 14.25F);
            this.comboBoxPayMethod.FormattingEnabled = true;
            this.comboBoxPayMethod.Items.AddRange(new object[] {
            "Cash",
            "Card",
            "Check",
            "Paypal",
            "Generic Credit",
            "Generic Charge",
            "Buy in Charge"});
            this.comboBoxPayMethod.Location = new System.Drawing.Point(20, 365);
            this.comboBoxPayMethod.Name = "comboBoxPayMethod";
            this.comboBoxPayMethod.Size = new System.Drawing.Size(271, 30);
            this.comboBoxPayMethod.TabIndex = 192;
            this.comboBoxPayMethod.SelectedIndexChanged += new System.EventHandler(this.comboBoxPayMethod_SelectedIndexChanged);
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
            // tableAdapterManager2
            // 
            this.tableAdapterManager2.AccountingTableAdapter = this.accountingTableAdapter;
            this.tableAdapterManager2.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager2.UpdateOrder = Big8_MAIN.AccountingDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // comboBoxSelectWeek
            // 
            this.comboBoxSelectWeek.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxSelectWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectWeek.Font = new System.Drawing.Font("Arial", 14.25F);
            this.comboBoxSelectWeek.FormattingEnabled = true;
            this.comboBoxSelectWeek.Items.AddRange(new object[] {
            "Week 01",
            "Week 02",
            "Week 03",
            "Week 04",
            "Week 05",
            "Week 06",
            "Week 07",
            "Week 08",
            "Week 09",
            "Week 10",
            "Week 11",
            "Week 12",
            "Week 13",
            "Week 14",
            "Week 15",
            "Week 16",
            "Week 17"});
            this.comboBoxSelectWeek.Location = new System.Drawing.Point(333, 219);
            this.comboBoxSelectWeek.MaxDropDownItems = 17;
            this.comboBoxSelectWeek.Name = "comboBoxSelectWeek";
            this.comboBoxSelectWeek.Size = new System.Drawing.Size(207, 30);
            this.comboBoxSelectWeek.TabIndex = 193;
            // 
            // textBoxType
            // 
            this.textBoxType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxType.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxType.Location = new System.Drawing.Point(20, 301);
            this.textBoxType.Name = "textBoxType";
            this.textBoxType.ReadOnly = true;
            this.textBoxType.Size = new System.Drawing.Size(270, 29);
            this.textBoxType.TabIndex = 194;
            // 
            // textBoxTransactionNotes
            // 
            this.textBoxTransactionNotes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxTransactionNotes.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTransactionNotes.Location = new System.Drawing.Point(21, 425);
            this.textBoxTransactionNotes.Name = "textBoxTransactionNotes";
            this.textBoxTransactionNotes.Size = new System.Drawing.Size(270, 29);
            this.textBoxTransactionNotes.TabIndex = 196;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(17, 403);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 19);
            this.label7.TabIndex = 195;
            this.label7.Text = "Transaction Notes";
            // 
            // FormTransactionDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(633, 528);
            this.Controls.Add(this.textBoxTransactionNotes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxType);
            this.Controls.Add(this.comboBoxSelectWeek);
            this.Controls.Add(this.comboBoxPayMethod);
            this.Controls.Add(this.buttonReverseTransaction);
            this.Controls.Add(this.buttonSaveChanges);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.upDownInterest);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxDateTime);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxCheckNumber);
            this.Controls.Add(this.labelCheckNumber);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.upDownAmount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxPlayerName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxTransactionId);
            this.Controls.Add(this.label1);
            this.Name = "FormTransactionDetails";
            this.Text = "Transaction Details";
            this.Load += new System.EventHandler(this.FormTransactionDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.playersDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownInterest)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TransactionsDBDataSet transactionsDBDataSet;
        private System.Windows.Forms.BindingSource transactionsBindingSource;
        private TransactionsDBDataSetTableAdapters.TransactionsTableAdapter transactionsTableAdapter;
        private TransactionsDBDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private PlayersDBDataSet playersDBDataSet;
        private System.Windows.Forms.BindingSource playersBindingSource;
        private PlayersDBDataSetTableAdapters.PlayersTableAdapter playersTableAdapter;
        private PlayersDBDataSetTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxTransactionId;
        private System.Windows.Forms.TextBox textBoxPlayerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown upDownAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxCheckNumber;
        private System.Windows.Forms.Label labelCheckNumber;
        private System.Windows.Forms.TextBox textBoxDateTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown upDownInterest;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelAccountingText;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxSelectedSeason;
        private System.Windows.Forms.Button buttonSaveChanges;
        private System.Windows.Forms.Button buttonReverseTransaction;
        private System.Windows.Forms.ComboBox comboBoxPayMethod;
        private AccountingDataSet accountingDataSet;
        private System.Windows.Forms.BindingSource accountingBindingSource;
        private AccountingDataSetTableAdapters.AccountingTableAdapter accountingTableAdapter;
        private AccountingDataSetTableAdapters.TableAdapterManager tableAdapterManager2;
        private System.Windows.Forms.ComboBox comboBoxSelectWeek;
        private System.Windows.Forms.TextBox textBoxType;
        private System.Windows.Forms.TextBox textBoxTransactionNotes;
        private System.Windows.Forms.Label label7;
    }
}