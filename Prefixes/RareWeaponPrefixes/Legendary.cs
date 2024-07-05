using Terraria;
using Terraria.ModLoader;

namespace SorbetReforges.Prefixes.RareWeaponPrefixes {
    internal class Legendary : ModPrefix {
        public override void ModifyValue(ref float valueMult) {
            valueMult *= 3.0985f;
        }

        public override PrefixCategory Category => PrefixCategory.Melee;

        public override void SetStats(
            ref float damageMult, 
            ref float knockbackMult, 
            ref float useTimeMult, 
            ref float scaleMult, 
            ref float shootSpeedMult, 
            ref float manaMult, 
            ref int critBonus
        ) {
            damageMult = 1.2f;
            knockbackMult = 1.15f;
            useTimeMult = 0.9f;
            scaleMult = 1.1f;
            shootSpeedMult = 1f;
            manaMult = 1f;
            critBonus = 7;
        }

        public override bool CanRoll(Item item) {
            return ModContent.GetInstance<ShouldEnable>().EnableRarePrefixes;
        }

        public override float RollChance(Item item) {
            return ModContent.GetInstance<ShouldEnable>().RarePrefixRelativeChance;
        }
    }
}
