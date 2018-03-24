namespace Big8_MAIN
{
    partial class FormGroups
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelSelectWeekText = new System.Windows.Forms.Label();
            this.comboBoxSelectWeek = new System.Windows.Forms.ComboBox();
            this.textBoxSelectedSeason = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelGroupsText = new System.Windows.Forms.Label();
            this.listBoxGroupNames = new System.Windows.Forms.ListBox();
            this.listBoxPlayerNames = new System.Windows.Forms.ListBox();
            this.labelAddressText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelGroupLeaderText = new System.Windows.Forms.Label();
            this.labelPreferredPayMethodText = new System.Windows.Forms.Label();
            this.labelTotalGroupOwesText = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelGroupLeaderName = new System.Windows.Forms.Label();
            this.labelPayMethod = new System.Windows.Forms.Label();
            this.labelTotalGroupOwes = new System.Windows.Forms.Label();
            this.labelTotalWeOweGroup = new System.Windows.Forms.Label();
            this.comboBoxPayMethod = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonPayGroup = new System.Windows.Forms.Button();
            this.accountingDataSet = new Big8_MAIN.AccountingDataSet();
            this.accountingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.accountingTableAdapter = new Big8_MAIN.AccountingDataSetTableAdapters.AccountingTableAdapter();
            this.tableAdapterManager = new Big8_MAIN.AccountingDataSetTableAdapters.TableAdapterManager();
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
            this.seasons11_17BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.seasons6_10BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transactionsDBDataSet = new Big8_MAIN.TransactionsDBDataSet();
            this.transactionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transactionsTableAdapter = new Big8_MAIN.TransactionsDBDataSetTableAdapters.TransactionsTableAdapter();
            this.tableAdapterManager3 = new Big8_MAIN.TransactionsDBDataSetTableAdapters.TableAdapterManager();
            this.textBoxCheckNumber = new System.Windows.Forms.TextBox();
            this.labelCheckNumber = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accountingDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seasonsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seasons1_5BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seasons11_17BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seasons6_10BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel2.Controls.Add(this.labelSelectWeekText);
            this.panel2.Controls.Add(this.comboBoxSelectWeek);
            this.panel2.Controls.Add(this.textBoxSelectedSeason);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.labelGroupsText);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(739, 68);
            this.panel2.TabIndex = 185;
            // 
            // labelSelectWeekText
            // 
            this.labelSelectWeekText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSelectWeekText.AutoSize = true;
            this.labelSelectWeekText.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold);
            this.labelSelectWeekText.ForeColor = System.Drawing.SystemColors.Control;
            this.labelSelectWeekText.Location = new System.Drawing.Point(532, 7);
            this.labelSelectWeekText.Name = "labelSelectWeekText";
            this.labelSelectWeekText.Size = new System.Drawing.Size(103, 21);
            this.labelSelectWeekText.TabIndex = 212;
            this.labelSelectWeekText.Text = "Select Week";
            // 
            // comboBoxSelectWeek
            // 
            this.comboBoxSelectWeek.Anchor = System.Windows.Forms.AnchorStyles.Top;
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
            this.comboBoxSelectWeek.Location = new System.Drawing.Point(535, 30);
            this.comboBoxSelectWeek.MaxDropDownItems = 17;
            this.comboBoxSelectWeek.Name = "comboBoxSelectWeek";
            this.comboBoxSelectWeek.Size = new System.Drawing.Size(190, 28);
            this.comboBoxSelectWeek.TabIndex = 211;
            // 
            // textBoxSelectedSeason
            // 
            this.textBoxSelectedSeason.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxSelectedSeason.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxSelectedSeason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSelectedSeason.Enabled = false;
            this.textBoxSelectedSeason.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxSelectedSeason.Location = new System.Drawing.Point(27, 32);
            this.textBoxSelectedSeason.Name = "textBoxSelectedSeason";
            this.textBoxSelectedSeason.Size = new System.Drawing.Size(190, 26);
            this.textBoxSelectedSeason.TabIndex = 209;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(23, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 21);
            this.label4.TabIndex = 210;
            this.label4.Text = "Selected Season";
            // 
            // labelGroupsText
            // 
            this.labelGroupsText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelGroupsText.AutoSize = true;
            this.labelGroupsText.Font = new System.Drawing.Font("Blue Highway Condensed", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGroupsText.ForeColor = System.Drawing.SystemColors.Control;
            this.labelGroupsText.Location = new System.Drawing.Point(297, 1);
            this.labelGroupsText.Name = "labelGroupsText";
            this.labelGroupsText.Size = new System.Drawing.Size(129, 62);
            this.labelGroupsText.TabIndex = 1;
            this.labelGroupsText.Text = "Groups";
            // 
            // listBoxGroupNames
            // 
            this.listBoxGroupNames.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxGroupNames.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxGroupNames.FormattingEnabled = true;
            this.listBoxGroupNames.ItemHeight = 21;
            this.listBoxGroupNames.Location = new System.Drawing.Point(27, 131);
            this.listBoxGroupNames.Name = "listBoxGroupNames";
            this.listBoxGroupNames.ScrollAlwaysVisible = true;
            this.listBoxGroupNames.Size = new System.Drawing.Size(237, 151);
            this.listBoxGroupNames.Sorted = true;
            this.listBoxGroupNames.TabIndex = 187;
            this.listBoxGroupNames.SelectedIndexChanged += new System.EventHandler(this.listBoxGroupNames_SelectedIndexChanged);
            // 
            // listBoxPlayerNames
            // 
            this.listBoxPlayerNames.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxPlayerNames.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold);
            this.listBoxPlayerNames.FormattingEnabled = true;
            this.listBoxPlayerNames.ItemHeight = 21;
            this.listBoxPlayerNames.Location = new System.Drawing.Point(29, 312);
            this.listBoxPlayerNames.Name = "listBoxPlayerNames";
            this.listBoxPlayerNames.ScrollAlwaysVisible = true;
            this.listBoxPlayerNames.Size = new System.Drawing.Size(237, 193);
            this.listBoxPlayerNames.Sorted = true;
            this.listBoxPlayerNames.TabIndex = 188;
            this.listBoxPlayerNames.SelectedIndexChanged += new System.EventHandler(this.listBoxPlayerNames_SelectedIndexChanged);
            // 
            // labelAddressText
            // 
            this.labelAddressText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAddressText.AutoSize = true;
            this.labelAddressText.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddressText.Location = new System.Drawing.Point(23, 107);
            this.labelAddressText.Name = "labelAddressText";
            this.labelAddressText.Size = new System.Drawing.Size(113, 21);
            this.labelAddressText.TabIndex = 189;
            this.labelAddressText.Text = "List of Groups";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 288);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 21);
            this.label1.TabIndex = 190;
            this.label1.Text = "Players in Selected Group";
            // 
            // labelGroupLeaderText
            // 
            this.labelGroupLeaderText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelGroupLeaderText.AutoSize = true;
            this.labelGroupLeaderText.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGroupLeaderText.Location = new System.Drawing.Point(285, 141);
            this.labelGroupLeaderText.Name = "labelGroupLeaderText";
            this.labelGroupLeaderText.Size = new System.Drawing.Size(113, 21);
            this.labelGroupLeaderText.TabIndex = 191;
            this.labelGroupLeaderText.Text = "Group Leader:";
            // 
            // labelPreferredPayMethodText
            // 
            this.labelPreferredPayMethodText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPreferredPayMethodText.AutoSize = true;
            this.labelPreferredPayMethodText.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPreferredPayMethodText.Location = new System.Drawing.Point(285, 199);
            this.labelPreferredPayMethodText.Name = "labelPreferredPayMethodText";
            this.labelPreferredPayMethodText.Size = new System.Drawing.Size(214, 21);
            this.labelPreferredPayMethodText.TabIndex = 193;
            this.labelPreferredPayMethodText.Text = "Preferred Payment Method:";
            // 
            // labelTotalGroupOwesText
            // 
            this.labelTotalGroupOwesText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTotalGroupOwesText.AutoSize = true;
            this.labelTotalGroupOwesText.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalGroupOwesText.Location = new System.Drawing.Point(285, 250);
            this.labelTotalGroupOwesText.Name = "labelTotalGroupOwesText";
            this.labelTotalGroupOwesText.Size = new System.Drawing.Size(148, 21);
            this.labelTotalGroupOwesText.TabIndex = 195;
            this.labelTotalGroupOwesText.Text = "Total Group Owes:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(285, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 21);
            this.label2.TabIndex = 197;
            this.label2.Text = "Total We Owe Group:";
            // 
            // labelGroupLeaderName
            // 
            this.labelGroupLeaderName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelGroupLeaderName.Font = new System.Drawing.Font("Blue Highway Condensed", 20F, System.Drawing.FontStyle.Bold);
            this.labelGroupLeaderName.Location = new System.Drawing.Point(454, 141);
            this.labelGroupLeaderName.Name = "labelGroupLeaderName";
            this.labelGroupLeaderName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelGroupLeaderName.Size = new System.Drawing.Size(222, 27);
            this.labelGroupLeaderName.TabIndex = 202;
            this.labelGroupLeaderName.Text = "Jitterz";
            this.labelGroupLeaderName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelPayMethod
            // 
            this.labelPayMethod.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPayMethod.Font = new System.Drawing.Font("Blue Highway Condensed", 20F, System.Drawing.FontStyle.Bold);
            this.labelPayMethod.Location = new System.Drawing.Point(501, 193);
            this.labelPayMethod.Name = "labelPayMethod";
            this.labelPayMethod.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelPayMethod.Size = new System.Drawing.Size(175, 27);
            this.labelPayMethod.TabIndex = 203;
            this.labelPayMethod.Text = "Cash";
            this.labelPayMethod.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelTotalGroupOwes
            // 
            this.labelTotalGroupOwes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTotalGroupOwes.Font = new System.Drawing.Font("Blue Highway Condensed", 20F, System.Drawing.FontStyle.Bold);
            this.labelTotalGroupOwes.Location = new System.Drawing.Point(486, 250);
            this.labelTotalGroupOwes.Name = "labelTotalGroupOwes";
            this.labelTotalGroupOwes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelTotalGroupOwes.Size = new System.Drawing.Size(190, 27);
            this.labelTotalGroupOwes.TabIndex = 204;
            this.labelTotalGroupOwes.Text = "0";
            this.labelTotalGroupOwes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelTotalWeOweGroup
            // 
            this.labelTotalWeOweGroup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTotalWeOweGroup.Font = new System.Drawing.Font("Blue Highway Condensed", 20F, System.Drawing.FontStyle.Bold);
            this.labelTotalWeOweGroup.Location = new System.Drawing.Point(496, 303);
            this.labelTotalWeOweGroup.Name = "labelTotalWeOweGroup";
            this.labelTotalWeOweGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelTotalWeOweGroup.Size = new System.Drawing.Size(180, 27);
            this.labelTotalWeOweGroup.TabIndex = 205;
            this.labelTotalWeOweGroup.Text = "1,569,456";
            this.labelTotalWeOweGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            "Generic Charge"});
            this.comboBoxPayMethod.Location = new System.Drawing.Point(387, 376);
            this.comboBoxPayMethod.Name = "comboBoxPayMethod";
            this.comboBoxPayMethod.Size = new System.Drawing.Size(207, 28);
            this.comboBoxPayMethod.TabIndex = 207;
            this.comboBoxPayMethod.SelectedIndexChanged += new System.EventHandler(this.comboBoxPayMethod_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(384, 353);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 19);
            this.label3.TabIndex = 206;
            this.label3.Text = "Payment Method";
            // 
            // buttonPayGroup
            // 
            this.buttonPayGroup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonPayGroup.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonPayGroup.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPayGroup.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonPayGroup.Location = new System.Drawing.Point(407, 465);
            this.buttonPayGroup.Name = "buttonPayGroup";
            this.buttonPayGroup.Size = new System.Drawing.Size(169, 62);
            this.buttonPayGroup.TabIndex = 208;
            this.buttonPayGroup.Text = "Pay Group";
            this.buttonPayGroup.UseVisualStyleBackColor = false;
            this.buttonPayGroup.Click += new System.EventHandler(this.buttonPayGroup_Click);
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
            // seasons11_17BindingSource
            // 
            this.seasons11_17BindingSource.DataMember = "Seasons11_17";
            this.seasons11_17BindingSource.DataSource = this.seasonsDBDataSet;
            // 
            // seasons6_10BindingSource
            // 
            this.seasons6_10BindingSource.DataMember = "Seasons6_10";
            this.seasons6_10BindingSource.DataSource = this.seasonsDBDataSet;
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
            // textBoxCheckNumber
            // 
            this.textBoxCheckNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxCheckNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCheckNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxCheckNumber.Location = new System.Drawing.Point(387, 433);
            this.textBoxCheckNumber.Name = "textBoxCheckNumber";
            this.textBoxCheckNumber.Size = new System.Drawing.Size(207, 26);
            this.textBoxCheckNumber.TabIndex = 210;
            this.textBoxCheckNumber.Visible = false;
            // 
            // labelCheckNumber
            // 
            this.labelCheckNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCheckNumber.AutoSize = true;
            this.labelCheckNumber.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCheckNumber.Location = new System.Drawing.Point(384, 410);
            this.labelCheckNumber.Name = "labelCheckNumber";
            this.labelCheckNumber.Size = new System.Drawing.Size(105, 19);
            this.labelCheckNumber.TabIndex = 209;
            this.labelCheckNumber.Text = "Check Number";
            this.labelCheckNumber.Visible = false;
            // 
            // FormGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(739, 549);
            this.Controls.Add(this.textBoxCheckNumber);
            this.Controls.Add(this.labelCheckNumber);
            this.Controls.Add(this.buttonPayGroup);
            this.Controls.Add(this.comboBoxPayMethod);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelTotalWeOweGroup);
            this.Controls.Add(this.labelTotalGroupOwes);
            this.Controls.Add(this.labelPayMethod);
            this.Controls.Add(this.labelGroupLeaderName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelTotalGroupOwesText);
            this.Controls.Add(this.labelPreferredPayMethodText);
            this.Controls.Add(this.labelGroupLeaderText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelAddressText);
            this.Controls.Add(this.listBoxPlayerNames);
            this.Controls.Add(this.listBoxGroupNames);
            this.Controls.Add(this.panel2);
            this.Name = "FormGroups";
            this.Text = "Groups";
            this.Load += new System.EventHandler(this.FormGroups_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accountingDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seasonsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seasons1_5BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seasons11_17BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seasons6_10BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelGroupsText;
        private System.Windows.Forms.ListBox listBoxGroupNames;
        private System.Windows.Forms.ListBox listBoxPlayerNames;
        private System.Windows.Forms.Label labelAddressText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelGroupLeaderText;
        private System.Windows.Forms.Label labelPreferredPayMethodText;
        private System.Windows.Forms.Label labelTotalGroupOwesText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelGroupLeaderName;
        private System.Windows.Forms.Label labelPayMethod;
        private System.Windows.Forms.Label labelTotalGroupOwes;
        private System.Windows.Forms.Label labelTotalWeOweGroup;
        private System.Windows.Forms.ComboBox comboBoxPayMethod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonPayGroup;
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
        private SeasonsDBDataSetTableAdapters.Seasons11_17TableAdapter seasons11_17TableAdapter;
        private System.Windows.Forms.BindingSource seasons11_17BindingSource;
        private SeasonsDBDataSetTableAdapters.Seasons6_10TableAdapter seasons6_10TableAdapter;
        private System.Windows.Forms.BindingSource seasons6_10BindingSource;
        private System.Windows.Forms.TextBox textBoxSelectedSeason;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelSelectWeekText;
        private System.Windows.Forms.ComboBox comboBoxSelectWeek;
        private TransactionsDBDataSet transactionsDBDataSet;
        private System.Windows.Forms.BindingSource transactionsBindingSource;
        private TransactionsDBDataSetTableAdapters.TransactionsTableAdapter transactionsTableAdapter;
        private TransactionsDBDataSetTableAdapters.TableAdapterManager tableAdapterManager3;
        private System.Windows.Forms.TextBox textBoxCheckNumber;
        private System.Windows.Forms.Label labelCheckNumber;
    }
}