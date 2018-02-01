using XFramework.Base;
using XFramework.ObjectPool;

namespace XFramework.UI
{
    internal partial class UIManager
    {
        /// <summary>
        /// 界面实例对象。
        /// </summary>
        private sealed class UIFormInstanceObject : ObjectBase
        {
            private readonly object m_UIFormAsset;
            private readonly IUIFormHelper m_UIFormHelper;

            public UIFormInstanceObject(string name, object uiFormAsset, object uiFormInstance, IUIFormHelper uiFormHelper)
                : base(name, uiFormInstance)
            {
                if (uiFormAsset == null)
                {
                    throw new GameFrameworkException("UI form asset is invalid.");
                }

                if (uiFormHelper == null)
                {
                    throw new GameFrameworkException("UI form helper is invalid.");
                }

                m_UIFormAsset = uiFormAsset;
                m_UIFormHelper = uiFormHelper;
            }

            protected internal override void Release()
            {
                m_UIFormHelper.ReleaseUIForm(m_UIFormAsset, Target);
            }
        }
    }
}
