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
			if (Main.LocalPlayer.dead)
			{
				NPC.life = 0;
			}
			if (Math.Abs((NPC.position - Main.LocalPlayer.position).Length()) >= 600)
			{
				YiDong();
				return;
			}
			switch (AI_State)
			{

				case (float)AIState.XiuXi:
					xiuxi();
					break;
				case (float)AIState.ZhaoXiaoGuai1:
					ZhaoXiaoGuai();
					break;
				case (float)AIState.WaiQuanHongZha:
					WaiQuanHongZha();
					break;
				case (float)AIState.NeiQuanHongZha:
					NeiQuanHongZha();
					break;
				case (float)AIState.ShanXingHongZha1:
					ShanXingHongZha1();
					break;
				case (float)AIState.ShanXingHongZha2:
					ShanXingHongZha2();
					break;
				case (float)AIState.ZhaoXiaoGuai2:
					ZhaoXiaoGuai();
					break;
				case (float)AIState.ShiLian1:
					Main.NewText("ShiLianKaiShi" + NPC.frameCounter);
					ShiLian((int)(NPC.lifeMax * 0.1), 8);
					break;
				case (float)AIState.ShiLian2:
					Main.NewText("ShiLianKaiShi" + NPC.frameCounter);
					ShiLian((int)(NPC.lifeMax * 0.15), 8);
					break;
				case (float)AIState.Die:
					NPC.life = 0;
					break;
			}
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
		public void xiuxi()
		{
			NPC.frameCounter++;

			if (NPC.frameCounter > 120)
			{
				NPC.frameCounter = 0;
				AI_State = TrueAiState + 1;
				if (AI_State > 8)
				{
					AI_State = 1;
					NPC.frameCounter = 0;
				}
			}

		}
		public void ZhaoXiaoGuai()
		{
			Random random = new Random();
			for (int i = 0; i <= 3; i++)
			{
				NPC.NewNPC(Entity.GetSource_FromAI(), (int)(NPC.position.X + random.Next(100) - 50), (int)(NPC.position.Y + random.Next(100) - 50), ModContent.NPCType<ShuiXiaoPangXie>());
			}
			NPC.frameCounter = 0;
			TrueAiState = AI_State;
			AI_State = 0;
		}
		public void WaiQuanHongZha()
		{
			for (int i = 0; i <= 7; i++)
			{
				Projectile.NewProjectile(Entity.GetSource_FromAI(), NPC.position + new Vector2(400, 400 - i * 100), Vector2.Zero, ModContent.ProjectileType<ShuiBaoDan>(), odamage, 10);
				Projectile.NewProjectile(Entity.GetSource_FromAI(), NPC.position + new Vector2(-400, 400 - i * 100), Vector2.Zero, ModContent.ProjectileType<ShuiBaoDan>(), odamage, 10);
			}
			NPC.frameCounter = 0;
			TrueAiState = AI_State;
			AI_State = 0;
		}
		public void NeiQuanHongZha()
		{
			for (int i = 0; i <= 7; i++)
			{
				Projectile.NewProjectile(Entity.GetSource_FromAI(), NPC.position + new Vector2(200, 400 - i * 100), Vector2.Zero, ModContent.ProjectileType<ShuiBaoDan>(), odamage, 10);
				Projectile.NewProjectile(Entity.GetSource_FromAI(), NPC.position + new Vector2(-200, 400 - i * 100), Vector2.Zero, ModContent.ProjectileType<ShuiBaoDan>(), odamage, 10);
			}
			NPC.frameCounter = 0;
			TrueAiState = AI_State;
			AI_State = 0;
		}
		public void ShanXingHongZha1()
		{
			float sin22 = (float)Math.Sin(Math.PI / 8);
			float cos22 = (float)Math.Cos(Math.PI / 8);
			float sin45 = (float)Math.Sin(Math.PI / 4);
			float cos45 = (float)Math.Cos(Math.PI / 4);
			for (int i = 0; i <= 7; i++)
			{
				Projectile.NewProjectile(Entity.GetSource_FromAI(), NPC.position + new Vector2(100 * i * sin22, 100 * i * cos22), Vector2.Zero, ModContent.ProjectileType<ShuiBaoDan>(), odamage, 10);
				Projectile.NewProjectile(Entity.GetSource_FromAI(), NPC.position + new Vector2(100 * i * sin22, -100 * i * cos22), Vector2.Zero, ModContent.ProjectileType<ShuiBaoDan>(), odamage, 10);
				Projectile.NewProjectile(Entity.GetSource_FromAI(), NPC.position + new Vector2(-100 * i * sin22, 100 * i * cos22), Vector2.Zero, ModContent.ProjectileType<ShuiBaoDan>(), odamage, 10);
				Projectile.NewProjectile(Entity.GetSource_FromAI(), NPC.position + new Vector2(-100 * i * sin22, -100 * i * cos22), Vector2.Zero, ModContent.ProjectileType<ShuiBaoDan>(), odamage, 10);
				Projectile.NewProjectile(Entity.GetSource_FromAI(), NPC.position + new Vector2(100 * i * sin45, 100 * i * cos45), Vector2.Zero, ModContent.ProjectileType<ShuiBaoDan>(), odamage, 10);
				Projectile.NewProjectile(Entity.GetSource_FromAI(), NPC.position + new Vector2(100 * i * sin45, -100 * i * cos45), Vector2.Zero, ModContent.ProjectileType<ShuiBaoDan>(), odamage, 10);
				Projectile.NewProjectile(Entity.GetSource_FromAI(), NPC.position + new Vector2(-100 * i * sin45, 100 * i * cos45), Vector2.Zero, ModContent.ProjectileType<ShuiBaoDan>(), odamage, 10);
				Projectile.NewProjectile(Entity.GetSource_FromAI(), NPC.position + new Vector2(-100 * i * sin45, -100 * i * cos45), Vector2.Zero, ModContent.ProjectileType<ShuiBaoDan>(), odamage, 10);
			}
			NPC.frameCounter = 0;
			TrueAiState = AI_State;
			AI_State = 0;
		}
		public void ShanXingHongZha2()
		{
			float sin67 = (float)Math.Sin(Math.PI * 3 / 8);
			float cos67 = (float)Math.Cos(Math.PI * 3 / 8);
			float sin45 = (float)Math.Sin(Math.PI / 4);
			float cos45 = (float)Math.Cos(Math.PI / 4);
			for (int i = 0; i <= 7; i++)
			{
				Projectile.NewProjectile(Entity.GetSource_FromAI(), NPC.position + new Vector2(100 * i * sin67, 100 * i * cos67), Vector2.Zero, ModContent.ProjectileType<ShuiBaoDan>(), odamage, 10);
				Projectile.NewProjectile(Entity.GetSource_FromAI(), NPC.position + new Vector2(100 * i * sin67, -100 * i * cos67), Vector2.Zero, ModContent.ProjectileType<ShuiBaoDan>(), odamage, 10);
				Projectile.NewProjectile(Entity.GetSource_FromAI(), NPC.position + new Vector2(-100 * i * sin67, 100 * i * cos67), Vector2.Zero, ModContent.ProjectileType<ShuiBaoDan>(), odamage, 10);
				Projectile.NewProjectile(Entity.GetSource_FromAI(), NPC.position + new Vector2(-100 * i * sin67, -100 * i * cos67), Vector2.Zero, ModContent.ProjectileType<ShuiBaoDan>(), odamage, 10);
				Projectile.NewProjectile(Entity.GetSource_FromAI(), NPC.position + new Vector2(100 * i * sin45, 100 * i * cos45), Vector2.Zero, ModContent.ProjectileType<ShuiBaoDan>(), odamage, 10);
				Projectile.NewProjectile(Entity.GetSource_FromAI(), NPC.position + new Vector2(100 * i * sin45, -100 * i * cos45), Vector2.Zero, ModContent.ProjectileType<ShuiBaoDan>(), odamage, 10);
				Projectile.NewProjectile(Entity.GetSource_FromAI(), NPC.position + new Vector2(-100 * i * sin45, 100 * i * cos45), Vector2.Zero, ModContent.ProjectileType<ShuiBaoDan>(), odamage, 10);
				Projectile.NewProjectile(Entity.GetSource_FromAI(), NPC.position + new Vector2(-100 * i * sin45, -100 * i * cos45), Vector2.Zero, ModContent.ProjectileType<ShuiBaoDan>(), odamage, 10);
			}
			NPC.frameCounter = 0;
			TrueAiState = AI_State;
			AI_State = 0;
		}
		public void ShiLian(int hp, int t)
		{
			if (NPC.frameCounter <= 1)
			{
				shilian = 0;
				shilianhp1 = NPC.life;
			}
			else if (shilianhp1 - NPC.life >= hp)
			{
				NPC.frameCounter = 0;
				TrueAiState = AI_State;
				AI_State = 0;
				ShiLianChenggong();
			}
			else if (NPC.frameCounter >= 60 * t)
			{
				ShiLianShibai();
				NPC.frameCounter = 0;
				TrueAiState = AI_State;
				AI_State = 0;

			}
			NPC.frameCounter++;
		}
		public void ShiLianShibai()
		{
			Main.LocalPlayer.Hurt(PlayerDeathReason.ByNPC(1), 250, 0);
		}
		public void ShiLianChenggong()
		{
			//雷抗降低
		}
		public void YiDong()
		{
			NPC.position = Main.LocalPlayer.position + new Vector2(0, -200);
		}
	}
}