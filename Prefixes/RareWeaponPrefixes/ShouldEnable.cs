using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace SorbetReforges.Prefixes.RareWeaponPrefixes {
    internal class ShouldEnable : ModConfig {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [DefaultValue(true)]
        public bool EnableRarePrefixes;

        [Range(0.01f, 1f)]
        [Increment(0.01f)]
        [DefaultValue(0.05f)]
        public float RarePrefixRelativeChance;
    }
}
