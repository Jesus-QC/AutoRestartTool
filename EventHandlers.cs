using System;
using MEC;
using System.Diagnostics;
using System.Collections.Generic;
using Exiled.API.Features;

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
            if (plugin.Config.TimeOfRestart != "-1") { Timing.RunCoroutine(TimeChecker()); }
            if (Rounds >= plugin.Config.RoundsNeededToRestart && plugin.Config.RoundsNeededToRestart > -1)
            {
                Timing.CallDelayed(1.5f, () => { Process.GetCurrentProcess().Kill(); });
            }
        }

        IEnumerator<float> TimeChecker()
        {
            for (; ; )
            {
                if (DateTime.Now.ToShortTimeString() == plugin.Config.TimeOfRestart)
                {
                    Round.Restart();
                    Timing.CallDelayed(1.5f, () => { Process.GetCurrentProcess().Kill(); });
                }
                else
                {
                    yield return Timing.WaitForSeconds(60);
                }
            }
        }
    }
}