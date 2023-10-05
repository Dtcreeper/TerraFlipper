using Microsoft.Xna.Framework;
using System;
using TerraFlipper.Common.Player;
using TerraFlipper.Content.DamageClasses;
using TerraFlipper.Content.ProjectTiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerraFlipper.Content.Weapons
{
	public class LiuShuiRenJian : ModItem
	{
		// The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.TerraFlipper.hjson file.

		public override void SetDefaults()
		{
			Random random = new Random();
			Item.damage = 65;
			Item.DamageType = ModContent.GetInstance<BounceDamage>();
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = 200000;
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.crit = -4;
			Item.shoot = ModContent.ProjectileType<GrayStar>();
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
			double crit = 0;
			Random random = new Random();
			double r = random.NextDouble();
			//判断强力弹射
			if (r <= crit / (4 + crit))
			{
				Projectile.NewProjectile(source, position, velocity * 5, ModContent.ProjectileType<ColorfulStar>(), (int)(damage * 10), knockback);
			}
			else if (r <= crit)
			{
				Projectile.NewProjectile(source, position, velocity * 2, ModContent.ProjectileType<GoldStar>(), (int)(damage * 4), knockback);
			}
			else
			{
				Projectile.NewProjectile(source, position, velocity, type, damage, knockback); ;
			}
			return false;
		}
		public override void HoldItem(Player player)
		{
			player.GetCritChance(ModContent.GetInstance<BounceDamage>()) += 0.06f;
			if (Fever.IsFever())
			{
				player.GetCritChance(ModContent.GetInstance<BounceDamage>()) += 0.1f;
			}
		}
		//被动



	}
}