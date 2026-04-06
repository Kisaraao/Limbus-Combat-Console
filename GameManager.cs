namespace Limbus_Combat_Console
{
    public enum GameStatus
    {
        OnEnter,
        OnSelect,
        OnCombat,
        OnDamage,
        OnExit
    }
    public class GameManager
    {
        public int TurnCounter = 0;
        public GameStatus Status = GameStatus.OnEnter;

        public void Process()
        {
            Console.WriteLine(Status.ToString());
            switch (Status)
            {
                case GameStatus.OnEnter:
                    Console.WriteLine("回合数:[{0}]", TurnCounter);
                    Status = GameStatus.OnSelect;
                    break;
                case GameStatus.OnSelect:
                    Console.ReadKey();
                    Status = GameStatus.OnCombat;
                    break;
                case GameStatus.OnCombat:
                    Status = GameStatus.OnDamage;
                    break;
                case GameStatus.OnDamage:
                    Status = GameStatus.OnExit;
                    break;
                case GameStatus.OnExit:
                    TurnCounter++;
                    Status = GameStatus.OnEnter;
                    break;
                default:
                    break;
            }
        }
    }
}
