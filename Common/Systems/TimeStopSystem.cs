using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace test.Common.Systems
{
    public class TimeStopSystem : ModSystem
    {
        public static bool IsTimeStopped = false;
        public static double Time = 0;
        public static Dictionary<int, NPCState> Saved_NPC_State = new Dictionary<int, NPCState>();
        public static Dictionary<int, ProjectileState> Saved_Projectiles_State = new Dictionary<int, ProjectileState>();
        public override void PostUpdateTime()
        {
            if (IsTimeStopped)
            {
                Main.time = Time;
            }
        }
    }
    public class NPCState
    {
        public float[] Ai { get; set; }
        public int AiStyle { get; set; }
        public Vector2 Velocity { get; set; }
    }
    public class ProjectileState
    {
        public float[] Ai { get; set; }
        public int AiStyle { get; set; }
        public Vector2 Velocity { get; set; }
    }
}
