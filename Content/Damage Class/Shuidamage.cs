using Terraria;
using Terraria.ModLoader;

namespace TerraFlipper.Content.DamageClasses
{
	public class ShuiDamage : DamageClass
	{
		// This is an example damage class designed to demonstrate all the current functionality of the feature and explain how to create one of your own, should you need one.
		// For information about how to apply stat bonuses to specific damage classes, please instead refer to ExampleMod/Content/Items/Accessories/ExampleStatBonusAccessory.
		public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
		{
			return StatInheritanceData.None;
		}

		public override bool GetEffectInheritance(DamageClass damageClass)
		{
			
			if (damageClass == DamageClass.Melee)
				return true;
			if (damageClass == DamageClass.Ranged)
				return true;

			return false;
		}

		public override void SetDefaultStats(Player player)
		{
			
		}

		
		public override bool UseStandardCritCalcs => false;

		public override bool ShowStatTooltipLine(Player player, string lineName)
		{
			

			return true;
			
		}
		public static float JiaCheng()
		{
			return Main.LocalPlayer.GetTotalDamage(ModContent.GetInstance<ShuiDamage>()).ApplyTo(1000) / 1000f;
		}
	}
}
