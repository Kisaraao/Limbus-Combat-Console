using System.Reflection.Emit;
using System.Text.Json.Nodes;
using System.Xml.Linq;

namespace Limbus_Combat_Console
{

    public static class Global
    {
        public static Dictionary<string, ConsoleColor> SinType { get; set; }
        public static List<string> AttackType { get; set; }
    }

    class JsonParser
    {
        public void LoadSinType(string path)
        {
            Global.SinType = new Dictionary<string, ConsoleColor>();
            JsonNode root = JsonNode.Parse(File.ReadAllText(path));
            foreach (var item in root["Sin"] as JsonArray) 
            {
                Global.SinType.Add(item["Name"].GetValue<string>(), (ConsoleColor)item["Color"].GetValue<int>());
            }
        }
        
        public void LoadAttackType(string path)
        {
            Global.AttackType = new List<string>();
            JsonNode root = JsonNode.Parse(File.ReadAllText(path));
            foreach(var item in root["Attack"] as JsonArray){ Global.AttackType.Add(item.GetValue<string>()); }
        }

        public Character LoadCharacter(string path)
        {
            Character character = new Character();
            JsonNode root = JsonNode.Parse(File.ReadAllText(path));
            character.Name = root["Name"].GetValue<string>();
            character.Level = root["Level"].GetValue<int>();
            foreach(var item in root["Tags"] as JsonArray)
            {
                character.Tags.Add(item.GetValue<string>());
            }
            character.HealthRange = (root["Health"][0]["Min"].GetValue<int>(), root["Health"][0]["Max"].GetValue<int>());
            character.HealthInitial = root["Health"][0]["Initial"].GetValue<int>();
            character.SanityRange = (root["Sanity"][0]["Min"].GetValue<int>(), root["Sanity"][0]["Max"].GetValue<int>());
            character.HealthInitial = root["Sanity"][0]["Initial"].GetValue<int>();
            character.SpeedRange = (root["Speed"][0]["Min"].GetValue<int>(), root["Speed"][0]["Max"].GetValue<int>());
            character.DefenseBase = root["Defense"][0]["Base"].GetValue<int>();
            character.DefenseVariable = root["Defense"][0]["Variable"].GetValue<int>();
            foreach(var item in root["Confusion"] as JsonArray)
            {
                character.Confusions.Enqueue(item.GetValue<double>());
            }
            return character;
        }
    }

    class Program
    {
        static public void PrintSinAttributes()
        {
            Console.Write("全局罪孽属性：");
            foreach (var item in Global.SinType)
            {
                Console.ForegroundColor = item.Value;
                Console.Write("[" + item.Key + "]");
            }
            Console.Write("\n");
            Console.ResetColor();
        }

        static public void PrintAttackAttributes()
        {
            Console.Write("全局攻击属性：");
            foreach (var item in Global.AttackType)
            {
                Console.Write("[" + item + "]");
            }
            Console.Write("\n");
        }

        static void Main()
        {
            JsonParser parser = new JsonParser();
            parser.LoadSinType("../../../json/Type.json");
            parser.LoadAttackType("../../../json/Type.json");
            Character player = parser.LoadCharacter("../../../json/Callisto.json");
            
            PrintSinAttributes();
            PrintAttackAttributes();
            player.PrintInfos();
        }
    }
}