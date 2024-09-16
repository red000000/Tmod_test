using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace test.Content.Items
{
    public class NoDamageBullet : ModItem
    {
        public override void SetDefaults()
        {
            Item.ammo = AmmoID.Bullet; // 子弹类型
            Item.useAnimation = 10; // 子弹使用动画时间
            Item.useTime = 10; // 子弹使用间隔时间
            Item.knockBack = 1f; // 子弹击退力
            Item.damage = 10;
            Item.width = 4; // 子弹宽度
            Item.height = 4; // 子弹高度
            Item.consumable = true; // 子弹使用时消耗
            Item.maxStack = 999; // 最大堆叠数
            Item.shootSpeed = 16f; // 子弹速度
            Item.value = Item.sellPrice(silver: 10); // 子弹的售价
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DirtBlock, 1); // 使用 1 个泥土块作为合成材料
            recipe.AddTile(TileID.WorkBenches); // 使用工作台作为合成台
            recipe.Register(); // 注册配方
        }
    }
}
