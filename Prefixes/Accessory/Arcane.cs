using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace SorbetReforges.Prefixes.Accessory {
    internal class Arcane : GlobalItem {
        public override void Load() {
            On_Player.GrantPrefixBenefits += modify;
        }

        private static void modify(On_Player.orig_GrantPrefixBenefits orig, Player self, Item item) {
            if (item.prefix == PrefixID.Arcane) {
                self.manaCost *= 0.97f;
                self.statManaMax2 += 15;
            } else {
                orig(self, item);
            }
        }

        static TooltipLine? _line2;
        static TooltipLine line2 => _line2 ??= new TooltipLine(
            SorbetReforges.Instance,
            "PrefixAccManaCost",
            "-2" + Language.GetText("LegacyTooltip.42")
        ) {
            IsModifier = true,
        };

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
            if (item.prefix == PrefixID.Arcane) {
                foreach (var line in tooltips) {
                    if (line.Name == "PrefixAccMaxMana") {
                        line.Text = "+15 " + Language.GetText("LegacyTooltip.31");
                    }
                }
                tooltips.Add(line2);
            }
        }
    }
}
