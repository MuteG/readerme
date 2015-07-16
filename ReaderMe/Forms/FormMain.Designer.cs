namespace GPStudio.Tools.ReaderMe.Forms
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.rtbText = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuItemPopBookMark = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPopJumpToBookMark = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemPopMiniMode = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPopSimpleMode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemPopCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPopCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPopPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemTopMost = new System.Windows.Forms.ToolStripMenuItem();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslWordCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemOpenHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemCloseActiveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemFind = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemFont = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemEncoding = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemWordWrap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemReadOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemBookMark = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemJumpToBookMark = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemSmartClearSpaceLine = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemOperation = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemMini = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemSimpleMode = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemConfigOpenHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemIntroduction = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.myRichTextBox1 = new GPStudio.Tools.ReaderMe.module.MyRichTextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbText
            // 
            this.rtbText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbText.ContextMenuStrip = this.contextMenuStrip1;
            this.rtbText.DetectUrls = false;
            this.rtbText.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbText.ImeMode = System.Windows.Forms.ImeMode.On;
            this.rtbText.Location = new System.Drawing.Point(0, 24);
            this.rtbText.Margin = new System.Windows.Forms.Padding(0);
            this.rtbText.Name = "rtbText";
            this.rtbText.Size = new System.Drawing.Size(277, 200);
            this.rtbText.TabIndex = 5;
            this.rtbText.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemPopBookMark,
            this.mnuItemPopJumpToBookMark,
            this.toolStripMenuItem2,
            this.mnuItemPopMiniMode,
            this.mnuItemPopSimpleMode,
            this.toolStripMenuItem1,
            this.mnuItemPopCut,
            this.mnuItemPopCopy,
            this.mnuItemPopPaste,
            this.toolStripMenuItem5,
            this.menuItemTopMost});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 198);
            // 
            // mnuItemPopBookMark
            // 
            this.mnuItemPopBookMark.Name = "mnuItemPopBookMark";
            this.mnuItemPopBookMark.Size = new System.Drawing.Size(122, 22);
            this.mnuItemPopBookMark.Text = "做书签";
            this.mnuItemPopBookMark.Click += new System.EventHandler(this.mnuItemPopBookMark_Click);
            // 
            // mnuItemPopJumpToBookMark
            // 
            this.mnuItemPopJumpToBookMark.Name = "mnuItemPopJumpToBookMark";
            this.mnuItemPopJumpToBookMark.Size = new System.Drawing.Size(122, 22);
            this.mnuItemPopJumpToBookMark.Text = "移至书签";
            this.mnuItemPopJumpToBookMark.Click += new System.EventHandler(this.mnuItemPopJumpToBookMark_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(119, 6);
            // 
            // mnuItemPopMiniMode
            // 
            this.mnuItemPopMiniMode.Name = "mnuItemPopMiniMode";
            this.mnuItemPopMiniMode.Size = new System.Drawing.Size(122, 22);
            this.mnuItemPopMiniMode.Text = "迷你模式";
            this.mnuItemPopMiniMode.Click += new System.EventHandler(this.mnuItemMini_Click);
            // 
            // mnuItemPopSimpleMode
            // 
            this.mnuItemPopSimpleMode.CheckOnClick = true;
            this.mnuItemPopSimpleMode.Name = "mnuItemPopSimpleMode";
            this.mnuItemPopSimpleMode.Size = new System.Drawing.Size(122, 22);
            this.mnuItemPopSimpleMode.Text = "精简模式";
            this.mnuItemPopSimpleMode.Click += new System.EventHandler(this.mnuItemPopSimpleMode_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(119, 6);
            // 
            // mnuItemPopCut
            // 
            this.mnuItemPopCut.Name = "mnuItemPopCut";
            this.mnuItemPopCut.Size = new System.Drawing.Size(122, 22);
            this.mnuItemPopCut.Text = "剪切";
            this.mnuItemPopCut.Click += new System.EventHandler(this.mnuItemPopCut_Click);
            // 
            // mnuItemPopCopy
            // 
            this.mnuItemPopCopy.Name = "mnuItemPopCopy";
            this.mnuItemPopCopy.Size = new System.Drawing.Size(122, 22);
            this.mnuItemPopCopy.Text = "拷贝";
            this.mnuItemPopCopy.Click += new System.EventHandler(this.mnuItemPopCopy_Click);
            // 
            // mnuItemPopPaste
            // 
            this.mnuItemPopPaste.Name = "mnuItemPopPaste";
            this.mnuItemPopPaste.Size = new System.Drawing.Size(122, 22);
            this.mnuItemPopPaste.Text = "粘贴";
            this.mnuItemPopPaste.Click += new System.EventHandler(this.mnuItemPopPaste_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(119, 6);
            // 
            // menuItemTopMost
            // 
            this.menuItemTopMost.Name = "menuItemTopMost";
            this.menuItemTopMost.Size = new System.Drawing.Size(122, 22);
            this.menuItemTopMost.Text = "总在最上";
            this.menuItemTopMost.Click += new System.EventHandler(this.menuItemTopMost_Click);
            // 
            // fontDialog1
            // 
            this.fontDialog1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "txt|*.txt";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            this.saveFileDialog1.Filter = "文本文件|*.txt|所有文件|*.*";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel3,
            this.tsslWordCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 224);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(277, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(61, 17);
            this.toolStripStatusLabel3.Text = "文章字数：";
            // 
            // tsslWordCount
            // 
            this.tsslWordCount.Name = "tsslWordCount";
            this.tsslWordCount.Size = new System.Drawing.Size(14, 17);
            this.tsslWordCount.Text = "0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemFile,
            this.mnuItemEdit,
            this.mnuItemOperation,
            this.mnuItemAbout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(277, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuItemFile
            // 
            this.mnuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemOpen,
            this.mnuItemOpenHistory,
            this.mnuItemSave,
            this.mnuItemSaveAs,
            this.mnuItemCloseActiveFile,
            this.mnuItemExit});
            this.mnuItemFile.Name = "mnuItemFile";
            this.mnuItemFile.Size = new System.Drawing.Size(43, 20);
            this.mnuItemFile.Text = "文件";
            // 
            // mnuItemOpen
            // 
            this.mnuItemOpen.Name = "mnuItemOpen";
            this.mnuItemOpen.Size = new System.Drawing.Size(146, 22);
            this.mnuItemOpen.Text = "打开";
            this.mnuItemOpen.Click += new System.EventHandler(this.mnuItemOpen_Click);
            // 
            // mnuItemOpenHistory
            // 
            this.mnuItemOpenHistory.Name = "mnuItemOpenHistory";
            this.mnuItemOpenHistory.Size = new System.Drawing.Size(146, 22);
            this.mnuItemOpenHistory.Text = "打开历史";
            // 
            // mnuItemSave
            // 
            this.mnuItemSave.Name = "mnuItemSave";
            this.mnuItemSave.Size = new System.Drawing.Size(146, 22);
            this.mnuItemSave.Text = "保存";
            this.mnuItemSave.Click += new System.EventHandler(this.mnuItemSave_Click);
            // 
            // mnuItemSaveAs
            // 
            this.mnuItemSaveAs.Name = "mnuItemSaveAs";
            this.mnuItemSaveAs.Size = new System.Drawing.Size(146, 22);
            this.mnuItemSaveAs.Text = "另存为…";
            this.mnuItemSaveAs.Click += new System.EventHandler(this.mnuItemSaveAs_Click);
            // 
            // mnuItemCloseActiveFile
            // 
            this.mnuItemCloseActiveFile.Name = "mnuItemCloseActiveFile";
            this.mnuItemCloseActiveFile.Size = new System.Drawing.Size(146, 22);
            this.mnuItemCloseActiveFile.Text = "关闭当前文件";
            this.mnuItemCloseActiveFile.Click += new System.EventHandler(this.mnuItemCloseActiveFile_Click);
            // 
            // mnuItemExit
            // 
            this.mnuItemExit.Name = "mnuItemExit";
            this.mnuItemExit.Size = new System.Drawing.Size(146, 22);
            this.mnuItemExit.Text = "退出";
            this.mnuItemExit.Click += new System.EventHandler(this.mnuItemExit_Click);
            // 
            // mnuItemEdit
            // 
            this.mnuItemEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemCut,
            this.mnuItemCopy,
            this.mnuItemPaste,
            this.toolStripSeparator2,
            this.mnuItemFind,
            this.mnuItemFont,
            this.mnuItemEncoding,
            this.toolStripMenuItem4,
            this.mnuItemWordWrap,
            this.mnuItemReadOnly,
            this.toolStripSeparator1,
            this.mnuItemBookMark,
            this.mnuItemJumpToBookMark,
            this.toolStripMenuItem3,
            this.mnuItemSmartClearSpaceLine});
            this.mnuItemEdit.Name = "mnuItemEdit";
            this.mnuItemEdit.Size = new System.Drawing.Size(43, 20);
            this.mnuItemEdit.Text = "编辑";
            // 
            // mnuItemCut
            // 
            this.mnuItemCut.Name = "mnuItemCut";
            this.mnuItemCut.Size = new System.Drawing.Size(134, 22);
            this.mnuItemCut.Text = "剪切";
            this.mnuItemCut.Click += new System.EventHandler(this.mnuItemCut_Click);
            // 
            // mnuItemCopy
            // 
            this.mnuItemCopy.Name = "mnuItemCopy";
            this.mnuItemCopy.Size = new System.Drawing.Size(134, 22);
            this.mnuItemCopy.Text = "拷贝";
            this.mnuItemCopy.Click += new System.EventHandler(this.mnuItemCopy_Click);
            // 
            // mnuItemPaste
            // 
            this.mnuItemPaste.Name = "mnuItemPaste";
            this.mnuItemPaste.Size = new System.Drawing.Size(134, 22);
            this.mnuItemPaste.Text = "粘贴";
            this.mnuItemPaste.Click += new System.EventHandler(this.mnuItemPaste_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(131, 6);
            // 
            // mnuItemFind
            // 
            this.mnuItemFind.Name = "mnuItemFind";
            this.mnuItemFind.Size = new System.Drawing.Size(134, 22);
            this.mnuItemFind.Text = "查找";
            this.mnuItemFind.Click += new System.EventHandler(this.mnuItemFind_Click);
            // 
            // mnuItemFont
            // 
            this.mnuItemFont.Name = "mnuItemFont";
            this.mnuItemFont.Size = new System.Drawing.Size(134, 22);
            this.mnuItemFont.Text = "字体";
            this.mnuItemFont.Click += new System.EventHandler(this.mnuItemFont_Click);
            // 
            // mnuItemEncoding
            // 
            this.mnuItemEncoding.Name = "mnuItemEncoding";
            this.mnuItemEncoding.Size = new System.Drawing.Size(134, 22);
            this.mnuItemEncoding.Text = "编码";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(131, 6);
            // 
            // mnuItemWordWrap
            // 
            this.mnuItemWordWrap.CheckOnClick = true;
            this.mnuItemWordWrap.Name = "mnuItemWordWrap";
            this.mnuItemWordWrap.Size = new System.Drawing.Size(134, 22);
            this.mnuItemWordWrap.Text = "自动换行";
            this.mnuItemWordWrap.Click += new System.EventHandler(this.mnuItemWordWrap_Click);
            // 
            // mnuItemReadOnly
            // 
            this.mnuItemReadOnly.CheckOnClick = true;
            this.mnuItemReadOnly.Name = "mnuItemReadOnly";
            this.mnuItemReadOnly.Size = new System.Drawing.Size(134, 22);
            this.mnuItemReadOnly.Text = "只读模式";
            this.mnuItemReadOnly.Click += new System.EventHandler(this.mnuItemReadOnly_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(131, 6);
            // 
            // mnuItemBookMark
            // 
            this.mnuItemBookMark.Name = "mnuItemBookMark";
            this.mnuItemBookMark.Size = new System.Drawing.Size(134, 22);
            this.mnuItemBookMark.Text = "做书签";
            this.mnuItemBookMark.Click += new System.EventHandler(this.mnuItemBookMark_Click);
            // 
            // mnuItemJumpToBookMark
            // 
            this.mnuItemJumpToBookMark.Name = "mnuItemJumpToBookMark";
            this.mnuItemJumpToBookMark.Size = new System.Drawing.Size(134, 22);
            this.mnuItemJumpToBookMark.Text = "移至书签";
            this.mnuItemJumpToBookMark.Click += new System.EventHandler(this.mnuItemJumpToBookMark_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(131, 6);
            // 
            // mnuItemSmartClearSpaceLine
            // 
            this.mnuItemSmartClearSpaceLine.Name = "mnuItemSmartClearSpaceLine";
            this.mnuItemSmartClearSpaceLine.Size = new System.Drawing.Size(134, 22);
            this.mnuItemSmartClearSpaceLine.Text = "智能去空行";
            this.mnuItemSmartClearSpaceLine.Click += new System.EventHandler(this.mnuItemSmartClearSpaceLine_Click);
            // 
            // mnuItemOperation
            // 
            this.mnuItemOperation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemMini,
            this.mnuItemSimpleMode,
            this.mnuItemConfigOpenHistory,
            this.mnuItemConfig});
            this.mnuItemOperation.Name = "mnuItemOperation";
            this.mnuItemOperation.Size = new System.Drawing.Size(43, 20);
            this.mnuItemOperation.Text = "选项";
            // 
            // mnuItemMini
            // 
            this.mnuItemMini.Name = "mnuItemMini";
            this.mnuItemMini.Size = new System.Drawing.Size(146, 22);
            this.mnuItemMini.Text = "迷你模式";
            this.mnuItemMini.Click += new System.EventHandler(this.mnuItemMini_Click);
            // 
            // mnuItemSimpleMode
            // 
            this.mnuItemSimpleMode.Name = "mnuItemSimpleMode";
            this.mnuItemSimpleMode.Size = new System.Drawing.Size(146, 22);
            this.mnuItemSimpleMode.Text = "精简模式";
            this.mnuItemSimpleMode.Click += new System.EventHandler(this.mnuItemSimpleMode_Click);
            // 
            // mnuItemConfigOpenHistory
            // 
            this.mnuItemConfigOpenHistory.Name = "mnuItemConfigOpenHistory";
            this.mnuItemConfigOpenHistory.Size = new System.Drawing.Size(146, 22);
            this.mnuItemConfigOpenHistory.Text = "管理打开历史";
            this.mnuItemConfigOpenHistory.Click += new System.EventHandler(this.mnuItemConfigOpenHistory_Click);
            // 
            // mnuItemConfig
            // 
            this.mnuItemConfig.Name = "mnuItemConfig";
            this.mnuItemConfig.Size = new System.Drawing.Size(146, 22);
            this.mnuItemConfig.Text = "设置";
            this.mnuItemConfig.Click += new System.EventHandler(this.mnuItemConfig_Click);
            // 
            // mnuItemAbout
            // 
            this.mnuItemAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemIntroduction,
            this.mnuItemHelp,
            this.mnuItemInfo});
            this.mnuItemAbout.Name = "mnuItemAbout";
            this.mnuItemAbout.Size = new System.Drawing.Size(43, 20);
            this.mnuItemAbout.Text = "关于";
            // 
            // mnuItemIntroduction
            // 
            this.mnuItemIntroduction.Name = "mnuItemIntroduction";
            this.mnuItemIntroduction.Size = new System.Drawing.Size(98, 22);
            this.mnuItemIntroduction.Text = "简介";
            this.mnuItemIntroduction.Click += new System.EventHandler(this.mnuItemIntroduction_Click);
            // 
            // mnuItemHelp
            // 
            this.mnuItemHelp.Name = "mnuItemHelp";
            this.mnuItemHelp.Size = new System.Drawing.Size(98, 22);
            this.mnuItemHelp.Text = "帮助";
            this.mnuItemHelp.Click += new System.EventHandler(this.mnuItemHelp_Click_1);
            // 
            // mnuItemInfo
            // 
            this.mnuItemInfo.Name = "mnuItemInfo";
            this.mnuItemInfo.Size = new System.Drawing.Size(98, 22);
            this.mnuItemInfo.Text = "关于";
            this.mnuItemInfo.Click += new System.EventHandler(this.mnuItemInfo_Click);
            // 
            // myRichTextBox1
            // 
            this.myRichTextBox1.Location = new System.Drawing.Point(12, 27);
            this.myRichTextBox1.Name = "myRichTextBox1";
            this.myRichTextBox1.Size = new System.Drawing.Size(240, 186);
            this.myRichTextBox1.TabIndex = 10;
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 246);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.myRichTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.rtbText);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(192, 189);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ReaderMe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbText;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPopBookMark;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuItemFile;
        private System.Windows.Forms.ToolStripMenuItem mnuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuItemSave;
        private System.Windows.Forms.ToolStripMenuItem mnuItemSaveAs;
        private System.Windows.Forms.ToolStripMenuItem mnuItemExit;
        private System.Windows.Forms.ToolStripMenuItem mnuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuItemFont;
        private System.Windows.Forms.ToolStripMenuItem mnuItemOpenHistory;
        private System.Windows.Forms.ToolStripMenuItem mnuItemEncoding;
        private System.Windows.Forms.ToolStripMenuItem mnuItemOperation;
        private System.Windows.Forms.ToolStripMenuItem mnuItemConfig;
        private System.Windows.Forms.ToolStripMenuItem mnuItemWordWrap;
        private System.Windows.Forms.ToolStripMenuItem mnuItemConfigOpenHistory;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel tsslWordCount;
        private System.Windows.Forms.ToolStripMenuItem mnuItemCut;
        private System.Windows.Forms.ToolStripMenuItem mnuItemCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPaste;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPopCut;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPopCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPopPaste;
        private System.Windows.Forms.ToolStripMenuItem mnuItemFind;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPopJumpToBookMark;
        private System.Windows.Forms.ToolStripMenuItem mnuItemMini;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPopMiniMode;
        private System.Windows.Forms.ToolStripMenuItem mnuItemCloseActiveFile;
        private System.Windows.Forms.ToolStripMenuItem mnuItemBookMark;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuItemJumpToBookMark;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPopSimpleMode;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuItemSimpleMode;
        private System.Windows.Forms.ToolStripMenuItem mnuItemAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuItemInfo;
        private System.Windows.Forms.ToolStripMenuItem mnuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuItemIntroduction;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuItemSmartClearSpaceLine;
        private System.Windows.Forms.ToolStripMenuItem mnuItemReadOnly;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem menuItemTopMost;
        private module.MyRichTextBox myRichTextBox1;
    }
}

