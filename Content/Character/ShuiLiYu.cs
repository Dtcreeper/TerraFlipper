using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraFlipper.Common.Global;
using TerraFlipper.Content.DamageClasses;
using TerraFlipper.Content.ProjectTiles;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria;
using TerraFlipper.Common.Player;
using Microsoft.Xna.Framework;
using TerraFlipper.Common.Buffs;

namespace TerraFlipper.Content.Character
{
	public class ShuiLiYu : FlipperAccessory
	{
		// Fever状态中给予自身200攻刃100PF伤害。主动技给予自身20PF几率持续20秒。
		public static readonly int Gongren = 200;
		public static readonly int PF = 100;
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(Gongren, PF);

		public override void SetDefaults()
		{
			Item.width = 112;
			Item.height = 96;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (Fever.IsFever())
			{
				player.GetDamage(ModContent.GetInstance<GongRenDamage>()) += Gongren/100f;
				player.GetDamage(ModContent.GetInstance<PFDamage>()) += PF/100f;
			}
		}
		public static string ShuXing()
		{
			return "Shui";
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
			player.AddBuff(ModContent.BuffType<PF_20>(), 1200);
			Projectile.NewProjectile(player.GetSource_FromThis(), player.position, Vector2.One, ModContent.ProjectileType<LiYuJiNeng>(), 0, 0);
		}
		public override int GetElement()
		{
			return 2;
		}
		public override string ToString()
		{
			return "Lei Mu";
		}
	}
}
