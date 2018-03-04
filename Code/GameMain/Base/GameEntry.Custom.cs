namespace GameMain
{
    /// <summary>
    /// 游戏入口。
    /// </summary>
    public partial class GameEntry
    {
        private static void InitCustomComponents()
        {
            Config = UnityGameFramework.Runtime.GameEntry.GetComponent<ConfigComponent>();
            FairyGui = UnityGameFramework.Runtime.GameEntry.GetComponent<FairyGuiComponent>();   
        }

        public static FairyGuiComponent FairyGui
        {
            get;
            private set;
        }

        public static ConfigComponent Config
        {
            get;
            private set;
        }
    }
}
