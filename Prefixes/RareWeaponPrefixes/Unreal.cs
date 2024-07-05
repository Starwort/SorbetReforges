using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace SorbetReforges.Prefixes.RareWeaponPrefixes {
    internal class Unreal : ModPrefix {
        public override void ModifyValue(ref float valueMult) {
            valueMult *= 3.0985f;
        }

        public override PrefixCategory Category => PrefixCategory.Ranged;

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
            scaleMult = 1f;
            shootSpeedMult = 1.1f;
            manaMult = 1f;
            critBonus = 7;
        }

        public override bool CanRoll(Item item) {
            return ModContent.GetInstance<ShouldEnable>().EnableRarePrefixes;
        }

        public override float RollChance(Item item) {
            return ModContent.GetInstance<ShouldEnable>().RarePrefixRelativeChance;
        }

        static TooltipLine[] lines = null!;
        public override void Load() {
            static TooltipLine line(string what, string text) {
                return new TooltipLine(SorbetReforges.Instance, "Prefix" + what, text) {
                    IsModifier = true
                };
            }
            lines = [
                line("Damage",$"+20{Language.GetText("LegacyTooltip.39")}"),
                line("Speed",$"+10{Language.GetText("LegacyTooltip.40")}"),
                line("CritChance",$"+7{Language.GetText("LegacyTooltip.41")}"),
                line("ShootSpeed",$"+10{Language.GetText("LegacyTooltip.44")}"),
                line("Knockback",$"+15{Language.GetText("LegacyTooltip.45")}"),
            ];
        }

        public override IEnumerable<TooltipLine> GetTooltipLines(Item item) {
            return lines;
        }
    }
}
