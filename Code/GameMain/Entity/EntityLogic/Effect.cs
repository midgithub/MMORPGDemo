using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace GameMain
{
    /// <summary>
    /// 技能特效
    /// </summary>
    public class Effect : EntityBase
    {
        [SerializeField]
        private EffectData m_effectData = null;

        private float m_ElapseSeconds = 0f;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_effectData = userData as EffectData;
            if (m_effectData == null)
            {
                Log.Error("Effect Data is invalid.");
                return;
            }

            Name = string.Format("{0}[{1}]", m_effectData.TypeId, m_effectData.Id);

            CachedTransform.position = m_effectData.Position;
            CachedTransform.localPosition = m_effectData.LocalPosition;
            CachedTransform.rotation = m_effectData.Rotation;
            CachedTransform.localScale = m_effectData.Scale;
            m_ElapseSeconds = 0f;
        }

        protected override void OnAttachTo(EntityLogic parentEntity, Transform parentTransform, object userData)
        {
            base.OnAttachTo(parentEntity, parentTransform, userData);

            CachedTransform.localPosition = m_effectData.LocalPosition;
            CachedTransform.rotation = m_effectData.Rotation;
            CachedTransform.localScale = m_effectData.Scale;
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            m_ElapseSeconds += elapseSeconds;
            if (m_ElapseSeconds >= m_effectData.KeepTime)
            {
                GameEntry.Entity.HideEntity(this);
            }
        }

    }

}
