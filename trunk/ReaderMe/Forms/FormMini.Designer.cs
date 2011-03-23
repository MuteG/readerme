namespace GP.Tools.ReaderMe.Forms
{
    partial class FormMini
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuItemReturn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemTop = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemShowInTask = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemBookMark = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.lblRightSize = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemReturn,
            this.mnuItemTop,
            this.mnuItemShowInTask,
            this.mnuItemBookMark});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(135, 92);
            // 
            // mnuItemReturn
            // 
            this.mnuItemReturn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuItemReturn.Name = "mnuItemReturn";
            this.mnuItemReturn.Size = new System.Drawing.Size(134, 22);
            this.mnuItemReturn.Text = "返回";
            this.mnuItemReturn.Click += new System.EventHandler(this.mnuItemReturn_Click);
            // 
            // mnuItemTop
            // 
            this.mnuItemTop.CheckOnClick = true;
            this.mnuItemTop.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuItemTop.Name = "mnuItemTop";
            this.mnuItemTop.Size = new System.Drawing.Size(134, 22);
            this.mnuItemTop.Text = "总在最上";
            this.mnuItemTop.Click += new System.EventHandler(this.mnuItemTop_Click);
            // 
            // mnuItemShowInTask
            // 
            this.mnuItemShowInTask.CheckOnClick = true;
            this.mnuItemShowInTask.Name = "mnuItemShowInTask";
            this.mnuItemShowInTask.Size = new System.Drawing.Size(134, 22);
            this.mnuItemShowInTask.Text = "显示状态栏";
            this.mnuItemShowInTask.Visible = false;
            this.mnuItemShowInTask.CheckedChanged += new System.EventHandler(this.mnuItemShowInTask_CheckedChanged);
            this.mnuItemShowInTask.Click += new System.EventHandler(this.mnuItemShowInTask_Click);
            // 
            // mnuItemBookMark
            // 
            this.mnuItemBookMark.Name = "mnuItemBookMark";
            this.mnuItemBookMark.Size = new System.Drawing.Size(134, 22);
            this.mnuItemBookMark.Text = "做书签";
            this.mnuItemBookMark.Click += new System.EventHandler(this.mnuItemBookMark_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(144, 12);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            this.richTextBox1.SelectionChanged += new System.EventHandler(this.richTextBox1_SelectionChanged);
            this.richTextBox1.SizeChanged += new System.EventHandler(this.richTextBox1_SizeChanged);
            // 
            // lblRightSize
            // 
            this.lblRightSize.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblRightSize.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.lblRightSize.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblRightSize.Location = new System.Drawing.Point(148, 0);
            this.lblRightSize.MinimumSize = new System.Drawing.Size(2, 0);
            this.lblRightSize.Name = "lblRightSize";
            this.lblRightSize.Size = new System.Drawing.Size(2, 12);
            this.lblRightSize.TabIndex = 3;
            this.lblRightSize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            // 
            // lblText
            // 
            this.lblText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblText.Location = new System.Drawing.Point(0, 0);
            this.lblText.MinimumSize = new System.Drawing.Size(148, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(148, 12);
            this.lblText.TabIndex = 4;
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMini_MouseDown);
            // 
            // FormMini
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(150, 12);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.lblRightSize);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.richTextBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(150, 12);
            this.Name = "FormMini";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormMini";
            this.Load += new System.EventHandler(this.FormMini_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMini_MouseDown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMini_KeyDown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuItemReturn;
        private System.Windows.Forms.ToolStripMenuItem mnuItemTop;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripMenuItem mnuItemShowInTask;
        private System.Windows.Forms.ToolStripMenuItem mnuItemBookMark;
        private System.Windows.Forms.Label lblRightSize;
        private System.Windows.Forms.Label lblText;

    }
}