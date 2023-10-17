using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraFlipper.Common.Buffs;
using TerraFlipper.Content.DamageClasses;
using TerraFlipper.Content.ProjectTiles;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria;
using TerraFlipper.Common.Global;

namespace TerraFlipper.Content.Accessories
{
	public class Protostar_Gauntlet:FlipperAccessory
	{
		// 直击刃+130
		public static readonly int ZhiJi = 130;
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(ZhiJi);

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(ModContent.GetInstance<ZhiJiDamage>()) += ZhiJi / 100f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.IronBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}

		public override int GetElement()
		{
			return 0;
		}
	}
}
