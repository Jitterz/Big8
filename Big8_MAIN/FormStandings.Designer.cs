namespace Big8_MAIN
{
    partial class FormStandings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStandings));
            this.buttonExportStandings = new System.Windows.Forms.Button();
            this.playersDBDataSet = new Big8_MAIN.PlayersDBDataSet();
            this.playersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.playersTableAdapter = new Big8_MAIN.PlayersDBDataSetTableAdapters.PlayersTableAdapter();
            this.tableAdapterManager = new Big8_MAIN.PlayersDBDataSetTableAdapters.TableAdapterManager();
            this.playersDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.playersDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonExportStandings
            // 
            this.buttonExportStandings.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonExportStandings.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonExportStandings.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold);
            this.buttonExportStandings.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonExportStandings.Location = new System.Drawing.Point(19, 231);
            this.buttonExportStandings.Name = "buttonExportStandings";
            this.buttonExportStandings.Size = new System.Drawing.Size(211, 29);
            this.buttonExportStandings.TabIndex = 50;
            this.buttonExportStandings.Text = "Export Player Standings";
            this.buttonExportStandings.UseVisualStyleBackColor = false;
            this.buttonExportStandings.Click += new System.EventHandler(this.buttonExportStandings_Click);
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
            // playersDataGridView
            // 
            this.playersDataGridView.AutoGenerateColumns = false;
            this.playersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.playersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn1});
            this.playersDataGridView.DataSource = this.playersBindingSource;
            this.playersDataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.playersDataGridView.Location = new System.Drawing.Point(0, 0);
            this.playersDataGridView.Name = "playersDataGridView";
            this.playersDataGridView.Size = new System.Drawing.Size(242, 220);
            this.playersDataGridView.TabIndex = 51;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "PlayerTotalWins";
            this.dataGridViewTextBoxColumn3.HeaderText = "PlayerTotalWins";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PlayerPoolName";
            this.dataGridViewTextBoxColumn1.HeaderText = "PlayerPoolName";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // FormStandings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(242, 271);
            this.Controls.Add(this.playersDataGridView);
            this.Controls.Add(this.buttonExportStandings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormStandings";
            this.Text = "Player Standings";
            this.Load += new System.EventHandler(this.FormStandings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.playersDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonExportStandings;
        private PlayersDBDataSet playersDBDataSet;
        private System.Windows.Forms.BindingSource playersBindingSource;
        private PlayersDBDataSetTableAdapters.PlayersTableAdapter playersTableAdapter;
        private PlayersDBDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView playersDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}