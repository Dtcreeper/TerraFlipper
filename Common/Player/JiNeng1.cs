using System;
using TerraFlipper.Common.Key;
using TerraFlipper.Content.Character;
using TerraFlipper.Content.DamageClasses;
using TerraFlipper.Content.ProjectTiles;
using Terraria;
using Terraria.GameInput;
using Terraria.ModLoader;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace TerraFlipper.Common.Player
{
	public class JiNeng1 : ModPlayer
	{
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
				if (Player.armor[3].ToString().Contains("Shui Li Yu"))
				{
					ShuiLiYu.FangJiNeng(Player);
				}
			}
		}

	}
}
