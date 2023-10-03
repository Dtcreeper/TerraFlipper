using Microsoft.Xna.Framework;
using System.Numerics;
using TerraFlipper.Common.Key;
using TerraFlipper.Content.DamageClasses;
using TerraFlipper.Content.ProjectTiles;
using TerraFlipper.Content.Weapons;
using Terraria;
using Terraria.GameInput;
using Terraria.ModLoader;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace TerraFlipper.Common.Player
{
	// See Common/Systems/KeybindSystem for keybind registration.
	public class JiNeng1 : ModPlayer
	{
		public override void ProcessTriggers(TriggersSet triggersSet)
		{
			
			Vector2 p = Main.MouseScreen+Main.screenPosition-Player.position;
			
			Vector2 velocity = 20f * p / p.Length();
			int damage = (int)Player.GetTotalDamage(ModContent.GetInstance<JiShangDamage>()).ApplyTo(100);
			if (Key1.JiNeng1.JustPressed)
			{
				Projectile.NewProjectile(Player.GetSource_FromThis(), Player.position, velocity, ModContent.ProjectileType<LeiMuJiNeng>(), damage, 0);
			}
		}

	}
}
