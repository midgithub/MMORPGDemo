using UnityEditor;
using UnityGameFramework.Runtime;
using XFramework.DataNode;

namespace UnityEditorExtension.Inspector
{
    [CustomEditor(typeof(DataNodeComponent))]
    internal sealed class DataNodeComponentInspector : GameFrameworkInspector
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (!EditorApplication.isPlaying)
            {
                EditorGUILayout.HelpBox("Available during runtime only.", MessageType.Info);
                return;
            }

            DataNodeComponent t = (DataNodeComponent)target;

            if (PrefabUtility.GetPrefabType(t.gameObject) != PrefabType.Prefab)
            {
                DrawDataNode(t.Root);
            }

            Repaint();
        }

        private void OnEnable()
        {

        }

        private void DrawDataNode(IDataNode dataNode)
        {
            EditorGUILayout.LabelField(dataNode.FullName, dataNode.ToDataString());
            IDataNode[] child = dataNode.GetAllChild();
            foreach (IDataNode c in child)
            {
                DrawDataNode(c);
            }
        }
    }
}
