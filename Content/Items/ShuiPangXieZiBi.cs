using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerraFlipper.Content.Items
{
	internal class ShuiPangXieZiBi:ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 44; // The item texture's width
			Item.height = 44; // The item texture's height
			Item.rare = ItemRarityID.Purple;
			Item.value = 5000;
			Item.maxStack = 1; // The item's max stack value
		}
		public override void AddRecipes()
		{
			CreateRecipe(1)
				.AddIngredient(ModContent.GetInstance<ShuiPangXieJinBi>(), 10)
				.AddIngredient(ItemID.Seagull)
				.AddTile(TileID.WorkBenches)
				.Register();
		}

	}
}
