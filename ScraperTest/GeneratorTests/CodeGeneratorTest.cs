using Scraper.Generator;

namespace ScraperTest.GeneratorTests
{
    public class CodeGeneratorTest
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void GetFirstCodesTheory(List<string> data, string pattern)
        {
            bool expected = true;

            var codes = CodeGenerator.GetCodes(pattern).Take(5);
            bool actual = codes.SequenceEqual(data);

            Assert.Equal(expected, actual);
        }
        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[]
                {
                    new List<string>()
                    {
                        "aaa",
                        "aab",
                        "aac",
                        "aad",
                        "aae",
                    },
                    "CCC",
                },
                new object[]
                {
                    new List<string>()
                    {
                        "000",
                        "001",
                        "002",
                        "003",
                        "004",
                    },
                    "000",
                },
                new object[]
                {
                    new List<string>()
                    {
                        "a0a",
                        "a0b",
                        "a0c",
                        "a0d",
                        "a0e",
                    },
                    "a0a",
                },
            };
        [Theory]
        [MemberData(nameof(LastData))]
        public void GetLastCodesTheory(List<string> data, string pattern)
        {
            bool expected = true;

            var codes = CodeGenerator.GetCodes(pattern);
            codes = codes.Skip(codes.Count() - 5);
            bool actual = codes.SequenceEqual(data);

            Assert.Equal(expected, actual);
        }
        public static IEnumerable<object[]> LastData =>
            new List<object[]>
            {
                new object[]
                {
                    new List<string>()
                    {
                        "ZZV",
                        "ZZW",
                        "ZZX",
                        "ZZY",
                        "ZZZ",
                    },
                    "CCC",
                },
                new object[]
                {
                    new List<string>()
                    {
                        "995",
                        "996",
                        "997",
                        "998",
                        "999",
                    },
                    "000",
                },
                new object[]
                {
                    new List<string>()
                    {
                        "z9v",
                        "z9w",
                        "z9x",
                        "z9y",
                        "z9z",
                    },
                    "a0a",
                },
            };
    }
}
