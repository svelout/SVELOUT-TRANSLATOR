using System.ComponentModel;
using Exiled.API.Interfaces;

namespace SVELOUT_TRANSLATOR
{
    public class Translation : ITranslation
    {
        [Description("REPLACE (COLOR) AND (TEXT)")]
        public string Message { get; set; } = "<align=right><size=50%><color=(COLOR)><b>(TEXT)</b></color></size></align>";
    }
}