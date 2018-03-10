
//********************************************
//    Exported by ExcelConfigExport
//    此代码由工具根据配置自动生成, 建议不要修改。
//********************************************

using System.Collections.Generic;
using GameFramework.DataTable;

namespace GameMain
{
	partial class DRWeapon : IDataRow
	{
		/// <summary>
		/// 装备编号
		/// </summary>
		public int Id { get; private set; }

		/// <summary>
		/// 对应的实体编号
		/// </summary>
		public int EntityId { get; private set; }

		/// <summary>
		/// 对应图标编号
		/// </summary>
		public int IconId { get; private set; }

		/// <summary>
		/// 装备名称
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// 装备职业(0:通用)
		/// </summary>
		public int EquipProfession { get; private set; }

		/// <summary>
		/// 装备等级
		/// </summary>
		public int EquipLevel { get; private set; }

		/// <summary>
		/// 装备部位
		/// </summary>
		public int EquipPart { get; private set; }

		/// <summary>
		/// 攻击
		/// </summary>
		public int Attack { get; private set; }

		/// <summary>
		/// 防御
		/// </summary>
		public int Defense { get; private set; }

		/// <summary>
		/// 命中
		/// </summary>
		public int HitRate { get; private set; }

		/// <summary>
		/// 闪避
		/// </summary>
		public int Hedge { get; private set; }

		/// <summary>
		/// 暴击
		/// </summary>
		public int Strike { get; private set; }

		/// <summary>
		/// 格挡
		/// </summary>
		public int Tenacity { get; private set; }

		/// <summary>
		/// 强化增长率
		/// </summary>
		public float StrengthRate { get; private set; }

		/// <summary>
		/// 购买价格
		/// </summary>
		public int Price { get; private set; }

		/// <summary>
		/// 出售价格
		/// </summary>
		public int SellPrice { get; private set; }


		public DRWeapon()
		{
		}

		public void ParseDataRow(string dataRowText)
		{
			string[] text = DataTableExtension.SplitDataRow(dataRowText);
			int index = -1;
			Id = int.Parse(text[++index]);
			EntityId = int.Parse(text[++index]);
			IconId = int.Parse(text[++index]);
			Name = text[++index];
			EquipProfession = int.Parse(text[++index]);
			EquipLevel = int.Parse(text[++index]);
			EquipPart = int.Parse(text[++index]);
			Attack = int.Parse(text[++index]);
			Defense = int.Parse(text[++index]);
			HitRate = int.Parse(text[++index]);
			Hedge = int.Parse(text[++index]);
			Strike = int.Parse(text[++index]);
			Tenacity = int.Parse(text[++index]);
			StrengthRate = float.Parse(text[++index]);
			Price = int.Parse(text[++index]);
			SellPrice = int.Parse(text[++index]);
		}

		private void AvoidJIT()
		{
			new Dictionary<int, DREntity>();
		}
	}

}

