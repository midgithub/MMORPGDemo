using XFramework.Base;

namespace XFramework.Resource
{
    /// <summary>
    /// 加载场景成功回调函数。
    /// </summary>
    /// <param name="sceneAssetName">要加载的场景资源名称。</param>
    /// <param name="duration">加载持续时间。</param>
    /// <param name="userData">用户自定义数据。</param>
    public delegate void LoadSceneSuccessCallback(string sceneAssetName, float duration, object userData);

    /// <summary>
    /// 加载场景失败回调函数。
    /// </summary>
    /// <param name="sceneAssetName">要加载的场景资源名称。</param>
    /// <param name="status">加载场景状态。</param>
    /// <param name="errorMessage">错误信息。</param>
    /// <param name="userData">用户自定义数据。</param>
    public delegate void LoadSceneFailureCallback(string sceneAssetName, LoadResourceStatus status, string errorMessage, object userData);

    /// <summary>
    /// 加载场景更新回调函数。
    /// </summary>
    /// <param name="sceneAssetName">要加载的场景资源名称。</param>
    /// <param name="progress">加载场景进度。</param>
    /// <param name="userData">用户自定义数据。</param>
    public delegate void LoadSceneUpdateCallback(string sceneAssetName, float progress, object userData);

    /// <summary>
    /// 加载场景时加载依赖资源回调函数。
    /// </summary>
    /// <param name="sceneAssetName">要加载的场景资源名称。</param>
    /// <param name="dependencyAssetName">被加载的依赖资源名称。</param>
    /// <param name="loadedCount">当前已加载依赖资源数量。</param>
    /// <param name="totalCount">总共加载依赖资源数量。</param>
    /// <param name="userData">用户自定义数据。</param>
    public delegate void LoadSceneDependencyAssetCallback(string sceneAssetName, string dependencyAssetName, int loadedCount, int totalCount, object userData);






    /// <summary>
    /// 加载场景回调函数集。
    /// </summary>
    public sealed class LoadSceneCallbacks
    {
        private readonly LoadSceneSuccessCallback m_LoadSceneSuccessCallback;
        private readonly LoadSceneFailureCallback m_LoadSceneFailureCallback;
        private readonly LoadSceneUpdateCallback m_LoadSceneUpdateCallback;
        private readonly LoadSceneDependencyAssetCallback m_LoadSceneDependencyAssetCallback;

        /// <summary>
        /// 初始化加载场景回调函数集的新实例。
        /// </summary>
        /// <param name="loadSceneSuccessCallback">加载场景成功回调函数。</param>
        public LoadSceneCallbacks(LoadSceneSuccessCallback loadSceneSuccessCallback)
            : this(loadSceneSuccessCallback, null, null, null)
        {

        }

        /// <summary>
        /// 初始化加载场景回调函数集的新实例。
        /// </summary>
        /// <param name="loadSceneSuccessCallback">加载场景成功回调函数。</param>
        /// <param name="loadSceneFailureCallback">加载场景失败回调函数。</param>
        public LoadSceneCallbacks(LoadSceneSuccessCallback loadSceneSuccessCallback, LoadSceneFailureCallback loadSceneFailureCallback)
            : this(loadSceneSuccessCallback, loadSceneFailureCallback, null, null)
        {

        }

        /// <summary>
        /// 初始化加载场景回调函数集的新实例。
        /// </summary>
        /// <param name="loadSceneSuccessCallback">加载场景成功回调函数。</param>
        /// <param name="loadSceneUpdateCallback">加载场景更新回调函数。</param>
        public LoadSceneCallbacks(LoadSceneSuccessCallback loadSceneSuccessCallback, LoadSceneUpdateCallback loadSceneUpdateCallback)
            : this(loadSceneSuccessCallback, null, loadSceneUpdateCallback, null)
        {

        }

        /// <summary>
        /// 初始化加载场景回调函数集的新实例。
        /// </summary>
        /// <param name="loadSceneSuccessCallback">加载场景成功回调函数。</param>
        /// <param name="loadSceneDependencyAssetCallback">加载场景时加载依赖资源回调函数。</param>
        public LoadSceneCallbacks(LoadSceneSuccessCallback loadSceneSuccessCallback, LoadSceneDependencyAssetCallback loadSceneDependencyAssetCallback)
            : this(loadSceneSuccessCallback, null, null, loadSceneDependencyAssetCallback)
        {

        }

        /// <summary>
        /// 初始化加载场景回调函数集的新实例。
        /// </summary>
        /// <param name="loadSceneSuccessCallback">加载场景成功回调函数。</param>
        /// <param name="loadSceneFailureCallback">加载场景失败回调函数。</param>
        /// <param name="loadSceneUpdateCallback">加载场景更新回调函数。</param>
        public LoadSceneCallbacks(LoadSceneSuccessCallback loadSceneSuccessCallback, LoadSceneFailureCallback loadSceneFailureCallback, LoadSceneUpdateCallback loadSceneUpdateCallback)
            : this(loadSceneSuccessCallback, loadSceneFailureCallback, loadSceneUpdateCallback, null)
        {

        }

        /// <summary>
        /// 初始化加载场景回调函数集的新实例。
        /// </summary>
        /// <param name="loadSceneSuccessCallback">加载场景成功回调函数。</param>
        /// <param name="loadSceneFailureCallback">加载场景失败回调函数。</param>
        /// <param name="loadSceneDependencyAssetCallback">加载场景时加载依赖资源回调函数。</param>
        public LoadSceneCallbacks(LoadSceneSuccessCallback loadSceneSuccessCallback, LoadSceneFailureCallback loadSceneFailureCallback, LoadSceneDependencyAssetCallback loadSceneDependencyAssetCallback)
            : this(loadSceneSuccessCallback, loadSceneFailureCallback, null, loadSceneDependencyAssetCallback)
        {

        }

        /// <summary>
        /// 初始化加载场景回调函数集的新实例。
        /// </summary>
        /// <param name="loadSceneSuccessCallback">加载场景成功回调函数。</param>
        /// <param name="loadSceneFailureCallback">加载场景失败回调函数。</param>
        /// <param name="loadSceneUpdateCallback">加载场景更新回调函数。</param>
        /// <param name="loadSceneDependencyAssetCallback">加载场景时加载依赖资源回调函数。</param>
        public LoadSceneCallbacks(LoadSceneSuccessCallback loadSceneSuccessCallback, LoadSceneFailureCallback loadSceneFailureCallback, LoadSceneUpdateCallback loadSceneUpdateCallback, LoadSceneDependencyAssetCallback loadSceneDependencyAssetCallback)
        {
            if (loadSceneSuccessCallback == null)
            {
                throw new GameFrameworkException("Load scene success callback is invalid.");
            }

            m_LoadSceneSuccessCallback = loadSceneSuccessCallback;
            m_LoadSceneFailureCallback = loadSceneFailureCallback;
            m_LoadSceneUpdateCallback = loadSceneUpdateCallback;
            m_LoadSceneDependencyAssetCallback = loadSceneDependencyAssetCallback;
        }

        /// <summary>
        /// 获取加载场景成功回调函数。
        /// </summary>
        public LoadSceneSuccessCallback LoadSceneSuccessCallback
        {
            get
            {
                return m_LoadSceneSuccessCallback;
            }
        }

        /// <summary>
        /// 获取加载场景失败回调函数。
        /// </summary>
        public LoadSceneFailureCallback LoadSceneFailureCallback
        {
            get
            {
                return m_LoadSceneFailureCallback;
            }
        }

        /// <summary>
        /// 获取加载场景更新回调函数。
        /// </summary>
        public LoadSceneUpdateCallback LoadSceneUpdateCallback
        {
            get
            {
                return m_LoadSceneUpdateCallback;
            }
        }

        /// <summary>
        /// 获取加载场景时加载依赖资源回调函数。
        /// </summary>
        public LoadSceneDependencyAssetCallback LoadSceneDependencyAssetCallback
        {
            get
            {
                return m_LoadSceneDependencyAssetCallback;
            }
        }

    }
}
