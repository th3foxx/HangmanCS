namespace Hangman;

public class Render
{
    public string RenderDirectory { get; init; }
    public string FileLogo { get; init; }
    public string FileHeader { get; init; }

    public Render(string renderDirectory, string fileLogo, string fileHeader)
    {
        RenderDirectory = renderDirectory;
        FileLogo = fileLogo;
        FileHeader = fileHeader;
    }
    
    public void LogoRender()
    {
        string logoPath = $"{RenderDirectory}{FileLogo}";
        string headerPath = $"{RenderDirectory}{FileHeader}";
        string logo = File.ReadAllText(logoPath);
        string header = File.ReadAllText(headerPath);
        
        
        Console.WriteLine(logo);
        Console.WriteLine(header);
    }
    
    public void Menu()
    {
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
}