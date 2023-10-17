using TerraFlipper.Common.Global;
using TerraFlipper.Content.DamageClasses;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerraFlipper.Content.Weapons
{
	public class Protostar_Bident : FlipperWeapons
	{
		//攻刃+70
		public static int GongRen = 70;
		public override void SetDefaults()
		{
			Item.damage = 15;
			Item.DamageType = ModContent.GetInstance<ZhiJiDamage>();
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = 5000;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.crit = 0;
			//Item.shoot = ModContent.ProjectileType<GrayStar_Shui>();
			//Item.shootSpeed = 5f;
			Item.attackSpeedOnlyAffectsWeaponAnimation = false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.IronBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}


		//被动
		public override void HoldItem(Player player)
		{
			player.GetDamage(ModContent.GetInstance<GongRenDamage>()) += GongRen / 100f;
		}
		


	}
}
