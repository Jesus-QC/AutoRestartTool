using Exiled.API.Interfaces;
using System.ComponentModel;

namespace ART
{
    public sealed class Config : IConfig
    {
        [Description("Is the plugin enabled? **YOU NEED MULTIADMIN**")]
        public bool IsEnabled { get; set; } = true;
        [Description("Rounds to restart the server (0 to restart the server every round)[-1 to disable it]")]
        public int RoundsNeededToRestart { get; set; } = 50;
        [Description("At this time server will restart every day (Example: 23:59) [-1 to disable it]")]
        public string TimeOfRestart { get; set; } = "23:59";
    }
}
