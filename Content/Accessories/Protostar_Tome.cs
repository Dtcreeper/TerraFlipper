using TerraFlipper.Common.Global;
using TerraFlipper.Content.DamageClasses;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TerraFlipper.Content.Accessories
{
	public class Protostar_Tome : FlipperAccessory
	{
		// 30攻刃
		public static readonly int GongRen = 30;
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(GongRen);

		public override void SetDefaults()
		{
			Item.width = 36;
			Item.height = 40;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(ModContent.GetInstance<GongRenDamage>()) += GongRen / 100f;
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
