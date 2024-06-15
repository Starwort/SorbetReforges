using Terraria.ModLoader;

namespace SorbetReforges {
    public class SorbetReforges : Mod {
        private static Mod _instance = null!;
        internal static Mod Instance = _instance ??= ModContent.GetInstance<SorbetReforges>();
    }
}
