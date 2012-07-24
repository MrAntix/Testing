using System.Diagnostics;
using System.Drawing;
using Xunit;

namespace Testing.Tests
{
    public class extensions_find_embedded_resource_image
    {
        Size _imageSize;

        public extensions_find_embedded_resource_image()
        {

            using (var stream = GetType().Assembly.GetManifestResourceStream("Testing.Tests.Resources.Image.png"))
            {
                Debug.Assert(stream != null, "stream != null");
                _imageSize = Image.FromStream(stream).Size;
            }
        }

        [Fact]
        void get_an_image()
        {
            Assert.Equal(_imageSize, GetType().FindResourceImage("Image.png").Size);
        }
    }
}