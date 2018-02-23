using System;
using GameFramework;
using GameFramework.DataTable;
using UnityGameFramework.Runtime;

namespace GameMain
{
    public static class EntityExtension
    {
        // 关于 EntityId 的约定：
        // 0 为无效
        // 正值用于和服务器通信的实体（如玩家角色、NPC、怪等，服务器只产生正值）
        // 负值用于本地生成的临时实体（如特效、FakeObject等）
        private static int s_SerialId = 0;

        /// <summary>
        /// 生成实体序列ID（正值）
        /// </summary>
        public static int GenerateSerialId(this EntityComponent entityComponent)
        {
            return ++s_SerialId;
        }

        /// <summary>
        /// 生成临时实体序列ID（负值）
        /// </summary>
        public static int GenerateTempSerialId(this EntityComponent entityComponent)
        {
            return --s_SerialId;
        }

        public static EntityBase GetGameEntity(this EntityComponent entityComponent, int entityId)
        {
            UnityGameFramework.Runtime.Entity entity = entityComponent.GetEntity(entityId);
            if (entity == null)
            {
                return null;
            }

            return (EntityBase) entity.Logic;
        }

        public static void HideEntity(this EntityComponent entityComponent, EntityBase entity)
        {
            entityComponent.HideEntity(entity.Entity);
        }

        public static void AttachEntity(this EntityComponent entityComponent, EntityBase entity, int ownerId,
            string parentTransformPath = null, object userData = null)
        {
            entityComponent.AttachEntity(entity.Entity, ownerId, parentTransformPath, userData);
        }

        public static void ShowEntity(this EntityComponent entityComponent, Type logicType, string entityGroup, EntityData data)
        {
            if (data == null)
            {
                Log.Warning("Data is invalid.");
                return;
            }

            if (entityComponent.HasEntity(data.Id))
            {
                Log.Warning(string.Format("Entity {0} is exit.", data.Id));
                return;
            }

            IDataTable<DREntity> dtEntity = GameEntry.DataTable.GetDataTable<DREntity>();
            DREntity drEntity = dtEntity.GetDataRow(data.TypeId);
            if (drEntity == null)
            {
                Log.Warning("Can not load entity id '{0}' from data table.", data.TypeId.ToString());
                return;
            }

            entityComponent.ShowEntity(data.Id, logicType, AssetUtility.GetEntityAsset(drEntity.AssetName), entityGroup, data);
        }


        //-----------------简化调用函数----------------
        public static void ShowEffect(this EntityComponent entityComponent, EffectData data)
        {
            entityComponent.ShowEntity(typeof(Effect), "Effect", data);
        }

        public static void ShowPoseRole(this EntityComponent entityComponent,PoseRoleData data)
        {
            entityComponent.ShowEntity(typeof(PoseRole), "PoseRole", data);
        }

    }
}
