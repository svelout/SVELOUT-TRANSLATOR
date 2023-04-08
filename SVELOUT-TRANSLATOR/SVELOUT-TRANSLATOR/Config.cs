using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;

namespace SVELOUT_TRANSLATOR
{
    public class Config : IConfig
    {
        [Description("Текущее состояние плагина")]
        public bool IsEnabled { get; set; } = true;

        [Description("Дебаг плагина")] 
        public bool Debug { get; set; } = false;

        [Description("Отправление логов вебхукам")]
        public bool Webhook { get; set; } = false;

        [Description("Список вебхуков которым будут транслироваться логи(Если они включены) ")]
        public List<string> WebHooks { get; set; } = new()
        {
            "YOUR WEBHOOKS",
        };

        [Description("Сообщение при входе игрока на сервер, %PLAYER%-это имя игрока, его вставляем в нужный контекст")]
        public bool JoinTranslator { get; set; } = true;
        public string JoinMessage { get; set; } = "%PLAYER% вошел на сервер";

        [Description("Сообщение при выходе игрока из сервера, %PLAYER%-это имя игрока, его вставляем в нужный контекст")]
        public bool LeftTranslator { get; set; } = true;
        public string LeftMessage { get; set; } = "%PLAYER% вышел из сервера";

        [Description("Сообщение после начала раунда, %DATETIME% это время которое установлено на устройстве, на котором запущен сервер")]
        public bool RoundStartedTranslator { get; set; } = false;

        public string RoundStartedMessage { get; set; } = "Раунд начался ровно в %DATETIME%";
        
        [Description("Сообщение после конца раунда, %DATETIME% это время которое установлено на устройстве, на котором запущен сервер.%TIME% - время до рестарта раунда")]
        public bool RoundEndedTranslator{ get; set; } = false;
        public string RoundEndedMessage { get; set; } = "Раунд закончился ровно в %DATETIME%, рестарт раунда через %TIME% секунд";

    }
}