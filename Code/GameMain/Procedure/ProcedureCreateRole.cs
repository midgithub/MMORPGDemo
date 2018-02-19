using GameFramework;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameMain
{
    public class ProcedureCreateRole : ProcedureBase
    {
        public override bool UseNativeDialog
        {
            get
            {
                return false;
            }
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            RoleCreateFormParams data = new RoleCreateFormParams();
            data.RandomNameQueue = new Queue<string>();
            data.RandomNameQueue.Enqueue("梅长苏");
            data.RandomNameQueue.Enqueue("靖王");
            data.OnClickRoleType = OnClickRoleType;
            data.OnClickCreateRole = OnClickCreateRole;
            GameEntry.UI.OpenUIForm(UIFormId.CreateRole, data);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
            GameEntry.UI.CloseUIForm(UIFormId.CreateRole);
        }

        private void OnClickRoleType(int type)
        {
            Log.Info("selete type : " + type);
        }

        private void OnClickCreateRole(string roleName)
        {
            Log.Info("create role ,name : " + roleName);
        }

    }

}
