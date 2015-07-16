namespace GPStudio.Tools.ReaderMe.Forms
{
    partial class FormReleaseHistory
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
            this.tbxIntroduction = new System.Windows.Forms.TextBox();
            this.tbxReleaseHistory = new System.Windows.Forms.TextBox();
            this.lblIntroduction = new System.Windows.Forms.Label();
            this.lblReleaseHistory = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbxIntroduction
            // 
            this.tbxIntroduction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxIntroduction.BackColor = System.Drawing.SystemColors.Control;
            this.tbxIntroduction.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxIntroduction.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbxIntroduction.Location = new System.Drawing.Point(12, 26);
            this.tbxIntroduction.Multiline = true;
            this.tbxIntroduction.Name = "tbxIntroduction";
            this.tbxIntroduction.ReadOnly = true;
            this.tbxIntroduction.Size = new System.Drawing.Size(391, 123);
            this.tbxIntroduction.TabIndex = 0;
            // 
            // tbxReleaseHistory
            // 
            this.tbxReleaseHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxReleaseHistory.BackColor = System.Drawing.Color.White;
            this.tbxReleaseHistory.Location = new System.Drawing.Point(12, 176);
            this.tbxReleaseHistory.Multiline = true;
            this.tbxReleaseHistory.Name = "tbxReleaseHistory";
            this.tbxReleaseHistory.ReadOnly = true;
            this.tbxReleaseHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxReleaseHistory.Size = new System.Drawing.Size(391, 136);
            this.tbxReleaseHistory.TabIndex = 1;
            // 
            // lblIntroduction
            // 
            this.lblIntroduction.AutoSize = true;
            this.lblIntroduction.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblIntroduction.Location = new System.Drawing.Point(12, 9);
            this.lblIntroduction.Name = "lblIntroduction";
            this.lblIntroduction.Size = new System.Drawing.Size(57, 12);
            this.lblIntroduction.TabIndex = 2;
            this.lblIntroduction.Text = "软件简介";
            // 
            // lblReleaseHistory
            // 
            this.lblReleaseHistory.AutoSize = true;
            this.lblReleaseHistory.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblReleaseHistory.Location = new System.Drawing.Point(12, 161);
            this.lblReleaseHistory.Name = "lblReleaseHistory";
            this.lblReleaseHistory.Size = new System.Drawing.Size(57, 12);
            this.lblReleaseHistory.TabIndex = 3;
            this.lblReleaseHistory.Text = "发布履历";
            // 
            // FormReleaseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 324);
            this.Controls.Add(this.lblReleaseHistory);
            this.Controls.Add(this.lblIntroduction);
            this.Controls.Add(this.tbxReleaseHistory);
            this.Controls.Add(this.tbxIntroduction);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormReleaseHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormReleaseHistory";
            this.Shown += new System.EventHandler(this.FormReleaseHistory_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxIntroduction;
        private System.Windows.Forms.TextBox tbxReleaseHistory;
        private System.Windows.Forms.Label lblIntroduction;
        private System.Windows.Forms.Label lblReleaseHistory;
    }
}