// See https://aka.ms/new-console-template for more information

var word = new[]{"House", "Mouse"};
while (true)
{
    var score = 0;
    Console.WriteLine("New Game of Hangman ->");
    var inputs = new List<string>();
    var random = new Random().Next(word.Length - 1);
    var word2 = word[random];
    var output = word2.ToArray().Aggregate("", (current, c) => current + "_");
    
    Console.WriteLine(output);
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

        if (input == word2)
        {
            break;
        }
        
        Console.WriteLine(output + " score: " + score);
        score++;
    }
    Console.WriteLine("You won with score " + score);
    Console.WriteLine();
}

