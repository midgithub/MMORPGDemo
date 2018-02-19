using GameFramework;

namespace GameMain
{
    /// <summary>
    /// 登陆界面数据
    /// </summary>
    public class LoginFormParams
    {
        /// <summary>
        /// 游戏版本
        /// </summary>
        public string Version
        {
            get;
            set;
        }

        /// <summary>
        /// 游戏公告
        /// </summary>
        public string Notice
        {
            get;
            set;
        }

        /// <summary>
        /// 点击登陆
        /// </summary>
        public GameFrameworkAction<object> OnClickLogin
        {
            get;
            set;
        }

        /// <summary>
        /// 点击注册
        /// </summary>
        public GameFrameworkAction<object> OnClickRegister
        {
            get;
            set;
        }

    }
}
