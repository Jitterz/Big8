namespace Big8_MAIN
{
    partial class FormAccounting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAccounting));
            this.labelAccountingText = new System.Windows.Forms.Label();
            this.labelWhoOwesUsText = new System.Windows.Forms.Label();
            this.labelWhoWeOweText = new System.Windows.Forms.Label();
            this.buttonViewMasterAccounting = new System.Windows.Forms.Button();
            this.listBoxPlayersList = new System.Windows.Forms.ListBox();
            this.textBoxSearchPlayer = new System.Windows.Forms.TextBox();
            this.labelSearchPlayerText = new System.Windows.Forms.Label();
            this.comboBoxPayMethod = new System.Windows.Forms.ComboBox();
            this.textBoxCheckNumber = new System.Windows.Forms.TextBox();
            this.labelCheckNumber = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelAmount = new System.Windows.Forms.Label();
            this.comboBoxSelectPayReceive = new System.Windows.Forms.ComboBox();
            this.labelSelectPlayerTextEdit = new System.Windows.Forms.Label();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSelectedSeason = new System.Windows.Forms.TextBox();
            this.playersDBDataSet = new Big8_MAIN.PlayersDBDataSet();
            this.playersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.playersTableAdapter = new Big8_MAIN.PlayersDBDataSetTableAdapters.PlayersTableAdapter();
            this.tableAdapterManager1 = new Big8_MAIN.PlayersDBDataSetTableAdapters.TableAdapterManager();
            this.seasonsDBDataSet = new Big8_MAIN.SeasonsDBDataSet();
            this.seasons1_5BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.seasons1_5TableAdapter = new Big8_MAIN.SeasonsDBDataSetTableAdapters.Seasons1_5TableAdapter();
            this.tableAdapterManager2 = new Big8_MAIN.SeasonsDBDataSetTableAdapters.TableAdapterManager();
            this.seasons11_17TableAdapter = new Big8_MAIN.SeasonsDBDataSetTableAdapters.Seasons11_17TableAdapter();
            this.seasons6_10TableAdapter = new Big8_MAIN.SeasonsDBDataSetTableAdapters.Seasons6_10TableAdapter();
            this.seasons6_10BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.seasons11_17BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.upDownAmount = new System.Windows.Forms.NumericUpDown();
            this.accountingDataSet = new Big8_MAIN.AccountingDataSet();
            this.accountingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.accountingTableAdapter = new Big8_MAIN.AccountingDataSetTableAdapters.AccountingTableAdapter();
            this.tableAdapterManager = new Big8_MAIN.AccountingDataSetTableAdapters.TableAdapterManager();
            this.labelSelectWeekText = new System.Windows.Forms.Label();
            this.comboBoxSelectWeek = new System.Windows.Forms.ComboBox();
            this.textBoxPreferredMethod = new System.Windows.Forms.TextBox();
            this.labelPreferredMethod = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonGroups = new System.Windows.Forms.Button();
            this.buttonChargeAllBuyIn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.transactionsDBDataSet = new Big8_MAIN.TransactionsDBDataSet();
            this.transactionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transactionsTableAdapter = new Big8_MAIN.TransactionsDBDataSetTableAdapters.TransactionsTableAdapter();
            this.tableAdapterManager3 = new Big8_MAIN.TransactionsDBDataSetTableAdapters.TableAdapterManager();
            this.listViewWhoOwesUs = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewWhoWeOwe = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonViewPlayerLedger = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.labelTotalOwesUs = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelTotalWeOwe = new System.Windows.Forms.Label();
            this.textBoxTransactionNotes = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxPlayerNotes = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.listViewTransactionWindow = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonPayAll = new System.Windows.Forms.Button();
            this.labelTotalFundsText = new System.Windows.Forms.Label();
            this.listViewAccountingTotals = new System.Windows.Forms.ListView();
            this.Interest = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Progressive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PoolFunds = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RealCash = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.upDownReceiveAmount = new System.Windows.Forms.NumericUpDown();
            this.labelReceiveAmount = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonFixTransactions = new System.Windows.Forms.Button();
            this.buttonPayProgressive = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.playersDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seasonsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seasons1_5BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seasons6_10BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seasons11_17BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownReceiveAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAccountingText
            // 
            this.labelAccountingText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAccountingText.AutoSize = true;
            this.labelAccountingText.Font = new System.Drawing.Font("Blue Highway Condensed", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAccountingText.ForeColor = System.Drawing.SystemColors.Control;
            this.labelAccountingText.Location = new System.Drawing.Point(378, 14);
            this.labelAccountingText.Name = "labelAccountingText";
            this.labelAccountingText.Size = new System.Drawing.Size(189, 62);
            this.labelAccountingText.TabIndex = 3;
            this.labelAccountingText.Text = "Accounting";
            // 
            // labelWhoOwesUsText
            // 
            this.labelWhoOwesUsText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelWhoOwesUsText.AutoSize = true;
            this.labelWhoOwesUsText.Font = new System.Drawing.Font("Blue Highway Condensed", 20F, System.Drawing.FontStyle.Bold);
            this.labelWhoOwesUsText.Location = new System.Drawing.Point(95, 386);
            this.labelWhoOwesUsText.Name = "labelWhoOwesUsText";
            this.labelWhoOwesUsText.Size = new System.Drawing.Size(104, 27);
            this.labelWhoOwesUsText.TabIndex = 141;
            this.labelWhoOwesUsText.Text = "Who Owes Us";
            // 
            // labelWhoWeOweText
            // 
            this.labelWhoWeOweText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelWhoWeOweText.AutoSize = true;
            this.labelWhoWeOweText.Font = new System.Drawing.Font("Blue Highway Condensed", 20F, System.Drawing.FontStyle.Bold);
            this.labelWhoWeOweText.Location = new System.Drawing.Point(284, 386);
            this.labelWhoWeOweText.Name = "labelWhoWeOweText";
            this.labelWhoWeOweText.Size = new System.Drawing.Size(102, 27);
            this.labelWhoWeOweText.TabIndex = 143;
            this.labelWhoWeOweText.Text = "Who We Owe";
            // 
            // buttonViewMasterAccounting
            // 
            this.buttonViewMasterAccounting.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonViewMasterAccounting.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonViewMasterAccounting.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonViewMasterAccounting.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonViewMasterAccounting.Location = new System.Drawing.Point(395, 5);
            this.buttonViewMasterAccounting.Name = "buttonViewMasterAccounting";
            this.buttonViewMasterAccounting.Size = new System.Drawing.Size(169, 62);
            this.buttonViewMasterAccounting.TabIndex = 158;
            this.buttonViewMasterAccounting.Text = "View Master Accounting";
            this.buttonViewMasterAccounting.UseVisualStyleBackColor = false;
            this.buttonViewMasterAccounting.Click += new System.EventHandler(this.buttonViewMasterAccounting_Click);
            // 
            // listBoxPlayersList
            // 
            this.listBoxPlayersList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxPlayersList.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxPlayersList.FormattingEnabled = true;
            this.listBoxPlayersList.ItemHeight = 21;
            this.listBoxPlayersList.Location = new System.Drawing.Point(704, 146);
            this.listBoxPlayersList.Name = "listBoxPlayersList";
            this.listBoxPlayersList.ScrollAlwaysVisible = true;
            this.listBoxPlayersList.Size = new System.Drawing.Size(201, 382);
            this.listBoxPlayersList.TabIndex = 161;
            this.listBoxPlayersList.SelectedIndexChanged += new System.EventHandler(this.listBoxPlayersList_SelectedIndexChanged);
            // 
            // textBoxSearchPlayer
            // 
            this.textBoxSearchPlayer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxSearchPlayer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSearchPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxSearchPlayer.Location = new System.Drawing.Point(704, 56);
            this.textBoxSearchPlayer.Name = "textBoxSearchPlayer";
            this.textBoxSearchPlayer.Size = new System.Drawing.Size(201, 26);
            this.textBoxSearchPlayer.TabIndex = 160;
            this.textBoxSearchPlayer.TextChanged += new System.EventHandler(this.textBoxSearchPlayer_TextChanged_1);
            // 
            // labelSearchPlayerText
            // 
            this.labelSearchPlayerText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSearchPlayerText.AutoSize = true;
            this.labelSearchPlayerText.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSearchPlayerText.ForeColor = System.Drawing.SystemColors.Control;
            this.labelSearchPlayerText.Location = new System.Drawing.Point(700, 33);
            this.labelSearchPlayerText.Name = "labelSearchPlayerText";
            this.labelSearchPlayerText.Size = new System.Drawing.Size(99, 19);
            this.labelSearchPlayerText.TabIndex = 159;
            this.labelSearchPlayerText.Text = "Search Player";
            // 
            // comboBoxPayMethod
            // 
            this.comboBoxPayMethod.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxPayMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPayMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboBoxPayMethod.FormattingEnabled = true;
            this.comboBoxPayMethod.Items.AddRange(new object[] {
            "Cash",
            "Card",
            "Check",
            "Paypal",
            "Generic Credit",
            "Generic Charge",
            "Buy in Charge"});
            this.comboBoxPayMethod.Location = new System.Drawing.Point(461, 470);
            this.comboBoxPayMethod.Name = "comboBoxPayMethod";
            this.comboBoxPayMethod.Size = new System.Drawing.Size(207, 28);
            this.comboBoxPayMethod.TabIndex = 177;
            this.comboBoxPayMethod.SelectedIndexChanged += new System.EventHandler(this.comboBoxPayMethod_SelectedIndexChanged);
            // 
            // textBoxCheckNumber
            // 
            this.textBoxCheckNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxCheckNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCheckNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxCheckNumber.Location = new System.Drawing.Point(461, 523);
            this.textBoxCheckNumber.Name = "textBoxCheckNumber";
            this.textBoxCheckNumber.Size = new System.Drawing.Size(207, 26);
            this.textBoxCheckNumber.TabIndex = 182;
            this.textBoxCheckNumber.Visible = false;
            // 
            // labelCheckNumber
            // 
            this.labelCheckNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCheckNumber.AutoSize = true;
            this.labelCheckNumber.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCheckNumber.Location = new System.Drawing.Point(459, 501);
            this.labelCheckNumber.Name = "labelCheckNumber";
            this.labelCheckNumber.Size = new System.Drawing.Size(105, 19);
            this.labelCheckNumber.TabIndex = 175;
            this.labelCheckNumber.Text = "Check Number";
            this.labelCheckNumber.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(458, 448);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 19);
            this.label2.TabIndex = 174;
            this.label2.Text = "Payment Method";
            // 
            // labelAmount
            // 
            this.labelAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAmount.AutoSize = true;
            this.labelAmount.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAmount.Location = new System.Drawing.Point(458, 280);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(61, 19);
            this.labelAmount.TabIndex = 172;
            this.labelAmount.Text = "Amount";
            // 
            // comboBoxSelectPayReceive
            // 
            this.comboBoxSelectPayReceive.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxSelectPayReceive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectPayReceive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboBoxSelectPayReceive.FormattingEnabled = true;
            this.comboBoxSelectPayReceive.Items.AddRange(new object[] {
            "Pay Out",
            "Receive Payment",
            "Charge",
            "Credit",
            "Initial Payment",
            "Charge/Receive"});
            this.comboBoxSelectPayReceive.Location = new System.Drawing.Point(461, 246);
            this.comboBoxSelectPayReceive.Name = "comboBoxSelectPayReceive";
            this.comboBoxSelectPayReceive.Size = new System.Drawing.Size(207, 28);
            this.comboBoxSelectPayReceive.TabIndex = 171;
            this.comboBoxSelectPayReceive.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelectPayReceive_SelectedIndexChanged);
            // 
            // labelSelectPlayerTextEdit
            // 
            this.labelSelectPlayerTextEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSelectPlayerTextEdit.AutoSize = true;
            this.labelSelectPlayerTextEdit.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectPlayerTextEdit.Location = new System.Drawing.Point(458, 224);
            this.labelSelectPlayerTextEdit.Name = "labelSelectPlayerTextEdit";
            this.labelSelectPlayerTextEdit.Size = new System.Drawing.Size(145, 19);
            this.labelSelectPlayerTextEdit.TabIndex = 170;
            this.labelSelectPlayerTextEdit.Text = "Select Pay / Receive";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSubmit.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonSubmit.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubmit.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonSubmit.Location = new System.Drawing.Point(476, 668);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(169, 38);
            this.buttonSubmit.TabIndex = 184;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = false;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(59, 33);
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
            this.textBoxSelectedSeason.Location = new System.Drawing.Point(63, 56);
            this.textBoxSelectedSeason.Name = "textBoxSelectedSeason";
            this.textBoxSelectedSeason.Size = new System.Drawing.Size(190, 26);
            this.textBoxSelectedSeason.TabIndex = 179;
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
            // seasonsDBDataSet
            // 
            this.seasonsDBDataSet.DataSetName = "SeasonsDBDataSet";
            this.seasonsDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // seasons1_5BindingSource
            // 
            this.seasons1_5BindingSource.DataMember = "Seasons1_5";
            this.seasons1_5BindingSource.DataSource = this.seasonsDBDataSet;
            // 
            // seasons1_5TableAdapter
            // 
            this.seasons1_5TableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager2
            // 
            this.tableAdapterManager2.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager2.Seasons1_5TableAdapter = this.seasons1_5TableAdapter;
            this.tableAdapterManager2.Seasons11_17TableAdapter = this.seasons11_17TableAdapter;
            this.tableAdapterManager2.Seasons6_10TableAdapter = this.seasons6_10TableAdapter;
            this.tableAdapterManager2.UpdateOrder = Big8_MAIN.SeasonsDBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // seasons11_17TableAdapter
            // 
            this.seasons11_17TableAdapter.ClearBeforeFill = true;
            // 
            // seasons6_10TableAdapter
            // 
            this.seasons6_10TableAdapter.ClearBeforeFill = true;
            // 
            // seasons6_10BindingSource
            // 
            this.seasons6_10BindingSource.DataMember = "Seasons6_10";
            this.seasons6_10BindingSource.DataSource = this.seasonsDBDataSet;
            // 
            // seasons11_17BindingSource
            // 
            this.seasons11_17BindingSource.DataMember = "Seasons11_17";
            this.seasons11_17BindingSource.DataSource = this.seasonsDBDataSet;
            // 
            // upDownAmount
            // 
            this.upDownAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.upDownAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.upDownAmount.Location = new System.Drawing.Point(461, 302);
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
            this.upDownAmount.Size = new System.Drawing.Size(207, 26);
            this.upDownAmount.TabIndex = 181;
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
            // tableAdapterManager
            // 
            this.tableAdapterManager.AccountingTableAdapter = this.accountingTableAdapter;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.UpdateOrder = Big8_MAIN.AccountingDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // labelSelectWeekText
            // 
            this.labelSelectWeekText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSelectWeekText.AutoSize = true;
            this.labelSelectWeekText.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectWeekText.Location = new System.Drawing.Point(458, 168);
            this.labelSelectWeekText.Name = "labelSelectWeekText";
            this.labelSelectWeekText.Size = new System.Drawing.Size(92, 19);
            this.labelSelectWeekText.TabIndex = 183;
            this.labelSelectWeekText.Text = "Select Week";
            // 
            // comboBoxSelectWeek
            // 
            this.comboBoxSelectWeek.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxSelectWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelectWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
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
            this.comboBoxSelectWeek.Location = new System.Drawing.Point(461, 191);
            this.comboBoxSelectWeek.MaxDropDownItems = 17;
            this.comboBoxSelectWeek.Name = "comboBoxSelectWeek";
            this.comboBoxSelectWeek.Size = new System.Drawing.Size(207, 28);
            this.comboBoxSelectWeek.TabIndex = 182;
            // 
            // textBoxPreferredMethod
            // 
            this.textBoxPreferredMethod.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPreferredMethod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPreferredMethod.Enabled = false;
            this.textBoxPreferredMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxPreferredMethod.Location = new System.Drawing.Point(461, 419);
            this.textBoxPreferredMethod.Name = "textBoxPreferredMethod";
            this.textBoxPreferredMethod.ReadOnly = true;
            this.textBoxPreferredMethod.Size = new System.Drawing.Size(207, 26);
            this.textBoxPreferredMethod.TabIndex = 185;
            // 
            // labelPreferredMethod
            // 
            this.labelPreferredMethod.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPreferredMethod.AutoSize = true;
            this.labelPreferredMethod.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPreferredMethod.Location = new System.Drawing.Point(459, 397);
            this.labelPreferredMethod.Name = "labelPreferredMethod";
            this.labelPreferredMethod.Size = new System.Drawing.Size(169, 19);
            this.labelPreferredMethod.TabIndex = 184;
            this.labelPreferredMethod.Text = "Player Preferred Method";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.buttonGroups);
            this.panel1.Controls.Add(this.buttonViewMasterAccounting);
            this.panel1.Controls.Add(this.buttonChargeAllBuyIn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 712);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(972, 70);
            this.panel1.TabIndex = 186;
            // 
            // buttonGroups
            // 
            this.buttonGroups.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonGroups.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGroups.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonGroups.Location = new System.Drawing.Point(58, 5);
            this.buttonGroups.Name = "buttonGroups";
            this.buttonGroups.Size = new System.Drawing.Size(169, 62);
            this.buttonGroups.TabIndex = 160;
            this.buttonGroups.Text = "View Groups";
            this.buttonGroups.UseVisualStyleBackColor = false;
            this.buttonGroups.Click += new System.EventHandler(this.buttonGroups_Click);
            // 
            // buttonChargeAllBuyIn
            // 
            this.buttonChargeAllBuyIn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonChargeAllBuyIn.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonChargeAllBuyIn.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChargeAllBuyIn.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonChargeAllBuyIn.Location = new System.Drawing.Point(730, 5);
            this.buttonChargeAllBuyIn.Name = "buttonChargeAllBuyIn";
            this.buttonChargeAllBuyIn.Size = new System.Drawing.Size(175, 55);
            this.buttonChargeAllBuyIn.TabIndex = 188;
            this.buttonChargeAllBuyIn.Text = "Charge All Buy In Amount";
            this.buttonChargeAllBuyIn.UseVisualStyleBackColor = false;
            this.buttonChargeAllBuyIn.Click += new System.EventHandler(this.buttonChargeAllBuyIn_Click);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel2.Controls.Add(this.labelAccountingText);
            this.panel2.Controls.Add(this.labelSearchPlayerText);
            this.panel2.Controls.Add(this.textBoxSearchPlayer);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textBoxSelectedSeason);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(972, 85);
            this.panel2.TabIndex = 187;
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
            // tableAdapterManager3
            // 
            this.tableAdapterManager3.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager3.TransactionsTableAdapter = this.transactionsTableAdapter;
            this.tableAdapterManager3.UpdateOrder = Big8_MAIN.TransactionsDBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // listViewWhoOwesUs
            // 
            this.listViewWhoOwesUs.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listViewWhoOwesUs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewWhoOwesUs.FullRowSelect = true;
            this.listViewWhoOwesUs.HideSelection = false;
            this.listViewWhoOwesUs.Location = new System.Drawing.Point(12, 416);
            this.listViewWhoOwesUs.MultiSelect = false;
            this.listViewWhoOwesUs.Name = "listViewWhoOwesUs";
            this.listViewWhoOwesUs.Size = new System.Drawing.Size(215, 198);
            this.listViewWhoOwesUs.TabIndex = 190;
            this.listViewWhoOwesUs.UseCompatibleStateImageBehavior = false;
            this.listViewWhoOwesUs.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 142;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Amount";
            this.columnHeader2.Width = 64;
            // 
            // listViewWhoWeOwe
            // 
            this.listViewWhoWeOwe.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listViewWhoWeOwe.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.listViewWhoWeOwe.Location = new System.Drawing.Point(233, 416);
            this.listViewWhoWeOwe.Name = "listViewWhoWeOwe";
            this.listViewWhoWeOwe.Size = new System.Drawing.Size(213, 198);
            this.listViewWhoWeOwe.TabIndex = 191;
            this.listViewWhoWeOwe.UseCompatibleStateImageBehavior = false;
            this.listViewWhoWeOwe.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 140;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Amount";
            this.columnHeader4.Width = 64;
            // 
            // buttonViewPlayerLedger
            // 
            this.buttonViewPlayerLedger.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonViewPlayerLedger.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonViewPlayerLedger.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonViewPlayerLedger.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonViewPlayerLedger.Location = new System.Drawing.Point(704, 668);
            this.buttonViewPlayerLedger.Name = "buttonViewPlayerLedger";
            this.buttonViewPlayerLedger.Size = new System.Drawing.Size(203, 32);
            this.buttonViewPlayerLedger.TabIndex = 192;
            this.buttonViewPlayerLedger.Text = "View Player Ledger";
            this.buttonViewPlayerLedger.UseVisualStyleBackColor = false;
            this.buttonViewPlayerLedger.Click += new System.EventHandler(this.buttonViewPlayerLedger_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Blue Highway Condensed", 20F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(12, 617);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 27);
            this.label3.TabIndex = 195;
            this.label3.Text = "Total:";
            // 
            // labelTotalOwesUs
            // 
            this.labelTotalOwesUs.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTotalOwesUs.Font = new System.Drawing.Font("Blue Highway Condensed", 20F, System.Drawing.FontStyle.Bold);
            this.labelTotalOwesUs.Location = new System.Drawing.Point(106, 617);
            this.labelTotalOwesUs.Name = "labelTotalOwesUs";
            this.labelTotalOwesUs.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelTotalOwesUs.Size = new System.Drawing.Size(121, 27);
            this.labelTotalOwesUs.TabIndex = 196;
            this.labelTotalOwesUs.Text = "0";
            this.labelTotalOwesUs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Blue Highway Condensed", 20F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(233, 617);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 27);
            this.label6.TabIndex = 197;
            this.label6.Text = "Total:";
            // 
            // labelTotalWeOwe
            // 
            this.labelTotalWeOwe.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTotalWeOwe.Font = new System.Drawing.Font("Blue Highway Condensed", 20F, System.Drawing.FontStyle.Bold);
            this.labelTotalWeOwe.Location = new System.Drawing.Point(325, 615);
            this.labelTotalWeOwe.Name = "labelTotalWeOwe";
            this.labelTotalWeOwe.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelTotalWeOwe.Size = new System.Drawing.Size(121, 27);
            this.labelTotalWeOwe.TabIndex = 198;
            this.labelTotalWeOwe.Text = "0";
            this.labelTotalWeOwe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxTransactionNotes
            // 
            this.textBoxTransactionNotes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxTransactionNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTransactionNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxTransactionNotes.Location = new System.Drawing.Point(461, 574);
            this.textBoxTransactionNotes.Name = "textBoxTransactionNotes";
            this.textBoxTransactionNotes.Size = new System.Drawing.Size(207, 26);
            this.textBoxTransactionNotes.TabIndex = 183;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(457, 552);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 19);
            this.label7.TabIndex = 199;
            this.label7.Text = "Transaction Notes";
            // 
            // textBoxPlayerNotes
            // 
            this.textBoxPlayerNotes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPlayerNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPlayerNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxPlayerNotes.Location = new System.Drawing.Point(462, 625);
            this.textBoxPlayerNotes.Multiline = true;
            this.textBoxPlayerNotes.Name = "textBoxPlayerNotes";
            this.textBoxPlayerNotes.ReadOnly = true;
            this.textBoxPlayerNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxPlayerNotes.Size = new System.Drawing.Size(207, 37);
            this.textBoxPlayerNotes.TabIndex = 202;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(457, 603);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 19);
            this.label8.TabIndex = 201;
            this.label8.Text = "Player Notes";
            // 
            // listViewTransactionWindow
            // 
            this.listViewTransactionWindow.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listViewTransactionWindow.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Type,
            this.Amount});
            this.listViewTransactionWindow.Location = new System.Drawing.Point(704, 532);
            this.listViewTransactionWindow.Name = "listViewTransactionWindow";
            this.listViewTransactionWindow.Size = new System.Drawing.Size(201, 130);
            this.listViewTransactionWindow.TabIndex = 203;
            this.listViewTransactionWindow.UseCompatibleStateImageBehavior = false;
            this.listViewTransactionWindow.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 37;
            // 
            // Type
            // 
            this.Type.Text = "Type";
            this.Type.Width = 90;
            // 
            // Amount
            // 
            this.Amount.Text = "Amount";
            this.Amount.Width = 70;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonRefresh.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonRefresh.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRefresh.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonRefresh.Location = new System.Drawing.Point(476, 129);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(169, 27);
            this.buttonRefresh.TabIndex = 204;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonPayAll
            // 
            this.buttonPayAll.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonPayAll.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonPayAll.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPayAll.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonPayAll.Location = new System.Drawing.Point(257, 645);
            this.buttonPayAll.Name = "buttonPayAll";
            this.buttonPayAll.Size = new System.Drawing.Size(169, 29);
            this.buttonPayAll.TabIndex = 205;
            this.buttonPayAll.Text = "Pay All";
            this.buttonPayAll.UseVisualStyleBackColor = false;
            this.buttonPayAll.Click += new System.EventHandler(this.buttonPayAll_Click);
            // 
            // labelTotalFundsText
            // 
            this.labelTotalFundsText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTotalFundsText.AutoSize = true;
            this.labelTotalFundsText.Font = new System.Drawing.Font("Blue Highway Condensed", 20F, System.Drawing.FontStyle.Bold);
            this.labelTotalFundsText.Location = new System.Drawing.Point(172, 160);
            this.labelTotalFundsText.Name = "labelTotalFundsText";
            this.labelTotalFundsText.Size = new System.Drawing.Size(132, 27);
            this.labelTotalFundsText.TabIndex = 145;
            this.labelTotalFundsText.Text = "Accounting Totals";
            // 
            // listViewAccountingTotals
            // 
            this.listViewAccountingTotals.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listViewAccountingTotals.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Interest,
            this.Progressive,
            this.PoolFunds,
            this.RealCash});
            this.listViewAccountingTotals.FullRowSelect = true;
            this.listViewAccountingTotals.HideSelection = false;
            this.listViewAccountingTotals.Location = new System.Drawing.Point(12, 191);
            this.listViewAccountingTotals.MultiSelect = false;
            this.listViewAccountingTotals.Name = "listViewAccountingTotals";
            this.listViewAccountingTotals.Size = new System.Drawing.Size(434, 104);
            this.listViewAccountingTotals.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewAccountingTotals.TabIndex = 206;
            this.listViewAccountingTotals.UseCompatibleStateImageBehavior = false;
            this.listViewAccountingTotals.View = System.Windows.Forms.View.Details;
            // 
            // Interest
            // 
            this.Interest.Text = "Interest";
            this.Interest.Width = 96;
            // 
            // Progressive
            // 
            this.Progressive.Text = "Progressive";
            this.Progressive.Width = 106;
            // 
            // PoolFunds
            // 
            this.PoolFunds.Text = "Pool Funds";
            this.PoolFunds.Width = 111;
            // 
            // RealCash
            // 
            this.RealCash.Text = "RealCash";
            this.RealCash.Width = 116;
            // 
            // upDownReceiveAmount
            // 
            this.upDownReceiveAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.upDownReceiveAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.upDownReceiveAmount.Location = new System.Drawing.Point(461, 361);
            this.upDownReceiveAmount.Maximum = new decimal(new int[] {
            35000,
            0,
            0,
            0});
            this.upDownReceiveAmount.Minimum = new decimal(new int[] {
            35000,
            0,
            0,
            -2147483648});
            this.upDownReceiveAmount.Name = "upDownReceiveAmount";
            this.upDownReceiveAmount.Size = new System.Drawing.Size(207, 26);
            this.upDownReceiveAmount.TabIndex = 207;
            this.upDownReceiveAmount.Visible = false;
            // 
            // labelReceiveAmount
            // 
            this.labelReceiveAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelReceiveAmount.AutoSize = true;
            this.labelReceiveAmount.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReceiveAmount.Location = new System.Drawing.Point(457, 339);
            this.labelReceiveAmount.Name = "labelReceiveAmount";
            this.labelReceiveAmount.Size = new System.Drawing.Size(117, 19);
            this.labelReceiveAmount.TabIndex = 208;
            this.labelReceiveAmount.Text = "Receive Amount";
            this.labelReceiveAmount.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.MidnightBlue;
            this.button1.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(151, 302);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 27);
            this.button1.TabIndex = 209;
            this.button1.Text = "View House Ledger";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonFixTransactions
            // 
            this.buttonFixTransactions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonFixTransactions.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonFixTransactions.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFixTransactions.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonFixTransactions.Location = new System.Drawing.Point(12, 91);
            this.buttonFixTransactions.Name = "buttonFixTransactions";
            this.buttonFixTransactions.Size = new System.Drawing.Size(169, 27);
            this.buttonFixTransactions.TabIndex = 210;
            this.buttonFixTransactions.Text = "Fix Transactions";
            this.buttonFixTransactions.UseVisualStyleBackColor = false;
            this.buttonFixTransactions.Visible = false;
            this.buttonFixTransactions.Click += new System.EventHandler(this.buttonFixTransactions_Click);
            // 
            // buttonPayProgressive
            // 
            this.buttonPayProgressive.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonPayProgressive.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonPayProgressive.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPayProgressive.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonPayProgressive.Location = new System.Drawing.Point(715, 91);
            this.buttonPayProgressive.Name = "buttonPayProgressive";
            this.buttonPayProgressive.Size = new System.Drawing.Size(169, 49);
            this.buttonPayProgressive.TabIndex = 211;
            this.buttonPayProgressive.Text = "Pay Progressive";
            this.buttonPayProgressive.UseVisualStyleBackColor = false;
            this.buttonPayProgressive.Click += new System.EventHandler(this.buttonPayProgressive_Click);
            // 
            // FormAccounting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(972, 782);
            this.Controls.Add(this.buttonPayProgressive);
            this.Controls.Add(this.buttonFixTransactions);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelReceiveAmount);
            this.Controls.Add(this.upDownReceiveAmount);
            this.Controls.Add(this.listViewAccountingTotals);
            this.Controls.Add(this.buttonPayAll);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.listViewTransactionWindow);
            this.Controls.Add(this.textBoxPlayerNotes);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxTransactionNotes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelTotalWeOwe);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelTotalOwesUs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonViewPlayerLedger);
            this.Controls.Add(this.listViewWhoWeOwe);
            this.Controls.Add(this.listViewWhoOwesUs);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.textBoxPreferredMethod);
            this.Controls.Add(this.labelPreferredMethod);
            this.Controls.Add(this.labelSelectWeekText);
            this.Controls.Add(this.comboBoxSelectWeek);
            this.Controls.Add(this.upDownAmount);
            this.Controls.Add(this.comboBoxPayMethod);
            this.Controls.Add(this.textBoxCheckNumber);
            this.Controls.Add(this.labelCheckNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.comboBoxSelectPayReceive);
            this.Controls.Add(this.labelSelectPlayerTextEdit);
            this.Controls.Add(this.listBoxPlayersList);
            this.Controls.Add(this.labelTotalFundsText);
            this.Controls.Add(this.labelWhoWeOweText);
            this.Controls.Add(this.labelWhoOwesUsText);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAccounting";
            this.Text = "Accounting";
            this.Load += new System.EventHandler(this.FormAccounting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.playersDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seasonsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seasons1_5BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seasons6_10BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seasons11_17BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownReceiveAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAccountingText;
        private System.Windows.Forms.Label labelWhoOwesUsText;
        private System.Windows.Forms.Label labelWhoWeOweText;
        private System.Windows.Forms.Button buttonViewMasterAccounting;
        private System.Windows.Forms.ListBox listBoxPlayersList;
        private System.Windows.Forms.TextBox textBoxSearchPlayer;
        private System.Windows.Forms.Label labelSearchPlayerText;
        private System.Windows.Forms.ComboBox comboBoxPayMethod;
        private System.Windows.Forms.TextBox textBoxCheckNumber;
        private System.Windows.Forms.Label labelCheckNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.ComboBox comboBoxSelectPayReceive;
        private System.Windows.Forms.Label labelSelectPlayerTextEdit;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSelectedSeason;
        private AccountingDataSet accountingDataSet;
        private System.Windows.Forms.BindingSource accountingBindingSource;
        private AccountingDataSetTableAdapters.AccountingTableAdapter accountingTableAdapter;
        private AccountingDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private PlayersDBDataSet playersDBDataSet;
        private System.Windows.Forms.BindingSource playersBindingSource;
        private PlayersDBDataSetTableAdapters.PlayersTableAdapter playersTableAdapter;
        private PlayersDBDataSetTableAdapters.TableAdapterManager tableAdapterManager1;
        private SeasonsDBDataSet seasonsDBDataSet;
        private System.Windows.Forms.BindingSource seasons1_5BindingSource;
        private SeasonsDBDataSetTableAdapters.Seasons1_5TableAdapter seasons1_5TableAdapter;
        private SeasonsDBDataSetTableAdapters.TableAdapterManager tableAdapterManager2;
        private SeasonsDBDataSetTableAdapters.Seasons6_10TableAdapter seasons6_10TableAdapter;
        private System.Windows.Forms.BindingSource seasons6_10BindingSource;
        private SeasonsDBDataSetTableAdapters.Seasons11_17TableAdapter seasons11_17TableAdapter;
        private System.Windows.Forms.BindingSource seasons11_17BindingSource;
        private System.Windows.Forms.NumericUpDown upDownAmount;
        private System.Windows.Forms.Label labelSelectWeekText;
        private System.Windows.Forms.ComboBox comboBoxSelectWeek;
        private System.Windows.Forms.TextBox textBoxPreferredMethod;
        private System.Windows.Forms.Label labelPreferredMethod;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonChargeAllBuyIn;
        private System.Windows.Forms.Button buttonGroups;
        private TransactionsDBDataSet transactionsDBDataSet;
        private System.Windows.Forms.BindingSource transactionsBindingSource;
        private TransactionsDBDataSetTableAdapters.TransactionsTableAdapter transactionsTableAdapter;
        private TransactionsDBDataSetTableAdapters.TableAdapterManager tableAdapterManager3;
        private System.Windows.Forms.ListView listViewWhoOwesUs;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView listViewWhoWeOwe;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button buttonViewPlayerLedger;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelTotalOwesUs;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelTotalWeOwe;
        private System.Windows.Forms.TextBox textBoxTransactionNotes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxPlayerNotes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView listViewTransactionWindow;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ColumnHeader Amount;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonPayAll;
        private System.Windows.Forms.Label labelTotalFundsText;
        private System.Windows.Forms.ListView listViewAccountingTotals;
        private System.Windows.Forms.ColumnHeader Interest;
        private System.Windows.Forms.ColumnHeader PoolFunds;
        private System.Windows.Forms.ColumnHeader Progressive;
        private System.Windows.Forms.NumericUpDown upDownReceiveAmount;
        private System.Windows.Forms.Label labelReceiveAmount;
        private System.Windows.Forms.ColumnHeader RealCash;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonFixTransactions;
        private System.Windows.Forms.Button buttonPayProgressive;
    }
}