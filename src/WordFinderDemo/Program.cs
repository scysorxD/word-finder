using Microsoft.Extensions.DependencyInjection;
using WordFinderLib;


var services = new ServiceCollection();

var matrix = new[]
{
    "ABCDC",
    "FGWIO",
    "CHILL",
    "PQNSD",
    "UVDXY"
};

services.AddScoped<IWordFinder>(_ => new WordFinder(matrix));

var serviceProvider = services.BuildServiceProvider();
var wordFinder = serviceProvider.GetRequiredService<IWordFinder>();

var wordStream = new[] { "COLD", "WIND", "SNOW", "CHILL", "AFCP" }; 

var foundWords = wordFinder.Find(wordStream);

Console.WriteLine("Words found in matrix:");
foreach (var word in foundWords)
{
    Console.WriteLine($"{word}");
}

Console.WriteLine("Press Any key to exit...");
Console.ReadKey();