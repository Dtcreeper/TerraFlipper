using Microsoft.Xna.Framework;
using System;
using TerraFlipper.Common.Buffs;
using TerraFlipper.Common.Global;
using TerraFlipper.Content.DamageClasses;
using TerraFlipper.Content.ProjectTiles;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TerraFlipper.Content.Accessories
{
	public class Protostar_Rifle : FlipperAccessory
	{
		// pf概率+10，pf伤害+20
		public static readonly int PFC = 10;
		public static readonly int PF = 20;
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(PFC, PF);

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetCritChance(ModContent.GetInstance<GongRenDamage>()) += PFC / 100f;
			player.GetDamage(ModContent.GetInstance<PFDamage>()) += PF / 100f;
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
