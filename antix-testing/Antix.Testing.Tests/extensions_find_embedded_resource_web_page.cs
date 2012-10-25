using System.Diagnostics;
using System.IO;
using Xunit;

namespace Antix.Testing.Tests
{
    public class extensions_find_embedded_resource_web_page
    {
        readonly string _webPage;

        public extensions_find_embedded_resource_web_page()
        {
            using (var stream = GetType().Assembly.GetManifestResourceStream("Antix.Testing.Tests.Resources.WebPage.htm"))
            {
                Debug.Assert(stream != null, "stream != null");
                _webPage = new StreamReader(stream).ReadToEnd();
            }
        }

        [Fact]
        void get_a_web_page()
        {
            Assert.Equal(_webPage, GetType().FindResourceString("WebPage.htm"));
        }
    }
}