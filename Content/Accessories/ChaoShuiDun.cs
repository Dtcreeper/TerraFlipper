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
	public class ChaoShuiDun : FlipperAccessory
	{
		// 每装备一个水属性角色，最大hp*1.2&防御+20
		public static readonly int HP = 20;
		public static readonly int FangYu = 20;
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(HP, FangYu);

		public override void SetDefaults()
		{
			Item.width = 36;
			Item.height = 42;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			int a = Counter.ShuiJueSeShuLiang();
			player.statLifeMax2 =(int)(Math.Pow((HP/100f+1) , a)*player.statLifeMax2);
			player.statDefense += FangYu * a;
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
