namespace Big8_MAIN
{
    partial class FormNewSeason
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewSeason));
            this.textBoxSeasonNameSeason = new System.Windows.Forms.TextBox();
            this.labelSeasonNameText = new System.Windows.Forms.Label();
            this.buttonSubmitNewSeason = new System.Windows.Forms.Button();
            this.seasonsDBDataSet = new Big8_MAIN.SeasonsDBDataSet();
            this.seasons1_5BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.seasons1_5TableAdapter = new Big8_MAIN.SeasonsDBDataSetTableAdapters.Seasons1_5TableAdapter();
            this.tableAdapterManager = new Big8_MAIN.SeasonsDBDataSetTableAdapters.TableAdapterManager();
            this.seasons11_17TableAdapter = new Big8_MAIN.SeasonsDBDataSetTableAdapters.Seasons11_17TableAdapter();
            this.seasons6_10TableAdapter = new Big8_MAIN.SeasonsDBDataSetTableAdapters.Seasons6_10TableAdapter();
            this.seasons11_17BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.seasons6_10BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.accountingDataSet = new Big8_MAIN.AccountingDataSet();
            this.accountingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.accountingTableAdapter = new Big8_MAIN.AccountingDataSetTableAdapters.AccountingTableAdapter();
            this.tableAdapterManager1 = new Big8_MAIN.AccountingDataSetTableAdapters.TableAdapterManager();
            this.playersDBDataSet = new Big8_MAIN.PlayersDBDataSet();
            this.playersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.playersTableAdapter = new Big8_MAIN.PlayersDBDataSetTableAdapters.PlayersTableAdapter();
            this.tableAdapterManager2 = new Big8_MAIN.PlayersDBDataSetTableAdapters.TableAdapterManager();
            this.checkBoxMakePlayersInactive = new System.Windows.Forms.CheckBox();
            this.checkBoxResetPlayerPicks = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.seasonsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seasons1_5BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seasons11_17BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seasons6_10BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxSeasonNameSeason
            // 
            this.textBoxSeasonNameSeason.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxSeasonNameSeason.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxSeasonNameSeason.Location = new System.Drawing.Point(32, 108);
            this.textBoxSeasonNameSeason.Name = "textBoxSeasonNameSeason";
            this.textBoxSeasonNameSeason.Size = new System.Drawing.Size(260, 26);
            this.textBoxSeasonNameSeason.TabIndex = 140;
            // 
            // labelSeasonNameText
            // 
            this.labelSeasonNameText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSeasonNameText.AutoSize = true;
            this.labelSeasonNameText.Font = new System.Drawing.Font("Blue Highway", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSeasonNameText.Location = new System.Drawing.Point(28, 85);
            this.labelSeasonNameText.Name = "labelSeasonNameText";
            this.labelSeasonNameText.Size = new System.Drawing.Size(173, 23);
            this.labelSeasonNameText.TabIndex = 139;
            this.labelSeasonNameText.Text = "Enter Season Name";
            // 
            // buttonSubmitNewSeason
            // 
            this.buttonSubmitNewSeason.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSubmitNewSeason.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonSubmitNewSeason.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold);
            this.buttonSubmitNewSeason.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonSubmitNewSeason.Location = new System.Drawing.Point(80, 136);
            this.buttonSubmitNewSeason.Name = "buttonSubmitNewSeason";
            this.buttonSubmitNewSeason.Size = new System.Drawing.Size(169, 26);
            this.buttonSubmitNewSeason.TabIndex = 242;
            this.buttonSubmitNewSeason.Text = "Submit";
            this.buttonSubmitNewSeason.UseVisualStyleBackColor = false;
            this.buttonSubmitNewSeason.Click += new System.EventHandler(this.buttonSubmitNewSeason_Click);
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
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Seasons1_5TableAdapter = this.seasons1_5TableAdapter;
            this.tableAdapterManager.Seasons11_17TableAdapter = this.seasons11_17TableAdapter;
            this.tableAdapterManager.Seasons6_10TableAdapter = this.seasons6_10TableAdapter;
            this.tableAdapterManager.UpdateOrder = Big8_MAIN.SeasonsDBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
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
            // tableAdapterManager2
            // 
            this.tableAdapterManager2.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager2.PlayersTableAdapter = this.playersTableAdapter;
            this.tableAdapterManager2.UpdateOrder = Big8_MAIN.PlayersDBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // checkBoxMakePlayersInactive
            // 
            this.checkBoxMakePlayersInactive.AutoSize = true;
            this.checkBoxMakePlayersInactive.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold);
            this.checkBoxMakePlayersInactive.Location = new System.Drawing.Point(32, 12);
            this.checkBoxMakePlayersInactive.Name = "checkBoxMakePlayersInactive";
            this.checkBoxMakePlayersInactive.Size = new System.Drawing.Size(190, 25);
            this.checkBoxMakePlayersInactive.TabIndex = 243;
            this.checkBoxMakePlayersInactive.Text = "Make Players Inactive";
            this.checkBoxMakePlayersInactive.UseVisualStyleBackColor = true;
            // 
            // checkBoxResetPlayerPicks
            // 
            this.checkBoxResetPlayerPicks.AutoSize = true;
            this.checkBoxResetPlayerPicks.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold);
            this.checkBoxResetPlayerPicks.Location = new System.Drawing.Point(32, 48);
            this.checkBoxResetPlayerPicks.Name = "checkBoxResetPlayerPicks";
            this.checkBoxResetPlayerPicks.Size = new System.Drawing.Size(167, 25);
            this.checkBoxResetPlayerPicks.TabIndex = 244;
            this.checkBoxResetPlayerPicks.Text = "Reset Player Picks";
            this.checkBoxResetPlayerPicks.UseVisualStyleBackColor = true;
            // 
            // FormNewSeason
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(324, 178);
            this.Controls.Add(this.checkBoxResetPlayerPicks);
            this.Controls.Add(this.checkBoxMakePlayersInactive);
            this.Controls.Add(this.buttonSubmitNewSeason);
            this.Controls.Add(this.textBoxSeasonNameSeason);
            this.Controls.Add(this.labelSeasonNameText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormNewSeason";
            this.Text = "Create New Season";
            this.Load += new System.EventHandler(this.FormNewSeason_Load);
            ((System.ComponentModel.ISupportInitialize)(this.seasonsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seasons1_5BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seasons11_17BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seasons6_10BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSeasonNameSeason;
        private System.Windows.Forms.Label labelSeasonNameText;
        private System.Windows.Forms.Button buttonSubmitNewSeason;
        private SeasonsDBDataSet seasonsDBDataSet;
        private System.Windows.Forms.BindingSource seasons1_5BindingSource;
        private SeasonsDBDataSetTableAdapters.Seasons1_5TableAdapter seasons1_5TableAdapter;
        private SeasonsDBDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private SeasonsDBDataSetTableAdapters.Seasons11_17TableAdapter seasons11_17TableAdapter;
        private System.Windows.Forms.BindingSource seasons11_17BindingSource;
        private SeasonsDBDataSetTableAdapters.Seasons6_10TableAdapter seasons6_10TableAdapter;
        private System.Windows.Forms.BindingSource seasons6_10BindingSource;
        private AccountingDataSet accountingDataSet;
        private System.Windows.Forms.BindingSource accountingBindingSource;
        private AccountingDataSetTableAdapters.AccountingTableAdapter accountingTableAdapter;
        private AccountingDataSetTableAdapters.TableAdapterManager tableAdapterManager1;
        private PlayersDBDataSet playersDBDataSet;
        private System.Windows.Forms.BindingSource playersBindingSource;
        private PlayersDBDataSetTableAdapters.PlayersTableAdapter playersTableAdapter;
        private PlayersDBDataSetTableAdapters.TableAdapterManager tableAdapterManager2;
        private System.Windows.Forms.CheckBox checkBoxMakePlayersInactive;
        private System.Windows.Forms.CheckBox checkBoxResetPlayerPicks;
    }
}