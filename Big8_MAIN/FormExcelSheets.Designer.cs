namespace Big8_MAIN
{
    partial class FormExcelSheets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExcelSheets));
            this.buttonMasterSheet = new System.Windows.Forms.Button();
            this.buttonStandings = new System.Windows.Forms.Button();
            this.buttonCreatePacket = new System.Windows.Forms.Button();
            this.buttonMasterSeason = new System.Windows.Forms.Button();
            this.seasonsDBDataSet = new Big8_MAIN.SeasonsDBDataSet();
            this.seasons1_5BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.seasons1_5TableAdapter = new Big8_MAIN.SeasonsDBDataSetTableAdapters.Seasons1_5TableAdapter();
            this.tableAdapterManager = new Big8_MAIN.SeasonsDBDataSetTableAdapters.TableAdapterManager();
            this.seasons11_17TableAdapter = new Big8_MAIN.SeasonsDBDataSetTableAdapters.Seasons11_17TableAdapter();
            this.seasons6_10TableAdapter = new Big8_MAIN.SeasonsDBDataSetTableAdapters.Seasons6_10TableAdapter();
            this.seasons11_17BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.seasons6_10BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.progressBarCreatePacket = new System.Windows.Forms.ProgressBar();
            this.labelBuildingPacket = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.seasonsDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seasons1_5BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seasons11_17BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seasons6_10BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonMasterSheet
            // 
            this.buttonMasterSheet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonMasterSheet.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonMasterSheet.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold);
            this.buttonMasterSheet.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonMasterSheet.Location = new System.Drawing.Point(72, 76);
            this.buttonMasterSheet.Name = "buttonMasterSheet";
            this.buttonMasterSheet.Size = new System.Drawing.Size(129, 29);
            this.buttonMasterSheet.TabIndex = 18;
            this.buttonMasterSheet.Text = "Master Sheet";
            this.buttonMasterSheet.UseVisualStyleBackColor = false;
            this.buttonMasterSheet.Click += new System.EventHandler(this.buttonMasterSheet_Click);
            // 
            // buttonStandings
            // 
            this.buttonStandings.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonStandings.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonStandings.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold);
            this.buttonStandings.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonStandings.Location = new System.Drawing.Point(72, 123);
            this.buttonStandings.Name = "buttonStandings";
            this.buttonStandings.Size = new System.Drawing.Size(129, 29);
            this.buttonStandings.TabIndex = 19;
            this.buttonStandings.Text = "Standings";
            this.buttonStandings.UseVisualStyleBackColor = false;
            this.buttonStandings.Click += new System.EventHandler(this.buttonStandings_Click);
            // 
            // buttonCreatePacket
            // 
            this.buttonCreatePacket.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonCreatePacket.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonCreatePacket.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold);
            this.buttonCreatePacket.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonCreatePacket.Location = new System.Drawing.Point(72, 218);
            this.buttonCreatePacket.Name = "buttonCreatePacket";
            this.buttonCreatePacket.Size = new System.Drawing.Size(129, 29);
            this.buttonCreatePacket.TabIndex = 20;
            this.buttonCreatePacket.Text = "Create Packet";
            this.buttonCreatePacket.UseVisualStyleBackColor = false;
            this.buttonCreatePacket.Click += new System.EventHandler(this.buttonCreatePacket_Click);
            // 
            // buttonMasterSeason
            // 
            this.buttonMasterSeason.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonMasterSeason.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonMasterSeason.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold);
            this.buttonMasterSeason.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonMasterSeason.Location = new System.Drawing.Point(72, 171);
            this.buttonMasterSeason.Name = "buttonMasterSeason";
            this.buttonMasterSeason.Size = new System.Drawing.Size(129, 29);
            this.buttonMasterSeason.TabIndex = 21;
            this.buttonMasterSeason.Text = "Entire Season";
            this.buttonMasterSeason.UseVisualStyleBackColor = false;
            this.buttonMasterSeason.Click += new System.EventHandler(this.buttonMasterSeason_Click);
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
            // progressBarCreatePacket
            // 
            this.progressBarCreatePacket.Location = new System.Drawing.Point(13, 278);
            this.progressBarCreatePacket.MarqueeAnimationSpeed = 1;
            this.progressBarCreatePacket.Maximum = 22;
            this.progressBarCreatePacket.Name = "progressBarCreatePacket";
            this.progressBarCreatePacket.Size = new System.Drawing.Size(245, 23);
            this.progressBarCreatePacket.Step = 1;
            this.progressBarCreatePacket.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarCreatePacket.TabIndex = 22;
            this.progressBarCreatePacket.Visible = false;
            // 
            // labelBuildingPacket
            // 
            this.labelBuildingPacket.AutoSize = true;
            this.labelBuildingPacket.BackColor = System.Drawing.Color.Transparent;
            this.labelBuildingPacket.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F);
            this.labelBuildingPacket.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.labelBuildingPacket.Location = new System.Drawing.Point(25, 255);
            this.labelBuildingPacket.Name = "labelBuildingPacket";
            this.labelBuildingPacket.Size = new System.Drawing.Size(224, 20);
            this.labelBuildingPacket.TabIndex = 23;
            this.labelBuildingPacket.Text = "Building Your Packet Mom . .";
            this.labelBuildingPacket.Visible = false;
            // 
            // FormExcelSheets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(270, 313);
            this.Controls.Add(this.labelBuildingPacket);
            this.Controls.Add(this.progressBarCreatePacket);
            this.Controls.Add(this.buttonMasterSeason);
            this.Controls.Add(this.buttonCreatePacket);
            this.Controls.Add(this.buttonStandings);
            this.Controls.Add(this.buttonMasterSheet);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormExcelSheets";
            this.Text = "Select Export Option";
            this.Load += new System.EventHandler(this.FormExcelSheets_Load);
            ((System.ComponentModel.ISupportInitialize)(this.seasonsDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seasons1_5BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seasons11_17BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seasons6_10BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonMasterSheet;
        private System.Windows.Forms.Button buttonStandings;
        private System.Windows.Forms.Button buttonCreatePacket;
        private System.Windows.Forms.Button buttonMasterSeason;
        private SeasonsDBDataSet seasonsDBDataSet;
        private System.Windows.Forms.BindingSource seasons1_5BindingSource;
        private SeasonsDBDataSetTableAdapters.Seasons1_5TableAdapter seasons1_5TableAdapter;
        private SeasonsDBDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private SeasonsDBDataSetTableAdapters.Seasons11_17TableAdapter seasons11_17TableAdapter;
        private System.Windows.Forms.BindingSource seasons11_17BindingSource;
        private SeasonsDBDataSetTableAdapters.Seasons6_10TableAdapter seasons6_10TableAdapter;
        private System.Windows.Forms.BindingSource seasons6_10BindingSource;
        private System.Windows.Forms.ProgressBar progressBarCreatePacket;
        private System.Windows.Forms.Label labelBuildingPacket;
    }
}