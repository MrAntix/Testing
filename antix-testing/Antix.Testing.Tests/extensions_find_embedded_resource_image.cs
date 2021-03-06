using System.Diagnostics;
using System.Drawing;
using Xunit;

namespace Antix.Testing.Tests
{
    public class extensions_find_embedded_resource_image
    {
        readonly Size _imageSize;

        public extensions_find_embedded_resource_image()
        {
            using (var stream = GetType().Assembly.GetManifestResourceStream("Antix.Testing.Tests.Resources.Image.png"))
            {
                Debug.Assert(stream != null, "stream != null");
                _imageSize = Image.FromStream(stream).Size;
            }
        }

        [Fact]
        void get_an_image()
        {
            using (var image = GetType().FindResourceImage("Image.png"))
            {
                Assert.Equal(_imageSize, image.Size);
            }
        }
    }
}