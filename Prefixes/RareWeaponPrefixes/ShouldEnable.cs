using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace SorbetReforges.Prefixes.RareWeaponPrefixes {
    public class ShouldEnable : ModConfig {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [DefaultValue(true)]
        public bool EnableRarePrefixes;

        internal float RarePrefixRelativeChance;

        [Range(1, 100)]
        [Slider]
        [DefaultValue(5)]
        public int RarePrefixRelativeChanceNew {
            get => (int) (RarePrefixRelativeChance * 100 + 0.999);
            set => RarePrefixRelativeChance = (float) value / 100f;
        }
    }
}
