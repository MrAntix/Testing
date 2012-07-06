namespace Testing.Randoms
{
    public class RandomShort :
        RandomBase<short, short>
    {
        public RandomShort() :
            base(0, short.MaxValue)
        {
        }

        public override short Get(short min, short max)
        {
            return (short) Data.Random.Value.Next(min, max);
        }
    }
}