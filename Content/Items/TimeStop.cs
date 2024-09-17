using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using test.Common.Systems;
namespace test.Content.Items
{
    public class TimeStop : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.maxStack = 99;
            Item.value = Item.sellPrice(gold: 1);
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.consumable = false;
            Item.UseSound = SoundID.Item1;
        }

        public override bool? UseItem(Player player)
        {
            // 切换时停状态
            TimeStopSystem.IsTimeStopped = !TimeStopSystem.IsTimeStopped;
            bool isTimeStopped = TimeStopSystem.IsTimeStopped;

            Main.NewText("Time Stop Activated: " + (isTimeStopped ? "On" : "Off"), Color.Red);
            // 保存当前时间
            TimeStopSystem.Time = Main.time;
            // 暂停或恢复所有 NPC 的行动
            foreach (NPC npc in Main.ActiveNPCs)
            {

                if (isTimeStopped)
                {

                    // 保存 NPC 当前状态
                    SaveNPCState(npc);
                    // 停止 NPC 移动和 AI
                    npc.velocity = Vector2.Zero;
                    npc.aiStyle = -1; // 停止 AI（根据具体 NPC 类型修改）
                    npc.netUpdate = true;
                }
                else
                {
                    // 恢复 NPC 状态
                    RestoreNPCState(npc);
                }

            }
            // 暂停或恢复所有 Projectile 的行动
            foreach (Projectile projectile in Main.ActiveProjectiles)
            {

                if (isTimeStopped)
                {
                    // 保存 Projectile 当前状态
                    SaveProjectile(projectile);

                    // 停止 Projectile 移动和 AI
                    projectile.velocity = Vector2.Zero;
                    projectile.aiStyle = -1; // 停止 AI（根据具体 NPC 类型修改）
                    projectile.netUpdate = true;
                }
                else
                {
                    // 恢复 Projectile 状态
                    RestoreProjectile(projectile);
                }

            }

            return true;
        }

        private void SaveNPCState(NPC npc)
        {
            if (!TimeStopSystem.Saved_NPC_State.ContainsKey(npc.whoAmI))
            {
                // 保存当前 NPC 的 AI 状态
                TimeStopSystem.Saved_NPC_State[npc.whoAmI] = new NPCState
                {
                    Ai = npc.ai,
                    AiStyle = npc.aiStyle,
                    Velocity = npc.velocity,
                };
            }
        }

        private void RestoreNPCState(NPC npc)
        {
            if (TimeStopSystem.Saved_NPC_State.TryGetValue(npc.whoAmI, out NPCState State))
            {
                // 恢复 NPC 的 AI 状态
                npc.ai = State.Ai;
                npc.aiStyle = State.AiStyle;
                npc.velocity = State.Velocity;

                npc.netUpdate = true;
            }
        }
        private void SaveProjectile(Projectile projectile)
        {
            if (!TimeStopSystem.Saved_Projectiles_State.ContainsKey(projectile.identity))
            {
                // 保存当前 NPC 的 AI 状态
                TimeStopSystem.Saved_Projectiles_State[projectile.whoAmI] = new ProjectileState
                {
                    Ai = projectile.ai,
                    Velocity = projectile.velocity,
                    AiStyle = projectile.aiStyle,
                };
            }
        }

        private void RestoreProjectile(Projectile projectile)
        {
            if (TimeStopSystem.Saved_Projectiles_State.TryGetValue(projectile.whoAmI, out ProjectileState State))
            {
                // 恢复 NPC 的 AI 状态
                projectile.ai = State.Ai;
                projectile.aiStyle = State.AiStyle;
                projectile.velocity = State.Velocity;

                projectile.netUpdate = true;
            }
        }
    }

    // 自定义类用于保存 NPC 状态

}
