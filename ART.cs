using Exiled.API.Features;
using MEC;
using System;
using System.Collections.Generic;

namespace ART
{
    public class ART : Plugin<Config>
    {
        public override string Name { get; } = "ART";
        public override string Author { get; } = "JesusQC";
        public override string Prefix { get; } = "AutoRestartingTool";
        private EventHandlers EventHandlers;
        public override void OnEnabled()
        {
            base.OnEnabled();
            EventHandlers = new EventHandlers(this) { Rounds = 0 };
            if (Config.TimeOfRestart != "-1")
                Timing.RunCoroutine(TimeChecker());
            Exiled.Events.Handlers.Server.RestartingRound += EventHandlers.OnRestarting;
        }
        public override void OnDisabled()
        {
            base.OnDisabled();
            Exiled.Events.Handlers.Server.RestartingRound -= EventHandlers.OnRestarting;
            EventHandlers = null;
        }
        IEnumerator<float> TimeChecker()
        {
            for (; ; )
            {
                if (DateTime.Now.ToShortTimeString() == Config.TimeOfRestart)
                {
                GameCore.Console.singleton.TypeCommand("/sr");
                }
                yield return Timing.WaitForSeconds(60);
            }
        }
    }
}
