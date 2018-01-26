using UnityEngine;

namespace UnityGameFramework.Runtime
{
    internal sealed class AttachEntityInfo
    {
        private readonly Transform m_ParentTransform;
        private readonly object m_UserData;

        public AttachEntityInfo(Transform parentTransform, object userData)
        {
            m_ParentTransform = parentTransform;
            m_UserData = userData;
        }

        public Transform ParentTransform
        {
            get
            {
                return m_ParentTransform;
            }
        }

        public object UserData
        {
            get
            {
                return m_UserData;
            }
        }
    }
}
