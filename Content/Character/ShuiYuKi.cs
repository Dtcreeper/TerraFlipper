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
	public class ShuiYuKi : FlipperAccessory
	{
		// 浑身给予160技伤，主动给予15s120技伤8%奶（护盾）
		public static readonly int Jishang1 = 160;
		public static readonly int Jishang2 = 120;
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(Jishang1 , Jishang2);

		public override void SetDefaults()
		{
			Item.width = 96;
			Item.height = 96;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(ModContent.GetInstance<JiShangDamage>())+=(int)(Jishang1/100f*player.statLife / player.statLifeMax2);
			Main.LocalPlayer.statLifeMax2 += 1000;
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
			player.AddBuff(ModContent.BuffType<JiShang_120>(), 900);
			Projectile.NewProjectile(player.GetSource_FromThis(), player.position, Vector2.One, ModContent.ProjectileType<YuKiJiNeng>(), 0, 0);
		}
		public override int GetElement()
		{
			return 2;
		}
	}
}
