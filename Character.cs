using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Limbus_Combat_Console
{
    class Character
    {
        // 名称
        public string Name { get; set; }
        // 等级
        public int Level { get; set; }
        // 特性关键词
        public List<String>? Tags { get; set; } = new List<String>();
        // 血量
        public int HealthInitial { get; set; }
        public (int min, int max) HealthRange { get; set; }
        // 理智
        public int SanityInitial { get; set; }
        public (int min, int max) SanityRange { get; set; }
        // 防御等级
        public int DefenseBase { get; set; }
        public int DefenseVariable { get; set; }
        // 混乱阈值
        public Queue<double> Confusions { get; set; } = new Queue<double>();
        // 速度
        public (int min, int max) SpeedRange { get; set; }
        // 攻击属性抗性
        public Dictionary<string, double>? AttackAttrResist { get; set; } = new Dictionary<string, double>();
        // 罪孽属性抗性
        public Dictionary<string, double>? SinAttrResist { get; set; } = new Dictionary<string, double>();
    
        public void PrintInfos()
        {
            Console.WriteLine("名称：{0}\n等级：{1}", Name, Level);
            Console.Write("特性关键词：");
            foreach (var item in Tags)
            {
                Console.Write("[{0}]", item);
            }
            Console.WriteLine("\n血量：[初始值：{0}][上下限：<{1}>-<{2}>]", HealthInitial, HealthRange.min, HealthRange.max);
            Console.WriteLine("理智：[初始值：{0}][上下限：<{1}>-<{2}>]", SanityInitial, SanityRange.min, SanityRange.max);
            Console.WriteLine("速度：[上下限：<{0}>-<{1}>]", SpeedRange.min, SpeedRange.max);
            Console.WriteLine("防御等级：[基础值：{0}][变动值：{1}]", DefenseBase, DefenseVariable);
            if (Confusions.Count > 0) { Console.Write("混乱阈值：", Math.Round(Confusions.Peek() * HealthRange.max)); }
            foreach (var item in Confusions) { Console.Write("[{0}]", item); }
            //Console.Write("物理属性抗性：");
            //foreach(var item in AttackAttrResist){ Console.Write("[{0}：x{1}]", item.Key, item.Value); }
            //Console.Write("\n罪孽属性抗性：");
            //foreach (var item in SinAttrResist) { Console.Write("[{0}：x{1}]", item.Key, item.Value); }
        }
    }
}
