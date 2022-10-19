// See https://aka.ms/new-console-template for more information
// https://github.com/cowtrix/gnuciDictionary
IEnumerable<gnuciDictionary.Word> allwords = gnuciDictionary.EnglishDictionary.GetAllWords();

while (true)
{
    var score = 0;
    //Starting game of hangman
    Console.WriteLine("New Game of Hangman ->");
    var inputs = new List<string>();
    if (allwords == null)
    {
        throw new Exception("no words loaded");
    }
    
    List<string> word =
        allwords.Where(u => u != null)
            .Select(u => u.Value)
            .ToList();
    var random = new Random().Next(word.Count);
    //get random word out of word list
    var word2 = word[random];
    var output = word2.ToArray().Aggregate("", (current, c) => current + "_");
    
    Console.WriteLine(output);
    //when you have not guessed the word right this continues or you type quit
    while (output.Contains('_'))
    {
        var input = Console.ReadLine();
        inputs.Add(input);
        if (word2.Contains(input))
        {
            var indexes = inputs.Select(inp => word2.IndexOf(inp, StringComparison.Ordinal)).ToList();

            output = "";
            for (var i = 0; i < word2.ToArray().Length; i++)
            {
                var c = word2.ToArray()[i];
                var inputed = false;
                foreach(var inde in indexes)
                {
                    //insert character if you guessed them correctly in the past
                    if (inde == i)
                    {
                        output += c;
                        inputed = true;
                        break;
                    }
                
                }

                if (inputed)
                {
                
                }
                else
                {
                    output += "_";
                }
            }
        }
        //TODO: add quit statement
        if (input == word2)
        {
            break;
        }

        if (input == "quit")
        {
            Console.WriteLine("Word was: " + word2);
            break;
        }
        
        Console.WriteLine(output + " score: " + score);
        score++;
    }
    Console.WriteLine("You won with score " + score);
    Console.WriteLine();
}

