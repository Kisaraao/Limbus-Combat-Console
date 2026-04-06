namespace Limbus_Combat_Console
{
    class Program
    {
        static void Main()
        {
            JsonParser.LoadType("../../../json/Type.json");
            CharacterData player = JsonParser.LoadCharacterData("../../../json/Callisto.json");
            //Global.PrintAttackAttributes();
            //Global.PrintSinAttributes();
            player.PrintInfos();
            //Speaker.Say("环指 父辈 - 卡利斯托", "你听见了吗？那由提比娅的一对肱骨与二十四根肋骨奏响的旋律！", "../../../audio/tibia.ogg");
            CharacterInstance test = new CharacterInstance(player);
            ActionSlot slot = new ActionSlot(test);
            slot.ReFill();
            GameManager manager = new GameManager();
            while (true)
            {
                manager.Process();
            }
            Console.ReadKey();
        }
    }
}