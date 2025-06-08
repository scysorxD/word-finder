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


        [Theory]
        [MemberData(nameof(WordFinderTestCases.GetPerformanceTestCases), MemberType = typeof(WordFinderTestCases))]
        public void FindsExpectedWordsInBigMatrixPerformanceTest(string[] matrix, string[] wordStream, string[] expected)
        {
            var bigMatrix = Enumerable.Range(0, 100).SelectMany(x => matrix).ToList();
            Stopwatch stopwatch = Stopwatch.StartNew();

            var finder = new WordFinder(bigMatrix);
            var result = finder.Find(wordStream).ToArray();
            
            stopwatch.Stop();
            Console.WriteLine($"Time total: {stopwatch.Elapsed}");

            Assert.Equal(expected.OrderBy(x => x), result.OrderBy(x => x));
        }
    }
}