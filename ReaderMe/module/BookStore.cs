namespace GPStudio.Tools.ReaderMe.module
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// 书架
    /// </summary>
    public class BookStore : CollectionBase
    {
        public int IndexOf(FileInformation item)
        {
            return this.List.IndexOf(item);
        }

        public void Insert(int index, FileInformation item)
        {
            this.List.Insert(index, item);
        }

        public FileInformation this[int index]
        {
            get
            {
                return this.List[index] as FileInformation;
            }
            set
            {
                this.List[index] = value;
            }
        }

        public FileInformation this[string md5]
        {
            get
            {
                return Find(md5);
            }
            set
            {
                FileInformation fileInfo = Find(md5);
                if (null == fileInfo)
                {
                    throw new KeyNotFoundException("不存在符合指定MD5的文件");
                }
            }
        }

        private FileInformation Find(string md5)
        {
            FileInformation result = null;
            foreach (FileInformation fileInfo in this.List)
            {
                if (0 == string.Compare(md5, fileInfo.MD5, true))
                {
                    result = fileInfo;
                    break;
                }
            }
            return result;
        }

        public void Add(FileInformation item)
        {
            this.List.Add(item);
        }

        public bool Contains(FileInformation item)
        {
            return this.List.Contains(item);
        }

        public void Remove(FileInformation item)
        {
            this.List.Remove(item);
        }
    }
}
