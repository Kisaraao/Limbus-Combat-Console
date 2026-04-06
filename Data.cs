namespace Limbus_Combat_Console
{
    public class RangedValue 
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public int Initial { get; set; } 
    }
    public class VariableStat 
    {
        public int Base { get; set; } 
        public int Variable { get; set; }
    }

    public class CodeToName 
    { 
        public string Code { get; set; } 
        public string Name { get; set; } 
    }
    public class Sin : CodeToName 
    { 
        public ConsoleColor Color { get; set; } 
    }

    public class TypeData
    {
        public List<CodeToName> Attack { get; set; }
        public List<Sin> Sin { get; set; }
    }

    public enum TriggerType
    {
        OnTurnBegin,     // 回合开始
        OnUse,           // 使用技能
        OnRollCoin,      // 投币
        OnBeforeCombat,  // 拼点前
        OnCombatWin,     // 拼点胜利
        OnCombatLose,    // 拼点失败
        OnAfterCombat,   // 拼点后
        OnBeforeHit,     // 攻击前
        OnHit,           // 击中
        OnAfterHit,      // 攻击后
        OnTurnEnd        // 回合结束
    }

    public static class Global
    {
        public static TypeData Type { get; set; }

        public static Dictionary<CoinType, string> CoinMap = new Dictionary<CoinType, string>()
        {
            [CoinType.Normal] = "●",
            [CoinType.Unbreakable] = "■"
        };

        public static Dictionary<int, SkillData> SkillPool = new Dictionary<int, SkillData>();

        public static void PrintSinAttributes()
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

        public static void PrintAttackAttributes()
        {
            Console.Write("全局攻击属性：");
            foreach (var item in Global.Type.Attack)
            {
                Console.Write("[" + item.Name + "]");
            }
            Console.Write("\n");
        }

        public static Dictionary<int, string> SkillTierMap = new Dictionary<int, string>()
        {
            [1] = "<>",
            [2] = "[]",
            [3] = "「」"
        };

        public static void PrintSkillName(int Id)
        {
            Console.ForegroundColor = Global.Type.Sin.FirstOrDefault(s => s.Code == SkillPool[Id].SinType)?.Color ?? ConsoleColor.White;
            Console.Write(SkillTierMap[SkillPool[Id].SkillTier][0]);
            Console.Write("{0}", SkillPool[Id].Name);
            Console.Write(SkillTierMap[SkillPool[Id].SkillTier][1]);
            Console.ResetColor();
        }
    }
}
