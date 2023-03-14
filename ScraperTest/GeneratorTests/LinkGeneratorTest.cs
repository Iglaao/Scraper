using Scraper.Data;
using Scraper.Generator;

namespace ScraperTest.GeneratorTests
{
    public class LinkGeneratorTest
    {
        [Theory]
        [InlineData("https://example.server.com/test/folder/0/website.com_100", "https://example.server.com/test/folder/#/website.com_100")]
        [InlineData("https://example.server.com/test/folder/9/website.com_109", "https://example.server.com/test/folder/#/website.com_109")]
        [InlineData("https://example.server.com/test/folder/5/website.com_105", "https://example.server.com/test/folder/#/website.com_105")]
        public void GetSignleLinksTheory(string expected, string input, int amount = 1)
        {
            var link = LinkGenerator.GetLinks(input, amount);
            Assert.Equal(expected, link.First().Url);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void GetLinksTheory(List<Link> dataList, string input, int amount)
        {
            bool expected = true;
            var links = LinkGenerator.GetLinks(input, amount);

            bool actual = links.SequenceEqual(dataList);

            Assert.Equal(expected, actual);
        }
        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[]
                {
                    new List<Link>()
                    {
                        new Link(){Id = 1, Url = "https://example.server.com/test/folder/0/website.com_100"},
                        new Link(){Id = 2, Url = "https://example.server.com/test/folder/1/website.com_101"},
                        new Link(){Id = 3, Url = "https://example.server.com/test/folder/2/website.com_102"},
                        new Link(){Id = 4, Url = "https://example.server.com/test/folder/3/website.com_103"},
                        new Link(){Id = 5, Url = "https://example.server.com/test/folder/4/website.com_104"},
                        new Link(){Id = 6, Url = "https://example.server.com/test/folder/5/website.com_105"},
                        new Link(){Id = 7, Url = "https://example.server.com/test/folder/6/website.com_106"},
                        new Link(){Id = 8, Url = "https://example.server.com/test/folder/7/website.com_107"},
                        new Link(){Id = 9, Url = "https://example.server.com/test/folder/8/website.com_108"},
                        new Link(){Id = 10, Url = "https://example.server.com/test/folder/9/website.com_109"},
                        new Link(){Id = 11, Url = "https://example.server.com/test/folder/0/website.com_110"},
                        new Link(){Id = 12, Url = "https://example.server.com/test/folder/1/website.com_111"},
                    },
                    "https://example.server.com/test/folder/#/website.com_100",
                    12
                },
                new object[]
                {
                    new List<Link>()
                    {
                        new Link(){Id = 1, Url = "https://example.server.com/test/folder/9/website.com_109"},
                        new Link(){Id = 2, Url = "https://example.server.com/test/folder/0/website.com_110"},
                        new Link(){Id = 3, Url = "https://example.server.com/test/folder/1/website.com_111"},
                    },
                    "https://example.server.com/test/folder/#/website.com_109",
                    3
                },
            };
    }
}
