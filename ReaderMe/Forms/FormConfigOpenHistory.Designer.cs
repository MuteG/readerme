namespace ReaderMe.Forms
{
    partial class FormConfigOpenHistory
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
            this.colHeaderCheckBox = new System.Windows.Forms.ColumnHeader();
            this.colHeaderFileName = new System.Windows.Forms.ColumnHeader();
            this.colHeaderFileStatus = new System.Windows.Forms.ColumnHeader();
            this.colHeaderFullPath = new System.Windows.Forms.ColumnHeader();
            this.colHeaderMD5 = new System.Windows.Forms.ColumnHeader();
            this.colHeaderEncode = new System.Windows.Forms.ColumnHeader();
            this.colHeaderDatetime = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuItemOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemFileRename = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSelectNone = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.mnuItemSelectAllNotExistFile = new System.Windows.Forms.ToolStripMenuItem();
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
            this.colHeaderFileStatus,
            this.colHeaderFullPath,
            this.colHeaderMD5,
            this.colHeaderEncode,
            this.colHeaderDatetime});
            this.lsvOpenHistory.ContextMenuStrip = this.contextMenuStrip1;
            this.lsvOpenHistory.FullRowSelect = true;
            this.lsvOpenHistory.GridLines = true;
            this.lsvOpenHistory.Location = new System.Drawing.Point(0, 0);
            this.lsvOpenHistory.MultiSelect = false;
            this.lsvOpenHistory.Name = "lsvOpenHistory";
            this.lsvOpenHistory.Size = new System.Drawing.Size(956, 350);
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
            // 
            // colHeaderFullPath
            // 
            this.colHeaderFullPath.Text = "完整路径";
            this.colHeaderFullPath.Width = 250;
            // 
            // colHeaderMD5
            // 
            this.colHeaderMD5.Text = "MD5";
            this.colHeaderMD5.Width = 245;
            // 
            // colHeaderEncode
            // 
            this.colHeaderEncode.Text = "编码";
            this.colHeaderEncode.Width = 85;
            // 
            // colHeaderDatetime
            // 
            this.colHeaderDatetime.Text = "记录时间";
            this.colHeaderDatetime.Width = 135;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemOpenFolder,
            this.mnuItemFileRename,
            this.mnuItemSelectAllNotExistFile});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(195, 70);
            // 
            // mnuItemOpenFolder
            // 
            this.mnuItemOpenFolder.Name = "mnuItemOpenFolder";
            this.mnuItemOpenFolder.Size = new System.Drawing.Size(194, 22);
            this.mnuItemOpenFolder.Text = "打开文件所在文件夹";
            this.mnuItemOpenFolder.Click += new System.EventHandler(this.mnuItemOpenFolder_Click);
            // 
            // mnuItemFileRename
            // 
            this.mnuItemFileRename.Name = "mnuItemFileRename";
            this.mnuItemFileRename.Size = new System.Drawing.Size(194, 22);
            this.mnuItemFileRename.Text = "文件重命名";
            this.mnuItemFileRename.Click += new System.EventHandler(this.mnuItemFileRename_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(745, 357);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(112, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "删除选择的记录";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(863, 357);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSelectNone
            // 
            this.btnSelectNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectNone.Location = new System.Drawing.Point(78, 357);
            this.btnSelectNone.Name = "btnSelectNone";
            this.btnSelectNone.Size = new System.Drawing.Size(72, 23);
            this.btnSelectNone.TabIndex = 3;
            this.btnSelectNone.Text = "全不选";
            this.btnSelectNone.UseVisualStyleBackColor = true;
            this.btnSelectNone.Click += new System.EventHandler(this.btnSelectNone_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.Location = new System.Drawing.Point(0, 357);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(72, 23);
            this.btnSelectAll.TabIndex = 4;
            this.btnSelectAll.Text = "全选";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // mnuItemSelectAllNotExistFile
            // 
            this.mnuItemSelectAllNotExistFile.Name = "mnuItemSelectAllNotExistFile";
            this.mnuItemSelectAllNotExistFile.Size = new System.Drawing.Size(194, 22);
            this.mnuItemSelectAllNotExistFile.Text = "选中所有不存在的文件";
            this.mnuItemSelectAllNotExistFile.Click += new System.EventHandler(this.mnuItemSelectAllNotExistFile_Click);
            // 
            // FormConfigOpenHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 383);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnSelectNone);
            this.Controls.Add(this.lsvOpenHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(400, 150);
            this.Name = "FormConfigOpenHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "管理打开历史";
            this.Load += new System.EventHandler(this.FormConfigOpenHistory_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lsvOpenHistory;
        private System.Windows.Forms.ColumnHeader colHeaderCheckBox;
        private System.Windows.Forms.ColumnHeader colHeaderFileName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSelectNone;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.ColumnHeader colHeaderFileStatus;
        private System.Windows.Forms.ColumnHeader colHeaderFullPath;
        private System.Windows.Forms.ColumnHeader colHeaderMD5;
        private System.Windows.Forms.ColumnHeader colHeaderEncode;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuItemOpenFolder;
        private System.Windows.Forms.ToolStripMenuItem mnuItemFileRename;
        private System.Windows.Forms.ColumnHeader colHeaderDatetime;
        private System.Windows.Forms.ToolStripMenuItem mnuItemSelectAllNotExistFile;
    }
}