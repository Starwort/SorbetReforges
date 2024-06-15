using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace SorbetReforges.Prefixes.Accessory {
    internal class Attuned : ModPrefix {
        public override void ApplyAccessoryEffects(Player player) {
            player.manaCost *= 0.99f;
            player.statManaMax2 += 5;
        }

        public override void ModifyValue(ref float valueMult) {
            valueMult *= 1.1025f;
        }

        public override PrefixCategory Category => PrefixCategory.Accessory;

        static TooltipLine? _line;
        static TooltipLine line => _line ??= new TooltipLine(
            SorbetReforges.Instance,
            "PrefixAccMaxMana",
            "+5 " + Language.GetText("LegacyTooltip.31")
        ) {
            IsModifier = true,
        };

        static TooltipLine? _line2;
        static TooltipLine line2 => _line2 ??= new TooltipLine(
            SorbetReforges.Instance,
            "PrefixAccManaCost",
            "-1" + Language.GetText("LegacyTooltip.42")
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
