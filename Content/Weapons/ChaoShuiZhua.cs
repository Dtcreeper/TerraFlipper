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
	public class ChaoShuiZhua : FlipperWeapons
	{
		public override void SetDefaults()
		{
			Item.damage = 35;
			Item.DamageType = ModContent.GetInstance<ZhiJiDamage>();
			Item.width = 34;
			Item.height = 40;
			Item.useTime = 25;
			Item.useAnimation = 25;
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
				Projectile.NewProjectile(source, position, velocity * PFDamage.PF2S, ModContent.ProjectileType<ColorfulStar_Shui>(), (int)(damage * PFDamage.PF2D * PFDamage.JiaCheng() * ShuiDamage.JiaCheng() / ZhiJiDamage.JiaCheng()), knockback);
			}
			else if (r <= crit)
			{
				Projectile.NewProjectile(source, position, velocity * PFDamage.PF1D, ModContent.ProjectileType<GoldStar_Shui>(), (int)(damage * PFDamage.PF1D * PFDamage.JiaCheng() * ShuiDamage.JiaCheng() / ZhiJiDamage.JiaCheng()), knockback);
			}
			else
			{
				Projectile.NewProjectile(source, position, velocity, type, (int)(damage * ShuiDamage.JiaCheng()), knockback); ;
			}
			return false;
		}
		//被动
		public override void HoldItem(Player player)
		{
			//每有一个水属性角色+75攻刃
			int a = Counter.ShuiJueSeShuLiang();
			player.GetDamage(ModContent.GetInstance<GongRenDamage>()) += a * 0.75f;
		}

	}
}