namespace Limbus_Combat_Console
{
    public static class RandomManager
    {
        public static Random rand = new Random();

        public static int Range(int Min, int Max)
        {
            return rand.Next(Min, Max);
        }

        public static bool Posibility(double Value)
        {
            return rand.NextDouble() <= Value;
        }

        public static int Weight(List<int> Weight)
        {
            int total = 0;
            foreach (var item in Weight)
            {
                total += item;
            }
            int index = 0;
            int sum = 0;
            int roll = rand.Next(0, total);
            foreach (var item in Weight)
            {
                sum += item;
                if (roll < sum) { return index; }
                index++;
            }
            throw new InvalidOperationException("ERROR 权重列表不能为空。");
        }
    }
}
