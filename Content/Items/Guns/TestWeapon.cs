using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace test.Content.Items.Guns
{
    public class TestWeapon : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 50; // 武器伤害
            Item.DamageType = DamageClass.Ranged; // 远程武器
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot; // 使用 Shoot 样式
            Item.noMelee = true;
            Item.shootSpeed = 16f; // 子弹速度
            Item.shoot = ModContent.ProjectileType<test.Content.Projectiles.TestProjectile>(); // 发射特定的发射物
            Item.useAmmo = ModContent.ItemType<test.Content.Items.Bullets.TestBullet>(); // 使用特定子弹作为弹药
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Orange;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DirtBlock, 1); // 添加泥土块作为合成材料
            recipe.AddTile(TileID.WorkBenches); // 指定合成台（工作台）
            recipe.Register(); // 注册配方
        }
    }
}
