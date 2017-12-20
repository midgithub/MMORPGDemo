using System.Collections.Generic;

namespace XFramework.DataTable
{
    internal partial class DataTableManager
    {
        private sealed class DataTable<T> : DataTableBase, IDataTable<T> where T : class, IDataRow, new()
        {
            private readonly Dictionary<int, T> m_DataSet;
            private T m_MinIdDataRow;
            private T m_MaxIdDataRow;

            /// <summary>
            /// 初始化数据表的新实例
            /// </summary>
            /// <param name="name"></param>
            public DataTable(string name) : base(name)
            {
                
            } 

        }

    }
}
