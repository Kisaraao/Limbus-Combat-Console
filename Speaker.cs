using System.Text.Json.Serialization;

namespace Limbus_Combat_Console
{
    public class SpeechType
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TriggerType Trigger { get; set; }
        public string Content { get; set; }
        public string? Audio { get; set; }
    }

    public static class Speaker
    {

        public static void Say(string name, string content, string path = "")
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[台词][{0}]:“{1}”", name, content);
            Console.ResetColor();
            if (path != string.Empty)
            {
                Audio speak = new Audio(path);
                speak.Play();
            }
        }
    }
}
