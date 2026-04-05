namespace Limbus_Combat_Console
{
    public class RangedValue { public int Min { get; set; } public int Max { get; set; } public int Initial { get; set; } }
    public class VariableStat { public int Base { get; set; } public int Variable { get; set; } }
    public class ResistData { public Dictionary<string, double> Attack { get; set; } public Dictionary<string, double> Sin { get; set; } }
    public class SkillRef { public int Id { get; set; } public int Count { get; set; } }
    public class Character
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public List<string> Tags { get; set; }
        public RangedValue Health { get; set; }
        public RangedValue Sanity { get; set; }
        public RangedValue Speed { get; set; }
        public VariableStat Defense { get; set; }
        public List<double> Confusion { get; set; }
        public ResistData Resists { get; set; }
        public List<SkillRef> Skills { get; set; }

        public void PrintInfos()
        {
            Console.WriteLine("名称：{0}\n等级：{1}", Name, Level);
            Console.Write("特性关键词：");
            foreach (var item in Tags)
            {
                Console.Write("[{0}]", item);
            }
            Console.WriteLine("\n血量：[初始值：{0}][上下限：<{1}>-<{2}>]", Health.Initial, Health.Min, Health.Max);
            Console.WriteLine("理智：[初始值：{0}][上下限：<{1}>-<{2}>]", Sanity.Initial, Sanity.Min, Sanity.Max);
            Console.WriteLine("速度：[上下限：<{0}>-<{1}>]", Speed.Min, Speed.Max);
            Console.WriteLine("防御等级：[基础值：{0}][变动值：{1}]", Defense.Base, Defense.Variable);
            if (Confusion.Count > 0) { Console.Write("混乱阈值："); }
            foreach (var item in Confusion) { Console.Write("[{0}]", item); }
            Console.Write("\n物理属性抗性：");
            foreach (var item in Resists.Attack)
            { 
                Console.Write("[{0}：x{1}]", Global.Type.Attack.FirstOrDefault(s => s.Code == item.Key)?.Name ?? item.Key, item.Value);
            }
            Console.Write("\n罪孽属性抗性：");
            foreach (var item in Resists.Sin)
            {
                ConsoleColor color = Global.Type.Sin.FirstOrDefault(s => s.Code == item.Key)?.Color ?? ConsoleColor.White;
                Console.ForegroundColor = color;
                Console.Write("[{0}：x{1}]", Global.Type.Sin.FirstOrDefault(s => s.Code == item.Key)?.Name ?? item.Key, item.Value);
            }
            Console.ResetColor();
        }
    }
}
