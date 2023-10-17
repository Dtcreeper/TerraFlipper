using TerraFlipper.Content.DamageClasses;
using Terraria;
using Terraria.ModLoader;

namespace TerraFlipper.Common.Global
{
	public class FlipperWeapons : ModItem
	{
		public override void ModifyHitNPC(Terraria.Player player, NPC target, ref NPC.HitModifiers modifiers)
		{
			//modifiers.FinalDamage *= GongRenDamage.JiaCheng();
		}
	}
}
