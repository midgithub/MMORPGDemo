using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace GameMain
{
    /// <summary>
    /// Splash动画流程
    /// </summary>
    public class ProcedureSplash : ProcedureBase
    {
        private int logoEntityID = 0;

        public override bool UseNativeDialog
        {
            get
            {
                return true;
            }
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            logoEntityID = GameEntry.Entity.GenerateSerialId();
            LogoEntityData data = new LogoEntityData(logoEntityID, 10000);
            GameEntry.Entity.ShowEntity(typeof(LogoEntity), "LogoEntity", data);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);       

            // 编辑器模式下，直接进入预加载流程；否则，检查版本
            //ChangeState(procedureOwner,GameEntry.Base.EditorResourceMode ? typeof(ProcedurePreload) : typeof(ProcedureCheckVersion));
            ChangeState<ProcedurePreload>(procedureOwner);
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);

            GameEntry.Entity.DetachEntity(logoEntityID);
        }

    }
}
