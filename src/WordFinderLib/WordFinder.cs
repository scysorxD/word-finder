namespace WordFinderLib
{
    public class WordFinder : IWordFinder
    {
        private readonly List<string> _horizontalLines;
        private readonly List<string> _verticalLines;

        public WordFinder(IEnumerable<string> matrix)
        {
            if (matrix == null || !matrix.Any())
                throw new ArgumentException("Matrix cannot be null or empty");

            var firstRow = matrix.First();

            if (matrix.Any(row => row.Length != firstRow.Length))
                throw new ArgumentException("All rows in the matrix must have the same length");

            _horizontalLines = matrix.Select(x => x.ToUpperInvariant()).ToList();

            int numCols = firstRow.Length;
            int numRows = _horizontalLines.Count;
            _verticalLines = new List<string>();

            for (int col = 0; col < numCols; col++)
            {
                var column = new char[numRows];
                for (int row = 0; row < numRows; row++)
                    column[row] = _horizontalLines[row][col];

                _verticalLines.Add(new string(column));
            }
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            var distinctWords = wordstream.Select(s => s.ToUpperInvariant()).Distinct();
        
            var wordCounts = new Dictionary<string, int>();

            foreach (var word in distinctWords)
            {
                int count = CountOccurrences(word);
                if (count > 0) wordCounts[word] = count;
            }

            return wordCounts
                .OrderByDescending(x => x.Value)
                .Take(10)
                .Select(s => s.Key);
        }

        private int CountOccurrences(string word)
        {
            int count = 0;

            foreach (var row in _horizontalLines)
                count += CountWordInLine(row, word);

            foreach (var col in _verticalLines)
                count += CountWordInLine(col, word);

            return count;
        }

        private static int CountWordInLine(string line, string word)
        {
            int count = 0;
            int index = 0;

            while ((index = line.IndexOf(word, index)) != -1)
            {
                count++;
                index += word.Length;
            }

            return count;
        }
    }
}
