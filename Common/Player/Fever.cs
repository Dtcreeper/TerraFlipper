using Terraria;
using Terraria.ModLoader;

namespace TerraFlipper.Common.Player
{
	public class Fever : ModPlayer
	{
		// Here we create a custom resource, similar to mana or health.
		// Creating some variables to define the current value of our example resource as well as the current maximum value. We also include a temporary max value, as well as some variables to handle the natural regeneration of this resource.
		public float FeverCurrent; // Current value of our example resource
		public const int DefaultFeverMax = 6000; // Default maximum value of example resource
		public int FeverMax; // Buffer variable that is used to reset maximum resource to default value in ResetDefaults().
		public int FeverMax2; // Maximum amount of our example resource. We will change that variable to increase maximum amount of our resource
		public float DeafaultFeverIncrease = 15; // 直击默认增加Fever数
		public float FeverDecreaseByTime = 10;
		public static bool FeverMode = false;
		internal int FeverTimer = 0; // A variable that is required for our timer

		// In order to make the Example Resource example straightforward, several things have been left out that would be needed for a fully functional resource similar to mana and health. 
		// Here are additional things you might need to implement if you intend to make a custom resource:
		// - Multiplayer Syncing: The current example doesn't require MP code, but pretty much any additional functionality will require this. ModPlayer.SendClientChanges and CopyClientState will be necessary, as well as SyncPlayer if you allow the user to increase exampleResourceMax.
		// - Save/Load permanent changes to max resource: You'll need to implement Save/Load to remember increases to your exampleResourceMax cap.
		// - Resouce replenishment item: Use GlobalNPC.OnKill to drop the item. ModItem.OnPickup and ModItem.ItemSpace will allow it to behave like Mana Star or Heart. Use code similar to Player.HealEffect to spawn (and sync) a colored number suitable to your resource.

		public override void Initialize()
		{
			FeverMax = DefaultFeverMax;
			FeverMode = false;
		}

		public override void ResetEffects()
		{
			//ResetVariables();
		}

		public override void UpdateDead()
		{
			ResetVariables();
		}

		// We need this to ensure that regeneration rate and maximum amount are reset to default values after increasing when conditions are no longer satisfied (e.g. we unequip an accessory that increaces our recource)
		public void ResetVariables()
		{
			FeverCurrent = 0;
			FeverMode = false;
		}

		public override void PostUpdateMiscEffects()
		{
			UpdateResource();
		}

		public override void PostUpdate()
		{
			CapResourceGodMode();
		}
		public static bool IsFever()
		{
			return FeverMode;
		}

		// Lets do all our logic for the custom resource here, such as limiting it, increasing it and so on.
		private void UpdateResource()
		{
			if (FeverMode)
			{
				if (FeverCurrent < 0)
				{
					FeverMode = false;
					DeafaultFeverIncrease = 15;
				}
				FeverCurrent -= FeverDecreaseByTime;
			}
			else
			{
				if (FeverCurrent >= DefaultFeverMax)
				{
					FeverMode = true;
					DeafaultFeverIncrease = 0;
				}
				else
				{
					if (FeverCurrent < 0)
					{
						FeverMode = false;
						DeafaultFeverIncrease = 15;
					}
				}
			}
		}

		private void CapResourceGodMode()
		{
			if (Main.myPlayer == Player.whoAmI && Player.creativeGodMode)
			{
				FeverCurrent = DefaultFeverMax;
			}
		}
	}
}