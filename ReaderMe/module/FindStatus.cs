using System.Windows.Forms;

namespace ReaderMe.Module
{
    public class FindStatus
    {
        private string _SelectedString;

        private bool _MatchCase;

        private bool _WholeWord;

        private RichTextBoxFinds _BoxFinds;

        private int _StartIndex;

        private bool _Reverse;

        private int _EndIndex;

        /// <summary>
        /// 获取或者设置结束索引
        /// </summary>
        public int EndIndex
        {
            get { return _EndIndex; }
            set { _EndIndex = value; }
        }

        /// <summary>
        /// 获取或者设置是否反向搜索
        /// </summary>
        public bool Reverse
        {
            get { return _Reverse; }
            set { _Reverse = value; }
        }

        /// <summary>
        /// 获取或者设置起始索引
        /// </summary>
        public int StartIndex
        {
            get { return _StartIndex; }
            set { _StartIndex = value; }
        }

        /// <summary>
        /// 获取或者设置如何在文本区域中搜索
        /// </summary>
        public RichTextBoxFinds BoxFinds
        {
            get { return _BoxFinds; }
            set { _BoxFinds = value; }
        }

        /// <summary>
        /// 获取或者设置是否全字匹配
        /// </summary>
        public bool WholeWord
        {
            get { return _WholeWord; }
            set { _WholeWord = value; }
        }

        /// <summary>
        /// 获取或者设置是否区分大小写
        /// </summary>
        public bool MatchCase
        {
            get { return _MatchCase; }
            set { _MatchCase = value; }
        }

        /// <summary>
        /// 获取或者设置要查找的字符串
        /// </summary>
        public string SelectedString
        {
            get { return _SelectedString; }
            set { _SelectedString = value; }
        }

        public FindStatus()
        {
            this._MatchCase = false;
            this._BoxFinds = RichTextBoxFinds.None;
            this._SelectedString = string.Empty;
            this._StartIndex = 0;
            this._EndIndex = 0;
            this._WholeWord = false;
            this._Reverse = false;
        }

        public FindStatus(FindStatus status)
        {
            this._MatchCase = status.MatchCase;
            this._BoxFinds = status.BoxFinds;
            this._SelectedString = status.SelectedString;
            this._StartIndex = status.StartIndex;
            this._EndIndex = status.EndIndex;
            this._WholeWord = status.WholeWord;
            this._Reverse = status.Reverse;
        }

        public FindStatus(bool matchCase, RichTextBoxFinds boxFinds, string selectedString, int startIndex, int endIndex, bool wholeWord, bool reverse)
        {
            this._MatchCase = matchCase;
            this._BoxFinds = boxFinds;
            this._SelectedString = selectedString;
            this._StartIndex = startIndex;
            this._EndIndex = endIndex;
            this._WholeWord = wholeWord;
            this._Reverse = reverse;
        }
    }
}