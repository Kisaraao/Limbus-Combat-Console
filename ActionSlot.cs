using NAudio.Codecs;
using System.Data;
using System.Runtime.CompilerServices;

namespace Limbus_Combat_Console
{
    public class ActionSlot
    {
        public CharacterInstance Owner { get; }
        public int SkillId { get; set; }
        public ActionSlot(CharacterInstance Owner) 
        {
            this.Owner = Owner;
        }
        public int DashBoardSize = 10;
        public List<int> DashBoard = new List<int>();
        public void ReFill()
        {
            List<int> weights = new List<int>();
            foreach (var item in Owner.Data.Skills)
            {
                weights.Add(item.Count);
            }
            while (DashBoard.Count < DashBoardSize)
            {
                int rand = RandomManager.Weight(weights);
                DashBoard.Add(rand);
            }
            foreach(var item in DashBoard)
            {
                Global.PrintSkillName(item);
                Console.Write("\n");
                //Console.WriteLine(Global.SkillPool[item].Name);
            }
        }
    }
}
