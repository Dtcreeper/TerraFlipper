using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TerraFlipper.Content.DamageClasses;
using Terraria;
using Terraria.ModLoader;


namespace TerraFlipper.Content.ProjectTiles
{
	public class LongQuanJiNeng : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[Projectile.type] = 15;//帧数
		}

		public override void SetDefaults()
		{
			Projectile.width = 312; //图宽度
			Projectile.height = 312; //图高度
			Projectile.friendly = true;
			Projectile.DamageType = ModContent.GetInstance<ShuiDamage>(); // 伤害类型
			Projectile.ignoreWater = false;
			Projectile.tileCollide = false;
			Projectile.penetrate = -1;
			Projectile.alpha = 0;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = -1;
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(200, 200, 200, 0) * Projectile.Opacity;
		}

		public override void AI()
		{
			Projectile.ai[0] += 1f;//计时器
			Projectile.velocity = Vector2.Zero;
			if (++Projectile.frameCounter >= 8)//每帧时间
			{
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= Main.projFrames[Projectile.type])
					Projectile.frame = 0;
			}
			if (Projectile.ai[0] >= 120f)/*    X/60秒后消失    */
				Projectile.Kill();
			Projectile.direction = Projectile.spriteDirection = Projectile.velocity.X > 0f ? 1 : -1;
			Projectile.rotation = Projectile.velocity.ToRotation();
			if (Projectile.spriteDirection == 1)
			{
				Projectile.rotation += MathHelper.Pi;
			}
		}
		public override bool PreDraw(ref Color lightColor)
		{
			SpriteEffects spriteEffects = SpriteEffects.None;
			if (Projectile.spriteDirection == -1)
				spriteEffects = SpriteEffects.FlipHorizontally;
			Texture2D texture = (Texture2D)ModContent.Request<Texture2D>(Texture);
			int frameWidth = texture.Width / Main.projFrames[Projectile.type];
			int startX = frameWidth * Projectile.frame;
			Rectangle sourceRectangle = new Rectangle(startX, 0, frameWidth, texture.Height);
			Vector2 origin = sourceRectangle.Size() / 2f;
			float offsetX = 152f;//注意修改offset
			origin.X = Projectile.spriteDirection == 1 ? sourceRectangle.Width - offsetX : offsetX;
			Color drawColor = lightColor;
			Main.EntitySpriteDraw(texture,
				Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY),
				sourceRectangle, drawColor, Projectile.rotation, origin, Projectile.scale, spriteEffects, 0);
			return false;
		}
	}
}

