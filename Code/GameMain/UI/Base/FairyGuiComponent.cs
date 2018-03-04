using FairyGUI;
using System;
using System.Collections.Generic;
using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain
{
    [DisallowMultipleComponent]
    public class FairyGuiComponent : GameFrameworkComponent
    {
        private class MyUIPackage
        {
            private UIPackage UIPackage { get; set; }
            public int ReferenceCount { get; set; }

            public MyUIPackage(UIPackage package,int reference)
            {
                UIPackage = package;
                ReferenceCount = reference;
            }
        }

        private Dictionary<string, MyUIPackage> m_UIPackages = null; 

        private void Start()
        {
            m_UIPackages = new Dictionary<string, MyUIPackage>();
        }

        /// <summary>
        /// 添加FairyGUI的UIPackage
        /// </summary>
        /// <param name="packageAssetName">资源包名</param>
        public void AddPackage(string packagePath)
        {
            if (!m_UIPackages.ContainsKey(packagePath))
            {
                string packageAssetPath = AssetUtility.GetFairyGuiPackageAsset(packagePath);
                UIPackage package = UIPackage.AddPackage(packageAssetPath, LoadPackageAsset);
                if (package != null)
                {
                    MyUIPackage myUiPackage = new MyUIPackage(package, 0);
                }
                else
                {
                    Log.Error("AddPackage Failure,packagePath:{0}", packagePath);
                }
            }
            else
            {
                MyUIPackage myUiPackage;
                if (m_UIPackages.TryGetValue(packagePath,out myUiPackage))
                {
                    myUiPackage.ReferenceCount++;
                }
                else
                {
                    Log.Error("Can no get myUIpackage,package:{0}", packagePath);
                }
            }
            
        }

        /// <summary>
        /// 移除FairGUI的UIPackage,如果没有引用了就直接移除，否则移除引用计数
        /// </summary>
        /// <param name="packagePath"></param>
        public void RemovePackage(string packagePath)
        {
            MyUIPackage myUiPackage;
            if (m_UIPackages.TryGetValue(packagePath, out myUiPackage))
            {
                myUiPackage.ReferenceCount--;
                if (myUiPackage.ReferenceCount <= 0)
                {
                    string packageAssetPath = AssetUtility.GetFairyGuiPackageAsset(packagePath);
                    UIPackage.RemovePackage(packageAssetPath);
                }
                m_UIPackages.Remove(packagePath);
            }
        }

        private object LoadPackageAsset(string name, string extension, Type type)
        {
            return GameEntry.Resource.LoadAssetSync(name + extension);
        }


    }
}
