namespace Hangman;

public class Player
{
    public int Score { get; private set; }
    public int Lives { get; private set; } = 9;

    public char PlayerInput()
    {
        while (true)
        {
            Console.Write("Type the letter: ");
            bool success = char.TryParse(Console.ReadLine(), out char playerInput);

            if (success)
                return playerInput;

            else 
                Console.WriteLine("Invalid value!");
        }
    }

    public void TakeLive()
    {
        Lives--;
    }

}