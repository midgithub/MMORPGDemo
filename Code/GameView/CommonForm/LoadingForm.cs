using FairyGUI;
using GameFramework;
using GameFramework.Event;
using GameMain;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameView
{
    public class LoadingForm : FairyGuiForm
    {
        private GProgressBar m_LoadingBar = null;
        private GTextField m_TipsText = null;
        private GTextField m_LoadInfoText = null;
        private Controller m_BgCtrl = null;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            m_LoadingBar = window.GetChild("prg_loding").asProgress;
            m_TipsText = window.GetChild("tf_tips").asTextField;
            m_LoadInfoText = window.GetChild("tf_loadInfo").asTextField;
            m_BgCtrl = window.GetController("bgCtrl");
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            GameMain.GameEntry.Event.Subscribe(LoadSceneUpdateEventArgs.EventId, OnLoadSceneUpdate);

             int sceneId  = 0;
            try
            {
                sceneId = (int)userData;
            }
            catch
            {
                Log.Warning("LoadingFormParams is invalid.");
                return;
            }
            int index = 0;
            if (sceneId < 6 && sceneId > 0)
                index = sceneId - 1;
            m_BgCtrl.selectedIndex = index;
        }

        protected override void OnClose(object userData)
        {
            base.OnClose(userData);

            m_BgCtrl.selectedIndex = 0;
            m_TipsText.text = string.Empty;
            m_LoadInfoText.text = string.Empty;
            m_LoadingBar.value = 0;
        }

        private void OnLoadSceneUpdate(object sender, GameEventArgs e)
        {
            LoadSceneUpdateEventArgs ne = (LoadSceneUpdateEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            m_LoadingBar.value = ne.Progress;
            m_TipsText.text =  ne.SceneAssetName;
        }



    }
}
