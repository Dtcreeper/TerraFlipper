using TerraFlipper.Common.Buffs;
using Terraria;
using Terraria.ModLoader;

namespace TerraFlipper.Common.Global
{
	internal static class Counter
	{
		public static int[] buffs = new int[2] {
			ModContent.BuffType<GongRen_100_1>(),
			ModContent.BuffType<GongRen_50_1>()
		};
		public static int CounterBuffs(int[] t)
		{
			int n = 0;
			for (int i = 0; i < t.Length; i++)
			{
				for (int j = 0; j < buffs.Length; j++)
				{
					if (t[i] == buffs[j])
					{
						n++;
						break;
					}
				}
			}
			
			return n;
		}
		public static int ShuiJueSeShuLiang()
		{
			Terraria.Player player = Main.LocalPlayer;
			int a = 0;
			if (player.armor[3].ToString().Contains("Shui"))
			{
				a += 1;
			}
			if (player.armor[4].ToString().Contains("Shui"))
			{
				a += 1;
			}
			if (player.armor[5].ToString().Contains("Shui"))
			{
				a += 1;
			}
			Main.NewText("a=" + a);
			return a;
		}

	}
}
