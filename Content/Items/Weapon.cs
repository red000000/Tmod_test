using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using test.Content.Projectiles;
namespace test.Content.Items
{
    public class Weapon : ModItem
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
            Item.shoot = ModContent.ProjectileType<Projectiles.NoDamageBulletProjectile>();
            Item.useAmmo = AmmoID.Bullet; // 使用子弹作为弹药
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
