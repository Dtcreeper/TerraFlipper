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
	public class Protostar_Belt : FlipperAccessory
	{
		// 40技伤
		public static readonly int JiShang = 40;
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(JiShang);

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(ModContent.GetInstance<JiShangDamage>()) += JiShang / 100f;
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
