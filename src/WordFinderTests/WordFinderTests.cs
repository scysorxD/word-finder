using System.Diagnostics;
using WordFinderLib;

namespace WordFinderTests
{
    public class WordFinderTests
    {
        [Theory]
        [MemberData(nameof(WordFinderTestCases.GetTestCases), MemberType = typeof(WordFinderTestCases))]
        public void FindsExpectedWordsInMatrix(string[] matrix, string[] wordStream, string[] expected)
        {
            var finder = new WordFinder(matrix);
            var result = finder.Find(wordStream).ToArray();
            
            Assert.Equal(expected.OrderBy(x => x), result.OrderBy(x => x));
        }
    }
}