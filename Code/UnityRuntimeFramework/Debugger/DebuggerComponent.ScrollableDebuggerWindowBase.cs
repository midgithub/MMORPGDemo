using UnityEngine;
using XFramework.Debugger;

namespace UnityGameFramework.Runtime
{
    public partial class DebuggerComponent
    {
        private abstract class ScrollableDebuggerWindowBase : IDebuggerWindow
        {
            private const float TitleWidth = 240f;
            private Vector2 m_ScrollPosition = Vector2.zero;

            public virtual void Initialize(params object[] args)
            {

            }

            public virtual void Shutdown()
            {

            }

            public virtual void OnEnter()
            {

            }

            public virtual void OnLeave()
            {

            }

            public virtual void OnUpdate(float elapseSeconds, float realElapseSeconds)
            {

            }

            public void OnDraw()
            {
                m_ScrollPosition = GUILayout.BeginScrollView(m_ScrollPosition);
                {
                    OnDrawScrollableWindow();
                }
                GUILayout.EndScrollView();
            }

            protected abstract void OnDrawScrollableWindow();

            protected void DrawItem(string title, string content)
            {
                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label(title, GUILayout.Width(TitleWidth));
                    GUILayout.Label(content);
                }
                GUILayout.EndHorizontal();
            }
        }
    }
}
