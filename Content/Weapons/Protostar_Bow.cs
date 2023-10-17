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
	public class Protostar_Bow : FlipperWeapons
	{


		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.PalmWoodBow);
			Item.DamageType = ModContent.GetInstance<PFDamage>();
			Item.damage = 10;
			Item.scale = 1.5f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.IronBar, 10);
			recipe.AddTile(TileID.Anvils);
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
				Projectile.NewProjectile(source, position, velocity * PFDamage.PF2S, ModContent.ProjectileType<ColorfulStar_Shui>(), (int)(damage * GongRenDamage.JiaCheng() * PFDamage.PF2D * PFDamage.JiaCheng() * ShuiDamage.JiaCheng()), knockback);
			}
			else if (r <= crit)
			{
				Projectile.NewProjectile(source, position, velocity * PFDamage.PF1D, ModContent.ProjectileType<GoldStar_Shui>(), (int)(damage * GongRenDamage.JiaCheng() * PFDamage.PF1D * PFDamage.JiaCheng() * ShuiDamage.JiaCheng()), knockback);
			}
			else
			{
				Projectile.NewProjectile(source, position, velocity, type, (int)(damage * PFDamage.JiaCheng() * GongRenDamage.JiaCheng() * ShuiDamage.JiaCheng()), knockback);
			}
			return false;
		}

	}
}

