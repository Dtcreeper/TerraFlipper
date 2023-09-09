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
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.TerraFlipper.hjson file.

        public override void SetDefaults()
        {
            Item.damage = 195;
            Item.DamageType = ModContent.GetInstance<BounceDamage>();
            Item.width = 44;
            Item.height = 44;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.value = 20000000;
            Item.rare = ItemRarityID.LightRed;
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
            recipe.AddIngredient(ItemID.DirtBlock, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            double crit = player.GetCritChance(ModContent.GetInstance<BounceDamage>());
            Random random = new Random();
            double r = random.NextDouble();

            int ndamage = (int)(damage * 2.6);//攻击力+160%
            if (r <= crit / (4 + crit))
            {
                Projectile.NewProjectile(source, position, velocity * 5, ModContent.ProjectileType<ColorfulStar>(), (int)(ndamage * 10), knockback);
            }
            else if (r <= crit)
            {
                Projectile.NewProjectile(source, position, velocity * 2, ModContent.ProjectileType<GoldStar>(), (int)(ndamage * 4), knockback);
            }
            else
            {
                Projectile.NewProjectile(source, position, velocity, type, ndamage, knockback); ;
            }
            return false;

        }


    }
}