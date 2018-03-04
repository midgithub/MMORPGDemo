using System;
using UnityEngine;
using UnityGameFramework.Runtime;
using XLua;

namespace GameMain
{
    public class XLuaComponent : GameFrameworkComponent
    {
        private LuaEnv m_luaEnv = null;

        [SerializeField]
        private const float GCInterval = 1;


        private float lastGCTime = 0;
        private Action luaOnStart = null;
        private Action luaOnUpdate = null;
        private Action luaOnDestroy = null;


        void Awake()
        {
            //初始化lua
            InitLua();

            //初始化自定义加载器
            InitCustomLoader();
        }

        private void InitLua()
        {
            m_luaEnv = new LuaEnv();
        }

        private void InitCustomLoader()
        {
            m_luaEnv.AddLoader((ref string fileName) =>
            {
                string assetName = AssetUtility.GetLuaAsset(fileName);
                TextAsset asset = GameEntry.Resource.LoadAssetSync(assetName) as TextAsset;
                string str = asset.text;
                return System.Text.Encoding.UTF8.GetBytes(str);
            });
        }

        private void StartLuaMain()
        {
            m_luaEnv.DoString("require 'main'");

        }

    }
}
