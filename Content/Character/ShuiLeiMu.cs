﻿using Microsoft.Xna.Framework;
using TerraFlipper.Common.Global;
using TerraFlipper.Common.Key;
using TerraFlipper.Common.Player;
using TerraFlipper.Content.DamageClasses;
using TerraFlipper.Content.ProjectTiles;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TerraFlipper.Content.Character
{
	public class ShuiLeiMu : FlipperAccessory
	{
		// By declaring these here, changing the values will alter the effect, and the tooltip
		public static readonly int Gongren = 100;
		public static readonly int Jishang = 150;

		// Insert the modifier values into the tooltip localization. More info on this approach can be found on the wiki: https://github.com/tModLoader/tModLoader/wiki/Localization#binding-values-to-localizations
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(Gongren, Jishang);

		public override void SetDefaults()
		{
			Item.width = 88;
			Item.height = 96;
			Item.accessory = true;

		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			//技伤+150（浑身），攻刃+100（浑身），
			Main.LocalPlayer.statLifeMax2 += 500;
			float hp = Main.LocalPlayer.statLife / Main.LocalPlayer.statLifeMax2;
			player.GetDamage(ModContent.GetInstance<GongRenDamage>()) += Gongren * hp / 100f;
			player.GetDamage(ModContent.GetInstance<JiShangDamage>()) += Jishang * hp / 100f;
			

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
			//28倍率
			int beilv = 28;
			Vector2 p = Main.MouseScreen + Main.screenPosition - player.position;
			Vector2 velocity = 20f * p / p.Length();
			int damage = (int)(player.GetTotalDamage(ModContent.GetInstance<ShuiDamage>()).ApplyTo(JiNeng1.GongJi*beilv) * GongRenDamage.JiaCheng()*JiShangDamage.JiaCheng());
			Projectile.NewProjectile(player.GetSource_FromThis(), player.position, velocity, ModContent.ProjectileType<LeiMuJiNeng>(), damage, 0);
		}
		public override int GetElement()
		{
			return 2;
		}
	}
}