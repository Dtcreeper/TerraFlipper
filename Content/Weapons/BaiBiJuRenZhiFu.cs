using Microsoft.Xna.Framework;
using TerraFlipper.Content.DamageClasses;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerraFlipper.Content.Weapons
{
    public class BaiBiJuRenZhiFu : ModItem
    {
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.TerraFlipper.hjson file.

        public override void SetDefaults()
        {
            Item.damage = 50;
            Item.DamageType = ModContent.GetInstance<BounceDamage>();
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 50;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.value = 100000;
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.crit = 1;
            Item.shoot = ProjectileID.BeachBall;
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
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }


    }
}