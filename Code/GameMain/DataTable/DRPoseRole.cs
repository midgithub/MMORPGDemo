using GameFramework.DataTable;
using System.Collections.Generic;

namespace GameMain
{
    /// <summary>
    /// 职业创建表
    /// </summary>
    public class DRPoseRole : IDataRow
    {
        /// <summary>
        /// 职业编号
        /// </summary>
        public int Id
        {
            get;
            protected set;
        }

        /// <summary>
        /// 职业类型
        /// </summary>
        public ProfessionType ProfessionType
        {
            get;
            protected set;
        }

        /// <summary>
        /// 特效01ID
        /// </summary>
        public int Effect01
        {
            get;
            protected set;
        }

        /// <summary>
        /// 特效01延迟
        /// </summary>
        public float Effect01Delay
        {
            get;
            protected set;
        }

        /// <summary>
        /// 特效01持续时间
        /// </summary>
        public float Effect01Duration
        {
            get;
            protected set;
        }

        /// <summary>
        /// 特效02ID
        /// </summary>
        public int Effect02
        {
            get;
            protected set;
        }

        /// <summary>
        /// 特效02延迟
        /// </summary>
        public float Effect02Delay
        {
            get;
            protected set;
        }

        /// <summary>
        /// 特效02持续时间
        /// </summary>
        public float Effect02Duration
        {
            get;
            protected set;
        }

        /// <summary>
        /// 音效ID
        /// </summary>
        public int SoundId
        {
            get;
            private set;
        }

        /// <summary>
        /// 音效延迟
        /// </summary>
        public float SoundDelay
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

            ProfessionType = (ProfessionType)int.Parse(text[index++]);
            Effect01 = int.Parse(text[index++]);
            Effect01Delay = float.Parse(text[index++]);
            Effect01Duration = float.Parse(text[index++]);
            Effect02 = int.Parse(text[index++]);
            Effect02Delay = float.Parse(text[index++]);
            Effect02Duration = float.Parse(text[index++]);
            SoundId = int.Parse(text[index++]);
            SoundDelay = float.Parse(text[index++]);
        }

        private void AvoidJIT()
        {
            new Dictionary<int, DRPoseRole>();
        }

    }
}
