namespace ReaderMe.Forms
{
    partial class FormOpenHistory
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
            this.lsvOpenHistory = new System.Windows.Forms.ListView();
            this.colHeaderCheckBox = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderFileStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuItemOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemFileRename = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemSelectAllNotExistFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cbxCheckAll = new System.Windows.Forms.CheckBox();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvOpenHistory
            // 
            this.lsvOpenHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvOpenHistory.CheckBoxes = true;
            this.lsvOpenHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeaderCheckBox,
            this.colHeaderFileName,
            this.colHeaderFileStatus});
            this.lsvOpenHistory.ContextMenuStrip = this.contextMenuStrip1;
            this.lsvOpenHistory.FullRowSelect = true;
            this.lsvOpenHistory.GridLines = true;
            this.lsvOpenHistory.Location = new System.Drawing.Point(0, 0);
            this.lsvOpenHistory.MultiSelect = false;
            this.lsvOpenHistory.Name = "lsvOpenHistory";
            this.lsvOpenHistory.ShowItemToolTips = true;
            this.lsvOpenHistory.Size = new System.Drawing.Size(271, 240);
            this.lsvOpenHistory.TabIndex = 0;
            this.lsvOpenHistory.UseCompatibleStateImageBehavior = false;
            this.lsvOpenHistory.View = System.Windows.Forms.View.Details;
            // 
            // colHeaderCheckBox
            // 
            this.colHeaderCheckBox.Text = "";
            this.colHeaderCheckBox.Width = 20;
            // 
            // colHeaderFileName
            // 
            this.colHeaderFileName.Text = "文件名";
            this.colHeaderFileName.Width = 140;
            // 
            // colHeaderFileStatus
            // 
            this.colHeaderFileStatus.Text = "文件状态";
            this.colHeaderFileStatus.Width = 67;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemOpenFolder,
            this.mnuItemFileRename,
            this.toolStripMenuItem1,
            this.mnuItemSelectAllNotExistFile});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(191, 76);
            // 
            // mnuItemOpenFolder
            // 
            this.mnuItemOpenFolder.Name = "mnuItemOpenFolder";
            this.mnuItemOpenFolder.Size = new System.Drawing.Size(190, 22);
            this.mnuItemOpenFolder.Text = "打开文件所在文件夹";
            this.mnuItemOpenFolder.Click += new System.EventHandler(this.mnuItemOpenFolder_Click);
            // 
            // mnuItemFileRename
            // 
            this.mnuItemFileRename.Name = "mnuItemFileRename";
            this.mnuItemFileRename.Size = new System.Drawing.Size(190, 22);
            this.mnuItemFileRename.Text = "文件重命名";
            this.mnuItemFileRename.Click += new System.EventHandler(this.mnuItemFileRename_Click);
            // 
            // mnuItemSelectAllNotExistFile
            // 
            this.mnuItemSelectAllNotExistFile.Name = "mnuItemSelectAllNotExistFile";
            this.mnuItemSelectAllNotExistFile.Size = new System.Drawing.Size(190, 22);
            this.mnuItemSelectAllNotExistFile.Text = "选中所有不存在的文件";
            this.mnuItemSelectAllNotExistFile.Click += new System.EventHandler(this.mnuItemSelectAllNotExistFile_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(116, 246);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(72, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(194, 246);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbxCheckAll
            // 
            this.cbxCheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbxCheckAll.AutoSize = true;
            this.cbxCheckAll.Location = new System.Drawing.Point(6, 249);
            this.cbxCheckAll.Name = "cbxCheckAll";
            this.cbxCheckAll.Size = new System.Drawing.Size(50, 18);
            this.cbxCheckAll.TabIndex = 5;
            this.cbxCheckAll.Text = "全选";
            this.cbxCheckAll.UseVisualStyleBackColor = true;
            this.cbxCheckAll.CheckedChanged += new System.EventHandler(this.cbxCheckAll_CheckedChanged);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(187, 6);
            // 
            // FormOpenHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 273);
            this.Controls.Add(this.cbxCheckAll);
            this.Controls.Add(this.lsvOpenHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(280, 150);
            this.Name = "FormOpenHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "管理打开历史";
            this.Load += new System.EventHandler(this.FormConfigOpenHistory_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lsvOpenHistory;
        private System.Windows.Forms.ColumnHeader colHeaderCheckBox;
        private System.Windows.Forms.ColumnHeader colHeaderFileName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader colHeaderFileStatus;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuItemOpenFolder;
        private System.Windows.Forms.ToolStripMenuItem mnuItemFileRename;
        private System.Windows.Forms.ToolStripMenuItem mnuItemSelectAllNotExistFile;
        private System.Windows.Forms.CheckBox cbxCheckAll;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    }
}