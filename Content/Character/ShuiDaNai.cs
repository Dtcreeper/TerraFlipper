using Microsoft.Xna.Framework;
using TerraFlipper.Common.Buffs;
using TerraFlipper.Common.Global;
using TerraFlipper.Content.DamageClasses;
using TerraFlipper.Content.ProjectTiles;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TerraFlipper.Content.Character
{
	public class ShuiDaNai : FlipperAccessory
	{
		// 主动100攻刃15s+50攻刃15s，被动按攻刃灯60攻刃/5灯
		public static readonly int GongRen1 = 100;
		public static readonly int GongRen2 = 50;
		public static readonly int GongRen3 = 60;
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(GongRen1, GongRen2, GongRen3);

		public override void SetDefaults()
		{
			
			Item.width = 96;
			Item.height = 96;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			Main.LocalPlayer.statLifeMax2 += 500;
			int[] t = player.buffType;
			int n = Counter.CounterBuffs(t);
			player.GetDamage(ModContent.GetInstance<GongRenDamage>()) += (int)(GongRen3 * n / 5 / 100f);
			
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
		public static void FangJiNeng(Player player)
		{
			player.AddBuff(ModContent.BuffType<GongRen_100_1>(), 900);
			player.AddBuff(ModContent.BuffType<GongRen_50_1>(), 900);
			Projectile.NewProjectile(player.GetSource_FromThis(), player.position, Vector2.One, ModContent.ProjectileType<ShuiDaNaiJiNeng>(), 0, 0);
		}
		public override int GetElement()
		{
			return 2;
		}
	}
}
