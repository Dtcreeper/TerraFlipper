using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using TerraFlipper.Common.Player;
using TerraFlipper.Content.DamageClasses;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerraFlipper.Content.ProjectTiles
{
    public class ColorfulStar : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5; // The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0; // The recording mode
        }
        public override void SetDefaults()
        {
            Projectile.width = 48; // The width of projectile hitbox
            Projectile.height = 48; // The height of projectile hitbox
            Projectile.aiStyle = 1; // The ai style of the projectile, please reference the source code of Terraria
            Projectile.friendly = true; // Can the projectile deal damage to enemies?
            Projectile.hostile = false; // Can the projectile deal damage to the player?
            Projectile.DamageType = ModContent.GetInstance<BounceDamage>(); // Is the projectile shoot by a ranged weapon?
            Projectile.penetrate = 10; // How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            Projectile.timeLeft = 600; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            Projectile.alpha = 0; // The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in) Make sure to delete this if you aren't using an aiStyle that fades in. You'll wonder why your projectile is invisible.
            Projectile.light = 1.5f; // How much light emit around the projectile
            Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
            Projectile.tileCollide = true; // Can the projectile collide with tiles?
            Projectile.extraUpdates = 1; // Set to above 0 if you want the projectile to update multiple time in a frame

            AIType = ProjectileID.Bullet;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            //增加Fever槽
            Main.LocalPlayer.GetModPlayer<Fever>().FeverCurrent += 4*Main.LocalPlayer.GetModPlayer<Fever>().DeafaultFeverIncrease;
            base.OnHitNPC(target, hit, damageDone);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            //处理碰撞tile
            Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);

            // If the projectile hits the left or right side of the tile, reverse the X velocity
            if (Math.Abs(Projectile.velocity.X - oldVelocity.X) > float.Epsilon)
            {
                Projectile.velocity.X = -oldVelocity.X;
                Projectile.velocity.Y = oldVelocity.Y;
            }

            // If the projectile hits the top or bottom side of the tile, reverse the Y velocity
            if (Math.Abs(Projectile.velocity.Y - oldVelocity.Y) > float.Epsilon)
            {
                Projectile.velocity.Y = -oldVelocity.Y;
                Projectile.velocity.X = oldVelocity.X;
            }


            return false;
        }
        public override bool PreAI()
        {
            //处理边缘碰撞，反向加上人物速度
            Player player = Main.player[Projectile.owner];
            if (Math.Abs(Projectile.position.X - player.position.X) >= 960)
            {
                if (Projectile.velocity.X > 0)
                {
                    Projectile.velocity.X = -Projectile.velocity.X - Math.Abs(player.velocity.X);
                }
                else
                {
                    Projectile.velocity.X = -Projectile.velocity.X + Math.Abs(player.velocity.X);
                }
            }
            if (Math.Abs(Projectile.position.Y - player.position.Y) >= 544)
            {
                if (Projectile.velocity.Y > 0)
                {
                    Projectile.velocity.Y = -Projectile.velocity.Y - Math.Abs(player.velocity.Y);
                }
                else
                {
                    Projectile.velocity.Y = -Projectile.velocity.Y + Math.Abs(player.velocity.Y);
                }

            }
            return false;
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Main.instance.LoadProjectile(Projectile.type);
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;

            // Redraw the projectile with the color not influenced by light
            Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, Projectile.height * 0.5f);
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = (Projectile.oldPos[k] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color color = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                Main.EntitySpriteDraw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }

            return true;
        }
        public override void Kill(int timeLeft)
        {
            // This code and the similar code above in OnTileCollide spawn dust from the tiles collided with. SoundID.Item10 is the bounce sound you hear.
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        }
    }



}
