// See https://aka.ms/new-console-template for more information
// https://github.com/cowtrix/gnuciDictionary

using ConsoleApp1;
using gnuciDictionary;

var allWords = WordsLoader.ExtractAllEnglishWords().ToList();
var userInterface = new ConsoleOutput();

while (true)
{
    //Starting game of hangman
    var score = 0;
    var currentGameUserInputs = new List<string>();
    var word2 = new Word(" "," ", " ");
    while (word2.Value.Contains(' '))
    {
        var random = new Random().Next(allWords.Count);
        //get random word out of word list
        word2 = allWords[random];
    }
    var word3 = word2.Value.ToLower();
    var output = word3.ToArray().Aggregate("", (current, c) => current + "_");
    
    userInterface.NewGame();
    Console.WriteLine(output);
    
    //when you have not guessed the word right this continues or you type quit
    while (output.Contains('_'))
    {
        var input = Console.ReadLine();
        currentGameUserInputs.Add(input);
        if (word3.Contains(input))
        {
            var indexes = new List<int>();
            foreach (var inp in currentGameUserInputs)
            {
                for (int i = word3.IndexOf(inp); i > -1; i = word3.IndexOf(inp, i + 1))
                {
                    // for loop end when i=-1 ('a' not found)
                    indexes.Add(i);
                }
            }
            
            //var indexes = inputs.Select(inp => word3.IndexOf(inp, StringComparison.Ordinal)).ToList();

            output = "";
            for (var i = 0; i < word3.ToArray().Length; i++)
            {
                var c = word3.ToArray()[i];
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
        if (input == word3)
        {
            break;
        }

        if (input == "quit")
        {
            Console.WriteLine("Word was -> " + word2);
            break;
        }
        
        Console.WriteLine(output + " score: " + score);
        score++;
    }
    Console.WriteLine("You won with score " + score);
    Console.WriteLine();
}

