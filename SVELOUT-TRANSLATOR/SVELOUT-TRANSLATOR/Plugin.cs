using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;

namespace SVELOUT_TRANSLATOR 
{
    public class Plugin : Plugin<Config, Translation>
    {
        public override string Author => "SveloutDevelop";
        public override string Name => "SveloutTranslator";
        public override string Prefix => "ST";

        public static Plugin Instance;
        private EventHandlers _eh;

        public override void OnEnabled()
        {
            Instance = this;
            OnRegEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Instance = null;
            OnUnRegEvents();
            base.OnDisabled();
        }

        public void OnRegEvents()
        {
            _eh = new();
            if (Plugin.Instance.Config.JoinTranslator) Player.Joined += _eh.OnPlayerJoined;
            else Player.Joined -= _eh.OnPlayerJoined;
            if (Plugin.Instance.Config.LeftTranslator) Player.Left += _eh.OnPlayerLeft;
            else Player.Left -= _eh.OnPlayerLeft;
            if (Plugin.Instance.Config.RoundStartedTranslator) Server.RoundStarted += _eh.OnRoundStarted;
            else Server.RoundStarted -= _eh.OnRoundStarted;
            if (Plugin.Instance.Config.RoundEndedTranslator) Server.RoundEnded += _eh.OnRoundEnded;
            else Server.RoundEnded -= _eh.OnRoundEnded;
        }

        public void OnUnRegEvents()
        {
            _eh = null;
            Player.Joined -= _eh.OnPlayerJoined;
            Player.Left -= _eh.OnPlayerLeft;
            Server.RoundStarted -= _eh.OnRoundStarted;
            Server.RoundEnded -= _eh.OnRoundEnded;
        }
    }
}