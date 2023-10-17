using Microsoft.Xna.Framework;
using System;
using TerraFlipper.Common.Global;
using TerraFlipper.Content.DamageClasses;
using TerraFlipper.Content.ProjectTiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerraFlipper.Content.Weapons
{
	public class ShuiShiLongShu : FlipperWeapons
	{
		// The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.TerraFlipper.hjson file.

		public override void SetDefaults()
		{
			Item.damage = 4;
			Item.DamageType = ModContent.GetInstance<ZhiJiDamage>();
			Item.width = 34;
			Item.height = 40;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 6;
			Item.value = 50000;
			Item.rare = ItemRarityID.Green;
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
			double crit = player.GetCritChance(ModContent.GetInstance<GongRenDamage>());
			Random random = new Random();
			double r = random.NextDouble();
			damage = player.GetWeaponDamage(this.Entity);
			if (r <= crit / (4 + crit))
			{
				Projectile.NewProjectile(source, position, (velocity + Main.rand.NextVector2CircularEdge(1, 1)) * PFDamage.PF2S, ModContent.ProjectileType<ColorfulStar_Shui>(), (int)(damage * PFDamage.PF2D * PFDamage.JiaCheng() * ShuiDamage.JiaCheng()), knockback);
				Projectile.NewProjectile(source, position, (velocity + Main.rand.NextVector2CircularEdge(1, 1)) * PFDamage.PF2S, ModContent.ProjectileType<ColorfulStar_Shui>(), (int)(damage * PFDamage.PF2D * PFDamage.JiaCheng() * ShuiDamage.JiaCheng()), knockback);
			}
			else if (r <= crit)
			{
				Projectile.NewProjectile(source, position, (velocity + Main.rand.NextVector2CircularEdge(1, 1)) * PFDamage.PF1D, ModContent.ProjectileType<GoldStar_Shui>(), (int)(damage * PFDamage.PF1D * PFDamage.JiaCheng() * ShuiDamage.JiaCheng()), knockback);
				Projectile.NewProjectile(source, position, (velocity + Main.rand.NextVector2CircularEdge(1, 1)) * PFDamage.PF1D, ModContent.ProjectileType<GoldStar_Shui>(), (int)(damage * PFDamage.PF1D * PFDamage.JiaCheng() * ShuiDamage.JiaCheng()), knockback);
			}
			else
			{
				Projectile.NewProjectile(source, position, velocity + Main.rand.NextVector2CircularEdge(1, 1), type, (int)(damage * ShuiDamage.JiaCheng()), knockback);
				Projectile.NewProjectile(source, position, velocity + Main.rand.NextVector2CircularEdge(1, 1), type, (int)(damage * ShuiDamage.JiaCheng()), knockback);
			}
			return false;
		}
		//被动
		public override void HoldItem(Player player)
		{
			player.GetDamage(ModContent.GetInstance<GongRenDamage>()) += 1.5f * player.statLife / player.statLifeMax2;
		}

	}
}