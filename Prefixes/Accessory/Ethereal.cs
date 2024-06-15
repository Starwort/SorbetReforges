using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace SorbetReforges.Prefixes.Accessory {
    internal class Ethereal : ModPrefix {
        public override void ApplyAccessoryEffects(Player player) {
            player.manaCost *= 0.98f;
            player.statManaMax2 += 10;
        }

        public override void ModifyValue(ref float valueMult) {
            valueMult *= 1.21f;
        }

        public override PrefixCategory Category => PrefixCategory.Accessory;

        static TooltipLine? _line;
        static TooltipLine line => _line ??= new TooltipLine(
            SorbetReforges.Instance,
            "PrefixAccMaxMana",
            "+10 " + Language.GetText("LegacyTooltip.31")
        ) {
            IsModifier = true,
        };

        static TooltipLine? _line2;
        static TooltipLine line2 => _line2 ??= new TooltipLine(
            SorbetReforges.Instance,
            "PrefixAccManaCost",
            "-2" + Language.GetText("LegacyTooltip.42")
        ) {
            IsModifier = true,
        };

        public override IEnumerable<TooltipLine> GetTooltipLines(Item item) {
            return [
                line,
                line2,
            ];
        }
    }
}
