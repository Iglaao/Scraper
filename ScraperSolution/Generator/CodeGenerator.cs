using System;
using System.Collections.Generic;
using System.Linq;

namespace Scraper.Generator
{
    public static class CodeGenerator
    {
        private static IEnumerable<IEnumerable<T>> Combine<T>(IEnumerable<IEnumerable<T>> sequences)
        {
            IEnumerable<IEnumerable<T>> emptyProduct = new[] { Enumerable.Empty<T>() };

            return sequences.Aggregate(
              emptyProduct,
              (accumulator, sequence) =>
                from accseq in accumulator
                from item in sequence
                select accseq.Concat(new[] { item }));
        }
        public static IEnumerable<string> GetCodes(string pattern)
        {
            string lowercase = "abcdefghijklmnopqrstuvwxyz"; // a
            string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // A
            string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"; // C
            string digits = "0123456789"; // 0
            string everything = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"; // E

            var sets = pattern.Select(ch => ch == 'C' ? letters :
                                            (ch == 'a' ? lowercase :
                                            (ch == 'A' ? uppercase :
                                            (ch == '0' ? digits : everything))));

            return Combine(sets).Select(x => new String(x.ToArray()));
        }
        public static IEnumerable<IEnumerable<T>> Split<T>(IEnumerable<T> list, int parts)
        {
            int i = 0;
            var splits = from item in list
                         group item by i++ % parts into part
                         select part.AsEnumerable();
            return splits.ToList();
        }
    }
}
