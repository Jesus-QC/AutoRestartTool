using System.Diagnostics;
using MEC;

namespace ART
{
    internal class EventHandlers
    {
        private readonly ART plugin;
        public EventHandlers(ART plugin) => this.plugin = plugin;
        public int Rounds;
        public void OnRestarting()
        {
            Rounds++;
            if (Rounds >= plugin.Config.RoundsNeededToRestart && plugin.Config.RoundsNeededToRestart > -1)
                Timing.CallDelayed(1.5f, () => Process.GetCurrentProcess().Kill());
        }        
    }
}
