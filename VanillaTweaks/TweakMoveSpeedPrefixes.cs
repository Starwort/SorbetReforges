using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace SorbetReforges.VanillaTweaks {
    internal class TweakMoveSpeedPrefixes : GlobalItem {
        public override void Load() {
            On_Player.GrantPrefixBenefits += modify;
        }

        private static void modify(On_Player.orig_GrantPrefixBenefits orig, Player self, Item item) {
            float modifier;
            switch (item.prefix) {
                case PrefixID.Brisk:
                    modifier = 1.01f;
                    goto UpdateSpeed;
                case PrefixID.Fleeting:
                    modifier = 1.02f;
                    goto UpdateSpeed;
                case PrefixID.Hasty:
                    modifier = 1.03f;
                    goto UpdateSpeed;
                case PrefixID.Quick:
                    modifier = 1.04f;
                UpdateSpeed:
                    self.runAcceleration *= modifier;
                    self.maxRunSpeed *= modifier;
                    self.accRunSpeed *= modifier;
                    self.runSlowdown *= modifier;
                    self.moveSpeed += modifier - 1f;
                    break;
                default:
                    orig(self, item);
                    break;
            }
        }
    }
}
