
//********************************************
//    Exported by ExcelConfigExport
//    此代码由工具根据配置自动生成, 建议不要修改。
//********************************************

using System.Collections.Generic;
using GameFramework.DataTable;

namespace GameMain
{
	partial class DRScene : IDataRow
	{
		/// <summary>
		/// ID(场景编号)
		/// </summary>
		public int Id { get; private set; }

		/// <summary>
		/// 名字
		/// </summary>
		public string SceneName { get; private set; }

		/// <summary>
		/// 资源名称
		/// </summary>
		public string AssetName { get; private set; }

		/// <summary>
		/// 背景音乐编号
		/// </summary>
		public int BackgroundMusicId { get; private set; }


		public DRScene()
		{
		}

		public void ParseDataRow(string dataRowText)
		{
			string[] text = DataTableExtension.SplitDataRow(dataRowText);
			int index = -1;
			Id = int.Parse(text[++index]);
			SceneName = text[++index];
			AssetName = text[++index];
			BackgroundMusicId = int.Parse(text[++index]);
		}

		private void AvoidJIT()
		{
			new Dictionary<int, DREntity>();
		}
	}

}

