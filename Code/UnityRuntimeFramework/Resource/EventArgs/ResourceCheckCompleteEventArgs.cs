using XFramework.Event;

namespace UnityRuntimeFramework.Resource
{
    /// <summary>
    /// 资源检查完成事件。
    /// </summary>
    public sealed class ResourceCheckCompleteEventArgs : GameEventArgs
    {
        /// <summary>
        /// 资源检查完成事件编号。
        /// </summary>
        public static readonly int EventId = typeof(ResourceCheckCompleteEventArgs).GetHashCode();

        /// <summary>
        /// 获取资源检查完成事件编号。
        /// </summary>
        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        /// <summary>
        /// 获取已移除的资源数量。
        /// </summary>
        public int RemovedCount
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取要更新的资源数量。
        /// </summary>
        public int UpdateCount
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取要更新的资源总大小。
        /// </summary>
        public int UpdateTotalLength
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取要更新的压缩包总大小。
        /// </summary>
        public int UpdateTotalZipLength
        {
            get;
            private set;
        }

        /// <summary>
        /// 清理资源检查完成事件。
        /// </summary>
        public override void Clear()
        {
            RemovedCount = default(int);
            UpdateCount = default(int);
            UpdateTotalLength = default(int);
            UpdateTotalZipLength = default(int);
        }

        /// <summary>
        /// 填充资源检查完成事件。
        /// </summary>
        /// <param name="e">内部事件。</param>
        /// <returns>资源检查完成事件。</returns>
        public ResourceCheckCompleteEventArgs Fill(XFramework.Resource.ResourceCheckCompleteEventArgs e)
        {
            RemovedCount = e.RemovedCount;
            UpdateCount = e.UpdateCount;
            UpdateTotalLength = e.UpdateTotalLength;
            UpdateTotalZipLength = e.UpdateTotalZipLength;

            return this;
        }
    }
}
