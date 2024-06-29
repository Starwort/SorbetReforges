using System.Collections.Generic;
using Terraria.ID;
using Terraria.Localization;
using Terraria;
using Terraria.ModLoader;

namespace SorbetReforges.VanillaTweaks {
    internal class TweakMeleeSpeedPrefixes : GlobalItem {
        public override void Load() {
            On_Player.GrantPrefixBenefits += modify;
        }

        private static void modify(On_Player.orig_GrantPrefixBenefits orig, Player self, Item item) {
            float modifier;
            switch (item.prefix) {
                case PrefixID.Wild:
                    modifier = 0.02f;
                    goto UpdateTooltip;
                case PrefixID.Rash:
                    modifier = 0.04f;
                    goto UpdateTooltip;
                case PrefixID.Intrepid:
                    modifier = 0.06f;
                    goto UpdateTooltip;
                case PrefixID.Violent:
                    modifier = 0.08f;
                UpdateTooltip:
                    self.GetAttackSpeed(DamageClass.Melee) += modifier;
                    break;
                default:
                    orig(self, item);
                    break;
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
            int modifier;
            switch (item.prefix) {
                case PrefixID.Wild:
                    modifier = 2;
                    goto UpdateTooltip;
                case PrefixID.Rash:
                    modifier = 4;
                    goto UpdateTooltip;
                case PrefixID.Intrepid:
                    modifier = 6;
                    goto UpdateTooltip;
                case PrefixID.Violent:
                    modifier = 8;
                UpdateTooltip:
                    foreach (var line in tooltips) {
                        if (line.Name == "PrefixAccMeleeSpeed") {
                            line.Text = $"+{modifier}" + Language.GetText("LegacyTooltip.47");
                        }
                    }
                    break;
            }
        }
    }
}
