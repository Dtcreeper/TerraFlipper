//using Microsoft.Xna.Framework;
//using Terraria;
//using Terraria.ID;
//using Terraria.ModLoader;
//using Terraria.ModLoader.IO;

//namespace TerraFlipper.Common.Player
//{
//	public class Character : ModPlayer
//	{
//		public static Item[] character = new Item[3];
//		public static TagCompound s=new TagCompound();
//		public static void equip(int slot, Item item)
//		{
//			if (slot == 1)
//			{
//				character[0] = item;
//            }
//			if (slot == 2)
//			{
//				character[1] = item;
//			}
//			if (slot == 3)
//			{
//				character[2] = item;
//			}
//			s.Set("character", character, true);
//		}
//		public static Item Load(int slot)
//		{
//			return s.Get<Item[]>("Character")[slot];
//		}
//	}

//	public class CharacterSlot1 : ModAccessorySlot
//	{

//		public override Vector2? CustomLocation => new Vector2(Main.screenWidth / 2, 3 * Main.screenHeight / 4);
//		public override string VanityBackgroundTexture => "Terraria/Images/Inventory_Back14"; // yellow
//		public override string FunctionalBackgroundTexture => "Terraria/Images/Inventory_Back7"; // pale blue
//		public override string FunctionalTexture => "Terraria/Images/Item_" + ItemID.TargetDummy;
//		public override bool DrawDyeSlot => false;
//		public override bool DrawVanitySlot => false;
//		public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
//		{
//			if (ModContent.GetModItem(checkItem.ModItem.Type) != null)
//			{
//				Character.equip(1, checkItem);
//				return true;
//			}

//			return false; // Otherwise nothing in slot
//		}




//	}
//	public class CharacterSlot2 : ModAccessorySlot
//	{
//		public override Vector2? CustomLocation => new Vector2(Main.screenWidth / 2 + 50, 3 * Main.screenHeight / 4);
//		public override string VanityBackgroundTexture => "Terraria/Images/Inventory_Back14"; // yellow
//		public override string FunctionalBackgroundTexture => "Terraria/Images/Inventory_Back7"; // pale blue
//		public override string FunctionalTexture => "Terraria/Images/Item_" + ItemID.TargetDummy;
//		public override bool DrawDyeSlot => false;
//		public override bool DrawVanitySlot => false;
//		public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
//		{
//			if (ModContent.GetModItem(checkItem.ModItem.Type) != null)
//				return true;

//			return false; // Otherwise nothing in slot
//		}
//	}


//	public class CharacterSlot3 : ModAccessorySlot
//	{
//		public override Vector2? CustomLocation => new Vector2(Main.screenWidth / 2 + 100, 3 * Main.screenHeight / 4);
//		public override string VanityBackgroundTexture => "Terraria/Images/Inventory_Back14"; // yellow
//		public override string FunctionalBackgroundTexture => "Terraria/Images/Inventory_Back7"; // pale blue
//		public override string FunctionalTexture => "Terraria/Images/Item_" + ItemID.TargetDummy;
//		public override bool DrawDyeSlot => false;
//		public override bool DrawVanitySlot => false;
//		public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
//		{
//			if (ModContent.GetModItem(checkItem.ModItem.Type) != null)
//				return true;
//			return false; // Otherwise nothing in slot
//		}
//	}

//}