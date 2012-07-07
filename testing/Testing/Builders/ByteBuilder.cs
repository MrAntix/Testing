using Testing.Base;

namespace Testing.Builders
{
    public class ByteBuilder :
        ValueBuilderBase<byte, byte>
    {
        public ByteBuilder() :
            base(0, byte.MaxValue)
        {
        }

        public override byte BuildItem()
        {
            return (byte) Data.Random.Value.Next(Max, Min);
        }

        protected override ValueBuilderBase<byte, byte> CreateClone()
        {
            return new ByteBuilder();
        }
    }
}