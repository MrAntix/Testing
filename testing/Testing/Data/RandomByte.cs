namespace Testing.Data
{
    public class RandomByte :
        RandomBase<byte>
    {
        public RandomByte() :
            base(0, byte.MaxValue)
        {
        }

        public override byte Get(byte min, byte max)
        {
            return (byte) Random.Local.Value.Next(min, max);
        }
    }
}