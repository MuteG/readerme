namespace ReaderMe.Forms
{
    partial class FormConfig
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
            this.numOpacity = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblAutoScrollInterval = new System.Windows.Forms.Label();
            this.tbxAutoScrollInterval = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.lblBackColor = new System.Windows.Forms.Label();
            this.pbxBackColor = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBackColor)).BeginInit();
            this.SuspendLayout();
            // 
            // numOpacity
            // 
            this.numOpacity.Location = new System.Drawing.Point(70, 12);
            this.numOpacity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numOpacity.Name = "numOpacity";
            this.numOpacity.Size = new System.Drawing.Size(58, 22);
            this.numOpacity.TabIndex = 0;
            this.numOpacity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numOpacity_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "透明度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "%";
            // 
            // btnEnter
            // 
            this.btnEnter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEnter.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnter.Location = new System.Drawing.Point(13, 115);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(60, 21);
            this.btnEnter.TabIndex = 3;
            this.btnEnter.Text = "确定";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(91, 115);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(60, 21);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "取消";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblAutoScrollInterval
            // 
            this.lblAutoScrollInterval.AutoSize = true;
            this.lblAutoScrollInterval.Location = new System.Drawing.Point(12, 48);
            this.lblAutoScrollInterval.Name = "lblAutoScrollInterval";
            this.lblAutoScrollInterval.Size = new System.Drawing.Size(79, 14);
            this.lblAutoScrollInterval.TabIndex = 5;
            this.lblAutoScrollInterval.Text = "自动滚动间隔";
            // 
            // tbxAutoScrollInterval
            // 
            this.tbxAutoScrollInterval.Location = new System.Drawing.Point(97, 46);
            this.tbxAutoScrollInterval.MaxLength = 2;
            this.tbxAutoScrollInterval.Name = "tbxAutoScrollInterval";
            this.tbxAutoScrollInterval.Size = new System.Drawing.Size(31, 22);
            this.tbxAutoScrollInterval.TabIndex = 1;
            this.tbxAutoScrollInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "秒";
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            // 
            // lblBackColor
            // 
            this.lblBackColor.AutoSize = true;
            this.lblBackColor.Location = new System.Drawing.Point(12, 81);
            this.lblBackColor.Name = "lblBackColor";
            this.lblBackColor.Size = new System.Drawing.Size(91, 14);
            this.lblBackColor.TabIndex = 8;
            this.lblBackColor.Text = "阅读窗口背景色";
            // 
            // pbxBackColor
            // 
            this.pbxBackColor.Location = new System.Drawing.Point(109, 74);
            this.pbxBackColor.Name = "pbxBackColor";
            this.pbxBackColor.Size = new System.Drawing.Size(42, 30);
            this.pbxBackColor.TabIndex = 9;
            this.pbxBackColor.TabStop = false;
            this.pbxBackColor.Click += new System.EventHandler(this.pbxBackColor_Click);
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(164, 147);
            this.Controls.Add(this.pbxBackColor);
            this.Controls.Add(this.lblBackColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxAutoScrollInterval);
            this.Controls.Add(this.lblAutoScrollInterval);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numOpacity);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置";
            this.Load += new System.EventHandler(this.FormConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBackColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numOpacity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblAutoScrollInterval;
        private System.Windows.Forms.TextBox tbxAutoScrollInterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label lblBackColor;
        private System.Windows.Forms.PictureBox pbxBackColor;
    }
}