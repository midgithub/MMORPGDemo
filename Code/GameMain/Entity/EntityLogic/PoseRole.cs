using GameFramework;
using System;
using System.Collections;
using UnityEngine;

namespace GameMain
{
    /// <summary>
    /// 职业选择的角色
    /// </summary>
    public class PoseRole : EntityBase
    {
        [SerializeField]
        private PoseRoleData m_PoseRoleData = null;

        private Animator m_Animator = null;
        private bool m_IsShowing = false;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            m_PoseRoleData = userData as PoseRoleData;
            if (m_PoseRoleData == null)
            {
                Log.Error("PoseRole data is invalid.");
                return;
            }

            m_Animator = CachedTransform.GetComponent<Animator>();
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            Name = string.Format("{0}[{1}]", m_PoseRoleData.TypeId, m_PoseRoleData.Id);
            CachedTransform.position = Vector3.zero;
            CachedTransform.rotation = Quaternion.identity;
            CachedTransform.localScale = Vector3.one;

            if (!m_IsShowing)
            {
                StartCoroutine(ShowPose());
                m_IsShowing = false;
            }
        }

        IEnumerator ShowPose()
        {
            m_IsShowing = true;
            m_Animator.SetTrigger("pose");
            float delay01 = m_PoseRoleData.Effect01Data.DelayTime;
            float delay02 = m_PoseRoleData.Effect02Data.DelayTime;
            if (delay01 >= delay02)
            {
                yield return new WaitForSeconds(delay02);
                GameEntry.Entity.ShowEffect(m_PoseRoleData.Effect02Data);
                yield return new WaitForSeconds(delay01 - delay02);
                GameEntry.Entity.ShowEffect(m_PoseRoleData.Effect01Data);
                GameEntry.Sound.PlaySound(m_PoseRoleData.SoundId);
            }
            else
            {
                yield return new WaitForSeconds(delay01);
                GameEntry.Entity.ShowEffect(m_PoseRoleData.Effect01Data);
                yield return new WaitForSeconds(delay02 - delay01);
                GameEntry.Entity.ShowEffect(m_PoseRoleData.Effect02Data);
                GameEntry.Sound.PlaySound(m_PoseRoleData.SoundId);
            }
        }

    }

}
