using Microsoft.Xna.Framework;
using System;
using TerraFlipper.Common.Global;
using TerraFlipper.Common.Player;
using TerraFlipper.Content.DamageClasses;
using TerraFlipper.Content.ProjectTiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerraFlipper.Content.Weapons
{
	public class LiuShuiRenJian : FlipperWeapons
	{
		// The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.TerraFlipper.hjson file.

		public override void SetDefaults()
		{
			Random random = new Random();
			Item.damage = 65;
			Item.DamageType = ModContent.GetInstance<ZhiJiDamage>();
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
		public override void HoldItem(Player player)
		{
			player.GetCritChance(ModContent.GetInstance<GongRenDamage>()) += 0.06f;
			if (Fever.IsFever())
			{
				player.GetCritChance(ModContent.GetInstance<GongRenDamage>()) += 0.1f;
			}
		}
		//被动



	}
}