using TerraFlipper.Content.DamageClasses;
using Terraria.Localization;
using Terraria.ModLoader;

namespace TerraFlipper.Common.Buffs
{
	public class JiShang_120 : ModBuff
	{
		public static readonly float JiShang = 1.2f;
		public override LocalizedText Description => base.Description.WithFormatArgs(JiShang);
		public override void Update(Terraria.Player player, ref int buffIndex)
		{
			player.GetDamage(ModContent.GetInstance<JiShangDamage>()) += JiShang;//属性修改
		}
		public override bool ReApply(Terraria.Player player, int time, int buffIndex)
		{
			return false;
		}
	}
}