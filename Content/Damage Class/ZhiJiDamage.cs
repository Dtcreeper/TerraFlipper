using Terraria;
using Terraria.ModLoader;

namespace TerraFlipper.Content.DamageClasses
{
	public class ZhiJiDamage : DamageClass
	{
		// This is an example damage class designed to demonstrate all the current functionality of the feature and explain how to create one of your own, should you need one.
		// For information about how to apply stat bonuses to specific damage classes, please instead refer to ExampleMod/Content/Items/Accessories/ExampleStatBonusAccessory.
		public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
		{
			return StatInheritanceData.None;

			
		}

		public override bool GetEffectInheritance(DamageClass damageClass)
		{
			//收到其他伤害类型特效
			// This method allows you to make your damage class benefit from and be able to activate other classes' effects (e.g. Spectre bolts, Magma Stone) based on what returns true.
			// Note that unlike our stat inheritance methods up above, you do not need to account for universal bonuses in this method.
			// For this example, we'll make our class able to activate melee- and magic-specifically effects.

			return false;
		}

		public override void SetDefaultStats(Player player)
		{
			// This method lets you set default statistical modifiers for your example damage class.
			// Here, we'll make our example damage class have more critical strike chance and armor penetration than normal.
			//player.GetCritChance<BounceDamage>() += 4;
			//player.GetArmorPenetration<BounceDamage>() += 10;
			// These sorts of modifiers also exist for damage (GetDamage), knockback (GetKnockback), and attack speed (GetAttackSpeed).
			// You'll see these used all around in referencce to vanilla classes and our example class here. Familiarize yourself with them.
		}

		// This property lets you decide whether or not your damage class can use standard critical strike calculations.
		// Note that setting it to false will also prevent the critical strike chance tooltip line from being shown.
		// This prevention will overrule anything set by ShowStatTooltipLine, so be careful!
		public override bool UseStandardCritCalcs => false;

		public override bool ShowStatTooltipLine(Player player, string lineName)
		{
			// This method lets you prevent certain common statistical tooltip lines from appearing on items associated with this DamageClass.
			// The four line names you can use are "Damage", "CritChance", "Speed", and "Knockback". All four cases default to true, and thus will be shown. For example...
			//if (lineName == "Speed")
			//    return false;

			return true;
			// PLEASE BE AWARE that this hook will NOT be here forever; only until an upcoming revamp to tooltips as a whole comes around.
			// Once this happens, a better, more versatile explanation of how to pull this off will be showcased, and this hook will be removed.
		}
		public static float JiaCheng()
		{
			return Main.LocalPlayer.GetTotalDamage(ModContent.GetInstance<ZhiJiDamage>()).ApplyTo(1000) / 1000f;
		}
	}
}
