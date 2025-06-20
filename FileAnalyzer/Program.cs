using FileAnalyzer;

string myFilePath = @"C:\Users\PC\source\repos\FileAnalyzer\FileAnalyzer\TextFile.txt";

MyFileAnalyzer analyzer = new MyFileAnalyzer(myFilePath);

Console.WriteLine($"Имя файла: {analyzer.GetFileName()}");

Console.WriteLine($"Количество слов: {analyzer.GetNumberWords()}");

Console.WriteLine($"Количество уникальных слов: {analyzer.GetNumberUniqueWords()}");

Console.WriteLine("Топ 5 повторяющихся слов:");
foreach (var wordFreq in analyzer.GetTop5Words())
{
    Console.WriteLine($"{wordFreq.Word}: {wordFreq.Count}");
}

string word = analyzer.GetLargestWord().word;
int number = analyzer.GetLargestWord().number;
Console.WriteLine($"Длина самого длинного слова: {number}, слово: {word}");

Console.WriteLine($"Количество строк в файле: {analyzer.GetNumberLines()}");

Console.ReadLine();
