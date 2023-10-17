using TerraFlipper.Common.Key;
using TerraFlipper.Content.Character;
using Terraria.GameInput;
using Terraria.ModLoader;

namespace TerraFlipper.Common.Player
{
	public class JiNeng1 : ModPlayer
	{
		public static int GongJi = 100;
		public override void ProcessTriggers(TriggersSet triggersSet)
		{
			if (Key1.JiNeng1.JustPressed)
			{
				//此处进行装备栏1装备物品的判断
				//未知原因会加括号
				//不清楚优化好不好
				//统一使用Class.FangJiNeng()
				if (Player.armor[3].ToString().Contains("Shui Lei Mu"))
				{
					ShuiLeiMu.FangJiNeng(Player);
				}
				else if (Player.armor[3].ToString().Contains("Shui Li Yu"))
				{
					ShuiLiYu.FangJiNeng(Player);
				}
				else if (Player.armor[3].ToString().Contains("Shui Yu Ki"))
				{
					ShuiYuKi.FangJiNeng(Player);
				}
				else if (Player.armor[3].ToString().Contains("Shui Da Nai"))
				{
					ShuiDaNai.FangJiNeng(Player);
				}
				else if (Player.armor[3].ToString().Contains("Shui Long Quan"))
				{
					ShuiLongQuan.FangJiNeng(Player);
				}
			}
		}

	}
}
