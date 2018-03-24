namespace Big8_MAIN
{
    partial class FormAddEditPlayers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddEditPlayers));
            this.labelAddPlayersText = new System.Windows.Forms.Label();
            this.labelPoolNameText = new System.Windows.Forms.Label();
            this.textBoxPoolNameAdd = new System.Windows.Forms.TextBox();
            this.labelBuyInAmountText = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPreferContactAdd = new System.Windows.Forms.TextBox();
            this.labelPreferContactText = new System.Windows.Forms.Label();
            this.textBoxPreferPayoutAdd = new System.Windows.Forms.TextBox();
            this.labelPreferedPayoutText = new System.Windows.Forms.Label();
            this.textBoxPhoneAdd = new System.Windows.Forms.TextBox();
            this.labelPhoneText = new System.Windows.Forms.Label();
            this.textBoxAddressAdd = new System.Windows.Forms.TextBox();
            this.labelAddressText = new System.Windows.Forms.Label();
            this.textBoxNameAdd = new System.Windows.Forms.TextBox();
            this.labelNameTextAdd = new System.Windows.Forms.Label();
            this.textBoxEmailAdd = new System.Windows.Forms.TextBox();
            this.labelEmailText = new System.Windows.Forms.Label();
            this.buttonEditPlayerAdd = new System.Windows.Forms.Button();
            this.buttonAddCurrentPlayerAdd = new System.Windows.Forms.Button();
            this.checkBoxIsActive = new System.Windows.Forms.CheckBox();
            this.playersDBDataSet = new Big8_MAIN.PlayersDBDataSet();
            this.playersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.playersTableAdapter = new Big8_MAIN.PlayersDBDataSetTableAdapters.PlayersTableAdapter();
            this.tableAdapterManager = new Big8_MAIN.PlayersDBDataSetTableAdapters.TableAdapterManager();
            this.upDownBuyInAmount = new System.Windows.Forms.NumericUpDown();
            this.upDownWins = new System.Windows.Forms.NumericUpDown();
            this.upDownCurrentWinnings = new System.Windows.Forms.NumericUpDown();
            this.labelCurrentWinnings = new System.Windows.Forms.Label();
            this.textBoxSearchPlayer = new System.Windows.Forms.TextBox();
            this.labelSearchPlayerText = new System.Windows.Forms.Label();
            this.listBoxPlayersList = new System.Windows.Forms.ListBox();
            this.buttonDeletePlayer = new System.Windows.Forms.Button();
            this.buttonNewPlayer = new System.Windows.Forms.Button();
            this.textBoxGroupName = new System.Windows.Forms.TextBox();
            this.labelNotes = new System.Windows.Forms.Label();
            this.accountingDataSet = new Big8_MAIN.AccountingDataSet();
            this.accountingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.accountingTableAdapter = new Big8_MAIN.AccountingDataSetTableAdapters.AccountingTableAdapter();
            this.tableAdapterManager1 = new Big8_MAIN.AccountingDataSetTableAdapters.TableAdapterManager();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSelectedSeason = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBoxIsGroupLeader = new System.Windows.Forms.CheckBox();
            this.transactionsDBDataSet = new Big8_MAIN.TransactionsDBDataSet();
            this.transactionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.transactionsTableAdapter = new Big8_MAIN.TransactionsDBDataSetTableAdapters.TransactionsTableAdapter();
            this.tableAdapterManager2 = new Big8_MAIN.TransactionsDBDataSetTableAdapters.TableAdapterManager();
            this.textBoxPlayerNotes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.upDownReceiveAmount = new System.Windows.Forms.NumericUpDown();
            this.labelReceiveAmount = new System.Windows.Forms.Label();
            this.labelPaymentMethod = new System.Windows.Forms.Label();
            this.comboBoxPayMethod = new System.Windows.Forms.ComboBox();
            this.checkBoxReceivePayment = new System.Windows.Forms.CheckBox();
            this.textBoxCheckNumber = new System.Windows.Forms.TextBox();
            this.labelCheckNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.playersDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownBuyInAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownWins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownCurrentWinnings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownReceiveAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAddPlayersText
            // 
            this.labelAddPlayersText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAddPlayersText.AutoSize = true;
            this.labelAddPlayersText.Font = new System.Drawing.Font("Blue Highway Condensed", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddPlayersText.ForeColor = System.Drawing.SystemColors.Control;
            this.labelAddPlayersText.Location = new System.Drawing.Point(217, 9);
            this.labelAddPlayersText.Name = "labelAddPlayersText";
            this.labelAddPlayersText.Size = new System.Drawing.Size(290, 62);
            this.labelAddPlayersText.TabIndex = 1;
            this.labelAddPlayersText.Text = "Add / Edit Players";
            // 
            // labelPoolNameText
            // 
            this.labelPoolNameText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPoolNameText.AutoSize = true;
            this.labelPoolNameText.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPoolNameText.Location = new System.Drawing.Point(17, 118);
            this.labelPoolNameText.Name = "labelPoolNameText";
            this.labelPoolNameText.Size = new System.Drawing.Size(89, 21);
            this.labelPoolNameText.TabIndex = 21;
            this.labelPoolNameText.Text = "Pool Name";
            // 
            // textBoxPoolNameAdd
            // 
            this.textBoxPoolNameAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPoolNameAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxPoolNameAdd.Location = new System.Drawing.Point(21, 142);
            this.textBoxPoolNameAdd.Name = "textBoxPoolNameAdd";
            this.textBoxPoolNameAdd.Size = new System.Drawing.Size(201, 26);
            this.textBoxPoolNameAdd.TabIndex = 1;
            // 
            // labelBuyInAmountText
            // 
            this.labelBuyInAmountText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelBuyInAmountText.AutoSize = true;
            this.labelBuyInAmountText.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBuyInAmountText.Location = new System.Drawing.Point(274, 104);
            this.labelBuyInAmountText.Name = "labelBuyInAmountText";
            this.labelBuyInAmountText.Size = new System.Drawing.Size(176, 21);
            this.labelBuyInAmountText.TabIndex = 24;
            this.labelBuyInAmountText.Text = "Charge Buy In Amount";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 436);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 21);
            this.label2.TabIndex = 26;
            this.label2.Text = "Wins";
            // 
            // textBoxPreferContactAdd
            // 
            this.textBoxPreferContactAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPreferContactAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxPreferContactAdd.Location = new System.Drawing.Point(21, 568);
            this.textBoxPreferContactAdd.Name = "textBoxPreferContactAdd";
            this.textBoxPreferContactAdd.Size = new System.Drawing.Size(201, 26);
            this.textBoxPreferContactAdd.TabIndex = 10;
            // 
            // labelPreferContactText
            // 
            this.labelPreferContactText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPreferContactText.AutoSize = true;
            this.labelPreferContactText.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPreferContactText.Location = new System.Drawing.Point(17, 544);
            this.labelPreferContactText.Name = "labelPreferContactText";
            this.labelPreferContactText.Size = new System.Drawing.Size(196, 21);
            this.labelPreferContactText.TabIndex = 29;
            this.labelPreferContactText.Text = "Prefered Contact Method";
            // 
            // textBoxPreferPayoutAdd
            // 
            this.textBoxPreferPayoutAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPreferPayoutAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxPreferPayoutAdd.Location = new System.Drawing.Point(21, 622);
            this.textBoxPreferPayoutAdd.Name = "textBoxPreferPayoutAdd";
            this.textBoxPreferPayoutAdd.Size = new System.Drawing.Size(201, 26);
            this.textBoxPreferPayoutAdd.TabIndex = 11;
            // 
            // labelPreferedPayoutText
            // 
            this.labelPreferedPayoutText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPreferedPayoutText.AutoSize = true;
            this.labelPreferedPayoutText.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPreferedPayoutText.Location = new System.Drawing.Point(17, 597);
            this.labelPreferedPayoutText.Name = "labelPreferedPayoutText";
            this.labelPreferedPayoutText.Size = new System.Drawing.Size(190, 21);
            this.labelPreferedPayoutText.TabIndex = 31;
            this.labelPreferedPayoutText.Text = "Prefered Payout Method";
            // 
            // textBoxPhoneAdd
            // 
            this.textBoxPhoneAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPhoneAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxPhoneAdd.Location = new System.Drawing.Point(21, 302);
            this.textBoxPhoneAdd.Name = "textBoxPhoneAdd";
            this.textBoxPhoneAdd.Size = new System.Drawing.Size(201, 26);
            this.textBoxPhoneAdd.TabIndex = 4;
            // 
            // labelPhoneText
            // 
            this.labelPhoneText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPhoneText.AutoSize = true;
            this.labelPhoneText.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPhoneText.Location = new System.Drawing.Point(17, 278);
            this.labelPhoneText.Name = "labelPhoneText";
            this.labelPhoneText.Size = new System.Drawing.Size(118, 21);
            this.labelPhoneText.TabIndex = 38;
            this.labelPhoneText.Text = "Phone Number";
            // 
            // textBoxAddressAdd
            // 
            this.textBoxAddressAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxAddressAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxAddressAdd.Location = new System.Drawing.Point(21, 251);
            this.textBoxAddressAdd.Name = "textBoxAddressAdd";
            this.textBoxAddressAdd.Size = new System.Drawing.Size(201, 26);
            this.textBoxAddressAdd.TabIndex = 3;
            // 
            // labelAddressText
            // 
            this.labelAddressText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAddressText.AutoSize = true;
            this.labelAddressText.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddressText.Location = new System.Drawing.Point(17, 227);
            this.labelAddressText.Name = "labelAddressText";
            this.labelAddressText.Size = new System.Drawing.Size(69, 21);
            this.labelAddressText.TabIndex = 36;
            this.labelAddressText.Text = "Address";
            // 
            // textBoxNameAdd
            // 
            this.textBoxNameAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNameAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxNameAdd.Location = new System.Drawing.Point(21, 195);
            this.textBoxNameAdd.Name = "textBoxNameAdd";
            this.textBoxNameAdd.Size = new System.Drawing.Size(201, 26);
            this.textBoxNameAdd.TabIndex = 2;
            // 
            // labelNameTextAdd
            // 
            this.labelNameTextAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNameTextAdd.AutoSize = true;
            this.labelNameTextAdd.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNameTextAdd.Location = new System.Drawing.Point(17, 171);
            this.labelNameTextAdd.Name = "labelNameTextAdd";
            this.labelNameTextAdd.Size = new System.Drawing.Size(52, 21);
            this.labelNameTextAdd.TabIndex = 33;
            this.labelNameTextAdd.Text = "Name";
            // 
            // textBoxEmailAdd
            // 
            this.textBoxEmailAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxEmailAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxEmailAdd.Location = new System.Drawing.Point(21, 352);
            this.textBoxEmailAdd.Name = "textBoxEmailAdd";
            this.textBoxEmailAdd.Size = new System.Drawing.Size(201, 26);
            this.textBoxEmailAdd.TabIndex = 5;
            // 
            // labelEmailText
            // 
            this.labelEmailText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelEmailText.AutoSize = true;
            this.labelEmailText.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmailText.Location = new System.Drawing.Point(17, 328);
            this.labelEmailText.Name = "labelEmailText";
            this.labelEmailText.Size = new System.Drawing.Size(50, 21);
            this.labelEmailText.TabIndex = 40;
            this.labelEmailText.Text = "Email";
            // 
            // buttonEditPlayerAdd
            // 
            this.buttonEditPlayerAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonEditPlayerAdd.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonEditPlayerAdd.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold);
            this.buttonEditPlayerAdd.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonEditPlayerAdd.Location = new System.Drawing.Point(366, 20);
            this.buttonEditPlayerAdd.Name = "buttonEditPlayerAdd";
            this.buttonEditPlayerAdd.Size = new System.Drawing.Size(169, 41);
            this.buttonEditPlayerAdd.TabIndex = 42;
            this.buttonEditPlayerAdd.Text = "Edit Current Player";
            this.buttonEditPlayerAdd.UseVisualStyleBackColor = false;
            this.buttonEditPlayerAdd.Click += new System.EventHandler(this.buttonEditPlayerAdd_Click);
            // 
            // buttonAddCurrentPlayerAdd
            // 
            this.buttonAddCurrentPlayerAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAddCurrentPlayerAdd.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonAddCurrentPlayerAdd.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold);
            this.buttonAddCurrentPlayerAdd.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonAddCurrentPlayerAdd.Location = new System.Drawing.Point(191, 20);
            this.buttonAddCurrentPlayerAdd.Name = "buttonAddCurrentPlayerAdd";
            this.buttonAddCurrentPlayerAdd.Size = new System.Drawing.Size(169, 41);
            this.buttonAddCurrentPlayerAdd.TabIndex = 13;
            this.buttonAddCurrentPlayerAdd.Text = "Add Current Player";
            this.buttonAddCurrentPlayerAdd.UseVisualStyleBackColor = false;
            this.buttonAddCurrentPlayerAdd.Click += new System.EventHandler(this.buttonAddCurrentPlayerAdd_Click);
            // 
            // checkBoxIsActive
            // 
            this.checkBoxIsActive.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxIsActive.AutoSize = true;
            this.checkBoxIsActive.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxIsActive.Location = new System.Drawing.Point(21, 90);
            this.checkBoxIsActive.Name = "checkBoxIsActive";
            this.checkBoxIsActive.Size = new System.Drawing.Size(143, 25);
            this.checkBoxIsActive.TabIndex = 45;
            this.checkBoxIsActive.TabStop = false;
            this.checkBoxIsActive.Text = "Is Player Active";
            this.checkBoxIsActive.UseVisualStyleBackColor = true;
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
            // upDownBuyInAmount
            // 
            this.upDownBuyInAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.upDownBuyInAmount.DecimalPlaces = 2;
            this.upDownBuyInAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.upDownBuyInAmount.Location = new System.Drawing.Point(278, 127);
            this.upDownBuyInAmount.Maximum = new decimal(new int[] {
            35000,
            0,
            0,
            0});
            this.upDownBuyInAmount.Name = "upDownBuyInAmount";
            this.upDownBuyInAmount.Size = new System.Drawing.Size(201, 26);
            this.upDownBuyInAmount.TabIndex = 7;
            // 
            // upDownWins
            // 
            this.upDownWins.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.upDownWins.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.upDownWins.Location = new System.Drawing.Point(21, 459);
            this.upDownWins.Maximum = new decimal(new int[] {
            35000,
            0,
            0,
            0});
            this.upDownWins.Name = "upDownWins";
            this.upDownWins.Size = new System.Drawing.Size(201, 26);
            this.upDownWins.TabIndex = 8;
            // 
            // upDownCurrentWinnings
            // 
            this.upDownCurrentWinnings.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.upDownCurrentWinnings.DecimalPlaces = 2;
            this.upDownCurrentWinnings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.upDownCurrentWinnings.Location = new System.Drawing.Point(21, 516);
            this.upDownCurrentWinnings.Maximum = new decimal(new int[] {
            35000,
            0,
            0,
            0});
            this.upDownCurrentWinnings.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.upDownCurrentWinnings.Name = "upDownCurrentWinnings";
            this.upDownCurrentWinnings.Size = new System.Drawing.Size(201, 26);
            this.upDownCurrentWinnings.TabIndex = 9;
            // 
            // labelCurrentWinnings
            // 
            this.labelCurrentWinnings.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCurrentWinnings.AutoSize = true;
            this.labelCurrentWinnings.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentWinnings.Location = new System.Drawing.Point(17, 492);
            this.labelCurrentWinnings.Name = "labelCurrentWinnings";
            this.labelCurrentWinnings.Size = new System.Drawing.Size(139, 21);
            this.labelCurrentWinnings.TabIndex = 48;
            this.labelCurrentWinnings.Text = "Current Winnings";
            // 
            // textBoxSearchPlayer
            // 
            this.textBoxSearchPlayer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxSearchPlayer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSearchPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxSearchPlayer.Location = new System.Drawing.Point(507, 36);
            this.textBoxSearchPlayer.Name = "textBoxSearchPlayer";
            this.textBoxSearchPlayer.Size = new System.Drawing.Size(201, 26);
            this.textBoxSearchPlayer.TabIndex = 51;
            this.textBoxSearchPlayer.TextChanged += new System.EventHandler(this.textBoxSearchPlayer_TextChanged);
            // 
            // labelSearchPlayerText
            // 
            this.labelSearchPlayerText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSearchPlayerText.AutoSize = true;
            this.labelSearchPlayerText.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold);
            this.labelSearchPlayerText.ForeColor = System.Drawing.SystemColors.Control;
            this.labelSearchPlayerText.Location = new System.Drawing.Point(503, 13);
            this.labelSearchPlayerText.Name = "labelSearchPlayerText";
            this.labelSearchPlayerText.Size = new System.Drawing.Size(112, 21);
            this.labelSearchPlayerText.TabIndex = 50;
            this.labelSearchPlayerText.Text = "Search Player";
            // 
            // listBoxPlayersList
            // 
            this.listBoxPlayersList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxPlayersList.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxPlayersList.FormattingEnabled = true;
            this.listBoxPlayersList.ItemHeight = 21;
            this.listBoxPlayersList.Location = new System.Drawing.Point(507, 182);
            this.listBoxPlayersList.Name = "listBoxPlayersList";
            this.listBoxPlayersList.ScrollAlwaysVisible = true;
            this.listBoxPlayersList.Size = new System.Drawing.Size(201, 445);
            this.listBoxPlayersList.TabIndex = 52;
            this.listBoxPlayersList.TabStop = false;
            this.listBoxPlayersList.SelectedIndexChanged += new System.EventHandler(this.listBoxPlayersList_SelectedIndexChanged);
            // 
            // buttonDeletePlayer
            // 
            this.buttonDeletePlayer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonDeletePlayer.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonDeletePlayer.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold);
            this.buttonDeletePlayer.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonDeletePlayer.Location = new System.Drawing.Point(539, 20);
            this.buttonDeletePlayer.Name = "buttonDeletePlayer";
            this.buttonDeletePlayer.Size = new System.Drawing.Size(169, 41);
            this.buttonDeletePlayer.TabIndex = 99;
            this.buttonDeletePlayer.Text = "Delete Current Player";
            this.buttonDeletePlayer.UseVisualStyleBackColor = false;
            this.buttonDeletePlayer.Click += new System.EventHandler(this.buttonDeletePlayer_Click);
            // 
            // buttonNewPlayer
            // 
            this.buttonNewPlayer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonNewPlayer.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonNewPlayer.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold);
            this.buttonNewPlayer.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonNewPlayer.Location = new System.Drawing.Point(16, 20);
            this.buttonNewPlayer.Name = "buttonNewPlayer";
            this.buttonNewPlayer.Size = new System.Drawing.Size(169, 41);
            this.buttonNewPlayer.TabIndex = 54;
            this.buttonNewPlayer.Text = "New Player";
            this.buttonNewPlayer.UseVisualStyleBackColor = false;
            this.buttonNewPlayer.Click += new System.EventHandler(this.buttonNewPlayer_Click);
            // 
            // textBoxGroupName
            // 
            this.textBoxGroupName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxGroupName.Location = new System.Drawing.Point(21, 403);
            this.textBoxGroupName.Name = "textBoxGroupName";
            this.textBoxGroupName.Size = new System.Drawing.Size(201, 26);
            this.textBoxGroupName.TabIndex = 6;
            // 
            // labelNotes
            // 
            this.labelNotes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNotes.AutoSize = true;
            this.labelNotes.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNotes.Location = new System.Drawing.Point(17, 379);
            this.labelNotes.Name = "labelNotes";
            this.labelNotes.Size = new System.Drawing.Size(101, 21);
            this.labelNotes.TabIndex = 57;
            this.labelNotes.Text = "Group Name";
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
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(17, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 21);
            this.label4.TabIndex = 182;
            this.label4.Text = "Selected Season";
            // 
            // textBoxSelectedSeason
            // 
            this.textBoxSelectedSeason.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxSelectedSeason.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxSelectedSeason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSelectedSeason.Enabled = false;
            this.textBoxSelectedSeason.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxSelectedSeason.Location = new System.Drawing.Point(21, 35);
            this.textBoxSelectedSeason.Name = "textBoxSelectedSeason";
            this.textBoxSelectedSeason.Size = new System.Drawing.Size(190, 26);
            this.textBoxSelectedSeason.TabIndex = 181;
            this.textBoxSelectedSeason.Text = "0";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.buttonNewPlayer);
            this.panel1.Controls.Add(this.buttonAddCurrentPlayerAdd);
            this.panel1.Controls.Add(this.buttonEditPlayerAdd);
            this.panel1.Controls.Add(this.buttonDeletePlayer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 713);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(724, 75);
            this.panel1.TabIndex = 183;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel2.Controls.Add(this.textBoxSelectedSeason);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.labelAddPlayersText);
            this.panel2.Controls.Add(this.textBoxSearchPlayer);
            this.panel2.Controls.Add(this.labelSearchPlayerText);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(724, 85);
            this.panel2.TabIndex = 184;
            // 
            // checkBoxIsGroupLeader
            // 
            this.checkBoxIsGroupLeader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxIsGroupLeader.AutoSize = true;
            this.checkBoxIsGroupLeader.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxIsGroupLeader.Location = new System.Drawing.Point(21, 661);
            this.checkBoxIsGroupLeader.Name = "checkBoxIsGroupLeader";
            this.checkBoxIsGroupLeader.Size = new System.Drawing.Size(145, 25);
            this.checkBoxIsGroupLeader.TabIndex = 187;
            this.checkBoxIsGroupLeader.TabStop = false;
            this.checkBoxIsGroupLeader.Text = "Is Group Leader";
            this.checkBoxIsGroupLeader.UseVisualStyleBackColor = true;
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
            // textBoxPlayerNotes
            // 
            this.textBoxPlayerNotes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPlayerNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxPlayerNotes.Location = new System.Drawing.Point(278, 436);
            this.textBoxPlayerNotes.Multiline = true;
            this.textBoxPlayerNotes.Name = "textBoxPlayerNotes";
            this.textBoxPlayerNotes.Size = new System.Drawing.Size(201, 212);
            this.textBoxPlayerNotes.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(274, 411);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 21);
            this.label1.TabIndex = 189;
            this.label1.Text = "Player Notes";
            // 
            // upDownReceiveAmount
            // 
            this.upDownReceiveAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.upDownReceiveAmount.DecimalPlaces = 2;
            this.upDownReceiveAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.upDownReceiveAmount.Location = new System.Drawing.Point(278, 227);
            this.upDownReceiveAmount.Maximum = new decimal(new int[] {
            35000,
            0,
            0,
            0});
            this.upDownReceiveAmount.Name = "upDownReceiveAmount";
            this.upDownReceiveAmount.Size = new System.Drawing.Size(201, 26);
            this.upDownReceiveAmount.TabIndex = 190;
            this.upDownReceiveAmount.Visible = false;
            // 
            // labelReceiveAmount
            // 
            this.labelReceiveAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelReceiveAmount.AutoSize = true;
            this.labelReceiveAmount.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReceiveAmount.Location = new System.Drawing.Point(274, 204);
            this.labelReceiveAmount.Name = "labelReceiveAmount";
            this.labelReceiveAmount.Size = new System.Drawing.Size(200, 21);
            this.labelReceiveAmount.TabIndex = 191;
            this.labelReceiveAmount.Text = "Receive Payment Amount";
            this.labelReceiveAmount.Visible = false;
            // 
            // labelPaymentMethod
            // 
            this.labelPaymentMethod.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPaymentMethod.AutoSize = true;
            this.labelPaymentMethod.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPaymentMethod.Location = new System.Drawing.Point(274, 263);
            this.labelPaymentMethod.Name = "labelPaymentMethod";
            this.labelPaymentMethod.Size = new System.Drawing.Size(197, 21);
            this.labelPaymentMethod.TabIndex = 193;
            this.labelPaymentMethod.Text = "Receive Payment Method";
            this.labelPaymentMethod.Visible = false;
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
            "Generic Credit"});
            this.comboBoxPayMethod.Location = new System.Drawing.Point(278, 287);
            this.comboBoxPayMethod.Name = "comboBoxPayMethod";
            this.comboBoxPayMethod.Size = new System.Drawing.Size(207, 28);
            this.comboBoxPayMethod.TabIndex = 194;
            this.comboBoxPayMethod.Visible = false;
            this.comboBoxPayMethod.SelectedIndexChanged += new System.EventHandler(this.comboBoxPayMethod_SelectedIndexChanged);
            // 
            // checkBoxReceivePayment
            // 
            this.checkBoxReceivePayment.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxReceivePayment.AutoSize = true;
            this.checkBoxReceivePayment.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxReceivePayment.Location = new System.Drawing.Point(278, 164);
            this.checkBoxReceivePayment.Name = "checkBoxReceivePayment";
            this.checkBoxReceivePayment.Size = new System.Drawing.Size(165, 25);
            this.checkBoxReceivePayment.TabIndex = 195;
            this.checkBoxReceivePayment.TabStop = false;
            this.checkBoxReceivePayment.Text = "Receive Payment?";
            this.checkBoxReceivePayment.UseVisualStyleBackColor = true;
            this.checkBoxReceivePayment.CheckedChanged += new System.EventHandler(this.checkBoxReceivePayment_CheckedChanged);
            // 
            // textBoxCheckNumber
            // 
            this.textBoxCheckNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxCheckNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCheckNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxCheckNumber.Location = new System.Drawing.Point(278, 352);
            this.textBoxCheckNumber.Name = "textBoxCheckNumber";
            this.textBoxCheckNumber.Size = new System.Drawing.Size(207, 26);
            this.textBoxCheckNumber.TabIndex = 196;
            this.textBoxCheckNumber.Visible = false;
            // 
            // labelCheckNumber
            // 
            this.labelCheckNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCheckNumber.AutoSize = true;
            this.labelCheckNumber.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCheckNumber.Location = new System.Drawing.Point(274, 331);
            this.labelCheckNumber.Name = "labelCheckNumber";
            this.labelCheckNumber.Size = new System.Drawing.Size(118, 21);
            this.labelCheckNumber.TabIndex = 197;
            this.labelCheckNumber.Text = "Check Number";
            this.labelCheckNumber.Visible = false;
            // 
            // FormAddEditPlayers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(724, 788);
            this.Controls.Add(this.labelCheckNumber);
            this.Controls.Add(this.textBoxCheckNumber);
            this.Controls.Add(this.checkBoxReceivePayment);
            this.Controls.Add(this.comboBoxPayMethod);
            this.Controls.Add(this.labelPaymentMethod);
            this.Controls.Add(this.upDownReceiveAmount);
            this.Controls.Add(this.checkBoxIsActive);
            this.Controls.Add(this.labelReceiveAmount);
            this.Controls.Add(this.textBoxPlayerNotes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxIsGroupLeader);
            this.Controls.Add(this.textBoxGroupName);
            this.Controls.Add(this.labelNotes);
            this.Controls.Add(this.listBoxPlayersList);
            this.Controls.Add(this.upDownCurrentWinnings);
            this.Controls.Add(this.labelCurrentWinnings);
            this.Controls.Add(this.upDownWins);
            this.Controls.Add(this.upDownBuyInAmount);
            this.Controls.Add(this.textBoxEmailAdd);
            this.Controls.Add(this.labelEmailText);
            this.Controls.Add(this.textBoxPhoneAdd);
            this.Controls.Add(this.labelPhoneText);
            this.Controls.Add(this.textBoxAddressAdd);
            this.Controls.Add(this.labelAddressText);
            this.Controls.Add(this.textBoxNameAdd);
            this.Controls.Add(this.labelNameTextAdd);
            this.Controls.Add(this.textBoxPreferPayoutAdd);
            this.Controls.Add(this.labelPreferedPayoutText);
            this.Controls.Add(this.textBoxPreferContactAdd);
            this.Controls.Add(this.labelPreferContactText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelBuyInAmountText);
            this.Controls.Add(this.textBoxPoolNameAdd);
            this.Controls.Add(this.labelPoolNameText);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FormAddEditPlayers";
            this.Text = "Add / Edit Players";
            this.Load += new System.EventHandler(this.FormAddEditPlayers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.playersDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownBuyInAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownWins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownCurrentWinnings)).EndInit();
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

        private System.Windows.Forms.Label labelAddPlayersText;
        private System.Windows.Forms.Label labelPoolNameText;
        private System.Windows.Forms.TextBox textBoxPoolNameAdd;
        private System.Windows.Forms.Label labelBuyInAmountText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPreferContactAdd;
        private System.Windows.Forms.Label labelPreferContactText;
        private System.Windows.Forms.TextBox textBoxPreferPayoutAdd;
        private System.Windows.Forms.Label labelPreferedPayoutText;
        private System.Windows.Forms.TextBox textBoxPhoneAdd;
        private System.Windows.Forms.Label labelPhoneText;
        private System.Windows.Forms.TextBox textBoxAddressAdd;
        private System.Windows.Forms.Label labelAddressText;
        private System.Windows.Forms.TextBox textBoxNameAdd;
        private System.Windows.Forms.Label labelNameTextAdd;
        private System.Windows.Forms.TextBox textBoxEmailAdd;
        private System.Windows.Forms.Label labelEmailText;
        private System.Windows.Forms.Button buttonEditPlayerAdd;
        private System.Windows.Forms.Button buttonAddCurrentPlayerAdd;
        private System.Windows.Forms.CheckBox checkBoxIsActive;
        private PlayersDBDataSet playersDBDataSet;
        private System.Windows.Forms.BindingSource playersBindingSource;
        private PlayersDBDataSetTableAdapters.PlayersTableAdapter playersTableAdapter;
        private PlayersDBDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.NumericUpDown upDownBuyInAmount;
        private System.Windows.Forms.NumericUpDown upDownWins;
        private System.Windows.Forms.NumericUpDown upDownCurrentWinnings;
        private System.Windows.Forms.Label labelCurrentWinnings;
        private System.Windows.Forms.TextBox textBoxSearchPlayer;
        private System.Windows.Forms.Label labelSearchPlayerText;
        private System.Windows.Forms.ListBox listBoxPlayersList;
        private System.Windows.Forms.Button buttonDeletePlayer;
        private System.Windows.Forms.Button buttonNewPlayer;
        private System.Windows.Forms.TextBox textBoxGroupName;
        private System.Windows.Forms.Label labelNotes;
        private AccountingDataSet accountingDataSet;
        private System.Windows.Forms.BindingSource accountingBindingSource;
        private AccountingDataSetTableAdapters.AccountingTableAdapter accountingTableAdapter;
        private AccountingDataSetTableAdapters.TableAdapterManager tableAdapterManager1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSelectedSeason;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBoxIsGroupLeader;
        private TransactionsDBDataSet transactionsDBDataSet;
        private System.Windows.Forms.BindingSource transactionsBindingSource;
        private TransactionsDBDataSetTableAdapters.TransactionsTableAdapter transactionsTableAdapter;
        private TransactionsDBDataSetTableAdapters.TableAdapterManager tableAdapterManager2;
        private System.Windows.Forms.TextBox textBoxPlayerNotes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown upDownReceiveAmount;
        private System.Windows.Forms.Label labelReceiveAmount;
        private System.Windows.Forms.Label labelPaymentMethod;
        private System.Windows.Forms.ComboBox comboBoxPayMethod;
        private System.Windows.Forms.CheckBox checkBoxReceivePayment;
        private System.Windows.Forms.TextBox textBoxCheckNumber;
        private System.Windows.Forms.Label labelCheckNumber;
    }
}