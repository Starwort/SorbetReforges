using System.Collections.Generic;
using Terraria.Localization;
using Terraria;
using Terraria.ModLoader;

namespace SorbetReforges.Prefixes.Accessory {
    internal class Accurate : ModPrefix {
        public override void ApplyAccessoryEffects(Player player) {
            player.GetCritChance(DamageClass.Generic) += 3;
        }

        public override void ModifyValue(ref float valueMult) {
            valueMult *= 1.3225f;
        }

        public override PrefixCategory Category => PrefixCategory.Accessory;

        static TooltipLine? _line;

        static TooltipLine line => _line ??= new TooltipLine(
            SorbetReforges.Instance,
            "PrefixCritChance",
            "+3" + Language.GetText("LegacyTooltip.41")
        );

        public override IEnumerable<TooltipLine> GetTooltipLines(Item item) {
            line.IsModifier = true;
            return [
                line
            ];
        }
    }
}
