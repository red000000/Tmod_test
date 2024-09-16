using System;
using Terraria;
using Terraria.ModLoader;

namespace test.Content.Buffs
{
    public class NoDamageBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true; // 标记为减益效果
            Main.buffNoTimeDisplay[Type] = false; // 显示 Buff 的持续时间
        }
        public override void ModifyBuffText(ref string buffName, ref string tip, ref int rare)
        {
            buffName = "无法造成伤害";
            tip = "无法造成伤害";
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            // 将敌人伤害属性设置为 0
            npc.damage = 0;
        }

    }
}
