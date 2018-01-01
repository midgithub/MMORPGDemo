namespace XFramework.Entity
{
    internal partial class EntityManager
    {
        /// <summary>
        /// 实体状态。
        /// </summary>
        private enum EntityStatus
        {
            /// <summary>
            /// 即将初始化
            /// </summary>
            WillInit,

            /// <summary>
            /// 初始化完毕
            /// </summary>
            Inited,

            /// <summary>
            /// 即将显示
            /// </summary>
            WillShow,

            /// <summary>
            /// 显示完毕
            /// </summary>
            Showed,

            /// <summary>
            /// 即将隐藏
            /// </summary>
            WillHide,

            /// <summary>
            /// 隐藏完毕
            /// </summary>
            Hidden,

            /// <summary>
            /// 即将回收
            /// </summary>
            WillRecycle,

            /// <summary>
            /// 回收完毕
            /// </summary>
            Recycled,
        }
    }
}
