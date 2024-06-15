using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SorbetReforges.VanillaTweaks {
    internal class RemoveVanillaPrefixes : GlobalItem {
        public override bool AllowPrefix(Item item, int pre) {
            return !(
                pre == PrefixID.Legendary
                || pre == PrefixID.Unreal
                || pre == PrefixID.Mythical
            );
        }
    }
}
