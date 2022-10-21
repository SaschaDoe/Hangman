using gnuciDictionary;

namespace ConsoleApp1;

public class WordsLoader
{
    public static IEnumerable<Word> ExtractAllEnglishWords()
    {
        var allWords = EnglishDictionary.GetAllWords();
        if (allWords == null)
        {
            throw new Exception("no words loaded");
        }
        return allWords;
    }
}