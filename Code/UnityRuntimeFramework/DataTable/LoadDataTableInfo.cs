using System;

namespace UnityRuntimeFramework.DataTable
{
    internal sealed class LoadDataTableInfo
    {
        private readonly Type m_DataRowType;
        private readonly string m_DataTableName;
        private readonly string m_DataTableNameInType;
        private readonly object m_UserData;

        public LoadDataTableInfo(Type dataRowType, string dataTableName, string dataTableNameInType, object userData)
        {
            m_DataRowType = dataRowType;
            m_DataTableName = dataTableName;
            m_DataTableNameInType = dataTableNameInType;
            m_UserData = userData;
        }

        /// <summary>
        /// 获取数据行的类型。
        /// </summary>
        public Type DataRowType
        {
            get
            {
                return m_DataRowType;
            }
        }

        /// <summary>
        /// 获取数据表名称。
        /// </summary>
        public string DataTableName
        {
            get
            {
                return m_DataTableName;
            }
        }

        /// <summary>
        /// 数据表的类型
        /// </summary>
        public string DataTableNameInType
        {
            get
            {
                return m_DataTableNameInType;
            }
        }

        /// <summary>
        /// 获取用户自定义数据。
        /// </summary>
        public object UserData
        {
            get
            {
                return m_UserData;
            }
        }
    }
}
