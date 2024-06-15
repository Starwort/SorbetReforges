using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace SorbetReforges.VanillaTweaks {
    internal class WeaponPrefixAdjustments : GlobalItem {
        public override void Load() {
            On_Item.TryGetPrefixStatMultipliersForItem += modify;
        }

        static Dictionary<int, (
            float damage,
            float knockback,
            float useTime,
            float size,
            float shotVelocity,
            float manaCost,
            int critChance
        )> prefixValues = new() {
            // Universal
            {PrefixID.Keen, (1f, 1f, 1f, 1f, 1f, 1f, 12)},
            {PrefixID.Superior, (1.1f, 1f, 1f, 1f, 1f, 1f, 5)},
            {PrefixID.Forceful, (1f, 1.5f, 1f, 1f, 1f, 1f, 0)},
            {PrefixID.Hurtful, (1.15f, 1f, 1f, 1f, 1f, 1f, 0)},
            {PrefixID.Strong, (1f, 1.5f, 1f, 1f, 1f, 1f, 0)},
            {PrefixID.Ruthless, (1.28f, 0.8f, 1f, 1f, 1f, 1f, -7)},
            {PrefixID.Demonic, (1.05f, 1f, 1f, 1f, 1f, 1f, 15)},
            {PrefixID.Zealous, (1f, 1f, 1f, 1f, 1f, 1f, 18)},
            // Common
            {PrefixID.Quick, (1f, 1f, 1.15f, 1f, 1f, 1f, 0)},
            {PrefixID.Agile, (1f, 1f, 0.9f, 1f, 1f, 1f, 7)},
            {PrefixID.Murderous, (1.07f, 1f, 0.94f, 1f, 1f, 1f, 5)},
            {PrefixID.Nasty, (1.15f, 0.9f, 0.85f, 1f, 1f, 1f, -15)},
            // Melee
            {PrefixID.Large, (1f, 1f, 1f, 1.25f, 1f, 1f, 0)},
            {PrefixID.Massive, (1f, 1f, 1f, 1.5f, 1f, 1f, 0)},
            {PrefixID.Dangerous, (1.05f, 1f, 0.9f, 1.1f, 1f, 1f, 5)},
            {PrefixID.Savage, (1.15f, 1.1f, 0.9f, 1.1f, 1f, 1f, -10)},
            {PrefixID.Pointy, (1.05f, 1f, 1f, 1f, 1f, 1f, 10)},
            {PrefixID.Bulky, (1.25f, 1.1f, 1.15f, 1.2f, 1f, 1f, 3)},
            {PrefixID.Light, (1f, 0.75f, 0.8f, 1f, 1f, 1f, 0)},
            // Ranged
            {PrefixID.Sighted, (1.05f, 1f, 1f, 1f, 1f, 1f, 10)},
            {PrefixID.Hasty, (1f, 1f, 0.85f, 1f, 1.25f, 1f, 0)},
            {PrefixID.Intimidating, (1f, 1.3f, 1f, 1f, 1.1f, 1f, 5)},
            {PrefixID.Staunch, (1.35f, 1f, 1f, 1f, 1f, 1f, -15)},
            {PrefixID.Awkward, (1.1f, 0.8f, 0.9f, 1f, 0.75f, 1f, 3)},
            {PrefixID.Powerful, (1.25f, 1f, 1.15f, 1f, 1f, 1f, 3)},
            {PrefixID.Frenzying, (0.85f, 1f, 0.7f, 1f, 1f, 1f, 0)},
            // Magic/Summon
            {PrefixID.Mystic, (1.1f, 1f, 1f, 1f, 1f, 0.8f, 0)},
            {PrefixID.Adept, (1f, 1f, 1f, 1f, 1f, 0.7f, 0)},
            {PrefixID.Masterful, (1.15f, 1.05f, 1f, 1f, 1f, 0.9f, 0)},
            {PrefixID.Deranged, (0.9f, 1f, 1f, 1f, 1f, 0.9f, 20)},
            {PrefixID.Intense, (1.2f, 1f, 1f, 1f, 1f, 1.1f, 0)},
            {PrefixID.Taboo, (1f, 1.1f, 0.8f, 1f, 1f, 1.2f, 0)},
            {PrefixID.Celestial, (1.3f, 1.1f, 1.15f, 1f, 1f, 1.1f, 0)},
            {PrefixID.Furious, (1.3f, 1.3f, 1f, 1f, 1f, 1.3f, 0)},
            {PrefixID.Manic, (0.85f, 1f, 0.7f, 1f, 1f, 0.8f, 0)},
        };

        private static bool modify(
            On_Item.orig_TryGetPrefixStatMultipliersForItem orig,
            Item self,
            int rolledPrefix,
            out float damage,
            out float knockback,
            out float useTime,
            out float size,
            out float shotVelocity,
            out float manaCost,
            out int critChance
        ) {
            if (prefixValues.TryGetValue(rolledPrefix, out var data)) {
                damage = data.damage;
                knockback = data.knockback;
                useTime = data.useTime;
                size = data.size;
                shotVelocity = data.shotVelocity;
                manaCost = data.manaCost;
                critChance = data.critChance;
                return (
                    (damage == 1f || Math.Round(self.damage * damage) != self.damage)
                    && (useTime == 1f || Math.Round(self.useAnimation * useTime) != self.useAnimation)
                    && (manaCost == 1f || Math.Round(self.mana * manaCost) != self.mana) 
                    && (knockback == 1f || self.knockBack != 0f)
                );
            } else {
                return orig(
                    self,
                    rolledPrefix,
                    out damage,
                    out knockback,
                    out useTime,
                    out size,
                    out shotVelocity,
                    out manaCost,
                    out critChance
                );
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
            if (prefixValues.TryGetValue(item.prefix, out var data)) {
                foreach (var line in tooltips) {
                    if (line.Name == "PrefixDamage") {
                        line.Text = $"{data.damage * 100 - 100:+#;-#}{Language.GetText("LegacyTooltip.39")}";
                        line.IsModifier = true;
                        line.IsModifierBad = data.damage < 1f;
                    }
                    if (line.Name == "PrefixSpeed") {
                        line.Text = $"{100 - data.useTime * 100:+#;-#}{Language.GetText("LegacyTooltip.40")}";
                        line.IsModifier = true;
                        line.IsModifierBad = data.useTime > 1f;
                    }
                    if (line.Name == "PrefixCritChance") {
                        line.Text = $"{data.critChance:+#;-#}{Language.GetText("LegacyTooltip.41")}";
                        line.IsModifier = true;
                        line.IsModifierBad = data.critChance < 0;
                    }
                    if (line.Name == "PrefixUseMana") {
                        line.Text = $"{data.manaCost * 100 - 100:+#;-#}{Language.GetText("LegacyTooltip.42")}";
                        line.IsModifier = true;
                        line.IsModifierBad = data.manaCost > 1f;
                    }
                    if (line.Name == "PrefixSize") {
                        line.Text = $"{data.size * 100 - 100:+#;-#}{Language.GetText("LegacyTooltip.43")}";
                        line.IsModifier = true;
                        line.IsModifierBad = data.size < 1f;
                    }
                    if (line.Name == "PrefixShootSpeed") {
                        line.Text = $"{data.shotVelocity * 100 - 100:+#;-#}{Language.GetText("LegacyTooltip.44")}";
                        line.IsModifier = true;
                        line.IsModifierBad = data.shotVelocity < 1f;
                    }
                    if (line.Name == "PrefixKnockback") {
                        line.Text = $"{data.knockback * 100 - 100:+#;-#}{Language.GetText("LegacyTooltip.45")}";
                        line.IsModifier = true;
                        line.IsModifierBad = data.knockback < 1f;
                    }
                }
            }
        }
    }
}
