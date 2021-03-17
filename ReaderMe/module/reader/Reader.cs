namespace ReaderMe.Module.Reader
{
    /// <summary>
    /// 读者
    /// </summary>
    public class Reader
    {
        /// <summary>
        /// 获取或设置读者的用户名
        /// </summary>
        public string Name { get; set; }

        public override int GetHashCode()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return base.GetHashCode();
            }
            else
            {
                return Name.GetHashCode();
            }
        }

        public override bool Equals(object obj)
        {
            Reader reader = obj as Reader;
            if (null == reader)
            {
                return false;
            }
            else
            {
                if (string.IsNullOrEmpty(reader.Name))
                {
                    return false;
                }
                {
                    return reader.Name.Equals(this.Name);
                }
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
