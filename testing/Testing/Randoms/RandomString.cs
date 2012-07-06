using System.Linq;

namespace Testing.Randoms
{
    public class RandomString :
        RandomBase<string, int>
    {
        DataResources _resources;

        public RandomString(DataResources resources) :
            base(0, 250)
        {
            _resources = resources;
        }

        public override string Get(int min, int max)
        {
            return new string(
                _resources.Chars.ManyOf(min, max).ToArray());
        }
    }
}