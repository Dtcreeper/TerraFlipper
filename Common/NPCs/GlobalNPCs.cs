using TerraFlipper.Common.Player;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace TerraFlipper.Common.NPCs
{
	internal class GlobalNPCs : GlobalNPC
	{
		//public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
		//{
		//	// First, we need to check the npc.type to see if the code is running for the vanilla NPCwe want to change
		//	if (npc.type == NPCID.VampireBat)
		//	{
		//		// This is where we add item drop rules for VampireBat, here is a simple example:
		//		npcLoot.Add(ItemDropRule.Common(ItemID.Shackle, 50));
		//	}
		//	// We can use other if statements here to adjust the drop rules of other vanilla NPC
		//}
		public override void SetDefaults(NPC entity)
		{
			entity.lifeMax *= 10;
		}
		public override void OnSpawn(NPC npc, IEntitySource source)
		{
			if (npc.boss)
			{
				ModContent.GetInstance<Fever>().ResetVariables();
				Fever.FeverMode = false;
				ModContent.GetInstance<Energy1>().ResetVariables();
			}
		}
	}
}
