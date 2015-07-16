namespace GPStudio.Tools.ReaderMe.Forms
{
    partial class FormFind
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbxFindWord = new System.Windows.Forms.TextBox();
            this.btnFindNext = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbxFindDirection = new System.Windows.Forms.GroupBox();
            this.rbtnDown = new System.Windows.Forms.RadioButton();
            this.rbtnUp = new System.Windows.Forms.RadioButton();
            this.cbxCase = new System.Windows.Forms.CheckBox();
            this.cbxWholeWord = new System.Windows.Forms.CheckBox();
            this.btnFindAll = new System.Windows.Forms.Button();
            this.btnFindCount = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.gbxFindDirection.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "查找目标";
            // 
            // tbxFindWord
            // 
            this.tbxFindWord.Location = new System.Drawing.Point(74, 9);
            this.tbxFindWord.Name = "tbxFindWord";
            this.tbxFindWord.Size = new System.Drawing.Size(285, 22);
            this.tbxFindWord.TabIndex = 1;
            // 
            // btnFindNext
            // 
            this.btnFindNext.Location = new System.Drawing.Point(375, 9);
            this.btnFindNext.Name = "btnFindNext";
            this.btnFindNext.Size = new System.Drawing.Size(75, 23);
            this.btnFindNext.TabIndex = 2;
            this.btnFindNext.Text = "查找下一个";
            this.btnFindNext.UseVisualStyleBackColor = true;
            this.btnFindNext.Click += new System.EventHandler(this.btnFindNext_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(375, 75);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbxFindDirection
            // 
            this.gbxFindDirection.Controls.Add(this.rbtnDown);
            this.gbxFindDirection.Controls.Add(this.rbtnUp);
            this.gbxFindDirection.Location = new System.Drawing.Point(117, 40);
            this.gbxFindDirection.Name = "gbxFindDirection";
            this.gbxFindDirection.Size = new System.Drawing.Size(174, 58);
            this.gbxFindDirection.TabIndex = 5;
            this.gbxFindDirection.TabStop = false;
            this.gbxFindDirection.Text = "查找方向";
            // 
            // rbtnDown
            // 
            this.rbtnDown.AutoSize = true;
            this.rbtnDown.Checked = true;
            this.rbtnDown.Location = new System.Drawing.Point(109, 23);
            this.rbtnDown.Name = "rbtnDown";
            this.rbtnDown.Size = new System.Drawing.Size(49, 18);
            this.rbtnDown.TabIndex = 1;
            this.rbtnDown.TabStop = true;
            this.rbtnDown.Text = "向下";
            this.rbtnDown.UseVisualStyleBackColor = true;
            // 
            // rbtnUp
            // 
            this.rbtnUp.AutoSize = true;
            this.rbtnUp.Location = new System.Drawing.Point(19, 23);
            this.rbtnUp.Name = "rbtnUp";
            this.rbtnUp.Size = new System.Drawing.Size(49, 18);
            this.rbtnUp.TabIndex = 0;
            this.rbtnUp.Text = "向上";
            this.rbtnUp.UseVisualStyleBackColor = true;
            // 
            // cbxCase
            // 
            this.cbxCase.AutoSize = true;
            this.cbxCase.Location = new System.Drawing.Point(13, 41);
            this.cbxCase.Name = "cbxCase";
            this.cbxCase.Size = new System.Drawing.Size(86, 18);
            this.cbxCase.TabIndex = 6;
            this.cbxCase.Text = "区分大小写";
            this.cbxCase.UseVisualStyleBackColor = true;
            // 
            // cbxWholeWord
            // 
            this.cbxWholeWord.AutoSize = true;
            this.cbxWholeWord.Location = new System.Drawing.Point(13, 65);
            this.cbxWholeWord.Name = "cbxWholeWord";
            this.cbxWholeWord.Size = new System.Drawing.Size(79, 18);
            this.cbxWholeWord.TabIndex = 7;
            this.cbxWholeWord.Text = "完整词/句";
            this.cbxWholeWord.UseVisualStyleBackColor = true;
            // 
            // btnFindAll
            // 
            this.btnFindAll.Location = new System.Drawing.Point(374, 46);
            this.btnFindAll.Name = "btnFindAll";
            this.btnFindAll.Size = new System.Drawing.Size(75, 23);
            this.btnFindAll.TabIndex = 8;
            this.btnFindAll.Text = "查找全部";
            this.btnFindAll.UseVisualStyleBackColor = true;
            this.btnFindAll.Click += new System.EventHandler(this.btnFindAll_Click);
            // 
            // btnFindCount
            // 
            this.btnFindCount.Location = new System.Drawing.Point(294, 46);
            this.btnFindCount.Name = "btnFindCount";
            this.btnFindCount.Size = new System.Drawing.Size(75, 23);
            this.btnFindCount.TabIndex = 9;
            this.btnFindCount.Text = "统计个数";
            this.btnFindCount.UseVisualStyleBackColor = true;
            this.btnFindCount.Click += new System.EventHandler(this.btnFindCount_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(294, 75);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // FormFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 107);
            this.Controls.Add(this.btnFindCount);
            this.Controls.Add(this.btnFindAll);
            this.Controls.Add(this.cbxWholeWord);
            this.Controls.Add(this.cbxCase);
            this.Controls.Add(this.gbxFindDirection);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnFindNext);
            this.Controls.Add(this.tbxFindWord);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFind";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查找";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormFind_Load);
            this.gbxFindDirection.ResumeLayout(false);
            this.gbxFindDirection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxFindWord;
        private System.Windows.Forms.Button btnFindNext;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gbxFindDirection;
        private System.Windows.Forms.RadioButton rbtnDown;
        private System.Windows.Forms.RadioButton rbtnUp;
        private System.Windows.Forms.CheckBox cbxCase;
        private System.Windows.Forms.CheckBox cbxWholeWord;
        private System.Windows.Forms.Button btnFindAll;
        private System.Windows.Forms.Button btnFindCount;
        private System.Windows.Forms.Button btnClear;
    }
}