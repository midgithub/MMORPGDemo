using GameFramework;
using XLua;

namespace GameMain
{
    /// <summary>
    /// Lua界面，管理lua界面的生命周期等
    /// </summary>
    [LuaCallCSharp]
    public class FairyGuiLuaForm : FairyGuiForm
    {
        private GameFrameworkAction<object> luaOnInit;
        private GameFrameworkAction<object> luaOnOpen;
        private GameFrameworkAction<object> luaOnClose;
        private GameFrameworkAction luaOnPause;
        private GameFrameworkAction luaOnResume;
        private GameFrameworkAction luaOnCover;
        private GameFrameworkAction luaOnReveal;
        private GameFrameworkAction luaOnRefocus;
        private GameFrameworkAction<float,float> luaOnUpdate;
        private GameFrameworkAction<int, int> luaOnDepthChanged;
        private GameFrameworkAction luaOnDestroy;
        private LuaTable luaForm;

        /// <summary>
        /// 界面初始化。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            LuaEnv m_luaEnv = GameEntry.Lua.LuaEnv;
            string luaFormName = GameEntry.FairyGui.GetLuaForm(UIForm.SerialId);
            if (string.IsNullOrEmpty(luaFormName))
            {
                Log.Error("luaForm is invalid. ID:{0}", UIForm.SerialId);
                return;
            }
            string luaScript = string.Format("require '{0}'", luaFormName);
            m_luaEnv.DoString(luaScript);

            luaForm = m_luaEnv.Global.Get<LuaTable>(luaFormName);
            if (luaForm == null)
            {
                Log.Error("Can no get luaForm. Key:{0}", luaFormName);
                return;
            }
            luaForm.Set("self", this);
            luaOnInit = luaForm.Get<GameFrameworkAction<object>>("OnInit");
            luaOnOpen = luaForm.Get<GameFrameworkAction<object>>("OnOpen");
            luaOnClose = luaForm.Get<GameFrameworkAction<object>>("OnClose");
            luaOnPause = luaForm.Get<GameFrameworkAction>("OnPause");
            luaOnResume = luaForm.Get<GameFrameworkAction>("OnResume");
            luaOnCover = luaForm.Get<GameFrameworkAction>("OnCover");
            luaOnReveal = luaForm.Get<GameFrameworkAction>("OnReveal");
            luaOnRefocus = luaForm.Get<GameFrameworkAction>("OnRefocus");
            luaOnUpdate = luaForm.Get<GameFrameworkAction<float, float>>("OnUpdate");
            luaOnDepthChanged = luaForm.Get<GameFrameworkAction<int, int>>("OnDepthChanged");
            luaOnDestroy = luaForm.Get<GameFrameworkAction>("OnDestroy");

            luaOnInit?.Invoke(userData);
        }

        /// <summary>
        /// 界面打开。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            luaOnOpen?.Invoke(userData);
        }

        /// <summary>
        /// 界面关闭。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        protected override void OnClose(object userData)
        {
            base.OnClose(userData);
            luaOnClose?.Invoke(userData);
        }

        /// <summary>
        /// 界面暂停。
        /// </summary>
        protected override void OnPause()
        {
            base.OnPause();
            luaOnPause?.Invoke();
        }

        /// <summary>
        /// 界面暂停恢复。
        /// </summary>
        protected override void OnResume()
        {
            base.OnResume();
            luaOnResume?.Invoke();
        }

        /// <summary>
        /// 界面遮挡。
        /// </summary>
        protected override void OnCover()
        {
            base.OnCover();
            luaOnCover?.Invoke();
        }

        /// <summary>
        /// 界面遮挡恢复。
        /// </summary>
        protected override void OnReveal()
        {
            base.OnReveal();
            luaOnReveal?.Invoke();
        }

        /// <summary>
        /// 界面激活。
        /// </summary>
        /// <param name="userData">用户自定义数据。</param>
        protected override void OnRefocus(object userData)
        {
            base.OnRefocus(userData);
            luaOnRefocus?.Invoke();
        }

        /// <summary>
        /// 界面轮询。
        /// </summary>
        /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位。</param>
        /// <param name="realElapseSeconds">真实流逝时间，以秒为单位。</param>
        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            luaOnUpdate?.Invoke(elapseSeconds, realElapseSeconds);
        }

        /// <summary>
        /// 界面深度改变。
        /// </summary>
        /// <param name="uiGroupDepth">界面组深度。</param>
        /// <param name="depthInUIGroup">界面在界面组中的深度。</param>
        protected override void OnDepthChanged(int uiGroupDepth, int depthInUIGroup)
        {
            base.OnDepthChanged(uiGroupDepth, depthInUIGroup);
            luaOnDepthChanged?.Invoke(uiGroupDepth, depthInUIGroup);
        }

        /// <summary>
        /// 界面销毁
        /// </summary>
        protected override void OnDestroy()
        {
            luaOnDestroy?.Invoke();

            luaOnInit = null;
            luaOnOpen = null;
            luaOnClose = null;
            luaOnPause = null;
            luaOnResume = null;
            luaOnCover = null;
            luaOnReveal = null;
            luaOnRefocus = null;
            luaOnUpdate = null;
            luaOnDepthChanged = null;
            luaOnDestroy = null;
            luaForm.Dispose();

            base.OnDestroy();
        }
    }
}
