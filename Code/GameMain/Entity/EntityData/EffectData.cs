using UnityEngine;
using System;

namespace GameMain
{
    [Serializable]
    public class EffectData : EntityData
    {
        [SerializeField]
        private float m_KeepTime = 0f;

        [SerializeField]
        private float m_DelayTime = 0f;

        public EffectData(int entityId, int typeId, float keepTime,float delayTime) : base(entityId,typeId)
        {
            m_KeepTime = keepTime;
            m_DelayTime = delayTime;
        }

        public float KeepTime
        {
            get 
            {
                return m_KeepTime;
            }
        }

        public float DelayTime
        {
            get
            {
                return m_DelayTime;
            }
        }

    }
}
