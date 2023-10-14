using Microsoft.Xna.Framework;
using System;
using TerraFlipper.Common.NPCs.XiaoGuai;
using TerraFlipper.Content.ProjectTiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerraFlipper.Common.BOSS
{
	[AutoloadBossHead]
	public class ShuiPangXie : ModNPC
	{
		public static int odamage = 50;
		public static int shilianhp1 = 0;
		public static int shilian = 0;
		enum AIState
		{
			//RuChang,
			XiuXi,
			ZhaoXiaoGuai1,
			WaiQuanHongZha,
			NeiQuanHongZha,
			ShanXingHongZha1,
			ShanXingHongZha2,
			ZhaoXiaoGuai2,
			ShiLian1,
			ShiLian2,
			Die,

		}
		public ref float AI_State => ref NPC.ai[0];
		public ref float AI_Timer => ref NPC.ai[1];
		public ref float TrueAiState => ref NPC.ai[2];
		public override void SetDefaults()
		{
			NPC.width = 150;
			NPC.height = 150;//这两个代表这个NPC的碰撞箱宽高，以及tr会从你的贴图里扣多大的图
			NPC.damage = 25;
			NPC.lifeMax = 2000;//npc的血量上限
			NPC.defense = 5;
			NPC.scale = 1f;//npc的贴图和碰撞箱的放缩倍率
			NPC.knockBackResist = 0f;
			NPC.HitSound = SoundID.NPCHit5;//挨打时发出的声音
			NPC.DeathSound = SoundID.NPCDeath7;//趋势时发出的声音
			NPC.value = Item.buyPrice(0, 5, 0, 0);//NPC的爆出来的MONEY的数量，四个空从左到右是铂金，金，银，铜
			NPC.lavaImmune = true;//对岩浆免疫
			NPC.noGravity = true;//不受重力影响。一般BOSS都是无重力的
			NPC.noTileCollide = true;//可穿墙
			NPC.npcSlots = 20; //NPC所占用的NPC数量，在TR世界里，NPC上限是200个，通常，这个用来限制Boss战时敌怪数量，填个10，20什么的
			NPC.boss = true; //将npc设为boss 会掉弱治药水和心，会显示xxx已被击败，会有血条
			NPC.dontTakeDamage = false;//为true则为无敌，这里的无敌意思是弹幕不会打到npc，并且npc的血条也不会显示了
			Music = MusicID.Boss1;
			NPC.aiStyle = -1;
		}
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[NPC.type] = 1;//总共几帧
			NPCDebuffImmunityData debuffData = new NPCDebuffImmunityData
			{
				SpecificallyImmuneTo = new int[]
					{
						BuffID.Poisoned,
					}
			};
		}
		public override void AI()
		{
			
		}
		public override void FindFrame(int frameHeight)
		{
			//NPC.spriteDirection = NPC.direction;
			NPC.frame.X = 0;
			NPC.frame.Y = 0;
		}
		public override void HitEffect(NPC.HitInfo hit)
		{
			base.HitEffect(hit);
		}
		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			base.ModifyNPCLoot(npcLoot);
		}
		public override void OnKill()
		{
			base.OnKill();
		}
		public void YiDong()
		{

		}
	}
}