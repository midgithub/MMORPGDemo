using UnityEngine;

namespace UnityGameFramework.Runtime
{
    public partial class DebuggerComponent
    {
        private sealed class PathInformationWindow : ScrollableDebuggerWindowBase
        {
            protected override void OnDrawScrollableWindow()
            {
                GUILayout.Label("<b>Path Information</b>");
                GUILayout.BeginVertical("box");
                {
                    DrawItem("Data Path:", Application.dataPath);
                    DrawItem("Persistent Data Path:", Application.persistentDataPath);
                    DrawItem("Streaming Assets Path:", Application.streamingAssetsPath);
                    DrawItem("Temporary Cache Path:", Application.temporaryCachePath);
                }
                GUILayout.EndVertical();
            }
        }
    }
}
