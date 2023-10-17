using Microsoft.Xna.Framework;
using TerraFlipper.Common.Global;
using TerraFlipper.Common.Player;
using TerraFlipper.Content.DamageClasses;
using TerraFlipper.Content.ProjectTiles;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TerraFlipper.Content.Character
{
	public class ShuiLongQuan : FlipperAccessory
	{
		// 浑身给予自己300攻刃，100技伤
		public static readonly int Gongren = 300;
		public static readonly int JiShang = 100;
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(Gongren, JiShang);

		public override void SetDefaults()
		{
			Item.width = 88;
			Item.height = 96;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			Main.LocalPlayer.statLifeMax2 += 500;
			float h = player.statLife / player.statLifeMax2;
			player.GetDamage(ModContent.GetInstance<GongRenDamage>()) += h * Gongren / 100f;
			player.GetDamage(ModContent.GetInstance<JiShangDamage>()) += h * JiShang / 100f;
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
			if (player.HasMinionAttackTargetNPC)
			{
				NPC npc = Main.npc[player.MinionAttackTargetNPC];
				int beilv = 33;
				int d = (int)(player.GetTotalDamage(ModContent.GetInstance<ShuiDamage>()).ApplyTo(JiNeng1.GongJi * beilv) * GongRenDamage.JiaCheng() * JiShangDamage.JiaCheng());
				Projectile.NewProjectile(player.GetSource_FromThis(), npc.position, Vector2.Zero, ModContent.ProjectileType<LongQuanJiNeng>(), d, 0);
			}
			else
			{
				int beilv = 33;
				int d = (int)(player.GetTotalDamage(ModContent.GetInstance<ShuiDamage>()).ApplyTo(JiNeng1.GongJi * beilv) * GongRenDamage.JiaCheng() * JiShangDamage.JiaCheng());
				Projectile.NewProjectile(player.GetSource_FromThis(), Main.MouseWorld, Vector2.Zero, ModContent.ProjectileType<LongQuanJiNeng>(), d, 0);
			}
		}
		public override int GetElement()
		{
			return 2;
		}

	}
}
