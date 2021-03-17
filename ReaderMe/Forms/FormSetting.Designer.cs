namespace ReaderMe.Forms
{
    partial class FormSetting
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
            this.lblNormalScrollInterval = new System.Windows.Forms.Label();
            this.tbxNormalScrollInterval = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.lblBackColor = new System.Windows.Forms.Label();
            this.pbxBackColor = new System.Windows.Forms.PictureBox();
            this.gbxNormalScroll = new System.Windows.Forms.GroupBox();
            this.lblNormalScrollRows = new System.Windows.Forms.Label();
            this.tbxNormalScrollRows = new System.Windows.Forms.TextBox();
            this.gbxMiniScroll = new System.Windows.Forms.GroupBox();
            this.lblMiniScrollRows = new System.Windows.Forms.Label();
            this.tbxMiniScrollRows = new System.Windows.Forms.TextBox();
            this.lblMiniScrollInterval = new System.Windows.Forms.Label();
            this.tbxMiniScrollInterval = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpgDisplay = new System.Windows.Forms.TabPage();
            this.tpgAutoScroll = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.numOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBackColor)).BeginInit();
            this.gbxNormalScroll.SuspendLayout();
            this.gbxMiniScroll.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpgDisplay.SuspendLayout();
            this.tpgAutoScroll.SuspendLayout();
            this.SuspendLayout();
            // 
            // numOpacity
            // 
            this.numOpacity.Location = new System.Drawing.Point(55, 7);
            this.numOpacity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numOpacity.Name = "numOpacity";
            this.numOpacity.Size = new System.Drawing.Size(42, 22);
            this.numOpacity.TabIndex = 0;
            this.numOpacity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numOpacity_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "透明度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "%";
            // 
            // btnEnter
            // 
            this.btnEnter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEnter.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnter.Location = new System.Drawing.Point(34, 225);
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
            this.btnClose.Location = new System.Drawing.Point(103, 225);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(60, 21);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "取消";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblNormalScrollInterval
            // 
            this.lblNormalScrollInterval.AutoSize = true;
            this.lblNormalScrollInterval.Location = new System.Drawing.Point(6, 24);
            this.lblNormalScrollInterval.Name = "lblNormalScrollInterval";
            this.lblNormalScrollInterval.Size = new System.Drawing.Size(115, 14);
            this.lblNormalScrollInterval.TabIndex = 5;
            this.lblNormalScrollInterval.Text = "自动滚动间隔（秒）";
            // 
            // tbxNormalScrollInterval
            // 
            this.tbxNormalScrollInterval.Location = new System.Drawing.Point(127, 21);
            this.tbxNormalScrollInterval.MaxLength = 2;
            this.tbxNormalScrollInterval.Name = "tbxNormalScrollInterval";
            this.tbxNormalScrollInterval.Size = new System.Drawing.Size(36, 22);
            this.tbxNormalScrollInterval.TabIndex = 1;
            this.tbxNormalScrollInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            // 
            // lblBackColor
            // 
            this.lblBackColor.AutoSize = true;
            this.lblBackColor.Location = new System.Drawing.Point(6, 44);
            this.lblBackColor.Name = "lblBackColor";
            this.lblBackColor.Size = new System.Drawing.Size(91, 14);
            this.lblBackColor.TabIndex = 8;
            this.lblBackColor.Text = "阅读窗口背景色";
            // 
            // pbxBackColor
            // 
            this.pbxBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxBackColor.Location = new System.Drawing.Point(103, 36);
            this.pbxBackColor.Name = "pbxBackColor";
            this.pbxBackColor.Size = new System.Drawing.Size(42, 30);
            this.pbxBackColor.TabIndex = 9;
            this.pbxBackColor.TabStop = false;
            this.pbxBackColor.Click += new System.EventHandler(this.pbxBackColor_Click);
            // 
            // gbxNormalScroll
            // 
            this.gbxNormalScroll.Controls.Add(this.lblNormalScrollRows);
            this.gbxNormalScroll.Controls.Add(this.tbxNormalScrollRows);
            this.gbxNormalScroll.Controls.Add(this.lblNormalScrollInterval);
            this.gbxNormalScroll.Controls.Add(this.tbxNormalScrollInterval);
            this.gbxNormalScroll.Location = new System.Drawing.Point(6, 6);
            this.gbxNormalScroll.Name = "gbxNormalScroll";
            this.gbxNormalScroll.Size = new System.Drawing.Size(173, 85);
            this.gbxNormalScroll.TabIndex = 11;
            this.gbxNormalScroll.TabStop = false;
            this.gbxNormalScroll.Text = "通常状态";
            // 
            // lblNormalScrollRows
            // 
            this.lblNormalScrollRows.AutoSize = true;
            this.lblNormalScrollRows.Location = new System.Drawing.Point(6, 52);
            this.lblNormalScrollRows.Name = "lblNormalScrollRows";
            this.lblNormalScrollRows.Size = new System.Drawing.Size(115, 14);
            this.lblNormalScrollRows.TabIndex = 8;
            this.lblNormalScrollRows.Text = "自动滚动距离（行）";
            // 
            // tbxNormalScrollRows
            // 
            this.tbxNormalScrollRows.Location = new System.Drawing.Point(127, 49);
            this.tbxNormalScrollRows.MaxLength = 2;
            this.tbxNormalScrollRows.Name = "tbxNormalScrollRows";
            this.tbxNormalScrollRows.Size = new System.Drawing.Size(36, 22);
            this.tbxNormalScrollRows.TabIndex = 7;
            this.tbxNormalScrollRows.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // gbxMiniScroll
            // 
            this.gbxMiniScroll.Controls.Add(this.lblMiniScrollRows);
            this.gbxMiniScroll.Controls.Add(this.tbxMiniScrollRows);
            this.gbxMiniScroll.Controls.Add(this.lblMiniScrollInterval);
            this.gbxMiniScroll.Controls.Add(this.tbxMiniScrollInterval);
            this.gbxMiniScroll.Location = new System.Drawing.Point(6, 97);
            this.gbxMiniScroll.Name = "gbxMiniScroll";
            this.gbxMiniScroll.Size = new System.Drawing.Size(173, 84);
            this.gbxMiniScroll.TabIndex = 12;
            this.gbxMiniScroll.TabStop = false;
            this.gbxMiniScroll.Text = "迷你状态";
            // 
            // lblMiniScrollRows
            // 
            this.lblMiniScrollRows.AutoSize = true;
            this.lblMiniScrollRows.Location = new System.Drawing.Point(6, 52);
            this.lblMiniScrollRows.Name = "lblMiniScrollRows";
            this.lblMiniScrollRows.Size = new System.Drawing.Size(115, 14);
            this.lblMiniScrollRows.TabIndex = 12;
            this.lblMiniScrollRows.Text = "自动滚动距离（行）";
            // 
            // tbxMiniScrollRows
            // 
            this.tbxMiniScrollRows.Enabled = false;
            this.tbxMiniScrollRows.Location = new System.Drawing.Point(127, 49);
            this.tbxMiniScrollRows.MaxLength = 2;
            this.tbxMiniScrollRows.Name = "tbxMiniScrollRows";
            this.tbxMiniScrollRows.Size = new System.Drawing.Size(36, 22);
            this.tbxMiniScrollRows.TabIndex = 11;
            this.tbxMiniScrollRows.Text = "1";
            this.tbxMiniScrollRows.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // lblMiniScrollInterval
            // 
            this.lblMiniScrollInterval.AutoSize = true;
            this.lblMiniScrollInterval.Location = new System.Drawing.Point(6, 24);
            this.lblMiniScrollInterval.Name = "lblMiniScrollInterval";
            this.lblMiniScrollInterval.Size = new System.Drawing.Size(115, 14);
            this.lblMiniScrollInterval.TabIndex = 10;
            this.lblMiniScrollInterval.Text = "自动滚动间隔（秒）";
            // 
            // tbxMiniScrollInterval
            // 
            this.tbxMiniScrollInterval.Location = new System.Drawing.Point(127, 21);
            this.tbxMiniScrollInterval.MaxLength = 2;
            this.tbxMiniScrollInterval.Name = "tbxMiniScrollInterval";
            this.tbxMiniScrollInterval.Size = new System.Drawing.Size(36, 22);
            this.tbxMiniScrollInterval.TabIndex = 9;
            this.tbxMiniScrollInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tpgDisplay);
            this.tabControl1.Controls.Add(this.tpgAutoScroll);
            this.tabControl1.Location = new System.Drawing.Point(2, 3);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(194, 216);
            this.tabControl1.TabIndex = 11;
            // 
            // tpgDisplay
            // 
            this.tpgDisplay.Controls.Add(this.label1);
            this.tpgDisplay.Controls.Add(this.pbxBackColor);
            this.tpgDisplay.Controls.Add(this.numOpacity);
            this.tpgDisplay.Controls.Add(this.lblBackColor);
            this.tpgDisplay.Controls.Add(this.label2);
            this.tpgDisplay.Location = new System.Drawing.Point(4, 23);
            this.tpgDisplay.Name = "tpgDisplay";
            this.tpgDisplay.Padding = new System.Windows.Forms.Padding(3);
            this.tpgDisplay.Size = new System.Drawing.Size(186, 189);
            this.tpgDisplay.TabIndex = 0;
            this.tpgDisplay.Text = "显示";
            this.tpgDisplay.UseVisualStyleBackColor = true;
            // 
            // tpgAutoScroll
            // 
            this.tpgAutoScroll.Controls.Add(this.gbxMiniScroll);
            this.tpgAutoScroll.Controls.Add(this.gbxNormalScroll);
            this.tpgAutoScroll.Location = new System.Drawing.Point(4, 23);
            this.tpgAutoScroll.Name = "tpgAutoScroll";
            this.tpgAutoScroll.Padding = new System.Windows.Forms.Padding(3);
            this.tpgAutoScroll.Size = new System.Drawing.Size(186, 189);
            this.tpgAutoScroll.TabIndex = 1;
            this.tpgAutoScroll.Text = "自动翻页";
            this.tpgAutoScroll.UseVisualStyleBackColor = true;
            // 
            // FormSetting
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(197, 258);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEnter);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置";
            this.Load += new System.EventHandler(this.FormConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBackColor)).EndInit();
            this.gbxNormalScroll.ResumeLayout(false);
            this.gbxNormalScroll.PerformLayout();
            this.gbxMiniScroll.ResumeLayout(false);
            this.gbxMiniScroll.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpgDisplay.ResumeLayout(false);
            this.tpgDisplay.PerformLayout();
            this.tpgAutoScroll.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numOpacity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblNormalScrollInterval;
        private System.Windows.Forms.TextBox tbxNormalScrollInterval;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label lblBackColor;
        private System.Windows.Forms.PictureBox pbxBackColor;
        private System.Windows.Forms.GroupBox gbxNormalScroll;
        private System.Windows.Forms.GroupBox gbxMiniScroll;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpgDisplay;
        private System.Windows.Forms.TabPage tpgAutoScroll;
        private System.Windows.Forms.Label lblNormalScrollRows;
        private System.Windows.Forms.TextBox tbxNormalScrollRows;
        private System.Windows.Forms.Label lblMiniScrollRows;
        private System.Windows.Forms.TextBox tbxMiniScrollRows;
        private System.Windows.Forms.Label lblMiniScrollInterval;
        private System.Windows.Forms.TextBox tbxMiniScrollInterval;
    }
}