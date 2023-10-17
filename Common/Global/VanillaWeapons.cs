using Microsoft.Xna.Framework;
using TerraFlipper.Content.DamageClasses;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace TerraFlipper.Common.Global
{
	internal class VanillaWeapons : GlobalItem
	{
		public override void SetDefaults(Item entity)
		{
			//原版伤害转换
			if (entity.DamageType == DamageClass.Melee)
			{
				entity.DamageType = ModContent.GetInstance<ZhiJiDamage>();
			}
			if (entity.DamageType == DamageClass.MeleeNoSpeed)
			{
				entity.DamageType = ModContent.GetInstance<PFDamage>();
			}
			if (entity.DamageType == DamageClass.Magic)
			{
				entity.DamageType = ModContent.GetInstance<JiShangDamage>();
			}
			if (entity.DamageType == DamageClass.MagicSummonHybrid)
			{
				entity.DamageType = ModContent.GetInstance<JiShangDamage>();
			}
			if (entity.DamageType == DamageClass.Ranged)
			{
				entity.DamageType = ModContent.GetInstance<PFDamage>();
			}
			if (entity.DamageType == DamageClass.Summon)
			{
				entity.DamageType = ModContent.GetInstance<ZhiJiDamage>();
			}
			if (entity.DamageType == DamageClass.SummonMeleeSpeed)
			{
				entity.DamageType = ModContent.GetInstance<ZhiJiDamage>();
			}
		}
		public override void ModifyHitNPC(Item item, Terraria.Player player, NPC target, ref NPC.HitModifiers modifiers)
		{
			
			modifiers.FinalDamage *= GongRenDamage.JiaCheng();//近战修改
			

		}
		public override void ModifyShootStats(Item item, Terraria.Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			
			damage = (int)(damage * GongRenDamage.JiaCheng());
			
			//Projectile.NewProjectile(player.GetSource_FromThis(), position, velocity, type, damage, knockback);

		}
	}
}
