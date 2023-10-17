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
	public class JiBanJian : ModItem
	{
		//160攻刃 40pf几率 100pf刃
		public int GongRen = 160;
		public int PFC = 40;
		public int PF = 100;

		public override void SetDefaults()
		{
			Item.damage = 195;
			Item.DamageType = ModContent.GetInstance<ZhiJiDamage>();
			Item.width = 44;
			Item.height = 44;
			Item.useTime = 14;
			Item.useAnimation = 14;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = 20000000;
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.crit = 0;
			Item.shoot = ModContent.ProjectileType<GrayStar_Shui>();
			Item.shootSpeed = 5f;
			Item.attackSpeedOnlyAffectsWeaponAnimation = false;

		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 10);
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
		//增加攻刃
		public override void HoldItem(Player player)
		{
			player.GetDamage(ModContent.GetInstance<GongRenDamage>()) += GongRen / 100f;
			player.GetDamage(ModContent.GetInstance<PFDamage>()) += PF / 100f;
			player.GetCritChance(ModContent.GetInstance<GongRenDamage>()) += PFC / 100f;
		}




	}
}