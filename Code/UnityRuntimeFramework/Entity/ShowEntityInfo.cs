using System;

namespace UnityGameFramework.Runtime
{
    internal sealed class ShowEntityInfo
    {
        private readonly Type m_EntityLogicType;
        private readonly object m_UserData;

        public ShowEntityInfo(Type entityLogicType, object userData)
        {
            m_EntityLogicType = entityLogicType;
            m_UserData = userData;
        }

        public Type EntityLogicType
        {
            get
            {
                return m_EntityLogicType;
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
