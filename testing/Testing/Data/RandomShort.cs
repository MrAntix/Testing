namespace Testing.Data
{
    public class RandomShort :
        RandomBase<short>
    {
        public RandomShort() :
            base(0, short.MaxValue)
        {
        }

        public override short Get(short min, short max)
        {
            return (short) Random.Local.Value.Next(min, max);
        }
    }
}