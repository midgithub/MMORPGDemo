namespace XFramework.Entity
{
    internal partial class EntityManager
    {
        private sealed class ShowEntityInfo
        {
            private readonly int m_EntityId;
            private readonly EntityGroup m_EntityGroup;
            private readonly object m_UserData;

            public ShowEntityInfo(int entityId, EntityGroup entityGroup, object userData)
            {
                m_EntityId = entityId;
                m_EntityGroup = entityGroup;
                m_UserData = userData;
            }

            public int EntityId
            {
                get
                {
                    return m_EntityId;
                }
            }

            public EntityGroup EntityGroup
            {
                get
                {
                    return m_EntityGroup;
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
}
