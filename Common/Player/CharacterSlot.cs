using Microsoft.Xna.Framework;
using TerraFlipper.Common.Key;
using TerraFlipper.Content.Character;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerraFlipper.Common.Player
{

	public class CharacterSlot1 : ModAccessorySlot
	{
		public override Vector2? CustomLocation => new Vector2(Main.screenWidth / 2, 3 * Main.screenHeight / 4);
		public override string VanityBackgroundTexture => "Terraria/Images/Inventory_Back14"; // yellow
		public override string FunctionalBackgroundTexture => "Terraria/Images/Inventory_Back7"; // pale blue
		public override string FunctionalTexture => "Terraria/Images/Item_" + ItemID.TargetDummy;
		public override bool DrawDyeSlot => false;
		public override bool DrawVanitySlot => false;
		public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
		{
			if (ModContent.GetModItem(checkItem.ModItem.Type) != null)
				return true;

			return false; // Otherwise nothing in slot
		}
		public override void ApplyEquipEffects()
		{
			if (Key1.Jineng1.JustPressed)
			{
				
			}
		}
		public static Item GetItem()
		{
			return FunctionalItem;
		}

	}
	public class CharacterSlot2 : ModAccessorySlot
	{
		public override Vector2? CustomLocation => new Vector2(Main.screenWidth / 2 + 50, 3 * Main.screenHeight / 4);
		public override string VanityBackgroundTexture => "Terraria/Images/Inventory_Back14"; // yellow
		public override string FunctionalBackgroundTexture => "Terraria/Images/Inventory_Back7"; // pale blue
		public override string FunctionalTexture => "Terraria/Images/Item_" + ItemID.TargetDummy;
		public override bool DrawDyeSlot => false;
		public override bool DrawVanitySlot => false;
		public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
		{
			if (ModContent.GetModItem(checkItem.ModItem.Type) != null) 
				return true;

			return false; // Otherwise nothing in slot
		}
	}


	public class CharacterSlot3 : ModAccessorySlot
	{
		public override Vector2? CustomLocation => new Vector2(Main.screenWidth / 2 + 100, 3 * Main.screenHeight / 4);
		public override string VanityBackgroundTexture => "Terraria/Images/Inventory_Back14"; // yellow
		public override string FunctionalBackgroundTexture => "Terraria/Images/Inventory_Back7"; // pale blue
		public override string FunctionalTexture => "Terraria/Images/Item_" + ItemID.TargetDummy;
		public override bool DrawDyeSlot => false;
		public override bool DrawVanitySlot => false;
		public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
		{
			if (ModContent.GetModItem(checkItem.ModItem.Type) != null)
				return true;
			return false; // Otherwise nothing in slot
		}
	}
	public class FangDaZhao
	{
		public void FangDa(int slot)
		{
			if(slot==1)
			{
				if(Main.LocalPlayer.GetModPlayer<Energy1>().CurrentEnergy>= Main.LocalPlayer.GetModPlayer<Energy1>().DefaultEnergyMax)
				{
					if(CharacterSlot1.GetItem().type == ModContent.GetInstance<LeiMu>().Type)
					{
						
					}
				}
			}
		}
	}
	
}