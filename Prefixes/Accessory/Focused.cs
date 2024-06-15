using System.Collections.Generic;
using Terraria.Localization;
using Terraria;
using Terraria.ModLoader;

namespace SorbetReforges.Prefixes.Accessory {
    internal class Focused : ModPrefix {
        public override void ApplyAccessoryEffects(Player player) {
            player.GetCritChance(DamageClass.Generic) += 1;
        }

        public override void ModifyValue(ref float valueMult) {
            valueMult *= 1.1025f;
        }

        public override PrefixCategory Category => PrefixCategory.Accessory;

        static TooltipLine? _line;

        static TooltipLine line => _line ??= new TooltipLine(
            SorbetReforges.Instance,
            "PrefixCritChance",
            "+1" + Language.GetText("LegacyTooltip.41")
        );

        public override IEnumerable<TooltipLine> GetTooltipLines(Item item) {
            line.IsModifier = true;
            return [
                line
            ];
        }
    }
}
