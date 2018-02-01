namespace XFramework.Download
{
    internal partial class DownloadManager
    {
        private partial class DownloadCounter
        {
            private sealed class DownloadCounterNode
            {
                private readonly int m_DownloadedLength;
                private float m_ElapseSeconds;

                public DownloadCounterNode(int downloadedLength)
                {
                    m_DownloadedLength = downloadedLength;
                    m_ElapseSeconds = 0f;
                }

                /// <summary>
                /// 下载大小
                /// </summary>
                public int DownloadedLength
                {
                    get
                    {
                        return m_DownloadedLength;
                    }
                }

                /// <summary>
                /// 下载耗时
                /// </summary>
                public float ElapseSeconds
                {
                    get
                    {
                        return m_ElapseSeconds;
                    }
                }

                public void Update(float elapseSeconds, float realElapseSeconds)
                {
                    m_ElapseSeconds += realElapseSeconds;
                }
            }

        }
    }
}
