/* Rock, scissor, paper
 * 2 players
 * cpu and user choose between rock, scissor, paper
 * if user wins, user gets 1 point
 * if cpu wins, cpu gets 1 point
 * if tie, nobody gets point
 * best to N input by player
*/
char[] choices = { 'r', 's', 'p' };
string[] choiceNames = { "Rock", "Scissor", "Paper" };

Console.WriteLine("Rock, Scissor, Paper");

Console.WriteLine("Choose an odd number for the number of games you want to play");

string? maxGamesInput = Console.ReadLine();
while (!int.TryParse(maxGamesInput, out _) || int.Parse(maxGamesInput) % 2 == 0)
{
    Console.WriteLine("Choose an odd number");
    maxGamesInput = Console.ReadLine();
}
int maxGames = int.Parse(maxGamesInput);

int userScore = 0;
int cpuScore = 0;

while (userScore <= maxGames / 2 && cpuScore <= maxGames / 2)
{
    Console.WriteLine("Type 'r' for rock, 's' for scissor, 'p' for paper");
    char userChoiceChar = Console.ReadKey().KeyChar;

    Console.WriteLine();

    while (Array.IndexOf(choices, userChoiceChar) == -1)
    {
        Console.WriteLine("Press a valid key! ('r', 's' or 'p')");
        userChoiceChar = Console.ReadKey().KeyChar;
        Console.WriteLine();
    }

    int userChoice = Array.IndexOf(choices, userChoiceChar);
    int cpuChoice = new Random().Next(0, 3);
    
    Console.WriteLine();
    Console.WriteLine($"CPU chose {choiceNames[cpuChoice]}");
    Console.WriteLine($"You chose {choiceNames[userChoice]}");

    if (userChoice == cpuChoice)
    {
        Console.WriteLine("Tie");
    }
    else if ((userChoice == 0 && cpuChoice == 1) || (userChoice == 1 && cpuChoice == 2) || (userChoice == 2 && cpuChoice == 0))
    {
        Console.WriteLine("You win\nResult: You " + (++userScore) + " - CPU " + (cpuScore));
    }
    else
    {
        Console.WriteLine("CPU wins\nResult: You " + (userScore) + " - CPU " + (++cpuScore));
    }

    Console.WriteLine("---------\n");
}

Console.WriteLine("Game over\n*************************");
if (userScore > cpuScore)
{
    Console.WriteLine("Congratulations!!! YOU WON");
}
else
{
    Console.WriteLine("Too Bad! YOU LOST");
}