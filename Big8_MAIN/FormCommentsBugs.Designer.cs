namespace Big8_MAIN
{
    partial class FormCommentsBugs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCommentsBugs));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCommentsBugsBody = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSendJitterz = new System.Windows.Forms.Button();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Blue Highway", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(101, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Comments and Bugs";
            // 
            // textBoxCommentsBugsBody
            // 
            this.textBoxCommentsBugsBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxCommentsBugsBody.Location = new System.Drawing.Point(33, 159);
            this.textBoxCommentsBugsBody.MaxLength = 90000;
            this.textBoxCommentsBugsBody.Multiline = true;
            this.textBoxCommentsBugsBody.Name = "textBoxCommentsBugsBody";
            this.textBoxCommentsBugsBody.Size = new System.Drawing.Size(436, 222);
            this.textBoxCommentsBugsBody.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.buttonSendJitterz);
            this.panel1.Location = new System.Drawing.Point(-3, 394);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(507, 88);
            this.panel1.TabIndex = 2;
            // 
            // buttonSendJitterz
            // 
            this.buttonSendJitterz.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSendJitterz.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonSendJitterz.Font = new System.Drawing.Font("Blue Highway", 14.25F, System.Drawing.FontStyle.Bold);
            this.buttonSendJitterz.Location = new System.Drawing.Point(196, 5);
            this.buttonSendJitterz.Name = "buttonSendJitterz";
            this.buttonSendJitterz.Size = new System.Drawing.Size(120, 67);
            this.buttonSendJitterz.TabIndex = 16;
            this.buttonSendJitterz.Text = "Send to Jitterz";
            this.buttonSendJitterz.UseVisualStyleBackColor = false;
            this.buttonSendJitterz.Click += new System.EventHandler(this.buttonSendJitterz_Click);
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxTitle.Location = new System.Drawing.Point(33, 105);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(436, 26);
            this.textBoxTitle.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Title / Subject";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Blue Highway", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Message";
            // 
            // FormCommentsBugs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(498, 478);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBoxCommentsBugsBody);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCommentsBugs";
            this.Text = "Send Jitterz Comments and Bugs";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCommentsBugsBody;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonSendJitterz;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}