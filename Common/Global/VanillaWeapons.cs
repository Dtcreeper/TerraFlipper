using TerraFlipper.Content.DamageClasses;
using Terraria;
using Terraria.ModLoader;

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
	}
}
