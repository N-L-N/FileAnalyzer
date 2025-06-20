using FileAnalyzer;

string myFilePath = @"C:\Users\PC\source\repos\FileAnalyzer\FileAnalyzer\TextFile.txt";

MyFileAnalyzer analyzer = new MyFileAnalyzer(myFilePath);

Console.WriteLine($"Имя файла: {analyzer.GetFileName()}");

Console.WriteLine($"Количество слов: {analyzer.GetNumberWords()}");

Console.WriteLine($"Количество уникальных слов: {analyzer.GetNumberUniqueWords()}");

Console.WriteLine("Топ 5 слов:");
foreach (var wordFreq in analyzer.GetTop5Words())
{
    Console.WriteLine($"{wordFreq.Word}: {wordFreq.Count}");
}

Console.WriteLine($"Длина самого длинного слова: {analyzer.GetNumberLargestWord()}");

Console.WriteLine($"Количество строк в файле: {analyzer.GetNumberLines()}");

Console.ReadLine();
