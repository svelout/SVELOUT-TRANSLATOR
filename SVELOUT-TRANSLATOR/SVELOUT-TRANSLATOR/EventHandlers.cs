using System;
using Exiled.Events.EventArgs.Player;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;

namespace SVELOUT_TRANSLATOR
{
    public class EventHandlers
    {
        public void OnPlayerJoined(JoinedEventArgs ev)
        {
            string join_text = Plugin.Instance.Config.JoinMessage;
            try
            {
                join_text = join_text.Replace("%PLAYER%", ev.Player.Nickname);
            }    
            catch {join_text = join_text;}
            foreach (Player p in Player.List)
            {
                string message = Plugin.Instance.Translation.Message
                    .Replace("(COLOR)", p.Role.Color.ToHex())
                    .Replace("(TEXT)", join_text);
                p.Broadcast(3, message);
            }
            if (Plugin.Instance.Config.Webhook)
            {
                foreach (string url in Plugin.Instance.Config.WebHooks)
                {
                    WebHook webhook = new(url);
                    webhook.SendMessage(join_text);
                }
            }
        }

        public void OnPlayerLeft(LeftEventArgs ev)
        {
            string left_text = Plugin.Instance.Config.LeftMessage;
            try
            {
                left_text = left_text.Replace("%PLAYER%", ev.Player.Nickname);
            }
            catch{left_text=left_text;}
            foreach (Player p in Player.List)
            {
                string message = Plugin.Instance.Translation.Message
                    .Replace("(COLOR)", p.Role.Color.ToHex())
                    .Replace("(TEXT)", left_text);
                p.Broadcast(3, message);
            }
            if (Plugin.Instance.Config.Webhook)
            {
                foreach (string url in Plugin.Instance.Config.WebHooks)
                {
                    WebHook webhook = new(url);
                    webhook.SendMessage(left_text);
                }
            }
        }

        public void OnRoundStarted()
        {
            string rs_message = Plugin.Instance.Config.RoundStartedMessage
                .Replace("%DATETIME%",DateTime.Now.ToString("HH:mm:ss"));
            foreach (Player p in Player.List)
            {
                string message = Plugin.Instance.Translation.Message
                    .Replace("(COLOR)", p.Role.Color.ToHex())
                    .Replace("(TEXT)", rs_message);
                p.Broadcast(3, message);
            }
            if (Plugin.Instance.Config.Webhook)
            {
                foreach (string url in Plugin.Instance.Config.WebHooks)
                {
                    WebHook webhook = new(url);
                    webhook.SendMessage(rs_message);
                }
            }
        }

        public void OnRoundEnded(RoundEndedEventArgs ev)
        {
            string re_message = Plugin.Instance.Config.RoundEndedMessage
                .Replace("%DATETIME%", DateTime.Now.ToString("HH:mm:ss"))
                .Replace("%TIME%", ev.TimeToRestart.ToString());
            foreach (Player p in Player.List)
            {
                string message = Plugin.Instance.Translation.Message
                    .Replace("(COLOR)", p.Role.Color.ToHex())
                    .Replace("(TEXT)", re_message);
                p.Broadcast(3, message);
            }
            if (Plugin.Instance.Config.Webhook)
            {
                foreach (string url in Plugin.Instance.Config.WebHooks)
                {
                    WebHook webhook = new(url);
                    webhook.SendMessage(re_message);
                }
            }
        }
    }
}