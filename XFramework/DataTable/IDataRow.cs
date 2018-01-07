namespace XFramework.DataTable
{
    /// <summary>
    /// 数据表行接口
    /// </summary>
    public interface IDataRow
    {
        /// <summary>
        /// 获取数据表行的编号。
        /// </summary>
        int Id
        {
            get;
        }

        /// <summary>
        /// 数据表行文本内容解析器。
        /// </summary>
        /// <param name="dataRowText">要解析的文本内容。</param>
        void ParseDataRow(string dataRowText);
    }
}
