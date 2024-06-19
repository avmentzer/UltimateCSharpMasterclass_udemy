public class GuessingGame
{
    private readonly RandomDice _dice;
    private const int InitialTries = 3;

    public GuessingGame(RandomDice dice)
    {
        _dice = dice;
    }

    public void Run()
    {
        int result = _dice.Roll();

        Console.WriteLine($"Rolled: {result}");
        Console.WriteLine($"Dice rolled. Guess what number it shows in {InitialTries} tries:");

        for (int i = 0; i < InitialTries; i++)
        {
            string userInput = Console.ReadLine();
            string message = int.TryParse(userInput, out int guess)
                ? guess == result ? "You win!" : "Wrong number. Enter number:"
                : "Incorrect input.";
            Console.WriteLine(message);
            if (message == "You win!")
                return;
            else if (message == "Incorrect input.")
                i--;
        }

        Console.WriteLine("You lose");
    }

    public static void Main(string[] args)
    {
        RandomDice diceInstance = new RandomDice(new Random());
        GuessingGame GuessingGame = new GuessingGame(diceInstance);
        GuessingGame.Run();
    }
}
