namespace Testing.Randoms
{
    public class RandomByte :
        RandomBase<byte, byte>
    {
        public RandomByte() :
            base(0, byte.MaxValue)
        {
        }

        public override byte Get(byte min, byte max)
        {
            return (byte) Data.Random.Value.Next(min, max);
        }
    }
}