using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerraFlipper.Content.Items
{
	internal class ShuiPangXieJinBi : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 44; // The item texture's width
			Item.height = 44; // The item texture's height
			Item.rare = ItemRarityID.Green;
			Item.value = 500;
			Item.maxStack = 9999; // The item's max stack value
		}

	}
}
