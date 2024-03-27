namespace Hangman;

public class Game
{
    private readonly WordProvider _wordProvider = new WordProvider(WordDirectory);
    private readonly Random _random = new Random();
    private const string ArtDirectory = @"C:\Users\lamer\RiderProjects\Hangman\Hangman\render\";
    private const string WordDirectory = @"C:\Users\lamer\RiderProjects\Hangman\Hangman\data\";
    
    public void Run()
    {
        int userSelect;
        Render.LogoRender(ArtDirectory);
        
        do
        {
            Render.Menu();
            int.TryParse(Console.ReadLine(), out userSelect);

            switch (userSelect)
            {
                case 1:
                    StartGame();
                    break;
                case 2:
                    ViewLeaderBoard();
                    break;
                case 3:
                    _wordProvider.AddNewWord();
                    break;
                case 9:
                    break;
                default:
                    Console.WriteLine("Invalid value!");
                    break;

            }
            
        } while (userSelect != 9);


    }
    private void StartGame()
    {
        
        Player player = new Player();
        string[] words = _wordProvider.GetWords();
        int randomWord = _random.Next(words.Length);
        string computerGuessedWord = words[randomWord];
        
        char[] computerGuessedLetter = computerGuessedWord.ToLower().ToCharArray();
        char[] guessedLetters = InitializeGuessedWord(computerGuessedLetter);
        string guessedWord = new string(guessedLetters);
        
        Console.Clear();
        
        while (player.Lives != 0)
        {
            Console.WriteLine(guessedWord);
            
            char playerInput = player.PlayerInput();
            CheckLetter(computerGuessedLetter, guessedLetters, playerInput, player);
            guessedWord = new string(guessedLetters);
            
            if (!IsWin(computerGuessedWord.ToLower(), guessedWord, player.Lives)) continue;
            Console.Clear();
            Console.WriteLine("You've won!");
            break;
        }
        
        Console.WriteLine($"The guessed word was {computerGuessedWord}");
        Thread.Sleep(3000);
        
    }
    private void ViewLeaderBoard()
    {
        Console.WriteLine("WIP");
    }

    private void CheckLetter(char[] computerGuessed, char[] guessedWord, char playerInput, Player player)
    {
        Console.Clear();
        if (computerGuessed.Contains(playerInput))
        {
            for (int i = 0; i < computerGuessed.Length; i++)
            {
                if (computerGuessed[i] != playerInput) continue;
                computerGuessed[i] = playerInput;
                guessedWord[i] = computerGuessed[i];
            }
        }
        else
        {
            player.TakeLive();
            Render.ShowHangman(ArtDirectory, player.Lives);
        }
    }

    private bool IsWin(string computerGuessedWord, string guessedWord, int lives) =>
        computerGuessedWord == guessedWord && lives != 0; 

    private static char[] InitializeGuessedWord(char[] computerGuessed)
    {
        char[] guessedWord = new char[computerGuessed.Length];
        
        for (int i = 0; i < guessedWord.Length; i++)
        {
            if (computerGuessed[i] == ' ')
                guessedWord[i] = ' ';
            else
                guessedWord[i] = '_';
        }

        return guessedWord;
    }
    
}