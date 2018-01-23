using XFramework.Event;

namespace UnityRuntimeFramework.Resource
{
    /// <summary>
    /// 版本资源列表更新失败事件。
    /// </summary>
    public sealed class VersionListUpdateFailureEventArgs : GameEventArgs
    {
        /// <summary>
        /// 版本资源列表更新失败事件编号。
        /// </summary>
        public static readonly int EventId = typeof(VersionListUpdateFailureEventArgs).GetHashCode();

        /// <summary>
        /// 获取版本资源列表更新失败事件编号。
        /// </summary>
        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        /// <summary>
        /// 获取下载地址。
        /// </summary>
        public string DownloadUri
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取错误信息。
        /// </summary>
        public string ErrorMessage
        {
            get;
            private set;
        }

        /// <summary>
        /// 清理版本资源列表更新失败事件。
        /// </summary>
        public override void Clear()
        {
            DownloadUri = default(string);
            ErrorMessage = default(string);
        }

        /// <summary>
        /// 填充版本资源列表更新失败事件。
        /// </summary>
        /// <param name="e">内部事件。</param>
        /// <returns>版本资源列表更新失败事件。</returns>
        public VersionListUpdateFailureEventArgs Fill(XFramework.Resource.VersionListUpdateFailureEventArgs e)
        {
            DownloadUri = e.DownloadUri;
            ErrorMessage = e.ErrorMessage;

            return this;
        }
    }
}
