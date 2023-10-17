using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraFlipper.Content.DamageClasses;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using TerraFlipper.Common.Global;

namespace TerraFlipper.Content.Weapons
{
	public  class Protostar_Harpe:FlipperWeapons
	{
		//技伤+100
		public static int JiShang = 100;
		public override void SetDefaults()
		{
			Item.damage = 10;
			Item.DamageType = ModContent.GetInstance<ZhiJiDamage>();
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 28;
			Item.useAnimation = 28;
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
			player.GetDamage(ModContent.GetInstance<JiShangDamage>()) += JiShang / 100f;
		}
	}
}
