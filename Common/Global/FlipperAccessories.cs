using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace TerraFlipper.Common.Global
{
	public class FlipperAccessory : ModItem
	{
		public virtual int GetElement()
		{
			//1火2水3雷4风5光6暗7全属0错误返回
			return 0;
		}
	}
}
