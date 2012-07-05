namespace Testing.Data
{
    public class RandomInteger :
        RandomBase<int>
    {
        public RandomInteger() :
            base(0, int.MaxValue)
        {
        }

        public override int Get(int min, int max)
        {
            return Random.Local.Value.Next(min, max);
        }
    }
}