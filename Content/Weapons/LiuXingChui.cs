using TerraFlipper;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TerraFlipper.Content.DamageClasses;
using System;
using TerraFlipper.Content.ProjectTiles;
using Terraria.DataStructures;
using TerraFlipper.Common.Global;

namespace TerraFlipper.Content.Weapons
{
	// ExampleFlail and ExampleFlailProjectile show the minimum amount of code needed for a flail using the existing vanilla code and behavior. ExampleAdvancedFlail and ExampleAdvancedFlailProjectile need to be consulted if more advanced customization is desired, or if you want to learn more advanced modding techniques.
	// ExampleFlail is a copy of the Sunfury flail weapon.
	internal class LiuXingChui : ModItem
	{
		public override void SetStaticDefaults()
		{
			// This line will make the damage shown in the tooltip twice the actual Item.damage. This multiplier is used to adjust for the dynamic damage capabilities of the projectile.
			// When thrown directly at enemies, the flail projectile will deal double Item.damage, matching the tooltip, but deals normal damage in other modes.
			ItemID.Sets.ToolTipDamageMultiplier[Type] = 2f;
		}

		public override void SetDefaults()
		{
			// These default values aside from Item.shoot match the Sunfury values, feel free to tweak them.
			Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
			Item.useAnimation = 45; // The item's use time in ticks (60 ticks == 1 second.)
			Item.useTime = 45; // The item's use time in ticks (60 ticks == 1 second.)
			Item.knockBack = 6.75f; // The knockback of your flail, this is dynamically adjusted in the projectile code.
			Item.width = 30; // Hitbox width of the item.
			Item.height = 10; // Hitbox height of the item.
			Item.damage = 20; // The damage of your flail, this is dynamically adjusted in the projectile code.
			Item.crit = 0; // Critical damage chance %
			Item.scale = 1.1f;
			Item.noUseGraphic = true; // This makes sure the item does not get shown when the player swings his hand
			Item.shoot = ModContent.ProjectileType<LiuXingChuiPT>(); // The flail projectile
			Item.shootSpeed = 12f; // The speed of the projectile measured in pixels per frame.
			Item.UseSound = SoundID.Item1; // The sound that this item makes when used
			Item.rare = ItemRarityID.Orange; // The color of the name of your item
			Item.value = Item.sellPrice(gold: 0, silver: 50); // Sells for 2 gold 50 silver
			Item.DamageType = ModContent.GetInstance<GongRenDamage>(); // Deals melee damage
			Item.channel = true;
			Item.noMelee = true; // This makes sure the item does not deal damage from the swinging animation
		}

		public override Color? GetAlpha(Color lightColor)
		{
			// Aside from SetDefaults, when making a copy of a vanilla weapon you may have to hunt down other bits of code. This code makes the item draw in full brightness when dropped.
			return Color.White;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			damage = player.GetWeaponDamage(this.Entity);
			Projectile.NewProjectile(source, position, velocity, type, (int)(damage * ZhiJiDamage.JiaCheng() * ShuiDamage.JiaCheng()), knockback);
			return false;
		}
		//被动
		public override void HoldItem(Player player)
		{
			//浑身+175技伤
			float a = player.statLife/player.statLifeMax2;
			player.GetDamage(ModContent.GetInstance<JiShangDamage>()) += a * 1.75f;
		}
	}
}