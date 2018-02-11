using System.Collections;
using FairyGUI;
using GameMain;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain
{
    public class FairyGuiForm : UIFormLogic
    {
        public const int DepthFactor = 100;
        private const float FadeTime = 0.3f;

        protected GComponent window = null;

        public int OriginalDepth
        {
            get;
            private set;
        }

        public int Depth
        {
            get
            {
                return window.sortingOrder;
            }
        }

        public void Close()
        {
            Close(false);
        }

        public void Close(bool ignoreFade)
        {
            StopAllCoroutines();

            if (ignoreFade)
            {
                GameEntry.UI.CloseUIForm(this);
            }
            else
            {
                StartCoroutine(CloseCo(FadeTime));
            }
        }

        public void PlayUISound(int uiSoundId)
        {
            GameEntry.Sound.PlayUISound(uiSoundId);
        }

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            UIPanel panel = gameObject.GetOrAddComponent<UIPanel>();
            window = panel.ui;
            OriginalDepth = window.sortingOrder;

            Transform transform = GetComponent<Transform>();
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
            transform.localScale = Vector3.one;

        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            window.alpha = 0f;
            StopAllCoroutines();
            StartCoroutine(window.FadeToAlpha(1f, FadeTime));
        }

        protected override void OnClose(object userData)
        {
            base.OnClose(userData);
        }

        protected override void OnPause()
        {
            base.OnPause();
        }

        protected override void OnResume()
        {
            base.OnResume();

            window.alpha = 0f;
            StopAllCoroutines();
            StartCoroutine(window.FadeToAlpha(1f, FadeTime));
        }

        protected override void OnCover()
        {
            base.OnCover();
        }

        protected override void OnReveal()
        {
            base.OnReveal();
        }

        protected override void OnRefocus(object userData)
        {
            base.OnRefocus(userData);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
        }

        protected override void OnDepthChanged(int uiGroupDepth, int depthInUIGroup)
        {
            int oldDepth = Depth;
            base.OnDepthChanged(uiGroupDepth, depthInUIGroup);
            int deltaDepth = FairyGuiGroupHelper.DepthFactor * uiGroupDepth + DepthFactor * depthInUIGroup - oldDepth + OriginalDepth;
            window.sortingOrder = deltaDepth;
        }

        private IEnumerator CloseCo(float duration)
        {
            yield return window.FadeToAlpha(0f, duration);
            GameEntry.UI.CloseUIForm(this);
        }
    }
}
