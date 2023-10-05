using TerraFlipper.Content.DamageClasses;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TerraFlipper.Common.Buffs
{
	public class PF_20 : ModBuff
	{
		public static readonly float  PF = 0.2f;
		public override LocalizedText Description => base.Description.WithFormatArgs(PF);
		public override void Update(Terraria.Player player, ref int buffIndex)
		{
			player.GetCritChance(ModContent.GetInstance<BounceDamage>()) += PF;//属性修改
		}
	}
}