using System.Text.Json.Serialization;

namespace Limbus_Combat_Console
{
    public enum CoinType
    {
        Normal,
        Unbreakable
    }

    public class CoinData
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CoinType Type { get; set; }
        public List<SpeechType> Speech { get; set; }
    }
}
