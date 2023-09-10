using Terraria;
using Terraria.ModLoader;
using System;

namespace TerraFlipper.Common.Player
{
	public class Energy1 : ModPlayer
	{
		public float CurrentEnergy;
		public  int DefaultEnergyMax = 1000; 
		public float DeafaultEnergyIncrease = 15;
		public override void Initialize()
		{
			CurrentEnergy = 0;
		}

		public override void ResetEffects()
		{
			ResetVariables();
		}

		public override void UpdateDead()
		{
			ResetVariables();
		}

		// We need this to ensure that regeneration rate and maximum amount are reset to default values after increasing when conditions are no longer satisfied (e.g. we unequip an accessory that increaces our recource)
		private void ResetVariables()
		{
			CurrentEnergy = 0;
		}

		public override void PostUpdateMiscEffects()
		{
			UpdateResource();
		}

		public override void PostUpdate()
		{
			CapResourceGodMode();
		}

		// Lets do all our logic for the custom resource here, such as limiting it, increasing it and so on.
		private void UpdateResource()
		{
			CurrentEnergy += Main.LocalPlayer.velocity.Length()/40;
		}

		private void CapResourceGodMode()
		{
			if (Main.myPlayer == Player.whoAmI && Player.creativeGodMode)
			{
				CurrentEnergy = DefaultEnergyMax;
			}
		}
	}
}