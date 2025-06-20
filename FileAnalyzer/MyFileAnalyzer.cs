using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAnalyzer
{
    public class MyFileAnalyzer
    {
        private string _path;

        private string _content;

        public record WordFrequency(string Word, int Count);
        public MyFileAnalyzer(string path) 
        {
            _path = path;

            if (!System.IO.File.Exists(_path))
            {
                throw new System.IO.FileNotFoundException("File not found", _path);
            }
            _content = System.IO.File.ReadAllText(_path);
        }

        public string GetFileName()
        {
            return System.IO.Path.GetFileName(_path);
        }

        public int GetNumberWords()
        {
            var words = _content.Split(new[] {' ', '\n', '\r', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        public int GetNumberUniqueWords()
        {
            var words = _content.Split(new[] { ' ', '\n', '\r', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Select(word => word.ToLowerInvariant()).Distinct().Count();
        }

        public List<WordFrequency> GetTop5Words()
        {
            var words = _content.Split(new[] { ' ', '\n', '\r', ',', '.' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(word => word.ToLowerInvariant())
                .GroupBy(word => word)
                .Select(group => new WordFrequency(group.Key, group.Count()))
                .OrderByDescending(wf => wf.Count)
                .Take(5)
                .ToList();

            return words;
        }

        public(int number, string word) GetLargestWord()
        {
            var words = _content.Split(new[] { ' ', '\n', '\r', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            int number = words.Select(word => word.Length).DefaultIfEmpty(0).Max();

            string word = words.FirstOrDefault(w => w.Length == number) ?? string.Empty;

            return (number, word);
        }

        public int GetNumberLines()
        {
            return _content.Split(['\n'], StringSplitOptions.RemoveEmptyEntries).Length;
        }   
    }
}
