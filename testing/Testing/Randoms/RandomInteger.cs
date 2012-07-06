namespace Testing.Randoms
{
    public class RandomInteger :
        RandomBase<int, int>
    {
        public RandomInteger() :
            base(0, int.MaxValue)
        {
        }

        public override int Get(int min, int max)
        {
            return Data.Random.Value.Next(min, max);
        }
    }
}