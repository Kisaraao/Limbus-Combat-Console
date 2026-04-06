using System.Text.Json.Serialization;

namespace Limbus_Combat_Console
{
    public enum SkillType
    {
        Attack,
        Guard,
        Evade,
        Counter
    }

    public enum OperatorType
    {
        Add,
        Subtract,
        Multiply,
        Divide
    }

    public class SkillData
    {
        public int Id { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SkillType Type { get; set; }
        public string SinType { get; set; }
        public string AtkType { get; set; }
        public bool CanDuel { get; set; }
        public int SkillTier { get; set; }
        public string Name { get; set; }
        public int SkillLevelVariable { get; set; }
        public VariableStat Value { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OperatorType Operator { get; set; }
        public List<CoinData> CoinList { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine(" Id:[{0}]", Id);
            Console.WriteLine(" 技能类型:[{0}]", Type.ToString());
            Console.Write(" 罪孽属性:");
            Console.ForegroundColor = Global.Type.Sin.FirstOrDefault(s => s.Code == SinType)?.Color ?? ConsoleColor.White;
            Console.Write("[{0}]\n", Global.Type.Sin.FirstOrDefault(s => s.Code == SinType)?.Name ?? SinType);
            Console.ResetColor();
            Console.WriteLine(" 攻击类型:[{0}]", Global.Type.Attack.FirstOrDefault(s => s.Code == AtkType)?.Name ?? AtkType);
            Console.WriteLine(" 可拼点:[{0}]", CanDuel.ToString());
            Console.WriteLine(" 罪孽等级:[{0}]", SkillTier);
            Console.WriteLine(" 名称:[{0}]", Name);
            Console.WriteLine(" 技能等级变动:[{0}]", SkillLevelVariable);
            Console.WriteLine(" 数值:[基础值:{0}][变动值:{1}]", Value.Base, Value.Variable);
            Console.WriteLine(" 计算类型:[{0}]", Operator.ToString());
            Console.WriteLine(" 硬币列表:");
            int index = 1;
            foreach (var item in CoinList)
            {
                Console.WriteLine(" [{0}-{1}]", Global.CoinMap[item.Type], index);
                index++;
            }
        }
    }
}
