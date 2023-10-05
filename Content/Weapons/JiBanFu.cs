using Microsoft.Xna.Framework;
using System;
using TerraFlipper.Content.DamageClasses;
using TerraFlipper.Content.ProjectTiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerraFlipper.Content.Weapons
{
	public class JiBanFu : ModItem
	{
		// The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.TerraFlipper.hjson file.

		public override void SetDefaults()
		{
			Random random = new Random();
			Item.damage = 415;
			Item.DamageType = ModContent.GetInstance<BounceDamage>();
			Item.width = 0;
			Item.height = 0;
			Item.useTime = 70;
			Item.useAnimation = 70;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = 2000000;
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.crit = -4;
			Item.shoot = ModContent.ProjectileType<GrayStar_Shui>();
			Item.shootSpeed = 5f;
			Item.attackSpeedOnlyAffectsWeaponAnimation = false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{

			double crit = player.GetCritChance(ModContent.GetInstance<BounceDamage>());
			Random random = new Random();
			double r = random.NextDouble();
			//判断强力弹射
			if (r <= crit / (PFDamage.PFChance + crit))
			{
				Projectile.NewProjectile(source, position, velocity * PFDamage.PF2S, ModContent.ProjectileType<ColorfulStar_Shui>(), (int)(damage * PFDamage.PF2D), knockback);
			}
			else if (r <= crit)
			{
				Projectile.NewProjectile(source, position, velocity * PFDamage.PF1S, ModContent.ProjectileType<GoldStar_Shui>(), (int)(damage * PFDamage.PF1D), knockback);
			}
			else
			{
				Projectile.NewProjectile(source, position, velocity, type, damage, knockback); ;
			}
			return false;
		}
		//技伤增加
		public override void HoldItem(Player player)
		{
			player.GetDamage(ModContent.GetInstance<JiShangDamage>()) += 2.8f;
		}


	}
}