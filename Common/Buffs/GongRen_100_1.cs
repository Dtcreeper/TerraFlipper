using TerraFlipper.Content.DamageClasses;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TerraFlipper.Common.Buffs
{
	public class GongRen_100_1 : ModBuff
	{
		public static readonly float GongRen = 1f;
		public override LocalizedText Description => base.Description.WithFormatArgs(GongRen);
		public override void Update(Terraria.Player player, ref int buffIndex)
		{
			player.GetDamage(ModContent.GetInstance<GongRenDamage>()) += GongRen;//属性修改
		}
		public override bool ReApply(Terraria.Player player, int time, int buffIndex)
		{
			return false;
		}
	}
}