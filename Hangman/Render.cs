namespace Hangman;

public static class Render
{

    private const string Logo = "logo.txt";
    private const string Header = "header.txt";
    private const string HangmanPics = "hangmanPics.txt";
    
    public static void LogoRender(string artDirectory)
    {
        string logoPath = $"{artDirectory}{Logo}";
        string headerPath = $"{artDirectory}{Header}";
        string logo = File.ReadAllText(logoPath);
        string header = File.ReadAllText(headerPath);
        
        
        Console.WriteLine(logo);
        Console.WriteLine(header);
        Thread.Sleep(3000);
    }
    
    public static void Menu()
    {
        Console.Clear();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("*********************");
        Console.WriteLine("*Hangman's Game Menu*");
        Console.WriteLine("*********************");
        Console.ForegroundColor = ConsoleColor.White;

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("1 - Play Game");
        Console.WriteLine("2 - View Leaderboards");
        Console.WriteLine("3 - Add New Word");
        Console.WriteLine("9 - Quit");
        Console.ForegroundColor = ConsoleColor.White;

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("Your pick: ");
        Console.ResetColor();
    }

    public static void TopicMenu(List<string> topics)
    {
        Console.Clear();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("**********************");
        Console.WriteLine("*Topic Selection Menu*");
        Console.WriteLine("**********************");
        Console.ForegroundColor = ConsoleColor.White;

        Console.ForegroundColor = ConsoleColor.Cyan;
        ShowTopics(topics);
        Console.ForegroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("Your pick: ");
        Console.ResetColor();
    }
    
    public static void WordMenu()
    {
        Console.Clear();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("**********************");
        Console.WriteLine("*Word Controller Menu*");
        Console.WriteLine("**********************");
        Console.ForegroundColor = ConsoleColor.White;

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("1 - Add New Topic");
        Console.WriteLine("2 - Add New Word");
        Console.WriteLine("9 - Quit");
        Console.ForegroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("Your pick: ");
        Console.ResetColor();
    }

    private static void ShowTopics(List<string> topics)
    {
        for (int i = 0; i < topics.Count; i++)
        {
            string topic = Path.GetFileNameWithoutExtension(topics[i]);
            Console.WriteLine($"{i + 1} - {topic}");
        }
    }
    
    public static void ShowHangman(string artDirectory, int lives)
    {
        Console.Clear();
        string path = $"{artDirectory}{HangmanPics}";
        string hangman = File.ReadAllText(path);
        string[] hangmanPics = hangman.Split('`'); 
        Console.WriteLine(hangmanPics[lives]);
    }
}