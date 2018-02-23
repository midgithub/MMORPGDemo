using GameFramework.DataTable;
using System.Collections.Generic;

namespace GameMain
{
    /// <summary>
    /// 角色取名表
    /// </summary>
   public class DRRoleName : IDataRow
    {
        /// <summary>
        /// 名字编号
        /// </summary>
        public int Id
        {
            get;
            protected set;
        }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName
        {
            get;
            private set;
        }

        public void ParseDataRow(string dataRowText)
        {
            string[] text = DataTableExtension.SplitDataRow(dataRowText);
            int index = 0;
            index++;
            Id = int.Parse(text[index++]);
            index++;
            RoleName = text[index++];
        }

        private void AvoidJIT()
        {
            new Dictionary<int, DRRoleName>();
        }
    }
}
