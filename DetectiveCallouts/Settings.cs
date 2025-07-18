using Rage;
using System.Windows.Forms;

namespace DetectiveCallouts
{
    internal static class Settings
    {
        public static readonly InitializationFile ini = new InitializationFile(@"Plugins\LSPDFR\DetectiveCallouts.ini");

        // Callout toggles
        public static readonly bool DesertMurder = ini.ReadBoolean("Callouts", "DesertMurder", true);

        // Keybinds
        public static readonly Keys DialogueKey = ini.ReadEnum<Keys>("Keybinds", "DialogueKey", Keys.Y);
        public static readonly Keys EndCallout = ini.ReadEnum<Keys>("Keybinds", "EndCallout", Keys.End);

        // Preferences
        public static readonly bool UseBluelineAudio = ini.ReadBoolean("Preferences", "UseBluelineDispatchAudio", false);

        // Vehicle model names
        public static readonly string PoliceVehicle1 = ini.ReadString("Vehicles", "PoliceVehicle1", "police");
        public static readonly string PoliceVehicle2 = ini.ReadString("Vehicles", "PoliceVehicle2", "police2");
        public static readonly string PoliceVehicle3 = ini.ReadString("Vehicles", "PoliceVehicle3", "fbi");
        public static readonly string PoliceVehicle4 = ini.ReadString("Vehicles", "PoliceVehicle4", "fbi2");
    }
}
