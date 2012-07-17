using System;
using System.Linq;
using Xunit;

namespace Testing.Tests
{
    public class data_using_the_static_test_data
    {
        [Fact]
        public void static_data_text_gets_random_letters()
        {
            var words = TestData.Text
                .WithLetters()
                .WithRange(1, 15)
                .Build(10)
                .Items.ToArray();

            Assert.NotNull(words);

            foreach (var word in words)
            {
                Assert.True(word.All(TestData.Resources.Letters.Contains));
                Console.WriteLine(word);
            }

            Assert.Equal(10, words.Count());
        }

        [Fact]
        public void static_data_text_gets_random_numbers()
        {
            var words = TestData.Text
                .WithNumbers()
                .WithRange(1, 15)
                .Build(10)
                .Items.ToArray();

            Assert.NotNull(words);

            foreach (var word in words)
            {
                Assert.True(word.All(TestData.Resources.Numbers.Contains));
                Console.WriteLine(word);
            }

            Assert.Equal(10, words.Count());
        }

        [Fact]
        public void static_data_text_gets_random_numbers_and_letters()
        {
            var words = TestData.Text
                .WithNumbersAndLetters()
                .WithRange(1, 15)
                .Build(10)
                .Items.ToArray();

            Assert.NotNull(words);

            foreach (var word in words)
            {
                Assert.True(word.All(
                    TestData.Resources.Letters
                        .Concat(TestData.Resources.Numbers)
                        .Contains));
                Console.WriteLine(word);
            }

            Assert.Equal(10, words.Count());
        }
    }
}