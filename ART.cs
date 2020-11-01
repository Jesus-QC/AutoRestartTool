using Exiled.API.Features;

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
            Exiled.Events.Handlers.Server.RestartingRound += EventHandlers.OnRestarting;
        }
        public override void OnDisabled()
        {
            base.OnDisabled();
            Exiled.Events.Handlers.Server.RestartingRound -= EventHandlers.OnRestarting;
            EventHandlers = null;
        }
    }
}
