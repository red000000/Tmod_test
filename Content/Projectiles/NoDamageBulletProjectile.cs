using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using test.Content.Buffs;
namespace test.Content.Projectiles
{
    public class NoDamageBulletProjectile : ModProjectile
    {
        public override void SetDefaults()
        {

            Projectile.width = 14; // 投射物宽度
            Projectile.height = 14; // 投射物高度
            Projectile.aiStyle = 1; // 设置 aiStyle（决定投射物的行为）
            Projectile.friendly = true; // 使投射物对友好目标有效
            Projectile.DamageType = DamageClass.Ranged; // 设置为远程武器
            Projectile.penetrate = 1; // 设置穿透次数
            Projectile.timeLeft = 600; // 投射物的存活时间
        }

        public override void AI()
        {
            // 这里可以添加自定义的 AI 逻辑
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            // 当投射物与瓦片碰撞时调用
            return true;
        }

        public override bool PreAI()
        {
            // 在 AI 之前运行
            return true;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {

            // 应用 debuff
            target.AddBuff(ModContent.BuffType<test.Content.Buffs.NoDamageBuff>(), 300);
        }
    }
}
