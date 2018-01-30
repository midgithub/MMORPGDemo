using UnityEditor;
using UnityEngine;

namespace UnityEditorExtension.Misc
{
    /// <summary>
    /// 帮助相关的实用函数。
    /// </summary>
    internal static class Help
    {
        internal static void ShowComponentHelp(string componentName)
        {
            ShowHelp(string.Format("http://gameframework.cn/archives/category/module/buildin/{0}/", componentName));
        }

        [MenuItem("Game Framework/Documentation", false, 90)]
        private static void ShowDocumentation()
        {
            ShowHelp("http://gameframework.cn/");
        }

        [MenuItem("Game Framework/API Reference", false, 91)]
        private static void ShowAPI()
        {
            ShowHelp("http://gameframework.cn/api/");
        }

        private static void ShowHelp(string uri)
        {
            Application.OpenURL(uri);
        }
    }
}
