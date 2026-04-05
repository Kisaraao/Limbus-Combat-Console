using System.Text.Json;

namespace Limbus_Combat_Console
{
    public class CodeToName { public string Code { get; set; } public string Name { get; set; } }
    public class Sin : CodeToName { public ConsoleColor Color { get; set; } }

    public class TypeData
    {
        public List<CodeToName> Attack { get; set; }
        public List<Sin> Sin { get; set; }
    }

    public static class Global
    {
        public static TypeData Type { get; set; }
    }

    public static class JsonParser
    {
        public static void LoadType(string path)
        {
            Global.Type = JsonSerializer.Deserialize<TypeData>(File.ReadAllText(path));
        }

        public static Character LoadCharacter(string path)
        {
            return JsonSerializer.Deserialize<Character>(File.ReadAllText(path)); ;
        }
    }

    class Program
    {
        static public void PrintSinAttributes()
        {
            Console.Write("全局罪孽属性：");
            foreach (var item in Global.Type.Sin)
            {
                Console.ForegroundColor = item.Color;
                Console.Write("[" + item.Name + "]");
            }
            Console.Write("\n");
            Console.ResetColor();
        }

        static public void PrintAttackAttributes()
        {
            Console.Write("全局攻击属性：");
            foreach (var item in Global.Type.Attack)
            {
                Console.Write("[" + item.Name + "]");
            }
            Console.Write("\n");
        }

        static void Main()
        {
            JsonParser.LoadType("../../../json/Type.json");
            Character player = JsonParser.LoadCharacter("../../../json/Callisto.json");
            PrintAttackAttributes();
            PrintSinAttributes();
            player.PrintInfos();
            Console.ReadKey();
        }
    }
}